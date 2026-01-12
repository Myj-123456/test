using Spine;
using Spine.Unity;
using System;
using System.Collections.Generic;
using UnityEngine;
using YooAsset;

/// <summary>
/// 加载spine模型
/// </summary>
public class HeroAvatar
{
    protected SkeletonDataAsset skeletonDataAsset;
    protected SkeletonAnimation bodySkeletonAnimation;//身体
    private Dictionary<DressPartType, SkeletonData> partSkeletonDataDic = new Dictionary<DressPartType, SkeletonData>();
    private Dictionary<DressPartType, int> partWearDic = new Dictionary<DressPartType, int>();
    private Skin partMixSkin;
    private SkeletonAnimation huibi;

    /// <summary>
    /// 初始化主体spine模型
    /// </summary>
    protected virtual void InitBody()
    {
        var spinePartUrl = ResPath.GetDressPartSpinePath("body", 0);
        var assetHandle = ResourceManager.Instance.LoadAssetSync<SkeletonDataAsset>(spinePartUrl);
        skeletonDataAsset = assetHandle.AssetObject as SkeletonDataAsset;
    }
    public SkeletonAnimation body
    {
        get { return bodySkeletonAnimation; }
    }

    public void ShowOrHide(bool show)
    {
        if (bodySkeletonAnimation != null)
        {
            bodySkeletonAnimation.gameObject.SetActive(show);
        }
    }

    public bool IsActive
    {
        get { return bodySkeletonAnimation != null ? bodySkeletonAnimation.gameObject.activeSelf : false; }
    }

    /// <summary>
    /// 添加 overlay 模型
    /// </summary>
    public void AddHuibi()
    {
        AnimationHelper.CreateSpine("huibi", bodySkeletonAnimation.transform, "idle", true, "", (SkeletonAnimation armatureComponent) =>
        {
            huibi = armatureComponent;
            var renderer = armatureComponent.GetComponent<Renderer>().sortingOrder = -1;
            armatureComponent.transform.localPosition = new Vector3(2.05f, 3.31f, 0f);
        });
    }


    /// <summary>
    /// 获取 dress part 的 spine 模型
    /// </summary>
    /// <param name="dressPartType"></param>
    /// <returns></returns>
    private SkeletonData GetPartSkeletonData(DressPartType dressPartType)
    {
        if (partSkeletonDataDic.TryGetValue(dressPartType, out SkeletonData skeletonData))
        {
            return skeletonData;
        }
        return null;
    }


    protected void SetSkin(SkeletonAnimation skeletonAnimation, string skinName)
    {
        Skin skin = skeletonAnimation.Skeleton.Data.FindSkin(skinName);
        if (skin != null)
        {
            skeletonAnimation.Skeleton.SetSkin(skin);
            skeletonAnimation.Skeleton.SetSlotsToSetupPose();
            skeletonAnimation.Skeleton.UpdateCache();
        }
    }

    public void PlayAnimation(string animationName, bool isLoop, Action playAniFinishCallBack = null)
    {
        if (bodySkeletonAnimation != null)
        {
            var trackEntry = bodySkeletonAnimation.AnimationState.SetAnimation(0, animationName, isLoop);
            trackEntry.TrackTime = 0;
            trackEntry.MixDuration = 0;
        }
        void OnAnimationEventHandler(Spine.TrackEntry trackEntry)
        {
            bodySkeletonAnimation.AnimationState.Complete -= OnAnimationEventHandler;
            if (animationName == trackEntry.Animation.Name)
            {
                playAniFinishCallBack?.Invoke();
            }
        }
        if (playAniFinishCallBack != null)
        {
            bodySkeletonAnimation.AnimationState.Complete += OnAnimationEventHandler;
        }

    }


    /// <summary>
    /// 更新 dress part 模型
    /// isFiltAccessories 是否过滤配件
    /// </summary>
    public void UpdateDress(bool isFiltAccessorie = false)
    {
        foreach (DressPartType part in Enum.GetValues(typeof(DressPartType)))
        {
            if (isFiltAccessorie && part == DressPartType.Accessories) continue;
            var wearPartId = 0;
            if (MyselfModel.Instance.atHome)
            {
                wearPartId = DressModel.Instance.GetWearPartId((int)part);
            }
            else
            {
                wearPartId = VisitFriendModel.Instance.GetWearPartId((int)part);
            }
            if (part == DressPartType.Face || part == DressPartType.Ear)//脸部、耳朵使用默认的
            {
                ChangePart(part, wearPartId);
            }
            else
            {
                if (wearPartId > 0)
                {
                    ChangePart(part, wearPartId);
                }
            }
        }
    }


    /// <summary>
    /// 更新部位装备
    /// </summary>
    public void UpdateDress(int[] clothIds)
    {
        foreach (var value in clothIds)
        {
            var dress = DressModel.Instance.GetDressConfig(value);
            ChangePart((DressPartType)dress.Type, value);
        }
        ChangePart(DressPartType.Ear, 0);//耳朵使用默认的
    }

    /// <summary>
    /// 更新部位装备
    /// </summary>
    public void UpdateDress(Dictionary<int, DressData> dressMap)
    {
        foreach (DressPartType part in Enum.GetValues(typeof(DressPartType)))
        {
            var wearPartId = 0;
            if (part == DressPartType.Ear)//耳朵使用默认的
            {
                ChangePart(part, wearPartId);
            }
            else
            {
                if (dressMap.ContainsKey((int)part) && dressMap[(int)part].clothesId > 0)
                {
                    ChangePart(part, dressMap[(int)part].clothesId);
                }
            }
        }
    }

