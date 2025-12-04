using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using ADK;
using System;

public class DaySignWindow : BaseWindow
{
   private fun_Welfare.day_sign_view view;
    private List<Ft_task_progressConfig> proData;
    private Dictionary<int, fun_Welfare.box> boxMap;
    private List<Ft_sign_dayConfig> listData;
    private CountDownTimer timer;
    public DaySignWindow()
    {
        packageName = "fun_Welfare";
        // 设置委托
        BindAllDelegate = fun_Welfare.fun_WelfareBinder.BindAll;
        CreateInstanceDelegate = fun_Welfare.day_sign_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Welfare.day_sign_view;

        SetBg(view.bg, "Welfare/ELIDA_meiriqiandao_bg1.png");

        view.list.itemRenderer = RenderList;
        view.list.SetVirtual();
        boxMap = new Dictionary<int, fun_Welfare.box>();

        listData = WelfareModel.Instance.signList;
        proData = TaskModel.Instance.GetTaskProList(4);
        InitPro();

        StringUtil.SetBtnTab(view.sign_btn, Lang.GetValue("welfare_main_6"));
        StringUtil.SetBtnTab(view.cost_btn, Lang.GetValue("welfare_main_7"));
        StringUtil.SetBtnTab(view.getted, Lang.GetValue("welfare_main_8"));
        view.sign_btn.onClick.Add(() =>
        {
            WelfareController.Instance.ReqDailySign();
        });
        view.cost_btn.onClick.Add(() =>
        {
            var costs = GlobalModel.Instance.module_profileConfig.signDayCost;
            var index = WelfareModel.Instance.retroactiveDays >= costs.Count ? costs.Count - 1 : (int)WelfareModel.Instance.retroactiveDays;
            if (MyselfModel.Instance.diamond < costs[index])
            {

                return;
            }
            WelfareController.Instance.ReqDailyRetroactive();
        });
        EventManager.Instance.AddEventListener(TaskEvent.TaskProAreward, UpdatePro);
        EventManager.Instance.AddEventListener(WelfareEvent.DailyRetroactive, UpdateData);
        EventManager.Instance.AddEventListener(WelfareEvent.DailySign, UpdateData);
        EventManager.Instance.AddEventListener(PlayerEvent.GameCrossDay, UpdateAllData);
    }
    private void InitPro()
    {
        var max = proData[proData.Count - 1].ProgressNum;
        view.pro.max = max;
        for (int i = 0; i < proData.Count; i++)
        {
            var value = proData[i];
            var cell = fun_Welfare.box.CreateInstance();
            view.pro.AddChild(cell);
            cell.y = -73;
            var x = view.pro.width * ((float)value.ProgressNum / (float)max) - cell.width / 2;
            cell.x = x;
            var itemVo = ItemModel.Instance.GetItemByEntityID(value.ProgressRewards[0].EntityID);
            cell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
            cell.numLab.text = value.ProgressRewards[0].Value.ToString();
            cell.day_num.text = value.ProgressNum.ToString();
            cell.data = value;
            cell.onClick.Add(ProReward);
            boxMap.Add(i, cell);
        }
    }
    private void ProReward(EventContext context)
    {
        var item = context.sender as fun_Welfare.box;
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
    public override void OnShown()
    {
        base.OnShown();
        Saver.SaveAsString<int>("DaySign" + MyselfModel.Instance.userId, (int)ServerTime.Time);
        // 其他打开面板的逻辑
        UpdateData();
        UpdateTime();
        view.list.ScrollToView((int)WelfareModel.Instance.signDay);
    }
    private void UpdateAllData()
    {
        UpdateData();
        UpdateTime();
    }
    private void UpdateData()
    {
        if (!WelfareModel.Instance.isSign)
        {
            view.cost_btn.visible = false;
            view.sign_btn.visible = true;
            view.getted.visible = false;
        }
        else if (WelfareModel.Instance.currentSignDay == WelfareModel.Instance.signDay)
        {
            view.cost_btn.visible = false;
            view.sign_btn.visible = false;
            view.getted.visible = true;
        }
        else
        {
            view.cost_btn.visible = true;
            view.sign_btn.visible = false;
            view.getted.visible = false;
        }
        view.sign_num.text = Lang.GetValue("welfare_main_8") + "：" + WelfareModel.Instance.signDay.ToString();
        var costs = GlobalModel.Instance.module_profileConfig.signDayCost;
        var index = WelfareModel.Instance.retroactiveDays >= costs.Count ? costs.Count - 1 : (int)WelfareModel.Instance.retroactiveDays;
        if (index > -1)
        {
            StringUtil.SetBtnCount(view.cost_btn, costs[index].ToString());
        }

        UpdateList();
        UpdatePro();
    }
    private void UpdateList()
    {
        view.list.numItems = listData.Count;
    }
    private void UpdatePro()
    {
        var proServer = TaskModel.Instance.GetProReward(4);
        view.pro.value = proServer.progress;
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
    private void RenderList(int index, GObject item)
    {
        var cell = item as fun_Welfare.sign_item1;
        var info = listData[index];
        cell.day_num.text = TextUtil.ToChineseNumber(info.Id);
        var itemVo = ItemModel.Instance.GetItemByEntityID(info.ItemIds[0].EntityID);
        cell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        cell.numLab.text = info.ItemIds[0].Value.ToString();

        if (info.Id == (WelfareModel.Instance.signDay + 1) && (WelfareModel.Instance.signDay < WelfareModel.Instance.currentSignDay))
        {
            cell.type.selectedIndex = 1;
        }
        else
        {
            cell.type.selectedIndex = 0;
        }
        if (info.Id <= WelfareModel.Instance.signDay)
        {
            cell.status.selectedIndex = 2;
        }
        else if (info.Id <= WelfareModel.Instance.currentSignDay && !(info.Id == (WelfareModel.Instance.signDay + 1) && !WelfareModel.Instance.isSign))
        {
            cell.status.selectedIndex = 1;
        }
        else
        {
            cell.status.selectedIndex = 0;
        }
        UILogicUtils.SetItemShow(cell, itemVo.ItemDefId);
    }

    private void UpdateTime()
    {
        if (timer != null)
        {
            timer.Clear();
            timer = null;
        }
        var endTime = GetEndTime();
        view.timeLab.text = "";
        timer = new CountDownTimer(view.timeLab, endTime, false);
        timer.prefixString = Lang.GetValue("lshop_ui_label_duration") + "：";
        timer.Run();
    }

    private int GetEndTime()
    {
        var day = 30 - WelfareModel.Instance.currentSignDay - 1;
        var curTime = TimeUtil.GetDateTime(ServerTime.Time);
        var nextDay = curTime.Date.AddDays(1);
        //var endTime = TimeUtil.GetTimestamp(nextDay);
        TimeSpan timeLeft = nextDay - curTime;
        var endTime = timeLeft.TotalSeconds + day * 24 * 60 * 60;
        return (int)endTime;
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
        if (timer != null)
        {
            timer.Clear();
            timer = null;
        }
    }
}

