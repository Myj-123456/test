using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using ADK;
using System;

public class RedPointManger : Singleton<RedPointManger>
{
    private fun_MainUI.baihualuBtn baihualuBtn;//百花录红点
    private fun_MainUI.mian_btn2 plotBtn;//剧情红点
    private fun_MainUI.moreBtn moreBtn;//更多红点
    private fun_MainUI.mian_btn2 storageBtn;//仓库红点
    private fun_MainUI.mian_btn2 dailyBtn;//日常任务红点
    private fun_MainUI.mian_btn2 achievBtn;//成就任务红点
    private fun_MainUI.funLeftBtn firstBtn;//首充红点
    private common_New.common_btn1 mailBtn;//邮件红点
    private fun_MainUI.mian_btn4 friendBtn;//好友红点
    private fun_MainUI.mian_btn4 guildBtn;//花盟红点
    private fun_MainUI.mian_btn4 btn_shop;//商铺红点
    private common_New.PictureFrame frameBtn;//头像红点
    private fun_MainUI.funLeftBtn vipBtn;//vip合集红点
    private fun_MainUI.funRightBtn welfareBtn;//福利合集红点
    public void Init(fun_MainUI.fun_MainView ui)
    {
        baihualuBtn = ui.bottomBtns.btn_baihualu;
        plotBtn = ui.bottomBtns.ui_moreFun.btn_book;
        moreBtn = ui.bottomBtns.btn_moreFun;
        storageBtn = ui.bottomBtns.ui_moreFun.btn_storage;
        dailyBtn = ui.bottomBtns.ui_moreFun.btn_dailyTask;
        achievBtn = ui.bottomBtns.ui_moreFun.btn_achieve;
        mailBtn = ui.bottomBtns.ui_moreFun.btn_mail as common_New.common_btn1;
        friendBtn = ui.bottomBtns.btn_friend;
        guildBtn = ui.bottomBtns.btn_guild;
        btn_shop = ui.bottomBtns.btn_shop;

        firstBtn = ui.leftBtns.btn.scroll.btn_first_recharge;
        vipBtn = ui.leftBtns.btn.scroll.btn_vip;

        frameBtn = ui.topBtns.frame as common_New.PictureFrame;

        welfareBtn = ui.rightBtns.btn_com.scroll.btn_welfare;

        UpdateData();
        EventManager.Instance.AddEventListener(RedPointEvent.UpdateItem, UpdateItemData);
        EventManager.Instance.AddEventListener(IkebanaEvent.IkebanaMake, UpdatebaihualuRed);
        EventManager.Instance.AddEventListener(IkebanaEvent.IkebanaReward, UpdatebaihualuRed);

        EventManager.Instance.AddEventListener(SystemEvent.UpdateLevel, UpdateUnlock);
        EventManager.Instance.AddEventListener(TaskEvent.MainTaskReward, UpdateUnlock);

        EventManager.Instance.AddEventListener(MailEvent.MailReward, UpdateMailBtn);
        EventManager.Instance.AddEventListener(RedPointEvent.GameMild, UpdateMailBtn);

        EventManager.Instance.AddEventListener<uint>(RedPointEvent.RedDotChange, UpdateRedPoint);

        EventManager.Instance.AddEventListener(RedPointEvent.UpdateTodayFirstLogin, UpdateFirstLogin);

        EventManager.Instance.AddEventListener(PlayerEvent.GameCrossDay, UpdateGameCross);

        EventManager.Instance.AddEventListener(RedPointEvent.OnRechargeDelevier,UpdateDelevier);

        EventManager.Instance.AddEventListener(RechargeEvent.RechargeInfo, UpdateRechargeInfo);
        EventManager.Instance.AddEventListener(RechargeEvent.FristRecharge, UpdateFirstRed);

        EventManager.Instance.AddEventListener(RechargeEvent.Normal, UpdateVipRed);
        EventManager.Instance.AddEventListener(RechargeEvent.MonthCard, UpdateVipRed);
        EventManager.Instance.AddEventListener(RechargeEvent.AccRecharge, UpdateVipRed);

        EventManager.Instance.AddEventListener(WelfareEvent.DailyLoginAward, UpdateWelfareRed);
        EventManager.Instance.AddEventListener(WelfareEvent.TurnTable, UpdateWelfareRed);
        EventManager.Instance.AddEventListener(WelfareEvent.DailySign, UpdateWelfareRed);
        EventManager.Instance.AddEventListener(TaskEvent.TaskProAreward, UpdateWelfareRed);
        EventManager.Instance.AddEventListener(WelfareEvent.DailyRetroactive, UpdateWelfareRed);

        EventManager.Instance.AddEventListener(RedPointEvent.ClickItem, UpdateFrameRed);

        EventManager.Instance.AddEventListener(PlayerEvent.ChangeDailyLogin, UpdateWelfareRed);
    }
    private void UpdateData()
    {
        UpdateItemData();
        UpdateFirstRed();
        UpdateMailBtn();
        UpdateDailyRed();
        UpdateAchievRed();
        UpdateFriendRed();
        UpdateGuildRed();
        UpdateFrameRed();
        UpdateShopRed();
        UpdateVipRed();
        UpdateWelfareRed();
    }
    //道具更新
    private void UpdateItemData()
    {
        UpdatebaihualuRed();
        UpdatePlotRed();
        UpdateStorageRed();
        UpdateFrameRed();
    }
    //等级任务更新
    private void UpdateUnlock()
    {
        UpdatePlotRed();
        UpdateMailBtn();
        UpdateDailyRed();
        UpdateAchievRed();
        UpdateFriendRed();
        UpdateGuildRed();
        UpdateShopRed();
        UpdateWelfareRed();
    }
    //发货
    public void UpdateDelevier()
    {
        UpdateVipRed();
    }
    //跨天
    private void UpdateGameCross()
    {
        UpdateFirstRed();
        UpdateVipRed();
        UpdateWelfareRed();
    }
    //更新充值信息
    public void UpdateRechargeInfo()
    {
        UpdateFirstRed();
        UpdateVipRed();
    }
    //今天首次登录
    public void UpdateFirstLogin()
    {
        UpdateShopRed();
    }
    //百花录红点
    private void UpdatebaihualuRed()
    {
        baihualuBtn.red_point.visible = StorageModel.Instance.GetCanFlowerLevel() || IkeModel.Instance.CanGetVaseExp();
    }
    //剧情红点
    private void UpdatePlotRed()
    {
        if (GlobalModel.Instance.GetUnlocked(SysId.Adventure))
        {
            var plotData = MyselfModel.Instance.GetUserInfo(UserInfoType.PLOT);
            var chapter = 1;
            var plotIdx = 0;
            if (plotData != null)
            {
                var plotChapter = plotData.info.Split(",");
                chapter = int.Parse(plotChapter[0]);
                plotIdx = int.Parse(plotChapter[1]);
                var chapterInfo = PlotModel.Instance.GetPlotChapterInfo(chapter);
                var isMax = PlotModel.Instance.GetPlotChapterInfo(chapter + 1) == null && chapterInfo.Plots.Length == plotIdx + 1;
                if (!isMax)
                {
                    if (chapterInfo.Plots.Length == plotIdx + 1)
                    {
                        chapter += 1;
                        plotIdx = 0;
                    }
                    else
                    {
                        plotIdx += 1;
                    }
                    var count = StorageModel.Instance.GetItemCount(GlobalModel.Instance.module_profileConfig.poltItemId);
                    var costNum = chapterInfo.PlotCosts[plotIdx];
                    plotBtn.red_point.visible = costNum <= count;
                }
                else
                {
                    plotBtn.red_point.visible = false;
                }
            }
            else
            {
                var chapterInfo = PlotModel.Instance.GetPlotChapterInfo(chapter);
                var count = StorageModel.Instance.GetItemCount(GlobalModel.Instance.module_profileConfig.poltItemId);
                var costNum = chapterInfo.PlotCosts[plotIdx];
                plotBtn.red_point.visible = costNum <= count;
            }
        }
        else
        {
            plotBtn.red_point.visible = false;
        }
        
        
        UpdateMoreRed();
    }
    //更多红点
    private void UpdateMoreRed()
    {
        moreBtn.red_point.visible = plotBtn.red_point.visible || storageBtn.red_point.visible || mailBtn.red_point.visible
            || dailyBtn.red_point.visible || achievBtn.red_point.visible;
    }
    //仓库红点
    private void UpdateStorageRed()
    {
        storageBtn.red_point.visible = StorageModel.Instance.GetRodomGift();
        UpdateMoreRed();
    }
    //首充红点
    private void UpdateFirstRed()
    {
        firstBtn.red_point.visible = RechargeModel.Instance.GetCanFirstRecharge();
    }
    //邮件红点
    private void UpdateMailBtn()
    {
        if (GlobalModel.Instance.GetUnlocked(SysId.Mail))
        {
            mailBtn.red_point.visible = MailModel.Instance.IsGetMailRead();
        }
        else
        {
            mailBtn.red_point.visible = false;
        }
        UpdateMoreRed();
    }
    //日常任务红点
    private void UpdateDailyRed()
    {
        if (GlobalModel.Instance.GetUnlocked(SysId.DailyTask))
        {
            dailyBtn.red_point.visible = RedPointModel.Instance.IsRedPointShow(RedPointType.Task_Daily) || RedPointModel.Instance.IsRedPointShow(RedPointType.Task_Week);
        }
        else
        {
            dailyBtn.red_point.visible = false;
        }
        UpdateMoreRed();
    }
    //成就任务红点
    private void UpdateAchievRed()
    {
        if (GlobalModel.Instance.GetUnlocked(SysId.Achiev_Task))
        {
            achievBtn.red_point.visible = RedPointModel.Instance.IsRedPointShow(RedPointType.Task_Achiev);
        }
        else
        {
            achievBtn.red_point.visible = false;
        }
        UpdateMoreRed();
    }

