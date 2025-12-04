using System;
using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using protobuf.friend;
using UnityEngine;
using static protobuf.friend.S_MSG_TRADE_FRIEND_SHOP;

public class TradeModel : Singleton<TradeModel>
{
    public List<I_GRID_VO> grids;//位置信息
    public List<FRINED_SHOP> friendGrids;//好友店铺信息

    public List<I_MESSAGE_LOG> messageList;//交易消息
    public uint tradeGoldCnt;//通过好友交易获得的金币数量

    public Dictionary<uint, uint> help;

    private Dictionary<int, Ft_friends_deal_gridConfig> _dealGrids;
    public Dictionary<int, Ft_friends_deal_gridConfig> dealGrids
    {
        get
        {
            if (_dealGrids == null)
            {
                Ft_friends_deal_gridConfigData gridConfig = ConfigManager.Instance.GetConfig<Ft_friends_deal_gridConfigData>("ft_friends_deal_gridsConfig");
                _dealGrids = gridConfig.DataMap;
            }
            return _dealGrids;
        }
    }

    private List<Ft_friends_deal_itemsConfig> _dealItems;
    public List<Ft_friends_deal_itemsConfig> dealItems
    {
        get
        {
            if (_dealItems == null)
            {
                Ft_friends_deal_itemsConfigData itemsConfig = ConfigManager.Instance.GetConfig<Ft_friends_deal_itemsConfigData>("ft_friends_deal_itemssConfig");
                _dealItems = itemsConfig.DataList;
            }
            return _dealItems;
        }
    }
    public I_GRID_VO GetGridData(uint pos)
    {
        return grids.Find((value) => value.position == pos);
    }

    public FRINED_SHOP GetFriendShopData(uint userId)
    {
        return friendGrids.Find((value) => value.userInfo.userId == userId);
    }

    public void UpdateFriendShop(uint targetUserId, I_FRIEND_GRID_VO grid)
    {
        var friendShop = GetFriendShopData(targetUserId);
        int index = -1;
        for (int i = 0; i < friendShop.grids.Count; i++)
        {
            if (friendShop.grids[i].position == grid.position)
            {
                index = i;
                break;
            }
        }
        if (index != -1)
        {
            friendShop.grids[index] = grid;
        }
    }

    public List<FRINED_SHOP> GetFriendShopList()
    {
        return friendGrids.FindAll((value) =>
        {
            foreach (var grid in value.grids)
            {
                if (grid.sellStatus == 1)
                {
                    return true;
                }
            }
            return false;
        });
    }


    public Ft_friends_deal_itemsConfig GetDealItemsData(int itemId)
    {
        return dealItems.Find((value) => value.ItemId == itemId);
    }
    public void UpdateGridData(I_GRID_VO data)
    {
        int index = GetGridIndex(data.position);
        if (index == -1) return;
        grids[index] = data;
    }

    public int GetGridIndex(uint pos)
    {
        for (int i = 0; i < grids.Count; i++)
        {
            if (grids[i].position == pos)
            {
                return i;
            }
        }
        return -1;
    }

    public int GetHelpTimes(int pos)
    {
        if (help.ContainsKey((uint)pos))
        {
            return (int)help[(uint)pos];
        }
        return 0;
    }

    public void UpdateHelpTimes(uint pos, uint helpCnt)
    {
        if (help.ContainsKey(pos))
        {
            help[pos] = helpCnt;
        }
        else
        {
            help.Add(pos, helpCnt);
        }
    }
}

public class TradeBuyParams
{
    public I_FRIEND_GRID_VO stall;
    public CallbackDelegate fun;
    public Action closeFun;
    public TradeBuyParams(I_FRIEND_GRID_VO stall, CallbackDelegate fun, Action closeFun = null)
    {
        this.stall = stall;
        this.fun = fun;
        this.closeFun = closeFun;
    }
}

public delegate void CallbackDelegate(string password);

