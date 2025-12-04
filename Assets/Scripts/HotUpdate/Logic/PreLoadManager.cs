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
    public bool IsLoadResFinish = false;//是否预加载资源完毕
    public bool startLoad = false;//是否开始预加载资源
    public IEnumerator StartPreLoad()
    {
        startLoad = true;
        IsLoadResFinish = false;
        yield return LoadPackages();
        yield return InitConfig();
        yield return InitSceneMap();
        Debug.Log("预加载完毕");
        IsLoadResFinish = true;
    }

    /// <summary>
    /// 初始化场景地图
    /// </summary>
    /// <returns></returns>
    public IEnumerator InitSceneMap()
    {
        ShowLoadingDes("加载地图");
        var location = ResPath.GetMapTrunkPath("map_0");  // 注意：location只需要填写资源包里的任意资源地址。
        var handle = ResourceManager.Instance.LoadAllAssetsAsync<Sprite>(location);
        yield return handle;
        handle.Release();
    }

    /// <summary>
    /// 初始化配置
    /// </summary>
    /// <returns></returns>
    public IEnumerator InitConfig()
    {
        ShowLoadingDes("加载配置");
        var location = ResPath.GetConfigByName("module_item_defsConfig");  // 注意：location只需要填写资源包里的任意资源地址。
        var handle = ResourceManager.Instance.LoadAllAssetsAsync<UnityEngine.TextAsset>(location);
        yield return handle;
        handle.Release();
    }

    private IEnumerator LoadPackages()
    {
        ShowLoadingDes("加载ui");
        var loadPackageNames = new List<string>() { "common", "common_New", "fun_MainUI", "fun_Scene", "fun_Battle", "NoCompress" };
        int packagesLoaded = 0;
        int totalPackages = loadPackageNames.Count;

        foreach (var packageName in loadPackageNames)
        {
            LoadPackage(packageName, () =>
            {
                packagesLoaded++;
                Debug.Log($"包 {packageName} 加载完成 ({packagesLoaded}/{totalPackages})");
            });
        }

        // 等待所有包加载完成
        yield return new WaitUntil(() => packagesLoaded >= totalPackages);

        // 绑定所有包
        common.commonBinder.BindAll();
        common_New.common_NewBinder.BindAll();
        fun_MainUI.fun_MainUIBinder.BindAll();
        fun_Scene.fun_SceneBinder.BindAll();
        fun_Battle.fun_BattleBinder.BindAll();

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
                    method = DestroyMethod.None; // 注意：这里一定要设置为 None
                    return pngAsset;
                });
            }

            handle.Release();
            onComplete?.Invoke(); // 通知完成
        };
    }

    /// <summary>
    /// 初始化 FairyGUI(暂时给提审版本使用)
    /// </summary>
    /// <returns></returns>
    public IEnumerator InitAuditVersionFairyGui()
    {
        // 初始化需要加载的包
        yield return LoadAndBindPackage("common_New", common_New.common_NewBinder.BindAll);
        UIObjectFactory.SetLoaderExtension(typeof(MyGLoader));
    }

    /// <summary>
    /// 加载并绑定 FairyGUI 包
    /// </summary>
    /// <param name="packageName">包名称</param>
    /// <param name="bindMethod">绑定方法</param>
    /// <returns></returns>
    private IEnumerator LoadAndBindPackage(string packageName, System.Action bindMethod)
    {
        // 加载 bytes 文件
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
                method = DestroyMethod.None; // 注意：这里一定要设置为 None
                return pngAsset;
            });
            // 绑定
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
