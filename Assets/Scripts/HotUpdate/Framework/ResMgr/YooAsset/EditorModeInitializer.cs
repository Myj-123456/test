using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YooAsset;

/// <summary>
/// ±à¼­Æ÷Ä£Ê½
/// </summary>
public class EditorModeInitializer : BaseModeInitializer
{
    public override InitializeParameters Initialize()
    {
        var buildResult = EditorSimulateModeHelper.SimulateBuild("DefaultPackage");
        var packageRoot = buildResult.PackageRootDirectory;
        var createParameters = new EditorSimulateModeParameters();
        createParameters.EditorFileSystemParameters = FileSystemParameters.CreateDefaultEditorFileSystemParameters(packageRoot);
        return createParameters;
    }
}
