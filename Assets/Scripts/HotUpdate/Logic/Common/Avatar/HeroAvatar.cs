using Spine;
using Spine.Unity;
using System;
using System.Collections.Generic;
using UnityEngine;
using YooAsset;

/// <summary>
/// ����spineģ��
/// </summary>
public class HeroAvatar
{
    protected SkeletonDataAsset skeletonDataAsset;
    protected SkeletonAnimation bodySkeletonAnimation;//����
    private Dictionary<DressPartType, SkeletonData> partSkeletonDataDic = new Dictionary<DressPartType, SkeletonData>();
    private Dictionary<DressPartType, int> partWearDic = new Dictionary<DressPartType, int>();
    private Skin partMixSkin;
    private SkeletonAnimation huibi;

    /// <summary>
    /// ��ʼ������
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
    /// ���ӻ��
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
    /// ��λ��������
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
    /// ���²�λ��װ
    /// isFiltAccessories �Ƿ���˵����
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
            if (part == DressPartType.Face || part == DressPartType.Ear)//���͡�������Ĭ�ϵ�
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
    /// ���²�λ��װ
    /// </summary>
    public void UpdateDress(int[] clothIds)
    {
        foreach(var value in clothIds)
        {
            var dress = DressModel.Instance.GetDressConfig(value);
            ChangePart((DressPartType)dress.Type, value);
        }
        ChangePart(DressPartType.Ear, 0);//������Ĭ�ϵ�
    }

    /// <summary>
    /// ���²�λ��װ
    /// </summary>
    public void UpdateDress(Dictionary<int, DressData> dressMap)
    {
        foreach (DressPartType part in Enum.GetValues(typeof(DressPartType)))
        {
            var wearPartId = 0;
            if (part == DressPartType.Ear)//���͡�������Ĭ�ϵ�
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
    ///����λ
    /// </summary>
    /// <param name="partName">��λ����</param>
    /// <param name="partId">��λid</param>
    public void ChangePart(DressPartType dressPartType, int partId)
    {
        if (partWearDic.ContainsKey(dressPartType) && partWearDic[dressPartType] == partId)
        {
            return;//��λidû�ı䲻��Ҫˢ��
        }
        if (partMixSkin == null)
        {
            Skin skinDefault = bodySkeletonAnimation.Skeleton.Data.FindSkin("body");
            // ����һ���µ�Ƥ������
            partMixSkin = new Skin("Mix");
            // ���� MissDie Ĭ��Ƥ��
            partMixSkin.CopySkin(skinDefault);
        }
        //���ض�Ӧ��λ����
        var partName = dressPartType.ToString().ToLower();
        var spinePartUrl = ResPath.GetDressPartSpinePath(partName, partId);
        var assetHandle = ResourceManager.Instance.LoadAssetAsync<SkeletonDataAsset>(spinePartUrl);
        assetHandle.Completed += (AssetHandle assetHandle) =>
        {
            TakeOffPart(dressPartType);
            var skeletonDataAsset = assetHandle.AssetObject as SkeletonDataAsset;
            if (skeletonDataAsset == null)
            {
                Debug.LogWarning("��ӦƤ�������� partId: " + partId + "partName:" + partName);
                return;
            }
            var skeletonData = skeletonDataAsset.GetSkeletonData(false);
            Skin skin = skeletonData.FindSkin(partName);//��ȡ��Ӧ��λ����Ƥ��
            if (skin == null)//��ӦƤ��������
            {
                Debug.LogWarning("��ӦƤ�������� partId: " + partId + "partName:" + partName);
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

            partMixSkin.AddSkin(skin, bodySkeletonAnimation.Skeleton.Data);//�ϲ�Ƥ�������Ǽ�
            // ����Ƥ�����õ����Ǽ���
            bodySkeletonAnimation.Skeleton.SetSkin(partMixSkin);
            bodySkeletonAnimation.skeleton.UpdateCache();
            bodySkeletonAnimation.skeleton.SetSlotsToSetupPose();
        };
    }

    /// <summary>
    /// ���²�λ
    /// </summary>
    private void TakeOffPart(DressPartType dressPartType)
    {
        if (dressPartType == DressPartType.Skirt)//���������������ȹ ��ô��Ҫ������װ����
        {
            RemovePart(DressPartType.Up_clothes);
            RemovePart(DressPartType.Dw_clothes);
        }
        else if (dressPartType == DressPartType.Up_clothes || dressPartType == DressPartType.Dw_clothes)//���������������װ ��ô��Ҫ������ȹ����
        {
            RemovePart(DressPartType.Skirt);
        }
        RemovePart(dressPartType);
    }

    /// <summary>
    /// �Ƴ���λ
    /// </summary>
    /// <param name="partName"></param>
    public void RemovePart(DressPartType dressPartType)
    {
        if (!partWearDic.ContainsKey(dressPartType)) return;//û�� ����Ҫж��
        if (partMixSkin == null)
        {
            return;
        }
        var skeletonData = GetPartSkeletonData(dressPartType);
        if (skeletonData == null)
        {
            return;
        }
        // ��ȡĿ�겿λ��Ƥ��
        var partName = dressPartType.ToString().ToLower();
        Skin targetSkin = skeletonData.FindSkin(partName);
        if (targetSkin == null)
        {
            return;
        }
        partMixSkin.RemoveSkin(targetSkin, bodySkeletonAnimation.Skeleton.Data);
        // ����Ӧ��Ƥ��
        bodySkeletonAnimation.Skeleton.SetSkin(partMixSkin);
        bodySkeletonAnimation.Skeleton.SetSlotsToSetupPose();
        bodySkeletonAnimation.Skeleton.UpdateCache();
        partWearDic.Remove(dressPartType);//ж�²�λ����
    }

    /// <summary>
    /// �Ƴ����в�λ
    /// </summary>
    public void RemoveAllPart()
    {

    }


    /// <summary>
    /// �ı䲥���ٶ�
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
    /// ��ͣ����
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
    /// ��������
    /// </summary>
    public void Resume()
    {
        if (bodySkeletonAnimation != null)
        {
            bodySkeletonAnimation.timeScale = lastTimeScale;
        }
    }

}
