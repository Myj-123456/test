using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using ADK;
using Elida.Config;

public class OtherShopView
{
    public int eventId = 17000035;
    private fun_VipShop.OtherView view;
    private List<Ft_event_exchangeConfig> listData;
    public OtherShopView(fun_VipShop.OtherView ui)
    {
        view = ui;
        view.list.itemRenderer = RenderList;
        listData = DrawModel.Instance.GetExchangeList(eventId);
        EventManager.Instance.AddEventListener(ExhcangeEvent.FurnitureShop, UpdateData);
    }

    public void OnShown()
    {
        UpdateData();
    }
    private void UpdateData()
    {
        view.list.numItems = listData.Count;
    }
    private void RenderList(int index,GObject item)
    {
        var cell = item as fun_VipShop.ShopItemRender;
        var info = listData[index];
        
        var costItem = ItemModel.Instance.GetItemByEntityID(info.Expends[0].EntityID);
        StringUtil.SetBtnUrl(cell.buy_btn, ImageDataModel.Instance.GetIconUrl(costItem));
        StringUtil.SetBtnTab(cell.buy_btn, info.Expends[0].Value.ToString());
        var itemVo = ItemModel.Instance.GetItemByEntityID(info.Rewards[0].EntityID);
        cell.img.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        cell.countLab.text = info.Rewards[0].Value.ToString();
        
        cell.name_txt.text = Lang.GetValue(itemVo.Name);
        var count = DrawModel.Instance.GetExchangeCount((uint)info.Id);
        if (info.LimitConfigs[0] == 1)
        {
            var oddCount = info.LimitConfigs[1] - count;
            cell.limitLab.text = Lang.GetValue("Treasure_headline10") + "£º" + oddCount + "/" + info.LimitConfigs[1];
            cell.buy_btn.enabled = oddCount > 0;
        }
        else if(info.LimitConfigs[0] == 2)
        {
            var oddCount = info.LimitConfigs[1] - count;
            cell.limitLab.text = Lang.GetValue("draw_limit_buy_1") + "£º" + oddCount + "/" + info.LimitConfigs[1];
            cell.buy_btn.enabled = oddCount > 0;
        }else if(info.LimitConfigs[0] == 3)
        {
            var oddCount = info.LimitConfigs[1] - count;
            cell.limitLab.text = Lang.GetValue("draw_limit_buy_2") + "£º" + oddCount + "/" + info.LimitConfigs[1];
            cell.buy_btn.enabled = oddCount > 0;
        }
        else
        {
            cell.limitLab.text = ""; 
            cell.buy_btn.enabled = true;
        }
        cell.buy_btn.data = info;
        cell.buy_btn.onClick.Add(BuyClick);
    }

    private void BuyClick(EventContext context)
    {
        var info = (context.sender as GComponent).data as Ft_event_exchangeConfig;
        var costItem = ItemModel.Instance.GetItemByEntityID(info.Expends[0].EntityID);
        var costNum = StorageModel.Instance.GetItemCount(info.Expends[0].EntityID);
        if(costNum < info.Expends[0].Value)
        {
            UILogicUtils.ShowNotice(Lang.GetValue(costItem.Name) + Lang.GetValue("text_grandma14"));
            return;
        }
        DrawController.Instance.ReqCommonExchange((uint)SysId.Furniture_Shop, (uint)info.Id, (uint)ExchangeType.Furniture_Shop);
    }
}
