using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class VideoDoubleView
{
   private fun_Welfare.video_double_view view;
    public CountDownTimer timer;
   public VideoDoubleView(fun_Welfare.video_double_view ui)
    {
        view = ui;
        StringUtil.SetBtnTab(view.btn_buy, Lang.GetValue("flower_order_05"));
        string str = Lang.GetValue("video_popup_tip1");
        view.tip1.text = str.Substring(0, 1);
        view.tip2.text = str.Substring(1);
        view.tip3.text = Lang.GetValue("video_popup_tip2");

        view.spnie.loop = true;
        view.spnie.url = "shipingshouyi";
        view.spnie.animationName = "idle";

        view.btn_buy.onClick.Add(() =>
        {
            VideoController.Instance.ReqVideoWatch((uint)VideoSeeType.common_video_id);
        });
        EventManager.Instance.AddEventListener(RechargeEvent.VideoPay, UpdateVideoView);
        EventManager.Instance.AddEventListener(VideoEvent.videoDoubleTime, UpdateVideoView);
    }


    public void OnShown()
    {
        UpdateVideoView();
    }
    private void UpdateVideoView()
    {
        var videoDouble = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_VIDEO_BUFF);
        var card = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_SKIP_VIDEO_CARD);
        if (videoDouble == null && card == null)
        {
            return;
        }
        var endTime1 = videoDouble == null ? 0 : int.Parse(videoDouble.info);
        var endTime2 = card == null ? 0 : int.Parse(card.info);
        var endTime = endTime1 > endTime2 ? endTime1 : endTime2;
        var time = endTime - (int)ServerTime.Time;
        if (time > 0)
        {
            view.btn_buy.visible = false;
            if (timer != null)
            {
                timer.Clear();
                timer = null;
            }
            timer = new CountDownTimer(view.timeLab, time);
            //_videoCountDown.CompleteCallBacker = UpdateVideoView;
            timer.CompleteCallBacker = UpdateVideoView;
        }
        else
        {
            view.btn_buy.visible = true;
            view.timeLab.text = "";


        }
    }
    public void OnHide()
    {
        if(timer != null)
        {
            timer.Clear();
            timer = null;
        }
    }
}

