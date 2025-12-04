using System.Collections;
using System.Collections.Generic;
using protobuf.guild;
using protobuf.messagecode;
using UnityEngine;

public class GuildGiftController : BaseController<GuildGiftController>
{
    private int nomalNum = 0;
    private int rateNum = 0;
    protected override void InitListeners()
    {
        //礼物列表
        AddNetListener<S_MSG_GUILD_GIFT_LIST>((int)MessageCode.S_MSG_GUILD_GIFT_LIST, GuildGiftList);
        //礼物详情
        AddNetListener<S_MSG_GUILD_GIFT_INFO>((int)MessageCode.S_MSG_GUILD_GIFT_INFO, GuildGiftInfo);
        //领取礼物
        AddNetListener<S_MSG_GUILD_GIFT_DRAW>((int)MessageCode.S_MSG_GUILD_GIFT_DRAW, GuildGiftDraw);
        //领取大宝箱
        AddNetListener<S_MSG_GUILD_GIFT_GRADIENT>((int)MessageCode.S_MSG_GUILD_GIFT_GRADIENT, GuildGiftGradient);
    }
    //礼物列表
    public void GuildGiftList(S_MSG_GUILD_GIFT_LIST data)
    {
        GuildGiftModel.Instance.giftList = data.list;
        GuildGiftModel.Instance.gradientCnt = data.gradientCnt;
        GuildGiftModel.Instance.InfoGiftList();
        EventManager.Instance.DispatchEvent(GuildGiftEvent.GuildGiftList);
    }

    public void ReqGuildGiftList()
    {
        C_MSG_GUILD_GIFT_LIST c_MSG_GUILD_GIFT_LIST = new C_MSG_GUILD_GIFT_LIST();
        SendCmd((int)MessageCode.C_MSG_GUILD_GIFT_LIST, c_MSG_GUILD_GIFT_LIST);
    }
    //礼物详情
    public void GuildGiftInfo(S_MSG_GUILD_GIFT_INFO data)
    {
        GuildGiftModel.Instance.ParseGiftInfo(data.list);
        EventManager.Instance.DispatchEvent(GuildGiftEvent.GuildGiftInfo);
    }

    public void ReqGuildGiftInfo(string giftIds)
    {
        C_MSG_GUILD_GIFT_INFO c_MSG_GUILD_GIFT_INFO = new C_MSG_GUILD_GIFT_INFO();
        c_MSG_GUILD_GIFT_INFO.giftIds = giftIds;
        SendCmd((int)MessageCode.C_MSG_GUILD_GIFT_INFO, c_MSG_GUILD_GIFT_INFO,0);
    }
    //领取礼物
    public void GuildGiftDraw(S_MSG_GUILD_GIFT_DRAW data)
    {
        GuildGiftModel.Instance.UpdateGiftInfo(data);
        GuildModel.Instance.guild.giftScore = data.giftScore;
        EventManager.Instance.DispatchEvent(GuildGiftEvent.GuildGiftDraw);
    }

    public void ReqGuildGiftDraw(uint id)
    {
        C_MSG_GUILD_GIFT_DRAW c_MSG_GUILD_GIFT_DRAW = new C_MSG_GUILD_GIFT_DRAW();
        c_MSG_GUILD_GIFT_DRAW.giftId = id;
        SendCmd((int)MessageCode.C_MSG_GUILD_GIFT_DRAW, c_MSG_GUILD_GIFT_DRAW);
    }
    //领取大宝箱
    public void GuildGiftGradient(S_MSG_GUILD_GIFT_GRADIENT data)
    {
        GuildGiftModel.Instance.gradientCnt = data.gradientCnt;
        EventManager.Instance.DispatchEvent(GuildGiftEvent.GuildGiftGradient);
    }

    public void ReqGuildGiftGradient()
    {
        C_MSG_GUILD_GIFT_GRADIENT c_MSG_GUILD_GIFT_GRADIENT = new C_MSG_GUILD_GIFT_GRADIENT();
        SendCmd((int)MessageCode.C_MSG_GUILD_GIFT_GRADIENT,c_MSG_GUILD_GIFT_GRADIENT);
    }

    //一次请求100个分页请求
    public void ReqGiftInfo(int index, int type)
    {
        var str = "";
        if (type == 0)
        {
            if (index < nomalNum) return;
            var min = GuildGiftModel.Instance.nomalGiftList.Count - index > 8 ? index + 8 : GuildGiftModel.Instance.nomalGiftList.Count;
            for (; index < min; index++)
            {
                str += (GuildGiftModel.Instance.nomalGiftList[index].gifoVo.id + (index == min - 1?"":","));
            }
            nomalNum += min;
        }
        else
        {
            if (index < rateNum) return;
            var min = GuildGiftModel.Instance.rareGiftList.Count - index > 8 ? index + 8 : GuildGiftModel.Instance.nomalGiftList.Count;
            for (; index < min; index++)
            {
                str += (GuildGiftModel.Instance.rareGiftList[index].gifoVo.id + (index == min - 1 ? "" : ","));
            }
            rateNum += min;
        }
        ReqGuildGiftInfo(str);
    }

    public void ClearNum()
    {
        nomalNum = 0;
        rateNum = 0;
    }
}
