using System.Collections;
using System.Collections.Generic;
using ADK;
using UnityEngine;
using FairyGUI;

public class TaskManger
{
    private fun_MainUI.task_com view;
    private TaskRewardObject[] rewards;
    public TaskManger(fun_MainUI.task_com cell)
    {
        view = cell;
        view.rect.onClick.Add(GetTaskReward);
        UpdateData();
        EventManager.Instance.AddEventListener(TaskEvent.MainTaskReward, UpdateData);
        EventManager.Instance.AddEventListener<int>(TaskEvent.MainTaskCount, UpdateTaskData);
        

        //view.spine1.url = "maomao";
        //view.spine1.loop = true;
        //view.spine1.forcePlay = true;

        //view.spine2.url = "zhujmrw";
        //view.spine2.loop = true;
        //view.spine2.forcePlay = true;
        
    }

    private void GetTaskReward()
    {
        var taskData = TaskModel.Instance.mainTask;
        if (taskData != null)
        {
            var taskInfo = TaskModel.Instance.GetTaskMainInfo((int)taskData.mainTaskId);
            if (taskInfo != null)
            {
                if (taskData.mainTaskCnt < taskInfo.TaskNum)
                {
                    OnJumpTask(taskData.mainTaskId);
                }
                else
                {
                    TaskController.Instance.ReqMainTaskReward(taskData.mainTaskId);
                }
            }
        }
    }

    /// <summary>
    /// 任务跳转
    /// </summary>
    private void OnJumpTask(uint taskId)
    {
        TaskJumpHelper.JumpTask(taskId);
    }

    public void UpdateData()
    {
        var taskData = TaskModel.Instance.mainTask;
        if (taskData.mainTaskId == 0)
        {
            view.visible = false;
            return;
        }
        Debug.Log("主线任务mainTaskId :" + taskData.mainTaskId);
        view.visible = true;
        var taskInfo = TaskModel.Instance.GetTaskMainInfo((int)taskData.mainTaskId);
        var addStr = taskInfo.Ishistory == 1 ? Lang.GetValue("main_task_4") : "";
        if (taskInfo.TaskType == 1 || taskInfo.TaskType == 2 || taskInfo.TaskType == 16 || taskInfo.TaskType == 23)
        {
            if (taskInfo.TypeParam == 0)
            {
                var str = "";
                if (taskInfo.TaskType == 1 || taskInfo.TaskType == 16)
                {
                    str = Lang.GetValue("main_task_1");
                }
                else if (taskInfo.TaskType == 2)
                {
                    str = Lang.GetValue("warehouse_03");
                }
                else
                {
                    str = Lang.GetValue("flower_arrangement_01");
                }
                view.decLab.text = taskData.mainTaskId + "." + addStr + Lang.GetValue(taskInfo.TaskDesc, Lang.GetValue("fund_6") + str, taskInfo.TaskNum.ToString());
            }
            else
            {
                var itemVo = ItemModel.Instance.GetItemById(taskInfo.TypeParam);
                view.decLab.text = taskData.mainTaskId + "." + addStr + Lang.GetValue(taskInfo.TaskDesc, Lang.GetValue(itemVo.Name), taskInfo.TaskNum.ToString());
            }

        }
        else if (taskInfo.TaskType == 24)
        {
            if (taskInfo.TypeParam == 0)
            {
                view.decLab.text = taskData.mainTaskId + "." + addStr + Lang.GetValue(taskInfo.TaskDesc, Lang.GetValue("main_task_1"));
            }
            else
            {
                var itemVo = ItemModel.Instance.GetItemById(taskInfo.TypeParam);
                view.decLab.text = taskData.mainTaskId + "." + addStr + Lang.GetValue(taskInfo.TaskDesc, Lang.GetValue(itemVo.Name));
            }
            
        }
        else if (taskInfo.TaskType == 33)
        {
            view.decLab.text = taskData.mainTaskId + "." + addStr + Lang.GetValue(taskInfo.TaskDesc);
        }
        else
        {
            view.decLab.text = taskData.mainTaskId + "." + addStr + Lang.GetValue(taskInfo.TaskDesc, taskInfo.TaskNum.ToString());
        }

        view.proLab.text = "(" + (taskData.mainTaskCnt > taskInfo.TaskNum ? taskInfo.TaskNum : taskData.mainTaskCnt) + "/" + taskInfo.TaskNum + ")";
        view.proLab.color = taskData.mainTaskCnt >= taskInfo.TaskNum ? StringUtil.HexToColor("#099e81") : StringUtil.HexToColor("#f36f54");
        rewards = taskInfo.TaskRewards;
        //if(taskData.mainTaskCnt >= taskInfo.TaskNum)
        //{
        //    view.spine2.animationName = "lingq";
        //    view.spine1.animationName = "lingq";
        //}
        //else
        //{
        //    view.spine2.animationName = "idle";
        //    view.spine1.animationName = "idle";
        //}
        var rewardVo = ItemModel.Instance.GetItemByEntityID(taskInfo.TaskRewards[0].EntityID);
        view.pic.url = ImageDataModel.Instance.GetIconUrl(rewardVo);
        view.numLab.text = taskInfo.TaskRewards[0].Value.ToString();

    }

