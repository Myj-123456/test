using ADK;
using FairyGUI;
using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using YooAsset;

public class BaseUI
{
    public object data;
    private List<IEnumerator> enumerators = new List<IEnumerator>();

    /// <summary>
    /// 创建一个spine动画
    /// </summary>
    /// <param name="spineName"></param>
    /// <param name="aLoader"></param>
    /// <param name="callback"></param>
    public void CreateSpine(string spineName, GLoader3D aLoader, string animationName = "", bool isLoop = false, Action<SkeletonAnimation> callback = null)
    {
        var assetHandle = ResourceManager.Instance.LoadAssetAsync<SkeletonDataAsset>(ResPath.GetSpinePath(spineName));
        assetHandle.Completed += (AssetHandle assetHandle) =>
        {
            var skeletonDataAsset = assetHandle.AssetObject as SkeletonDataAsset;
            aLoader.SetSpine(skeletonDataAsset, (int)aLoader.width, (int)aLoader.height, Vector2.zero);
            if (!string.IsNullOrEmpty(animationName))
            {
                aLoader.spineAnimation.AnimationState.SetAnimation(0, animationName, isLoop);
            }
            callback?.Invoke(aLoader.spineAnimation);
        };
    }

    #region 游戏事件
    public void DispatchEvent(string eventName) => EventManager.Instance.DispatchEvent(eventName);
    public void DispatchEvent<T1>(string eventName, T1 arg1) => EventManager.Instance.DispatchEvent(eventName, arg1);
    public void DispatchEvent<T1, T2>(string eventName, T1 arg1, T2 arg2) => EventManager.Instance.DispatchEvent(eventName, arg1, arg2);
    public void DispatchEvent<T1, T2, T3>(string eventName, T1 arg1, T2 arg2, T3 arg3) => EventManager.Instance.DispatchEvent(eventName, arg1, arg2, arg3);
    public void DispatchEvent<T1, T2, T3, T4>(string eventName, T1 arg1, T2 arg2, T3 arg3, T4 arg4) => EventManager.Instance.DispatchEvent(eventName, arg1, arg2, arg3, arg4);

    public void AddEventListener(string eventName, Action action) => EventManager.Instance.AddEventListener(eventName, action);
    public void AddEventListener<T1>(string eventName, Action<T1> action) => EventManager.Instance.AddEventListener(eventName, action);
    public void AddEventListener<T1, T2>(string eventName, Action<T1, T2> action) => EventManager.Instance.AddEventListener(eventName, action);
    public void AddEventListener<T1, T2, T3>(string eventName, Action<T1, T2, T3> action) => EventManager.Instance.AddEventListener(eventName, action);
    public void AddEventListener<T1, T2, T3, T4>(string eventName, Action<T1, T2, T3, T4> action) => EventManager.Instance.AddEventListener(eventName, action);

    public void RemoveEventListener(string eventName, Action action) => EventManager.Instance.RemoveEventListener(eventName, action);
    public void RemoveEventListener<T1>(string eventName, Action<T1> action) => EventManager.Instance.RemoveEventListener(eventName, action);
    public void RemoveEventListener<T1, T2>(string eventName, Action<T1, T2> action) => EventManager.Instance.RemoveEventListener(eventName, action);
    public void RemoveEventListener<T1, T2, T3>(string eventName, Action<T1, T2, T3> action) => EventManager.Instance.RemoveEventListener(eventName, action);
    public void RemoveEventListener<T1, T2, T3, T4>(string eventName, Action<T1, T2, T3, T4> action) => EventManager.Instance.RemoveEventListener(eventName, action);
    #endregion

    public void AddClickListener(GComponent component, EventCallback0 callback)
    {
        component.AddEventListener("onClick", callback);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strType"></param>
    /// <param name="callback"></param>
    public void RemoveClickListener(GComponent component, EventCallback1 callback)
    {
        component.RemoveEventListener("onClick", callback);
    }

    /// <summary>
    /// 开启协程
    /// </summary>
    /// <param name="ie"></param>
    /// <returns></returns>
    public Coroutine StartCoroutine(IEnumerator ie)
    {
        enumerators.Add(ie);
        return Coroutiner.StartCoroutine(ie);
    }

    /// <summary>
    /// 关闭协程
    /// </summary>
    /// <param name="ie"></param>
    public void StopCoroutine(IEnumerator ie)
    {
        Coroutiner.StopCoroutine(ie);
    }
    protected void StopAllCoroutine()
    {
        foreach (var enumerator in enumerators)
        {
            StopCoroutine(enumerator);
        }
        enumerators.Clear();
    }
}
