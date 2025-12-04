using System.Collections;
using UnityEngine;
using YooAsset;

public class Boot : MonoBehaviour
{

    [SerializeField]
    private EPlayMode playMode = EPlayMode.EditorSimulateMode;
    [SerializeField]
    private LoadingView loadingView;

    IEnumerator Start()
    {
        Application.targetFrameRate = 60;
        Application.runInBackground = true;
#if UNITY_WEBGL && !UNITY_EDITOR && !WEIXINMINIGAME//网页端
        Config.isShowLoginView = true;
#endif
        LoadingView.instance = loadingView;
        loadingView.loadingFinish = OnLoadingFinish;
        if (Config.isShowLoginView)
        {
            yield return InitFrameWork();
            UIManager.Instance.OpenPanel<LoginView>(UIName.LoginView);
        }
        else
        {
            loadingView.gameObject.SetActive(true);
            yield return InitFrameWork();
            StartCoroutine(PreLoadManager.Instance.StartPreLoad());//开始预加载资源
        }
    }
    /// <summary>
    /// 初始化资源加载模式
    /// </summary>
    /// <returns></returns>
    private EPlayMode InitPlayMode()
    {
#if UNITY_EDITOR
        return playMode;
#elif UNITY_WEBGL
        return EPlayMode.WebPlayMode;
#elif UNITY_ANDROID || UNITY_IOS
        return EPlayMode.OfflinePlayMode;
#endif
    }
    //<summary>
    /// 框架初始化
    /// </summary>
    IEnumerator InitFrameWork()
    {
        playMode = InitPlayMode();
        yield return ResourceManager.Instance.Initialize(playMode);
    }

    /// <summary>
    /// 资源预加载完毕
    /// </summary>
    private void OnLoadingFinish()
    {
        StartCoroutine(PreParseConfig());
    }

    private IEnumerator PreParseConfig()
    {
        yield return ConfigManager.Instance.PreParseConfig();
        Debug.Log("配置预解析完毕");
        LoginController.Instance.StartLogin();//开始请求登录
    }
}

