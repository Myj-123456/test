using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ADK;
using Elida.Config;
using static protobuf.monster.S_MSG_LOLITA_INFO;

public class NpcCollectModel : Singleton<NpcCollectModel>
{
    public Dictionary<int, GrandmaData> staticItemMapData;

    public List<GrandmaData> staticItemListData;

    public Dictionary<int, List<GrandmaData>> itemDataByType;

    public List<Exchange_grandmaData> exchangeListData;

    public Dictionary<int,Exchange_grandmaData> exchangeMapData;

    public List<uint> taskStatus;

    public Dictionary<uint, ulong> progress;

    public List<I_LOLI_TASK> loliTask;


    public int INVITE_CONDITION_NUM = 15;//分享ID
    public int VIDEO_CONDITION_NUM = 16;//视频ID

    public void InitData()
    {
        Ft_loli_exchangeConfigData exchangeData = ConfigManager.Instance.GetConfig<Ft_loli_exchangeConfigData>("ft_loli_exchangesConfig");
        Ft_loli_collectionConfigData grandmaConfigData = ConfigManager.Instance.GetConfig<Ft_loli_collectionConfigData>("ft_loli_collectionsConfig");
        exchangeListData = new List<Exchange_grandmaData>();
        exchangeMapData = new Dictionary<int, Exchange_grandmaData>();

        staticItemListData = new List<GrandmaData>();
        staticItemMapData = new Dictionary<int, GrandmaData>();

        foreach (Ft_loli_exchangeConfig data in exchangeData.DataList)
        {
            Exchange_grandmaData item = new Exchange_grandmaData(data);
            exchangeListData.Add(item);
            exchangeMapData.Add(item.Id,item);
        }

        foreach (Ft_loli_collectionConfig data in grandmaConfigData.DataList)
        {
            GrandmaData item = new GrandmaData(data);
            staticItemListData.Add(item);
            staticItemMapData.Add(item.Id, item);
        }
        itemDataByType = new Dictionary<int, List<GrandmaData>>();
        for (int i = 0; i < staticItemListData.Count; i++)
        {
            GrandmaData value = staticItemListData[i];

            itemDataByType.TryGetValue(value.Type, out List<GrandmaData> arr);
            if (arr == null)
            {
                arr = new List<GrandmaData>();
                itemDataByType.Add(value.Type, arr);
            }
            arr.Add(value);
            

        }
    }

    public void RequestData()
    {
        
    }

    public List<Exchange_grandmaData> GetItemData(int type)
    {
        exchangeListData.Sort(SortExchangeData);

        List<Exchange_grandmaData> staticArr = exchangeListData.FindAll(item =>
        {

            return (item).StartTime <= ServerTime.Time;
        });

        return staticArr;
    }

    //获取任务进度数据
    public I_LOLI_TASK GetTaskPro(uint id)
    {
        return loliTask.Find(value => value.id == id);
    }


    private int SortExchangeData(Exchange_grandmaData a, Exchange_grandmaData b)
    {
        if(a.HasRewardCount != b.HasRewardCount)
        {
            return a.QuantityInStock - b.QuantityInStock;
        }

        if(a.ConsumeAmount != b.ConsumeAmount)
        {
            return a.ConsumeAmount - b.ConsumeAmount;
        }

        return a.Order - b.Order;
    }

    public List<GrandmaData> GetItemData1(int type)
    {
        if (!itemDataByType.ContainsKey(type))
        {
            return new List<GrandmaData>();
        }
        List<GrandmaData> arr = itemDataByType[type];
        arr.Sort((GrandmaData a, GrandmaData b) => {
            if(a.SortNum != b.SortNum)
            {
                return a.SortNum - b.SortNum;
            }
            return a.Order < b.Order ? -1 : 1;
        });
        return arr;
    }

    //public List<int> GetTabStatus()
    //{
    //    List<int> ret = new List<int>();