    //好友红点
    private void UpdateFriendRed()
    {
        if (GlobalModel.Instance.GetUnlocked(SysId.Friend))
        {
            friendBtn.red_point.visible = RedPointModel.Instance.IsRedPointShow(RedPointType.Friend_Apply) || RedPointModel.Instance.IsRedPointShow(RedPointType.Friend_Crony) || RedPointModel.Instance.IsRedPointShow(RedPointType.Friend_Chat);
        }
        else
        {
            friendBtn.red_point.visible = false;
        }
    }
    //花盟红点
    private void UpdateGuildRed() {
        if (GlobalModel.Instance.GetUnlocked(SysId.Friend))
        {
            guildBtn.red_point.visible = RedPointModel.Instance.IsRedPointShow(RedPointType.Guild_Donate)||
                RedPointModel.Instance.IsRedPointShow(RedPointType.Guild_Donate_Pro) ||
                RedPointModel.Instance.IsRedPointShow(RedPointType.Guild_Apply) ||
                RedPointModel.Instance.IsRedPointShow(RedPointType.Guild_Gift) ||
                RedPointModel.Instance.IsRedPointShow(RedPointType.Guild_Big_Box) ||
                RedPointModel.Instance.IsRedPointShow(RedPointType.Guild_Plant);
        }
        else
        {
            guildBtn.red_point.visible = false;
        }
    }

