
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static protobuf.friend.S_MSG_TRADE_FRIEND_SHOP;
using ADK;
using protobuf.common;

public class TradeFriendsListWindow : BaseWindow
{
    private fun_FriendsTrade_New.tradeFriendsListView _view;
    private List<FRINED_SHOP> listData;
    private string filterName;

    public TradeFriendsListWindow()
    {
        packageName = "fun_FriendsTrade_New";
        // 设置委托
        BindAllDelegate = fun_FriendsTrade_New.fun_FriendsTrade_NewBinder.BindAll;
        CreateInstanceDelegate = fun_FriendsTrade_New.tradeFriendsListView.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        _view = ui as fun_FriendsTrade_New.tradeFriendsListView;

        SetBg(_view.bg, "Common/ELIDA_common_bigdi01.png");
        StringUtil.SetBtnTab(_view.findBtn, Lang.GetValue("pray_8"));
        //_view.title.text = Lang.GetValue("trade_friends");
        _view.list.itemRenderer = FriendItemRenderer;
        _view.list.SetVirtual();
        StringUtil.SetBtnTab(_view.tip, "暂无好友交易");
        _view.findBtn.onClick.Add(() =>
        {
            filterName = _view.inputLab.text.Trim();
            UpdateList();
        });

        EventManager.Instance.AddEventListener(TradeEvent.TradeFriendShop, UpdateList);
        EventManager.Instance.AddEventListener(TradeEvent.Trade, UpdateList);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        filterName = "";
        TradeController.Instance.ReqTradeFriendShop();
    }
    private void UpdateList()
    {
        var friendShopList = TradeModel.Instance.GetFriendShopList();
        listData = friendShopList.FindAll((value) =>
        {
            if (filterName == "")
            {
                return true;
            }
            else
            {
                string name = value.userInfo.townName;
                if (name.Contains(filterName))
                {
                    return true;
                }
            }
            return false;

        });
        _view.list.numItems = listData.Count;
        _view.list.scrollPane.ScrollTop();
        _view.tip.visible = listData.Count <= 0;
    }

    private void FriendItemRenderer(int index, GObject item)
    {
        fun_FriendsTrade_New.tradeFriendCell cell = item as fun_FriendsTrade_New.tradeFriendCell;
        var userInfo = listData[index].userInfo;
        var grids = listData[index].grids;
        var head = cell.head as common_New.MoonFestivalHead;
        head.pic.url = "Avatar/ELIDA_common_touxiangdi01.png";
        
        cell.txt_lv.text = userInfo.userLevel.ToString();
        cell.lb_userName.text = userInfo.townName;
        StringUtil.SetBtnTab(cell.btn_comeIn, Lang.GetValue("FriendsDeal_18"));
        cell.ls_items.itemRenderer = ((int index, GObject items) =>
        {
            fun_FriendsTrade_New.tradeFriendItemsCell itemsCell = items as fun_FriendsTrade_New.tradeFriendItemsCell;
            itemsCell.img_item.url = "";
            itemsCell.password.visible = false;
            var stall = grids.Find((value) => (int)value.position == (index + 1));
            if (stall != null)
            {
                if (stall.sellStatus == 1)
                {
                    itemsCell.img_item.url = ImageDataModel.Instance.GetIconUrlByItemId((long)stall.itemId);
                    itemsCell.password.visible = stall.setPassword;
                }
                itemsCell.status.selectedIndex = 0;

            }
            else
            {
                itemsCell.status.selectedIndex = 1;
            }
        });
        cell.ls_items.numItems = 8;
        cell.btn_comeIn.data = userInfo;
        cell.btn_comeIn.onClick.Add(ComeInClickHander);
    }

    private void ComeInClickHander(EventContext context)
    {
        I_USER_PROFILE userInfo = (context.sender as GComponent).data as I_USER_PROFILE;
        UIManager.Instance.OpenPanel<TradeFriendsShopWindow>(UIName.TradeFriendsShopWindow, UILayer.UI, userInfo);
        UIManager.Instance.CloseWindow(UIName.TradeFriendsListWindow);
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

