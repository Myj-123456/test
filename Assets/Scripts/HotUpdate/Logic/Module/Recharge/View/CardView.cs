
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ADK;

public class CardView
{
   private fun_Recharge.card_view view;
    private CountDownTimer vipTime;
    private CountDownTimer videoTime;
    public CardView(fun_Recharge.card_view ui)
    {
        view = ui;
        view.item1.titleLab.text = Lang.GetValue("recharge_main_4");
        view.item1.sunLab.text = view.item2.sunLab.text = Lang.GetValue("recharge_main_10");
        view.item1.txt_1.lab.text = Lang.GetValue("recharge_main_5");
        view.item1.txt_2.lab.text = Lang.GetValue("recharge_main_6");
        view.item1.txt_3.lab.text = Lang.GetValue("recharge_main_7", MyselfModel.Instance.expVip.ToString());
        view.item1.txt_4.lab.text = Lang.GetValue("recharge_main_8", GlobalModel.Instance.module_profileConfig.waterLimitVip.ToString());
        view.item1.txt_5.lab.text = Lang.GetValue("recharge_main_9","1");
        view.item1.tipLab.text = Lang.GetValue("recharge_main_11");

        view.item2.titleLab.text = Lang.GetValue("recharge_main_19");
        view.item2.sunLab.text = view.item2.sunLab.text = Lang.GetValue("recharge_main_10");
        view.item2.txt_1.lab.text = Lang.GetValue("recharge_main_20");
        view.item2.txt_2.lab.text = Lang.GetValue("recharge_main_21");
        view.item2.txt_3.lab.text = Lang.GetValue("flower_order_01");
        view.item2.txt_4.lab.text = Lang.GetValue("npc_order_10");
        view.item2.txt_5.lab.text = Lang.GetValue("recharge_main_22");
        view.item2.tipLab.text = Lang.GetValue("recharge_main_11");


        view.item1.buy_lab.text = Lang.GetValue("recharge_main_12");
        view.item1.day_lab.text = Lang.GetValue("recharge_main_13");
        view.item1.show_com.titleLab.text = Lang.GetValue("recharge_main_14");
        view.item1.show_com.txt_1.text = Lang.GetValue("vip_video_title");
        view.item1.show_com.txt_2.text = Lang.GetValue("Vip_function2");
        view.item1.show_com.txt_3.text = Lang.GetValue("recharge_main_15");
        view.item1.show_com.txt_4.text = Lang.GetValue("Vip_function1");
        view.item1.show_com.txt_5.text = Lang.GetValue("recharge_main_16");
        view.item1.show_com.txt_6.text = Lang.GetValue("recharge_main_17");

        
        //RechargeController.Instance.ReqPlaceOrder(2, (uint)vipData.IndexId);
        var vipData = RechargeModel.Instance.GetDiamondVo((int)E_DIAMOND_VALUE_TYPE.VIP);
        
        view.item1.reward_list1.itemRenderer = (int index, GObject item) =>
        {
            var cell = item as fun_Recharge.reward_item;
            var info = vipData.Items[index];
            var itemVo = ItemModel.Instance.GetItemByEntityID(info.EntityID);
            cell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
            cell.countLab.text = info.Value.ToString();
            UILogicUtils.SetItemShow(cell, itemVo.ItemDefId);
        };
        view.item1.reward_list1.numItems = vipData.Items.Length;

        var dayReward = GlobalModel.Instance.module_profileConfig.everyVipReward.ToList();
        view.item1.reward_list2.itemRenderer = (int index, GObject item) =>
        {
            var cell = item as fun_Recharge.reward_item;
            var info = dayReward[index];
            var itemVo = ItemModel.Instance.GetItemByEntityID(info.Key);
            cell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
            cell.countLab.text = info.Value.ToString();
            UILogicUtils.SetItemShow(cell, itemVo.ItemDefId);
        };
        view.item1.reward_list2.numItems = dayReward.Count;

        view.item1.lok_btn.onClick.Add(() =>
        {
            view.item1.show.selectedIndex = view.item1.show.selectedIndex == 0?1:0;
        });
        view.item1.buy_btn.onClick.Add(() => {
            if (MyselfModel.Instance.IsVip())
            {
                if (MyselfModel.Instance.behaviorDaily.monthCardAward == 0)
                {
                    RechargeController.Instance.ReqMonthCard();
                }
                else
                {

                }
            }
            else
            {
                RechargeController.Instance.ReqPlaceOrder(2, (uint)vipData.IndexId);
            }
        });
        var videoData = RechargeModel.Instance.GetDiamondVo((int)E_DIAMOND_VALUE_TYPE.VIDEO_PRIVILEGE);
        view.item2.buy_btn.onClick.Add(() =>
        {
            RechargeController.Instance.ReqPlaceOrder(2, (uint)videoData.IndexId);
        });
        StringUtil.SetBtnTab(view.item1.buy_btn, Lang.GetValue("recharge_main_18", (videoData.Price / 10).ToString()));
        EventManager.Instance.AddEventListener(RechargeEvent.VipPay, UpdateVip);
        EventManager.Instance.AddEventListener(RechargeEvent.MonthCard, UpdateVip);
        EventManager.Instance.AddEventListener(RechargeEvent.VideoPay, UpdateVedioTime);
        EventManager.Instance.AddEventListener(RechargeEvent.RechargeInfo, UpdateVedioTime);
    }


