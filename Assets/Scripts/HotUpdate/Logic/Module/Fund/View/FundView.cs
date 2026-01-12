using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using Elida.Config;

public class FundView
{
    private fun_Recharge.fund_view view;
    private int tabType;
    private List<Ft_fundConfig> listData;
    private Ft_diamond_valueConfig curBuyData;
    public FundView(fun_Recharge.fund_view ui)
    {
        view = ui;
        //packageName = "fun_Fund";
        //// 设置委托
        //BindAllDelegate = fun_Fund.fun_FundBinder.BindAll;
        //CreateInstanceDelegate = fun_Fund.fund_view.CreateInstance;
        view.list.height = view.buy_btn.y - view.cash_btn.y - 91;
        OnInit();
    }

    public void OnInit()
    {
        StringUtil.SetBtnTab(view.cash_btn, Lang.GetValue("fund_1"));
        StringUtil.SetBtnTab(view.new_btn, Lang.GetValue("fund_2"));
        StringUtil.SetBtnTab(view.step_btn, Lang.GetValue("fund_3"));
        view.n25.text = Lang.GetValue("fund_7");
        tabType = 0;
        view.list.itemRenderer = RenderList;

        view.buy_btn.onClick.Add(() =>
        {
            RechargeController.Instance.ReqPlaceOrder(2, (uint)curBuyData.IndexId);
        });
        view.cash_btn.onClick.Add(() =>
        {
            if (tabType != 0)
            {
                ChangeTab(0);
            }
        });
        view.new_btn.onClick.Add(() =>
        {
            if (tabType != 1)
            {
                ChangeTab(1);
            }
        });
        view.step_btn.onClick.Add(() =>
        {
            if (tabType != 2)
            {
                ChangeTab(2);
            }
        });
        EventManager.Instance.AddEventListener(RechargeEvent.RechargeInfo, UpdateData);
        EventManager.Instance.AddEventListener(FundEvent.FundReward, () => 
        {
            UpdateList();
            UpdateTabButtonStates();
        });
    }

    public void OnShown()
    {
        // 其他打开面板的逻辑
        ChangeTab(tabType);
        UpdateTabButtonStates();
    }
    private void UpdateData()
    {
        ChangeTab(tabType);
    }
    private void ChangeTab(int type)
    {
        tabType = type;
        if (tabType == 0)
        {
            curBuyData = RechargeModel.Instance.GetDiamondVo((int)E_DIAMOND_VALUE_TYPE.CASH);
        }
        else if (tabType == 1)
        {
            curBuyData = RechargeModel.Instance.GetDiamondVo((int)E_DIAMOND_VALUE_TYPE.INTROD);
        }
        else
        {
            curBuyData = RechargeModel.Instance.GetDiamondVo((int)E_DIAMOND_VALUE_TYPE.STEP);
        }
        listData = FundModel.Instance.GetFundList(tabType + 1);
        UpdateList();
        
        UpdateTabButtonStates();
        
        if (curBuyData != null)
        {
            StringUtil.SetBtnTab(view.buy_btn, Lang.GetValue("recharge_main_18", (curBuyData.Price / 10).ToString()));
            view.buy_btn.visible = !RechargeModel.Instance.haveDiamondValue.ContainsKey((uint)curBuyData.IndexId);
        }
    }
    
    private void UpdateTabButtonStates()
    {
        var cashData = RechargeModel.Instance.GetDiamondVo((int)E_DIAMOND_VALUE_TYPE.CASH);
        if (cashData != null)
        {
            view.cash_btn.ctrl.selectedIndex = RechargeModel.Instance.haveDiamondValue.ContainsKey((uint)cashData.IndexId) ? 0 : 1;
            CheckFundRedPoint(view.cash_btn, 1);
        }
        var introData = RechargeModel.Instance.GetDiamondVo((int)E_DIAMOND_VALUE_TYPE.INTROD);
        if (introData != null)
        {
            view.new_btn.ctrl.selectedIndex = RechargeModel.Instance.haveDiamondValue.ContainsKey((uint)introData.IndexId) ? 0 : 1;
            CheckFundRedPoint(view.new_btn, 2);
        }
        var stepData = RechargeModel.Instance.GetDiamondVo((int)E_DIAMOND_VALUE_TYPE.STEP);
        if (stepData != null)
        {
            view.step_btn.ctrl.selectedIndex = RechargeModel.Instance.haveDiamondValue.ContainsKey((uint)stepData.IndexId) ? 0 : 1;
            CheckFundRedPoint(view.step_btn, 3);
        }
    }
    
