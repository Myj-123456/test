using System.Collections;
using System.Collections.Generic;
using ADK;
using protobuf.card;
using protobuf.commonActivity;
using protobuf.messagecode;
using UnityEngine;

public class DrawController : BaseController<DrawController>
{
    protected override void InitListeners()
    {
        //抽卡活动信息
        AddNetListener<S_MSG_DRAW_INFO>((int)MessageCode.S_MSG_DRAW_INFO, DrawInfo);
        //抽卡
        AddNetListener<S_MSG_DRAW_CARD>((int)MessageCode.S_MSG_DRAW_CARD, DrawCard);
        //兑换道具
        AddNetListener<S_MSG_COMMONACTIVITY_EXCHANGE>((int)MessageCode.S_MSG_COMMONACTIVITY_EXCHANGE, CommonExchange);

    }
    //抽卡活动信息
    public void DrawInfo(S_MSG_DRAW_INFO data)
    {
        var activityInfo = DrawModel.Instance.GetGameEventInfo((int)data.drawInfo.activityId);
        if(activityInfo.Type == (int)ActivityType.Month_Draw)
        {
            DrawModel.Instance.monthDrawData = data;
            DispatchEvent(ActivityEvent.MonthDraw);
        }
        else if (activityInfo.Type == (int)ActivityType.Diamond_Draw)
        {
            DrawModel.Instance.diamondDrawData = data;
            DispatchEvent(ActivityEvent.DiamondDraw);
        }
        else if (activityInfo.Type == (int)ActivityType.Dress_Draw)
        {
            DrawModel.Instance.dressDrawData = data;
            DispatchEvent(ActivityEvent.DressDraw);
        }
    }

    public void ReqDrawInfo(uint activityId)
    {
        C_MSG_DRAW_INFO c_MSG_DRAW_INFO = new C_MSG_DRAW_INFO();
        c_MSG_DRAW_INFO.activityId = activityId;
        SendCmd((int)MessageCode.C_MSG_DRAW_INFO, c_MSG_DRAW_INFO);
    }
    //抽卡
    public void DrawCard(S_MSG_DRAW_CARD data)
    {
        StorageModel.Instance.AddToStorage(data.items);
        StorageModel.Instance.OddToStorageItems(data.items);
        var activityInfo = DrawModel.Instance.GetGameEventInfo((int)data.activityId);
        if (activityInfo.Type == (int)ActivityType.Month_Draw)
        {
            DrawModel.Instance.monthDrawItems = data.itemList;
            DrawModel.Instance.monthDrawData.drawInfo.luckyValue = data.luckyValue;
            DispatchEvent(ActivityEvent.MonthDraw);
        }
        else if (activityInfo.Type == (int)ActivityType.Diamond_Draw)
        {
            DrawModel.Instance.diamondDrawItems = data.itemList;
            DrawModel.Instance.diamondDrawData.drawInfo.luckyValue = data.luckyValue;
            DispatchEvent(ActivityEvent.DiamondDraw);
        }
        else if (activityInfo.Type == (int)ActivityType.Dress_Draw)
        {
            DrawModel.Instance.dressDrawItems = data.itemList;
            DrawModel.Instance.dressDrawData.drawInfo.luckyValue = data.luckyValue;
            DispatchEvent(ActivityEvent.DressDraw);
        }
        UIManager.Instance.OpenWindow<DressCallResultWindow>(UIName.DressCallResultWindow, data.itemList);
    }

    public void ReqDrawCard(uint activityId,uint num)
    {
        C_MSG_DRAW_CARD c_MSG_DRAW_CARD = new C_MSG_DRAW_CARD();
        c_MSG_DRAW_CARD.activityId = activityId;
        c_MSG_DRAW_CARD.num = num;
        SendCmd((int)MessageCode.C_MSG_DRAW_CARD, c_MSG_DRAW_CARD);
    }

    public void CommonExchange(S_MSG_COMMONACTIVITY_EXCHANGE data)
    {
        var exhcangeInfo = DrawModel.Instance.GetExchangeInfo((int)data.exchangeId);
        var costItems = new Dictionary<ulong, ulong>();
        foreach(var value in exhcangeInfo.Expends)
        {
            costItems.Add(ulong.Parse(value.EntityID), (ulong)value.Value);
        }
        StorageModel.Instance.OddToStorageItems(costItems);
        if (data.module == (int)ExchangeType.Month_Draw)
        {
            DispatchEvent(ExhcangeEvent.MonthDraw);
        }
        else if (data.module == (int)ExchangeType.Diamond_Draw)
        {
            DispatchEvent(ExhcangeEvent.DiamondDraw);
        }
        else if (data.module == (int)ExchangeType.Dress_Draw)
        {
            DispatchEvent(ExhcangeEvent.DressDraw);
        }else if (data.module == (int)ExchangeType.Furniture_Shop)
        {
            DrawModel.Instance.UpdateExchangeData(data.exchange);
            DispatchEvent(ExhcangeEvent.FurnitureShop);
        }
        var dropList = ItemModel.Instance.GetDropData(data.items);
        UILogicUtils.ShowGetReward(dropList, () =>
        {
            DropManager.ShowDrop(dropList);
        });
    }

    public void ReqCommonExchange(uint activityId,uint exchangeId,uint module)
    {
        C_MSG_COMMONACTIVITY_EXCHANGE c_MSG_COMMONACTIVITY_EXCHANGE = new C_MSG_COMMONACTIVITY_EXCHANGE();
        c_MSG_COMMONACTIVITY_EXCHANGE.activityId = activityId;
        c_MSG_COMMONACTIVITY_EXCHANGE.exchangeId = exchangeId;
        c_MSG_COMMONACTIVITY_EXCHANGE.module = module;
        SendCmd((int)MessageCode.C_MSG_COMMONACTIVITY_EXCHANGE, c_MSG_COMMONACTIVITY_EXCHANGE);
    }
}
