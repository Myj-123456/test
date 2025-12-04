using System.Collections;
using System.Collections.Generic;
using ADK;
using protobuf.dailyTask;
using protobuf.messagecode;
using UnityEngine;

public class DailyTaskController : BaseController<DailyTaskController>
{
    protected override void InitListeners()
    {
        AddNetListener<S_MSG_DAILY_TASK>((int)MessageCode.S_MSG_DAILY_TASK, DailyTask);
        AddNetListener<S_MSG_DAILY_TASK_AWARD>((int)MessageCode.S_MSG_DAILY_TASK_AWARD, DailyTaskAward);
    }

    public void DailyTask(S_MSG_DAILY_TASK data)
    {
        DailyTaskModel.Instance.dailyTask = data.dailyTask;
        DailyTaskModel.Instance.weeklyTask = data.weeklyTask;
        EventManager.Instance.DispatchEvent(DailyTaskEvent.DailyTask);
    }

    public void ReqDailyTask()
    {
        C_MSG_DAILY_TASK c_MSG_DAILY_TASK = new C_MSG_DAILY_TASK();
        SendCmd((int)MessageCode.C_MSG_DAILY_TASK, c_MSG_DAILY_TASK);
    }

    public void DailyTaskAward(S_MSG_DAILY_TASK_AWARD data)
    {
        var items = ItemModel.Instance.GetDropData(data.items);
        if (items != null && items.Count > 0)
        {
            UILogicUtils.ShowGetReward(items, () =>
            {
                //foreach(var item in items)
                //{
                //    StorageModel.Instance.AddToStorageByItemId(item.itemDefId, item.count);
                //}
                DropManager.ShowDrop(items);
            });
        }
        if(data.type == 1)
        {
            var taskInfo = DailyTaskModel.Instance.GetTaskConfig((int)data.dailyTask.taskId);
            var pro = TaskModel.Instance.GetProReward(3);
            pro.progress += (uint)taskInfo.Progress;
            EventManager.Instance.DispatchEvent(TaskEvent.MainTaskCount,32);

            var dayProData = TaskModel.Instance.GetProReward(1);
            dayProData.progress += (uint)taskInfo.Progress;
            DailyTaskModel.Instance.UpdateWeekTaskData((uint)taskInfo.Progress);

        }
        DailyTaskModel.Instance.UpdateTaskList(data.dailyTask,data.type);
        EventManager.Instance.DispatchEvent(DailyTaskEvent.DailyTask);
    }

    public void ReqDailyTaskAward(uint pos,uint type)
    {
        C_MSG_DAILY_TASK_AWARD c_MSG_DAILY_TASK_AWARD = new C_MSG_DAILY_TASK_AWARD();
        c_MSG_DAILY_TASK_AWARD.pos = pos;
        c_MSG_DAILY_TASK_AWARD.type = type;
        SendCmd((int)MessageCode.C_MSG_DAILY_TASK_AWARD, c_MSG_DAILY_TASK_AWARD);
    }
}
