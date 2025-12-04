using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YooAsset;

public class MyGLoader : GLoader
{
    private Dictionary<string, AssetHandle> assetHandles = new Dictionary<string, AssetHandle>();
    override protected void LoadExternal()
    {
        var dynamicuiUrl = ResPath.GetDynamicUIPath(url);
        SetUrl(dynamicuiUrl);

        AssetHandle assetHandle = ResourceManager.Instance.LoadAssetAsync<Texture2D>(dynamicuiUrl);
        assetHandle.Completed += OnLoadSuccess;

        var key = id + "_" + dynamicuiUrl;
        if (!assetHandles.ContainsKey(key))
        {
            assetHandles.Add(key, assetHandle);
        }
    }

    private void OnLoadSuccess(AssetHandle handle)
    {
        if (handle.GetAssetInfo().AssetPath != loaderUrl)//url不一致return掉
        {
            return;
        }
        if (handle.Status == EOperationStatus.Succeed)
        {
            var texture = handle.AssetObject as Texture2D;
            onExternalLoadSuccess(new NTexture(texture));
        }
        else if (handle.Status == EOperationStatus.Failed)
        {
            onExternalLoadFailed();
        }
    }

    override protected void FreeExternal(NTexture texture)
    {
        //释放外部载入的资源
    }

    public override void Destroy()
    {
        base.Destroy();
        
        if (assetHandles.Count > 0)
        {
            foreach (var assetHandle in assetHandles)
            {
                assetHandle.Value.Release();
                ResourceManager.Instance.TryUnloadUnusedAsset(assetHandle.Value.GetAssetInfo().AssetPath);
            }
            assetHandles.Clear();
        }
    }
}
