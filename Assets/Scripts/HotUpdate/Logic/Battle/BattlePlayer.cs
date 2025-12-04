
using ADK;
using Elida.Config;
using protobuf.login;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 战斗播放器
/// </summary>
public class BattlePlayer
{
    private BattleRoundVo roundData;//当前行动单元数据
    private int actionInd = 0;//玩家行为单元索引
    private int buffSeqInd = 0;//播放玩家buff队列索引
    private ulong lastRound = 0;
    private List<BattleRoundVo> roundDetails;//玩家战斗行动单元数据
    private List<FightHeroUnit> _heroCamps;//玩家阵营(0：我方 1：对方)
    private Dictionary<int, FightPetUnit> _petMyCamps;//我方宠物列表
    private Dictionary<int, FightPetUnit> _petOtherCamps;//对方宠物列表
    private List<FightEnemyUnit> _enemys;//对方宠物列表
    private Dictionary<int, fun_Battle.FlowerFairiesItem> _myFlowerFairies;
    private Dictionary<int, fun_Battle.FlowerFairiesItem> _otherFlowerFairies;
    private Action _playFinishCall;//播放完成回调
    private Dictionary<int, bool> dodgeActionDic;//存储闪避已push队列的行动单元

    public List<FightHeroUnit> heroCamps
    {
        set { _heroCamps = value; }
    }

    public Dictionary<int, FightPetUnit> petMyCamps
    {
        set { _petMyCamps = value; }
    }

    public Dictionary<int, FightPetUnit> petOtherCamps
    {
        set { _petOtherCamps = value; }
    }
    public List<FightEnemyUnit> enemys
    {
        set { _enemys = value; }
    }

    public Dictionary<int, fun_Battle.FlowerFairiesItem> myFlowerFairies
    {
        set { _myFlowerFairies = value; }
    }

    public Dictionary<int, fun_Battle.FlowerFairiesItem> otherFlowerFairies
    {
        set { _otherFlowerFairies = value; }
    }

    public Action playFinishCall
    {
        set { _playFinishCall = value; }
    }

    /// <summary>
    /// 重新开始
    /// </summary>
    public void Start()
    {
        roundDetails = BattleModel.Instance.roundDetails;
        dodgeActionDic = new Dictionary<int, bool>();
        lastRound = 0;
        actionInd = 1;
        buffSeqInd = 1;
        BattleModel.Instance.isBattlePlay = true;
        Play();
    }

    private void Play()
    {
        if (!BattleModel.Instance.isBattlePlay) return;
        if (actionInd <= roundDetails.Count)
        {
            roundData = roundDetails[actionInd - 1];
            PlayPlayerAction(roundData);
        }
        else//回合播放完毕 结束战斗
        {
            Debug.Log("回合播放完毕 结束战斗");
            End();
        }
    }

    /// <summary>
    /// 播放玩家的行动单元
    /// </summary>
    private void PlayPlayerAction(BattleRoundVo roundData)
    {
        UpdateRound(roundData.round);
        PlayBuffSeq(roundData);
    }

    /// <summary>
    /// 更新回合数
    /// </summary>
    /// <param name="round"></param>
    private void UpdateRound(ulong round)
    {
        EventManager.Instance.DispatchEvent(BattleEvent.UpdateActionUnit, actionInd);
        Debug.Log("当前行动单元:" + actionInd);
        if (lastRound != round)
        {
            Debug.Log("当前回合数:" + round);
            OnPerRoundUpdateBuffList();
            EventManager.Instance.DispatchEvent(BattleEvent.UpdateRound, round);
        }
        lastRound = round;
    }


    /// <summary>
    /// 每回合开始前更新玩家双方的buff
    /// </summary>
    private void OnPerRoundUpdateBuffList()
    {
        if (roundData != null)
        {
            foreach (var heroCamp in _heroCamps)
            {
                heroCamp.OnPerRoundUpdateBuffList(roundData.buffSeq);
            }
        }
    }




    /// <summary>
    /// 
    /// </summary>
    private void PlayBuffSeq(BattleRoundVo roundData)
    {
        //Debug.Log("执行round :" + roundData.round);
        var curIndex = actionInd - 1;
        Debug.Log("执行 actionInd:" + curIndex);
        var buffSeq = roundData.buffSeq;
        if (roundData.isDodge)//但是玩家攻击触发了闪避 也需要表现玩家攻击 敌人飘闪避
        {
            if (!dodgeActionDic.ContainsKey(actionInd))//每个行动单元确保只能放到队列一次
            {
                Debug.Log("执行闪避");
                BuffSeqVo buff = new BuffSeqVo();
                buff.t = 0;
                buff.s = 2;
                buff.sid = -1;
                buff.buffId = 0;
                buff.f = true;//自己攻击方恒为已方
                buff.v = 0;
                buff.enemytargetId = (int)roundData.enemyId;
                buff.userId = (int)roundData.userId;
                buffSeq.Add(buff);//自己添加到队列里面
                dodgeActionDic.Add(actionInd, true);
            }
        }
        if (buffSeqInd <= buffSeq.Count)
        {
            Debug.Log("执行 buffSeqInd:" + (buffSeqInd - 1));
            PlayActionByType(roundData, buffSeq[buffSeqInd - 1], SwitchNextAction);
        }
        else//没有buff队列
        {
            Debug.Log("执行 禁锢行动");
            Debug.Log("禁锢行动 直接切换下个行动回合");
            SwitchNextAction();
        }
    }

