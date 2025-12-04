using FairyGUI;
using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YooAsset;

public class MyGLoader3D : GLoader3D
{
    override protected void LoadExternal()
    {
        var spineUrl = ResPath.GetSpinePath(url);
        SetUrl(spineUrl);
        var assetHandle = ResourceManager.Instance.LoadAssetAsync<SkeletonDataAsset>(spineUrl);
        assetHandle.Completed += OnLoadSuccess;
    }

    private void OnLoadSuccess(AssetHandle handle)
    {
        if (handle.GetAssetInfo().AssetPath != loaderUrl)//url不一致return掉
        {
            return;
        }
        if (handle.Status == EOperationStatus.Succeed)
        {
            var skeletonDataAsset = handle.AssetObject as SkeletonDataAsset;
            SetSpine(skeletonDataAsset, (int)width, (int)height, Vector2.zero);
        }
        else if (handle.Status == EOperationStatus.Failed)
        {
        }

    }

    override protected void FreeExternal()
    {
        //释放外部载入的资源
        FreeSpine();
    }
}
