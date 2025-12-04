using FairyGUI;
using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YooAsset;

public class SkillTimeConfig
{
    public float start;//开始时间
    public float duration;//持续时间
}

/// <summary>
/// 绘笔技能时间配置
/// </summary>
public class SkillHuibiTimeConfigs
{
    public SkillTimeConfig timeConfigFly;
    public SkillTimeConfig timeConfigBack;
    public SkillTimeConfig timeConfigIdle;
}

/// <summary>
/// 敌人攻击技能时间配置
/// </summary>
public class SkillEnemyTimeConfigs
{
    public SkillTimeConfig timeConfigStart;
    public SkillTimeConfig timeConfigFly;
    public SkillTimeConfig timeConfigBack;
    public SkillTimeConfig timeConfigIdle;
}

/// <summary>
/// 技能管理器
/// </summary>
public class SkillManager : Singleton<SkillManager>
{
    private GComponent layer;

    private Dictionary<string, SkillHuibiTimeConfigs> skillHuibiTimeDic = new Dictionary<string, SkillHuibiTimeConfigs>();//绘笔技能时间配置
    private Dictionary<string, SkillEnemyTimeConfigs> skillEnemyTimeDic = new Dictionary<string, SkillEnemyTimeConfigs>();//敌人攻击技能时间配置

    /// <summary>
    /// 设置技能播放层级
    /// </summary>
    /// <param name="gComponent"></param>
    public void SetPlayLayer(GComponent layer)
    {
        this.layer = layer;
    }
    /// <summary>
    /// 释放一个技能
    /// </summary>
    /// <param name="skillId">技能id</param>
    /// <param name="caster">施法者</param>
    /// <param name="target">目标者</param>
    public void ReleaseSkill(uint skillId, BaseFightUnit caster, BaseFightUnit target, System.Action skillAttackcallback = null, System.Action skillFinishcallback = null, float duration = 0f)
    {
        BaseSkill baseSkill = null;
        switch (skillId)
        {
            case 1:
                baseSkill = new HeroBallisticSkill();
                break;
            case 2:
                baseSkill = new TargetReleaseSkill();
                break;
            case 3:
                baseSkill = new EnemyBulletSkill();
                break;
        }
        baseSkill.SetSkillId(skillId);
        baseSkill.duration = duration;
        baseSkill.SetPlayLayer(layer);
        baseSkill.SetOwner(caster);
        baseSkill.SetTarget(target);
        baseSkill.SetOnAttack(skillAttackcallback);
        baseSkill.SetSkillReleasedCallback(skillFinishcallback);
        baseSkill.ReleaseSkill();
    }

    /// <summary>
    /// 获取一个画笔技能时间配置
    /// </summary>
    /// <param name="skeletonAnimation"></param>
    /// <param name="aniName"></param>
    /// <returns></returns>
    public SkillHuibiTimeConfigs GetSkillTimeConfigs(SkeletonAnimation skeletonAnimation, string aniName)
    {
        SkillHuibiTimeConfigs skillTimeConfigs = null;
        var key = skeletonAnimation.name + "_" + aniName;
        if (!skillHuibiTimeDic.TryGetValue(key, out skillTimeConfigs))
        {
            skillTimeConfigs = new SkillHuibiTimeConfigs();
            Spine.Animation animation = skeletonAnimation.Skeleton.Data.FindAnimation(aniName);
            if (animation == null)
            {
                Debug.LogError("找不到动画！");
                return null;
            }

            float attakTime = 0f;
            float backTime = 0f;
            float backendTime = 0f;
            var timeline = animation.Timelines.Items[animation.Timelines.Count - 1];//定义好最后一个Timeline一定event时间轴
            if (timeline != null && timeline is EventTimeline eventTimeline)
            {
                foreach (Spine.Event e in eventTimeline.Events)
                {
                    Debug.Log($"动画1 '{e.Data.Name}' 的事件 时间: {e.Time}");
                    var eventName = e.Data.Name;
                    var time = e.Time;
                    if (eventName == "attack")
                    {
                        attakTime = time;
                    }
                    else if (eventName == "back")
                    {
                        backTime = time;
                    }
                    else if (eventName == "backend")
                    {
                        backendTime = time;
                    }
                }
            }
            else
            {
                Debug.LogWarning("最后一个Timeline不是eventTimeline aniName:" + aniName);
                return null;
            }

            skillTimeConfigs.timeConfigFly = new SkillTimeConfig() { start = 0f, duration = attakTime };
            skillTimeConfigs.timeConfigBack = new SkillTimeConfig() { start = backTime, duration = backendTime - backTime };
            skillTimeConfigs.timeConfigIdle = new SkillTimeConfig() { start = backendTime, duration = 0f };
            skillHuibiTimeDic.Add(key, skillTimeConfigs);
        }
        return skillTimeConfigs;
    }

    /// <summary>
    /// 获取一个敌人攻击技能时间配置
    /// </summary>
    /// <param name="skeletonAnimation"></param>
    /// <param name="aniName"></param>
    /// <returns></returns>
    public SkillEnemyTimeConfigs GetEnemySkillTimeConfigs(SkeletonAnimation skeletonAnimation, string aniName)
    {
        SkillEnemyTimeConfigs skillTimeConfigs = null;
        var key = skeletonAnimation.name + "_" + aniName;
        if (!skillEnemyTimeDic.TryGetValue(key, out skillTimeConfigs))
        {
            skillTimeConfigs = new SkillEnemyTimeConfigs();
            Spine.Animation animation = skeletonAnimation.Skeleton.Data.FindAnimation(aniName);
            if (animation == null)
            {
                Debug.LogError("找不到动画！");
                return null;
            }

            float startTime = 0f;//开始时间
            float attakTime = 0f;//攻击时间
            float backTime = 0f;//回来时间
            float backendTime = 0f;//回来完毕时间

            var timeline = animation.Timelines.Items[animation.Timelines.Count - 1];//定义好最后一个Timeline一定event时间轴
            if (timeline != null && timeline is EventTimeline eventTimeline)
            {
                foreach (Spine.Event e in eventTimeline.Events)
                {
                    Debug.Log($"动画1 '{e.Data.Name}' 的事件 时间: {e.Time}");
                    var eventName = e.Data.Name;
                    var time = e.Time;
                    if (eventName == "start")
                    {
                        startTime = time;
                    }
                    else if (eventName == "attack")
                    {
                        attakTime = time;
                    }
                    else if (eventName == "back")
                    {
                        backTime = time;
                    }
                    else if (eventName == "backend")
                    {
                        backendTime = time;
                    }
                }
            }
            else
            {
                Debug.LogWarning("最后一个Timeline不是eventTimeline aniName:" + aniName);
                return null;
            }

            skillTimeConfigs.timeConfigStart = new SkillTimeConfig() { start = 0f, duration = startTime };
            skillTimeConfigs.timeConfigFly = new SkillTimeConfig() { start = startTime, duration = attakTime - startTime };
            if (backTime != 0 && backendTime != 0)//有些没返回的
            {
                skillTimeConfigs.timeConfigBack = new SkillTimeConfig() { start = backTime, duration = backendTime - backTime };
                skillTimeConfigs.timeConfigIdle = new SkillTimeConfig() { start = backendTime, duration = 0f };
            }
            else//idle动画如果没配置 那么默认使用总动画时间
            {
                skillTimeConfigs.timeConfigIdle = new SkillTimeConfig() { start = animation.Duration, duration = 0f };
            }
            skillEnemyTimeDic.Add(key, skillTimeConfigs);
        }
        return skillTimeConfigs;
    }
}
