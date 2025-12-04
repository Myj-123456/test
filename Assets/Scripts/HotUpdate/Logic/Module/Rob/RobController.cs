using System;
using System.Collections;
using System.Collections.Generic;
using ADK;
using protobuf.messagecode;
using protobuf.rob;
using UnityEngine;

public class RobController : BaseController<RobController>
{
    protected override void InitListeners()
    {
        AddNetListener<S_MSG_ROB_INFO>((int)MessageCode.S_MSG_ROB_INFO, RobInfo);
        AddNetListener<S_MSG_ROB_UNLOCK>((int)MessageCode.S_MSG_ROB_UNLOCK, RobUnlock);
        AddNetListener<S_MSG_ROB_FRIEND_LIST>((int)MessageCode.S_MSG_ROB_FRIEND_LIST, RobFriendList);
        AddNetListener<S_MSG_ROB_ENEMY_LIST>((int)MessageCode.S_MSG_ROB_ENEMY_LIST, RobEnemyList);
        AddNetListener<S_MSG_ROB_RECOMMEND_LIST>((int)MessageCode.S_MSG_ROB_RECOMMEND_LIST, RobRecommendList);
        AddNetListener<S_MSG_ROB_DAILY_REWARD>((int)MessageCode.S_MSG_ROB_DAILY_REWARD, RobDailyReward);
        AddNetListener<S_MSG_ROB_ARREST>((int)MessageCode.S_MSG_ROB_ARREST, RobArrest);
        AddNetListener<S_MSG_ROB_REWARD>((int)MessageCode.S_MSG_ROB_REWARD, RobReward);
        AddNetListener<S_MSG_ROB_EXCHANGE>((int)MessageCode.S_MSG_ROB_EXCHANGE, RobExchange);
        AddNetListener<S_MSG_ROB_BUY>((int)MessageCode.S_MSG_ROB_BUY, RobBuy);
        AddNetListener<S_MSG_ROB_SETSHIELD>((int)MessageCode.S_MSG_ROB_SETSHIELD, RobSetshield);
        AddNetListener<S_MSG_ROB_MESSAGE>((int)MessageCode.S_MSG_ROB_MESSAGE, RobMessage);
    }

    public void RobInfo(S_MSG_ROB_INFO data)
    {
        RobModel.Instance.arrestList = data.arrestList;
        RobModel.Instance.info = data.info;
        RobModel.Instance.robInfo = data.robInfo;
        RobModel.Instance.targetUserInfo = data.targetUserInfo;
        EventManager.Instance.DispatchEvent(RobEvent.RobInfo);
    }

    public void ReqRobInfo()
    {
        C_MSG_ROB_INFO c_MSG_ROB_INFO = new C_MSG_ROB_INFO();
        SendCmd((int)MessageCode.C_MSG_ROB_INFO, c_MSG_ROB_INFO);
    }

    public void RobUnlock(S_MSG_ROB_UNLOCK data)
    {
        RobModel.Instance.UpdateRobUnlock(data.arrest);
        EventManager.Instance.DispatchEvent(RobEvent.RobUnlock);
    }

    public void ReqRobUnlock(uint position)
    {
        C_MSG_ROB_UNLOCK c_MSG_ROB_UNLOCK = new C_MSG_ROB_UNLOCK();
        c_MSG_ROB_UNLOCK.position = position;
        SendCmd((int)MessageCode.C_MSG_ROB_UNLOCK, c_MSG_ROB_UNLOCK);
    }

    public void RobFriendList(S_MSG_ROB_FRIEND_LIST data)
    {
        RobModel.Instance.friendList = data.friendList;
        EventManager.Instance.DispatchEvent(RobEvent.RobFriendList);
    }

    public void ReqRobFriendList()
    {
        C_MSG_ROB_FRIEND_LIST c_MSG_ROB_FRIEND_LIST = new C_MSG_ROB_FRIEND_LIST();
        c_MSG_ROB_FRIEND_LIST.start = 1;
        c_MSG_ROB_FRIEND_LIST.end = 300;
        SendCmd((int)MessageCode.C_MSG_ROB_FRIEND_LIST, c_MSG_ROB_FRIEND_LIST);
    }

