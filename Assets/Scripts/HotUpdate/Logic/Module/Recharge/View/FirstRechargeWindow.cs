using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using Elida.Config;
using System;

public class FirstRechargeWindow : BaseWindow
{
   private fun_Recharge.first_recharge_view view;
    private int tabType;
    private List<Ft_game_payConfig> firstPayList;
    private List<StorageItemVO> listData;
    private int secondIdx;
   public FirstRechargeWindow()
    {
        packageName = "fun_Recharge";
        // 设置委托
        BindAllDelegate = fun_Recharge.fun_RechargeBinder.BindAll;
        CreateInstanceDelegate = fun_Recharge.first_recharge_view.CreateInstance;
        ClickBlankClose = true;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Recharge.first_recharge_view;
        SetBg(view.bg, "Recharge/ELIDA_shouchong_bg.png");
        firstPayList = RechargeModel.Instance.firstPayList;
        StringUtil.SetBtnTab(view.one_btn, Lang.GetValue("text_activity_6"));
        StringUtil.SetBtnTab(view.two_btn, Lang.GetValue("text_activity_7"));
        StringUtil.SetBtnTab(view.three_btn, Lang.GetValue("text_activity_8"));

        StringUtil.SetBtnTab(view.buy_btn1.buy_btn, Lang.GetValue("recharge_main_18", firstPayList[0].Price.ToString()));
        StringUtil.SetBtnTab(view.buy_btn2.buy_btn, Lang.GetValue("recharge_main_18", firstPayList[1].Price.ToString()));
        StringUtil.SetBtnTab(view.buy_btn3.buy_btn, Lang.GetValue("recharge_main_18", firstPayList[2].Price.ToString()));
        StringUtil.SetBtnTab(view.buy_btn4.buy_btn, Lang.GetValue("recharge_main_18", firstPayList[3].Price.ToString()));

        view.buy_btn1.countLab.text = firstPayList[0].IsThree.ToString();
        view.buy_btn2.countLab.text = firstPayList[1].IsThree.ToString();
        view.buy_btn3.countLab.text = firstPayList[2].IsThree.ToString();
        view.buy_btn4.countLab.text = firstPayList[3].IsThree.ToString();

        view.list.itemRenderer = RenderList;

        view.list1.itemRenderer = RenderList1;

        view.buy_btn3.status.selectedIndex = 1;
        view.buy_btn4.status.selectedIndex = 1;

        var flowerVo = GetFlower();
        if(flowerVo != null)
        {
            view.spine.loop = true;
            view.spine.forcePlay = true;
            view.spine.url = "flowers/" + flowerVo.itemDefId;
            view.spine.animationName = "step_" + 3 + "_idle";
            view.nameLab.text = Lang.GetValue(flowerVo.item.Name);
            UILogicUtils.SetItemShow(view.show_btn, flowerVo.itemDefId);
        }
        view.one_btn.onClick.Add(() =>
        {
            if(tabType != 0)
            {
                ChangeTab(0);
            }
        });

        view.two_btn.onClick.Add(() =>
        {
            if (tabType != 1)
            {
                ChangeTab(1);
            }
        });

        view.three_btn.onClick.Add(() =>
        {
            if (tabType != 2)
            {
                ChangeTab(2);
            }
        });

        view.buy_btn1.buy_btn.onClick.Add(() =>
        {
            var buyData = firstPayList[0];
            RechargeController.Instance.ReqPlaceOrder(3, uint.Parse(buyData.ProductId));
        });
        view.buy_btn2.buy_btn.onClick.Add(() =>
        {
            var buyData = firstPayList[1];
            RechargeController.Instance.ReqPlaceOrder(3, uint.Parse(buyData.ProductId));
        });
        view.buy_btn3.buy_btn.onClick.Add(() =>
        {
            var buyData = firstPayList[2];
            RechargeController.Instance.ReqPlaceOrder(3, uint.Parse(buyData.ProductId));
        });
        view.buy_btn4.buy_btn.onClick.Add(() =>
        {
            var buyData = firstPayList[3];
            RechargeController.Instance.ReqPlaceOrder(3, uint.Parse(buyData.ProductId));
        });

        view.get_btn.onClick.Add(() =>
        {
            RechargeController.Instance.ReqFristRecharge((uint)tabType + 1);
        });
        AddEventListener(RechargeEvent.RechargeInfo, UpdatePayData);
        AddEventListener(RechargeEvent.FristRecharge, UpdatePayData);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        var showDay = GetCanGet();
        view.tab.selectedIndex = showDay - 1;
        UpdateData();
        ChangeTab(showDay - 1);
    }
    private void UpdatePayData()
    {
        UpdateData();
        ChangeTab(tabType);
    }
    private void UpdateData()
    {
        if (RechargeModel.Instance.IsFirstRecharge())
        {
            view.buy.selectedIndex = 1;
        }
        else
        {
            view.buy.selectedIndex = 0;
        }
    }

