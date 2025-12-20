using System;
using System.Collections;
using System.Collections.Generic;
using protobuf.reddot;
using UnityEngine;

public class RedPointModel : Singleton<RedPointModel>
{
    public List<I_REDDOT_VO> reddot;//红点
    public Dictionary<TodayFirstLogin, bool> todayFirstLogin;
    public I_REDDOT_VO GetPointInfo(RedPointType type)
    {
        return reddot.Find(value => value.type == (uint)type);
    }
    public void InitTodayFirstLogin(bool isTodayFirstLogin)
    {
        todayFirstLogin = new Dictionary<TodayFirstLogin, bool>();
        var len = Enum.GetNames(typeof(TodayFirstLogin)).Length;
        for(var i = 0;i < len; i++)
        {
            todayFirstLogin.Add((TodayFirstLogin)i, isTodayFirstLogin);
        }
    }

    public void UpdateTodayFirstLogin(TodayFirstLogin type)
    {
        if (todayFirstLogin.ContainsKey(type) && todayFirstLogin[type])
        {
            todayFirstLogin[type] = false;
            EventManager.Instance.DispatchEvent(RedPointEvent.UpdateTodayFirstLogin);
        }
    }

    public bool GetTodayFirstLogin(TodayFirstLogin type)
    {
        if (todayFirstLogin.ContainsKey(type))
        {
            return todayFirstLogin[type];
        }
        return false;
    }
    public bool IsRedPointShow(RedPointType type)
    {
        var point = GetPointInfo(type);
        if(point != null)
        {
            return point.redDot;
        }
        return false;
    }
   //前端更改红点
    public void ClientUpadteRedPoint(RedPointType type)
    {
        var bol = false;
        if (type == RedPointType.Friend_Apply)
        {
            bol = FriendModel.Instance.applyList != null && FriendModel.Instance.applyList.Count > 0;

        }
        else if(type == RedPointType.Friend_Crony)
        {
            bol = FriendModel.Instance.applyUserIds != null && FriendModel.Instance.applyUserIds.Count > 0;
        }
        else if (type == RedPointType.Task_Daily || type == RedPointType.Task_Week)
        {
            bol = TaskModel.Instance.GetProRedPoint(1) || DailyTaskModel.Instance.GetDailyRedPoint() || DailyTaskModel.Instance.GetWeekRedPoint();
        }
        else if (type == RedPointType.Task_Achiev)
        {
            bol = TaskModel.Instance.GetAchievAllRedPoint();
        }
        else if (type == RedPointType.Growth_Road)
        {
            bol = WelfareModel.Instance.GetGrowthRed();
        }
        else if (type == RedPointType.Trade)
        {

        }
        else if (type == RedPointType.Task_Contract)
        {
            bol = ContractModel.Instance.GetTaskContractRed(ActivityType.Contract);
        }
        else if (type == RedPointType.Flower_Contract)
        {

        }
        else if (type == RedPointType.Guild_Donate)
        {
            var maxNum = GuildModel.Instance.othersConfig.PersekutuanjumlahDonasi;
            var num = maxNum - (int)GuildModel.Instance.guildMember.donateCnt;
            bol = num > 0;
        }
        else if(type == RedPointType.Guild_Donate_Pro)
        {
            bol = GuildModel.Instance.GetDonatePro();
        }
        else if(type == RedPointType.Guild_Apply)
        {
            bol = GuildModel.Instance.applyList != null && GuildModel.Instance.applyList.Count > 0;
        }
        else if(type == RedPointType.Guild_Plant)
        {
            bol = GuildPlantModel.Instance.GetPlantReward();
        }
        else if (type == RedPointType.Guild_Gift)
        {
            bol = GuildGiftModel.Instance.GetGiftReward();
        }
        else if(type == RedPointType.Guild_Big_Box)
        {
            bol = GuildGiftModel.Instance.GetBigBox();
        }
        UpdateRedPoint(type, bol);
    }
    public void UpdateRedPoint(RedPointType type,bool bol)
    {
        var point = GetPointInfo(type);
        if (point != null && point.redDot != bol)
        {
            point.redDot = bol;
            EventManager.Instance.DispatchEvent(RedPointEvent.RedDotChange, (uint)type);
        }
    }

    public void UpdateRedPoint(I_REDDOT_VO data)
    {
        var point = GetPointInfo((RedPointType)data.type);
        if (point != null)
        {
            point.redDot = data.redDot;
            point.ext1 = data.ext1;
        }
        else
        {
            reddot.Add(data);
        }

    }
}

public enum RedPointType
{
    Friend_Apply = 1,//好友申请
    Friend_Crony = 2,//蜜友申请
    Task_Daily = 3,// 每日任务
    Task_Week = 4,//每周任务
    Task_Achiev = 5, //成就任务
    Growth_Road = 6,//成长之路任务
    Trade = 7,//好友交易卖出
    Task_Contract = 8,//合约任务
    Flower_Contract = 9,//花仙合约任务
    Guild_Donate = 10,//花盟捐献有剩余次数
    Guild_Donate_Pro = 11,//花盟捐献 - 进度奖励
    Guild_Apply = 12, //有玩家申请加入花盟
    Guild_Plant = 13,//花盟种植有奖励可领取时
    Guild_Gift = 14,//花盟有小礼物可以领取
    Guild_Big_Box = 15,//花盟有大宝箱可领取
}
//今天第一次登录
public enum TodayFirstLogin
{
    Vip_Shop = 0,//vip商店
    Recharge = 1,//充值
    Main_Gift = 2,//主界面礼包
    Frist_Recharge = 3,//首充
}
