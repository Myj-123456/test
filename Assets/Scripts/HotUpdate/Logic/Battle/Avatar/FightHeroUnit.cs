using FairyGUI;
using protobuf.fight;
using protobuf.login;
using Spine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectOrientation
{
    Default,
    Font,
    Back
}

public enum EffectPos
{
    Center,
    Bottom
}

/// <summary>
/// 主角战斗单元
/// </summary>
public class FightHeroUnit : BaseFightUnit
{
    private fun_Battle.FightHeroUnit fightHeroUnitSkin;
    private UIHeroAvatar heroAvatar;

    private ulong curHp;
    private ulong maxHp;
    private List<ulong> buffIdList;//玩家buff列表
    public bool isStun = false;//当前玩家是否被眩晕(被禁锢行动)
    private Dictionary<string, Dictionary<string, float>> aniEventDic = new Dictionary<string, Dictionary<string, float>>();
    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="playerVO"></param>
    public void Init(fun_Battle.FightHeroUnit fightHeroUnit, bool isMyCamp, I_BATTLE_PLAYER_VO battlePlayerVo)
    {
        isDie = false;
        isShowDie = false;
        isShowRevive = false;
        unitSkin = fightHeroUnit;
        buffIdList = new List<ulong>();
        this.isMyCamp = isMyCamp;
        fightHeroUnitSkin = fightHeroUnit;
        maxHp = battlePlayerVo.maxHealth;
        curHp = battlePlayerVo.health;
        UpdateHeroModel();
        InitHuibiModel();
        fightHeroUnitSkin.headBar.c1.selectedIndex = isMyCamp ? 0 : 1;
        UpdateHp(curHp);
        UpdateBuff(true);
        SetVisible(true);
    }

    public override void AddEffect(GLoader3D effect, EffectPos effectPos = EffectPos.Center, EffectOrientation effectOrientation = EffectOrientation.Default, float offY = -100)
    {
        if (effectOrientation == EffectOrientation.Default)//默认
        {
            fightHeroUnitSkin.AddChild(effect);
        }
        else if (effectOrientation == EffectOrientation.Font)// 前面
        {
            fightHeroUnitSkin.effectFont.AddChild(effect);
        }
        else if (effectOrientation == EffectOrientation.Back)
        {
            fightHeroUnitSkin.effectBack.AddChild(effect);
        }
        if (effectPos == EffectPos.Center)
        {
            var heroModelXy = fightHeroUnitSkin.heroModel.xy;
            heroModelXy.y += offY;
            effect.xy = heroModelXy;
        }
        else if (effectPos == EffectPos.Bottom)
        {
            effect.xy = fightHeroUnitSkin.heroModel.xy;
        }
    }

    /// <summary>
    /// 主角绘笔
    /// </summary>
    public GLoader3D huibiModel
    {
        get { return fightHeroUnitSkin.huibiModel; }
    }

    /// <summary>
    /// 玩家在界面层级的中心点
    /// </summary>
    /// <returns></returns>
    public override Vector2 GetHeroModelPos()
    {
        var globalPos = fightHeroUnitSkin.heroModel.LocalToGlobal(Vector2.zero);
        var pos = fightHeroUnitSkin.parent.GlobalToLocal(globalPos);
        pos.y -= 100;
        return pos;
    }

    public override Vector2 GetHeroModelPos2()
    {
        var globalPos = fightHeroUnitSkin.heroModel.LocalToGlobal(Vector2.zero);
        //var pos = fightHeroUnitSkin.parent.GlobalToLocal(globalPos);
        //pos.y -= 100;
        return globalPos;
    }

    /// <summary>
    /// 血条在界面层级的中心点
    /// </summary>
    /// <returns></returns>
    public override Vector2 GetHeadBarPos()
    {
        var globalPos = fightHeroUnitSkin.headBar.LocalToGlobal(Vector2.zero);
        var pos = fightHeroUnitSkin.parent.GlobalToLocal(globalPos);
        return pos;
    }

    public override Vector2 GetHeadBarPos2()
    {
        return fightHeroUnitSkin.headBar.position;
    }

    private void UpdateHeroModel()
    {
        heroAvatar = new UIHeroAvatar();
        heroAvatar.Init(fightHeroUnitSkin.heroModel);
        heroAvatar.UpdateDress(true);
        fightHeroUnitSkin.heroModel.scaleX = 0.4f;
        if (isMyCamp)
            fightHeroUnitSkin.heroModel.scaleX *= -1;
        ChangeTimeScale(BattleModel.Instance.TimeScale);
    }

