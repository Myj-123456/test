using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using YooAsset;
using YooAsset.Editor;

/// <summary>
/// 构建工具
/// </summary>
public static class BuildTool
{

    private static string webglResServerDir;//webgl资源服务器

    [MenuItem("Build/Build_webgl")]
    public static void Editor_Build_Webgl()
    {
        string buildType = GetJenkinsParameter("buildType");
        webglResServerDir = GetJenkinsParameter("resServerDir");
        Debug.Log("buildType：" + buildType);
        Debug.Log("webglResServerDir：" + webglResServerDir);
        BuildWebGL(buildType);
    }

    /// <summary>
    /// 构建webgl(构建脚本+AB)
    /// </summary>
    private static void BuildWebGL(string buildType)
    {
        Debug.Log("BuildWebGL");
        if (buildType == "all")
        {
            BuildAB();
            BuildWebglScript();
        }
        else if (buildType == "res")
        {
            BuildAB();
        }
        else if (buildType == "script")
        {
            BuildWebglScript();
        }
    }

    /// <summary>
    /// 构建AB资源
    /// </summary>
    private static void BuildAB()
    {
        Debug.Log("BuildAB");
        BuildInternal(BuildTarget.WebGL);
    }

    private static void BuildInternal(BuildTarget buildTarget)
    {
        Debug.Log($"开始构建 : {buildTarget}");

        var buildoutputRoot = AssetBundleBuilderHelper.GetDefaultBuildOutputRoot();
        //var streamingAssetsRoot = AssetBundleBuilderHelper.GetStreamingAssetsRoot();//除非是需要打内置包 否则不要拷贝到工程的streamingAsset目录
        var streamingAssetsRoot = webglResServerDir + "/StreamingAssets/yoo";//拷贝ab到资源服务器

        // 构建参数
        BuiltinBuildParameters buildParameters = new BuiltinBuildParameters();
        buildParameters.BuildOutputRoot = buildoutputRoot;
        buildParameters.BuildinFileRoot = streamingAssetsRoot;
        buildParameters.BuildPipeline = EBuildPipeline.BuiltinBuildPipeline.ToString();
        buildParameters.BuildBundleType = (int)EBuildBundleType.AssetBundle; //必须指定资源包类型
        buildParameters.BuildTarget = buildTarget;
        buildParameters.PackageName = "DefaultPackage";
        buildParameters.PackageVersion = ADK.TimeUtil.GetTimestamp().ToString();//先不指定版本号 后面需要配合构建工具传递版本参数进来 现在默认采取秒时间戳
        buildParameters.VerifyBuildingResult = true;
        buildParameters.EnableSharePackRule = true; //启用共享资源构建模式，兼容1.5x版本
        buildParameters.FileNameStyle = EFileNameStyle.BundleName_HashName;
        buildParameters.BuildinFileCopyOption = EBuildinFileCopyOption.ClearAndCopyAll;
        buildParameters.BuildinFileCopyParams = string.Empty;
        //buildParameters.EncryptionServices = CreateEncryptionInstance();
        buildParameters.CompressOption = ECompressOption.LZ4;
        buildParameters.ClearBuildCacheFiles = false; //不清理构建缓存，启用增量构建，可以提高打包速度！
        buildParameters.UseAssetDependencyDB = true; //使用资源依赖关系数据库，可以提高打包速度！

        // 执行构建
        BuiltinBuildPipeline pipeline = new BuiltinBuildPipeline();
        var buildResult = pipeline.Run(buildParameters, true);
        if (buildResult.Success)
        {
            Debug.Log($"构建成功 : {buildResult.OutputPackageDirectory}");
        }
        else
        {
            Debug.LogError($"构建失败 : {buildResult.ErrorInfo}");
        }
    }

    /// <summary>
    //从构建命令里获取参数示例
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private static string GetJenkinsParameter(string name)
    {
        string[] args = Environment.GetCommandLineArgs();
        foreach (string arg in args)
        {
            if (arg.StartsWith(name + "="))
            {
                string[] parts = arg.Split('=');
                if (parts.Length >= 2)
                {
                    return parts[1];
                }
            }
        }
        return string.Empty;
    }


    /// <summary>
    /// 构建webgl脚本
    /// </summary>
    private static void BuildWebglScript()
    {
        Debug.Log("BuildWebglScript");
        RemoveDefineSymbol(BuildTargetGroup.WebGL, "WEIXINMINIGAME");
        // 执行构建
        BuildPlayerOptions options = new BuildPlayerOptions();
        options.scenes = GetBuildScenes();
        options.locationPathName = "Build/WebGl";
        options.target = BuildTarget.WebGL;
        options.options = BuildOptions.None;
        var buildReport = BuildPipeline.BuildPlayer(options);
        if (buildReport.summary.result == UnityEditor.Build.Reporting.BuildResult.Succeeded)
        {
            Debug.Log("WebGL-->Build Success!");
            EditorTools.CopyDirectory("Build/WebGl/Build", webglResServerDir+"/Build");
        }
        else
        {
            Debug.LogError("WebGL-->Build Error!! total errors:" + buildReport.summary.totalErrors);
            var index = 0;
            foreach (var errStep in buildReport.steps)
            {
                foreach (var errStepMessage in errStep.messages)
                {
                    if (errStepMessage.type == LogType.Error || errStepMessage.type == LogType.Exception)
                    {
                        Debug.LogError($"Build Error StepName:{errStep.name}, MessageIndex:{index},content:{errStepMessage.content}");
                        index++;
                    }
                }
            }
            throw new Exception("WebGL Build Error!!");
        }
    }
    /// <summary>
    /// 移除某个平台下某个宏定义
    /// </summary>
    /// <param name="platform"></param>
    /// <param name="symbolToRemove"></param>
    private static void RemoveDefineSymbol(BuildTargetGroup platform, string symbolToRemove)
    {
        // 获取当前宏定义
        string defines = PlayerSettings.GetScriptingDefineSymbolsForGroup(platform);
        List<string> defineList = new List<string>(defines.Split(';'));

        // 移除指定宏
        if (defineList.Contains(symbolToRemove))
        {
            defineList.Remove(symbolToRemove);
        }
        // 重新设置宏定义
        string newDefines = string.Join(";", defineList.ToArray());
        PlayerSettings.SetScriptingDefineSymbolsForGroup(platform, newDefines);
    }

    private static string[] GetBuildScenes()
    {
        List<string> scenes = new List<string>();
        foreach (var scene in EditorBuildSettings.scenes)
        {
            if (scene.enabled)
                scenes.Add(scene.path);
        }
        return scenes.ToArray();
    }
}
