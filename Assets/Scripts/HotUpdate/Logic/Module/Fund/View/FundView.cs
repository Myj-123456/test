using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using Elida.Config;

public class FundView : BaseView
{
   private fun_Fund.fund_view view;
    private int tabType;
    private List<Ft_fundConfig> listData;
    private Ft_diamond_valueConfig curBuyData;
   public FundView()
    {
        packageName = "fun_Fund";
        // 设置委托
        BindAllDelegate = fun_Fund.fun_FundBinder.BindAll;
        CreateInstanceDelegate = fun_Fund.fund_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Fund.fund_view;
        SetBg(view.bg, "Recharge/ELIDA_chongzhi_bg01.png");
        StringUtil.SetBtnTab(view.cash_btn,Lang.GetValue("fund_1"));
        StringUtil.SetBtnTab(view.new_btn, Lang.GetValue("fund_2"));
        StringUtil.SetBtnTab(view.step_btn, Lang.GetValue("fund_3"));
        tabType = 0;
        view.list.itemRenderer = RenderList;
        view.buy_btn.onClick.Add(() =>
        {
            RechargeController.Instance.ReqPlaceOrder(2, (uint)curBuyData.IndexId);
        });
        view.cash_btn.onClick.Add(() =>
        {
            if(tabType != 0)
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
        AddEventListener(FundEvent.FundReward, UpdateList);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        ChangeTab(tabType);
    }
    private void UpdateData()
    {
        ChangeTab(tabType);
    }
    private void ChangeTab(int type)
    {
        tabType = type;
        if (tabType == 0) {
            curBuyData = RechargeModel.Instance.GetDiamondVo((int)E_DIAMOND_VALUE_TYPE.CASH);
        }
        else if(tabType == 1)
        {
            curBuyData = RechargeModel.Instance.GetDiamondVo((int)E_DIAMOND_VALUE_TYPE.INTROD);
        }
        else
        {
            curBuyData = RechargeModel.Instance.GetDiamondVo((int)E_DIAMOND_VALUE_TYPE.STEP);
        }
        listData = FundModel.Instance.GetFundList(tabType + 1);
        UpdateList();
        StringUtil.SetBtnTab(view.buy_btn, Lang.GetValue("recharge_main_18", (curBuyData.Price / 10).ToString()));
        view.buy_btn.visible = !RechargeModel.Instance.haveDiamondValue.ContainsKey((uint)curBuyData.IndexId);
    }
    private void UpdateList()
    {
        view.list.numItems = listData.Count;
    }
    
    private void RenderList(int index,GObject item)
    {
        var cell = item as fun_Fund.fund_item;
        var info = listData[index];
        cell.limitLab.text = Lang.GetValue("fund_4", info.ReceiveLv.ToString());
        cell.proLab.text =  (MyselfModel.Instance.level > info.ReceiveLv? info.ReceiveLv: MyselfModel.Instance.level) + "/" + info.ReceiveLv;
        if (RechargeModel.Instance.haveDiamondValue.ContainsKey((uint)curBuyData.IndexId))
        {
            if(info.ReceiveLv > MyselfModel.Instance.level)
            {
                cell.btn.enabled = false;
                StringUtil.SetBtnTab(cell.btn, Lang.GetValue("rob_21"));
            }
            else
            {
                if(FundModel.Instance.IsGetted((uint)tabType + 1, (uint)info.Id))
                {
                    cell.btn.enabled = false;
                    StringUtil.SetBtnTab(cell.btn, Lang.GetValue("Tour_gift_txt8"));
                }
                else
                {
                    cell.btn.enabled = true;
                    StringUtil.SetBtnTab(cell.btn, Lang.GetValue("Train_txt7"));
                }
            }
        }
        else
        {
            cell.btn.enabled = false;
            StringUtil.SetBtnTab(cell.btn, Lang.GetValue("rob_21"));
        }

        cell.list.itemRenderer = (int idx, GObject reward) =>
        {
            var rewardItem = reward as fun_Fund.reward_item;
            var rewardInfo = info.ItemRewards[idx];
            var itemVo = ItemModel.Instance.GetItemByEntityID(rewardInfo.EntityID);
            rewardItem.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
            rewardItem.countLab.text = TextUtil.ChangeCoinShow(rewardInfo.Value);
            rewardItem.bg.url = ImageDataModel.Instance.GetItemQuality(itemVo.Quality);
            UILogicUtils.SetItemShow(rewardItem, itemVo.ItemDefId);
        };
        cell.list.numItems = info.ItemRewards.Length;
        cell.btn.onClick.Add(GetReward);
    }

    private void GetReward()
    {
        FundController.Instance.ReqFundReward((uint)tabType + 1);
    }
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

