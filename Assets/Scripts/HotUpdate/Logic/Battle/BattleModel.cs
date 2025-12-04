using Elida.Config;
using protobuf.adventure;
using protobuf.fight;
using protobuf.login;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 触发战斗属性枚举
/// </summary>
public enum TriggerCombatAttribute
{
    Nomal,//正常无特殊
    Crit,//暴击
    Dodge,//闪避
    Stun,//击晕
    Reflect,//反弹
    Lifesteal,//吸血
    Chase,//追击/连击
}

public enum Camp
{
    Self,//己方
    Other//对方
}


/// <summary>
/// buff触发的角色类型
/// </summary>
public enum BuffTriggerRoleType
{
    FlowerFairy,//花仙
    Pet,//宠物
    Hero//玩家
}

/// <summary>
/// buff触发类型
/// </summary>
public enum BuffTriggerType
{
    Attack,//攻击
    Buff//buff
}

/// <summary>
/// 战斗数据中心
/// </summary>
public class BattleModel : Singleton<BattleModel>
{
    public float RoundInterval = 0.2f;//回合间隔
    public float ActionUnitInterval = 0.2f;//行动单元间隔
    public uint TimeScale = 1;//时间缩放
    public bool isPve = true;
    public bool isBattlePlay = false;//战斗是否播放
    public bool isWin = false;//我方是否赢了
    public I_BATTLE_PLAYER_VO myPlayerVo;//玩家数据
    public I_BATTLE_PLAYER_VO enemyPlayerVo;//敌人数据
    private BattleRounds battleRounds;//回合数据
    public int islandStage;//pve战斗关卡id
    private Dictionary<int, int> enemyHp = new Dictionary<int, int>();//根据敌人组保存敌人的血量

    //pvp结算相关
    public uint rivalIndex = 0;//pvp被挑战者索引
    public int score = 0;//本次挑战获得的积分
    public Dictionary<ulong, ulong> items;//挑战胜利获得的奖励

    public List<BattleRoundVo> roundDetails
    {
        get { return battleRounds.roundDetails; }
    }

    /// <summary>
    /// 解析pvp战斗数据
    /// </summary>
    /// <param name="s_MSG_BATTLE_START"></param>
    public void ParsePvpBattleData(I_BATTLE_RESULT s_MSG_BATTLE_START)
    {
        var roundDetailJson = Resources.Load<TextAsset>("battle_pvp");
        s_MSG_BATTLE_START = ADK.StringUtil.DeserializeObject<I_BATTLE_RESULT>(roundDetailJson.text);
        isPve = s_MSG_BATTLE_START.type == 2;
        isWin = s_MSG_BATTLE_START.isWin;
        myPlayerVo = s_MSG_BATTLE_START.me;
        enemyPlayerVo = s_MSG_BATTLE_START.enemy;

        battleRounds = new BattleRounds();
        battleRounds.roundDetails = new List<BattleRoundVo>();
        //初始化数据 前端再封装一次
        foreach (var roundDetail in s_MSG_BATTLE_START.roundDetails)
        {
            var buffSeq = new List<BuffSeqVo>();
            foreach (var buff in roundDetail.buffSeq)
            {
                buffSeq.Add(new BuffSeqVo() { t = buff.t, s = buff.s, sid = buff.sid, buffId = buff.buffId, skillId = buff.skillId, f = buff.f, v = buff.v, isChangeHealth = buff.isChangeHealth, enemytargetId = (int)roundDetail.enemyId, userId = (int)roundDetail.userId });
            }
            battleRounds.roundDetails.Add(new BattleRoundVo() { round = roundDetail.round, isCrit = roundDetail.isCrit, isAttacker = roundDetail.isAttacker, isDodge = roundDetail.isDodge, isStun = roundDetail.isStun, isChase = roundDetail.isChase, reflect = roundDetail.reflect, lifesteal = roundDetail.lifesteal, myHealth = roundDetail.myHealth, enemyHealth = roundDetail.enemyHealth, buffSeq = buffSeq });
        }

        if (isPve)
        {
            //初始化敌人组的血量
            enemyHp.Clear();
            var gridConfig = AdventureModel.Instance.GetGridConfig(BattleModel.Instance.islandStage);
            if (gridConfig != null)
            {
                var ft_island_stageConfig = AdventureModel.Instance.GetIslandStageConfig(int.Parse(gridConfig.ClearReward));
                if (ft_island_stageConfig != null)
                {
                    foreach (var enemy in ft_island_stageConfig.EnemyGroups)
                    {
                        var enemyConfig = AdventureModel.Instance.GetEnemyConfig(enemy);
                        if (enemyConfig != null)
                        {
                            var ft_enemy_attConfig = AdventureModel.Instance.GetEnemyAtt(enemyConfig.AttId);
                            if (ft_enemy_attConfig != null)
                            {
                                enemyHp.Add(enemy, ft_enemy_attConfig.Hp);
                            }
                        }
                    }
                }
            }
        }
        var roundInd = 0;
        foreach (var round in battleRounds.roundDetails)
        {
            CountSeqHp(round, roundInd);
            roundInd += 1;
        }

        Debug.Log("s_MSG_BATTLE_START:" + ADK.StringUtil.SerializeObject(s_MSG_BATTLE_START));


    }

