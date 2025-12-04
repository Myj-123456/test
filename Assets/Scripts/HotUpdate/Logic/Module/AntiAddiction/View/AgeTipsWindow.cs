using ADK;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class AgeTipsWindow : BaseWindow
{
    private fun_AntiAddiction.AgeTipsWindow viewSkin;

    public AgeTipsWindow()
    {
        packageName = "fun_AntiAddiction";
        // 设置委托
        BindAllDelegate = fun_AntiAddiction.fun_AntiAddictionBinder.BindAll;
        CreateInstanceDelegate = fun_AntiAddiction.AgeTipsWindow.CreateInstance;
    }
    public override void OnInit()
    {
        base.OnInit();
        viewSkin = ui as fun_AntiAddiction.AgeTipsWindow;
        SetBg(viewSkin.bg, "Common/ELIDA_common_bigdi01.png");
        viewSkin.txtMsg.text = Lang.GetValue("text_fang_tips9");
    }
}