    /// <summary>
    /// 根据id获取一个
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    private FightEnemyUnit GetFightEnemyUnit(int id)
    {
        foreach (var enemy in _enemys)
        {
            if ((int)enemy.fightUnitId == id)
            {
                return enemy;
            }
        }
        return null;
    }

    /// <summary>
    /// 根据行为播放行动单元
    /// </summary>
    private void PlayActionByType(BattleRoundVo roundData, BuffSeqVo action, System.Action actCallback = null)
    {
        BaseFightUnit caster = null;//攻击者
        BaseFightUnit target = null;//受击者
        bool isReversal = false;//是否翻转攻击受击
        if (roundData.isAttacker)//我方是攻击者
        {
            caster = _heroCamps[0];
            if (!BattleModel.Instance.isPve)//pvp受击者是主角
            {
                target = _heroCamps[1];
            }
            else//pve受击者是enemy
            {
                target = GetFightEnemyUnit(action.enemytargetId);
            }
            if (!action.f)//取反
            {
                if (!BattleModel.Instance.isPve)
                {
                    caster = _heroCamps[1];
                }
                else
                {
                    caster = GetFightEnemyUnit(action.enemytargetId);
                }
                target = _heroCamps[0];
                isReversal = true;
            }
        }
        else//对方是攻击者
        {
            if (!BattleModel.Instance.isPve)//pvp攻击者是主角
            {
                caster = _heroCamps[1];
            }
            else//pve攻击者是enemy
            {
                caster = GetFightEnemyUnit(action.userId);
            }
            target = _heroCamps[0];
            if (!action.f)//取反
            {
                caster = _heroCamps[0];
                if (!BattleModel.Instance.isPve)//pvp攻击者是主角
                {
                    target = _heroCamps[1];
                }
                else
                {
                    target = GetFightEnemyUnit(action.userId);
                }
                isReversal = true;
            }
        }

        switch (action.t)//类型 0：攻击 1：buff
        {
            case (uint)BuffTriggerType.Attack:

                if (action.s == (uint)BuffTriggerRoleType.Hero)//玩家触发的攻击
                {
                    Debug.Log("执行 玩家攻击");
                    //释放完技能回调
                    void OnSkillAttaclkEnd()
                    {
                        UpdateHeroHp(caster, target, action, true);
                        var isNomal = true;//是否是普通伤害
                        var isCrit = false;//是否暴击
                        if (roundData.isChase)//连击
                        {
                            caster.AddFloatInQueen(TriggerCombatAttribute.Chase);
                        }
                        if (roundData.isCrit)//暴击在受击者飘
                        {
                            isNomal = false;
                            isCrit = true;
                            target.AddFloatInQueen(TriggerCombatAttribute.Crit, "-" + action.v);
                        }
                        if (roundData.isDodge)//闪避在受击者飘
                        {
                            isNomal = false;
                            target.AddFloatInQueen(TriggerCombatAttribute.Dodge);
                        }
                        if (roundData.isStun)//击晕在受击者飘 同时显示眩晕特效
                        {
                            isNomal = false;
                            if (!isCrit)//没有暴击才显示普通攻击伤害飘字
                            {
                                target.AddFloatInQueen(TriggerCombatAttribute.Nomal, "-" + action.v);
                            }
                            target.AddFloatInQueen(TriggerCombatAttribute.Stun);//TODO：后续需修改为播放眩晕特效
                        }
                        if (roundData.lifesteal > 0 && roundData.reflect > 0)//吸血和反弹共存
                        {
                            isNomal = false;
                            if (!roundData.isCrit)//暴击就不再重复显示伤害了 上面已经显示了
                            {
                                target.AddFloatInQueen(TriggerCombatAttribute.Nomal, "-" + action.v);//受击者显示伤害
                            }
                            caster.AddFloatInQueen(TriggerCombatAttribute.Lifesteal, "+" + roundData.lifesteal);//攻击者显示特效+吸血数量飘字
                            target.AddFloatInQueen(TriggerCombatAttribute.Reflect, roundData.reflect.ToString());//受击者显示反弹飘字
                            caster.AddFloatInQueen(TriggerCombatAttribute.Nomal, "-" + roundData.reflect);//攻击者受反弹伤害飘字
                        }
                        else
                        {
                            if (roundData.lifesteal > 0)//吸血在攻击者飘(这里不飘字 显示特效) 同时显示吸血数字
                            {
                                isNomal = false;
                                if (!isCrit)//暴击就不再重复显示伤害了 上面已经显示了
                                {
                                    target.AddFloatInQueen(TriggerCombatAttribute.Nomal, "-" + action.v);//受击者显示伤害
                                }
                                caster.AddFloatInQueen(TriggerCombatAttribute.Lifesteal, "+" + roundData.lifesteal);//攻击者显示特效+吸血数量飘字
                            }
                            if (roundData.reflect > 0)//反弹在受击者飘 同时显示显示反弹数字
                            {
                                isNomal = false;
                                if (!roundData.isCrit)//暴击就不再重复显示伤害了 上面已经显示了
                                {
                                    target.AddFloatInQueen(TriggerCombatAttribute.Nomal, "-" + action.v);//受击者显示伤害
                                }
                                target.AddFloatInQueen(TriggerCombatAttribute.Reflect, roundData.reflect.ToString());//受击者显示特效+吸血数量飘字
                                caster.AddFloatInQueen(TriggerCombatAttribute.Nomal, "-" + roundData.reflect);//攻击者受反弹伤害飘字
                            }
                        }
                        if (isNomal)//普通伤害攻击
                        {
                            target.AddFloatInQueen(TriggerCombatAttribute.Nomal, "-" + action.v);
                        }
                    }

                    //技能是否完毕
                    void OnReleaseSkillEnd()
                    {
                        if (caster.isDie || target.isDie)//攻击方/受击方有一方死亡
                        {
                            BaseFightUnit dieBaseFightUnit = null;//死亡那方
                            if (caster.isDie)//攻击方死亡
                            {
                                dieBaseFightUnit = caster;
                            }
                            else if (target.isDie)//目标方死亡
                            {
                                dieBaseFightUnit = target;
                            }
                            if (dieBaseFightUnit.isShowDie)//死亡表现中 等待回调之后再执行下面流程
                            {
                                //死亡动画播放完毕回调流程
                                dieBaseFightUnit.SetDieFinishCall(actCallback);
                            }
                            else//表现完了 直接回调
                            {
                                actCallback();
                            }
                            Debug.Log("有一方死亡，延迟回调");
                        }
                        else
                        {
                            if (caster.isShowRevive || target.isShowRevive)//攻击方/受击方有一方复活
                            {
                                BaseFightUnit reviveBaseFightUnit = null;//死亡那方
                                if (caster.isShowRevive)//攻击方复活
                                {
                                    reviveBaseFightUnit = caster;
                                }
                                else if (target.isShowRevive)//目标方复活
                                {
                                    reviveBaseFightUnit = target;
                                }
                                //复活动画播放完毕回调流程
                                reviveBaseFightUnit.SetReviveviFinishCall(actCallback);
                            }
                            else
                            {
                                actCallback?.Invoke();
                            }
                        }
                    }


                    if (CheckFightHeroUnitActInvalid(caster, target))
                    {
                        Debug.Log("目标行为无效，跳过");
                        actCallback?.Invoke();
                        return;
                    }

                    caster.target = target;//设置受击者
                    caster.isCril = roundData.isCrit;//设置攻击者是否暴击
                    if (!BattleModel.Instance.isPve || caster is FightHeroUnit)//pve主角只会放1技能
                    {
                        caster.Attack();
                        SkillManager.Instance.ReleaseSkill(1, caster, target, OnSkillAttaclkEnd, OnReleaseSkillEnd);
                    }
                    else//pve的话 需要区分近战还是远程技能
                    {
                        var isRemoteAttack = false;
                        var enemyConfig = AdventureModel.Instance.GetEnemyConfig((int)caster.fightUnitId);
                        if (enemyConfig != null)
                        {
                            if (enemyConfig.AttackType == 1)//近战
                            {
                                isRemoteAttack = false;
                            }
                            else if (enemyConfig.AttackType == 2)//远程
                            {
                                isRemoteAttack = true;
                            }
                        }
                        if (isRemoteAttack)//远程攻击
                        {
                            //caster.Attack();
                            ////受击方原地释放受击特效 播放伤害--远程攻击
                            //SkillManager.Instance.ReleaseSkill(2, caster, target, OnSkillAttaclkEnd, OnReleaseSkillEnd);
                            //攻击者攻击回调
                            caster.SetAttack(OnSkillAttaclkEnd);
                            //攻击者攻击流程执行完毕回调
                            caster.SetAttackFinishCall(OnReleaseSkillEnd);
                        }
                        else//近战攻击
                        {
                            caster.SetAttack(OnSkillAttaclkEnd);
                            //攻击者攻击流程执行完毕回调
                            caster.SetAttackFinishCall(OnReleaseSkillEnd);
                        }
                        caster.Attack();
                    }
                }
                else//非玩家触发的攻击
                {
                    //宠物/花仙播放攻击动作
                    if (action.s == (uint)BuffTriggerRoleType.FlowerFairy)//花仙
                    {
                        Debug.Log("执行 花仙攻击");
                        fun_Battle.FlowerFairiesItem casterFairies = null;//攻击者
                        if (roundData.isAttacker)
                        {
                            if (!action.f)//取反 
                            {
                                _otherFlowerFairies.TryGetValue(action.sid, out casterFairies);
                            }
                            else
                            {
                                _myFlowerFairies.TryGetValue(action.sid, out casterFairies);
                            }
                        }
                        else
                        {

                            if (!action.f)//取反 
                            {
                                _myFlowerFairies.TryGetValue(action.sid, out casterFairies);
                            }
                            else
                            {
                                _otherFlowerFairies.TryGetValue(action.sid, out casterFairies);
                            }
                        }
                        if (casterFairies != null)
                        {
                            casterFairies.Attack();
                        }
                        else
                        {
                            Debug.Log("花仙攻击对象不存在,casterFairies:" + action.sid);
                        }
                    }
                    else if (action.s == (uint)BuffTriggerRoleType.Pet)//宠物
                    {
                        Debug.Log("执行 宠物攻击");
                        BaseFightUnit casterPet = null;//攻击者
                        if (roundData.isAttacker)
                        {
                            if (!action.f)//取反 
                            {
                                casterPet = _petOtherCamps[action.sid];
                            }
                            else
                            {
                                casterPet = _petMyCamps[action.sid];
                            }
                        }
                        else
                        {

                            if (!action.f)//取反 
                            {
                                casterPet = _petMyCamps[action.sid];
                            }
                            else
                            {
                                casterPet = _petOtherCamps[action.sid];
                            }
                        }
                        if (casterPet != null)
                        {
                            if (CheckFightHeroUnitActInvalid(caster, target))
                            {
                                Debug.Log("目标行为无效，跳过");
                                actCallback?.Invoke();
                                return;
                            }
                            casterPet.SetAttack(() =>
                            {
                                UpdateHeroHp(caster, target, action, true);
                                //飘攻击伤害
                                target.AddFloatInQueen(TriggerCombatAttribute.Nomal, "-" + action.v);
                            });
                            casterPet.SetAttackFinishCall(() =>
                            {
                                if (caster.isDie || target.isDie)//攻击方/受击方有一方死亡
                                {
                                    Debug.Log("有一方死亡，延迟回调");
                                    BaseFightUnit dieBaseFightUnit = null;//死亡那方
                                    if (caster.isDie)//攻击方死亡
                                    {
                                        dieBaseFightUnit = caster;
                                    }
                                    else if (target.isDie)//目标方死亡
                                    {
                                        dieBaseFightUnit = target;
                                    }
                                    if (dieBaseFightUnit.isShowDie)//死亡表现中 等待回调之后再执行下面流程
                                    {
                                        //死亡动画播放完毕回调流程
                                        dieBaseFightUnit.SetDieFinishCall(actCallback);
                                    }
                                    else//表现完了 直接回调
                                    {
                                        actCallback();
                                    }
                                }
                                else
                                {
                                    if (caster.isShowRevive || target.isShowRevive)//攻击方/受击方有一方复活
                                    {
                                        BaseFightUnit reviveBaseFightUnit = null;//死亡那方
                                        if (caster.isShowRevive)//攻击方复活
                                        {
                                            reviveBaseFightUnit = caster;
                                        }
                                        else if (target.isShowRevive)//目标方复活
                                        {
                                            reviveBaseFightUnit = target;
                                        }
                                        //复活动画播放完毕回调流程
                                        reviveBaseFightUnit.SetReviveviFinishCall(actCallback);
                                    }
                                    else
                                    {
                                        actCallback?.Invoke();
                                    }
                                }
                            });
                            casterPet.Attack();
                        }
                        else
                        {
                            Debug.Log("宠物攻击对象不存在,casterPet:" + action.sid);
                        }
                    }
                }
                break;
            case (uint)BuffTriggerType.Buff:
                if (action.s == (uint)BuffTriggerRoleType.FlowerFairy)//花仙
                {
                    Debug.Log("执行 花仙Buff");
                    fun_Battle.FlowerFairiesItem casterFairies = null;//攻击者
                    if (roundData.isAttacker)
                    {
                        if (!action.f)//取反 
                        {
                            _otherFlowerFairies.TryGetValue(action.sid, out casterFairies);
                        }
                        else
                        {
                            _myFlowerFairies.TryGetValue(action.sid, out casterFairies);
                        }
                    }
                    else
                    {
                        if (!action.f)//取反 
                        {
                            _myFlowerFairies.TryGetValue(action.sid, out casterFairies);
                        }
                        else
                        {
                            _otherFlowerFairies.TryGetValue(action.sid, out casterFairies);
                        }
                    }
                    if (casterFairies != null)
                    {
                        if (CheckFightHeroUnitActInvalid(caster, target))
                        {
                            Debug.Log("目标行为无效，跳过");
                            actCallback?.Invoke();
                            return;
                        }
                        bool isLossBlood = false;//被攻击减血了
                        var buffConfig = BattleModel.Instance.GetBuffConfig((int)action.buffId);
                        if (buffConfig != null && (buffConfig.BuffType == 1 || buffConfig.BuffType == 20 || buffConfig.BuffType == 21 || buffConfig.BuffType == 27))//触发血量变更的buff才需要更新血量
                        {
                            isLossBlood = buffConfig.BuffType == 1;
                            UpdateHeroHp(caster, target, action, isLossBlood);
                        }
                        AddBuff(action.skillId, action, action.buffId, caster, target, casterFairies);
                        if (isLossBlood && (caster.isDie || target.isDie))//攻击方/受击方有一方死亡
                        {
                            Debug.Log("有一方死亡，延迟回调");
                            BaseFightUnit dieBaseFightUnit = null;//死亡那方
                            if (caster.isDie)//攻击方死亡
                            {
                                dieBaseFightUnit = caster;
                            }
                            else if (target.isDie)//目标方死亡
                            {
                                dieBaseFightUnit = target;
                            }
                            if (dieBaseFightUnit.isShowDie)//死亡表现中 等待回调之后再执行下面流程
                            {
                                //死亡动画播放完毕回调流程
                                dieBaseFightUnit.SetDieFinishCall(actCallback);
                            }
                            else//表现完了 直接回调
                            {
                                actCallback();
                            }
                        }
                        else
                        {
                            if (caster.isShowRevive || target.isShowRevive)//攻击方/受击方有一方复活
                            {
                                BaseFightUnit reviveBaseFightUnit = null;//死亡那方
                                if (caster.isShowRevive)//攻击方复活
                                {
                                    reviveBaseFightUnit = caster;
                                }
                                else if (target.isShowRevive)//目标方复活
                                {
                                    reviveBaseFightUnit = target;
                                }
                                //复活动画播放完毕回调流程
                                reviveBaseFightUnit.SetReviveviFinishCall(actCallback);
                            }
                            else
                            {
                                actCallback?.Invoke();
                            }
                        }
                    }
                    else
                    {
                        Debug.Log("花仙buff对象不存在,casterFairies：" + action.sid);
                    }
                }
                else if (action.s == (uint)BuffTriggerRoleType.Pet)//宠物
                {
                    Debug.Log("执行 宠物Buff");
                    FightPetUnit casterPet = null;//攻击者
                    if (roundData.isAttacker)
                    {
                        if (!action.f)//取反 
                        {
                            casterPet = _petOtherCamps[action.sid];
                        }
                        else
                        {
                            casterPet = _petMyCamps[action.sid];
                        }
                    }
                    else
                    {
                        if (!action.f)//取反 
                        {
                            casterPet = _petMyCamps[action.sid];
                        }
                        else
                        {
                            casterPet = _petOtherCamps[action.sid];
                        }
                    }
                    if (casterPet != null)
                    {
                        if (CheckFightHeroUnitActInvalid(caster, target))
                        {
                            Debug.Log("目标行为无效，跳过");
                            actCallback?.Invoke();
                            return;
                        }
                        bool isLossBlood = false;//被攻击减血了
                        var buffConfig = BattleModel.Instance.GetBuffConfig((int)action.buffId);
                        if (buffConfig != null && (buffConfig.BuffType == 1 || buffConfig.BuffType == 20 || buffConfig.BuffType == 21 || buffConfig.BuffType == 27))//触发血量变更的buff才需要更新血量
                        {
                            isLossBlood = buffConfig.BuffType == 1;
                            UpdateHeroHp(caster, target, action, isLossBlood);
                        }
                        AddBuff(action.skillId, action, action.buffId, caster, target, casterPet);
                        if (isLossBlood && (caster.isDie || target.isDie))
                        {
                            Debug.Log("有一方死亡，延迟回调");
                            BaseFightUnit dieBaseFightUnit = null;//死亡那方
                            if (caster.isDie)//攻击方死亡
                            {
                                dieBaseFightUnit = caster;
                            }
                            else if (target.isDie)//目标方死亡
                            {
                                dieBaseFightUnit = target;
                            }
                            if (dieBaseFightUnit.isShowDie)//死亡表现中 等待回调之后再执行下面流程
                            {
                                //死亡动画播放完毕回调流程
                                dieBaseFightUnit.SetDieFinishCall(actCallback);
                            }
                            else//表现完了 直接回调
                            {
                                actCallback();
                            }
                        }
                        else
                        {
                            if (caster.isShowRevive || target.isShowRevive)//攻击方/受击方有一方复活
                            {
                                BaseFightUnit reviveBaseFightUnit = null;//死亡那方
                                if (caster.isShowRevive)//攻击方复活
                                {
                                    reviveBaseFightUnit = caster;
                                }
                                else if (target.isShowRevive)//目标方复活
                                {
                                    reviveBaseFightUnit = target;
                                }
                                //复活动画播放完毕回调流程
                                reviveBaseFightUnit.SetReviveviFinishCall(actCallback);
                            }
                            else
                            {
                                actCallback?.Invoke();
                            }
                        }
                    }
                    else
                    {
                        Debug.Log("宠物buff对象不存在,casterPet: " + action.sid);
                    }
                }
                else if (action.s == (uint)BuffTriggerRoleType.Hero)//玩家触发的buff(这里只在pve才会触发 pve的敌人s=Hero)
                {
                    Debug.Log("执行 玩家Buff");
                    BaseFightUnit casterFightUnit = null;//攻击者
                    if (roundData.isAttacker)//我方是攻击者
                    {
                        casterFightUnit = _heroCamps[0];//表示这个buff释放者是我方主角
                        if (!action.f)//取反 
                        {
                            if (!BattleModel.Instance.isPve)
                            {
                                casterFightUnit = _heroCamps[1];//pvp释放者是对方主角
                            }
                            else//pve 表示的敌人
                            {
                                casterFightUnit = GetFightEnemyUnit(action.enemytargetId);
                            }
                        }
                    }
                    else//受击者
                    {
                        if (!BattleModel.Instance.isPve)
                        {
                            casterFightUnit = _heroCamps[1];
                        }
                        else
                        {
                            casterFightUnit = GetFightEnemyUnit(action.userId);
                        }
                        if (!action.f)//取反 
                        {
                            if (!BattleModel.Instance.isPve)
                            {
                                casterFightUnit = _heroCamps[0];
                            }
                            else
                            {
                                casterFightUnit = GetFightEnemyUnit(action.userId);
                            }
                        }
                    }
                    if (casterFightUnit != null)
                    {
                        if (CheckFightHeroUnitActInvalid(caster, target))
                        {
                            Debug.Log("目标行为无效，跳过");
                            actCallback?.Invoke();
                            return;
                        }
                        bool isLossBlood = false;//被攻击减血了
                        var buffConfig = BattleModel.Instance.GetBuffConfig((int)action.buffId);
                        if (buffConfig != null && (buffConfig.BuffType == 1 || buffConfig.BuffType == 20 || buffConfig.BuffType == 21 || buffConfig.BuffType == 27))//触发血量变更的buff才需要更新血量
                        {
                            isLossBlood = buffConfig.BuffType == 1;
                            UpdateHeroHp(caster, target, action, isLossBlood);
                        }
                        AddBuff(action.skillId, action, action.buffId, caster, target, casterFightUnit);
                        if (isLossBlood && (caster.isDie || target.isDie))//攻击方/受击方有一方死亡
                        {
                            Debug.Log("有一方死亡，延迟回调");
                            BaseFightUnit dieBaseFightUnit = null;//死亡那方
                            if (caster.isDie)//攻击方死亡
                            {
                                dieBaseFightUnit = caster;
                            }
                            else if (target.isDie)//目标方死亡
                            {
                                dieBaseFightUnit = target;
                            }
                            if (dieBaseFightUnit.isShowDie)//死亡表现中 等待回调之后再执行下面流程
                            {
                                //死亡动画播放完毕回调流程
                                dieBaseFightUnit.SetDieFinishCall(actCallback);
                            }
                            else//表现完了 直接回调
                            {
                                actCallback();
                            }
                        }
                        else
                        {
                            if (caster.isShowRevive || target.isShowRevive)//攻击方/受击方有一方复活
                            {
                                BaseFightUnit reviveBaseFightUnit = null;//死亡那方
                                if (caster.isShowRevive)//攻击方复活
                                {
                                    reviveBaseFightUnit = caster;
                                }
                                else if (target.isShowRevive)//目标方复活
                                {
                                    reviveBaseFightUnit = target;
                                }
                                //复活动画播放完毕回调流程
                                reviveBaseFightUnit.SetReviveviFinishCall(actCallback);
                            }
                            else
                            {
                                actCallback?.Invoke();
                            }
                        }

                    }
                    else
                    {
                        Debug.Log("casterEnemy对象不存在");
                    }
                }
                break;
        }
    }


