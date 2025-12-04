using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using System;

public class ConfirmWindow : BaseWindow
{
    private common_New.confirmTips view;

    public Action callBack;
    public Action cancelBack;
    private bool isShowCancelBtn;
    private bool isShowAntiAddiction;
    public ConfirmWindow()
    {
        packageName = "common_New";
        // 设置委托
        BindAllDelegate = common_New.common_NewBinder.BindAll;
        CreateInstanceDelegate = common_New.confirmTips.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        view = ui as common_New.confirmTips;
        SetBg(view.bg,"Common/ELIDA_common_littledi01.png");
        StringUtil.SetBtnTab(view.btn_confirm, Lang.GetValue("gui_btn_confirm"));
        StringUtil.SetBtnTab(view.btn_cancel, Lang.GetValue("gui_btn_cancel"));
        view.btn_cancel.onClick.Add(() =>
        {
            if (cancelBack != null)
            {
                cancelBack();
            }
            UIManager.Instance.CloseWindow(UIName.ConfirmWindow);
        });
        view.btn_confirm.onClick.Add(() =>
        {
            if(callBack != null)
            {
                callBack();
            }
            UIManager.Instance.CloseWindow(UIName.ConfirmWindow);
        });

        view.lab_antiAddiction.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<AntiAddictionWindow>(UIName.AntiAddictionWindow);
        });
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        object[] param = data as object[];
        view.content.text = (string)param[0];
        callBack = param[1] as Action;
        cancelBack = param[2] as Action;
        isShowCancelBtn = (bool)param[3];
        view.btn_cancel.visible = isShowCancelBtn;
        view.btn_confirm.x = isShowCancelBtn ? 389 : 269;
        isShowAntiAddiction = (bool)param[4];
        view.lab_antiAddiction.visible = isShowAntiAddiction;
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}


