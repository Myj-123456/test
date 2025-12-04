using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YooAsset;

/// <summary>
/// 单机运行模式
/// </summary>
public class OfflineModePlayInitializer : BaseModeInitializer
{
    public override InitializeParameters Initialize()
    {
        var createParameters = new OfflinePlayModeParameters();
        createParameters.BuildinFileSystemParameters = FileSystemParameters.CreateDefaultBuildinFileSystemParameters();
        return createParameters;
    }
}
