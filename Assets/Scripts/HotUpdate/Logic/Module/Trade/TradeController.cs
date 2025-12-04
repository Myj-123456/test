using System.Collections;
using System.Collections.Generic;
using protobuf.friend;
using protobuf.messagecode;
using UnityEngine;

public class TradeController : BaseController<TradeController>
{
    protected override void InitListeners()
    {
        AddNetListener<S_MSG_TRADE_INFORMATION>((int)MessageCode.S_MSG_TRADE_INFORMATION, TradeInfomation);
        AddNetListener<S_MSG_TRADE_UNLOCK>((int)MessageCode.S_MSG_TRADE_UNLOCK, TradeUnlock);
        AddNetListener<S_MSG_TRADE_UPPER_SHELF>((int)MessageCode.S_MSG_TRADE_UPPER_SHELF, TradeUpperShelf);
        AddNetListener<S_MSG_TRADE_DOWN_SHELF>((int)MessageCode.S_MSG_TRADE_DOWN_SHELF, TradeDownShelf);
        AddNetListener<S_MSG_MESSAGE>((int)MessageCode.S_MSG_MESSAGE, Message);
        AddNetListener<S_MSG_TRADE_FRIEND_SHOP>((int)MessageCode.S_MSG_TRADE_FRIEND_SHOP, TradeFriendShop);
        AddNetListener<S_MSG_TRADE>((int)MessageCode.S_MSG_TRADE, Trade);
        AddNetListener<S_MSG_TRADE_BUY_SHELFTIMES>((int)MessageCode.S_MSG_TRADE_BUY_SHELFTIMES, TradeBuyShelftimes);
        //好友助力
        AddNetListener<S_MSG_TRADE_HELP>((int)MessageCode.S_MSG_TRADE_HELP, TradeHelp);
    }
    //概览
    public void TradeInfomation(S_MSG_TRADE_INFORMATION data)
    {
        TradeModel.Instance.grids = data.grids;
        TradeModel.Instance.tradeGoldCnt = data.tradeGoldCnt;
        //TradeModel.Instance.help = data.help == null ? new Dictionary<uint, uint>() : data.help;
        if (data.items != null)
        {
            StorageModel.Instance.AddToStorageItems(data.items);
        }
        if (data.backItems != null)
        {
            StorageModel.Instance.AddToStorageItems(data.backItems);
        }


        EventManager.Instance.DispatchEvent(TradeEvent.TradeInfomation);
    }

    public void ReqTradeInfomation()
    {
        C_MSG_TRADE_INFORMATION c_MSG_TRADE_INFORMATION = new C_MSG_TRADE_INFORMATION();
        SendCmd((int)MessageCode.C_MSG_TRADE_INFORMATION, c_MSG_TRADE_INFORMATION);
    }


    public void TradeUnlock(S_MSG_TRADE_UNLOCK data)
    {
        TradeModel.Instance.grids.Add(data.grid);
        EventManager.Instance.DispatchEvent(TradeEvent.TradeUnlock, (int)data.grid.position);

    }

    public void ReqTradeUnlock(uint position)
    {
        C_MSG_TRADE_UNLOCK c_MSG_TRADE_UNLOCK = new C_MSG_TRADE_UNLOCK();
        c_MSG_TRADE_UNLOCK.position = position;
        SendCmd((int)MessageCode.C_MSG_TRADE_UNLOCK, c_MSG_TRADE_UNLOCK);
    }
    //上架
    public void TradeUpperShelf(S_MSG_TRADE_UPPER_SHELF data)
    {
        TradeModel.Instance.UpdateGridData(data.grid);
        MyselfModel.Instance.behaviorDaily.tradePasswordCnt = data.tradePasswordCnt;
        StorageModel.Instance.AddToStorageByItemId((int)data.grid.itemId, -(int)data.grid.num);
        EventManager.Instance.DispatchEvent(TradeEvent.TradeUpperShelf);
    }

    public void ReqTradeUpperShelf(uint position, uint itemId, uint num, uint price, string password)
    {
        C_MSG_TRADE_UPPER_SHELF c_MSG_TRADE_UPPER_SHELF = new C_MSG_TRADE_UPPER_SHELF();
        c_MSG_TRADE_UPPER_SHELF.position = position;
        c_MSG_TRADE_UPPER_SHELF.itemId = itemId;
        c_MSG_TRADE_UPPER_SHELF.num = num;
        c_MSG_TRADE_UPPER_SHELF.price = price;
        c_MSG_TRADE_UPPER_SHELF.password = password;
        SendCmd((int)MessageCode.C_MSG_TRADE_UPPER_SHELF, c_MSG_TRADE_UPPER_SHELF);
    }
    //下架
    public void TradeDownShelf(S_MSG_TRADE_DOWN_SHELF data)
    {
        var stall = TradeModel.Instance.GetGridData(data.grid.position);
        StorageModel.Instance.AddToStorageByItemId((int)stall.itemId, (int)stall.num);
        TradeModel.Instance.UpdateGridData(data.grid);
        EventManager.Instance.DispatchEvent(TradeEvent.TradeUpperShelf);
    }

