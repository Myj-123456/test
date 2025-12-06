using System.Collections;
using System.Collections.Generic;
using ADK;
using protobuf.dailyTask;
using protobuf.messagecode;
using UnityEngine;

public class TaskController : BaseController<TaskController>
{
    protected override void InitListeners()
    {
        //领取主线任务奖励
        AddNetListener<S_MSG_MAINTASK_REWARD>((int)MessageCode.S_MSG_MAINTASK_REWARD, MainTaskReward);
        //进度奖励
        AddNetListener<S_MSG_TASK_PROGRESS_AWARD>((int)MessageCode.S_MSG_TASK_PROGRESS_AWARD, TaskProAreward);
        //成就任务信息
        AddNetListener<S_MSG_ACHIEV_TASK_INFO>((int)MessageCode.S_MSG_ACHIEV_TASK_INFO, AchievTaskInfo);
        //成就任务-领取奖励
        AddNetListener<S_MSG_ACHIEV_TASK_REWARD>((int)MessageCode.S_MSG_ACHIEV_TASK_REWARD, AchievTaskReward);
    }

    public void MainTaskReward(S_MSG_MAINTASK_REWARD data)
    {
        var dropList = ItemModel.Instance.GetDropData(data.items);
        UILogicUtils.ShowGetReward(dropList, () =>
        {
            DropManager.ShowDrop(dropList);
        });
        TaskModel.Instance.mainTask.mainTaskCnt = data.mainTaskCnt;
        TaskModel.Instance.mainTask.mainTaskId = data.mainTaskId;
        DispatchEvent(TaskEvent.MainTaskReward);
        DispatchEvent(TaskEvent.ResMainTaskReward, mainTaskId);
    }


    private uint mainTaskId;
    public void ReqMainTaskReward(uint mainTaskId)
    {
        this.mainTaskId = mainTaskId;
        C_MSG_MAINTASK_REWARD c_MSG_MAINTASK_REWARD = new C_MSG_MAINTASK_REWARD();
        SendCmd((int)MessageCode.C_MSG_MAINTASK_REWARD, c_MSG_MAINTASK_REWARD);
    }
    //进度奖励
    public void TaskProAreward(S_MSG_TASK_PROGRESS_AWARD data)
    {
        var dropList = ItemModel.Instance.GetDropData(data.items);
        DropManager.ShowDrop(dropList);
        TaskModel.Instance.UpdateProReward(data.type, data.rewardIds);
        DispatchEvent(TaskEvent.TaskProAreward);
    }

    public void ReqTaskProAreward(uint id)
    {
        C_MSG_TASK_PROGRESS_AWARD c_MSG_TASK_PROGRESS_AWARD = new C_MSG_TASK_PROGRESS_AWARD();
        c_MSG_TASK_PROGRESS_AWARD.indexId = id;
        SendCmd((int)MessageCode.C_MSG_TASK_PROGRESS_AWARD, c_MSG_TASK_PROGRESS_AWARD);
    }
    //成就任务信息
    public void AchievTaskInfo(S_MSG_ACHIEV_TASK_INFO data)
    {
        TaskModel.Instance.achievTaskList = data.achievTaskList;
        DispatchEvent(TaskEvent.AchievTaskInfo);
    }

    public void ReqAchievTaskInfo()
    {
        C_MSG_ACHIEV_TASK_INFO c_MSG_ACHIEV_TASK_INFO = new C_MSG_ACHIEV_TASK_INFO();
        SendCmd((int)MessageCode.C_MSG_ACHIEV_TASK_INFO, c_MSG_ACHIEV_TASK_INFO);
    }
    //成就任务-领取奖励
    public void AchievTaskReward(S_MSG_ACHIEV_TASK_REWARD data)
    {
        var dropList = ItemModel.Instance.GetDropData(data.items);
        DropManager.ShowDrop(dropList);
        TaskModel.Instance.UpdateAchievData(data.achievTask);
        DispatchEvent(TaskEvent.AchievTaskReward);
    }

    public void ReqAchievTaskReward(uint seriesId)
    {
        C_MSG_ACHIEV_TASK_REWARD c_MSG_ACHIEV_TASK_REWARD = new C_MSG_ACHIEV_TASK_REWARD();
        c_MSG_ACHIEV_TASK_REWARD.taskId = seriesId;
        SendCmd((int)MessageCode.C_MSG_ACHIEV_TASK_REWARD, c_MSG_ACHIEV_TASK_REWARD);
    }
}
