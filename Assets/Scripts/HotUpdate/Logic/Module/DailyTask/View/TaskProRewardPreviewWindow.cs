using ADK;
using FairyGUI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskProRewardPreviewWindow : BaseView
{
    private fun_DailyTask.TaskProRewardPreview view;
    private int curIndex = 0;
    public TaskProRewardPreviewWindow()
    {
        packageName = "fun_DailyTask";
        // 设置委托
        BindAllDelegate = fun_DailyTask.fun_DailyTaskBinder.BindAll;
        CreateInstanceDelegate = fun_DailyTask.TaskProRewardPreview.CreateInstance;

    }

    public override void OnInit()
    {
        base.OnInit();
        view = ui as fun_DailyTask.TaskProRewardPreview;
        SetBg(view.bg, "Common/common_three_tip_bg.png");

        view.titleLab.text = Lang.GetValue("title_activity_3");
        view.poorLab.text = Lang.GetValue("incomplete");

        //StringUtil.SetBtnTab(view.day_btn, Lang.GetValue("Daily_task_17"));
        //StringUtil.SetBtnTab(view.week_btn, Lang.GetValue("task_6"));

        //StringUtil.SetBtnTab3(view.day_btn, Lang.GetValue("Daily_task_17"));
        //StringUtil.SetBtnTab3(view.week_btn, Lang.GetValue("task_6"));

        //view.list.itemRenderer = ListRenderer;


        //view.anim.loop = true;
        //view.anim.url = "meirerenwu";
        //view.anim.animationName = "animation";
        //InitPro();

        //view.list.height = view.close_btn.y - view.day_btn.y - 146;


        //view.day_btn.onClick.Add(() =>
        //{
        //    if (taskTabType != 0)
        //    {
        //        taskTabType = 0;
        //        UpdateTask();
        //    }
        //});

        //view.week_btn.onClick.Add(() =>
        //{
        //    if (taskTabType != 1)
        //    {
        //        taskTabType = 1;
        //        UpdateTask();
        //    }
        //});
        //AddEventListener(TaskEvent.TaskProAreward, UpdateTask);
        //EventManager.Instance.AddEventListener(DailyTaskEvent.DailyTask, UpdateTask);
        //EventManager.Instance.AddEventListener(PlayerEvent.GameCrossDay, UpdateTask);
    }
    private void InitReward()
    {
        var dayProData = TaskModel.Instance.GetTaskProList(1).Find(x => x.Id == curIndex)!;
        var rewardsData = dayProData.ProgressRewards;
        view.tipLab.text = Lang.GetValue("Daily_task_pro", "#7d7056", "#28aa09", dayProData.ProgressNum+"");
        view.list.itemRenderer = (int idx, GObject reward) =>
        {
            var value = rewardsData[idx];
            var rewardItem = reward as fun_DailyTask.DailyTaskCell;
            
            UILogicUtils.SetItemShow(rewardItem, IDUtil.GetEntityValue(value.EntityID));
            rewardItem.img.url = ImageDataModel.Instance.GetIconUrlByEntityId(value.EntityID);
            rewardItem.bg.url = "MyInfo/show_flower_bg3.png";
            var drop = new StorageItemVO();
            drop.itemDefId = IDUtil.GetEntityValue(value.EntityID);
            drop.count = 100;
        };
        view.list.numItems = rewardsData.Length;
    }
    public override void OnShown()
    {
        base.OnShown();
        curIndex = (int)data;
        //刷新显示
        InitReward();
    }
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}
