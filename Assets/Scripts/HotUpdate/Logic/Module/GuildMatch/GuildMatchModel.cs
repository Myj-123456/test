using System.Collections;
using System.Collections.Generic;
using ADK;
using Elida.Config;
using protobuf.guild;
using UnityEngine;

public class GuildMatchModel : Singleton<GuildMatchModel>
{
    //社团任务表
    private Dictionary<int, Ft_clubMatch_taskConfig> _matchTaskMap;
    public Dictionary<int,Ft_clubMatch_taskConfig> matchTaskMap
    {
        get
        {
            if (_matchTaskMap == null)
            {
                var matchData = ConfigManager.Instance.GetConfig<Ft_clubMatch_taskConfigData>("ft_clubMatch_tasksConfig");
                _matchTaskMap = matchData.DataMap;
            }
            return _matchTaskMap;
        }
    }

    //社团进度表
    private Dictionary<int, Ft_clubMatch_progressConfig> _matchProMap;
    public Dictionary<int, Ft_clubMatch_progressConfig> matchProMap
    {
        get
        {
            if (_matchProMap == null)
            {
                var matchData = ConfigManager.Instance.GetConfig<Ft_clubMatch_progressConfigData>("ft_clubMatch_progresssConfig");
                _matchProMap = matchData.DataMap;
            }
            return _matchProMap;
        }
    }

    //社团排行奖励
    private Dictionary<int, Ft_clubMatch_rankConfig> _matchRankMap;
    public Dictionary<int, Ft_clubMatch_rankConfig> matchRankMap
    {
        get
        {
            if (_matchRankMap == null)
            {
                var matchData = ConfigManager.Instance.GetConfig<Ft_clubMatch_rankConfigData>("ft_clubMatch_ranksConfig");
                _matchRankMap = matchData.DataMap;
            }
            return _matchRankMap;
        }
    }

    //个人任务
    private List<Ft_clubMatch_questConfig> _matchQuestList;
    public List<Ft_clubMatch_questConfig> matchQuestMapList
    {
        get
        {
            if(_matchQuestList == null)
            {
                var matchData = ConfigManager.Instance.GetConfig<Ft_clubMatch_questConfigData>("ft_clubMatch_questsConfig");
                _matchQuestList = matchData.DataList;
            }
            return _matchQuestList;
        }
    }

    public bool join;//社团是否参与了本次竞赛
    public uint oddTaskCnt;//本次竞赛我还能领取任务次数
    public uint score;//我的积分
    public uint guildScore;//社团积分
    public uint matchLv;//段位 1 青铜
    public uint rankNum;//社团在本组的排行
    public bool memberJoinStatus;//玩家是否可参加竞赛(是否是在竞赛开启之前加入商会)
    public uint endTime;//结束时间
    public uint startTime;//开始时间
    public List<string> resultStat;//历史数据统计
    public uint preRank;//上次排名
    public uint preGrade;//上次段位
    public uint taskCnt;//提交任务次数


    public List<I_COMPETITION_TASK_VO> taskList;//任务信息
    public List<uint> selfRewardIds;//个人任务已领取奖励
    public List<uint> rewardIds;//社团阶段积分已领取奖励
    public List<uint> specialFlowers;//本期特卖鲜花
    public List<I_COMPETITION_GUILD_RANK_VO> guildRankList;//花盟排行
    public List<I_COMPETITION_MEMBER_RANK_VO> memberRankList;//排行列表
    public List<I_MEMBER_VO> memberList;//成员列表
    //通过id获取社团任务信息
    public Ft_clubMatch_taskConfig GetMatchTaskInfo(int id)
    {
        if (matchTaskMap.ContainsKey(id))
        {
            return matchTaskMap[id];
        }
        return null;
    }

    //通过id获取社团进度信息
    public Ft_clubMatch_progressConfig GetMatchProInfo(int id)
    {
        if (matchProMap.ContainsKey(id))
        {
            return matchProMap[id];
        }
        return null;
    }

