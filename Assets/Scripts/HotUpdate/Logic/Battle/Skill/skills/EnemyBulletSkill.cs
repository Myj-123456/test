using ADK;
using FairyGUI;
using Spine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YooAsset;

/// <summary>
/// 敌人弹道飞行技能
/// </summary>
public class EnemyBulletSkill : BaseSkill
{
    public override void ReleaseSkill()
    {
        base.ReleaseSkill();

        // 创建技能图标
        var skillIcon = (GLoader)UIObjectFactory.NewObject(ObjectType.Loader);
        skillIcon.autoSize = true;
        //skillIcon.SetSize(64, 64);
        skillIcon.pivotAsAnchor = true;
        skillIcon.pivotX = 0.5f;
        skillIcon.pivotY = 0.5f;
        skillIcon.fill = FillType.Scale;
        layer.AddChild(skillIcon);
        //skillIcon.url = $"Battle/SkillIcon/skill_{skillId}.png";
        skillIcon.url = "Battle/SkillIcon/fengho_bullet.png";
        var bulletPos = owner.GetHeroModelPos();
        bulletPos.y += 50;//偏下点 尽量每个偏移都一致 不一致就要走配置了 或者通过获取里面开火点位置
        skillIcon.xy = bulletPos;

        // 目标位置（假设target是目标对象）
        Vector2 targetPos = target.GetHeroModelPos();
        //targetPos.y -= 100;//y坐标偏移上点

        // 使用GTween实现弹道飞行效果
        GTween.To(skillIcon.xy, targetPos, duration / BattleModel.Instance.TimeScale)  // 飞行时间
            .SetTarget(skillIcon)  // 设置目标对象
            .SetEase(EaseType.Linear)  // 使用QuadOut缓动效果，看起来更像弹道
            .OnUpdate((GTweener tweener) =>
            {
                // 更新位置
                skillIcon.xy = tweener.value.vec2;
            })
            .OnComplete(() =>
            {
                skillIcon.RemoveFromParent();
                skillIcon.Dispose();
                // 到达目标后的回调
                AttackSkillCall();
            });
    }

}
