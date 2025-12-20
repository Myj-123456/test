using FairyGUI;
using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YooAsset;
/// <summary>
/// 资源预加载管理器
/// </summary>
public class PreLoadManager : Singleton<PreLoadManager>
{
    public bool IsLoadResFinish = false;//是否加载完成资源
    public bool startLoad = false;//是否开始加载资源
    public IEnumerator StartPreLoad()
    {
        startLoad = true;
        IsLoadResFinish = false;
        yield return LoadPackages();
        yield return InitConfig();
        yield return InitSceneMap();
        Debug.Log("资源预加载完成");
        IsLoadResFinish = true;
    }

    /// <summary>
    /// 初始化场景地图
    /// </summary>
    /// <returns></returns>
    public IEnumerator InitSceneMap()
    {
        ShowLoadingDes("加载场景地图");
        var location = ResPath.GetMapTrunkPath("map_0");  // 注意：location只需要提供资源路径，不需要包含资源类型
        var handle = ResourceManager.Instance.LoadAllAssetsAsync<Sprite>(location);
        yield return handle;
        handle.Release();
    }

    /// <summary>
    /// 初始化配置文件
    /// </summary>
    /// <returns></returns>
    public IEnumerator InitConfig()
    {
        ShowLoadingDes("加载配置文件");
        var location = ResPath.GetConfigByName("module_item_defsConfig");  // 注意：location只需要提供资源路径，不需要包含资源类型 
        var handle = ResourceManager.Instance.LoadAllAssetsAsync<UnityEngine.TextAsset>(location);
        yield return handle;
        handle.Release();
    }

    private IEnumerator LoadPackages()
    {
        ShowLoadingDes("加载UI资源");
        var loadPackageNames = new List<string>() { "common", "common_New", "fun_MainUI", "fun_Scene", "fun_Battle", "fun_Rob", "NoCompress" };
        int packagesLoaded = 0;
        int totalPackages = loadPackageNames.Count;

        foreach (var packageName in loadPackageNames)
        {
            LoadPackage(packageName, () =>
            {
                packagesLoaded++;
                Debug.Log($"加载完成 {packageName} ({packagesLoaded}/{totalPackages})");
            });
        }

        // 等待所有资源包加载完成
        yield return new WaitUntil(() => packagesLoaded >= totalPackages);

        // 绑定所有资源
        common.commonBinder.BindAll();
        common_New.common_NewBinder.BindAll();
        fun_MainUI.fun_MainUIBinder.BindAll();
        fun_Scene.fun_SceneBinder.BindAll();
        fun_Battle.fun_BattleBinder.BindAll();
        fun_Rob.fun_RobBinder.BindAll();

        UIConfig.globalModalWaiting = common.window_modal.URL;
        UIObjectFactory.SetLoaderExtension(typeof(MyGLoader));
        UIObjectFactory.SetLoader3DExtension(typeof(MyGLoader3D));
    }

    private void LoadPackage(string packageName, Action onComplete)
    {
        AllAssetsHandle assetHandle = ResourceManager.Instance.LoadAllAssetsAsync(ResPath.GetFuiBytes(packageName));
        assetHandle.Completed += (handle) =>
        {
            TextAsset textAsset = null;
            Texture2D pngAsset = null;

            foreach (var assetObj in handle.AllAssetObjects)
            {
                if (assetObj is TextAsset) textAsset = assetObj as TextAsset;
                else if (assetObj is Texture2D) pngAsset = assetObj as Texture2D;
            }

            if (textAsset != null)
            {
                // 添加到 UIPackage
                UIPackage.AddPackage(textAsset.bytes, packageName, (string name, string extension, System.Type type, out DestroyMethod method) =>
                {
                    method = DestroyMethod.None; // 注意：必须设置为 None，否则会导致内存泄漏
                    return pngAsset;
                });
            }

            handle.Release();
            onComplete?.Invoke(); // 通知加载完成
        };
    }

    /// <summary>
    /// 初始化 FairyGUI(旧版本需要使用)
    /// </summary>
    /// <returns></returns>
    public IEnumerator InitAuditVersionFairyGui()
    {
        // 加载并绑定 common_New 资源包
        yield return LoadAndBindPackage("common_New", common_New.common_NewBinder.BindAll);
        UIObjectFactory.SetLoaderExtension(typeof(MyGLoader));
    }

    /// <summary>
    /// 加载并绑定 FairyGUI 资源包      
    /// </summary>
    /// <param name="packageName">资源包名称</param>
    /// <param name="bindMethod">绑定方法</param>
    /// <returns></returns>
    private IEnumerator LoadAndBindPackage(string packageName, System.Action bindMethod)
    {
        // 加载资源包
        AllAssetsHandle assetHandle = ResourceManager.Instance.LoadAllAssetsAsync(ResPath.GetFuiBytes(packageName));
        yield return assetHandle;

        TextAsset textAsset = null;
        Texture2D pngAsset = null;
        foreach (var assetObj in assetHandle.AllAssetObjects)
        {
            if (assetObj is TextAsset)
            {
                textAsset = assetObj as TextAsset;
            }
            else if (assetObj is Texture2D)
            {
                pngAsset = assetObj as Texture2D;
            }
        }

        if (textAsset != null)
        {
            // 添加到 UIPackage
            UIPackage.AddPackage(textAsset.bytes, packageName, (string name, string extension, System.Type type, out DestroyMethod method) =>
            {
                method = DestroyMethod.None; // 注意：必须设置为 None，否则会导致内存泄漏
                return pngAsset;
            });
            // 绑定资源
            bindMethod?.Invoke();
        }
        assetHandle.Release();
    }
    public void ShowLoadingDes(string loadingDes)
    {
        LoadingView.instance.ShowLoadingDes(loadingDes);
    }

    public void ShowLoadingView()
    {
        LoadingView.instance.gameObject.SetActive(true);
    }
}
