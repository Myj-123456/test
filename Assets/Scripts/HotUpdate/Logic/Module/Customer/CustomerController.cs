using System.Collections;
using System.Collections.Generic;
using protobuf.messagecode;
using protobuf.npc;
using UnityEngine;

public class CustomerController : BaseController<CustomerController>
{
    protected override void InitListeners()
    {
        //赠送礼物、花艺品给居民
        AddNetListener<S_MSG_NPC_GIVE_GIFT>((int)MessageCode.S_MSG_NPC_GIVE_GIFT, NpcGiveGift);
        //购买赠送礼物、花艺赠送次数
        AddNetListener<S_MSG_NPC_BUY_GIVE_CNT>((int)MessageCode.S_MSG_NPC_BUY_GIVE_CNT, NpcBuyTimes);
        //领取居民等级奖励
        AddNetListener<S_MSG_NPC_LEVEL_REWARD>((int)MessageCode.S_MSG_NPC_LEVEL_REWARD, NpcGetReward);
    }
    //赠送礼物、花艺品给居民
    public void NpcGiveGift(S_MSG_NPC_GIVE_GIFT data)
    {
        StorageModel.Instance.OddToStorageItems(data.costItems);
        CustomerModel.Instance.surplusGiveGiftCnt = data.surplusGiveGiftCnt;
        CustomerModel.Instance.surplusGiveIkebanaCnt = data.surplusGiveIkebanaCnt;

        CustomerModel.Instance.totalLevel = data.totalLevel;
        CustomerModel.Instance.totalExp = data.totalExp;
        CustomerModel.Instance.UpdateNpcData(data.npc);
        DispatchEvent(NpcEvent.NpcGiveGift);
    }

    public void ReqNpcGiveGift(uint npcId,uint type,uint itemId,uint num)
    {
        C_MSG_NPC_GIVE_GIFT c_MSG_NPC_GIVE_GIFT = new C_MSG_NPC_GIVE_GIFT();
        c_MSG_NPC_GIVE_GIFT.npcId = npcId;
        c_MSG_NPC_GIVE_GIFT.type = type;
        c_MSG_NPC_GIVE_GIFT.itemId = itemId;
        c_MSG_NPC_GIVE_GIFT.num = num;
        SendCmd((int)MessageCode.C_MSG_NPC_GIVE_GIFT, c_MSG_NPC_GIVE_GIFT,0.2f);
    }
    //购买赠送礼物、花艺赠送次数
    public void NpcBuyTimes(S_MSG_NPC_BUY_GIVE_CNT data)
    {
        CustomerModel.Instance.surplusGiveGiftCnt = data.surplusGiveGiftCnt;
        CustomerModel.Instance.surplusGiveIkebanaCnt = data.surplusGiveIkebanaCnt;
        CustomerModel.Instance.buyGiftCnt = data.buyGiftCnt;
        CustomerModel.Instance.buyIkebanaCnt = data.buyIkebanaCnt;

       
        StorageModel.Instance.OddToStorageItems(data.costItems);
        DispatchEvent(NpcEvent.NpcBuyTimes);
    }

    public void ReqNpcBuyTimes(uint type,uint num)
    {
        C_MSG_NPC_BUY_GIVE_CNT c_MSG_NPC_BUY_GIVE_CNT = new C_MSG_NPC_BUY_GIVE_CNT();
        c_MSG_NPC_BUY_GIVE_CNT.type = type;
        c_MSG_NPC_BUY_GIVE_CNT.num = num;
        SendCmd((int)MessageCode.C_MSG_NPC_BUY_GIVE_CNT, c_MSG_NPC_BUY_GIVE_CNT);
    }
    //领取居民等级奖励
    public void NpcGetReward(S_MSG_NPC_LEVEL_REWARD data)
    {
        var dropList = ItemModel.Instance.GetDropData(data.items);
        DropManager.ShowDrop(dropList);
        CustomerModel.Instance.UpdateLevelReward(data.npcId, data.levelRewards);
        DispatchEvent(NpcEvent.NpcBuyTimes);
    }

    public void ReqNpcGetReward(uint npcId,uint rewardLevel)
    {
        C_MSG_NPC_LEVEL_REWARD c_MSG_NPC_LEVEL_REWARD = new C_MSG_NPC_LEVEL_REWARD();
        c_MSG_NPC_LEVEL_REWARD.npcId = npcId;
        c_MSG_NPC_LEVEL_REWARD.rewardLevel = rewardLevel;
        SendCmd((int)MessageCode.C_MSG_NPC_LEVEL_REWARD, c_MSG_NPC_LEVEL_REWARD);
    }
}
