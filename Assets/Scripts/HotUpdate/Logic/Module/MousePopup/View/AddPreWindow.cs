using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class AddPreWindow : BaseWindow
{
   private fun_PopTips.add_tips_view view;
    private CountDownTimer vipTime;
    private CountDownTimer videoTime;
    public AddPreWindow()
    {
        packageName = "fun_PopTips";
        // 设置委托
        BindAllDelegate = fun_PopTips.fun_PopTipsBinder.BindAll;
        CreateInstanceDelegate = fun_PopTips.add_tips_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_PopTips.add_tips_view;
        SetBg(view.bg, "Common/common_small_tip_bg.png");
        StringUtil.SetBtnTab(view.vip_com.vip_btn,"开通");
        StringUtil.SetBtnTab(view.video_com.video_btn, "试用");
        view.video_com.tip_lab.text = "2倍金币";
        view.vip_com.tip_lab.text = "1.25倍经验";
        var videoData = RechargeModel.Instance.GetDiamondVo((int)E_DIAMOND_VALUE_TYPE.VIDEO_PRIVILEGE);
        var vipData = RechargeModel.Instance.GetDiamondVo((int)E_DIAMOND_VALUE_TYPE.VIP);
        view.vip_com.vip_btn.onClick.Add(() =>
        {
            RechargeController.Instance.ReqPlaceOrder(2, (uint)vipData.IndexId);
        });
        view.video_com.video_btn.onClick.Add(() =>
        {
            if (!GlobalModel.Instance.GetUnlocked(SysId.VideoDouble, true))
            {
                return;
            }
            VideoController.Instance.ReqVideoWatch((uint)VideoSeeType.common_video_id);
        });
        view.video_com.buy_btn.onClick.Add(() =>
        {
            RechargeController.Instance.ReqPlaceOrder(2, (uint)videoData.IndexId);
        });
        view.video_com.seach_btn.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<RechargeMainView>(UIName.RechargeMainView, 1);
        });
        view.vip_com.seach_btn.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<RechargeMainView>(UIName.RechargeMainView, 1);
        });
        EventManager.Instance.AddEventListener(RechargeEvent.VipPay, UpdateVip);

        EventManager.Instance.AddEventListener(RechargeEvent.VideoPay, UpdateVedioTime);
        EventManager.Instance.AddEventListener(RechargeEvent.RechargeInfo, UpdateVedioTime);
        EventManager.Instance.AddEventListener(VideoEvent.videoDoubleTime, UpdateVedioTime);

    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        int type = (int)data;
        view.status.selectedIndex = type;
        UpdateVip();
        UpdateVedioTime();
    }

    private void UpdateVip()
    {
        var vipData = RechargeModel.Instance.GetDiamondVo((int)E_DIAMOND_VALUE_TYPE.VIP);
        if (MyselfModel.Instance.IsVip())
        {
            view.vip_com.show_time.selectedIndex = 1;
        }
        else
        {
            view.vip_com.show_time.selectedIndex = 0;
        }
        UpdateVipTime();
    }
    private void UpdateVipTime()
    {
        if (vipTime != null)
        {
            vipTime.Clear();
            vipTime = null;
        }
        if (MyselfModel.Instance.vipTime > ServerTime.Time)
        {
            var leftTime = MyselfModel.Instance.vipTime - ServerTime.Time;
            vipTime = new CountDownTimer(view.vip_com.timeLab, (int)leftTime, true,2);
            vipTime.CompleteCallBacker = UpdateVip;
        }
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
            StringUtil.SetBtnTab(view.video_com.buy_btn, Lang.GetValue("recharge_main_18", (videoData.Price / 10).ToString()));

            view.video_com.buy_btn.status.selectedIndex = 0;
            view.video_com.half.selectedIndex = 0;
        }
        else
        {
            StringUtil.SetBtnTab(view.video_com.buy_btn, Lang.GetValue("recharge_main_18", (videoData.Price / 10 / 2).ToString()));
            StringUtil.SetBtnTab3(view.video_com.buy_btn, Lang.GetValue("recharge_main_18", (videoData.Price / 10).ToString()));
            view.video_com.buy_btn.status.selectedIndex = 1;
            view.video_com.half.selectedIndex = 1;
        }
        if (videoDouble == null && card == null)
        {
            view.video_com.show_time.selectedIndex = 0;
            view.video_com.grp.visible = false;
            view.video_com.video_btn.visible = true;
            view.video_com.limit_lab.visible = true;
            return;
        }
        var endTime1 = videoDouble == null ? 0 : int.Parse(videoDouble.info);
        var endTime2 = card == null ? 0 : int.Parse(card.info);
        var endTime = endTime1 > endTime2 ? endTime1 : endTime2;
        var time = endTime - (int)ServerTime.Time;
        if(time > 0)
        {
            GTextField text = null;
            if(endTime2 > ServerTime.Time)
            {
                view.video_com.show_time.selectedIndex = 1;
                text = view.video_com.timeLab;
            }
            else if(endTime1 > ServerTime.Time)
            {
                view.video_com.show_time.selectedIndex = 0;
                view.video_com.grp.visible = true;
                view.video_com.video_btn.visible = false;
                view.video_com.limit_lab.visible = false;
                text = view.video_com.timeLab1;
            }
            videoTime = new CountDownTimer(text, time, true, 2);
            videoTime.CompleteCallBacker = UpdateVedioTime;
        }
        else
        {
            view.video_com.show_time.selectedIndex = 0;
            view.video_com.grp.visible = false;
            view.video_com.video_btn.visible = true;
            view.video_com.limit_lab.visible = true;
        }
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
        if (vipTime != null)
        {
            vipTime.Clear();
            vipTime = null;
        }
        if (videoTime != null)
        {
            videoTime.Clear();
            videoTime = null;
        }
    }
}