    private void CheckFundRedPoint(GObject btn, int fundType)
    {
        bool hasRed = false;
        
        Ft_diamond_valueConfig diamondData = null;
        if (fundType == 1)
        {
            diamondData = RechargeModel.Instance.GetDiamondVo((int)E_DIAMOND_VALUE_TYPE.CASH);
        }
        else if (fundType == 2)
        {
            diamondData = RechargeModel.Instance.GetDiamondVo((int)E_DIAMOND_VALUE_TYPE.INTROD);
        }
        else if (fundType == 3)
        {
            diamondData = RechargeModel.Instance.GetDiamondVo((int)E_DIAMOND_VALUE_TYPE.STEP);
        }

        if (diamondData == null || !RechargeModel.Instance.haveDiamondValue.ContainsKey((uint)diamondData.IndexId))
        {
            hasRed = false;
        }
        else
        {
            var fundList = FundModel.Instance.GetFundList(fundType);
            foreach (var config in fundList)
            {
                if (!FundModel.Instance.IsGetted((uint)fundType, (uint)config.Id) && MyselfModel.Instance.level >= config.ReceiveLv)
                {
                    hasRed = true;
                    break;
                }
            }
        }
        if (hasRed)
        {
            UILogicUtils.ShowRedPoint((GComponent)btn);
        }
        else
        {
            UILogicUtils.HideRedPoint((GComponent)btn);
        }
    }
    private void UpdateList()
    {
        if (listData != null)
        {
            view.list.numItems = listData.Count;
        }
    }

    private void RenderList(int index, GObject item)
    {
        if (item == null || listData == null || index < 0 || index >= listData.Count)
            return;
            
        var cell = item as fun_Recharge.fund_item;
        if (cell == null)
            return;
            
        var info = listData[index];
        if (info == null)
            return;
            
        cell.limitLab.text = Lang.GetValue("fund_4", info.ReceiveLv.ToString());
        if(MyselfModel.Instance.level >= info.ReceiveLv)
        {
            cell.textcolor.selectedIndex = 0;
            cell.proLab.text = (MyselfModel.Instance.level > info.ReceiveLv ? info.ReceiveLv : MyselfModel.Instance.level) + "/" + info.ReceiveLv;
        }
        else
        {
            cell.textcolor.selectedIndex = 1;
            cell.proLab1.text = (MyselfModel.Instance.level > info.ReceiveLv ? info.ReceiveLv : MyselfModel.Instance.level) + "/" + info.ReceiveLv;
        }
        
        if (RechargeModel.Instance.haveDiamondValue.ContainsKey((uint)curBuyData.IndexId))
        {
            if (info.ReceiveLv > MyselfModel.Instance.level)
            {
                cell.ctrl.selectedIndex = 0;
                cell.btn.enabled = false;
                StringUtil.SetBtnTab(cell.btn, Lang.GetValue("rob_21"));
            }
            else
            {
                if (FundModel.Instance.IsGetted((uint)tabType + 1, (uint)info.Id))
                {
                    cell.ctrl.selectedIndex = 1;
                    cell.btn.enabled = false;
                    StringUtil.SetBtnTab(cell.btn, Lang.GetValue("Tour_gift_txt8"));
                }
                else
                {
                    cell.ctrl.selectedIndex = 0;
                    cell.btn.enabled = true;
                    StringUtil.SetBtnTab(cell.btn, Lang.GetValue("Train_txt7"));
                }
            }
        }
        else
        {
            cell.ctrl.selectedIndex = 0;
            cell.btn.enabled = false;
            StringUtil.SetBtnTab(cell.btn, Lang.GetValue("rob_21"));
        }

        if (cell.list != null && info.ItemRewards != null)
        {
            cell.list.itemRenderer = (int idx, GObject reward) =>
            {
                if (reward == null || idx < 0 || idx >= info.ItemRewards.Length)
                    return;
                    
                var rewardItem = reward as fun_Recharge.reward_item1;
                if (rewardItem == null)
                    return;
                    
                var rewardInfo = info.ItemRewards[idx];
                if (rewardInfo == null)
                    return;
                    
                var itemVo = ItemModel.Instance.GetItemByEntityID(rewardInfo.EntityID);
                if (itemVo != null)
                {
                    rewardItem.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
                    rewardItem.countLab.text = TextUtil.ChangeCoinShow(rewardInfo.Value);
                    rewardItem.bg.url = ImageDataModel.Instance.GetItemQuality(itemVo.Quality);
                    UILogicUtils.SetItemShow(rewardItem, itemVo.ItemDefId);
                }
            };
            cell.list.numItems = info.ItemRewards.Length;
        }
        
        if (cell.btn != null)
        {
            cell.btn.onClick.Clear();
            uint rewardId = (uint)info.Id;
            cell.btn.onClick.Add(() => GetReward(rewardId));
        }
    }

    private void GetReward(uint rewardId)
    {
        FundController.Instance.ReqFundReward((uint)tabType + 1, rewardId);
    }
    public void OnHide()
    {
        // 其他关闭面板的逻辑
    }
}

