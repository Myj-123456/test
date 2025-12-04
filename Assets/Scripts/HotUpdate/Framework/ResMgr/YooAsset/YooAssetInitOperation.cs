
using ADK;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YooAsset;

/// <summary>
/// YooAsset初始化
/// </summary>
public class YooAssetInitOperation : GameAsyncOperation
{
    private ResourcePackage package;

    public ResourcePackage Package
    {
        get { return package; }
    }

    public YooAssetInitOperation(EPlayMode playMode)
    {
        // 初始化资源系统
        YooAssets.Initialize();
        // 创建默认的资源包
        package = YooAssets.CreatePackage("DefaultPackage");
        // 设置该资源包为默认的资源包，可以使用YooAssets相关加载接口加载该资源包内容。
        YooAssets.SetDefaultPackage(package);
        Coroutiner.StartCoroutine(InitPackage(package, playMode));
    }

    private IEnumerator InitPackage(ResourcePackage package, EPlayMode playMode)
    {
        var initializer = GetInitializer(playMode);
        if (initializer != null)
        {
            yield return package.InitializeAsync(initializer.Initialize());
            var operation = package.RequestPackageVersionAsync();
            yield return operation;
            yield return package.UpdatePackageManifestAsync(operation.PackageVersion);
            Status = EOperationStatus.Succeed;
        }
    }

    private BaseModeInitializer GetInitializer(EPlayMode PlayMode)
    {
        BaseModeInitializer baseModeInitializer = null;
        switch (PlayMode)
        {
            case EPlayMode.EditorSimulateMode:
                baseModeInitializer = new EditorModeInitializer();
                break;
            case EPlayMode.OfflinePlayMode:
                baseModeInitializer = new OfflineModePlayInitializer();
                break;
            case EPlayMode.HostPlayMode:
                baseModeInitializer = new HostPlayModeInitializer();
                break;
            case EPlayMode.WebPlayMode:
                baseModeInitializer = new WebPlayModeInitializer();
                break;
        }
        return baseModeInitializer;
    }

    protected override void OnStart() { }
    protected override void OnUpdate() { }
    protected override void OnAbort() { }
}

