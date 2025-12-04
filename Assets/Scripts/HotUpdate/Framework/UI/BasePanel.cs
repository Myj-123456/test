using ADK;
using FairyGUI;
using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using YooAsset;

/// <summary>
/// 面板类:BaseView和BaseWind基类
/// </summary>
public class BasePanel : BaseUI
{
    public string packageName; // 包名
    public string uiName;
    public bool isOpening = false;//正在打开中
    public bool isClosing = false;//正在关闭中
    public bool fairyBatching = false;//是否合批 一些子组件频繁变化的尽量不设置

    public GComponent ui;

    // 委托定义：用于绑定UI组件
    public Action BindAllDelegate { get; set; }

    // 委托定义：用于创建UI组件实例
    public Func<GComponent> CreateInstanceDelegate { get; set; }

    //public string preLoadBgUrl = "";//需要预载的背景图片url 一般默认只要预载大的背景图就行
    public AllAssetsHandle assetHandle;//资源加载器


    private bool _visible = false;
    public bool Visible
    {
        get { return _visible; }
        set
        {
            if (ui != null) ui.visible = value;
            _visible = value;
            if (value)
            {
                isClosing = false;
            }
            else
            {
                isOpening = false;
            }
        }
    }

    /// <summary>
    /// 打开关闭是否显示关闭主界面
    /// </summary>
    public virtual bool IsShowOrHideMainUI { get; set; } = false;

    /// <summary>
    /// 是否需要界面显示计算(一些常驻的全屏界面或者一些半交互的window这种需要设置为false) 这样子不算这个界面被打开 
    /// </summary>
    public virtual bool IsAddShowNum { get; set; } = true;


    /// <summary>
    /// 初始化(生命周期内只会调用一次)
    /// </summary>
    public virtual void OnInit()
    {
    }

    /// <summary>
    /// 打开界面
    /// </summary>
    public virtual void OnShown()
    {
    }

    /// <summary>
    /// 关闭界面
    /// </summary>
    public virtual void OnHide()
    {
        StopAllCoroutine();
        InitPopModel.Instance.AutoTipView();
    }

    /// <summary>
    /// 大背景必须使用这个方法加载(为了大背景的快速加载，单独走一个加载器) 其他禁止使用(其他的用url就行了)!!!
    /// </summary>
    /// <param name="url"></param>
    public void SetBg(GLoader gLoader, string url)
    {
        var dynamicuiUrl = ResPath.GetDynamicUIPath(url);
        AssetBundleLoaderManage.Instance.LoadAsset<Texture2D>(dynamicuiUrl, (ABCallBackData data) =>
        {
            if (data.AssetPath != dynamicuiUrl)//url不一致return掉
            {
                Debug.Log("url不一致return掉:" + data.AssetPath);
                return;
            }
            if (data.AssetObject != null)
            {
                gLoader.texture = new NTexture(data.AssetObject as Texture2D);
            }
            else
            {
                Debug.Log("SetBgUrl LoadFail :" + dynamicuiUrl);
            }
        });
    }

    /// <summary>
    ///内部关闭回调
    /// </summary>
    protected void Close(bool isImmediateClose = false)
    {
        if (this is BaseView)
        {
            UIManager.Instance.ClosePanel(uiName);
        }
        else if (this is BaseWindow)
        {
            UIManager.Instance.CloseWindow(uiName, isImmediateClose);
        }
    }

    protected void Close()
    {
        if (this is BaseView)
        {
            UIManager.Instance.ClosePanel(uiName);
        }
        else if (this is BaseWindow)
        {
            UIManager.Instance.CloseWindow(uiName);
        }
    }
}