    /// <summary>
    /// 更新双方主角血量
    /// </summary>
    /// <param name="action"></param>
    private void UpdateHeroHp(BaseFightUnit caster, BaseFightUnit target, BuffSeqVo action, bool isHit)
    {
        if (action.myHealth == -1 && action.enemyHealth == -1) return;

        if (caster.isMyCamp)
        {
            caster.UpdateHp((ulong)action.myHealth);//更新我方血量
        }
        else
        {
            caster.UpdateHp((ulong)action.enemyHealth);//更新敌方血量
        }

        if (target.isMyCamp)
        {
            if (isHit)//减血操作
            {
                target.Hit();
            }
            target.UpdateHp((ulong)action.myHealth);//更新我方血量
        }
        else
        {
            if (isHit)//减血操作
            {
                target.Hit();
            }
            target.UpdateHp((ulong)action.enemyHealth);//更新敌方血量
        }

        //if (action.myHealth >= 0)
        //{
        //    _heroCamps[0].UpdateHp((ulong)action.myHealth);//更新我方血量
        //}
        //if (action.enemyHealth >= 0)
        //{
        //    _heroCamps[1].UpdateHp((ulong)action.enemyHealth);//更新敌方血量
        //}
    }

    /// <summary>
    /// 计算血量
    /// </summary>
    /// <returns></returns>
    public ulong CountHealth()
    {
        if (roundData.buffSeq.Count > 1)
        {
            List<BuffSeqVo> mybuffSeq = new List<BuffSeqVo>();//我方的需要变更血量的buff列表(当前攻击方的)
            foreach (var buff in roundData.buffSeq)
            {
                if (buff.f)
                {
                    if (buff.t == 0)//攻击都放进去
                    {
                        mybuffSeq.Add(buff);
                    }
                    else if (buff.t == 1)//buff需要判断是否是血量变更的buff
                    {
                        var buffConfig = BattleModel.Instance.GetBuffConfig((int)buff.buffId);
                        if (buffConfig != null && (buffConfig.BuffType == 1 || buffConfig.BuffType == 20 || buffConfig.BuffType == 21 || buffConfig.BuffType == 27))//触发血量变更的buff才需要更新血量
                        {
                            mybuffSeq.Add(buff);
                        }
                    }
                }
            }
            if (mybuffSeq.Count > 1)//大于1的队列血量需要前端自己结算
            {
                ulong enemyHealth = roundData.enemyHealth;
                for (var i = buffSeqInd; i < mybuffSeq.Count; i++)
                {
                    enemyHealth += mybuffSeq[buffSeqInd].v;
                }
                return enemyHealth;
            }
        }
        return roundData.enemyHealth;
    }