    /// <summary>
    /// 解析pve战斗数据
    /// </summary>
    /// <param name="s_MSG_BATTLE_START"></param>
    public void ParsePveBattleData(S_MSG_ADVENTURE_STAGE s_MSG_BATTLE_START)
    {
        //var roundDetailJson = Resources.Load<TextAsset>("battle_pve");
        //s_MSG_BATTLE_START = ADK.StringUtil.DeserializeObject<S_MSG_ADVENTURE_STAGE>(roundDetailJson.text);
        islandStage = (int)s_MSG_BATTLE_START.objectId;
        isPve = s_MSG_BATTLE_START.type == 2;
        isWin = s_MSG_BATTLE_START.isWin;
        myPlayerVo = s_MSG_BATTLE_START.me;

        battleRounds = new BattleRounds();
        battleRounds.roundDetails = new List<BattleRoundVo>();
        //初始化数据 前端再封装一次
        foreach (var roundDetail in s_MSG_BATTLE_START.roundDetails)
        {
            var buffSeq = new List<BuffSeqVo>();
            foreach (var buff in roundDetail.buffSeq)
            {
                buffSeq.Add(new BuffSeqVo() { t = buff.t, s = buff.s, sid = buff.sid, isChangeHealth = buff.isChangeHealth, buffId = buff.buffId, skillId = buff.skillId, f = buff.f, v = buff.v, enemytargetId = (int)roundDetail.enemyId, userId = (int)roundDetail.userId });
            }
            battleRounds.roundDetails.Add(new BattleRoundVo() { round = roundDetail.round, isCrit = roundDetail.isCrit, isAttacker = roundDetail.isAttacker, isDodge = roundDetail.isDodge, isStun = roundDetail.isStun, isChase = roundDetail.isChase, reflect = roundDetail.reflect, lifesteal = roundDetail.lifesteal, myHealth = roundDetail.myHealth, enemyHealth = roundDetail.enemyHealth, buffSeq = buffSeq, enemyId = roundDetail.enemyId, userId = roundDetail.userId });
        }

        if (isPve)
        {
            //初始化敌人组的血量
            enemyHp.Clear();
            var gridConfig = AdventureModel.Instance.GetGridConfig(BattleModel.Instance.islandStage);
            if (gridConfig != null)
            {
                var ft_island_stageConfig = AdventureModel.Instance.GetIslandStageConfig(int.Parse(gridConfig.ClearReward));
                if (ft_island_stageConfig != null)
                {
                    foreach (var enemy in ft_island_stageConfig.EnemyGroups)
                    {
                        var enemyConfig = AdventureModel.Instance.GetEnemyConfig(enemy);
                        if (enemyConfig != null)
                        {
                            var ft_enemy_attConfig = AdventureModel.Instance.GetEnemyAtt(enemyConfig.AttId);
                            if (ft_enemy_attConfig != null)
                            {
                                enemyHp.Add(enemy, ft_enemy_attConfig.Hp);
                            }
                        }
                    }
                }
            }
        }
        var roundInd = 0;
        foreach (var round in battleRounds.roundDetails)
        {
            CountSeqHp(round, roundInd);
            roundInd += 1;
        }

        Debug.Log("s_MSG_BATTLE_START:" + ADK.StringUtil.SerializeObject(s_MSG_BATTLE_START));
    }

