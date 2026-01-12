using System.Collections;
using System.Collections.Generic;
using System.Linq;
using protobuf.dailyTask;
using protobuf.messagecode;
using protobuf.misc;
using UnityEngine;
using ADK;

public class WelfareController : BaseController<WelfareController>
{
    protected override void InitListeners()
    {
        // 签到
        AddNetListener<S_MSG_DAILY_SIGN>((int)MessageCode.S_MSG_DAILY_SIGN, DailySign);
        // 签到奖励
        AddNetListener<S_MSG_DAILY_RETROACTIVE>((int)MessageCode.S_MSG_DAILY_RETROACTIVE, DailyRetroactive);
        // 新人奖励信息
        AddNetListener<S_MSG_ROOKIE_INFO>((int)MessageCode.S_MSG_ROOKIE_INFO, RookieInfo);
        // 新人奖励
        AddNetListener<S_MSG_ROOKIE_REWARD>((int)MessageCode.S_MSG_ROOKIE_REWARD, RookieReward);
        // 转牌
        AddNetListener<S_MSG_TURNTABLE>((int)MessageCode.S_MSG_TURNTABLE, TurnTable);
        // 每日登录 - 获取奖励
        AddNetListener<S_MSG_DAILY_LOGIN_AWARD>((int)MessageCode.S_MSG_DAILY_LOGIN_AWARD, DailyLoginAward);
    }
    // 签到
    public void DailySign(S_MSG_DAILY_SIGN data)
    {
        WelfareModel.Instance.signDay = data.signDay;
        WelfareModel.Instance.isSign = data.isSign;
        var dropList = ItemModel.Instance.GetDropData(data.items);
        DropManager.ShowDrop(dropList);
        var proServer = TaskModel.Instance.GetProReward(4);
        proServer.progress += 1;
        EventManager.Instance.DispatchEvent(WelfareEvent.DailySign);
    }

    public void ReqDailySign()
    {
        C_MSG_DAILY_SIGN c_MSG_DAILY_SIGN = new C_MSG_DAILY_SIGN();
        SendCmd((int)MessageCode.C_MSG_DAILY_SIGN, c_MSG_DAILY_SIGN);
    }
    // 签到奖励
    public void DailyRetroactive(S_MSG_DAILY_RETROACTIVE data)
    {
        WelfareModel.Instance.signDay = data.signDay;
        WelfareModel.Instance.retroactiveDays = data.retroactiveDays;
        StorageModel.Instance.OddToStorageItems(data.costItems);
        var dropList = ItemModel.Instance.GetDropData(data.items);
        DropManager.ShowDrop(dropList);
        var proServer = TaskModel.Instance.GetProReward(4);
        proServer.progress += 1;
        EventManager.Instance.DispatchEvent(WelfareEvent.DailyRetroactive);
    }

    public void ReqDailyRetroactive()
    {
        C_MSG_DAILY_RETROACTIVE c_MSG_DAILY_RETROACTIVE = new C_MSG_DAILY_RETROACTIVE();
        SendCmd((int)MessageCode.C_MSG_DAILY_RETROACTIVE, c_MSG_DAILY_RETROACTIVE);
    }
    // 新人奖励信息
    public void RookieInfo(S_MSG_ROOKIE_INFO data)
    {
        WelfareModel.Instance.rookieTask = data.rookieTask;
        WelfareModel.Instance.days = data.days;
        EventManager.Instance.DispatchEvent(WelfareEvent.RookieInfo);
    }

    public void ReqRookieInfo()
    {
        C_MSG_ROOKIE_INFO c_MSG_ROOKIE_INFO = new C_MSG_ROOKIE_INFO();
        SendCmd((int)MessageCode.C_MSG_ROOKIE_INFO, c_MSG_ROOKIE_INFO);
    }
    // 新人奖励
    public void RookieReward(S_MSG_ROOKIE_REWARD data)
    {
        var diff1 = WelfareModel.Instance.rookieRewards == null? data.rookieRewards : data.rookieRewards.Except(WelfareModel.Instance.rookieRewards).ToArray();
        if(diff1.Length > 0)
        {
            var info = WelfareModel.Instance.GetGrowthInfo((int)diff1[0]);
            var proServer = TaskModel.Instance.GetProReward(5);
            proServer.progress += (uint)info.ScoreReward;
        }
        WelfareModel.Instance.rookieRewards = data.rookieRewards;
        var dropList = ItemModel.Instance.GetDropData(data.items);
        DropManager.ShowDrop(dropList);
        RedPointModel.Instance.ClientUpadteRedPoint(RedPointType.Growth_Road);
        EventManager.Instance.DispatchEvent(WelfareEvent.RookieReward);

    }

    public void ReqRookieReward(uint id)
    {
        C_MSG_ROOKIE_REWARD c_MSG_ROOKIE_REWARD = new C_MSG_ROOKIE_REWARD();
        c_MSG_ROOKIE_REWARD.id = id;
        SendCmd((int)MessageCode.C_MSG_ROOKIE_REWARD, c_MSG_ROOKIE_REWARD);
    }
    // 转盘
    public void TurnTable(S_MSG_TURNTABLE data)
    {
        var dropList = ItemModel.Instance.GetDropData(data.items);
        UILogicUtils.ShowGetReward(dropList, () =>
        {
            DropManager.ShowDrop(dropList);
        });
        
        // 如果是分享抽奖
        if (data.type == 2 && MyselfModel.Instance.behaviorDaily != null)
        {
            MyselfModel.Instance.behaviorDaily.turntableShareCnt = 1;
            // 触发更新界面
            EventManager.Instance.DispatchEvent(WelfareEvent.TurnTable);
        }
    }

    public void ReqTurnTable()
    {
        C_MSG_TURNTABLE c_MSG_TURNTABLE = new C_MSG_TURNTABLE();
        c_MSG_TURNTABLE.type = 1; // 普通抽奖
        SendCmd((int)MessageCode.C_MSG_TURNTABLE, c_MSG_TURNTABLE);
    }
    
    public void ReqTurnTableByShare()
    {
        C_MSG_TURNTABLE c_MSG_TURNTABLE = new C_MSG_TURNTABLE();
        c_MSG_TURNTABLE.type = 2; // 分享抽奖
        SendCmd((int)MessageCode.C_MSG_TURNTABLE, c_MSG_TURNTABLE);
    }
    // 每日登录奖励
    public void DailyLoginAward(S_MSG_DAILY_LOGIN_AWARD data)
    {
        var dropList = ItemModel.Instance.GetDropData(data.items);
        UILogicUtils.ShowGetReward(dropList, () =>
        {
            DropManager.ShowDrop(dropList);
        });
        WelfareModel.Instance.todayHaveDraw = true;
        if(WelfareModel.Instance.currentDay == SeventhSignModel.Instance.sevenList.Count && WelfareModel.Instance.todayHaveDraw)
        {
            WelfareModel.Instance.status = 2;
        }
        EventManager.Instance.DispatchEvent(WelfareEvent.DailyLoginAward);
    }
    public void ReqDailyLoginAward()
    {
        C_MSG_DAILY_LOGIN_AWARD c_MSG_DAILY_LOGIN_AWARD = new C_MSG_DAILY_LOGIN_AWARD();
        SendCmd((int)MessageCode.C_MSG_DAILY_LOGIN_AWARD, c_MSG_DAILY_LOGIN_AWARD);
    }
}
