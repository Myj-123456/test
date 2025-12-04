using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using protobuf.messagecode;
using protobuf.plant;
using UnityEngine;

public class FlowerRankController : BaseController<FlowerRankController>
{
    protected override void InitListeners()
    {
        //排行榜列表
        AddNetListener<S_MSG_RANK_LIST>((int)MessageCode.S_MSG_RANK_LIST, RankList);//排行榜类型 1：繁荣度 2：培育 3：花艺品 4：时装魅力
    }

    public void RankList(S_MSG_RANK_LIST data)
    {
        if(data.type == 1)
        {
            FlowerRankModel.Instance.prosperityRankList = data;
        }else if(data.type == 2)
        {
            FlowerRankModel.Instance.cultivateRankList = data;
        }
        else if (data.type == 3)
        {
            FlowerRankModel.Instance.artRankList = data;
        }
        else if (data.type == 4)
        {
            FlowerRankModel.Instance.dressRankList = data;
        }
        EventManager.Instance.DispatchEvent(FlowerRankEvent.RankList);
    }

    public void ReqRankList(uint type)
    {
        C_MSG_RANK_LIST c_MSG_RANK_LIST = new C_MSG_RANK_LIST();
        c_MSG_RANK_LIST.type = type;
        SendCmd((int)MessageCode.C_MSG_RANK_LIST, c_MSG_RANK_LIST,0);
    }

    public void ReqRankUserInfo(uint type)
    {
        var userId = new List<uint>();
        var dressId = new List<uint>();
        if (type == (uint)UserType.Prosperity)
        {
            foreach(var rankInfo in FlowerRankModel.Instance.prosperityRankList.rankList)
            {
                if(rankInfo.rank < 4)
                {
                    dressId.Add(rankInfo.targetId);
                }
                userId.Add(rankInfo.targetId);
            }
        }else if (type == (uint)UserType.Cultivate)
        {
            foreach (var rankInfo in FlowerRankModel.Instance.cultivateRankList.rankList)
            {
                if (rankInfo.rank < 4)
                {
                    dressId.Add(rankInfo.targetId);
                }
                userId.Add(rankInfo.targetId);
            }
        }
        else if (type == (uint)UserType.Art)
        {
            foreach (var rankInfo in FlowerRankModel.Instance.artRankList.rankList)
            {
                if (rankInfo.rank < 4)
                {
                    dressId.Add(rankInfo.targetId);
                }
                userId.Add(rankInfo.targetId);
            }
        }
        else if (type == (uint)UserType.Dress)
        {
            foreach (var rankInfo in FlowerRankModel.Instance.dressRankList.rankList)
            {
                if (rankInfo.rank < 4)
                {
                    dressId.Add(rankInfo.targetId);
                }
                userId.Add(rankInfo.targetId);
            }
        }
        var other = new List<string>();
        other.Add("ware");
        MyselfController.Instance.ReqGetUserInfo(userId.ToArray(), dressId.ToArray(), type, other);
    }
}
