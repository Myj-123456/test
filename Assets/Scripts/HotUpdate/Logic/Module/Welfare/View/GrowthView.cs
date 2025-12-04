using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using Elida.Config;
using System;

public class GrowthView
{
   private fun_Welfare.growth_view view;
    private List<Ft_task_progressConfig> proData;
    private Dictionary<int, fun_Welfare.box1> boxMap;
    private int tabType;
    private List<Ft_rookie_taskConfig> listData;

    public GrowthView(fun_Welfare.growth_view ui)
    {
        view = ui;

        view.list.height = view.rect.y - view.pro.y - 177;
        view.scoreLab.text = Lang.GetValue("scoreLab");
        proData = TaskModel.Instance.GetTaskProList(5);
        boxMap = new Dictionary<int, fun_Welfare.box1>();
        InitPro();

        view.list.itemRenderer = RenderList;
        view.list.SetVirtual();

        view.page_list.itemRenderer = RenderPageList;

        EventManager.Instance.AddEventListener(WelfareEvent.RookieInfo,UpdateData);
        EventManager.Instance.AddEventListener(WelfareEvent.RookieReward,UpdateList);
        EventManager.Instance.AddEventListener(TaskEvent.TaskProAreward, UpdatePro);
        EventManager.Instance.AddEventListener(PlayerEvent.GameCrossDay, UpdatePageList);
    }

    private void InitPro()
    {
        var max = proData[proData.Count - 1].ProgressNum;
        view.pro.max = max;
        for (int i = 0; i < proData.Count; i++)
        {
            var value = proData[i];
            var cell = fun_Welfare.box1.CreateInstance();
            view.pro.AddChild(cell);
            cell.y = -62;
            var x = view.pro.width * ((float)value.ProgressNum / (float)max) - cell.width / 2;
            cell.x = x;
            cell.type.selectedIndex = i == proData.Count - 1 ? 1 : 0;
            var itemVo = ItemModel.Instance.GetItemByEntityID(value.ProgressRewards[0].EntityID);
            cell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
            cell.pic1.url = ImageDataModel.Instance.GetIconUrl(itemVo);
            cell.numLab.text = value.ProgressRewards[0].Value.ToString();
            cell.day_num.text = value.ProgressNum.ToString();
            cell.rect.data = value;
            cell.rect.onClick.Add(ProReward);
            cell.data = value;
            boxMap.Add(i, cell);
        }
    }
    private void ProReward(EventContext context)
    {
        var item = (context.sender as GObject).parent as fun_Welfare.box1;
        var proInfo = item.data as Ft_task_progressConfig;
        if (item.status.selectedIndex == 1)
        {
            TaskController.Instance.ReqTaskProAreward((uint)proInfo.Id);
        }
        else
        {
            var itemVo = ItemModel.Instance.GetItemByEntityID(proInfo.ProgressRewards[0].EntityID);
            UILogicUtils.ShowItemGainTips(itemVo.ItemDefId);
        }
    }
    public void OnShown()
    {
        WelfareController.Instance.ReqRookieInfo();
        UpdatePro();
    }
    private void UpdateData()
    {
        tabType = (int)WelfareModel.Instance.days - 1;
        view.tab.selectedIndex = tabType;
        
        UpdateList();
        UpdatePageList();
        view.page_list.selectedIndex = tabType;
    }
    private void UpdatePageList()
    {
        view.page_list.numItems = 7;
    }
    private void UpdateList()
    {
        listData = WelfareModel.Instance.GetDayList(tabType + 1);
        view.list.numItems = listData.Count;
    }

