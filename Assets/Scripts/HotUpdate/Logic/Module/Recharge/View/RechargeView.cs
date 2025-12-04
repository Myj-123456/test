
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using ADK;
using System;

public class RechargeView
{
   private fun_Recharge.newRecharge view;
    
   public RechargeView(fun_Recharge.newRecharge ui)
    {
        view = ui;
        view.revharge.y = view.n25.y + 349;
        view.revharge.height = view.rect.y - view.n25.y - 452;
        if(view.revharge.height > 1061)
        {
            view.revharge.height = 1061;
        }
        OnInit();
    }

    public void OnInit()
    {
        view.revharge.buy_list.itemRenderer = CashItemRender;
        
        EventManager.Instance.AddEventListener(RechargeEvent.haveDiamondPay, UpdateList);
        EventManager.Instance.AddEventListener(RechargeEvent.HaveGamePay, UpdateList);
        EventManager.Instance.AddEventListener(RechargeEvent.RechargeInfo, UpdateList);
        view.spine.url = "beijing";
        view.spine.loop = true;
        view.spine.animationName = "idle";
        
    }

    public void OnShown()
    {
        UpdateList();
    }
    private void UpdateList()
    {
        view.revharge.buy_list.numItems = RechargeModel.Instance.gamePayList.Count;
        
    }

    private void CashItemRender(int index, GObject item)
    {
        var cell = item as fun_Recharge.newRecharge_cell;
        var data = RechargeModel.Instance.gamePayList[index];
        cell.img_loader.url = "Recharge/" + data.Resource + ".png";
        cell.txt_value.text = (data.Type == 1? Lang.GetValue("gem"): Lang.GetValue("gold")) + "*" + data.Count;
        cell.costLab.text = "￥" + (int)data.Price;
        cell.costLab1.text = "￥" + (int)data.Price;
        if (RechargeModel.Instance.gamePay.threeBuyId == 0 && data.IsThree > 0)
        {
            cell.preferentialTab.selectedIndex = 1;
            cell.spine1.url = "shouchong";
            cell.spine1.loop = true;
            cell.spine1.animationName = "idle";
            cell.double_txt_value.text = "+" + data.IsThree;
            cell.extraTxt.text = Lang.GetValue("recharge_main_24");
        }
        else
        {
            if(RechargeModel.Instance.gamePay.buyIds != null && Array.IndexOf(RechargeModel.Instance.gamePay.buyIds,uint.Parse(data.ProductId)) != -1)
            {
                cell.preferentialTab.selectedIndex = 0;
            }
            else
            {
                cell.double_txt_value.text = "+" + data.FirstExtraGive;
                cell.extraTxt.text = Lang.GetValue("title_recharge4");
                cell.preferentialTab.selectedIndex = 1;
                cell.spine1.url = "shouchong";
                cell.spine1.loop = true;
                cell.spine1.animationName = "idle";
            }
            
        }
        if(data.Price == 88 || data.Price == 128 || data.Price == 648)
        {
            cell.spine.url = data.Price.ToString();
            cell.spine.loop = true;
            cell.spine.animationName = "idle";
        }
        cell.data = data;
        cell.onClick.Add(BuyCash);
    }
    private void BuyCash(EventContext context)
    {
        var buyData = (context.sender as GComponent).data as Ft_game_payConfig;
        RechargeController.Instance.ReqPlaceOrder(3, uint.Parse(buyData.ProductId));
    }
}

