using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class VideoDoubleWindow : BaseWindow
{
   private fun_PopTips.video_doublr_view view;
    private CountDownTimer videoTime;
    public VideoDoubleWindow()
    {
        packageName = "fun_PopTips";
        // 设置委托
        BindAllDelegate = fun_PopTips.fun_PopTipsBinder.BindAll;
        CreateInstanceDelegate = fun_PopTips.video_doublr_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_PopTips.video_doublr_view;
        SetBg(view.bg, "Common/common_small_tip_bg.png");
        StringUtil.SetBtnTab(view.video_btn, "继续观看");
        var videoData = RechargeModel.Instance.GetDiamondVo((int)E_DIAMOND_VALUE_TYPE.VIDEO_PRIVILEGE);
        StringUtil.SetBtnTab(view.buy_btn1, Lang.GetValue("recharge_main_18", (videoData.Price / 10).ToString()));
        StringUtil.SetBtnTab(view.buy_btn, Lang.GetValue("recharge_main_18", (videoData.Price / 10 / 2).ToString()));
        StringUtil.SetBtnTab3(view.buy_btn, Lang.GetValue("recharge_main_18", (videoData.Price / 10).ToString()));

        view.video_btn.onClick.Add(() =>
        {
            if (!GlobalModel.Instance.GetUnlocked(SysId.VideoDouble, true))
            {
                return;
            }
            VideoController.Instance.ReqVideoWatch((uint)VideoSeeType.common_video_id);
        });
        view.buy_btn.onClick.Add(() =>
        {
            RechargeController.Instance.ReqPlaceOrder(2, (uint)videoData.IndexId);
        });
        view.seach_btn.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<RechargeMainView>(UIName.RechargeMainView, 1);
        });
        EventManager.Instance.AddEventListener(RechargeEvent.VideoPay, UpdateVedioTime);
        EventManager.Instance.AddEventListener(RechargeEvent.VipPay, UpdateVedioTime);
        EventManager.Instance.AddEventListener(VideoEvent.videoDoubleTime, UpdateVedioTime);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        UpdateVedioTime();
    }
    private void UpdateVedioTime()
    {
        if (videoTime != null)
        {
            videoTime.Clear();
            videoTime = null;
        }

        var videoData = RechargeModel.Instance.GetDiamondVo((int)E_DIAMOND_VALUE_TYPE.VIDEO_PRIVILEGE);

        var videoDouble = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_VIDEO_BUFF);
        var card = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_SKIP_VIDEO_CARD);

        if (RechargeModel.Instance.haveDiamondValue != null && RechargeModel.Instance.haveDiamondValue.ContainsKey((uint)videoData.IndexId))
        {
            view.status.selectedIndex = 0;
        }
        else
        {
            view.status.selectedIndex = 1;
        }
        if (videoDouble == null && card == null)
        {
            view.type.selectedIndex = 0;
            view.grp.visible = false;
            view.video_btn.visible = true;
            return;
        }
        var endTime1 = videoDouble == null ? 0 : int.Parse(videoDouble.info);
        var endTime2 = card == null ? 0 : int.Parse(card.info);
        var endTime = endTime1 > endTime2 ? endTime1 : endTime2;
        var time = endTime - (int)ServerTime.Time;
        if (time > 0)
        {
            GTextField text = null;
            if (endTime2 > ServerTime.Time)
            {
                view.type.selectedIndex = 1;
                text = view.timeLab;
            }
            else if (endTime1 > ServerTime.Time)
            {
                view.type.selectedIndex = 0;
                view.grp.visible = true;
                view.video_btn.visible = false;
                text = view.timeLab1;
            }
            videoTime = new CountDownTimer(text, time);
            videoTime.CompleteCallBacker = UpdateVedioTime;
        }
        else
        {
            view.type.selectedIndex = 0;
            view.grp.visible = false;
            view.video_btn.visible = true;
        }
    }
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
        if(videoTime != null)
        {
            videoTime.Clear();
            videoTime = null;
        }
    }
}