    public void RobEnemyList(S_MSG_ROB_ENEMY_LIST data)
    {
        RobModel.Instance.enemyList = data.enemyList;
        EventManager.Instance.DispatchEvent(RobEvent.RobEnemyList);
    }

    public void ReqRobEnemyList()
    {
        C_MSG_ROB_ENEMY_LIST c_MSG_ROB_ENEMY_LIST = new C_MSG_ROB_ENEMY_LIST();
        SendCmd((int)MessageCode.C_MSG_ROB_ENEMY_LIST, c_MSG_ROB_ENEMY_LIST);
    }

    public void RobRecommendList(S_MSG_ROB_RECOMMEND_LIST data)
    {
        RobModel.Instance.recommendList = data.recommendList;
        EventManager.Instance.DispatchEvent(RobEvent.RobRecommendList);
    }

    public void ReqRobRecommendList()
    {
        C_MSG_ROB_RECOMMEND_LIST c_MSG_ROB_RECOMMEND_LIST = new C_MSG_ROB_RECOMMEND_LIST();
        SendCmd((int)MessageCode.C_MSG_ROB_RECOMMEND_LIST, c_MSG_ROB_RECOMMEND_LIST);
    }

    public void RobDailyReward(S_MSG_ROB_DAILY_REWARD data)
    {
        RobModel.Instance.info = data.info;
        var item = RobModel.Instance.robOtherConfig.EverydayOrders[0];
        StorageModel.Instance.AddToStorageByItemId(item.EntityID, item.Value);
        var info = new StorageItemVO();
        info.itemDefId = IDUtil.GetEntityValue(item.EntityID);
        info.count = item.Value;
        var items = new List<StorageItemVO>();
        items.Add(info);

        UILogicUtils.ShowGetReward(items, () =>
        {
            DropManager.ShowDrop(items, false);
        }, Lang.GetValue("rob_53"));

        EventManager.Instance.DispatchEvent(RobEvent.RobDailyReward);
    }

    public void ReqRobDailyReward()
    {
        C_MSG_ROB_DAILY_REWARD c_MSG_ROB_DAILY_REWARD = new C_MSG_ROB_DAILY_REWARD();
        SendCmd((int)MessageCode.C_MSG_ROB_DAILY_REWARD, c_MSG_ROB_DAILY_REWARD);
    }

    public void RobArrest(S_MSG_ROB_ARREST data)
    {
        object[] param = new object[] { 0, data.arrestResult, data.isShield, data.arrest.userInfo.townName };
        UIManager.Instance.OpenWindow<RobTipMessageWindow>(UIName.RobTipMessageWindow, param);
        if (data.arrestResult)
        {
            RobModel.Instance.UpdateRobUnlock(data.arrest);
            EventManager.Instance.DispatchEvent(RobEvent.RobUnlock);
        }
        StorageModel.Instance.AddToStorageByItemId(RobModel.item_snatch_id, -1);

    }

    public void ReqRobArrest(uint targetUserId, uint position)
    {
        C_MSG_ROB_ARREST c_MSG_ROB_ARREST = new C_MSG_ROB_ARREST();
        c_MSG_ROB_ARREST.targetUserId = targetUserId;
        c_MSG_ROB_ARREST.position = position;
        SendCmd((int)MessageCode.C_MSG_ROB_ARREST, c_MSG_ROB_ARREST);
    }

    public void RobReward(S_MSG_ROB_REWARD data)
    {
        var userName = RobModel.Instance.GetArrestInfo(data.arrest.position).userInfo.townName;
        RobModel.Instance.UpdateRobUnlock(data.arrest);
        StorageModel.Instance.AddToStorageItems(data.items);
        object[] param = new object[] { 1, data.indexId, data.gainsBonus, data.items, userName };
        UIManager.Instance.OpenWindow<RobTipMessageWindow>(UIName.RobTipMessageWindow, param);

        EventManager.Instance.DispatchEvent(RobEvent.RobUnlock);
        EventManager.Instance.DispatchEvent(RobEvent.RobReward);
    }

