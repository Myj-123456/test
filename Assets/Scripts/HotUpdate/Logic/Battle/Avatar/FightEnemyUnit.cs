using ADK;
using FairyGUI;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// pve敌方战斗单元
/// </summary>
public class FightEnemyUnit : BaseFightUnit
{
    private fun_Battle.FightEnemyUnit fightEnemyUnitSkin;
    private ulong curHp;
    private ulong maxHp;
    private List<ulong> buffIdList;//玩家buff列表
    private SkillEnemyTimeConfigs skillTimeConfigs;
    private string spineName;

    public void Init(fun_Battle.FightEnemyUnit fightPetUnit, bool isMyCamp, ulong petId)
    {
        isDie = false;
        isShowDie = false;
        isShowRevive = false;
        unitSkin = fightPetUnit;
        buffIdList = new List<ulong>();
        fightEnemyUnitSkin = fightPetUnit;
        var enemyConfig = AdventureModel.Instance.GetEnemyConfig((int)petId);
        if (enemyConfig != null)
        {
            spineName = enemyConfig.SpineName;
            fightPetUnit.petModel.url = "enemy/" + enemyConfig.SpineName;
            fightPetUnit.petModel.animationName = "idle";
            fightPetUnit.petModel.loop = true;

            var ft_enemy_attConfig = AdventureModel.Instance.GetEnemyAtt(enemyConfig.AttId);
            if (ft_enemy_attConfig != null)
            {
                maxHp = (ulong)ft_enemy_attConfig.Hp;
                curHp = (ulong)ft_enemy_attConfig.Hp;
            }
        }
        this.isMyCamp = isMyCamp;
        if (isMyCamp)//敌人恒为false
            fightPetUnit.petModel.scaleX *= -1;
        ChangeTimeScale(BattleModel.Instance.TimeScale);
        fightEnemyUnitSkin.headBar.c1.selectedIndex = 1;
        UpdateHp(curHp);
        UpdateBuff(true);
        SetVisible(true);
    }

    private bool isRemoteAttack = false;
    /// <summary>
    /// 区分远程攻击还是近战攻击
    /// </summary>
    public override void Attack()
    {
        var spineAnimation = fightEnemyUnitSkin.petModel.spineAnimation;
        if (spineAnimation != null)
        {
            isRemoteAttack = false;
            var enemyConfig = AdventureModel.Instance.GetEnemyConfig((int)fightUnitId);
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
            spineAnimation.AnimationState.SetAnimation(0, "attack", false);//播放攻击动作
            skillTimeConfigs = SkillManager.Instance.GetEnemySkillTimeConfigs(spineAnimation, "attack");
            ExecuteAtatckProcess();
        }
    }

    private Vector2 orginPos;//缓存原位置坐标
    private IEnumerator StartFly(SkillTimeConfig skillTimeConfig)
    {
        if (skillTimeConfig == null) yield break;
        yield return new WaitForSeconds(skillTimeConfig.start / BattleModel.Instance.TimeScale);
        if (!isRemoteAttack)
        {
            orginPos = unitSkin.position;
            var targetPos = target.GetHeroModelPos();
            targetPos.y -= 100;//y坐标偏移上点
            unitSkin.TweenMove(new Vector2(targetPos.x, targetPos.y), skillTimeConfig.duration / BattleModel.Instance.TimeScale).OnComplete(() =>
            {
                StartAttack();
            });
        }
        else//远程攻击到时间直接回调
        {
            SkillManager.Instance.ReleaseSkill(3, this, target, () =>
            {
                StartAttack();
            }, null, skillTimeConfig.duration);
            //yield return new WaitForSeconds(skillTimeConfig.duration / BattleModel.Instance.TimeScale);
            //StartAttack();
        }

    }

    private void StartAttack()
    {
        AddAttackEffect("effect/" + spineName + "_attack", EffectOrientation.Default);
        AttackCall();
    }

    public override void Hit()
    {
        var spineAnimation = fightEnemyUnitSkin.petModel.spineAnimation;
        if (spineAnimation != null)
        {
            spineAnimation.AnimationState.SetAnimation(0, "shouj", false);
            spineAnimation.AnimationState.AddAnimation(0, "idle", true, 0);
        }
    }

    /// <summary>
    /// 绘笔开始返回
    /// </summary>
    private IEnumerator StartBack(SkillTimeConfig skillTimeConfig)
    {
        if (!isRemoteAttack)
        {
            if (skillTimeConfig == null) yield break;
            yield return new WaitForSeconds(skillTimeConfig.start / BattleModel.Instance.TimeScale);//延迟0.3f 和玩家施法动作对齐
            Debug.Log("攻击结束 开始往回飞");
            if (orginPos != null)
            {
                unitSkin.TweenMove(orginPos, skillTimeConfig.duration / BattleModel.Instance.TimeScale);
            }
        }
    }

    /// <summary>
    /// 切换待机
    /// </summary>
    /// <param name="skillTimeConfig"></param>
    /// <returns></returns>
    private IEnumerator StartIdle(SkillTimeConfig skillTimeConfig)
    {
        if (skillTimeConfig == null) yield break;
        yield return new WaitForSeconds(skillTimeConfig.start / BattleModel.Instance.TimeScale);
        var spineAnimation = fightEnemyUnitSkin.petModel.spineAnimation;
        if (spineAnimation != null)
        {
            spineAnimation.AnimationState.SetAnimation(0, "idle", true);
        }
        AttackFinishCall();
    }


