
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class VideoPopupWindow : BaseWindow
{
   private fun_DoubleRevenueByWatchVideo.VideoPopView _view;

   public VideoPopupWindow()
    {
        packageName = "fun_DoubleRevenueByWatchVideo";
        // 设置委托
        BindAllDelegate = fun_DoubleRevenueByWatchVideo.fun_DoubleRevenueByWatchVideoBinder.BindAll;
        CreateInstanceDelegate = fun_DoubleRevenueByWatchVideo.VideoPopView.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        _view = ui as fun_DoubleRevenueByWatchVideo.VideoPopView;
        StringUtil.SetBtnTab(_view.btn_buy, Lang.GetValue("flower_order_05"));
        string str = Lang.GetValue("video_popup_tip1");
        _view.tip1.text = str.Substring(0, 1);
        _view.tip2.text = str.Substring(1);
        _view.tip3.text = Lang.GetValue("video_popup_tip2");

        _view.spnie.loop = true;
        _view.spnie.url = "shipingshouyi";
        _view.spnie.animationName = "idle";

        _view.btn_buy.onClick.Add(() =>
        {
            VideoController.Instance.ReqVideoWatch((uint)VideoSeeType.common_video_id);
        });
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

