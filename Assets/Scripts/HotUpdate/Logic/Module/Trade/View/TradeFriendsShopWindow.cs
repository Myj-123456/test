
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static protobuf.friend.S_MSG_TRADE_FRIEND_SHOP;
using protobuf.friend;
using ADK;
using protobuf.common;

public class TradeFriendsShopWindow : BaseView
{
    private fun_FriendsTrade_New.tradeView _view;

    private I_USER_PROFILE userInfo;
    private FRINED_SHOP stallInfo;
    private List<I_FRIEND_GRID_VO> stalls;

    private int page;

    public TradeFriendsShopWindow()
    {
        packageName = "fun_FriendsTrade_New";
        // 设置委托
        BindAllDelegate = fun_FriendsTrade_New.fun_FriendsTrade_NewBinder.BindAll;
        CreateInstanceDelegate = fun_FriendsTrade_New.tradeView.CreateInstance;
        EventManager.Instance.AddEventListener(TradeEvent.Trade, UpdateList);
    }

    public override void OnInit()
    {
        base.OnInit();
        _view = ui as fun_FriendsTrade_New.tradeView;
        SetBg(_view.bg, "Trade/ELIDA_haoyoujiaoyi_bigbg01.jpg");
        _view.status.selectedIndex = 1;
        _view.ls_sale.itemRenderer = RenderList;
        _view.ls_sale.height = _view.close_btn.y - _view.spine.y - 250;
        if (TradeModel.Instance.dealGrids.Count % 2 == 0)
        {
            page = TradeModel.Instance.dealGrids.Count / 2;
        }
        else
        {
            page = (TradeModel.Instance.dealGrids.Count + 1) / 2;
        }
        //if (_view.close_btn.y > 1162)
        //{
        //    float moveY = (_view.close_btn.y - 1162) / 2;
        //    float endY = moveY + moveY / 4;
        //    float space = (_view.close_btn.y - 1162) / 10;
        //    float height = space * 3;
        //    _view.ls_sale.y = _view.ls_sale.y + endY;
        //    _view.pos.y = _view.pos.y + endY;
        //    _view.ls_sale.height = _view.ls_sale.height + height;
        //    _view.pos.lineGap = 145 + (int)space;
        //    _view.ls_sale.lineGap = -7 + (int)space;
        //}
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        userInfo = data as I_USER_PROFILE;
        _view.lb_tradeName.text = Lang.GetValue("FriendsDeal_3", userInfo.townName);
        UpdateList();
    }

    private void UpdateList()
    {
        stallInfo = TradeModel.Instance.GetFriendShopData(userInfo.userId);
        stalls = stallInfo.grids;
        _view.ls_sale.numItems = page;
    }
    private void RenderList(int index, GObject item)
    {
        var cell = item as fun_FriendsTrade_New.trade_item;
        var starIndex = (index + 1) * 2 - 2;

        StallRenderer(starIndex, cell.item1);
        if (starIndex + 2 > TradeModel.Instance.dealGrids.Count)
        {
            cell.item2.visible = false;
        }
        else
        {
            cell.item2.visible = true;
            StallRenderer(starIndex + 1, cell.item2);
        }

    }
    private void StallRenderer(int index, GObject item)
    {
        fun_FriendsTrade_New.trade_saleItem itemCell = item as fun_FriendsTrade_New.trade_saleItem;
        int pos = index % 4;
        //itemCell.indexStatus.selectedIndex = pos > 1 ? 1 : 0;
        var stall = stalls.Find((value) => (int)value.position == (index + 1));
        itemCell.password.visible = false;
        if (stall != null)
        {
            if (stall.sellStatus == 1)
            {
                itemCell.status.selectedIndex = 0;
                itemCell.lb_count.text = stall.num.ToString();
                itemCell.lb_price.text = stall.price.ToString();
                itemCell.img_item.url = ImageDataModel.Instance.GetIconUrlByEntityId((long)stall.itemId);
                itemCell.img_gold.url = ImageDataModel.GOLD_ICON_URL;
                itemCell.data = index;
                itemCell.password.visible = stall.setPassword ? true : false;
            }
            else
            {
                itemCell.status.selectedIndex = 5;
            }
        }
        else
        {
            itemCell.status.selectedIndex = 4;
            itemCell.lockSpine.url = "wudisuo";
            itemCell.lockSpine.loop = true;
            itemCell.lockSpine.animationName = "befor";
        }
        itemCell.data = index;
        itemCell.onClick.Add(StallClickHander);
    }

    private void StallClickHander(EventContext context)
    {
        int index = (int)(context.sender as GComponent).data;
        var stall = stalls.Find((value) => (int)value.position == (index + 1));
        if (stall != null && stall.sellStatus == 1)
        {
            UIManager.Instance.OpenWindow<TradeBuyWindow>(UIName.TradeBuyWindow, new TradeBuyParams(stall, ((password) =>
            {
                if (MyselfModel.Instance.gold < stall.price * stall.num)
                {
                    UILogicUtils.ShowNotice(Lang.GetValue("common_hint_txt2"));
                    return;
                }
                TradeController.Instance.ReqTrade(stallInfo.userInfo.userId, stall.position, stall.shelfTime, password);
            })));
        }
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
        UIManager.Instance.OpenWindow<TradeFriendsListWindow>(UIName.TradeFriendsListWindow);
    }
}

