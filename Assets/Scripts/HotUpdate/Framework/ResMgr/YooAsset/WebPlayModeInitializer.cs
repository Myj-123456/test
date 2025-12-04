using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YooAsset;

/// <summary>
/// WebGL运行模式
/// </summary>
public class WebPlayModeInitializer : BaseModeInitializer
{
    public override InitializeParameters Initialize()
    {
        var createParameters = new WebPlayModeParameters();
        createParameters.BundleLoadingMaxConcurrency = 10;

#if UNITY_WEBGL && WEIXINMINIGAME&& !UNITY_EDITOR
        string defaultHostServer = GetHostServerURL();
        string fallbackHostServer = GetHostServerURL();
        string packageRoot = $"{WeChatWASM.WX.env.USER_DATA_PATH}/__GAME_FILE_CACHE"; //注意：如果有子目录，请修改此处！
        IRemoteServices remoteServices = new RemoteServices(defaultHostServer, fallbackHostServer);
        createParameters.WebServerFileSystemParameters = WechatFileSystemCreater.CreateFileSystemParameters(packageRoot,remoteServices);
#else
        createParameters.WebServerFileSystemParameters = FileSystemParameters.CreateDefaultWebServerFileSystemParameters();
#endif
        return createParameters;
    }
}