    /// <summary>
    /// 执行攻击流程
    /// </summary>
    private void ExecuteAtatckProcess()
    {
        Coroutiner.StartCoroutine(StartFly(skillTimeConfigs.timeConfigFly));
        Coroutiner.StartCoroutine(StartBack(skillTimeConfigs.timeConfigBack));
        Coroutiner.StartCoroutine(StartIdle(skillTimeConfigs.timeConfigIdle));
    }

    public override void Resume()
    {
        if (fightEnemyUnitSkin.petModel.spineAnimation != null)
        {
            fightEnemyUnitSkin.petModel.spineAnimation.timeScale = lastTimeScale;
        }
    }

    /// <summary>
    /// 添加攻击特效
    /// </summary>
    /// <param name="effectPath"></param>
    /// <param name="effectOrientation"></param>
    private void AddAttackEffect(string effectPath, EffectOrientation effectOrientation)
    {
        GLoader3D effect = EffectPool.Instance.GetEffect(effectPath);
        //effect.scaleX = 0.5f;
        //effect.scaleY = 0.5f;
        effect.animationName = "attack";
        effect.forcePlay = true;
        effect.loop = false;
        target.AddEffect(effect, EffectPos.Center, effectOrientation, -140);//添加到目标身上
        effect.Complete = (string name) =>
        {
            effect.Complete = null;
            EffectPool.Instance.ReturnEffect(effect);//对象池回收
        };
    }

    public override void AddEffect(GLoader3D effect, EffectPos effectPos = EffectPos.Center, EffectOrientation effectOrientation = EffectOrientation.Default, float offY = -100)
    {
        fightEnemyUnitSkin.AddChild(effect);
        if (effectPos == EffectPos.Center)
        {
            var heroModelXy = fightEnemyUnitSkin.petModel.xy;
            heroModelXy.y += offY;
            effect.xy = heroModelXy;
        }
        else if (effectPos == EffectPos.Bottom)
        {
            effect.xy = fightEnemyUnitSkin.petModel.xy;
        }
    }

    public override void UpdateHp(ulong hp)
    {
        fightEnemyUnitSkin.headBar.otherBlood.max = maxHp;
        fightEnemyUnitSkin.headBar.otherBlood.value = hp;
        Debug.Log("敌方id：" + fightUnitId + " 血量：" + hp);
        if (hp <= 0)
        {
            Debug.Log("敌方血量为0，死亡 fightUnitId:" + fightUnitId);
            Die();
        }
        else if (curHp <= 0 && hp > 0)//被复活了
        {
            Debug.Log("敌方复活 fightUnitId:" + fightUnitId);
            Revive();
        }
        curHp = hp;
    }

    private float lastTimeScale;
    public override void Stop()
    {
        if (fightEnemyUnitSkin.petModel.spineAnimation != null)
        {
            lastTimeScale = fightEnemyUnitSkin.petModel.spineAnimation.timeScale;
            fightEnemyUnitSkin.petModel.spineAnimation.timeScale = 0;
        }
    }

    public override void ChangeTimeScale(uint timeScale)
    {
        if (fightEnemyUnitSkin.petModel.spineAnimation != null)
        {
            fightEnemyUnitSkin.petModel.spineAnimation.timeScale = timeScale;
        }
    }

    /// <summary>
    /// 玩家在界面层级的中心点
    /// </summary>
    /// <returns></returns>
    public override Vector2 GetHeroModelPos()
    {
        var globalPos = fightEnemyUnitSkin.petModel.LocalToGlobal(Vector2.zero);
        var pos = fightEnemyUnitSkin.parent.GlobalToLocal(globalPos);
        pos.y -= 100;
        return pos;
    }

    public override Vector2 GetHeroModelPos2()
    {
        var globalPos = fightEnemyUnitSkin.petModel.LocalToGlobal(Vector2.zero);
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
        var globalPos = fightEnemyUnitSkin.headBar.LocalToGlobal(Vector2.zero);
        var pos = fightEnemyUnitSkin.parent.GlobalToLocal(globalPos);
        return pos;
    }

    public override Vector2 GetHeadBarPos2()
    {
        return fightEnemyUnitSkin.headBar.position;
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
    /// 更新buff 每次都清空 重新赋值一遍
    /// </summary>
    public void UpdateBuff(bool isInit = false)
    {
        if (isInit)
        {
            fightEnemyUnitSkin.buffBar.list_buff.itemRenderer = RenderList;
        }
        fightEnemyUnitSkin.buffBar.list_buff.numItems = buffIdList.Count;
        var row = Mathf.Max(1, Mathf.CeilToInt((float)buffIdList.Count / 5)); ;//行数
        fightEnemyUnitSkin.buffBar.list_buff.y = (row - 1) * -28;
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
    /// 死亡
    /// </summary>
    public override void Die()
    {
        base.Die();
        SetVisible(false);
        Coroutiner.StartCoroutine(DelayDie());
    }

    /// <summary>
    /// 复活
    /// </summary>
    public override void Revive()
    {
        base.Revive();
        Coroutiner.StartCoroutine(DelayRevive());
    }


    private IEnumerator DelayDie()
    {
        yield return new WaitForSeconds(0.1f / BattleModel.Instance.TimeScale);
        isShowDie = false;
        DieFinishCall();
    }

    private IEnumerator DelayRevive()
    {
        yield return new WaitForSeconds(0.1f / BattleModel.Instance.TimeScale);
        SetVisible(true);
        isShowRevive = false;
        ReviveviFinishCall();
    }

    private void SetVisible(bool isVisible)
    {
        fightEnemyUnitSkin.petModel.visible = isVisible;//TODO：在看具体动画表现具体是否需要复活延迟后再回调 
        fightEnemyUnitSkin.buffBar.visible = isVisible;
        fightEnemyUnitSkin.headBar.visible = isVisible;
    }

}
