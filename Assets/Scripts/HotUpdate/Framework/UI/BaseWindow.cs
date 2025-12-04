using ADK;
using FairyGUI;
using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
#if WEIXINMINIGAME
using WeChatWASM;
#endif
using YooAsset;
/// <summary>
/// 窗口基类(非全屏界面、弹框这种需要继承BaseWindow) 
/// </summary>
public class BaseWindow : BasePanel
{
    public bool openWithTween = true;
    public bool showModal = true;
    public bool ClickBlankClose = false;//是否点击空白处关闭界面(需设置穿透)
    public bool FullScreen = false;//需要设置为全屏适配的window
    public override bool IsShowOrHideMainUI { get; set; } = false;
}