    /// <summary>
    /// 计算一个sep的血量
    /// </summary>
    private void CountSeqHp(BattleRoundVo round, int roundInd)
    {
        ulong lastmyHealth = 0;//上次我方血量(站在左边那个人的血量)
        ulong lastenemyHealth = 0;//敌方血量

        if (roundInd == 0)
        {
            lastmyHealth = myPlayerVo.health;
            if (enemyPlayerVo != null)//pvp才有敌人数据
            {
                lastenemyHealth = enemyPlayerVo.health;
            }
            else//pve的话直接用读取配置的(pve不需要废弃)
            {
            }
        }
        else
        {
            var lastBattleRoundVo = roundDetails[roundInd - 1];
            if (lastBattleRoundVo != null)
            {
                if (lastBattleRoundVo.isAttacker)
                {
                    lastmyHealth = lastBattleRoundVo.myHealth;
                    lastenemyHealth = lastBattleRoundVo.enemyHealth;
                }
                else
                {
                    lastmyHealth = lastBattleRoundVo.enemyHealth;
                    lastenemyHealth = lastBattleRoundVo.myHealth;
                }
            }
        }


        if (round.buffSeq.Count == 1)//只有一条数据直接取最终运算的血量数据
        {
            var buffSeqVo = round.buffSeq[0];
            var needCountHp = CheckNeedCountHp(buffSeqVo);//是否需要计算血量
            if (!needCountHp) return;

            if (round.isAttacker)
            {
                buffSeqVo.myHealth = (long)round.myHealth;
                buffSeqVo.enemyHealth = (long)round.enemyHealth;
            }
            else
            {
                buffSeqVo.myHealth = (long)round.enemyHealth;
                buffSeqVo.enemyHealth = (long)round.myHealth;
            }
            if (isPve)//pve更新当前敌人血量
            {
                enemyHp[round.isAttacker ? buffSeqVo.enemytargetId : buffSeqVo.userId] = (int)buffSeqVo.enemyHealth;
            }

        }
        else if (round.buffSeq.Count > 1)//至少2条数据以上
        {
            List<BuffSeqVo> buffSeq = new List<BuffSeqVo>();
            foreach (var seq in round.buffSeq)
            {
                if (CheckNeedCountHp(seq))
                {
                    buffSeq.Add(seq);
                }
            }

            var sepIndex = 0;
            foreach (var sep in buffSeq)//己方攻击列表
            {
                if (sepIndex == buffSeq.Count - 1)//如果是最后一个
                {
                    if (round.isAttacker)
                    {
                        sep.myHealth = (long)round.myHealth;
                        sep.enemyHealth = (long)round.enemyHealth;
                    }
                    else
                    {
                        sep.myHealth = (long)round.enemyHealth;
                        sep.enemyHealth = (long)round.myHealth;
                    }
                    if (isPve)//pve更新当前敌人血量
                    {
                        enemyHp[round.isAttacker ? sep.enemytargetId : sep.userId] = (int)sep.enemyHealth;
                    }
                }
                else//非最后一个
                {
                    if (sep.t == 0)//攻击
                    {
                        if (isPve)
                        {
                            if (round.isAttacker)
                            {
                                if (sep.f)//我方是攻击者 对敌人血量造成变更
                                {
                                    enemyHp[sep.enemytargetId] = (int)((sep.v > enemyHp[sep.enemytargetId]) ? 0 : enemyHp[sep.enemytargetId] - sep.v);
                                }
                                else
                                {
                                    lastmyHealth = (sep.v > lastmyHealth) ? 0 : lastmyHealth - sep.v;
                                }
                            }
                            else
                            {
                                if (sep.f)
                                {
                                    lastmyHealth = (sep.v > lastmyHealth) ? 0 : lastmyHealth - sep.v;
                                }
                                else
                                {
                                    enemyHp[sep.userId] = (int)((sep.v > enemyHp[sep.userId]) ? 0 : enemyHp[sep.userId] - sep.v);
                                }
                            }
                        }
                        else
                        {
                            if (round.isAttacker)
                            {
                                if (sep.f)//我方是攻击者 对敌人血量造成变更
                                {
                                    lastenemyHealth = (sep.v > lastenemyHealth) ? 0 : lastenemyHealth - sep.v;
                                }
                                else
                                {
                                    lastmyHealth = (sep.v > lastmyHealth) ? 0 : lastmyHealth - sep.v;
                                }
                            }
                            else
                            {
                                if (sep.f)
                                {
                                    lastmyHealth = (sep.v > lastmyHealth) ? 0 : lastmyHealth - sep.v;
                                }
                                else
                                {
                                    lastenemyHealth = (sep.v > lastenemyHealth) ? 0 : lastenemyHealth - sep.v;
                                }
                            }
                        }

                    }
                    else if (sep.t == 1)//buff
                    {
                        var buffConfig = GetBuffConfig((int)sep.buffId);
                        if (buffConfig != null)
                        {
                            if (buffConfig.BuffType == 1)//造成攻击力%的伤害
                            {
                                if (isPve)
                                {
                                    if (round.isAttacker)
                                    {
                                        if (sep.f)//我方是攻击者 对敌人血量造成变更
                                        {
                                            enemyHp[sep.enemytargetId] = (int)((sep.v > enemyHp[sep.enemytargetId]) ? 0 : enemyHp[sep.enemytargetId] - sep.v);
                                        }
                                        else
                                        {

                                            lastmyHealth = (sep.v > lastmyHealth) ? 0 : lastmyHealth - sep.v;
                                        }
                                    }
                                    else
                                    {
                                        if (sep.f)
                                        {
                                            lastmyHealth = (sep.v > lastmyHealth) ? 0 : lastmyHealth - sep.v;
                                        }
                                        else
                                        {
                                            enemyHp[sep.userId] = (int)((sep.v > enemyHp[sep.userId]) ? 0 : enemyHp[sep.userId] - sep.v);
                                        }
                                    }
                                }
                                else
                                {
                                    if (round.isAttacker)
                                    {
                                        if (sep.f)//我方是攻击者 对敌人血量造成变更
                                        {
                                            lastenemyHealth = (sep.v > lastenemyHealth) ? 0 : lastenemyHealth - sep.v;
                                        }
                                        else
                                        {

                                            lastmyHealth = (sep.v > lastmyHealth) ? 0 : lastmyHealth - sep.v;
                                        }
                                    }
                                    else
                                    {
                                        if (sep.f)
                                        {
                                            lastmyHealth = (sep.v > lastmyHealth) ? 0 : lastmyHealth - sep.v;
                                        }
                                        else
                                        {
                                            lastenemyHealth = (sep.v > lastenemyHealth) ? 0 : lastenemyHealth - sep.v;
                                        }
                                    }
                                }


                            }
                            else if (buffConfig.BuffType == 20)//恢复X%攻击力的生命
                            {
                                if (isPve)
                                {
                                    if (round.isAttacker)
                                    {
                                        if (sep.f)//对己方加血
                                        {
                                            lastmyHealth += sep.v;
                                            if (lastmyHealth <= 0) lastmyHealth = 0;
                                        }
                                        else
                                        {
                                            enemyHp[sep.enemytargetId] += (int)sep.v;
                                        }
                                    }
                                    else
                                    {
                                        if (sep.f)
                                        {
                                            enemyHp[sep.userId] += (int)sep.v;//对敌方加血
                                        }
                                        else
                                        {
                                            lastmyHealth += sep.v;
                                        }
                                    }
                                }
                                else
                                {
                                    if (round.isAttacker)
                                    {
                                        if (sep.f)//对己方加血
                                        {
                                            lastmyHealth += sep.v;
                                            if (lastmyHealth <= 0) lastmyHealth = 0;
                                        }
                                        else
                                        {
                                            lastenemyHealth += sep.v;
                                        }
                                    }
                                    else
                                    {
                                        if (sep.f)
                                        {
                                            lastenemyHealth += sep.v;//对敌方加血
                                        }
                                        else
                                        {
                                            lastmyHealth += sep.v;
                                        }
                                    }
                                }
                            }
                            else if (buffConfig.BuffType == 21)//复活并恢复%生命
                            {
                                if (isPve)
                                {
                                    if (round.isAttacker)
                                    {
                                        if (sep.f)
                                        {
                                            lastmyHealth += sep.v;
                                        }
                                        else
                                        {
                                            enemyHp[sep.enemytargetId] += (int)sep.v;
                                        }
                                    }
                                    else
                                    {
                                        if (sep.f)
                                        {
                                            enemyHp[sep.userId] += (int)sep.v;
                                        }
                                        else
                                        {
                                            lastmyHealth += sep.v;
                                        }
                                    }
                                }
                                else
                                {
                                    if (round.isAttacker)
                                    {
                                        if (sep.f)
                                        {
                                            lastmyHealth += sep.v;
                                        }
                                        else
                                        {
                                            lastenemyHealth += sep.v;
                                        }
                                    }
                                    else
                                    {
                                        if (sep.f)
                                        {
                                            lastenemyHealth += sep.v;
                                        }
                                        else
                                        {
                                            lastmyHealth += sep.v;
                                        }
                                    }
                                }
                            }
                            else if (buffConfig.BuffType == 27)//恢复%最大生命值的生命
                            {
                                if (isPve)
                                {
                                    if (round.isAttacker)
                                    {
                                        if (sep.f)//对己方加血
                                        {
                                            lastmyHealth += sep.v;
                                            if (lastmyHealth <= 0) lastmyHealth = 0;
                                        }
                                        else
                                        {
                                            enemyHp[sep.enemytargetId] += (int)sep.v;
                                        }
                                    }
                                    else
                                    {
                                        if (sep.f)
                                        {
                                            enemyHp[sep.userId] += (int)sep.v;//对敌方加血
                                        }
                                        else
                                        {
                                            lastmyHealth += sep.v;
                                        }
                                    }
                                }
                                else
                                {
                                    if (round.isAttacker)
                                    {
                                        if (sep.f)//对己方加血
                                        {
                                            lastmyHealth += sep.v;
                                            if (lastmyHealth <= 0) lastmyHealth = 0;
                                        }
                                        else
                                        {
                                            lastenemyHealth += sep.v;
                                        }
                                    }
                                    else
                                    {
                                        if (sep.f)
                                        {
                                            lastenemyHealth += sep.v;//对敌方加血
                                        }
                                        else
                                        {
                                            lastmyHealth += sep.v;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (isPve)//pve更新当前敌人血量
                    {
                        if (round.isAttacker)
                        {
                            sep.myHealth = (long)lastmyHealth;
                            sep.enemyHealth = enemyHp[sep.enemytargetId];
                        }
                        else
                        {
                            sep.myHealth = (long)lastmyHealth;
                            sep.enemyHealth = enemyHp[sep.userId];
                        }
                    }
                    else
                    {
                        sep.myHealth = (long)lastmyHealth;
                        sep.enemyHealth = (long)lastenemyHealth;
                    }
                }
                sepIndex += 1;
            }
        }
    }

    /// <summary>
    /// 检测是否需要计算血量
    /// </summary>
    /// <param name="buffSeqVo"></param>
    /// <returns></returns>
    private bool CheckNeedCountHp(BuffSeqVo buffSeqVo)
    {
        if (buffSeqVo == null) return false;
        var needCountHp = false;//是否需要计算血量
        if (buffSeqVo.t == 0)//是攻击的话
        {
            needCountHp = true;
        }
        else if (buffSeqVo.t == 1)//是buff
        {
            var buffConfig = GetBuffConfig((int)buffSeqVo.buffId);
            if (buffConfig != null && (buffConfig.BuffType == 1 || buffConfig.BuffType == 20 || buffConfig.BuffType == 21 || buffConfig.BuffType == 27))//触发血量变更的buff才需要更新血量
            {
                needCountHp = true;
            }
        }
        return needCountHp;
    }

    public Ft_skillConfig GetSkillConfig(long skillId)
    {
        var ft_skillConfigData = ConfigManager.Instance.GetConfig<Ft_skillConfigData>("ft_skillsConfig");
        return ft_skillConfigData[skillId];
    }
    public Ft_buffConfig GetBuffConfig(int buffId)
    {
        var ft_buffConfigData = ConfigManager.Instance.GetConfig<Ft_buffConfigData>("ft_buffsConfig");
        return ft_buffConfigData[buffId];
    }

    /// <summary>
    /// 总回合数
    /// </summary>
    public uint MaxRound
    {
        get
        {
            if (roundDetails == null || roundDetails.Count <= 0) return 0;
            return (uint)roundDetails[roundDetails.Count - 1].round;
        }
    }
}



public class BuffSeqVo
{
    public uint t; //类型 0：攻击 1：buff
    public uint s; //触发角色 0：花仙 1：宠物 2：人物
    public int sid; //-1：人物，否则为花仙或者宠物编号
    public ulong buffId; //如果不是buff，则为0
    public ulong skillId; ////技能id，buff由哪个技能触发
    public bool f; //阵营 是否是我方
    public uint v; //值，伤害值或者buff值
    public int enemytargetId;//敌人id
    public int userId;//敌人id
    public long myHealth = -1; //我的血量
    public long enemyHealth = -1; //敌人血量
    public bool isChangeHealth;//是否改变血量
}

public class BattleRoundVo
{
    public ulong round; //回合
    public bool isCrit; //是否暴击了
    public bool isAttacker; //是否是攻击发起者
    public bool isDodge; //被攻击方是否闪避了
    public bool isStun; //是否造成了击晕效果
    public bool isChase; //是否是追击
    public ulong reflect; //收到的反弹伤害
    public ulong lifesteal; //吸血效果造成的生命恢复
    public ulong myHealth; //我的血量
    public ulong enemyHealth; //敌人血量
    public List<BuffSeqVo> buffSeq; //buff序列播放
    public uint enemyId; //敌人id
    public uint userId; //我的id
}

public class BattleRounds
{
    public List<BattleRoundVo> roundDetails; //每个回合战斗详情
}


