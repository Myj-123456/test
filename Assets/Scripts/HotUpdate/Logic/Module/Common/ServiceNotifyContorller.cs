using System.Collections;
using System.Collections.Generic;
using protobuf.messagecode;
using protobuf.notify;
using UnityEngine;

public class ServiceNotifyContorller : BaseController<ServiceNotifyContorller>
{
    protected override void InitListeners()
    {
        AddNetListener<S_SYSTEM_EVENT_NOTIFY>((int)MessageCode.S_SYSTEM_EVENT_NOTIFY, SystemEventNotify);
    }

    public void SystemEventNotify(S_SYSTEM_EVENT_NOTIFY data)
    {
        NotifyEvent type = (NotifyEvent)data.eventType;
        if(type == NotifyEvent.TRADE_GRID_BUY)
        {
            var ui = UIManager.Instance.GetView(UIName.TradeWindow);
            if (ui != null && ui.Visible)
            {
                TradeController.Instance.ReqTradeInfomation();
            }
            else
            {
                EventManager.Instance.DispatchEvent(RedPointEvent.UpdateTradeMain);
            }
            var ui1 = UIManager.Instance.GetWindow(UIName.TradeMessageWindow);
            if (ui1 != null && ui1.Visible)
            {
                TradeController.Instance.ReqMessage();
            }
            else
            {
                TradeModel.Instance.tipRedPoint = true;
                EventManager.Instance.DispatchEvent(RedPointEvent.UpdateTradeTip);
            }
            
        }
        else if(type == NotifyEvent.JOIN_GUILD)
        {
            var ui = UIManager.Instance.GetWindow(UIName.GuildJoinWindow);
            if (ui != null && ui.Visible)
            {
                UIManager.Instance.CloseWindow(UIName.GuildJoinWindow);
            }

            var ui1 = UIManager.Instance.GetWindow(UIName.CreateGuildWindow);
            if (ui1 != null && ui1.Visible)
            {
                UIManager.Instance.CloseWindow(UIName.CreateGuildWindow);
            }
            GuildController.Instance.ReqGuildInfo();
            ChatController.Instance.ReqGuildChatHistory();
            EventManager.Instance.DispatchEvent(TaskEvent.MainTaskCount, 33);
        }
        else if (type == NotifyEvent.LEAVE_GUILD)
        {
            LeaveGuild();
            MyselfModel.Instance.UpdateUserInfo(UserInfoType.INFO_TYPE_GUILD_ID, "");
            EventManager.Instance.DispatchEvent(ChatEvent.GuildChatHistory); 
            EventManager.Instance.DispatchEvent(GuildEvent.LeaveGuild);
        }
        else if (type == NotifyEvent.ROB_ARREST)
        {
            var ui = UIManager.Instance.GetWindow(UIName.RobWindow);
            if (ui != null && ui.Visible)
            {
                //RobController.Instance.ReqRobInfo();
            }
        }
        else if (type == NotifyEvent.FRIEND_APPLY)
        {
            var ui = UIManager.Instance.GetWindow(UIName.FriendWindow);
            if (ui != null && ui.Visible)
            {
                FriendController.Instance.ReqFriendApplyList();
            }
        }
        else if (type == NotifyEvent.AGREE_APPLY || type == NotifyEvent.FRIEND_DEL)
        {
            var ui = UIManager.Instance.GetWindow(UIName.FriendWindow);
            FriendModel.Instance.friendCount = (uint)data.ext1;
            if (ui != null && ui.Visible)
            {
                FriendController.Instance.ReqFriendList();
            }
            EventManager.Instance.DispatchEvent(TaskEvent.MainTaskCount, 17);
        }
        else if (type == NotifyEvent.FLOWER_ORDER)
        {
            FlowerOrderController.Instance.ReqOderInfo();
        }else if(type == NotifyEvent.COMPETITION_TASK_CHANGE)
        {
            var pos = (uint)data.ext1;
            GuildMatchController.Instance.ReqGuildPosTask(pos);
        }else if(type == NotifyEvent.HUAYUN_AND_POWER)
        {
            //if(PlayerModel.Instance.pen == null)
            //{
            //    return;
            //}
            //PlayerModel.Instance.pen.floralCharm = data.ext1;
            //if(PlayerModel.Instance.pen.drawingPower != data.ext2)
            //{
            //    PlayerModel.Instance.pen.drawingPower = data.ext2;
            //    PowerNotice.Instance.PlayShow();
            //}
            
            //EventManager.Instance.DispatchEvent(SystemEvent.UpdatePower);
        }
        else if (type == NotifyEvent.Main_Task)
        {
            
            var taskData = TaskModel.Instance.mainTask;
            var taskInfo = TaskModel.Instance.GetTaskMainInfo((int)taskData.mainTaskId);
            if(taskData.mainTaskCnt < taskInfo.TaskNum && (uint)data.ext1 >= taskInfo.TaskNum)
            {
                TaskNotice.Instance.PlayShow();
            }

            TaskModel.Instance.mainTask.mainTaskCnt = (uint)data.ext1;
            EventManager.Instance.DispatchEvent(TaskEvent.MainTaskReward);
        }
        else if (type == NotifyEvent.Fighting)
        {
            if (MyselfModel.Instance.fighting != (uint)data.ext1)
            {
                MyselfModel.Instance.fighting = (uint)data.ext1;
                PowerNotice.Instance.PlayShow();
            }
            EventManager.Instance.DispatchEvent(SystemEvent.UpdateFighting);
        }
        else if (type == NotifyEvent.Dress_Charm)
        {
            MyselfModel.Instance.dressCharm = (uint)data.ext1;
            EventManager.Instance.DispatchEvent(SystemEvent.UpdateDressCharm);
        }else if(type == NotifyEvent.Gift)
        {
            MyselfModel.Instance.tipId = (uint)data.ext1;
            RechargeController.Instance.ReqGiftPackInfo();
        }else if(type == NotifyEvent.Flower_Home)
        {
            GuildPlantController.Instance.ReqGuildHouseInfo();
        }
        else if(type == NotifyEvent.Guild_Level)
        {
            GuildController.Instance.ReqGuildInfo();
        }
    }

