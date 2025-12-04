//using System.Collections;
//using System.Collections.Generic;
//using protobuf.guild;
//using protobuf.messagecode;
//using UnityEngine;

//public class FlowerShareController : BaseController<FlowerShareController>
//{
//    protected override void InitListeners()
//    {
//        // 鲜花分享
//        AddNetListener<S_MSG_GUILD_SHARE_FLOWER_INFO>((int)MessageCode.S_MSG_GUILD_SHARE_FLOWER_INFO, GuildShareFlowerInfo);
//        // 拿走社团其他成员分享的鲜花
//        AddNetListener<S_MSG_GUILD_TAKE_SHARE_FLOWER>((int)MessageCode.S_MSG_GUILD_TAKE_SHARE_FLOWER, GuildTaskShareFlower);
//        // 增加鲜花分享次数
//        AddNetListener<S_MSG_GUILD_ADD_SHARENUM>((int)MessageCode.S_MSG_GUILD_ADD_SHARENUM, GuildAddShareNum);
//        // 解锁鲜花分享位置
//        AddNetListener<S_MSG_GUILD_UNLOCK_SHARE_FLOWER>((int)MessageCode.S_MSG_GUILD_UNLOCK_SHARE_FLOWER, GuildUnlockShareFlower);
//        // 领取鲜花分享奖励
//        AddNetListener<S_MSG_GUILD_SHARE_FLOWER_REWARD>((int)MessageCode.S_MSG_GUILD_SHARE_FLOWER_REWARD, GuildShareFlowerReward);
//        //分享该位置的分享信息
//        AddNetListener<S_MSG_GUILD_SHARE_FLOWER>((int)MessageCode.S_MSG_GUILD_SHARE_FLOWER, GuildShareFlower);
//        // 分享鲜花日志
//        AddNetListener<S_MSG_GUILD_SHARE_FLOWER_LOG>((int)MessageCode.S_MSG_GUILD_SHARE_FLOWER_LOG, GuildShareFlowerLog);
//        // 鲜花分享 收藏鲜花
//        AddNetListener<S_MSG_GUILD_SHARE_COLLECT>((int)MessageCode.S_MSG_GUILD_SHARE_COLLECT, GuidShareCollect);
//    }

//    public void GuildShareFlowerInfo(S_MSG_GUILD_SHARE_FLOWER_INFO data)
//    {
//        FlowerShareModel.Instance.guildMemberShareFlowers = data.guildMemberShareFlowers;
//        FlowerShareModel.Instance.flowerShareInfos = data.flowerShareInfos;
//        FlowerShareModel.Instance.surplusTakeCnt = data.surplusTakeCnt;
//        FlowerShareModel.Instance.shareFlowersCollect = data.shareFlowersCollect;
//        EventManager.Instance.DispatchEvent(FlowerShareEvent.GuildShareFlowerInfo);
//    }

//    public void ReqGuildShareFlowerInfo()
//    {
//        C_MSG_GUILD_SHARE_FLOWER_INFO c_MSG_GUILD_SHARE_FLOWER_INFO = new C_MSG_GUILD_SHARE_FLOWER_INFO();
//        SendCmd((int)MessageCode.C_MSG_GUILD_SHARE_FLOWER_INFO, c_MSG_GUILD_SHARE_FLOWER_INFO);
//    }

//    public void GuildTaskShareFlower(S_MSG_GUILD_TAKE_SHARE_FLOWER data)
//    {
//        FlowerShareModel.Instance.UpdateStorageCount(data.flowerShare);
//        FlowerShareModel.Instance.UpdateGuildMember(data.flowerShare);
//        FlowerShareModel.Instance.surplusTakeCnt = data.surplusTakeCnt;
//        EventManager.Instance.DispatchEvent(FlowerShareEvent.GuildShareFlowerInfo);
//    }

//    public void ReqGuildTaskShareFlower(uint targetUserId,uint position)
//    {
//        C_MSG_GUILD_TAKE_SHARE_FLOWER c_MSG_GUILD_TAKE_SHARE_FLOWER = new C_MSG_GUILD_TAKE_SHARE_FLOWER();
//        c_MSG_GUILD_TAKE_SHARE_FLOWER.targetUserId = targetUserId;
//        c_MSG_GUILD_TAKE_SHARE_FLOWER.position = position;
//        SendCmd((int)MessageCode.C_MSG_GUILD_TAKE_SHARE_FLOWER, c_MSG_GUILD_TAKE_SHARE_FLOWER);
//    }
    
//    public void GuildAddShareNum(S_MSG_GUILD_ADD_SHARENUM data)
//    {
//        GuildModel.Instance.guild.addShareNum = data.addShareNum;
//        FlowerShareModel.Instance.surplusTakeCnt++;
//        GuildModel.Instance.guild.money = data.money;
//        EventManager.Instance.DispatchEvent(FlowerShareEvent.GuildAddShareNum);
//    }

