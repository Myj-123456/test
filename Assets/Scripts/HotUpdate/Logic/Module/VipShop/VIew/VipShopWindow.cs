
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using ADK;
using protobuf.misc;
using System;

public class VipShopWindow
{
    private fun_VipShop.VipShop _view;

    private float MAX_COUNT_PER_PAGE = 12;

    private List<Ft_item_vip_shopConfig> listData;
    private CountDownTimer timer;
    private CountDownTimer timer1;

    private int maxPage;
    public VipShopWindow(fun_VipShop.VipShop ui)
    {
        _view = ui;
        OnInit();
    }

    public void OnInit()
    {
        _view.titleLab.text = Lang.GetValue("shop_main_2");
        _view.tipLab.text = Lang.GetValue("Vip_store_txt3");
        _view.tipLab1.text = Lang.GetValue("shop_main_3");
        _view.pic.url = ImageDataModel.CASH_ICON_URL;
        _view.list.itemRenderer = RenderCommonSale;
        _view.list.SetVirtual();
        _view.list.scrollPane.onScrollEnd.Add(UppdateStatusBtn);
        _view.spine.loop = true;
        _view.spine.forcePlay = true;
        _view.left_btn.onClick.Add(()=>{ 
            if(_view.list.scrollPane.currentPageX > 0)
            {
                _view.list.scrollPane.SetCurrentPageX(_view.list.scrollPane.currentPageX - 1, true);
            }
        });
        _view.right_btn.onClick.Add(() => {
            if (_view.list.scrollPane.currentPageX < maxPage)
            {
                _view.list.scrollPane.SetCurrentPageX(_view.list.scrollPane.currentPageX + 1, true);
            }
        });
        _view.inputLab.onChanged.Add(() =>
        {
            UpdateList();
        });
        _view.buy_btn.onClick.Add(BuyItem);
        EventManager.Instance.AddEventListener(VipShopEvent.VipShopInfo, UpdateData);
        EventManager.Instance.AddEventListener(VipShopEvent.VipShopBuy, UpdateData);
        EventManager.Instance.AddEventListener<uint>(SystemEvent.UpdateProfile, UpdateCurrency);

       
    }

    public void OnShown()
    {
        // 其他打开面板的逻辑
        
        VipShopController.Instance.ReqVipShopInfo();
        _view.txt_gold.text = TextUtil.ChangeCoinShow(MyselfModel.Instance.diamond);

    }

    private void RenderCommonSale(int index, GObject item)
    {
        var cell = item as fun_VipShop.vip_item;
        
        //cell.vipTab.selectedIndex = MyselfModel.Instance.IsVip() ? 1 : 0;
        var shopData = listData[index];
        var shop = VipShopModel.Instance.GetVipShopData((uint)shopData.Id);
        cell.type.selectedIndex = shopData.Type;
        if(shopData.Type == 1)
        {
            if(timer1 != null)
            {
                timer1.Clear();
                timer1 = null;
            }
            var endTime = GetEndTime();
            timer1 = new CountDownTimer(cell.timeLab, endTime, true, 2);
        }
        cell.discount.text = Lang.GetValue("Discount_information_10011", shopData.Discount.ToString());
        cell.pic.url = ImageDataModel.Instance.GetIconUrlByEntityId(shopData.ItemId);
        cell.nameLab.text = ItemModel.Instance.GetNameByEntityID(shopData.ItemId.ToString());
        cell.numLab.text = shopData.ItemNum.ToString();
        cell.limitLab.text = Lang.GetValue("draw_limit_buy_2") + "（" + (shop == null ? shopData.Times : shopData.Times - shop.buyCount) + "/" + shopData.Times + "）";
        cell.costLab.text = shopData.Price.ToString();
        cell.cost_img.url = VipShopModel.Instance.GetURLByPriceType(shopData.PriceType);

        cell.buy_btn.enabled = shop == null || shopData.Times > shop.buyCount;
        cell.buy_btn.data = shopData;
        cell.buy_btn.onClick.Add(BuyItem);
    }

