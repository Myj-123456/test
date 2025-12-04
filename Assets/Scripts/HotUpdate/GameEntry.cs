using ADK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YooAsset;
using UnityWebSocket;
using System;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using FairyGUI;
using Spine.Unity;

public class GameEntry : MonoBehaviour
{

    void Start()
    {
        OnInitData();
        ShowMainUI();
        GuideController.Instance.CheckMainTaskShowWeakGuide();//检测主线任务引导
        StartCoroutine(PlayBgMusic());
        StartCoroutine(OnDelaySilentLoadRes());
    }

    //进入游戏主场景前必须需要初始化的数据,一般是一些进来主场景必须马上用到的数据
    private void OnInitData()
    {
        IkeModel.Instance.initData();
    }

    ////进入游戏主场后前延迟初始化的数据(一般是一些不立马使用的数据)
    ////InitSeedCropVOList后面需要再初始化其他数据 需要用  yield return null 分帧之后再调用数据初始化
    //private IEnumerator OnDelayInitData()
    //{
    //    yield return new WaitForSeconds(1f);
    //    //PlantModel.Instance.InitSeedCropVOList();
    //    yield return null;//分帧之后再调用其他数据初始化
    //}

    /// <summary>
    /// 需要延迟静默加载的资源
    /// </summary>
    /// <returns></returns>
    private IEnumerator OnDelaySilentLoadRes()
    {
        yield return new WaitForSeconds(5f);
        LoadDynamicUIs();
    }

    //预加载动态加载的ui
    private void LoadDynamicUIs()
    {
        LoadDynamicBGUI("Common/ELIDA_common_littledi01.png");
    }

    /// <summary>
    /// 加载动态背景
    /// </summary>
    /// <param name="imageUrl"></param>
    private void LoadDynamicBGUI(string imageUrl)
    {
        var url = ResPath.GetDynamicUIPath(imageUrl);
        AssetBundleLoaderManage.Instance.LoadAsset<Texture2D>(url);
    }

    /// <summary
    /// <summary>
    /// 显示主UI
    /// </summary>
    void ShowMainUI()
    {
        UIManager.Instance.OpenPanel<MainView>(UIName.MainView, UILayer.MainUI);
    }

    /// <summary>
    /// 进入播放背景音乐
    /// </summary>
    private IEnumerator PlayBgMusic()
    {
        if (MyselfModel.Instance.isFirstEnterGame)
        {
            MyselfModel.Instance.isFirstEnterGame = false;
            yield return new WaitForSeconds(1f);
            SoundManager.Instance.PlayMusic("bgm");
        }
    }
}
