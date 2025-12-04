using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using protobuf.dailyTask;
using protobuf.login;
using UnityEngine;
using static protobuf.login.S_MSG_GAME_MISC;

public class TaskModel : Singleton<TaskModel>
{
    //主线任务配置表|ft_task_main
    private Dictionary<int, Ft_task_mainConfig> _taskMainMap;
    public Dictionary<int, Ft_task_mainConfig> taskMainMap
    {
        get
        {
            if (_taskMainMap == null)
            {
                var taskMainData = ConfigManager.Instance.GetConfig<Ft_task_mainConfigData>("ft_task_mainsConfig");
                _taskMainMap = taskMainData.DataMap;
            }
            return _taskMainMap;
        }
    }

    //成就配置表|ft_achiev_config
    private List<Ft_achiev_configConfig> _achievList;
    public List<Ft_achiev_configConfig> achievList
    {
        get
        {
            if (_achievList == null)
            {
                var achievData = ConfigManager.Instance.GetConfig<Ft_achiev_configConfigData>("ft_achiev_configsConfig");
                _achievList = achievData.DataList;
            }
            return _achievList;
        }
    }

    //任务进度表|ft_task_progress
    private Dictionary<int, Ft_task_progressConfig> _taskProMap;
    private Dictionary<int, Ft_task_progressConfig> taskProMap
    {
        get
        {
            if (_taskProMap == null)
            {
                var taskProData = ConfigManager.Instance.GetConfig<Ft_task_progressConfigData>("ft_task_progresssConfig");
                _taskProMap = taskProData.DataMap;
            }
            return _taskProMap;
        }
    }

    public MAINTASK_VO mainTask;//主线任务
    public List<I_PROGRESS_VO> progress; //进度奖励
    public List<I_ACHIEV_TASK_VO> achievTaskList;//成就任务

    //获取任务进度配置
    public Ft_task_progressConfig GetTaskProInfo(int id)
    {
        if (taskProMap.ContainsKey(id))
        {
            return taskProMap[id];
        }
        return null;
    }
    //获取进度列表
    public List<Ft_task_progressConfig> GetTaskProList(int type)
    {
        var listData = new List<Ft_task_progressConfig>();
        foreach (var value in taskProMap)
        {
            if (value.Value.DayWeek == type)
            {
                listData.Add(value.Value);
            }
        }
        listData.Sort((a, b) => a.ProgressNum - b.ProgressNum);
        return listData;

    }
    //获取成就配置

    public Ft_achiev_configConfig GetAchievInfo(int id)
    {
        return achievList.Find(value => value.Id == id);
    }

    //获取成就配置

    public List<Ft_achiev_configConfig> GetAchievInfoType(int type)
    {
        return achievList.FindAll(value => value.AchievType == type);
    }

    //获取主线任务配置
    public Ft_task_mainConfig GetTaskMainInfo(int id)
    {
        if (taskMainMap.ContainsKey(id))
        {
            return taskMainMap[id];
        }
        return null;
    }

    //获取进度奖励
    public I_PROGRESS_VO GetProReward(uint type)
    {
        return progress.Find(value => value.type == type);
    }

    //更新进度
    public void UpdatePro(uint type,uint progress)
    {

    }

    public void UpdateProReward(uint type, uint[] rewardIds)
    {
        var proData = GetProReward(type);
        proData.rewardId = rewardIds;
    }
    //获取成就服务数据
    public I_ACHIEV_TASK_VO GetAchievData(uint seriesId)
    {
        return achievTaskList.Find(value => value.seriesId == seriesId);
    }
    //获取成就列表
    public List<I_ACHIEV_TASK_VO> GetAchievList(int type)
    {
        var achievData = new List<I_ACHIEV_TASK_VO>();
        foreach (var value in achievTaskList)
        {
            var achievInfo = GetAchievInfo((int)value.taskId);
            if (achievInfo.AchievType == type)
            {
                achievData.Add(value);
            }
        }
        return achievData;
    }