    public void OnShown()
    {
        view.item1.show.selectedIndex = 0;
        UpdateVip();
        UpdateVedioTime();
    }

    private void UpdateVip()
    {
        var vipData = RechargeModel.Instance.GetDiamondVo((int)E_DIAMOND_VALUE_TYPE.VIP);
        view.item1.buy_btn.enabled = true;
        if (MyselfModel.Instance.IsVip())
        {
            if(MyselfModel.Instance.behaviorDaily.monthCardAward == 0)
            {
                StringUtil.SetBtnTab(view.item1.buy_btn, Lang.GetValue("common_claim_button"));
            }
            else
            {
                StringUtil.SetBtnTab(view.item1.buy_btn, Lang.GetValue("recharge_main_23"));
                view.item1.buy_btn.enabled = false;
            }
        }
        else
        {
            StringUtil.SetBtnTab(view.item1.buy_btn, Lang.GetValue("recharge_main_18", (vipData.Price / 10).ToString()));
        }
        UpdateVipTime();
    }

    private void UpdateVipTime()
    {
        if(vipTime != null)
        {
            vipTime.Clear();
            vipTime = null;
        }
        if (MyselfModel.Instance.vipTime > ServerTime.Time)
        {
            var leftTime = MyselfModel.Instance.vipTime - ServerTime.Time;
            vipTime = new CountDownTimer(view.item1.timeLab, (int)leftTime, false);
            vipTime.prefixString = Lang.GetValue("fun_boon_3");
            vipTime.Run();
            vipTime.CompleteCallBacker = UpdateVip;
        }
        else
        {
            view.item1.timeLab.text = "";
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
        var video = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_SKIP_VIDEO_CARD);
        if (RechargeModel.Instance.haveDiamondValue != null && RechargeModel.Instance.haveDiamondValue.ContainsKey((uint)videoData.IndexId))
        {
            StringUtil.SetBtnTab(view.item2.buy_btn, Lang.GetValue("recharge_main_18", (videoData.Price / 10).ToString()));
            
            view.item2.half.selectedIndex = 0;
            view.item2.buy_btn.type.selectedIndex = 0;
        }
        else
        {
            StringUtil.SetBtnTab(view.item2.buy_btn, Lang.GetValue("recharge_main_18", (videoData.Price / 10 / 2).ToString()));
            StringUtil.SetBtnTab3(view.item2.buy_btn, Lang.GetValue("recharge_main_18", (videoData.Price / 10).ToString()));
            view.item2.buy_btn.type.selectedIndex = 1;
            view.item2.half.selectedIndex = 1;
        }
        if (video != null && int.Parse(video.info) > ServerTime.Time)
        {
            var leftTime = int.Parse(video.info) - ServerTime.Time;
            videoTime = new CountDownTimer(view.item2.timeLab, (int)leftTime, false);
            videoTime.prefixString = Lang.GetValue("fun_boon_3");
            videoTime.Run();
            videoTime.CompleteCallBacker = UpdateVedioTime;

        }
        else
        {
            view.item2.timeLab.text = "";
        }
    }

    public void OnHide()
    {
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

