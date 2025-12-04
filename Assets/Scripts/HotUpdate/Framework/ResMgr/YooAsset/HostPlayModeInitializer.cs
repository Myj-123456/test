using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YooAsset;

/// <summary>
/// 联机运行模式
/// </summary>
public class HostPlayModeInitializer : BaseModeInitializer
{
    public override InitializeParameters Initialize()
    {
        string defaultHostServer = GetHostServerURL();
        string fallbackHostServer = GetHostServerURL();
        IRemoteServices remoteServices = new RemoteServices(defaultHostServer, fallbackHostServer);
        var createParameters = new HostPlayModeParameters();
        createParameters.BuildinFileSystemParameters = FileSystemParameters.CreateDefaultBuildinFileSystemParameters();
        createParameters.CacheFileSystemParameters = FileSystemParameters.CreateDefaultCacheFileSystemParameters(remoteServices);
        return createParameters;
    }
}
