using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using protobuf.fairy;
using protobuf.fight;
using protobuf.messagecode;
using UnityEngine;

public class FlowerGoldController : BaseController<FlowerGoldController>
{
    protected override void InitListeners()
    {
        //花仙信息
        AddNetListener<S_MSG_FAIRY_INFO>((int)MessageCode.S_MSG_FAIRY_INFO, FairyInfo);
        //领取花仙碎片
        AddNetListener<S_MSG_FAIRY_DRAW>((int)MessageCode.S_MSG_FAIRY_DRAW, FairyDraw);
        //兑换花仙
        AddNetListener<S_MSG_FAIRY_EXCHANGE>((int)MessageCode.S_MSG_FAIRY_EXCHANGE, FairyExchange);
        //升级
        AddNetListener<S_MSG_FAIRY_UPGRADE>((int)MessageCode.S_MSG_FAIRY_UPGRADE, FairyUpgrade);
        //刷新祭坛
        AddNetListener<S_MSG_FAIRY_REFRESH>((int)MessageCode.S_MSG_FAIRY_REFRESH, FairyRefresh);
        //花仙上阵
        AddNetListener<S_MSG_BATTLE_FAIRY>((int)MessageCode.S_MSG_BATTLE_FAIRY, BattleFairy);
    }
    //花仙信息
    public void FairyInfo(S_MSG_FAIRY_INFO data)
    {
        FlowerGoldModel.Instance.altar = data.altar;
        DispatchEvent(FlowerGoldEvent.FairyInfo);
    }

    public void ReqFairyInfo()
    {
        C_MSG_FAIRY_INFO c_MSG_FAIRY_INFO = new C_MSG_FAIRY_INFO();
        SendCmd((int)MessageCode.C_MSG_FAIRY_INFO, c_MSG_FAIRY_INFO);
    }
    //领取花仙碎片
    public void FairyDraw(S_MSG_FAIRY_DRAW data)
    {
        if(data.altar.refreshTime != FlowerGoldModel.Instance.altar.refreshTime)
        {
            FlowerGoldModel.Instance.altar = data.altar;
            DispatchEvent(FlowerGoldEvent.FairyDraw);
        }
        else
        {

            FlowerGoldModel.Instance.altar = data.altar;
            var index = Array.IndexOf(data.altar.fairyShardIds, data.items.Keys.ToList()[0]);
            DispatchEvent(FlowerGoldEvent.FairyDrawItem, index);
            
        }
        
        StorageModel.Instance.AddToStorageItems(data.items);
        StorageModel.Instance.OddToStorageItems(data.costItems);

        
    }

    public void ReqFairyDraw(uint multi,uint refreshTime)
    {
        C_MSG_FAIRY_DRAW c_MSG_FAIRY_DRAW = new C_MSG_FAIRY_DRAW();
        c_MSG_FAIRY_DRAW.multi = multi;
        c_MSG_FAIRY_DRAW.refreshTime = refreshTime;
        SendCmd((int)MessageCode.C_MSG_FAIRY_DRAW, c_MSG_FAIRY_DRAW);
    }
    //兑换花仙
    public void FairyExchange(S_MSG_FAIRY_EXCHANGE data)
    {
        FlowerGoldModel.Instance.fairys.Add( data.fairy);
        StorageModel.Instance.OddToStorageItems(data.costItems);
        DispatchEvent(FlowerGoldEvent.FairyExchange);
    }

    public void ReqFairyExchange(uint fairyId)
    {
        C_MSG_FAIRY_EXCHANGE c_MSG_FAIRY_EXCHANGE = new C_MSG_FAIRY_EXCHANGE();
        c_MSG_FAIRY_EXCHANGE.fairyId = fairyId;
        SendCmd((int)MessageCode.C_MSG_FAIRY_EXCHANGE, c_MSG_FAIRY_EXCHANGE);
    }
    //升级
    public void FairyUpgrade(S_MSG_FAIRY_UPGRADE data)
    {
        FlowerGoldModel.Instance.UpdateFairy(data.fairy);
        StorageModel.Instance.OddToStorageItems(data.costItems);
        DispatchEvent(FlowerGoldEvent.FairyUpgrade);
    }

    public void ReqFairyUpgrade(uint fairyId)
    {
        C_MSG_FAIRY_UPGRADE c_MSG_FAIRY_UPGRADE = new C_MSG_FAIRY_UPGRADE();
        c_MSG_FAIRY_UPGRADE.fairyId = fairyId;
        SendCmd((int)MessageCode.C_MSG_FAIRY_UPGRADE, c_MSG_FAIRY_UPGRADE);
    }
    //刷新祭坛
    public void FairyRefresh(S_MSG_FAIRY_REFRESH data)
    {
        FlowerGoldModel.Instance.altar = data.altar;
        DispatchEvent(FlowerGoldEvent.FairyRefresh);
    }

    public void ReqFairyRefresh()
    {
        C_MSG_FAIRY_REFRESH c_MSG_FAIRY_REFRESH = new C_MSG_FAIRY_REFRESH();
        SendCmd((int)MessageCode.C_MSG_FAIRY_REFRESH, c_MSG_FAIRY_REFRESH);
    }

    //花仙上阵
    public void BattleFairy(S_MSG_BATTLE_FAIRY data)
    {
        PlayerModel.Instance.pen.battleFairys = data.battleFairys;
        DispatchEvent(FlowerGoldEvent.BattleFairy);
    }

    public void ReqBattleFairy(uint pos,uint fairyId)
    {
        C_MSG_BATTLE_FAIRY c_MSG_BATTLE_FAIRY = new C_MSG_BATTLE_FAIRY();
        c_MSG_BATTLE_FAIRY.pos = pos;
        c_MSG_BATTLE_FAIRY.fairyId = fairyId;
        SendCmd((int)MessageCode.C_MSG_BATTLE_FAIRY, c_MSG_BATTLE_FAIRY);
    }
}
