using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using protobuf.dailyTask;
using UnityEngine;
using static protobuf.login.S_MSG_GAME_MISC;

public class DailyTaskModel : Singleton<DailyTaskModel>
{

    public List<I_TASK_VO> dailyTask;//每日任务
    public List<I_TASK_VO> weeklyTask;//每周任务

    public static double TASK_COUNT = 5;

    public Dictionary<uint, List<StorageItemVO>> DropMap = new Dictionary<uint, List<StorageItemVO>>();

    private Dictionary<int, Ft_task_dailyConfig> _taskDataMap;
    public Dictionary<int, Ft_task_dailyConfig> taskDataMap { get
        {
            if(_taskDataMap == null)
            {
                Ft_task_dailyConfigData dailyConfigData = ConfigManager.Instance.GetConfig<Ft_task_dailyConfigData>("ft_task_dailysConfig");
                _taskDataMap = dailyConfigData.DataMap;
            }
            return _taskDataMap;
        } }

    private List<Ft_task_levelConfig> _taskLevelList;
    public List<Ft_task_levelConfig> taskLevelList
    { get { 
            if(_taskLevelList == null)
            {
                Ft_task_levelConfigData levelConfigData = ConfigManager.Instance.GetConfig<Ft_task_levelConfigData>("ft_task_levelsConfig");
                _taskLevelList = levelConfigData.DataList;
            }
            return _taskLevelList;
        } }

    public void UpdateTaskList(I_TASK_VO data,uint type)
    {
        int index = type == 1? GetDailyTaskIndex(data.taskId): GetWeekTaskIndex(data.taskId);
        if (index != -1)
        {
            if(type == 1)
            {
                dailyTask[index] = data;
            }
            else
            {
                weeklyTask[index] = data;
            }
            
        }
    }

    public int GetDailyTaskIndex(uint taskId)
    {
        for(int i = 0;i < dailyTask.Count; i++)
        {
            if(dailyTask[i].taskId == taskId)
            {
                return i;
            }
        }
        return -1;
    }

    public int GetWeekTaskIndex(uint taskId)
    {
        for (int i = 0; i < weeklyTask.Count; i++)
        {
            if (weeklyTask[i].taskId == taskId)
            {
                return i;
            }
        }
        return -1;
    }

    public void UpdateWeekTaskData(uint add)
    {
        foreach(var value in weeklyTask)
        {
            var vo = GetTaskConfig((int)value.taskId);
            if(vo.Type == 32)
            {
                value.curCnt += add;
            }
        }
    }

    public Ft_task_levelConfig GetTaskLvVoByLv(int lv = 0)
    {
        if(lv == 0)
        {
            lv = (int)MyselfModel.Instance.level;
        }
        var taskLvVo = taskLevelList.Find(value => value.Level == lv);
        if(taskLvVo == null)
        {
            if(lv < taskLevelList[0].Level)
            {
                taskLvVo = taskLevelList[0];
            }else if(lv > taskLevelList[taskLevelList.Count - 1].Level)
            {
                taskLvVo = taskLevelList[taskLevelList.Count - 1];
            }
        }
        return taskLvVo;
    }

    public void UpdateDrop(uint id,List<StorageItemVO> list)
    {
        if (DropMap.ContainsKey(id))
        {
            DropMap[id] = list;
        }
        else
        {
            DropMap.Add(id, list);
        }
    }

    public List<StorageItemVO> GetDrop(uint id)
    {
        if (DropMap.ContainsKey(id))
        {
           return DropMap[id];
        }
        return null;
    }

    public Ft_task_dailyConfig GetTaskConfig(int id)
    {
        if (taskDataMap.ContainsKey(id))
        {
            return taskDataMap[id];
        }
        return null;
    }

    public int GetTaskPercentage()
    {
        var taskLvVo = GetTaskLvVoByLv();
        return taskLvVo.Percentage;
    }

}