    private void LeaveGuild()
    {
        var ui = UIManager.Instance.GetView(UIName.GuildMainView);
        if (ui != null && ui.Visible)
        {
            UIManager.Instance.ClosePanel(UIName.GuildMainView);
        }
        var ui1 = UIManager.Instance.GetView(UIName.GuildPlantView);
        if (ui1 != null && ui1.Visible)
        {
            UIManager.Instance.ClosePanel(UIName.GuildPlantView);
        }
        var ui2 = UIManager.Instance.GetWindow(UIName.BuyFlowerRackWindow);
        if (ui2 != null && ui2.Visible)
        {
            UIManager.Instance.CloseWindow(UIName.BuyFlowerRackWindow);
        }
        var ui3 = UIManager.Instance.GetView(UIName.GuildPlantingView);
        if (ui3 != null && ui3.Visible)
        {
            UIManager.Instance.ClosePanel(UIName.GuildPlantingView);
        }
        var ui4 = UIManager.Instance.GetView(UIName.GuildGiftView);
        if (ui4 != null && ui4.Visible)
        {
            UIManager.Instance.ClosePanel(UIName.GuildGiftView);
        }
        var ui5 = UIManager.Instance.GetWindow(UIName.GuildBargainWindow);
        if (ui5 != null && ui5.Visible)
        {
            UIManager.Instance.CloseWindow(UIName.GuildBargainWindow);
        }
        var ui6 = UIManager.Instance.GetWindow(UIName.GuildManageView);
        if (ui6 != null && ui6.Visible)
        {
            UIManager.Instance.CloseWindow(UIName.GuildManageView);
        }
        var ui7 = UIManager.Instance.GetWindow(UIName.GuildManageView);
        if (ui7 != null && ui7.Visible)
        {
            UIManager.Instance.CloseWindow(UIName.GuildManageView);
        }
        var ui8 = UIManager.Instance.GetWindow(UIName.GuildDonateWindow);
        if (ui8 != null && ui8.Visible)
        {
            UIManager.Instance.CloseWindow(UIName.GuildDonateWindow);
        }
        var ui9 = UIManager.Instance.GetWindow(UIName.GuildChangeNoticeWindow);
        if (ui9 != null && ui9.Visible)
        {
            UIManager.Instance.CloseWindow(UIName.GuildChangeNoticeWindow);
        }
        var ui10 = UIManager.Instance.GetView(UIName.GuildMatchView);
        if (ui10 != null && ui10.Visible)
        {
            UIManager.Instance.ClosePanel(UIName.GuildMatchView);
        }
        var ui11 = UIManager.Instance.GetWindow(UIName.MatchMyTaskWindow);
        if (ui11 != null && ui11.Visible)
        {
            UIManager.Instance.CloseWindow(UIName.MatchMyTaskWindow);
        }
        var ui12 = UIManager.Instance.GetWindow(UIName.MatchTaskInfoWindow);
        if (ui12 != null && ui12.Visible)
        {
            UIManager.Instance.CloseWindow(UIName.MatchTaskInfoWindow);
        }
        var ui13 = UIManager.Instance.GetWindow(UIName.MatchRankWindow);
        if (ui13 != null && ui13.Visible)
        {
            UIManager.Instance.CloseWindow(UIName.MatchRankWindow);
        }
        var ui14 = UIManager.Instance.GetWindow(UIName.MatchFlowerWindow);
        if (ui14 != null && ui14.Visible)
        {
            UIManager.Instance.CloseWindow(UIName.MatchFlowerWindow);
        }
    }                                              
}

public enum NotifyEvent
{
    EMPTY = 0,
    TRADE_GRID_BUY = 1, //交易购买 - 行会里有人购买我的货
    JOIN_GUILD = 2, //加入行会 - 我加入了一个行会
    LEAVE_GUILD = 3, //退出行会 - 我退出了一个行会
    ROB_ARREST = 4, //抢夺令 - 我被抢夺了
    FRIEND_APPLY = 5, //好友申请 - 我收到了一个好友申请
    AGREE_APPLY = 6, //好友同意 - 我同意了一个好友申请
    FRIEND_DEL = 7,//好友删除 - 我删除了一个好友
    FLOWER_ORDER = 8,//花束订单 - 我收到了一个花束订单
    COMPETITION_TASK_CHANGE = 9,//公会比赛任务变化 - 我收到了一个公会比赛任务变化
    HUAYUN_AND_POWER = 10,//花云和战力 - 我收到了一个花云和战力
    Main_Task = 11,//主线任务 - 我收到了一个主线任务
    Fighting = 12,//战力 - 我收到了一个战力
    Dress_Charm = 13,// Dress_Charm - 我收到了一个 Dress_Charm
    Gift = 17,//礼包更新时推送
    Flower_Home = 18,//花房家园
    Guild_Level = 19,//公会等级变化推送
}