    public void UpdateAchievData(I_ACHIEV_TASK_VO data)
    {
        var achievData = GetAchievData(data.seriesId);
        if (achievData != null)
        {
            achievData.taskId = data.taskId;
            achievData.curCnt = data.curCnt;
        }
    }

    public List<int> GetAchievTypeList()
    {
        var typeData = new List<int>();
        foreach (var value in achievList)
        {
            if (typeData.IndexOf(value.AchievType) == -1)
            {
                typeData.Add(value.AchievType);
            }
        }
        typeData.Sort();
        return typeData;
    }


    /// <summary>
    /// 检测某个任务是否完成了
    /// </summary>
    /// <param name="taskId"></param>
    public bool CheckIsCompleteTask(uint taskId)
    {
        if (mainTask != null)
        {
            if (mainTask.mainTaskId == 0) return true;//全部任务都完成了
            return mainTask.mainTaskId > taskId;
        }
        return true;
    }

    public string GetTaskDec(string TaskDesc,int TaskType,int TaskNum, int TypeParam,int Ishistory = 0)
    {
        var addStr = Ishistory == 1 ? Lang.GetValue("main_task_4") : "";
        if (TaskType == 1 || TaskType == 2 || TaskType == 16 || TaskType == 23)
        {
            if (TypeParam == 0)
            {
                var str = "";
                if (TaskType == 1 || TaskType == 16)
                {
                    str = Lang.GetValue("main_task_1");
                }
                else if (TaskType == 2)
                {
                    str = Lang.GetValue("warehouse_03");
                }
                else
                {
                    str = Lang.GetValue("flower_arrangement_01");
                }
                return addStr + Lang.GetValue(TaskDesc, Lang.GetValue("fund_6") + str, TaskNum.ToString());
            }
            else
            {
                var itemVo = ItemModel.Instance.GetItemById(TypeParam);
                return addStr + Lang.GetValue(TaskDesc, Lang.GetValue(itemVo.Name), TaskNum.ToString());
            }

        }
        else if (TaskType == 24)
        {
            if (TypeParam == 0)
            {
                return addStr + Lang.GetValue(TaskDesc, Lang.GetValue("main_task_1"));
            }
            else
            {
                var itemVo = ItemModel.Instance.GetItemById(TypeParam);
                return addStr + Lang.GetValue(TaskDesc, Lang.GetValue(itemVo.Name));
            }

        }
        else if (TaskType == 33)
        {
            return addStr + Lang.GetValue(TaskDesc);
        }
        else
        {
            return addStr + Lang.GetValue(TaskDesc, TaskNum.ToString());
        }
    }
}


public enum TaskType
{
    Flower = 1,//收获指定花XX个
    Vase = 2,//完成XXX花瓶的插花X个
    FlowerLevel = 3,//升级n次花
    Cultivate = 4,//成功培育出n种花
    CustomerOrder = 5,//累积完成n个顾客订单
    FlowerMarketOrder = 6,//累积完成n个花市订单
    VipBuy = 7,//在vip商店购买n次
    CultivateBuy = 8,//培育商店内购买n次
    FlowerOrder = 9,//完成鲜花订单n次
    VaseSell = 10,//花台出售任意插花作品n个
    DamondCost = 11,//消耗钻石xx个
    GoldGet = 12,//累积获得XXXX个金币
    DamondGet = 13,//累积获得XXX个钻石
    FriendFlower = 14,//摘取好友xxx朵花
    LookVideo = 15,//累积观看视频xx次
    PlantFlower = 16,//种植xxx次鲜花
    FriendCount = 17,//累积拥有xx个好友
    LoginDay = 18,//登陆游戏xx天
    UnlockLand = 19,//解锁土地xxx块
    UnlockFlowerBed = 20,//解锁花台xx个
    Level = 21,//等级达到xx级
    Share = 22,//任意分享X次
    FlowerBedSell = 23,//花台出售XXX插花作品n个
}