    /// <summary>
    /// 检测攻击方/收击方是否则行为无效
    /// </summary>
    /// <returns></returns>
    private bool CheckFightHeroUnitActInvalid(BaseFightUnit caster, BaseFightUnit target)
    {
        if (caster is FightHeroUnit)//攻击方 检测是否死亡 复活中状态
        {
            if (caster.isDie)
            {
                Debug.Log("攻击方已死亡，行为无效，跳过");
                return true;
            }
            else if (caster.isShowDie)
            {
                Debug.Log("攻击方死亡表现中，行为无效，跳过");
                return true;
            }
            else if (caster.isShowRevive)
            {
                Debug.Log("攻击方复活表现中，行为无效，跳过");
                return true;
            }
        }
        if (target is FightHeroUnit)//受击方 检测是否死亡 复活中状态
        {
            if (target.isDie)
            {
                Debug.Log("受击方已死亡，行为无效，跳过");
                return true;
            }
            else if (target.isShowDie)
            {
                Debug.Log("受击方死亡表现中，行为无效，跳过");
                return true;
            }
            else if (target.isShowRevive)
            {
                Debug.Log("受击方复活表现中，行为无效，跳过");
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// 花仙触发给玩家添加的buff
    /// </summary>
    /// <param name="skillId"></param>
    /// <param name="buffId"></param>
    /// <param name="caster"></param>
    /// <param name="target"></param>
    private void AddBuff(ulong skillId, BuffSeqVo action, ulong buffId, BaseFightUnit caster, BaseFightUnit target, fun_Battle.FlowerFairiesItem casterFairies)
    {
        var skillConfig = BattleModel.Instance.GetSkillConfig((long)skillId);
        if (skillConfig != null)
        {
            var buffInd = 0;
            foreach (var bufId in skillConfig.BuffIds)
            {
                if (bufId == (int)buffId)
                {
                    break;
                }
                buffInd += 1;
            }
            Debug.Log("buffID:" + skillConfig.ID);
            var buffTarget = skillConfig.BuffTargets[buffInd];
            if (skillConfig.ID == 102 || skillConfig.ID == 110)
            {
                Debug.Log("出现持续性buff:" + skillConfig.ID);
            }
            if (buffTarget == 1)//己方
            {
                casterFairies.Attack();
                caster.AddBuff(action);
            }
            else if (buffTarget == 2)//对方
            {
                casterFairies.Attack();
                target.AddBuff(action);
            }
        }
    }

    /// <summary>
    /// 宠物触发给玩家添加的buff
    /// </summary>
    /// <param name="skillId"></param>
    /// <param name="buffId"></param>
    /// <param name="caster"></param>
    /// <param name="target"></param>
    private void AddBuff(ulong skillId, BuffSeqVo action, ulong buffId, BaseFightUnit caster, BaseFightUnit target, FightPetUnit casterPet)
    {
        var skillConfig = BattleModel.Instance.GetSkillConfig((long)skillId);
        if (skillConfig != null)
        {
            var buffInd = 0;
            foreach (var bufId in skillConfig.BuffIds)
            {
                if (bufId == (int)buffId)
                {
                    break;
                }
                buffInd += 1;
            }
            var buffTarget = skillConfig.BuffTargets[buffInd];
            if (buffTarget == 1)//己方
            {
                casterPet.Attack();
                caster.AddBuff(action);
            }
            else if (buffTarget == 2)//对方
            {
                casterPet.Attack();
                target.AddBuff(action);
            }
        }
    }

    /// <summary>
    /// 主角/敌人触发的buff 暂时没有skillId
    /// </summary>
    /// <param name="action"></param>
    /// <param name="buffId"></param>
    /// <param name="caster"></param>
    /// <param name="target"></param>
    /// <param name="casterPet"></param>
    private void AddBuff(ulong skillId, BuffSeqVo action, ulong buffId, BaseFightUnit caster, BaseFightUnit target, BaseFightUnit casterPet)
    {
        var skillConfig = BattleModel.Instance.GetSkillConfig((long)skillId);
        if (skillConfig != null)
        {
            var buffInd = 0;
            foreach (var bufId in skillConfig.BuffIds)
            {
                if (bufId == (int)buffId)
                {
                    break;
                }
                buffInd += 1;
            }
            var buffTarget = skillConfig.BuffTargets[buffInd];
            if (buffTarget == 1)//己方
            {
                caster.AddBuff(action);
            }
            else if (buffTarget == 2)//对方
            {
                target.AddBuff(action);
            }
        }
    }

    /// <summary>
    /// 切换下一行动单元
    /// </summary>
    private void SwitchNextAction()
    {
        var isSwitchAction = false;
        if (buffSeqInd < roundData.buffSeq.Count)
        {
            buffSeqInd += 1;//切换下个队列
            isSwitchAction = false;
        }
        else//切换下一个行动单元
        {
            actionInd += 1;
            Debug.Log("切换下一个行动单元 actionInd: " + actionInd);
            buffSeqInd = 1;
            isSwitchAction = true;
        }

        Coroutiner.StartCoroutine(DelaySwitchNextAction(isSwitchAction));
    }

    private IEnumerator DelaySwitchNextAction(bool isSwitchRound)
    {
        var switchTime = isSwitchRound ? BattleModel.Instance.RoundInterval : BattleModel.Instance.ActionUnitInterval;
        yield return new WaitForSeconds(switchTime / BattleModel.Instance.TimeScale);
        Play();
    }

    /// <summary>
    ///继续播放
    /// </summary>
    public void Rusume()
    {
        BattleModel.Instance.isBattlePlay = true;
        foreach (var hero in _heroCamps)
        {
            hero.Resume();
        }
        Play();
    }

    public void Stop()
    {
        BattleModel.Instance.isBattlePlay = false;
        foreach (var hero in _heroCamps)
        {
            hero.Stop();
        }
        foreach (var pet in _petMyCamps)
        {
            if (pet.Value != null)
            {
                pet.Value.Stop();
            }
        }
        foreach (var pet in _petOtherCamps)
        {
            if (pet.Value != null)
            {
                pet.Value.Stop();
            }
        }
    }

    /// <summary>
    ///结束战斗播放
    /// </summary>
    public void End()
    {
        Stop();
        _playFinishCall?.Invoke();
    }

    public void Clear()
    {
        Stop();
        _heroCamps = null;
        _petMyCamps = null;
        _petOtherCamps = null;
    }

    /// <summary>
    /// 加速
    /// </summary>
    /// <param name="timeScale">几倍速度</param>
    public void SpeedUp(uint timeScale)
    {
        foreach (var hero in _heroCamps)
        {
            hero.ChangeTimeScale(timeScale);
        }
        foreach (var pet in _petMyCamps)
        {
            if (pet.Value != null)
            {
                pet.Value.ChangeTimeScale(timeScale);
            }
        }
        foreach (var pet in _petOtherCamps)
        {
            if (pet.Value != null)
            {
                pet.Value.ChangeTimeScale(timeScale);
            }
        }
        foreach (var enemy in _enemys)
        {
            enemy.ChangeTimeScale(timeScale);
        }
        BattleModel.Instance.TimeScale = timeScale;
    }
}