    /// <summary>
    /// 绘笔挂到身后
    /// </summary>
    private void InitHuibiModel()
    {
        fightHeroUnitSkin.huibiModel.url = "huibi";
        fightHeroUnitSkin.huibiModel.animationName = "idle";
        fightHeroUnitSkin.huibiModel.loop = true;
        fightHeroUnitSkin.huibiModel.x = isMyCamp ? 0 : 140;
    }

    //public void AddHp(ulong hp)
    //{
    //    curHp += hp;
    //    UpdateHp(curHp);
    //}
    //public void ReduceHp(ulong hp)
    //{
    //    curHp -= hp;
    //    if (curHp <= 0) curHp = 0;
    //    UpdateHp(curHp);
    //}

    public override void UpdateHp(ulong hp)
    {
        if (isMyCamp)
        {
            fightHeroUnitSkin.headBar.myBlood.max = maxHp;
            fightHeroUnitSkin.headBar.myBlood.value = hp;
        }
        else
        {
            fightHeroUnitSkin.headBar.otherBlood.max = maxHp;
            fightHeroUnitSkin.headBar.otherBlood.value = hp;
        }

        if (isMyCamp)
        {
            Debug.Log("我方血量：" + hp);
            if (hp <= 0)
            {
                Debug.Log("我方主角血量为0，死亡");
                Die();
            }
            else if (curHp <= 0 && hp > 0)//被复活了
            {
                Revive();
            }
        }
        else
        {
            Debug.Log("敌方血量：" + hp);
            if (hp <= 0)
            {
                Debug.Log("敌方主角血量为0，死亡");
                Die();
            }
            else if (curHp <= 0 && hp > 0)//被复活了
            {
                Revive();
            }
        }
        curHp = hp;
    }



    /// <summary>
    /// 检测某个buff是否存在
    /// </summary>
    /// <param name="buffId"></param>
    /// <returns></returns>
    public override bool CheckHaveBuff(ulong buffId)
    {
        return buffIdList.Contains(buffId);
    }

    /// <summary>
    /// 添加buff
    /// </summary>
    public override void AddBuff(BuffSeqVo action)
    {
        FloatBuff(action);
        if (!buffIdList.Contains(action.buffId))
        {
            buffIdList.Add(action.buffId);
            UpdateBuff();
        }
    }


    /// <summary>
    /// buff飘字
    /// </summary>
    private void FloatBuff(BuffSeqVo action)
    {
        var buffConfig = BattleModel.Instance.GetBuffConfig((int)action.buffId);
        if (buffConfig != null)
        {
            if (buffConfig.BuffType == 1)
            {
                AddFloatInQueen(TriggerCombatAttribute.Nomal, "-" + action.v);
            }
            else if (buffConfig.BuffType == 20 || buffConfig.BuffType == 21 || buffConfig.BuffType == 27)//TODO:21是复活之后再恢复生命 需要表现完复活之后再加血
            {
                AddFloatInQueen(TriggerCombatAttribute.Lifesteal, "+" + action.v);
            }
            else if (buffConfig.BuffType == 19)//眩晕 先飘文本 后面再显示眩晕特效
            {
                AddFloatInQueen(TriggerCombatAttribute.Stun);
            }
        }
    }

    /// <summary>
    /// 每个回合之前先更新一下buff列表(每回合的第一条数据)
    /// 主要是为了剔除已失效的buff
    /// </summary>
    public void OnPerRoundUpdateBuffList(List<BuffSeqVo> buffSeq)
    {
        if (buffSeq == null || buffSeq.Count == 0)
        {
            buffIdList.Clear();//清空玩家身上的buff
            UpdateBuff();
            return; // 如果没有 buff 数据，不进行任何操作
        }
        if (buffIdList.Count <= 0) return;//都没有挂buff 不需要更新
        var exsitbuffs = new HashSet<ulong>();//当前回合玩家身上存在的buff列表
        foreach (var buff in buffSeq)
        {
            if (buff.t == 1 && buff.f == isMyCamp)//我方的buff
            {
                if (!exsitbuffs.Contains(buff.buffId))
                {
                    exsitbuffs.Add(buff.buffId);
                }
            }
        }
        //从 buffIdList 中移除不存在的buff
        buffIdList.RemoveAll(buffId => !exsitbuffs.Contains(buffId));
        UpdateBuff();
    }

