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
   private fun_DailyTask.DailyTask view;
    private bool isPlay = false;
    private int tabType = 0;

    private int taskTabType = 0;

    private int achievType = 0;

    private Dictionary<int, fun_DailyTask.pro_item> dayItems;
    private Dictionary<int, fun_DailyTask.pro_item> weekItems;

    private List<int> achievTypeData;

    private List<I_ACHIEV_TASK_VO> achievData;
    public DailyTaskWindow()
    {
        packageName = "fun_DailyTask";
        // 设置委托
        BindAllDelegate = fun_DailyTask.fun_DailyTaskBinder.BindAll;
        CreateInstanceDelegate = fun_DailyTask.DailyTask.CreateInstance;
        
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_DailyTask.DailyTask;
        //view.refreshTipTxt.text = Lang.GetValue("slang_67");//任务会在每日0点更新哦!
        //view.giftTipTxt.text = Lang.GetValue("slang_68");//完成所有任务可额外获得礼包一个
        string str = Lang.GetValue("Daily_task_17");
        //view.title1.text = str.Substring(0,2);
        //view.title2.text = str.Substring(2, 2);
        SetBg(view.bg,"DailyTask/ELIDA_meirirenwu_bg02.png");
        SetBg(view.bg1,"DailyTask/ELIDA_meirirenwu_juanzhou_01.png");
        achievTypeData = TaskModel.Instance.GetAchievTypeList();

        StringUtil.SetBtnTab(view.task_btn, Lang.GetValue("COC_Tab_Task"));
        StringUtil.SetBtnTab(view.achiev_btn, Lang.GetValue("building_achievement"));
        StringUtil.SetBtnTab3(view.task_btn, Lang.GetValue("COC_Tab_Task"));
        StringUtil.SetBtnTab3(view.achiev_btn, Lang.GetValue("building_achievement"));

        StringUtil.SetBtnTab(view.day_btn, Lang.GetValue("Daily_task_17"));
        StringUtil.SetBtnTab(view.week_btn, Lang.GetValue("task_6"));

        StringUtil.SetBtnTab3(view.day_btn, Lang.GetValue("Daily_task_17"));
        StringUtil.SetBtnTab3(view.week_btn, Lang.GetValue("task_6"));

        view.list.itemRenderer = ListRenderer;
        view.tab_list.itemRenderer = RenderType;
        view.tab_list.numItems = achievTypeData.Count;
        view.tab_list.selectedIndex = achievType;

        view.achiev_list.itemRenderer = RenderAchiev;
        view.achiev_list.SetVirtual();

        view.anim.loop = true;
        view.anim.url = "meirerenwu";
        view.anim.animationName = "animation";
        InitPro();

        view.list.height = view.close_btn.y - view.day_btn.y - 130;
        view.achiev_btn.height = view.close_btn.y - view.tab_list.y - 125;

        view.task_btn.onClick.Add(() =>
        {
            if(tabType != 0)
            {
                ChangeTab(0);
            }
        });

        view.achiev_btn.onClick.Add(() =>
        {
            if (tabType != 1)
            {
                ChangeTab(1);
            }
        });

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

        EventManager.Instance.AddEventListener(DailyTaskEvent.DailyTask, UpdateData);
        AddEventListener(TaskEvent.AchievTaskInfo, UpdateData);
        EventManager.Instance.AddEventListener(PlayerEvent.GameCrossDay, UpdateData);
        AddEventListener(TaskEvent.AchievTaskReward, UpdateAchiev);
    }

    private void RenderType(int index,GObject item)
    {
        var cell = item as fun_DailyTask.page_btn1;
        cell.titleLab.text = cell.titleLab1.text = Lang.GetValue("task_title_" + (index + 1));
        cell.data = index;
        cell.onClick.Add(AchievTab);
    }

    private void AchievTab(EventContext context)
    {
        var type = (int)(context.sender as GComponent).data;
        if(achievType != type)
        {
            achievType = type;
            UpdateAchiev();
        }
    }

    private void UpdateAchiev()
    {
        achievData = TaskModel.Instance.GetAchievList(achievType + 1);
        view.achiev_list.numItems = achievData.Count;
    }

    private void RenderAchiev(int index,GObject item)
    {
        var cell = item as fun_DailyTask.achiev_item;
        var achiev = achievData[index];
        var achievInfo = TaskModel.Instance.GetAchievInfo((int)achiev.taskId);
        cell.nameLab.text = Lang.GetValue(achievInfo.AchievName);
        cell.decLab.text = TaskModel.Instance.GetTaskDec(achievInfo.AchievDesc, achievInfo.TaskType,achievInfo.TaskNum,achievInfo.TypeParam,achievInfo.Ishistory);
        cell.pro.max = achievInfo.TaskNum;
        cell.pro.value = achiev.curCnt;
        cell.proLab.text = achiev.curCnt + "/" + achievInfo.TaskNum;
        StringUtil.SetBtnTab(cell.getBtn, Lang.GetValue("common_claim_button"));
        cell.reward_list.itemRenderer = (int idx, GObject reward) =>
        {
            var value = achievInfo.Rewards[idx];
            var rewardItem = reward as fun_DailyTask.DailyTaskCell;
            float rate = (MyselfModel.Instance.CurrVipExp() / 100f) + 1;
            if (IDUtil.GetEntityValue(value.EntityID) == (int)BaseType.EXP)
            {
                rewardItem.count.text = Mathf.Ceil(rate * value.Value).ToString();
            }
            else
            {
                rewardItem.count.text = value.Value.ToString();
            }
            UILogicUtils.SetItemShow(rewardItem, IDUtil.GetEntityValue(value.EntityID));
            rewardItem.img.url = ImageDataModel.Instance.GetIconUrlByEntityId(value.EntityID);
            rewardItem.bg.url = "MyInfo/show_flower_bg1.png";
        };
        
        cell.reward_list.numItems = achievInfo.Rewards.Length;
        cell.getBtn.enabled = achiev.curCnt >= achievInfo.TaskNum;
        cell.getBtn.data = achiev.seriesId;
        cell.getBtn.onClick.Add(AchievReward);
    }

    private void AchievReward(EventContext context)
    {
        var id = (uint)(context.sender as GComponent).data;
        TaskController.Instance.ReqAchievTaskReward(id);
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
        isPlay = false;
        int index = (int)data;
        view.tab.selectedIndex = index;
        ChangeTab(index);
    }
    private void ChangeTab(int type)
    {
        tabType = type;
        if(tabType == 0)
        {
            DailyTaskController.Instance.ReqDailyTask();
        }
        else
        {
            TaskController.Instance.ReqAchievTaskInfo();
        }
    }
    private void UpdateData()
    {
        //double pro = DailyTaskModel.Instance.doneTaskNum / DailyTaskModel.TASK_COUNT;
        //view.progressBar.value = pro * 100;
        //view.progressTxt.text = "<font color = '#f57863'>" + "</font>/" + DailyTaskModel.TASK_COUNT.ToString();
        if(tabType == 0)
        {
            if (!isPlay)
            {
                isPlay = true;
                //UILogicUtils.AddTweenOfViewList(view.list);
            }
            UpdateTask();
        }
        else
        {
            UpdateAchiev();
        }
        
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
                if (dayProData.progress > proInfo.ProgressNum)
                {
                    
                }
                else if(dayProData.rewardId != null && Array.IndexOf(dayProData.rewardId,(uint)value.Key) != -1)
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