    public void ReqRobReward(uint position)
    {
        C_MSG_ROB_REWARD c_MSG_ROB_REWARD = new C_MSG_ROB_REWARD();
        c_MSG_ROB_REWARD.position = position;
        SendCmd((int)MessageCode.C_MSG_ROB_REWARD, c_MSG_ROB_REWARD);
    }

    public void RobExchange(S_MSG_ROB_EXCHANGE data)
    {
        var petalItem = RobModel.Instance.robOtherConfig.PetalConsumes[0];
        StorageModel.Instance.AddToStorageByItemId(petalItem.EntityID, -petalItem.Value);
        var rewards = RobModel.Instance.GeRobRewardConfig((int)data.indexId);
        //StorageModel.Instance.AddToStorageItems(data.items);
        if (rewards != null)
        {
            var dropList = new List<StorageItemVO>();
            foreach (var item in rewards.Rewards)
            {
                var drop = new StorageItemVO();
                drop.itemDefId = IDUtil.GetEntityValue(item.EntityID);
                drop.count = (int)item.Value;
                dropList.Add(drop);
            }
            if (rewards.Type == 1)
            {
                UILogicUtils.ShowGetReward(dropList, () =>
                {
                    DropManager.ShowDrop(dropList);
                });
            }
            else
            {
                DropManager.ShowDrop(dropList);
            }

        }

        EventManager.Instance.DispatchEvent(RobEvent.RobReward);
    }

    public void ReqRobExchange()
    {
        C_MSG_ROB_EXCHANGE c_MSG_ROB_EXCHANGE = new C_MSG_ROB_EXCHANGE();
        SendCmd((int)MessageCode.C_MSG_ROB_EXCHANGE, c_MSG_ROB_EXCHANGE);
    }

    public void RobBuy(S_MSG_ROB_BUY data)
    {
        int indexId = (int)data.indexId;
        if (data.type == 1)
        {
            var shield = RobModel.Instance.robOtherConfig.ShieldNums[indexId];
            StorageModel.Instance.AddToStorageByItemId(shield.EntityID, shield.Value);
        }
        else
        {
            var shield = RobModel.Instance.robOtherConfig.TokenNums[indexId];
            StorageModel.Instance.AddToStorageByItemId(shield.EntityID, shield.Value);

        }
        EventManager.Instance.DispatchEvent(RobEvent.RobBuy);
    }

    public void ReqRobBuy(uint type, uint indexId)
    {
        C_MSG_ROB_BUY c_MSG_ROB_BUY = new C_MSG_ROB_BUY();
        c_MSG_ROB_BUY.type = type;
        c_MSG_ROB_BUY.indexId = indexId;
        SendCmd((int)MessageCode.C_MSG_ROB_BUY, c_MSG_ROB_BUY);
    }

    public void RobSetshield(S_MSG_ROB_SETSHIELD data)
    {
        RobModel.Instance.info = data.info;
        EventManager.Instance.DispatchEvent(RobEvent.RobSetshield);
    }

    public void ReqRobSetshield(uint type)
    {
        C_MSG_ROB_SETSHIELD c_MSG_ROB_SETSHIELD = new C_MSG_ROB_SETSHIELD();
        c_MSG_ROB_SETSHIELD.type = type;
        SendCmd((int)MessageCode.C_MSG_ROB_SETSHIELD, c_MSG_ROB_SETSHIELD);
    }

    public void RobMessage(S_MSG_ROB_MESSAGE data)
    {
        RobModel.Instance.messageList = data.messageList;
        EventManager.Instance.DispatchEvent(RobEvent.RobMessage);
    }

    public void ReqRobMessage()
    {
        C_MSG_ROB_MESSAGE C_MSG_ROB_MESSAGE = new C_MSG_ROB_MESSAGE();
        SendCmd((int)MessageCode.C_MSG_ROB_MESSAGE, C_MSG_ROB_MESSAGE);
    }
}
