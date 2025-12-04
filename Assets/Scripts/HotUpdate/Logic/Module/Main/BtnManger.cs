using System.Collections;
using System.Collections.Generic;
using ADK;
using UnityEngine;

public class MatchBtn
{
    private fun_MainUI.funLeftBtn view;
    private CountDownTimer timer;
    public MatchBtn(fun_MainUI.funLeftBtn ui)
    {
        view = ui;
        var guild = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_GUILD_ID);
        if (GlobalModel.Instance.GetUnlocked(SysId.Guild) && !(guild == null || guild.info == "" || guild.info == "0"))
        {
            GuildMatchController.Instance.ReqGuildCompetition();
        }
        else
        {
            view.visible = false;
        }
        EventManager.Instance.AddEventListener(GuildMatchEvent.GuildCompetition, IsShowMatchBtn);
        EventManager.Instance.AddEventListener(GuildEvent.GuildFound, UpdateData);
        EventManager.Instance.AddEventListener(GuildEvent.GuildApply, UpdateData);
        EventManager.Instance.AddEventListener(GuildEvent.GuildQuit, UpdateData);
        EventManager.Instance.AddEventListener(GuildEvent.GuildQuit, UpdateData);
        EventManager.Instance.AddEventListener(GuildEvent.LeaveGuild, UpdateData);
    }

    public void UpdateData()
    {
        var guild = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_GUILD_ID);
        if (GlobalModel.Instance.GetUnlocked(SysId.Guild) && !(guild == null || guild.info == "" || guild.info == "0"))
        {
            GuildMatchController.Instance.ReqGuildCompetition();
        }
        else
        {
            view.visible = false;
        }
    }
    public void IsShowMatchBtn()
    {
        view.visible = GuildMatchModel.Instance.GetIsOpenMatchTask();
        if (timer != null)
        {
            timer.Clear();
            timer = null;
        }
        if (ServerTime.Time > GuildMatchModel.Instance.startTime && ServerTime.Time <= GuildMatchModel.Instance.endTime)
        {
            var endTime = GuildMatchModel.Instance.endTime - ServerTime.Time;
            timer = new CountDownTimer(view.timeLab, (int)endTime);
            timer.CompleteCallBacker = UpdateData;
        }
        else
        {
            var endTime = ServerTime.Time - GuildMatchModel.Instance.startTime;
            timer = new CountDownTimer(view.timeLab, (int)endTime);
            timer.CompleteCallBacker = IsShowMatchBtn;
        }
    }
}

public class DrawBtn
{
    private fun_MainUI.funLeftBtn view;
    private CountDownTimer timer;
    private int index;
    public DrawBtn(fun_MainUI.funLeftBtn ui)
    {
        view = ui;
        UpdateData();
        view.onClick.Add(() =>
        {
            UIManager.Instance.OpenPanel<DrawMainView>(UIName.DrawMainView, UILayer.UI, index);
        });
        EventManager.Instance.AddEventListener(SystemEvent.UpdateLevel, UpdateData);
        EventManager.Instance.AddEventListener(TaskEvent.MainTaskReward, UpdateData);
    }

    private void UpdateData()
    {
        if (timer != null)
        {
            timer.Clear();
            timer = null;
        }
        DrawModel.Instance.isMonth_DrawActive = false;
        if (GlobalModel.Instance.GetUnlocked(SysId.MonthDraw))
        {
            index = -1;
            if (DrawModel.Instance.IsActivityOpen(ActivityType.Month_Draw))
            {
                index = 0;
                DrawModel.Instance.isMonth_DrawActive = true;
            }
            else if (DrawModel.Instance.IsActivityOpen(ActivityType.Diamond_Draw))
            {
                index = 1;
            }
            else if (DrawModel.Instance.IsActivityOpen(ActivityType.Dress_Draw))
            {
                index = 2;
            }
            view.visible = index != -1;
            if (index == 0)
            {
                view.status.selectedIndex = 1;
                var activityId = DrawModel.Instance.GetActivityId(ActivityType.Month_Draw);
                var activityInfo = DrawModel.Instance.GetGameEventInfo(activityId);
                var endTime = TimeUtil.GetNumericTime(activityInfo.WeixinEndTime) - ServerTime.Time;
                timer = new CountDownTimer(view.timeLab, (int)endTime);
                timer.CompleteCallBacker = UpdateData;
                EventManager.Instance.DispatchEvent(ActivityEvent.MonthDrawWhetherDisplay, true);
            }
            else
            {
                view.status.selectedIndex = 0;
            }
        }
        else
        {
            view.visible = false;
            EventManager.Instance.DispatchEvent(ActivityEvent.MonthDrawWhetherDisplay, false);
        }

    }

}

public class GiftPackBtn
{
    private fun_MainUI.funLeftBtn view;
    private CountDownTimer timer;
    private uint id;

    public GiftPackBtn(fun_MainUI.funLeftBtn ui)
    {
        view = ui;
        view.status.selectedIndex = 1;
        EventManager.Instance.AddEventListener(RechargeEvent.GiftPackInfo, UpdateData);
        view.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<PopGiftWindow>(UIName.PopGiftWindow, id);
        });
        UpdateData();
    }

    private void UpdateData()
    {
        if (PopGiftModel.Instance.giftPackList.Count > 0)
        {
            view.visible = true;
            if (timer != null)
            {
                timer.Clear();
                timer = null;
            }
            var giftPackData = PopGiftModel.Instance.GetMinEndTime();
            id = giftPackData.id;
            int endTime = (int)giftPackData.endTime - (int)ServerTime.Time;
            timer = new CountDownTimer(view.timeLab, endTime);
            timer.CompleteCallBacker = () =>
            {
                RechargeController.Instance.ReqGiftPackInfo();
            };
        }
        else
        {
            view.visible = false;
        }
    }
}

public class WelfareBtn
{
    private fun_MainUI.funRightBtn view;
    public WelfareBtn(fun_MainUI.funRightBtn ui)
    {
        view = ui;
        UpdateData();
        EventManager.Instance.AddEventListener(SystemEvent.UpdateLevel, UpdateData);
        EventManager.Instance.AddEventListener(TaskEvent.MainTaskReward, UpdateData);
    }
    private void UpdateData()
    {
        view.visible = false;
        for (var i = 0; i < 5; i++)
        {
            if (i == 0 && (!GlobalModel.Instance.GetUnlocked(SysId.SeventhSign) || WelfareModel.Instance.status == 2))
            {
                continue;
            }
            if (i == 1 && !GlobalModel.Instance.GetUnlocked(SysId.ChamberOfCommerce))
            {
                continue;
            }
            if (i == 2 && !GlobalModel.Instance.GetUnlocked(SysId.TurnTable))
            {
                continue;
            }
            if (i == 3 && !GlobalModel.Instance.GetUnlocked(SysId.VideoDouble))
            {
                continue;
            }
            if (i == 4 && (!GlobalModel.Instance.GetUnlocked(SysId.Newspaper) || WelfareModel.Instance.IsGrowthGetted()))
            {
                continue;
            }
            view.visible = true;
            break;
        }
    }
}

