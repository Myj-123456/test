using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 技能基类
/// </summary>
public class BaseSkill
{
    protected uint skillId;//技能id
    protected BaseFightUnit owner;//技能拥有者
    protected BaseFightUnit target;//技能目标
    private System.Action onAttack; // 技能触发攻击回调
    private System.Action onSkillFinishCall; // 技能释放完毕回调
    protected GComponent layer;
    public float duration;//持续时间(目前只有弹道技能才有值)


    public void SetSkillId(uint skillId)
    {
        this.skillId = skillId;
    }
    public void SetOwner(BaseFightUnit owner)
    {
        this.owner = owner;
    }
    public void SetTarget(BaseFightUnit target)
    {
        this.target = target;
    }
    public void SetPlayLayer(GComponent layer)
    {
        this.layer = layer;
    }

    public void SetOnAttack(System.Action callback)
    {
        this.onAttack = callback;
    }
    public void SetSkillReleasedCallback(System.Action callback)
    {
        this.onSkillFinishCall = callback;
    }

    /// <summary>
    /// 释放技能
    /// </summary>
    public virtual void ReleaseSkill()
    {

    }

    /// <summary>
    /// 释放技能触发攻击
    /// </summary>
    protected void AttackSkillCall()
    {
        onAttack?.Invoke();
    }

    /// <summary>
    /// 释放技能完毕
    /// </summary>
    protected void ReleasedSkillCall()
    {
        onSkillFinishCall?.Invoke();
    }
}
