using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using System;
using Spine.Unity;

public class LoadingView : MonoBehaviour
{
    [SerializeField]
    private UIPanel uiPannel;

    private float curLoad = 0;
    private float frameLoadStep = 0;
    private float total = 100;
    private float loadingWaitTotal = 80;
    private float loadingWaitTime = 1;
    private GProgressBar progressBar;
    private GLoader img_ageTips;
    public Action loadingFinish;
    private GTextField txt_des;
    private GTextField txt_progress;
    private GTextField txt_gameVer;
    private static LoadingView _instance;

    public static LoadingView instance
    {
        get { return _instance; }
        set { _instance = value; }
    }

    void Start()
    {
        progressBar = uiPannel.ui.GetChild("progressBar") as GProgressBar;
        img_ageTips = uiPannel.ui.GetChild("img_ageTips") as GLoader;
        txt_des = uiPannel.ui.GetChild("txt_des") as GTextField;
        txt_progress = uiPannel.ui.GetChild("txt_progress") as GTextField;
        frameLoadStep = loadingWaitTotal / (loadingWaitTime * Application.targetFrameRate);//按指定帧计算达到80%进度 计算出每帧需要走的加载步数
        txt_gameVer = uiPannel.ui.GetChild("txt_gameVer") as GTextField;
        txt_gameVer.text = "gameVer：" + Config.appVer;
    }

    void Update()
    {
        if (!PreLoadManager.Instance.startLoad) return;

        curLoad += frameLoadStep;
        if (!PreLoadManager.Instance.IsLoadResFinish)
        {
            if (curLoad >= loadingWaitTotal)
            {
                curLoad = loadingWaitTotal;
            }
        }
        else//预加载完毕马上加载下一波
        {
            if (loadingFinish != null)
            {
                loadingFinish.Invoke();
                loadingFinish = null;
            }
        }
        OnLoadingProgess(curLoad, total);
    }
    private void OnLoadingProgess(float currentDownloadCount, float totalDownloadCount)
    {
        var rate = (currentDownloadCount / totalDownloadCount) * 100;
        if (rate >= 100) rate = 100;
        progressBar.value = rate;
        txt_progress.text = Math.Floor(rate) + "%";
    }

    public void ShowLoadingDes(string loadingDes)
    {
        if (txt_des == null)
            txt_des = uiPannel.ui.GetChild("txt_des") as GTextField;
        txt_des.text = loadingDes;
    }
}
