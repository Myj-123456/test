
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using YooAsset;

/// <summary>
/// 资源管理器
/// </summary>
public class ResourceManager : Singleton<ResourceManager>
{
    public EPlayMode playMode;
    private ResourcePackage package = null;

    /// <summary>
    /// 初始化资源管理器
    /// </summary>
    /// <param name="_package">资源包</param>
    public IEnumerator Initialize(EPlayMode playMode)
    {
        this.playMode = playMode;
        YooAssetInitOperation operation = new YooAssetInitOperation(playMode);
        YooAssets.StartOperation(operation);
        yield return operation;
        package = operation.Package;
    }

    /// <summary>
    /// 同步加载场景
    /// </summary>
    /// <param name="location"></param>
    /// <param name="sceneMode"></param>
    /// <param name="physicsMode"></param>
    /// <returns></returns>
    public SceneHandle LoadSceneSync(string location, LoadSceneMode sceneMode = LoadSceneMode.Single, LocalPhysicsMode physicsMode = LocalPhysicsMode.None)
    {
        return package.LoadSceneAsync(location, sceneMode, physicsMode);
    }

    /// <summary>
    /// 异步加载场景
    /// </summary>
    /// <param name="location"></param>
    /// <param name="sceneMode"></param>
    /// <param name="physicsMode"></param>
    /// <param name="suspendLoad"></param>
    /// <param name="priority"></param>
    /// <returns></returns>
    public SceneHandle LoadSceneAsync(string location, LoadSceneMode sceneMode = LoadSceneMode.Single, LocalPhysicsMode physicsMode = LocalPhysicsMode.None, bool suspendLoad = false, uint priority = 0)
    {
        return package.LoadSceneAsync(location, sceneMode, physicsMode, suspendLoad, priority);
    }

    /// <summary>
    /// 同步加载资源对象
    /// </summary>
    /// <param name="location"></param>
    /// <returns></returns>
    public AssetHandle LoadAssetSync(string location)
    {
        return package.LoadAssetSync(location);
    }

    /// <summary>
    /// 同步加载资源对象
    /// </summary>
    /// <param name="location"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public AssetHandle LoadAssetSync(string location, Type type)
    {
        return package.LoadAssetSync(location, type);
    }

    /// <summary>
    /// 同步加载资源对象
    /// </summary>
    /// <typeparam name="TObject"></typeparam>
    /// <param name="location"></param>
    /// <returns></returns>
    public AssetHandle LoadAssetSync<TObject>(string location) where TObject : UnityEngine.Object
    {
        return package.LoadAssetSync<TObject>(location);
    }

    /// <summary>
    /// 异步加载资源对象
    /// </summary>
    /// <param name="location"></param>
    /// <param name="priority"></param>
    /// <returns></returns>
    public AssetHandle LoadAssetAsync(string location, uint priority = 0)
    {
        return package.LoadAssetAsync(location, priority);
    }

    /// <summary>
    /// 异步加载资源对象
    /// </summary>
    /// <param name="location"></param>
    /// <param name="type"></param>
    /// <param name="priority"></param>
    /// <returns></returns>
    public AssetHandle LoadAssetAsync(string location, Type type, uint priority = 0)
    {
        return package.LoadAssetAsync(location, type, priority);
    }

    /// <summary>
    /// 异步加载资源对象
    /// </summary>
    /// <param name="location"></param>
    /// <param name="type"></param>
    /// <param name="priority"></param>
    /// <returns></returns>
    public AssetHandle LoadAssetAsync<TObject>(string location, uint priority = 0) where TObject : UnityEngine.Object
    {
        return package.LoadAssetAsync<TObject>(location, priority);
    }
    /// <summary>
    /// 同步获取一个资源
    /// </summary>
    /// <typeparam name="TObject"></typeparam>
    /// <param name="location"></param>
    /// <returns></returns>
    public TObject GetAsset<TObject>(string location) where TObject : UnityEngine.Object
    {
        AssetHandle assetHandle = package.LoadAssetSync(location);
        return assetHandle.AssetObject as TObject;
    }

    public AssetInfo GetAssetInfo(string location)
    {
        return package.GetAssetInfo(location);
    }

    public void LoadSubAssetsSync()
    {

    }
    public void LoadSubAssetsAsync()
    {

    }
    public void LoadAllAssetsSync()
    {

    }
    public AllAssetsHandle LoadAllAssetsAsync<TObject>(string location, uint priority = 0) where TObject : UnityEngine.Object
    {
        return package.LoadAllAssetsAsync<TObject>(location);
    }

    public AllAssetsHandle LoadAllAssetsAsync(string location, uint priority = 0)
    {
        return package.LoadAllAssetsAsync(location);
    }

    public void LoadRawFileSync()
    {

    }
    public void LoadRawFileAsync()
    {

    }

    /// <summary>
    /// 检测某个资源地址是否有效 无效一般是不存在或者url写错了
    /// </summary>
    /// <param name="location"></param>
    /// <returns></returns>
    public bool CheckLocationValid(string location)
    {
        return package.CheckLocationValid(location);
    }

    /// <summary>
    /// 尝试卸载指定的资源对象
    /// </summary>
    /// <param name="location"></param>
    public void TryUnloadUnusedAsset(string location)
    {
        package.TryUnloadUnusedAsset(location);
    }

    /// <summary>
    /// 卸载所有引用计数为零的资源包。
    /// 可以在切换场景之后调用资源释放方法或者写定时器间隔时间去释放。
    /// </summary>
    public void UnloadUnusedAssetsAsync()
    {
        package.UnloadUnusedAssetsAsync();
    }
    public void UnloadAllAssetsAsync()
    {
        package.UnloadAllAssetsAsync();
    }

    /// <summary>
    /// 通过资源获取AB
    /// </summary>
    /// <typeparam name="TObject"></typeparam>
    /// <param name="location"></param>
    /// <returns></returns>
    public string GetABNameByRes<TObject>(string location) where TObject : UnityEngine.Object
    {
        return package.GetABNameByRes<TObject>(location);
    }
}

