using System.Collections;
using System.Collections.Generic;
using protobuf.messagecode;
using protobuf.share;
using UnityEngine;

public class ShareController : BaseController<ShareController>
{
    protected override void InitListeners()
    {
        //等级奖励
        AddNetListener<S_MSG_SHARE_LEVEL_REWARD>((int)MessageCode.S_MSG_SHARE_LEVEL_REWARD, ShareLevelReward);
        //首次分享插花奖励
        AddNetListener<S_MSG_SHARE_IKEBANA_REWARD>((int)MessageCode.S_MSG_SHARE_IKEBANA_REWARD, ShareIkeReward);
        //分享鲜花奖励
        AddNetListener<S_MSG_SHARE_FLOWER_REWARD>((int)MessageCode.S_MSG_SHARE_FLOWER_REWARD, ShareFlowerReward);
    }
    //等级奖励
    public void ShareLevelReward(S_MSG_SHARE_LEVEL_REWARD data)
    {
        var dropList = ItemModel.Instance.GetDropData(data.items);
        DropManager.ShowDrop(dropList);
        EventManager.Instance.DispatchEvent(ShareEvent.ShareLevelReward, dropList);
    }
    public void ReqShareLevelReward()
    {
        C_MSG_SHARE_LEVEL_REWARD c_MSG_SHARE_LEVEL_REWARD = new C_MSG_SHARE_LEVEL_REWARD();
        SendCmd((int)MessageCode.C_MSG_SHARE_LEVEL_REWARD, c_MSG_SHARE_LEVEL_REWARD);
    }
    //首次分享插花奖励
    public void ShareIkeReward(S_MSG_SHARE_IKEBANA_REWARD data)
    {
        var dropList = ItemModel.Instance.GetDropData(data.items);
        DropManager.ShowDrop(dropList);
        IkeModel.Instance.UpdateShareIke(data.combinationId);
        EventManager.Instance.DispatchEvent(ShareEvent.ShareIkeReward);
    }
    public void ReqShareIkeReward(uint combinationId)
    {
        C_MSG_SHARE_IKEBANA_REWARD c_MSG_SHARE_IKEBANA_REWARD = new C_MSG_SHARE_IKEBANA_REWARD();
        c_MSG_SHARE_IKEBANA_REWARD.combinationId = combinationId;
        SendCmd((int)MessageCode.C_MSG_SHARE_IKEBANA_REWARD, c_MSG_SHARE_IKEBANA_REWARD);
    }
    //分享鲜花奖励
    public void ShareFlowerReward(S_MSG_SHARE_FLOWER_REWARD data)
    {
        var dropList = ItemModel.Instance.GetDropData(data.items);
        DropManager.ShowDrop(dropList);
        EventManager.Instance.DispatchEvent(ShareEvent.ShareFlowerReward);
    }
    public void ReqShareFlowerReward()
    {
        C_MSG_SHARE_FLOWER_REWARD c_MSG_SHARE_FLOWER_REWARD = new C_MSG_SHARE_FLOWER_REWARD();
        SendCmd((int)MessageCode.C_MSG_SHARE_FLOWER_REWARD, c_MSG_SHARE_FLOWER_REWARD);
    }
}