    public void ReqTradeDownShelf(uint position)
    {
        C_MSG_TRADE_DOWN_SHELF c_MSG_TRADE_DOWN_SHELF = new C_MSG_TRADE_DOWN_SHELF();
        c_MSG_TRADE_DOWN_SHELF.position = position;
        SendCmd((int)MessageCode.C_MSG_TRADE_DOWN_SHELF, c_MSG_TRADE_DOWN_SHELF);
    }
    //交易消息
    public void Message(S_MSG_MESSAGE data)
    {
        TradeModel.Instance.messageList = data.messageList;
        EventManager.Instance.DispatchEvent(TradeEvent.Message);
    }

    public void ReqMessage()
    {
        C_MSG_MESSAGE c_MSG_MESSAGE = new C_MSG_MESSAGE();
        SendCmd((int)MessageCode.C_MSG_MESSAGE, c_MSG_MESSAGE);
    }
    //好友店铺信息
    public void TradeFriendShop(S_MSG_TRADE_FRIEND_SHOP data)
    {
        TradeModel.Instance.friendGrids = data.friendGrids;
        EventManager.Instance.DispatchEvent(TradeEvent.TradeFriendShop);
    }

    public void ReqTradeFriendShop()
    {
        C_MSG_TRADE_FRIEND_SHOP c_MSG_TRADE_FRIEND_SHOP = new C_MSG_TRADE_FRIEND_SHOP();
        SendCmd((int)MessageCode.C_MSG_TRADE_FRIEND_SHOP, c_MSG_TRADE_FRIEND_SHOP);
    }

    //交易
    public void Trade(S_MSG_TRADE data)
    {
        var friendShop = TradeModel.Instance.GetFriendShopData(data.targetUserId);
        var stall = friendShop.grids.Find((value) => value.position == data.grid.position);
        //StorageModel.Instance.AddToStorageByItemId((int)stall.itemId, (int)stall.num);
        TradeModel.Instance.UpdateFriendShop(data.targetUserId, data.grid);
        DropManager.ShowDropItem((int)stall.itemId, (int)stall.num);
        EventManager.Instance.DispatchEvent(TradeEvent.Trade);
    }

    public void ReqTrade(uint targetUserId, uint position, uint shelfTime, string password)
    {
        C_MSG_TRADE c_MSG_TRADE = new C_MSG_TRADE();
        c_MSG_TRADE.targetUserId = targetUserId;
        c_MSG_TRADE.position = position;
        c_MSG_TRADE.shelfTime = shelfTime;
        c_MSG_TRADE.password = password;
        SendCmd((int)MessageCode.C_MSG_TRADE, c_MSG_TRADE);
    }

    //购买上架次数
    public void TradeBuyShelftimes(S_MSG_TRADE_BUY_SHELFTIMES data)
    {
        TradeModel.Instance.UpdateGridData(data.grid);
        EventManager.Instance.DispatchEvent(TradeEvent.TradeUnlock);
    }

    public void ReqTradeBuyShelftimes(uint position)
    {
        C_MSG_TRADE_BUY_SHELFTIMES c_MSG_TRADE_BUY_SHELFTIMES = new C_MSG_TRADE_BUY_SHELFTIMES();
        c_MSG_TRADE_BUY_SHELFTIMES.position = position;
        SendCmd((int)MessageCode.C_MSG_TRADE_BUY_SHELFTIMES, c_MSG_TRADE_BUY_SHELFTIMES);
    }

    public void TradeHelp(S_MSG_TRADE_HELP data)
    {
        TradeModel.Instance.UpdateHelpTimes(data.position, data.helpCnt);
        EventManager.Instance.DispatchEvent(TradeEvent.TradeHelp);
    }

    public void ReqTradeHelp(uint pos)
    {
        C_MSG_TRADE_HELP c_MSG_HELP = new C_MSG_TRADE_HELP();
        c_MSG_HELP.position = pos;
        SendCmd((int)MessageCode.C_MSG_TRADE_HELP, c_MSG_HELP);
    }
}