    /// <summary>
    /// 更新部位装备
    /// </summary>
    /// <param name="partName">部位名称</param>
    /// <param name="partId">部位id</param>
    public void ChangePart(DressPartType dressPartType, int partId)
    {
        Debug.Log("ChangePart,dressPartType:" + dressPartType.ToString() + " partId:" + partId);
        if (partWearDic.ContainsKey(dressPartType) && partWearDic[dressPartType] == partId)
        {
            return;//部位id没有改变，无需更新
        }
        if (partMixSkin == null)
        {
            Skin skinDefault = bodySkeletonAnimation.Skeleton.Data.FindSkin("body");
            // 创建一个新的皮肤用于混合
            partMixSkin = new Skin("Mix");
            // 复制默认皮肤到新皮肤
            partMixSkin.CopySkin(skinDefault);
        }
        // 对应部位的模型路径
        var partName = dressPartType.ToString().ToLower();
        var spinePartUrl = ResPath.GetDressPartSpinePath(partName, partId);
        var assetHandle = ResourceManager.Instance.LoadAssetAsync<SkeletonDataAsset>(spinePartUrl);
        assetHandle.Completed += (AssetHandle assetHandle) =>
        {
            TakeOffPart(dressPartType);
            var skeletonDataAsset = assetHandle.AssetObject as SkeletonDataAsset;
            if (skeletonDataAsset == null)
            {
                Debug.LogWarning("对应皮肤不存在 partId: " + partId + "partName:" + partName);
                return;
            }
            var skeletonData = skeletonDataAsset.GetSkeletonData(false);
            Skin skin = skeletonData.FindSkin(partName);//获取对应部位的皮肤
            if (skin == null)//对应皮肤不存在
            {
                Debug.LogWarning("对应皮肤不存在 partId: " + partId + "partName:" + partName);
                return;
            };
            if (partSkeletonDataDic.ContainsKey(dressPartType))
            {
                partSkeletonDataDic[dressPartType] = skeletonData;
            }
            else
            {
                partSkeletonDataDic.Add(dressPartType, skeletonData);
            }
            if (partWearDic.ContainsKey(dressPartType))
            {
                partWearDic[dressPartType] = partId;
            }
            else
            {
                partWearDic.Add(dressPartType, partId);
            }

            partMixSkin.AddSkin(skin, bodySkeletonAnimation.Skeleton.Data);//将部位的皮肤添加到混合皮肤中
            // 设置混合皮肤为当前皮肤
            bodySkeletonAnimation.Skeleton.SetSkin(partMixSkin);
            bodySkeletonAnimation.skeleton.UpdateCache();
            bodySkeletonAnimation.skeleton.SetSlotsToSetupPose();
        };
    }

    /// <summary>
    /// 脱下部位    
    /// </summary>
    private void TakeOffPart(DressPartType dressPartType)
    {
        if (dressPartType == DressPartType.Skirt)//如果穿的是连衣裙，那么需要脱下上衣和下装
        {
            RemovePart(DressPartType.Up_clothes);
            RemovePart(DressPartType.Dw_clothes);
        }
        else if (dressPartType == DressPartType.Up_clothes || dressPartType == DressPartType.Dw_clothes)//如果穿的是上衣或下装，那么需要脱下连衣裙
        {
            RemovePart(DressPartType.Skirt);
        }
        RemovePart(dressPartType);
    }

    /// <summary>
    /// 脱下部位    
    /// </summary>
    /// <param name="partName"></param>
    public void RemovePart(DressPartType dressPartType)
    {
        if (!partWearDic.ContainsKey(dressPartType)) return;// 没有装备，无需脱下
        if (partMixSkin == null)
        {
            return;
        }
        var skeletonData = GetPartSkeletonData(dressPartType);
        if (skeletonData == null)
        {
            return;
        }
        // 获取部位名称
        var partName = dressPartType.ToString().ToLower();
        Skin targetSkin = skeletonData.FindSkin(partName);
        if (targetSkin == null)
        {
            return;
        }
        partMixSkin.RemoveSkin(targetSkin, bodySkeletonAnimation.Skeleton.Data);
        // 设置混合皮肤为当前皮肤
        bodySkeletonAnimation.Skeleton.SetSkin(partMixSkin);
        bodySkeletonAnimation.Skeleton.SetSlotsToSetupPose();
        bodySkeletonAnimation.Skeleton.UpdateCache();
        partWearDic.Remove(dressPartType);//移除部位装备记录
    }

    /// <summary>
    /// 脱下所有部位
    /// </summary>
    public void RemoveAllPart()
    {

    }


    /// <summary>
    /// 改变播放速度
    /// </summary>
    /// <param name="timeScale"></param>
    public void ChangeTimeScale(float timeScale)
    {
        if (bodySkeletonAnimation != null)
        {
            bodySkeletonAnimation.timeScale = timeScale;
        }
    }


    private float lastTimeScale;
    /// <summary>
    /// 暂停播放
    /// </summary>
    public void Stop()
    {
        if (bodySkeletonAnimation != null)
        {
            lastTimeScale = bodySkeletonAnimation.timeScale;
            bodySkeletonAnimation.timeScale = 0;
        }
    }

    /// <summary>
    /// 恢复播放
    /// </summary>
    public void Resume()
    {
        if (bodySkeletonAnimation != null)
        {
            bodySkeletonAnimation.timeScale = lastTimeScale;
        }
    }

}
