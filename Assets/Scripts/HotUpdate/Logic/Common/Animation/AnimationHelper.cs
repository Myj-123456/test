
using System.Threading.Tasks;
using UnityEngine;
using YooAsset;
using System.Collections.Generic;
using System;
using Spine.Unity;
using System.Collections;
/// <summary>
/// 动画创建器
/// </summary>
public class AnimationHelper
{
    /// <summary>
    /// 创建spine动画
    /// </summary>
    /// <param name="spineName"></param>
    /// <param name="transform"></param>
    /// <param name="sortingLayerName"></param>
    /// <param name="callback"></param>
    public static void CreateSpine(string spineName, UnityEngine.Transform transform, string animationName = "", bool isLoop = false, string sortingLayerName = "", Action<SkeletonAnimation> callback = null)
    {
        var assetHandle = ResourceManager.Instance.LoadAssetAsync<SkeletonDataAsset>(ResPath.GetSpinePath(spineName));
        assetHandle.Completed += (AssetHandle assetHandle) =>
        {
            var skeletonDataAsset = assetHandle.AssetObject as SkeletonDataAsset;
            SkeletonAnimation skeletonAnimation = SkeletonAnimation.NewSkeletonAnimationGameObject(skeletonDataAsset);
            skeletonAnimation.name = spineName;
            skeletonAnimation.transform.SetParent(transform,false);
            skeletonAnimation.Initialize(false);
            if (!string.IsNullOrEmpty(animationName))
            {
                skeletonAnimation.AnimationState.SetAnimation(0, animationName, isLoop);
            }
            if (!string.IsNullOrEmpty(sortingLayerName))
            {
                skeletonAnimation.GetComponent<Renderer>().sortingLayerName = sortingLayerName;
            }
            callback?.Invoke(skeletonAnimation);
        };
    }

    /// <summary>
    /// 创建mc动画
    /// </summary>
    /// <param name="mcName"></param>
    /// <param name="transform"></param>
    /// <param name="sortingLayerName"></param>
    /// <param name="callback"></param>
    public static void CreateMC(string mcName, UnityEngine.Transform transform, string sortingLayerName = "", Action<GameObject> callback = null)
    {
        var assetHandle = ResourceManager.Instance.LoadAssetAsync<GameObject>(ResPath.GetMcPath(mcName));
        assetHandle.Completed += (AssetHandle assetHandle) =>
        {
            var mcObject = assetHandle.InstantiateSync();
            mcObject.name = mcName;
            mcObject.transform.SetParent(transform, false);
            mcObject.transform.localPosition = Vector3.zero;
            mcObject.transform.localRotation = Quaternion.identity;
            if (!string.IsNullOrEmpty(sortingLayerName))
            {
                mcObject.GetComponent<Renderer>().sortingLayerName = sortingLayerName;
            }
            callback?.Invoke(mcObject);
        };
    }

    /// <summary>
    /// 创建粒子特效
    /// </summary>
    /// <param name="particleName"></param>
    /// <param name="transform"></param>
    /// <param name="sortingLayerName"></param>
    /// <param name="callback"></param>
    public static void CreateParticle(string particleName, UnityEngine.Transform transform, string sortingLayerName = "", Action<GameObject> callback = null)
    {
        var assetHandle = ResourceManager.Instance.LoadAssetAsync<GameObject>(ResPath.GetParticlePath(particleName));
        assetHandle.Completed += (AssetHandle assetHandle) =>
        {
            var particleObject = assetHandle.InstantiateSync();
            particleObject.name = particleName;
            particleObject.transform.SetParent(transform, false);
            particleObject.transform.localPosition = Vector3.zero;
            particleObject.transform.localRotation = Quaternion.identity;
            if (!string.IsNullOrEmpty(sortingLayerName))
            {
                particleObject.GetComponent<Renderer>().sortingLayerName = sortingLayerName;
            }
            callback?.Invoke(particleObject);
        };
    }
}