    //}
    ///**获取需要完成任务才能兑换鲜花、花瓶的前2个页签 */
    //public int GetTaskTabsStatus(int type)
    //{
    //    int ret = 0;
    //    List<GrandmaData> arr = itemDataByType[type];
    //    List<GrandmaData> newlyExposedList = arr.FindAll(v => v.IsNew);
    //    List<GrandmaData> avaliableList = arr.FindAll(v => )

    //}

    public void ParseTaskStatus(uint[] data)
    {
        if(taskStatus == null)
        {
            taskStatus = new List<uint>();
        }
        else
        {
            taskStatus.Clear();
        }
        if(data != null)
        {
            foreach (var value in data)
            {
                taskStatus.Add(value);
            }
        }
        
    }

    public int CheckTaskStatus(int id)
    {
        int status = (int)NpcCollectTaskStatus.Unfinished;
        var taskData = GetTaskPro((uint)id);
        var taskInfo = staticItemMapData[id];
        if (taskStatus.IndexOf((uint)id) != -1)
        {
            status = 2;
        }
        else
        {
            status = taskInfo.TaskNum > taskData.curCnt ? 0 : 1;
        }
        return status;
    }
}

public class Exchange_grandmaData
{
    public int Id { get; set; }
    public int Order { get; set; }
    public int Type { get; set; }
    public System.Collections.Generic.List<RewardObject> Rewards { get; set; }
    public System.Collections.Generic.List<ExpendObject> Expends { get; set; }
    public int New { get; set; }
    public string WxStartTime { get; set; }
    public string WbStartTime { get; set; }
    public string HgStartTime { get; set; }


    public Exchange_grandmaData(Ft_loli_exchangeConfig data)
    {
        Id = data.Id;
        Order = data.Order;
        Type = data.Type;
        Rewards = new List<RewardObject>(data.Rewards);
        Expends = new List<ExpendObject>(data.Expends);
        New = data.New;
        WxStartTime = data.WxStartTime;
    }

    public int QuantityInStock
    {
        get
        {
            return StorageModel.Instance.GetItemCount(Rewards[0].EntityID);
        }
    }

    public bool HasRewardCount
    {
        get
        {
            return QuantityInStock > 0;
        }
    }

    public int ConsumeAmount
    {
        get
        {
            return Expends[0].Value;
        }
    }

    public int StartTime
    {
        get
        {
            return (int)TimeUtil.ParseFullTimeStr(WxStartTime);
        }
    }
}


public class GrandmaData
{
    public int Id { get; set; }
    public int Order { get; set; }
    public int Type { get; set; }
    public System.Collections.Generic.List<RewardObject> Rewards { get; set; }
    public int New { get; set; }

    public int TaskType;

    public int Ishistory;

    public int TypeParam;

    public int TaskNum;

    public GrandmaData(Ft_loli_collectionConfig data)
    {
        Id = data.Id;
        Order = data.Order;
        Type = data.Type;
        Rewards = new List<RewardObject>(data.Rewards);
        New = data.New;
        Ishistory = data.Ishistory;
        TaskType = data.TaskType;
        TypeParam = data.TypeParam;
        TaskNum = data.TaskNum;
        Ishistory = data.Ishistory;
    }

    public bool IsNew { get
        {
            return New == 1;
        }
    }

    public int SortNum
    {
        get
        {
            int num = 0;
            int status = NpcCollectModel.Instance.CheckTaskStatus(Id);
            if(status == 2)
            {
                num = 2;
            }
            else if(status == 1)
            {
                num = 0;
            }
            else
            {
                num = 1;
            }
            return num;
        }
    }
}


public enum NpcCollectTaskStatus
{
    Unfinished = 0, //未完成
    Available, //完成、未领奖
    Finished //完成、已领奖
}

public class TaskInfo
{
    public int UserId;
    public int Id;
    public int Status;
}

public class ProgressData
{
    public int UserId;
    public int Content;
    public int Progress;
}
