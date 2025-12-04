using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 特效播放辅助
/// </summary>
public class EffectHelper
{
    /// <summary>
    /// 创建一个特效
    /// </summary>
    /// <param name="effectName"></param>
    /// <param name="transform"></param>
    /// <param name="pos"></param>
    /// <param name="scale"></param>
    /// <param name="aniName"></param>
    /// <param name="isLoop"></param>
    /// <param name="OnPlayAniComCall"></param>
    public static void CreateEffect(string effectName, Transform transform, Vector3 pos = default, Vector3 scale = default, string aniName = "animation", bool isLoop = false, Action OnPlayAniComCall = null)
    {
        if (pos == default) pos = Vector3.one;
        if (scale == default) scale = Vector3.one;
        AnimationHelper.CreateSpine(effectName, transform, aniName, isLoop, "", (Spine.Unity.SkeletonAnimation armatureComponent) =>
        {
            armatureComponent.gameObject.transform.localPosition = pos;
            armatureComponent.gameObject.transform.localScale = scale;
            armatureComponent.timeScale = BattleModel.Instance.TimeScale;
            void OnAnimationEventHandler(Spine.TrackEntry trackEntry)
            {
                armatureComponent.AnimationState.Complete -= OnAnimationEventHandler;
                OnPlayAniComCall();
            }
            if (OnPlayAniComCall != null)
            {
                armatureComponent.AnimationState.Complete += OnAnimationEventHandler;
            }
        });
    }
}
