using ADK;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class AntiAddictionWindow : BaseWindow
{
    private fun_AntiAddiction.AntiAddictionWindow viewSkin;

    public AntiAddictionWindow()
    {
        packageName = "fun_AntiAddiction";
        // 设置委托
        BindAllDelegate = fun_AntiAddiction.fun_AntiAddictionBinder.BindAll;
        CreateInstanceDelegate = fun_AntiAddiction.AntiAddictionWindow.CreateInstance;
    }
    public override void OnInit()
    {
        base.OnInit();
        viewSkin = ui as fun_AntiAddiction.AntiAddictionWindow;
        SetBg(viewSkin.bg,"Common/ELIDA_common_bigdi01.png");
        viewSkin.txtMsg.text = Lang.GetValue("text_fang_tips5");
    }
}
