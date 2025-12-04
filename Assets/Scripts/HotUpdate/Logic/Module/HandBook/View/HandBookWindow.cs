
using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ADK;

public class HandBookWindow : BaseWindow
{
    private fun_CultivationManual.handbook_brandNew viewSkin;


    public HandBookWindow()
    {
        packageName = "fun_CultivationManual";
        // 设置委托
        BindAllDelegate = fun_CultivationManual.fun_CultivationManualBinder.BindAll;
        CreateInstanceDelegate = fun_CultivationManual.handbook_brandNew.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        viewSkin = ui as fun_CultivationManual.handbook_brandNew;
  


    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
       
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }

    
}

