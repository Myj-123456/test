using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using protobuf.dailyTask;
using ADK;

public class AchievTaskView : BaseView
{
   private fun_DailyTask.achiev_task_view view;
    private int achievType = 0;

    private List<int> achievTypeData;

    private List<I_ACHIEV_TASK_VO> achievData;
    public AchievTaskView()
    {
        packageName = "fun_DailyTask";
        // 设置委托
        BindAllDelegate = fun_DailyTask.fun_DailyTaskBinder.BindAll;
        CreateInstanceDelegate = fun_DailyTask.achiev_task_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_DailyTask.achiev_task_view;
        SetBg(view.bg, "DailyTask/ELIDA_meirirenwu_bg02.png");
        SetBg(view.bg1, "DailyTask/ELIDA_meirirenwu_juanzhou_01.png");
        achievTypeData = TaskModel.Instance.GetAchievTypeList();
        view.titleLab.text = Lang.GetValue("building_achievement");
        view.tab_list.itemRenderer = RenderType;
        view.tab_list.numItems = achievTypeData.Count;
        view.tab_list.selectedIndex = achievType;

        view.achiev_list.itemRenderer = RenderAchiev;
        view.achiev_list.SetVirtual();

        view.anim.loop = true;
        view.anim.url = "meirerenwu";
        view.anim.animationName = "animation";

        view.achiev_list.height = view.close_btn.y - view.tab_list.y - 160;
        AddEventListener(TaskEvent.AchievTaskReward, UpdateAchiev);
        AddEventListener(TaskEvent.AchievTaskInfo, UpdateAchiev);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        TaskController.Instance.ReqAchievTaskInfo();
    }
    private void RenderType(int index, GObject item)
    {
        var cell = item as fun_DailyTask.page_btn;
        cell.titleLab.text = cell.titleLab1.text = Lang.GetValue("task_title_" + (index + 1));
        cell.data = index;
        cell.onClick.Add(AchievTab);
    }

    private void AchievTab(EventContext context)
    {
        var type = (int)(context.sender as GComponent).data;
        if (achievType != type)
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
    private void RenderAchiev(int index, GObject item)
    {
        var cell = item as fun_DailyTask.achiev_item;
        var achiev = achievData[index];
        var achievInfo = TaskModel.Instance.GetAchievInfo((int)achiev.taskId);
        cell.nameLab.text = Lang.GetValue(achievInfo.AchievName);
        cell.decLab.text = TaskModel.Instance.GetTaskDec(achievInfo.AchievDesc, achievInfo.TaskType, achievInfo.TaskNum, achievInfo.TypeParam, achievInfo.Ishistory);
        cell.pro.max = achievInfo.TaskNum;
        cell.pro.value = achiev.curCnt;
        cell.proLab.text = achiev.curCnt + "/" + achievInfo.TaskNum;
        
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
        if(achiev.awardStatus == 1)
        {
            StringUtil.SetBtnTab(cell.getBtn, Lang.GetValue("invite_friends_11"));
            cell.getBtn.enabled = false;
        }
        else if(achiev.curCnt < achievInfo.TaskNum)
        {
            StringUtil.SetBtnTab(cell.getBtn, Lang.GetValue("incomplete"));
            cell.getBtn.enabled = false;
        }
        else
        {
            StringUtil.SetBtnTab(cell.getBtn, Lang.GetValue("common_claim_button"));
            cell.getBtn.enabled = true;
        }
        cell.reward_list.numItems = achievInfo.Rewards.Length;
        cell.getBtn.data = achiev.taskId;
        cell.getBtn.onClick.Add(AchievReward);
    }

    private void AchievReward(EventContext context)
    {
        var id = (uint)(context.sender as GComponent).data;
        TaskController.Instance.ReqAchievTaskReward(id);
    }
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

