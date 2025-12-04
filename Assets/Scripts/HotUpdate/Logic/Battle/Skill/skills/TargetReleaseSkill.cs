using FairyGUI;
using Spine.Unity;
using UnityEngine;

/// <summary>
/// 原目标释放技能
/// </summary>
public class TargetReleaseSkill : BaseSkill
{
    public override void ReleaseSkill()
    {
        base.ReleaseSkill();
        PlayEffect();
    }

    public void PlayEffect()
    {
        AttackSkillCall();
        ReleasedSkillCall();
        return;//不播放这个特效了

        GLoader3D effect = EffectPool.Instance.GetEffect("xianhuashengji");
        effect.scaleX = 0.5f;
        effect.scaleY = 0.5f;
        effect.loop = false;
        effect.timeScale = BattleModel.Instance.TimeScale;
        effect.animationName = "animation";
        effect.forcePlay = true;
        target.AddEffect(effect);//添加到目标身上
        //layer.AddChild(effect);//添加到界面层(一般是界面层特效)
        //effect.xy = target.GetHeroEffectPos();
        AttackSkillCall();
        effect.Complete = (string name) =>
        {
            effect.Complete = null;
            ReleasedSkillCall();
            EffectPool.Instance.ReturnEffect(effect);//对象池回收
        };
    }
}