    private void ChangeTab(int type)
    {
        tabType = type;
        if(tabType == 0)
        {
            listData = GetRewards(GlobalModel.Instance.module_profileConfig.FirstRechargeReward_Day1);
        }
        else if(tabType == 1)
        {
            listData = GetRewards(GlobalModel.Instance.module_profileConfig.FirstRechargeReward_Day2);
        }
        else
        {
            listData = GetRewards(GlobalModel.Instance.module_profileConfig.FirstRechargeReward_Day3);
        }
        if(listData.Count % 2 == 0)
        {
            secondIdx = listData.Count / 2;
        }
        else
        {
            secondIdx = (listData.Count - 1) / 2 + 1;
        }
        view.list.numItems = secondIdx;
        view.list1.numItems = listData.Count - secondIdx;
        var unlockDay = GetCurDayTime();
        if (RechargeModel.Instance.IsFirstRecharge())
        {
            if (tabType < unlockDay)
            {
                if (RechargeModel.Instance.firstRechargeRewards == null || Array.IndexOf(RechargeModel.Instance.firstRechargeRewards, (uint)(tabType + 1)) == -1)
                {
                    view.get_btn.enabled = true;
                    StringUtil.SetBtnTab(view.get_btn, Lang.GetValue("common_claim_button"));
                }
                else
                {
                    view.get_btn.enabled = false;
                    StringUtil.SetBtnTab(view.get_btn, Lang.GetValue("invite_friends_11"));
                }
            }
            else
            {
                view.get_btn.enabled = false;
                StringUtil.SetBtnTab(view.get_btn, Lang.GetValue("common_claim_button"));
            }
        }
            
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }

    private int GetCanGet()
    {
        if (!RechargeModel.Instance.IsFirstRecharge())
        {
            return 1;
        }
        var curDay = GetCurDayTime();
        var day = 3;
        for(int i = 1;i < curDay + 1; i++)
        {
            if(RechargeModel.Instance.firstRechargeRewards == null || Array.IndexOf(RechargeModel.Instance.firstRechargeRewards,(uint)i) == -1){
                day = i;
                break;
            }
        }
        return day;
    }

    private int GetCurDayTime()
    {
        var now = TimeUtil.GetDateTime(RechargeModel.Instance.firstRechargeTime);
        var next = now.Date.AddDays(1);
        var three = now.Date.AddDays(2);
        var nextTamp = TimeUtil.GetTimestamp(next);
        var threeTamp = TimeUtil.GetTimestamp(three);
        if (ServerTime.Time >= threeTamp)
        {
            return 3;
        }else if(ServerTime.Time >= nextTamp)
        {
            return 2;
        }
        else
        {
            return 1;
        }
    }

    private List<StorageItemVO> GetRewards(Dictionary<string, int> rewards)
    {
        var list = new List<StorageItemVO>();
        foreach(var value in rewards)
        {
            var reward = new StorageItemVO();
            var itemVo = ItemModel.Instance.GetItemByEntityID(value.Key);
            reward.count = value.Value;
            reward.itemDefId = itemVo.ItemDefId;
            reward.item = itemVo;
            list.Add(reward);
        }
        return list;
    }

    private StorageItemVO GetFlower()
    {
        var rewards = GetRewards(GlobalModel.Instance.module_profileConfig.FirstRechargeReward_Day3);
        foreach(var value in rewards)
        {
            if(value.item.Type == 4105)
            {
                return value;
            }
        }
        return null;
    }

    private void RenderList(int index,GObject item)
    {
        var cell = item as fun_Recharge.reward_item3;
        var info = listData[index];
        cell.pic.url = ImageDataModel.Instance.GetIconUrl(info.item);
        cell.countLab.text = info.count.ToString();
        UILogicUtils.SetItemShow(cell, info.item.ItemDefId);
    }

    private void RenderList1(int index, GObject item)
    {
        var cell = item as fun_Recharge.reward_item3;
        var info = listData[secondIdx + index];
        cell.pic.url = ImageDataModel.Instance.GetIconUrl(info.item);
        cell.countLab.text = info.count.ToString();
        UILogicUtils.SetItemShow(cell, info.item.ItemDefId);
    }
}

