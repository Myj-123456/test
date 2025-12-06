using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using ADK;
using Elida.Config;
using protobuf.dailyTask;

public class DailyTaskWindow : BaseView
{
   private fun_DailyTask.daily_task_view view;
    private bool isPlay = false;
    private int taskTabType = 0;
    private Dictionary<int, fun_DailyTask.pro_item> dayItems;
    private Dictionary<int, fun_DailyTask.pro_item> weekItems;

    public DailyTaskWindow()
    {
        packageName = "fun_DailyTask";
        // 设置委托
        BindAllDelegate = fun_DailyTask.fun_DailyTaskBinder.BindAll;
        CreateInstanceDelegate = fun_DailyTask.daily_task_view.CreateInstance;
        
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_DailyTask.daily_task_view;
        //view.refreshTipTxt.text = Lang.GetValue("slang_67");//任务会在每日0点更新哦!
        //view.giftTipTxt.text = Lang.GetValue("slang_68");//完成所有任务可额外获得礼包一个
        string str = Lang.GetValue("Daily_task_17");
        //view.title1.text = str.Substring(0,2);
        //view.title2.text = str.Substring(2, 2);
        SetBg(view.bg,"DailyTask/ELIDA_meirirenwu_bg02.png");
        SetBg(view.bg1,"DailyTask/ELIDA_meirirenwu_juanzhou_01.png");
        view.titleLab.text = Lang.GetValue("COC_Tab_Task");

        StringUtil.SetBtnTab(view.day_btn, Lang.GetValue("Daily_task_17"));
        StringUtil.SetBtnTab(view.week_btn, Lang.GetValue("task_6"));

        StringUtil.SetBtnTab3(view.day_btn, Lang.GetValue("Daily_task_17"));
        StringUtil.SetBtnTab3(view.week_btn, Lang.GetValue("task_6"));

        view.list.itemRenderer = ListRenderer;
       

        view.anim.loop = true;
        view.anim.url = "meirerenwu";
        view.anim.animationName = "animation";
        InitPro();

        view.list.height = view.close_btn.y - view.day_btn.y - 146;
        

        view.day_btn.onClick.Add(() =>
        {
            if(taskTabType != 0)
            {
                taskTabType = 0;
                UpdateTask();
            }
        });

        view.week_btn.onClick.Add(() =>
        {
            if (taskTabType != 1)
            {
                taskTabType = 1;
                UpdateTask();
            }
        });
        AddEventListener(TaskEvent.TaskProAreward, UpdateTask);
        EventManager.Instance.AddEventListener(DailyTaskEvent.DailyTask, UpdateTask);
        EventManager.Instance.AddEventListener(PlayerEvent.GameCrossDay, UpdateTask);
    }


    private void InitPro()
    {
        var dayProData = TaskModel.Instance.GetTaskProList(1);
        dayItems = new Dictionary<int, fun_DailyTask.pro_item>();
        var dayMax = dayProData[dayProData.Count - 1].ProgressNum;
        view.pro_day_com.pro.max = dayMax;
        foreach (var value in dayProData)
        {
            var item = fun_DailyTask.pro_item.CreateInstance();
            view.pro_day_com.AddChild(item);
            item.y = -38;
            var x = view.pro_day_com.width * ((float)value.ProgressNum / (float)dayMax);
            item.x = x;
            item.data = value.Id;
            item.onClick.Add(DayGetProReward);
            dayItems.Add(value.Id, item);
        }
    }

