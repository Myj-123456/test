using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using protobuf.cultivateshop;
using System;
using System.Linq;

public class CultivationShopWindow
{
   private fun_VipShop.ShopView _view;
    private CountDownTimer timer;

   public CultivationShopWindow(fun_VipShop.ShopView ui)
    {
        _view = ui;
        OnInit();
    }

    public void OnInit()
    {
        _view.titleLab.text = Lang.GetValue("cultivate_shop_04");
        StringUtil.SetBtnTab(_view.pay_btn, Lang.GetValue("Vip_function7"));
        StringUtil.SetBtnTab(_view.refresh_btn, Lang.GetValue("MarketOrder_txt9"));

        _view.list.itemRenderer = ItemRender;

        _view.pay_btn.onClick.Add(Refresh);
        _view.refresh_btn.onClick.Add(Refresh);

        EventManager.Instance.AddEventListener(CultivationShopEvent.CultivateRefresh, UpdateData);
        EventManager.Instance.AddEventListener(CultivationShopEvent.ReqCultivateBuy, UpdateList);
        EventManager.Instance.AddEventListener<uint>(SystemEvent.UpdateProfile, UpdateCurrency);
    }

    private void Refresh()
    {
        CultivationShopController.Instance.ReqCultivateRefresh();
    }
    public void OnShown()
    {
        // 其他打开面板的逻辑
        CultivationShopController.Instance.ReqCultivateShop();
        _view.txt_gold.text = TextUtil.ChangeCoinShow(MyselfModel.Instance.gold);
    }

    public void UpdateData()
    {
        if(timer != null)
        {
            timer.Clear();
            timer = null;
        }
        int time = ((int)CultivationShopModel.Instance.refreshTime + CultivationShopModel.Instance.refrushTimeGap) - (int)ServerTime.Time;
        timer = new CountDownTimer(_view.time_txt, time,false,2);
        
        timer.suffixString = Lang.GetValue("cultivate_shop_01");
        timer.Run();
        timer.CompleteCallBacker = () =>
        {
            CultivationShopController.Instance.ReqCultivateRefresh();
        };
        int refreshCnt = CultivationShopModel.Instance.freeMaxTime > CultivationShopModel.Instance.refreshCnt ? (int)CultivationShopModel.Instance.freeMaxTime - (int)CultivationShopModel.Instance.refreshCnt : 0;
        _view.refreshLab.text = Lang.GetValue("guildStore_24") + "：" + refreshCnt + "/" + CultivationShopModel.Instance.freeMaxTime;
        if (CultivationShopModel.Instance.refreshCnt >= CultivationShopModel.Instance.freeMaxTime)
        {
            _view.pay_btn.visible = true;
            _view.refresh_btn.visible = false;
            int payLv = (int)CultivationShopModel.Instance.refreshCnt - (int)CultivationShopModel.Instance.freeMaxTime;
            
            if (payLv >= 0)
            {
                payLv = Math.Min(payLv, GlobalModel.Instance.module_profileConfig.costItem.Count - 1);
                var vo = GlobalModel.Instance.module_profileConfig.costItem[payLv];
                StringUtil.SetBtnUrl(_view.pay_btn, ImageDataModel.Instance.GetIconUrlByEntityId(vo.ToList()[0].Key));
                StringUtil.SetBtnTab(_view.pay_btn, vo.ToList()[0].Value.ToString());
                if((int)MyselfModel.Instance.diamond < vo.ToList()[0].Value)
                {
                    _view.pay_btn.enabled = false;
                }
                else
                {
                    _view.pay_btn.enabled = true;
                }
            }
        }
        else
        {
            _view.pay_btn.visible = false;
            _view.refresh_btn.visible = true;
        }
        UpdateList();
    }

    public void UpdateList()
    {
        _view.list.numItems = CultivationShopModel.Instance.cultivateShops.Count;
    }

    private void ItemRender(int index,GObject item)
    {
        fun_VipShop.ShopItemRender cell = item as fun_VipShop.ShopItemRender;
        var data = CultivationShopModel.Instance.cultivateShops[index];
        //(cell.sold_txt as common.nullTips).emptyText.text = Lang.GetValue("slang_124");//已出售
        var vo = CultivationShopModel.Instance.breedShopMap[(int)data.itemId];
        //StringUtil.SetBtnTab(cell.getted, Lang.GetValue("guildStore_28"));
        var itemData = ItemModel.Instance.GetItemByEntityID(vo.GetItem.ToString());
        cell.name_txt.text = Lang.GetValue(itemData.Name);
        cell.img.url = ImageDataModel.Instance.GetIconUrlByEntityId(vo.GetItem);
        cell.bg.url = ImageDataModel.Instance.GetItemQuality(itemData.Quality);
        int count = StorageModel.Instance.GetItemCount(vo.GetItem.ToString());
        //cell.group_count.visible = false;
        if (count > 0)
        {
            //cell.group_count.visible = true;
            //cell.count_txt.text = Lang.GetValue("Vip_store_txt5")+ "：" + count + "";
            //cell.pic.url = ImageDataModel.Instance.GetIconUrlByEntityId(vo.GetItem);
        }
        cell.buy_btn.data = data;
        StringUtil.SetBtnTab(cell.buy_btn, (data.itemCnt * data.price).ToString());
        StringUtil.SetBtnUrl(cell.buy_btn, ImageDataModel.Instance.GetIconUrlByEntityId(vo.CostItem));
        cell.sell.selectedIndex = (int)data.isBuy;
        cell.countLab.text = data.itemCnt.ToString();
        //cell.buy_btn.enabled = data.isBuy == 0;
        cell.limitLab.text = Lang.GetValue("draw_limit_buy_2") + "：" + (data.isBuy == 0 ? 1 : 0) + "/1";
        cell.img.grayed = data.isBuy == 1;
        cell.buy_btn.onClick.Add(BuyHandler);
    }

    public void BuyHandler(EventContext context)
    {
        I_SHOP_ITEM data = (context.sender as GComponent).data as I_SHOP_ITEM;
        if(MyselfModel.Instance.gold < (data.itemCnt * data.price))
        {
            UILogicUtils.ShowNotice(Lang.GetValue("common_hint_txt2"));
            return;
        }
        CultivationShopController.Instance.ReqCultivateBuy(data.position);
    }
    private void UpdateCurrency(uint itemId)
    {
        _view.txt_gold.text = TextUtil.ChangeCoinShow(MyselfModel.Instance.gold);
    }
    public void OnHide()
    {
        if (timer != null)
        {
            timer.Clear();
            timer = null;
        }
    }
}

