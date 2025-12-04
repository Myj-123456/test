using ADK;
using FairyGUI;
using Spine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YooAsset;

/// <summary>
/// 主角弹道飞行技能
/// </summary>
public class HeroBallisticSkill : BaseSkill
{
    private GLoader3D huibiModel;
    private Vector2 huibiModelOrgPos;
    private float deleyTime = 0.3f;//施法延迟时间
    private string skillAnimationName;//技能动画名字
    private SkillHuibiTimeConfigs skillTimeConfigs;

    public override void ReleaseSkill()
    {
        base.ReleaseSkill();

        if (huibiModel == null && owner is FightHeroUnit fightHeroUnit)
        {
            huibiModel = fightHeroUnit.huibiModel;
        }
        huibiModelOrgPos = huibiModel.position;
        skillAnimationName = !owner.isCril ? "attack1" : "attack2";
        skillTimeConfigs = SkillManager.Instance.GetSkillTimeConfigs(huibiModel.spineAnimation, skillAnimationName);
        Coroutiner.StartCoroutine(StartHuabiFly(skillTimeConfigs.timeConfigFly));
        Coroutiner.StartCoroutine(StartHuabiBack(skillTimeConfigs.timeConfigBack));
        Coroutiner.StartCoroutine(StartHuabiIdle(skillTimeConfigs.timeConfigIdle));
    }

    private IEnumerator StartHuabiFly(SkillTimeConfig skillTimeConfig)
    {
        yield return new WaitForSeconds(deleyTime / BattleModel.Instance.TimeScale);//延迟0.3f 和玩家施法动作对齐
        huibiModel.animationName = skillAnimationName;
        huibiModel.loop = false;
        var targetPos = target.GetHeroModelPos2();
        targetPos = huibiModel.parent.GlobalToLocal(targetPos);//转到当前主角所在层级坐标
        if (target is FightHeroUnit)//目标方是英雄偏移点
        {
            targetPos.y -= 100;
        }
        // 使用GTween实现弹道飞行效果
        GTween.To(huibiModel.xy, targetPos, skillTimeConfig.duration / BattleModel.Instance.TimeScale)  // 飞行时间
            .SetTarget(huibiModel)  // 设置目标对象
            .SetEase(EaseType.Linear)  // 使用QuadOut缓动效果，看起来更像弹道
            .OnUpdate((GTweener tweener) =>
            {
                // 更新位置
                huibiModel.xy = tweener.value.vec2;
            })
            .OnComplete(() =>
            {
                StartHuabiAttack();
            });
    }

    /// <summary>
    /// 绘笔开始攻击
    /// </summary>
    private void StartHuabiAttack()
    {
        Debug.Log("飞到目标之后 开始播放攻击特效");
        GLoader3D effect = EffectPool.Instance.GetEffect("effect/attack");
        effect.scaleX = 0.5f;
        effect.scaleY = 0.5f;
        effect.animationName = skillAnimationName;
        effect.forcePlay = true;
        effect.loop = false;
        var offY = 0;
        if (target is FightHeroUnit)//目标方是英雄偏移点
        {
            offY = -100;
        }
        target.AddEffect(effect, EffectPos.Center, EffectOrientation.Default, offY);//添加到目标身上
        effect.Complete = (string name) =>
        {
            effect.Complete = null;
            EffectPool.Instance.ReturnEffect(effect);//对象池回收
        };
        AttackSkillCall();
    }

    /// <summary>
    /// 绘笔开始返回
    /// </summary>
    private IEnumerator StartHuabiBack(SkillTimeConfig skillTimeConfig)
    {
        yield return new WaitForSeconds((deleyTime + skillTimeConfig.start) / BattleModel.Instance.TimeScale);//延迟0.3f 和玩家施法动作对齐
        Debug.Log("攻击结束 开始往回飞");
        var targetPos = huibiModelOrgPos;
        // 使用GTween实现弹道飞行效果
        GTween.To(huibiModel.xy, targetPos, skillTimeConfig.duration / BattleModel.Instance.TimeScale)  // 飞行时间
            .SetTarget(huibiModel)  // 设置目标对象
            .SetEase(EaseType.Linear)  // 使用QuadOut缓动效果，看起来更像弹道
            .OnUpdate((GTweener tweener) =>
            {
                // 更新位置
                huibiModel.xy = tweener.value.vec2;
            });
    }

    private IEnumerator StartHuabiIdle(SkillTimeConfig skillTimeConfig)
    {
        yield return new WaitForSeconds((deleyTime + skillTimeConfig.start) / BattleModel.Instance.TimeScale);//延迟0.3f 和玩家施法动作对齐
        huibiModel.animationName = "idle";
        huibiModel.loop = true;
        ReleasedSkillCall();
    }

}