    private void UpdateTaskData(int type)
    {

        var taskData = TaskModel.Instance.mainTask;
        if (taskData.mainTaskId == 0)
        {
            return;
        }
        var taskInfo = TaskModel.Instance.GetTaskMainInfo((int)(int)taskData.mainTaskId);
        if (type == 19 && taskInfo.TaskType == 19)
        {
            if (taskData.mainTaskCnt < taskInfo.TaskNum && PlantModel.Instance.unlockLand >= taskInfo.TaskNum)
            {
                TaskNotice.Instance.PlayShow();
            }
            taskData.mainTaskCnt = (uint)PlantModel.Instance.unlockLand;
        }
        else if (type == 20 && taskInfo.TaskType == 20)
        {
            if (taskData.mainTaskCnt < taskInfo.TaskNum && FlowerSellModel.Instance.unlockTable >= taskInfo.TaskNum)
            {
                TaskNotice.Instance.PlayShow();
            }
            taskData.mainTaskCnt = (uint)FlowerSellModel.Instance.unlockTable;

        }
        else if (type == 21 && taskInfo.TaskType == 21)
        {
            if (taskData.mainTaskCnt < taskInfo.TaskNum && MyselfModel.Instance.level >= taskInfo.TaskNum)
            {
                TaskNotice.Instance.PlayShow();
            }
            taskData.mainTaskCnt = (uint)MyselfModel.Instance.level;
        }
        else if (type == 4 && (taskInfo.TaskType == 4 || taskInfo.TaskType == 24))
        {
            if (taskInfo.TaskType == 4)
            {

                var count = StorageModel.Instance.seedCount;
                if (taskData.mainTaskCnt < taskInfo.TaskNum && count >= taskInfo.TaskNum)
                {
                    TaskNotice.Instance.PlayShow();
                }
                taskData.mainTaskCnt = (uint)count;
            }
            else
            {
                var bol = StorageModel.Instance.AlreadyUnlockSeed(taskInfo.TypeParam);
                if (taskData.mainTaskCnt < taskInfo.TaskNum && bol)
                {
                    TaskNotice.Instance.PlayShow();
                }
                if (bol)
                {
                    taskData.mainTaskCnt = 1;
                }
            }

        }
        else if (type == 32 && taskInfo.TaskType == 32)
        {
            var pro = TaskModel.Instance.GetProReward(3);
            if (taskData.mainTaskCnt < taskInfo.TaskNum && pro.progress >= taskInfo.TaskNum)
            {
                TaskNotice.Instance.PlayShow();
            }
            taskData.mainTaskCnt = pro.progress;
        }
        else if (type == 17 && taskInfo.TaskType == 17)
        {
            if (taskData.mainTaskCnt < taskInfo.TaskNum && FriendModel.Instance.friendCount >= taskInfo.TaskNum)
            {
                TaskNotice.Instance.PlayShow();
            }
            taskData.mainTaskCnt = FriendModel.Instance.friendCount;
        }
        else if (type == 33 && taskInfo.TaskType == 33)
        {
            if (taskData.mainTaskCnt < 1)
            {
                TaskNotice.Instance.PlayShow();
            }
            taskData.mainTaskCnt = 1;
        }
        UpdateData();
    }
}
