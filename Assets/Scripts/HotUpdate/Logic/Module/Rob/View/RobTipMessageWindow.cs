
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using System;
using System.Linq;

public class RobTipMessageWindow : BaseWindow
{
    private fun_Rob.robResult _view;

    private int openType;

    private Action callFun;
    public RobTipMessageWindow()
    {
        packageName = "fun_Rob";
        // 设置委托
        BindAllDelegate = fun_Rob.fun_RobBinder.BindAll;
        CreateInstanceDelegate = fun_Rob.robResult.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        _view = ui as fun_Rob.robResult;

        _view.btn_watchVideo1.visible = false;
        _view.lb_wacthCount.visible = false;

        _view.btn_sure.onClick.Add(CallFun);
        _view.btn_getReward.onClick.Add(CallFun);
        //_view.close_btn.onClick.Add(CloseView);
    }



    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        object[] param = data as object[];
        openType = (int)param[0];
        _view.status.selectedIndex = openType;
        if (openType == 0)
        {
            List<string> result;
            _view.close_btn.visible = true;
            if ((bool)param[1])
            {
                result = new List<string>(RobModel.Instance.robOtherConfig.RobResult1s);
                StringUtil.SetBtnTab(_view.btn_sure, Lang.GetValue("common_button_ok"));
            }
            else
            {
                StringUtil.SetBtnTab(_view.btn_sure, Lang.GetValue("common_button_ok"));
                if ((bool)param[2])
                {
                    result = new List<string>(RobModel.Instance.robOtherConfig.RobResult2s);
                }
                else
                {
                    result = new List<string>(RobModel.Instance.robOtherConfig.RobResult3s);
                }
            }
            _view.lb_title.text = Lang.GetValue(result[0]);
            _view.txt_tip.text = Lang.GetValue(result[1], param[3] as string);
            _view.img_tip.url = "rob/" + result[2] + ".png";
        }
        else
        {
            _view.close_btn.visible = false;
            _view.lb_title.text = Lang.GetValue("title_message");
            uint id = (uint)param[1];

            Dictionary<ulong, ulong> items = param[3] as Dictionary<ulong, ulong>;
            StringUtil.SetBtnUrl(_view.btn_getReward, ImageDataModel.Instance.GetIconUrlByEntityId(items.Keys.ToList()[0].ToString()));
        }
    }

    private void CallFun()
    {
        if (openType == 0)
        {
            UIManager.Instance.CloseWindow(UIName.RobTipMessageWindow);
        }
        else
        {
            UIManager.Instance.CloseWindow(UIName.RobTipMessageWindow);
        }

    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

