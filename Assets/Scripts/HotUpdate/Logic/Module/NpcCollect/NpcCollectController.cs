using System;
using System.Collections;
using System.Collections.Generic;
using protobuf.messagecode;
using protobuf.monster;
using UnityEngine;

public class NpcCollectController : BaseController<NpcCollectController>
{
    protected override void InitListeners()
    {
        AddNetListener<S_MSG_LOLITA_INFO>((int)MessageCode.S_MSG_LOLITA_INFO, GrandmaInfo);
        AddNetListener<S_MSG_LOLITA_EXCHANGE>((int)MessageCode.S_MSG_LOLITA_EXCHANGE, GrandmaExchange);
        AddNetListener<S_MSG_LOLITA_REWARD>((int)MessageCode.S_MSG_LOLITA_REWARD, GrandmaReward);
    }

    public void GrandmaInfo(S_MSG_LOLITA_INFO data)
    {
        NpcCollectModel.Instance.loliTask = data.loliTask;
        NpcCollectModel.Instance.ParseTaskStatus(data.rewardIds);
        EventManager.Instance.DispatchEvent(NpcCollectEvent.GrandmaInfo);
    }

    public void ReqGrandmaInfo()
    {
        C_MSG_LOLITA_INFO c_MSG_LOLITA_INFO = new C_MSG_LOLITA_INFO();
        SendCmd((int)MessageCode.C_MSG_LOLITA_INFO, c_MSG_LOLITA_INFO);
    }

    public void GrandmaExchange(S_MSG_LOLITA_EXCHANGE data)
    {
        int id = (int)data.exchangeId;
        Exchange_grandmaData grandmaData = NpcCollectModel.Instance.exchangeMapData[id];
        StorageModel.Instance.AddToStorageByItemId(grandmaData.Expends[0].EntityID, -grandmaData.Expends[0].Value);
        //NpcCollectModel.Instance.taskStatus.Add((uint)id);
        StorageModel.Instance.AddToStorageByItemId(grandmaData.Rewards[0].EntityID, grandmaData.Rewards[0].Value);
        var itemData = ItemModel.Instance.GetItemByEntityID(grandmaData.Rewards[0].EntityID);
        Action callFun = () => {
            UIManager.Instance.CloseWindow(UIName.NpcCollectWindow);
        };
        var param = new object[] { itemData, callFun };
        UIManager.Instance.OpenWindow<NewlyGotFlowerShowWindow>(UIName.NewlyGotFlowerShowWindow, param);
        EventManager.Instance.DispatchEvent(NpcCollectEvent.GrandmaExchange);
    }

    public void ReqGrandmaExchange(uint exchangeId)
    {
        C_MSG_LOLITA_EXCHANGE c_MSG_LOLITA_EXCHANGE = new C_MSG_LOLITA_EXCHANGE();
        c_MSG_LOLITA_EXCHANGE.exchangeId = exchangeId;
        SendCmd((int)MessageCode.C_MSG_LOLITA_EXCHANGE, c_MSG_LOLITA_EXCHANGE);
    }


    public void GrandmaReward(S_MSG_LOLITA_REWARD data)
    {
        int id = (int)data.id;
        GrandmaData grandmaData = NpcCollectModel.Instance.staticItemMapData[id];
        StorageModel.Instance.AddToStorageByItemId(grandmaData.Rewards[0].EntityID, grandmaData.Rewards[0].Value);
        NpcCollectModel.Instance.taskStatus.Add((uint)id);
        var itemData = ItemModel.Instance.GetItemByEntityID(grandmaData.Rewards[0].EntityID);
        Action callFun = () => {
            UIManager.Instance.CloseWindow(UIName.NpcCollectWindow);
        };
        var param = new object[] { itemData, callFun };
        UIManager.Instance.OpenWindow<NewlyGotFlowerShowWindow>(UIName.NewlyGotFlowerShowWindow, param);
        
        EventManager.Instance.DispatchEvent(NpcCollectEvent.GrandmaReward);
    }

    public void ReqGrandmaReward(uint id)
    {
        C_MSG_LOLITA_REWARD c_MSG_LOLITA_REWARD = new C_MSG_LOLITA_REWARD();
        c_MSG_LOLITA_REWARD.id = id;
        SendCmd((int)MessageCode.C_MSG_LOLITA_REWARD, c_MSG_LOLITA_REWARD);
    }
}