    /// <summary>
    /// 更新buff 每次都清空 重新赋值一遍
    /// </summary>
    public void UpdateBuff(bool isInit = false)
    {
        if (isInit)
        {
            fightHeroUnitSkin.buffBar.list_buff.itemRenderer = RenderList;
        }
        fightHeroUnitSkin.buffBar.list_buff.numItems = buffIdList.Count;
        var row = Mathf.Max(1, Mathf.CeilToInt((float)buffIdList.Count / 5)); ;//行数
        fightHeroUnitSkin.buffBar.list_buff.y = (row - 1) * -28;
    }
    private void RenderList(int index, GObject item)
    {
        var cell = item as fun_Battle.BuffItem;
        var buffConfig = BattleModel.Instance.GetBuffConfig((int)buffIdList[index]);
        if (buffConfig != null)
        {
            cell.img_icon.url = ResPath.GetBuffIconPath(buffConfig.BuffIcon);
        }
    }

    /// <summary>
    /// 治疗
    /// </summary>
    public void Cure()
    {

    }

    public override void Attack()
    {
        heroAvatar.PlayAnimation(!isCril ? "attack1" : "attack2", false);
        heroAvatar.body.AnimationState.AddAnimation(0, "idle", true, 0);
    }

    public override void Hit()
    {
        if (heroAvatar != null)
        {
            heroAvatar.PlayAnimation("Hit", false);
            heroAvatar.body.AnimationState.AddAnimation(0, "idle", true, 0);
        }
    }

    public override void Resume()
    {
        if (heroAvatar != null)
        {
            heroAvatar.Resume();
        }
    }

    public override void Stop()
    {
        if (heroAvatar != null)
        {
            heroAvatar.Stop();
        }
    }

    public override void ChangeTimeScale(uint timeScale)
    {
        if (heroAvatar != null)
        {
            heroAvatar.ChangeTimeScale(timeScale);
            if (fightHeroUnitSkin.huibiModel.spineAnimation != null)
            {
                fightHeroUnitSkin.huibiModel.spineAnimation.timeScale = timeScale;
            }
        }
    }

    /// <summary>
    /// 死亡
    /// </summary>
    public override void Die()
    {
        base.Die();
        //SetVisible(false);
        if (heroAvatar != null)
        {
            heroAvatar.body.AnimationState.Complete += OnAnimationComplete;
            heroAvatar.PlayAnimation("defeated", false);
        }
    }

    private void OnAnimationComplete(TrackEntry trackEntry)
    {
        if (trackEntry.Animation.Name == "defeated")//死亡播放完毕回调
        {
            heroAvatar.body.AnimationState.Complete -= OnAnimationComplete;
            isShowDie = false;
            DieFinishCall();
        }
        else if (trackEntry.Animation.Name == "resurrect")//复活播放完毕回调
        {
            isShowRevive = false;
            heroAvatar.body.AnimationState.Complete -= OnAnimationComplete;
            ReviveviFinishCall();
        }
    }

    /// <summary>
    /// 复活
    /// </summary>
    public override void Revive()
    {
        base.Revive();
        //SetVisible(true);
        if (heroAvatar != null)
        {
            heroAvatar.body.AnimationState.Complete += OnAnimationComplete;
            heroAvatar.PlayAnimation("resurrect", false);
            heroAvatar.body.AnimationState.AddAnimation(0, "idle", true, 0);
            //播放复活特效
            AddResurrectEffect("effect/resurrection1", EffectOrientation.Font);
            AddResurrectEffect("effect/resurrection2", EffectOrientation.Default);
        }
    }

    private void AddResurrectEffect(string effectPath, EffectOrientation effectOrientation)
    {
        GLoader3D effect = EffectPool.Instance.GetEffect(effectPath);
        effect.scaleX = 0.5f;
        effect.scaleY = 0.5f;
        effect.animationName = "animation";
        effect.forcePlay = true;
        effect.loop = false;
        AddEffect(effect, EffectPos.Bottom, effectOrientation);//添加到目标身上
        effect.Complete = (string name) =>
        {
            effect.Complete = null;
            EffectPool.Instance.ReturnEffect(effect);//对象池回收
        };
    }

    private void SetVisible(bool isVisible)
    {
        fightHeroUnitSkin.heroModel.visible = isVisible;
        fightHeroUnitSkin.huibiModel.visible = isVisible;
        fightHeroUnitSkin.buffBar.visible = isVisible;
        fightHeroUnitSkin.headBar.visible = isVisible;
    }
}