//    public void ReqGuildAddShareNum()
//    {
//        C_MSG_GUILD_ADD_SHARENUM c_MSG_GUILD_ADD_SHARENUM = new C_MSG_GUILD_ADD_SHARENUM();
//        SendCmd((int)MessageCode.C_MSG_GUILD_ADD_SHARENUM, c_MSG_GUILD_ADD_SHARENUM);
//    }

//    public void GuildUnlockShareFlower(S_MSG_GUILD_UNLOCK_SHARE_FLOWER data)
//    {
//        FlowerShareModel.Instance.UpdateFlowerShareInfos(data.flowerShare);
//        EventManager.Instance.DispatchEvent(FlowerShareEvent.GuildUnlockShareFlower);
//    }

//    public void ReqGuildUnlockShareFlower(uint position)
//    {
//        C_MSG_GUILD_UNLOCK_SHARE_FLOWER c_MSG_GUILD_UNLOCK_SHARE_FLOWER = new C_MSG_GUILD_UNLOCK_SHARE_FLOWER();
//        c_MSG_GUILD_UNLOCK_SHARE_FLOWER.position = position;
//        SendCmd((int)MessageCode.C_MSG_GUILD_UNLOCK_SHARE_FLOWER, c_MSG_GUILD_UNLOCK_SHARE_FLOWER);
//    }

//    public void GuildShareFlowerReward(S_MSG_GUILD_SHARE_FLOWER_REWARD data)
//    {
//        FlowerShareModel.Instance.UpdateFlowerShareInfos(data.flowerShare);
//        EventManager.Instance.DispatchEvent(FlowerShareEvent.GuildUnlockShareFlower);
//    }

//    public void ReqGuildShareFlowerReward(uint position)
//    {
//        C_MSG_GUILD_SHARE_FLOWER_REWARD c_MSG_GUILD_SHARE_FLOWER_REWARD = new C_MSG_GUILD_SHARE_FLOWER_REWARD();
//        c_MSG_GUILD_SHARE_FLOWER_REWARD.position = position;
//        SendCmd((int)MessageCode.C_MSG_GUILD_SHARE_FLOWER_REWARD, c_MSG_GUILD_SHARE_FLOWER_REWARD);
//    }

//    public void GuildShareFlower(S_MSG_GUILD_SHARE_FLOWER data)
//    {
//        FlowerShareModel.Instance.UpdateFlowerShareInfos(data.flowerShare);
//        StorageModel.Instance.AddToStorageByItemId(data.flowerShare.flowerId, -(int)(uint.Parse(data.flowerShare.count) * FlowerShareModel.getFlowerMaxCount));
//        EventManager.Instance.DispatchEvent(FlowerShareEvent.GuildShareFlower);
//    }

//    public void ReqGuildShareFlower(uint position,uint flowerId)
//    {
//        C_MSG_GUILD_SHARE_FLOWER c_MSG_GUILD_SHARE_FLOWER = new C_MSG_GUILD_SHARE_FLOWER();
//        c_MSG_GUILD_SHARE_FLOWER.position = position;
//        c_MSG_GUILD_SHARE_FLOWER.flowerId = flowerId;
//        SendCmd((int)MessageCode.C_MSG_GUILD_SHARE_FLOWER, c_MSG_GUILD_SHARE_FLOWER);
//    }

//    public void GuildShareFlowerLog(S_MSG_GUILD_SHARE_FLOWER_LOG data)
//    {
//        FlowerShareModel.Instance.messageList = data.messageList;
//        EventManager.Instance.DispatchEvent(FlowerShareEvent.GuildShareFlowerLog);
//    }

//    public void ReqGuildShareFlowerLog()
//    {
//        C_MSG_GUILD_SHARE_FLOWER_LOG c_MSG_GUILD_SHARE_FLOWER_LOG = new C_MSG_GUILD_SHARE_FLOWER_LOG();
//        SendCmd((int)MessageCode.C_MSG_GUILD_SHARE_FLOWER_LOG, c_MSG_GUILD_SHARE_FLOWER_LOG);
//    }

//    public void GuidShareCollect(S_MSG_GUILD_SHARE_COLLECT data)
//    {
//        FlowerShareModel.Instance.shareFlowersCollect = data.shareFlowersCollect;
//        EventManager.Instance.DispatchEvent(FlowerShareEvent.GuidShareCollect);
//    }

//    public void ReqGuidShareCollect(string flowerIds)
//    {
//        C_MSG_GUILD_SHARE_COLLECT c_MSG_GUILD_SHARE_COLLECT = new C_MSG_GUILD_SHARE_COLLECT();
//        c_MSG_GUILD_SHARE_COLLECT.flowerIds = flowerIds;
//        SendCmd((int)MessageCode.C_MSG_GUILD_SHARE_COLLECT, c_MSG_GUILD_SHARE_COLLECT);
//    }
//}
