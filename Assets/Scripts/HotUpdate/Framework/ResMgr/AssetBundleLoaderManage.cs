
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using YooAsset;
#if UNITY_WEBGL && WEIXINMINIGAME && !UNITY_EDITOR
using WeChatWASM;
#endif

public struct ABCallBackData
{
    public string AssetPath;
    public Object AssetObject;
}

/// <summary>
/// 仅用于动态图片的快速加载 其他一律禁止使用！！！
/// </summary>
public class AssetBundleLoaderManage : Singleton<AssetBundleLoaderManage>
{
    /// <summary>
    /// 缓存加载的AssetBundle，防止多次加载
    /// </summary>
    private Dictionary<string, AssetBundle> m_abDic = new Dictionary<string, AssetBundle>();

    private void GetAssetBundle(string url, UnityAction<AssetBundle> callback = null)
    {
        if (m_abDic.ContainsKey(url))
        {
            return;
        }
        ADK.Coroutiner.StartCoroutine(LoadFromFile(url, callback));
    }
    private IEnumerator LoadFromFile(string url, UnityAction<AssetBundle> callback = null)
    {
        if (m_abDic.ContainsKey(url))
        {
            yield break;
        }
#if UNITY_WEBGL && WEIXINMINIGAME && !UNITY_EDITOR
        UnityWebRequest bundleReq = WXAssetBundle.GetAssetBundle(url) /*WXAssetBundle.GetAssetBundle(url)*/; // UnityWebRequestAssetBundle => WXAssetBundle
#else
        UnityWebRequest bundleReq = UnityWebRequestAssetBundle.GetAssetBundle(url) /*WXAssetBundle.GetAssetBundle(url)*/; // UnityWebRequestAssetBundle => WXAssetBundle
#endif
        yield return bundleReq.SendWebRequest();
        if (bundleReq.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(GetType() + "/ERROR/" + bundleReq.error);
        }
        else
        {
            if (m_abDic.ContainsKey(url))
            {
                yield break;
            }
#if UNITY_WEBGL && WEIXINMINIGAME && !UNITY_EDITOR
            AssetBundle bundle = (bundleReq.downloadHandler as DownloadHandlerWXAssetBundle).assetBundle; // DownloadHandlerAssetBundle => DownloadHandlerWXAssetBundle
#else
            AssetBundle bundle = (bundleReq.downloadHandler as DownloadHandlerAssetBundle).assetBundle; // DownloadHandlerAssetBundle => DownloadHandlerWXAssetBundle
#endif
            callback?.Invoke(bundle);
            //bundle.WXUnload(false); //bundle还是AssetBundle类型，但需要调用扩展方法WXUnload()才可真正卸载
        }
        bundleReq.Dispose();
    }


    private Dictionary<string, Queue<UnityAction<AssetBundle>>> loadCallQueue = new Dictionary<string, Queue<UnityAction<AssetBundle>>>();
    /// <summary>
    /// 加载AssetBundle
    /// </summary>
    /// <param name="abName">AssetBundle名称</param>
    /// <returns></returns>
    public void LoadAssetBundle(string abName, UnityAction<AssetBundle> callback = null)
    {
        string abResPath = "";
        if (ResourceManager.Instance.playMode == EPlayMode.WebPlayMode)
        {
#if WEIXINMINIGAME
            abResPath = Path.Combine(Config.cdnResPath + "/qmhj/wxRL/" + Config.appVer + "/StreamingAssets/yoo/DefaultPackage", abName);
#else
            abResPath = Path.Combine(Application.streamingAssetsPath + "/yoo/DefaultPackage", abName);
#endif
        }
        else if (ResourceManager.Instance.playMode == EPlayMode.OfflinePlayMode)
        {
            abResPath = Path.Combine(Application.streamingAssetsPath + "/yoo/DefaultPackage", abName);
            // 在iOS上，对于StreamingAssets中的文件，需要使用file://协议
#if UNITY_IOS && !UNITY_EDITOR
            if (!abResPath.Contains("://"))
            {
                abResPath = "file://" + abResPath;
            }
#endif
        }
        if (!m_abDic.ContainsKey(abResPath))
        {
            //这里保证加载一个同类型的就行
            Queue<UnityAction<AssetBundle>> queue;
            if (!loadCallQueue.TryGetValue(abName, out queue))
            {
                queue = new Queue<UnityAction<AssetBundle>>();
                loadCallQueue.Add(abName, queue);

                //同名ab加载一次就行了
                GetAssetBundle(abResPath, (assetBundle) =>
                {
                    if (m_abDic.ContainsKey(abResPath))
                    {
                        return;
                    }
                    m_abDic[abResPath] = assetBundle;

                    //加载完毕同名之后 把同名队列的全部都回调出去
                    var queue2 = loadCallQueue[abName];
                    foreach (var q in queue2)
                    {
                        q?.Invoke(assetBundle);
                    }
                    loadCallQueue.Remove(abName);//移除队列
                });
            }
            queue.Enqueue(callback);
        }
        else
        {
            AssetBundle ab = m_abDic[abResPath];
            callback?.Invoke(ab);
        }
    }