    private void BuyItem(EventContext context)
    {
        if (!MyselfModel.Instance.IsVip())
        {
            UILogicUtils.ShowNotice("请开启Vip");
            return;
        }
        var data = (context.sender as GObject).data as Ft_item_vip_shopConfig;
        if (VipShopModel.Instance.IsCurrencyEnough(data.PriceType, data.Price))
        {
            VipShopController.Instance.ReqVipShopBuy(data.Id);
        }
    }

    public void UpdateData()
    {
        UpdateList();
        UpdateFlower();
        //updateSaleItem(_view.propItem, VipShopModel.Instance.dailyId);
        //updateSaleItem(_view.flowerItem, VipShopModel.Instance.specialId);
    }
    private void UpdateFlower()
    {
        var vipShop = VipShopModel.Instance.GetVipShopData(VipShopModel.Instance.specialId);
        var shopData = VipShopModel.Instance.GetShopConfigData((int)VipShopModel.Instance.specialId);
        var itemVo = ItemModel.Instance.GetItemByEntityID(shopData.ItemId.ToString());
        var flowerVo = FlowerHandbookModel.Instance.GetStaticSeedCondition1(itemVo.ItemDefId);
        _view.buy_btn.data = shopData;
       var orderVo = OrderModel.Instance.GetOrderInfo(flowerVo.FlowerId);
        _view.buy_btn.enabled = vipShop == null || vipShop.buyCount < shopData.Times;
        _view.buy_btn.data = shopData;
        if(_view.spine.url == "" || _view.spine.url != flowerVo.FlowerId.ToString())
        {
            _view.spine.url = "flowers/" + flowerVo.FlowerId;
            _view.spine.animationName = "step_" + 3 + "_idle";
        }
        StringUtil.SetBtnTab(_view.buy_btn, shopData.Price.ToString());
        StringUtil.SetBtnUrl(_view.buy_btn, VipShopModel.Instance.GetURLByPriceType(shopData.PriceType));
        _view.limitLab.text = Lang.GetValue("draw_limit_buy_2") + "/" + (vipShop == null?shopData.Times:shopData.Times - vipShop.buyCount) + "/" + shopData.Times.ToString();
        if (timer != null)
        {
            timer.Clear();
            timer = null;
        }
        _view.goldlab.text = Lang.GetValue("shop_main_5") + orderVo.Gold;
        _view.cashlab.text = Lang.GetValue("shop_main_6") + orderVo.Experience;
        var endTime = shopData.EndTime - (int)ServerTime.Time;
        _view.timeLab.text = "";
        timer = new CountDownTimer(_view.timeLab, endTime,false);
        timer.prefixString = Lang.GetValue("shop_main_4");
        timer.Run();
        timer.CompleteCallBacker = () =>
        {
            _view.timeLab.text = "";
        };
    }
    private void UpdateList()
    {
        listData = VipShopModel.Instance.FilterVipShopList(_view.inputLab.text.Trim());
        maxPage = listData.Count / 6;
        _view.list.numItems = listData.Count;
        UppdateStatusBtn();
    }
    private void UppdateStatusBtn()
    {
        _view.left_btn.enabled = _view.list.scrollPane.currentPageX > 0;
        _view.right_btn.enabled = _view.list.scrollPane.currentPageX < maxPage;
        _view.pageLab.text = (_view.list.scrollPane.currentPageX + 1) + "/" + (maxPage + 1);
    }
    private void UpdateCurrency(uint itemId)
    {
        _view.txt_gold.text = TextUtil.ChangeCoinShow(MyselfModel.Instance.diamond);
    }

    private int GetEndTime()
    {
        var curTime = TimeUtil.GetDateTime(ServerTime.Time);
        var nextDay = curTime.Date.AddDays(1);
        TimeSpan timeLeft = nextDay - curTime;
        return (int)timeLeft.TotalSeconds;
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

