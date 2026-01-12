using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractPayWindow : BaseWindow
{
    private fun_Recharge.contractPayWindow view;

    public ContractPayWindow()
    {
        packageName = "fun_Recharge";
        // 设置委托
        BindAllDelegate = fun_Recharge.fun_RechargeBinder.BindAll;
        ClickBlankClose = true;
        CreateInstanceDelegate = fun_Recharge.contractPayWindow.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        view = ui as fun_Recharge.contractPayWindow;
        SetBg(view.bg, "Recharge/ELIDA_heyue_diban.png");
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

