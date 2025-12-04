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
/// 面板基类 (常驻界面(主界面)、全屏界面这种需要继承BaseView) 
/// </summary>
public class BaseView : BasePanel
{
    public override bool IsShowOrHideMainUI { get; set; } = true;
}