    public void Unload(string resName)
    {
        if (ResourceManager.Instance.playMode == EPlayMode.EditorSimulateMode)
        {
            return;
        }
        var abName = ResourceManager.Instance.GetABNameByRes<Texture2D>(resName);//通过文件映射获取ABName
        if (ResourceManager.Instance.playMode == EPlayMode.WebPlayMode)
        {
            abName = Path.Combine(Config.cdnResPath + "/qmhj/wxRL/" + Config.appVer + "/StreamingAssets/yoo/DefaultPackage", abName);
        }
        else if (ResourceManager.Instance.playMode == EPlayMode.OfflinePlayMode)
        {
            abName = Path.Combine(Application.streamingAssetsPath + "/yoo/DefaultPackage", abName);
            // 在iOS上，对于StreamingAssets中的文件，需要使用file://协议
#if UNITY_IOS && !UNITY_EDITOR
            if (!abResPath.Contains("://"))
            {
                abName = "file://" + abName;
            }
#endif
        }
        if (m_abDic.ContainsKey(abName))
        {
            AssetBundle ab = m_abDic[abName];
#if UNITY_WEBGL && WEIXINMINIGAME && !UNITY_EDITOR
            ab.WXUnload(true);
#else
            ab.Unload(true);
#endif
            m_abDic.Remove(abName);
        }
    }

    /// <summary>
    /// 从AssetBundle中加载Asset
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <param name="abName">AssetBundle名</param>
    /// <param name="assetName">Asset名</param>
    /// <returns></returns>
    public void LoadAsset<T>(string assetName, UnityAction<ABCallBackData> callback = null) where T : UnityEngine.Object
    {
        if (ResourceManager.Instance.playMode == EPlayMode.EditorSimulateMode)
        {
#if UNITY_EDITOR
            var texture = UnityEditor.AssetDatabase.LoadAssetAtPath<Texture2D>(assetName);
            var loadABCallData = new ABCallBackData() { AssetPath = assetName, AssetObject = texture };
            callback?.Invoke(loadABCallData);
#endif
        }
        else
        {
            var abName = ResourceManager.Instance.GetABNameByRes<T>(assetName);//通过文件映射获取ABName
            if (!string.IsNullOrEmpty(abName))
            {
                LoadAssetBundle(abName, (assetBundle) =>
                {
                    AssetBundle ab = assetBundle;
                    T t = ab.LoadAsset<T>(assetName.ToLower());//转成小写去获取资源
                    var loadABCallData = new ABCallBackData() { AssetPath = assetName, AssetObject = t };
                    callback?.Invoke(loadABCallData);
                });
            }
        }
    }
    /// <summary>
    /// 从AssetBundle中加载所有Asset
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <param name="abName">AssetBundle名</param>
    /// <param name="assetName">Asset名</param>
    /// <returns></returns>
    public void LoadAllAssets<T>(string assetName, UnityAction<T[]> callback = null) where T : UnityEngine.Object
    {
        var abName = ResourceManager.Instance.GetABNameByRes<T>(assetName);//通过文件映射获取ABName
        if (!string.IsNullOrEmpty(abName))
        {
            LoadAssetBundle(abName, (assetBundle) =>
            {
                AssetBundle ab = assetBundle;
                T[] t = ab.LoadAllAssets<T>();
                callback?.Invoke(t);
            });
        }
    }
}