    private void UpdateRedPoint(uint type)
    {
        if(type == (uint)RedPointType.Friend_Apply || type == (uint)RedPointType.Friend_Crony || type == (uint)RedPointType.Friend_Chat)
        {
            UpdateFriendRed();
        }
        else if (type == (uint)RedPointType.Task_Daily || type == (uint)RedPointType.Task_Week)
        {
            UpdateDailyRed();
        }
        else if (type == (uint)RedPointType.Task_Achiev)
        {
            UpdateAchievRed();
        }
        else if (type == (uint)RedPointType.Growth_Road)
        {
            UpdateWelfareRed();
        }
        else if (type == (uint)RedPointType.Trade)
        {

        }
        else if (type == (uint)RedPointType.Task_Contract)
        {
            UpdateVipRed();
        }
        else if (type == (uint)RedPointType.Flower_Contract)
        {

        }
        else if (type == (uint)RedPointType.Guild_Donate || type == (uint)RedPointType.Guild_Donate_Pro || type == (uint)RedPointType.Guild_Apply || type == (uint)RedPointType.Guild_Plant || type == (uint)RedPointType.Guild_Gift || type == (uint)RedPointType.Guild_Big_Box)
        {
            UpdateGuildRed();
        }
    }
    //头像红点
    private void UpdateFrameRed()
    {
        if (PlayerModel.Instance.GetHeadRedPoint() || PlayerModel.Instance.GetFrameRedPoint() || PlayerModel.Instance.GetTitleRedPoint())
        {
            UILogicUtils.ShowRedPoint(frameBtn,false, frameBtn.width - 20,10);
        }
        else
        {
            UILogicUtils.HideRedPoint(frameBtn);
        }
    }
    //商铺红点
    private void UpdateShopRed()
    {
        if (GlobalModel.Instance.GetUnlocked(SysId.VipPopup))
        {
            btn_shop.red_point.visible = RedPointModel.Instance.GetTodayFirstLogin(TodayFirstLogin.Vip_Shop);
        }
        else
        {
            btn_shop.red_point.visible = false;
        }
        
    }
    //vip合集红点
    private void UpdateVipRed()
    {
        if(RechargeModel.Instance.GetRechargeGiftRed() || MyselfModel.Instance.GetVipRed() || RechargeModel.Instance.GetCumulativeRed()||
            RedPointModel.Instance.GetTodayFirstLogin(TodayFirstLogin.Recharge) || RedPointModel.Instance.IsRedPointShow(RedPointType.Task_Contract))
        {
            vipBtn.red_point.visible = true;
        }
        else
        {
            vipBtn.red_point.visible = false;
        }
    }

    private void UpdateWelfareRed()
    {
        if(WelfareModel.Instance.GetSevenRed() || RedPointModel.Instance.IsRedPointShow(RedPointType.Growth_Road) || 
            WelfareModel.Instance.GetTurnRed() || WelfareModel.Instance.GetSignRed())
        {
            welfareBtn.red_point.visible = true;
        }
        else
        {
            welfareBtn.red_point.visible = false;
        }
    }
}