    private void RenderList(int index,GObject item)
    {
        var cell = item as fun_Welfare.growth_item;
        var taskInfo = listData[index];
        var taskNum = WelfareModel.Instance.GetRookieTaskNum((uint)taskInfo.IndexId);
        cell.status.selectedIndex = WelfareModel.Instance.GetStatusRookie((uint)taskInfo.IndexId);
        StringUtil.SetBtnTab(cell.goto_btn, Lang.GetValue("travel_button_go"));
        if(cell.status.selectedIndex == 2)
        {
            StringUtil.SetBtnTab(cell.get_btn, Lang.GetValue("invite_friends_11"));
        }
        else
        {
            StringUtil.SetBtnTab(cell.get_btn, Lang.GetValue("invite_friends_10"));
        }
        if(taskInfo.TaskNum > taskNum)
        {
            cell.proLab.text = "<font color = '#d4580d'>" + taskNum + "</font>/" + taskInfo.TaskNum;
        }
        else
        {
            cell.proLab.text = "<font color = '#624A4B'>" + taskInfo.TaskNum + "</font>/" + taskInfo.TaskNum;
        }

        cell.titleLab.text = TaskModel.Instance.GetTaskDec(taskInfo.TaskDesc, taskInfo.TaskType, taskInfo.TaskNum, taskInfo.TypeParam);
        cell.list.itemRenderer = (int idx, GObject rewardItem) =>
        {
            var rewardCell = rewardItem as fun_Welfare.reward_item;
            var rewardInfo = taskInfo.Rewards[idx];
            var itemVo = ItemModel.Instance.GetItemByEntityID(rewardInfo.EntityID);
            rewardCell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
            rewardCell.bg.url = ImageDataModel.Instance.GetItemQuality(itemVo.Quality);
            rewardCell.numLab.text = TextUtil.ChangeCoinShow(rewardInfo.Value);
            UILogicUtils.SetItemShow(rewardCell, itemVo.ItemDefId);
        };
        cell.list.numItems = taskInfo.Rewards.Length;
        cell.goto_btn.data = taskInfo.JumpId;
        cell.get_btn.data = taskInfo.IndexId;
        cell.goto_btn.onClick.Add(OnGo);
        cell.get_btn.onClick.Add(GetReward);
    }
    private void OnGo(EventContext context)
    {
        var id = (int)(context.sender as GComponent).data;
        var ft_jumpConfig = GlobalModel.Instance.GetFt_jumpConfig(id);
        UIManager.Instance.CloseAllWindown();
        UIManager.Instance.ClosePanel(UIName.WelfareMainView);
        if (ft_jumpConfig.JumpType == 1)
        {
            UIManager.Instance.OpenPanelByName(ft_jumpConfig.JumpParam);
        }
    }
    private void GetReward(EventContext context)
    {
        var id = (int)(context.sender as GComponent).data;
        WelfareController.Instance.ReqRookieReward((uint)id);
    }
    private void RenderPageList(int index,GObject item)
    {
        var cell = item as fun_Welfare.day_btn;
        cell.type.selectedIndex = index;
        cell.unlock.selectedIndex = WelfareModel.Instance.days > index?0:1;
        cell.data = index;
        cell.onClick.Add(SelectDay);
    }
    private void SelectDay(EventContext context)
    {
        var index = (int)(context.sender as GComponent).data;
        if(tabType != index)
        {
            tabType = index;
            UpdateList();
        }
    }
    private void UpdatePro()
    {
        var proServer = TaskModel.Instance.GetProReward(5);
        view.pro.value = proServer.progress;
        view.score_num.text = proServer.progress.ToString();
        foreach (var value in boxMap)
        {
            var proInfo = value.Value.data as Ft_task_progressConfig;
            if (proServer.rewardId == null || Array.IndexOf(proServer.rewardId, (uint)proInfo.Id) == -1)
            {
                if (proServer.progress < proInfo.ProgressNum)
                {
                    value.Value.status.selectedIndex = 0;
                }
                else
                {
                    value.Value.status.selectedIndex = 1;
                }
            }
            else
            {
                value.Value.status.selectedIndex = 2;
            }
        }
    }
    public void OnHide()
    {
        
    }
}