    private void DayGetProReward(EventContext context)
    {
        var id = (int)(context.sender as GComponent).data;
        TaskController.Instance.ReqTaskProAreward((uint)id);
    }
    private void WeekGetProReward(EventContext context)
    {
        var id = (int)(context.sender as GComponent).data;
        TaskController.Instance.ReqTaskProAreward((uint)id);
    }
    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        taskTabType = (int)data;
        view.tab.selectedIndex = taskTabType;
        isPlay = false;
        DailyTaskController.Instance.ReqDailyTask();
    }

    private void ListRenderer(int index,GObject cell)
    {
        fun_DailyTask.DailyTaskItem item = cell as fun_DailyTask.DailyTaskItem;
        var obj = taskTabType == 0? DailyTaskModel.Instance.dailyTask[index]: DailyTaskModel.Instance.weeklyTask[index];
        var vo = DailyTaskModel.Instance.GetTaskConfig((int)obj.taskId);
        
        item.getBtn.data = obj.pos;
        item.nameTxt.text = Lang.GetValue(vo.Title);
        item.taskTxt.text = TaskModel.Instance.GetTaskDec(vo.Description,vo.TaskType, (int)obj.needNum, vo.TypeParam,vo.Ishistory);
        //item.goldLoader.url = ImageDataModel.GOLD_ICON_URL;
        //item.expLoader.url = ImageDataModel.EXP_ICON_URL;
        var dropList = new List<StorageItemVO>();
        item.list.itemRenderer = (int idx, GObject reward) =>
        {
            var value = vo.Rewards[idx];
            var rewardItem = reward as fun_DailyTask.DailyTaskCell;
            int rate = DailyTaskModel.Instance.GetTaskPercentage();
            double totalCount = Math.Ceiling((double)(value.Value * rate * obj.needNum) / 100);
            if(IDUtil.GetEntityValue(value.EntityID) == (int)BaseType.EXP)
            {
                rewardItem.count.text = Mathf.Ceil((float)totalCount *(1 + MyselfModel.Instance.CurrVipExp()/100f)).ToString();
            }
            else
            {
                rewardItem.count.text = totalCount.ToString();
            }
            UILogicUtils.SetItemShow(rewardItem, IDUtil.GetEntityValue(value.EntityID));
            rewardItem.img.url = ImageDataModel.Instance.GetIconUrlByEntityId(value.EntityID);
            rewardItem.bg.url = "MyInfo/show_flower_bg3.png";
            var drop = new StorageItemVO();
            drop.itemDefId = IDUtil.GetEntityValue(value.EntityID);
            drop.count = (int)totalCount;
            dropList.Add(drop);
        };
        DailyTaskModel.Instance.UpdateDrop(obj.taskId, dropList);
        item.list.numItems = vo.Rewards.Length;
        //item.iconSpecified.selectedIndex = vo.TaskType - 1;
        var color = obj.curCnt >= obj.needNum ? "#4D4B4B" : "#f57c68";
        item.progressTxt.text = Lang.GetValue("Daily_task_16", color, obj.curCnt.ToString(), obj.needNum.ToString());

        StringUtil.SetBtnTab(item.getBtn1, Lang.GetValue("Treasure_button5"));
        StringUtil.SetBtnTab(item.getBtn, Lang.GetValue("common_claim_button"));
        item.receiveStatus.selectedIndex = (int)obj.awardStatus;
        item.getBtn.onClick.Add(GetdailyTaskReward);
    }

    private void GetdailyTaskReward(EventContext context)
    {
        uint pos = (uint)(context.sender as GComponent).data;
        DailyTaskController.Instance.ReqDailyTaskAward(pos,(uint)(taskTabType == 0?1:2));
    }

    private void UpdateTask()
    {
        if(taskTabType == 0)
        {
            view.list.numItems = DailyTaskModel.Instance.dailyTask.Count;
            var dayProData = TaskModel.Instance.GetProReward(1);
            view.proLab.text = dayProData.progress.ToString();
            view.pro_day_com.pro.value = dayProData.progress;

            foreach (var value in dayItems)
            {
                var item = value.Value;
                var proInfo = TaskModel.Instance.GetTaskProInfo(value.Key);
                item.proLab.text = proInfo.ProgressNum.ToString();
                if(dayProData.rewardId != null && Array.IndexOf(dayProData.rewardId, (uint)value.Key) != -1)
                {

                }else if(dayProData.progress > proInfo.ProgressNum)
                {

                }
                else
                {

                }
            }
        }
        else
        {
            view.list.numItems = DailyTaskModel.Instance.weeklyTask.Count;    
        }

    }

    private void StartMove()
    {
        //view.getGiftBtn.onRollOut.Add(StopMove);
        var itemVoList = new List<StorageItemVO>();
        foreach(var reward in GlobalModel.Instance.module_profileConfig.dailyTaskBoxReward)
        {
            var vo = new StorageItemVO();
            vo.itemDefId = IDUtil.GetEntityValue(reward.Key);
            vo.count = reward.Value;
            itemVoList.Add(vo);
        }
        //var pos = view.getGiftBtn.LocalToRoot(new Vector2(view.getGiftBtn.width, view.getGiftBtn.height),GRoot.inst);
        //var offset = new float[] { pos.x, pos.y };
        //var param = new object[] { itemVoList, offset };
        
        //ShowRewardWindow.OnShown(param);
    }

    private void StopMove()
    {
        //view.getGiftBtn.onRollOut.Remove(StopMove);
        //UIManager.Instance.CloseWindow(UIName.ShowRewardWindow);
        ShowRewardWindow.HideShowReward();
    }

    private void CloseView()
    {
        UIManager.Instance.CloseWindow(UIName.DailyTaskWindow);
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

