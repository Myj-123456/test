using System;
using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using protobuf.misc;
using UnityEngine;
using static protobuf.dailyTask.S_MSG_ROOKIE_INFO;

public class WelfareModel : Singleton<WelfareModel>
{
    private List<Ft_sign_dayConfig> _signList;
    public List<Ft_sign_dayConfig> signList
    {
        get
        {
            if (_signList == null)
            {
                var signData = ConfigManager.Instance.GetConfig<Ft_sign_dayConfigData>("ft_sign_daysConfig");
                _signList = signData.DataList;
            }
            return _signList;
        }
    }

    //萌新之路
    private List<Ft_rookie_taskConfig> _growthList;
    public List<Ft_rookie_taskConfig> growthList
    {
        get
        {
            if (_growthList == null)
            {
                var growthData = ConfigManager.Instance.GetConfig<Ft_rookie_taskConfigData>("ft_rookie_tasksConfig");
                _growthList = growthData.DataList;
            }
            return _growthList;
        }
    }

    private Dictionary<int, Ft_turntableConfig> _turnMap;
    public Dictionary<int, Ft_turntableConfig> turnMap
    {
        get
        {
            if (_turnMap == null)
            {
                var turnData = ConfigManager.Instance.GetConfig<Ft_turntableConfigData>("ft_turntablesConfig");
                _turnMap = turnData.DataMap;
            }
            return _turnMap;
        }
    }

    public uint currentDay;//当前第几天;
    public bool todayHaveDraw;//今天是否已领取奖励
    public uint status;//0-活动未开始 1-未完成 2-已完成
    public uint currentSignDay;//补签最大天数 为0 则是今天未补签
    public uint signDay; //签到天数当前已经签到了多少天,已经算上了补签天数
    public bool isSign;//今天是否已经签到
    public uint retroactiveDays;//当前已补签天数

    public List<I_ROOKIE_TASK> rookieTask;//萌新任务
    public uint days;//已登录天数
    public uint[] rookieRewards;// rookie任务id

    public Ft_turntableConfig GetTurnInfo(int id)
    {
        if (turnMap.ContainsKey(id))
        {
            return turnMap[id];
        }
        return null;
    }
    public void InitDailyLogin(I_DAILY_LOGIN data)
    {
        currentDay = data.currentDay;
        todayHaveDraw = data.todayHaveDraw;
        status = data.status;
        currentSignDay = data.currentSignDay;
        signDay = data.signDay;
        isSign = data.isSign;
        retroactiveDays = data.retroactiveDays;
    }
    public Ft_sign_dayConfig GetSignInfo(int id)
    {
        return signList.Find(value => value.Id == id);
    }

    public Ft_rookie_taskConfig GetGrowthInfo(int id)
    {
        return growthList.Find(value => value.IndexId == id);
    }

    public uint GetRookieTaskNum(uint indexId)
    {
        var growthData = rookieTask.Find(value => value.indexId == indexId);
        if (growthData == null) return 0;
        return growthData.curCnt;
    }
    public int GetStatusRookie(uint indexId)
    {
        if (rookieRewards != null && Array.IndexOf(rookieRewards, indexId) != -1)
        {
            return 2;
        }
        else
        {
            var growthInfo = GetGrowthInfo((int)indexId);
            var haveNum = GetRookieTaskNum(indexId);
            if (growthInfo.TaskNum > haveNum)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }

    public List<Ft_rookie_taskConfig> GetDayList(int day)
    {
        var listData = growthList.FindAll(value => value.DayNum == day);
        listData.Sort((a, b) => { return GetStatusRookie((uint)a.IndexId) - GetStatusRookie((uint)b.IndexId); });
        return listData;
    }

    //判断萌新之路是否完成
    public bool IsGrowthGetted()
    {
        var bol = rookieRewards != null && rookieRewards.Length == growthList.Count;
        var proData = TaskModel.Instance.GetTaskProList(5);
        var proServer = TaskModel.Instance.GetProReward(5);
        var bol1 = proServer.rewardId != null && proData.Count == proServer.rewardId.Length;
        return bol && bol1;
    }

    public bool GetGrowthRed()
    {
        if((!GlobalModel.Instance.GetUnlocked(SysId.Newspaper) || IsGrowthGetted()))
        {
            return false;
        }
        foreach (var value in growthList)
        {
            if (GetStatusRookie((uint)value.IndexId) == 0)
            {
                return true;
            }
        }
        var proData = TaskModel.Instance.GetTaskProList(5);
        var proServer = TaskModel.Instance.GetProReward(5);
        foreach (var value in proData)
        {
            if ((proServer.rewardId == null || Array.IndexOf(proServer.rewardId, (uint)value.Id) == -1) && proServer.progress >= value.ProgressNum)
            {
                return true;
            }
        }
        return false;
    }

    public bool GetSevenRed()
    {
        if((!GlobalModel.Instance.GetUnlocked(SysId.SeventhSign) || status == 2))
        {
            return false;
        }
    
        if (todayHaveDraw)
        {
            return true;
        }
        return false;
    }

    public bool GetTurnRed()
    {
        if (!GlobalModel.Instance.GetUnlocked(SysId.TurnTable))
        {
            return false;
        }
        if(TurnBoxManager.Instance.boxNum > 0)
        {
            return true;
        }
        return false;
    }

    public bool GetSignRed()
    {
        if (!GlobalModel.Instance.GetUnlocked(SysId.Newspaper))
        {
            return false;
        }
        if (!isSign)
        {
            return true;
        }
        var proServer = TaskModel.Instance.GetProReward(4);
        var proData = TaskModel.Instance.GetTaskProList(4);
        foreach(var value in proData)
        {
            if ((proServer.rewardId == null || Array.IndexOf(proServer.rewardId, (uint)value.Id) == -1) && proServer.progress >= value.ProgressNum)
            {
                return true;
            }
        }
        return false;
    }
}

