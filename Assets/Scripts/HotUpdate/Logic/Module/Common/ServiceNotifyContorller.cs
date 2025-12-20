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
            if (ui.Visible)
            {
                TradeController.Instance.ReqTradeInfomation();
            }
            else
            {
                EventManager.Instance.DispatchEvent(RedPointEvent.UpdateTradeMain);
            }
            var ui1 = UIManager.Instance.GetView(UIName.TradeMessageWindow);
            if (ui1.Visible)
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
            if (ui.Visible)
            {
                UIManager.Instance.CloseWindow(UIName.GuildJoinWindow);
            }

            var ui1 = UIManager.Instance.GetWindow(UIName.CreateGuildWindow);
            if (ui1.Visible)
            {
                UIManager.Instance.CloseWindow(UIName.CreateGuildWindow);
            }
            GuildController.Instance.ReqGuildInfo();
            ChatController.Instance.ReqGuildChatHistory();
            EventManager.Instance.DispatchEvent(TaskEvent.MainTaskCount, 33);
        }
        else if (type == NotifyEvent.LEAVE_GUILD)
        {
            var ui = UIManager.Instance.GetWindow(UIName.GuildMainView);
            if (ui.Visible)
            {
                UIManager.Instance.CloseWindow(UIName.GuildMainView);
            }
            
            MyselfModel.Instance.UpdateUserInfo(UserInfoType.INFO_TYPE_GUILD_ID, "");
            EventManager.Instance.DispatchEvent(ChatEvent.GuildChatHistory); 
            EventManager.Instance.DispatchEvent(GuildEvent.LeaveGuild);
        }
        else if (type == NotifyEvent.ROB_ARREST)
        {
            var ui = UIManager.Instance.GetWindow(UIName.RobWindow);
            if (ui.Visible)
            {
                //RobController.Instance.ReqRobInfo();
            }
        }
        else if (type == NotifyEvent.FRIEND_APPLY)
        {
            var ui = UIManager.Instance.GetWindow(UIName.FriendWindow);
            if (ui.Visible)
            {
                FriendController.Instance.ReqFriendApplyList();
            }
        }
        else if (type == NotifyEvent.AGREE_APPLY || type == NotifyEvent.FRIEND_DEL)
        {
            var ui = UIManager.Instance.GetWindow(UIName.FriendWindow);
            FriendModel.Instance.friendCount = (uint)data.ext1;
            if (ui.Visible)
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