    //通过id获取个人任务
    public Ft_clubMatch_rankConfig GetMatchRankInfo(int id)
    {
        if (matchRankMap.ContainsKey(id))
        {
            return matchRankMap[id];
        }
        return null;
    }


    public bool GetIsOpenMatch()
    {
        //var curTime = TimeUtil.GetDateTime(ServerTime.Time);
        //// 获取星期几（周日=0, 周一=1,..., 周六=6）
        //int currentDay = (int)curTime.DayOfWeek;
        //// 计算到本周三的天数差
        //int daysToAdd = (currentDay != 0)
        //    ? (3 - currentDay)   
        //    : (3 - 7); 
        //var wednesday = curTime.Date.AddDays(daysToAdd);
        //var starTime = TimeUtil.GetTimestamp(wednesday) + 10 * 60 * 60;
        //var endTime = starTime + GuildModel.Instance.othersConfig.MatchTime2;
        //return ServerTime.Time > starTime && starTime < endTime;
        return ServerTime.Time > startTime && ServerTime.Time <= endTime;
    }

    public bool GetIsOpenMatchTask()
    {
        if(ServerTime.Time > startTime && ServerTime.Time <= endTime)
        {
            if(join && memberJoinStatus)
            {
                return true;
            }
        }
        return false;
    }

    public int GetMarchUpdateTime()
    {
        System.DateTime target;
        var curTime = TimeUtil.GetDateTime(ServerTime.Time);
        if (curTime.Minute == 0 && curTime.Second == 0)
        {
            target =  curTime.AddHours(1);
        }

        // 否则计算下一个整点小时
        target = new System.DateTime(
            curTime.Year,
            curTime.Month,
            curTime.Day,
            curTime.Hour, 0, 0).AddHours(1);
        return (int)TimeUtil.GetTimestamp(target) - (int)ServerTime.Time;
    }

    //通过pos获取任务数据
    public I_COMPETITION_TASK_VO GetTaskData(uint pos)
    {
        foreach(var value in taskList)
        {
            if(value.pos == pos)
            {
                return value;
            }
        }
        return null;
    }

    //更新任务
    public void UpdateTaskInfo(uint pos, I_COMPETITION_TASK_VO taskInfo)
    {
        for(int i = 0,len = taskList.Count;i < len; i++)
        {
            if(taskList[i].pos == pos)
            {
                taskList[i] = taskInfo;
                break;
            }
        }
    }

    //刷新任务
    public void RefreshTask(uint pos,uint id,uint curCnt,uint needCnt,uint needItem)
    {
        for (int i = 0, len = taskList.Count; i < len; i++)
        {
            if (taskList[i].pos == pos)
            {
                taskList[i].id = id;
                taskList[i].curCnt = curCnt;
                taskList[i].needCnt = needCnt;
                taskList[i].needItem = needItem;
                break;
            }
        }
    }
    //根据品质获取任务列表
    public List<I_COMPETITION_TASK_VO> GetTaskListData(int quality)
    {
        if(quality == 0)
        {
            return taskList;
        }
        return taskList.FindAll((value) =>
        {
            var taskInfo = GetMatchTaskInfo((int)value.id);
            return taskInfo.TaskRank == quality;
        });
    }

    public I_MEMBER_VO GetMemberInfo(uint userId)
    {
        if(memberList == null)
        {
            return null;
        }
        return memberList.Find(value => value.userId == userId);
    }

    public int GetMaxScore()
    {
        var score = guildRankList[0].score;
        var max = 0;
        foreach(var value in matchProMap)
        {
            if(score < value.Value.Progress)
            {
                return value.Value.Progress;
            }
            if(max < value.Value.Progress)
            {
                max = value.Value.Progress;
            }
        }
        return max;
    }

    //获取社团排行奖励
    public List<Ft_clubMatch_rankConfig> GetRankRewardList(int type,int grade = 0)
    {
        var listData = new List<Ft_clubMatch_rankConfig>();
        foreach(var value in matchRankMap)
        {
            if(value.Value.Type == type)
            {
                if(grade != 0)
                {

                }
                else
                {
                    listData.Add(value.Value);
                }
            }
        }
        return listData;
    }
}

