using System.Collections;
using System.Collections.Generic;
using ADK;
using Elida.Config;
using protobuf.card;
using protobuf.commonActivity;
using protobuf.item;
using UnityEngine;

public class DrawModel : Singleton<DrawModel>
{
    public bool isMonth_DrawActive = false;//月度抽卡是否可见
    //抽卡配置表
    private Dictionary<int,Ft_draw_configConfig> _drawMap;
    public Dictionary<int,Ft_draw_configConfig> drawMap { get
        {
            if(_drawMap == null)
            {
                var drawData = ConfigManager.Instance.GetConfig<Ft_draw_configConfigData>("ft_draw_configsConfig");
                _drawMap = drawData.DataMap;
            }
            return _drawMap;
        } }
    //活动配置表
    private Dictionary<int, Ft_game_eventConfig> _gameEventMap;
    public Dictionary<int, Ft_game_eventConfig> gameEventMap { get
        {
            if(_gameEventMap == null)
            {
                var gameEventData = ConfigManager.Instance.GetConfig<Ft_game_eventConfigData>("ft_game_eventsConfig");
                _gameEventMap = gameEventData.DataMap;
            }
            return _gameEventMap;
        } }
    //抽卡奖池
    private List<Ft_draw_poolConfig> _drawPoolList;
    public List<Ft_draw_poolConfig> drawPoolList
    { get
        {
            if(_drawPoolList == null)
            {
                var drawPoolData = ConfigManager.Instance.GetConfig<Ft_draw_poolConfigData>("ft_draw_poolsConfig");
                _drawPoolList = drawPoolData.DataList;
            }
            return _drawPoolList;
        } }
    //通用兑换
    private Dictionary<int, Ft_event_exchangeConfig> _exchangeMap;
    public Dictionary<int, Ft_event_exchangeConfig> exchangeMap { get
        {
            if(_exchangeMap == null)
            {
                var echangeData = ConfigManager.Instance.GetConfig<Ft_event_exchangeConfigData>("ft_event_exchangesConfig");
                _exchangeMap = echangeData.DataMap;
            }
            return _exchangeMap;
        } }
    //抽卡礼包商城
    private Dictionary<int, Ft_mallConfig> _mallMap;
    public Dictionary<int, Ft_mallConfig> mallMap { get
        {
            if(_mallMap == null)
            {
                var mallData = ConfigManager.Instance.GetConfig<Ft_mallConfigData>("ft_mallsConfig");
                _mallMap = mallData.DataMap;
            }
            return _mallMap;
        } }

    //月度抽卡
    public S_MSG_DRAW_INFO monthDrawData;
    public List<I_ITEM_VO> monthDrawItems;
    //砖石抽卡
    public S_MSG_DRAW_INFO diamondDrawData;
    public List<I_ITEM_VO> diamondDrawItems;
    //服装抽卡
    public S_MSG_DRAW_INFO dressDrawData;
    public List<I_ITEM_VO> dressDrawItems;


    //家具商店兑换次数统计
    public List<I_EXCHANGE_STAT> furnitureExchangeStat;

    public Ft_draw_configConfig GetDrawInfo(int id)
    {
        if (drawMap.ContainsKey(id))
        {
            return drawMap[id];
        }
        return null;
    }

    public Ft_game_eventConfig GetGameEventInfo(int id)
    {
        if (gameEventMap.ContainsKey(id))
        {
            return gameEventMap[id];
        }
        return null;
    }

    public List<Ft_game_eventConfig> GetGameEventList(ActivityType type)
    {
        var listData = new List<Ft_game_eventConfig>();
        foreach(var value in gameEventMap)
        {
            if(value.Value.Type == (int)type)
            {
                listData.Add(value.Value);
            }
        }
        return listData;
    }

    public Ft_draw_poolConfig GetDrawPoolInfo(int id)
    {
        return drawPoolList.Find(value => value.Id == id);
    }
    public Module_item_defConfig GetBigItem(int eventId)
    {
       var poolInfo = drawPoolList.FindAll(value => value.EventId == eventId);
        var item = poolInfo.Find(value => value.IsBig == 1);
        if(item != null)
        {
            var itemVo = ItemModel.Instance.GetItemByEntityID(item.PoolItems[0].EntityID);
            return itemVo;
        }
        return null;
    }

    public Ft_event_exchangeConfig GetExchangeInfo(int id)
    {
        if (exchangeMap.ContainsKey(id))
        {
            return exchangeMap[id];
        }
        return null;
    }

    public List<Ft_event_exchangeConfig> GetExchangeList(int eventId)
    {
        var listData = new List<Ft_event_exchangeConfig>();
        foreach (var value in exchangeMap)
        {
            if(eventId == value.Value.EventId)
            {
                listData.Add(value.Value);
            }
        }
        return listData;
    }

    public List<Ft_mallConfig> GetMallList(int eventId)
    {
        var listData = new List<Ft_mallConfig>();
        foreach(var value in mallMap)
        {
            if(value.Value.Event == eventId)
            {
                listData.Add(value.Value);
            }
        }
        return listData;
    }

    public bool IsActivityOpen(ActivityType type)
    {
        var activityData = GetGameEventList(type);
        if(activityData.Count == 1)
        {
            var endTime = TimeUtil.GetNumericTime(activityData[0].WeixinEndTime);
            var startTime = TimeUtil.GetNumericTime(activityData[0].WeixinTriggerTime);
            return ServerTime.Time >= startTime && ServerTime.Time <= endTime;
        }
        else
        {
            var bol = false;
            foreach(var value in activityData)
            {
                var endTime = TimeUtil.GetNumericTime(value.WeixinEndTime);
                var startTime = TimeUtil.GetNumericTime(value.WeixinTriggerTime);
                if(ServerTime.Time >= startTime && ServerTime.Time <= endTime)
                {
                    bol = true;
                    break;
                }
            }
            return bol;
        }
    }

    public int GetActivityId(ActivityType type)
    {
        var activityData = GetGameEventList(type);
        var id = -1;
        foreach (var value in activityData)
        {
            var endTime = TimeUtil.GetNumericTime(value.WeixinEndTime);
            var startTime = TimeUtil.GetNumericTime(value.WeixinTriggerTime);
            if (ServerTime.Time >= startTime && ServerTime.Time <= endTime)
            {
                id = value.IndexId;
                break;
            }
        }
        return id;
    }

    public void UpdateExchangeData(I_EXCHANGE_STAT data)
    {
        var exchange = furnitureExchangeStat.Find(value => value.exchangeId == data.exchangeId);
        if(exchange != null)
        {
            exchange.cnt = data.cnt;
        }
        else
        {
            furnitureExchangeStat.Add(data);
        }
    }

    public int GetExchangeCount(uint id)
    {
        var exchange = furnitureExchangeStat.Find(value => value.exchangeId == id);
        if (exchange != null)
        {
            return (int)exchange.cnt;
        }
        return 0;
    }
}

public enum ActivityType
{
    Contract = 20,//合约
    Month_Draw = 43,//月度抽卡沿用活动类型
    Dress_Draw = 44,//衣服抽卡使用活动类型
    Diamond_Draw = 45,//钻石抽卡使用活动类  
}
//客户端维护
public enum ExchangeType
{
    Furniture_Shop = 1,//家具商店
    Month_Draw = 43,//月度抽卡沿用活动类型
    Dress_Draw = 44,//衣服抽卡使用活动类型
    Diamond_Draw = 45,//钻石抽卡使用活动类  
}

