using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ADK;
using protobuf.common;
using protobuf.guild;
using protobuf.messagecode;
using UnityEngine;
using static protobuf.guild.S_MSG_GUILD_KAN_DETAIL;

public class GuildController : BaseController<GuildController>
{
    public uint countdownTime = 100;//社团数量

    public int addMony = 0;
    protected override void InitListeners()
    {
        //社团列表
        AddNetListener<S_MSG_GUILD_LIST>((int)MessageCode.S_MSG_GUILD_LIST, GuildList);
        //id查找社团
        AddNetListener<S_MSG_GUILD_FIND>((int)MessageCode.S_MSG_GUILD_FIND, GuildFind);
        //创建社团
        AddNetListener<S_MSG_GUILD_FOUND>((int)MessageCode.S_MSG_GUILD_FOUND, GuildFound);
        // 申请加入社团
        AddNetListener<S_MSG_GUILD_APPLY>((int)MessageCode.S_MSG_GUILD_APPLY, GuildApply);
        //社团信息
        AddNetListener<S_MSG_GUILD_INFO>((int)MessageCode.S_MSG_GUILD_INFO, GuildInfo);
        //修改社团公告 slogan
        AddNetListener<S_MSG_GUILD_CHANGE_NOTICE>((int)MessageCode.S_MSG_GUILD_CHANGE_NOTICE, GuildChangeTxt);
        //// 升级社团
        AddNetListener<S_MSG_GUILD_UPGRADE>((int)MessageCode.S_MSG_GUILD_UPGRADE, GuildUpgrade);
        //修改社团审批方式
        AddNetListener<S_MSG_GUILD_EDIT_APPLY_CONDITION>((int)MessageCode.S_MSG_GUILD_EDIT_APPLY_CONDITION, GuildEditApproval);
        // 退出社团
        AddNetListener<S_MSG_GUILD_QUIT>((int)MessageCode.S_MSG_GUILD_QUIT, GuildQuit);
        //解散社团
        AddNetListener<S_MSG_GUILD_DISSOLVE>((int)MessageCode.S_MSG_GUILD_DISSOLVE, GuildDissolve);
        //成员列表
        AddNetListener<S_MSG_GUILD_MEMBERLIST>((int)MessageCode.S_MSG_GUILD_MEMBERLIST, GuildMemberList);
        // 踢出社团
        AddNetListener<S_MSG_GUILD_KICK>((int)MessageCode.S_MSG_GUILD_KICK, GuildKick);
        // 降职/升职
        AddNetListener<S_MSG_GUILD_MODIFY_POWER>((int)MessageCode.S_MSG_GUILD_MODIFY_POWER, GuildPromotion);
        // 申请加入社团列表
        AddNetListener<S_MSG_GUILD_APPLY_LIST>((int)MessageCode.S_MSG_GUILD_APPLY_LIST, GuildApplyList);
        // 处理申请
        AddNetListener<S_MSG_GUILD_DEAL_APPLY>((int)MessageCode.S_MSG_GUILD_DEAL_APPLY, GuildDealApply);
        // 社团捐献
        AddNetListener<S_MSG_GUILD_DONATE>((int)MessageCode.S_MSG_GUILD_DONATE, GuildDonate);
       
        // 社团资金使用明细
        AddNetListener<S_MSG_GUILD_MONEY>((int)MessageCode.S_MSG_GUILD_MONEY, GuildMoney);
        // 社团捐献进度奖励
        AddNetListener<S_MSG_GUILD_DONATE_PROGRESS>((int)MessageCode.S_MSG_GUILD_DONATE_PROGRESS, GuildDonateProgress);

        // 砍价信息
        AddNetListener<S_MSG_GUILD_KAN_INFO>((int)MessageCode.S_MSG_GUILD_KAN_INFO, GuildKanInfo);
        // 砍价
        AddNetListener<S_MSG_GUILD_KAN>((int)MessageCode.S_MSG_GUILD_KAN, GuildKan);

        // 砍价用户列表
        AddNetListener<S_MSG_GUILD_KAN_DETAIL>((int)MessageCode.S_MSG_GUILD_KAN_DETAIL, GuildKanDetail);

        // 社团未砍价用户列表
        AddNetListener<S_MSG_GUILD_KAN_NOT>((int)MessageCode.S_MSG_GUILD_KAN_NOT, GuildKanNot);

        // 砍价购买
        AddNetListener<S_MSG_GUILD_KAN_BUY>((int)MessageCode.S_MSG_GUILD_KAN_BUY, GuildKanBuy);

        // 社团商店
        AddNetListener<S_MSG_GUILD_SHOP_INFO>((int)MessageCode.S_MSG_GUILD_SHOP_INFO, GuildShopInfo);
        //社团商店购买
        AddNetListener<S_MSG_GUILD_SHOP_BUY>((int)MessageCode.S_MSG_GUILD_SHOP_BUY, GuildShopBuy);
        //我已经申请加入的社团id
        AddNetListener<S_MSG_APPLY_GUILD_LIST>((int)MessageCode.S_MSG_APPLY_GUILD_LIST, ApplyGuildList);
    }

    public void GuildList(S_MSG_GUILD_LIST data)
    {
        GuildModel.Instance.ParseGuildList(data);
        EventManager.Instance.DispatchEvent(GuildEvent.GuildList);
    }

    public void ReqGuildList(int page)
    {
        C_MSG_GUILD_LIST c_MSG_GUILD_LIST = new C_MSG_GUILD_LIST();
        c_MSG_GUILD_LIST.page = page;
        SendCmd((int)MessageCode.C_MSG_GUILD_LIST, c_MSG_GUILD_LIST,0);
    }

    public void GuildFind(S_MSG_GUILD_FIND data)
    {
        if (data.list.Count == 0)
        {
            UILogicUtils.ShowNotice(Lang.GetValue("guild.join_notFound"));//未找到社区
            return;
        }
        UIManager.Instance.OpenWindow<GuildSearchResultWindow>(UIName.GuildSearchResultWindow, data.list[0]);
    }

    public void ReqGuildFind(uint guildId)
    {
        C_MSG_GUILD_FIND c_MSG_GUILD_FIND = new C_MSG_GUILD_FIND();
        c_MSG_GUILD_FIND.guildId = guildId;
        SendCmd((int)MessageCode.C_MSG_GUILD_FIND, c_MSG_GUILD_FIND);
    }

    public void GuildFound(S_MSG_GUILD_FOUND data)
    {
        MyselfModel.Instance.UpdateUserInfo(UserInfoType.INFO_TYPE_GUILD_ID, data.guild.guildId.ToString());
        EventManager.Instance.DispatchEvent(GuildEvent.GuildFound);
        UIManager.Instance.OpenPanel<GuildMainView>(UIName.GuildMainView);
        EventManager.Instance.DispatchEvent(TaskEvent.MainTaskCount, 33);
        //EventManager.Instance.DispatchEvent(ChatEvent.GuildChatHistory);
        ChatController.Instance.ReqGuildChatHistory();
    }

    public void ReqGuildFound(string guildName,string flagId)
    {
        C_MSG_GUILD_FOUND c_MSG_GUILD_FOUND = new C_MSG_GUILD_FOUND();
        c_MSG_GUILD_FOUND.guildName = guildName;
        c_MSG_GUILD_FOUND.flagId = flagId;
        SendCmd((int)MessageCode.C_MSG_GUILD_FOUND, c_MSG_GUILD_FOUND);
    }

    public void GuildApply(S_MSG_GUILD_APPLY data)
    {
        GuildModel.Instance.guildIds.Add(data.guildId);
        if (data.join)
        {
            if (data.guildId != 0)
            {
                MyselfModel.Instance.UpdateUserInfo(UserInfoType.INFO_TYPE_GUILD_ID, data.guildId.ToString());
                UIManager.Instance.OpenPanel<GuildMainView>(UIName.GuildMainView);
                EventManager.Instance.DispatchEvent(TaskEvent.MainTaskCount, 33);
            }
            ChatController.Instance.ReqGuildChatHistory();
        }
        EventManager.Instance.DispatchEvent(GuildEvent.GuildApply, data.join);
        //EventManager.Instance.DispatchEvent(ChatEvent.GuildChatHistory);

    }

    public void ReqGuildApply(int guildId)
    {
        C_MSG_GUILD_APPLY c_MSG_GUILD_APPLY = new C_MSG_GUILD_APPLY();
        c_MSG_GUILD_APPLY.guildId = guildId;
        SendCmd((int)MessageCode.C_MSG_GUILD_APPLY, c_MSG_GUILD_APPLY);
    }

    public void GuildInfo(S_MSG_GUILD_INFO data)
    {
        var guild = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_GUILD_ID);
        if (guild == null || guild.info == "" || guild.info == "0")
        {
            MyselfModel.Instance.UpdateUserInfo(UserInfoType.INFO_TYPE_GUILD_ID, data.guild.guildId.ToString());
        }
        GuildModel.Instance.guildName = data.guild.guildName;
        GuildModel.Instance.guild = data.guild;
        GuildModel.Instance.presidentInfo = data.presidentInfo;
        GuildModel.Instance.guildMember = data.me;
        GuildModel.Instance.guildDonate = data.guildDonate;

        if(data.haveDrawDonateIds == null)
        {
            GuildModel.Instance.haveDrawDonateIds = new List<uint>();
        }
        else
        {
            GuildModel.Instance.haveDrawDonateIds = data.haveDrawDonateIds.ToList();
        }
        EventManager.Instance.DispatchEvent(GuildEvent.GuildInfo);
    }

    public void ReqGuildInfo()
    {
        C_MSG_GUILD_INFO C_MSG_GUILD_INFO = new C_MSG_GUILD_INFO();
        SendCmd((int)MessageCode.C_MSG_GUILD_INFO, C_MSG_GUILD_INFO);
    }

    public void GuildChangeTxt(S_MSG_GUILD_CHANGE_NOTICE data)
    {
        GuildModel.Instance.guild.notice = data.notice;
        EventManager.Instance.DispatchEvent(GuildEvent.GuildChangeTxt);
    }

    public void ReqGuildChangeTxt(string text)
    {
        C_MSG_GUILD_CHANGE_NOTICE c_MSG_GUILD_CHANGE_NOTICE = new C_MSG_GUILD_CHANGE_NOTICE();
        c_MSG_GUILD_CHANGE_NOTICE.notice = text;
        SendCmd((int)MessageCode.C_MSG_GUILD_CHANGE_NOTICE, c_MSG_GUILD_CHANGE_NOTICE);
    }

    public void GuildUpgrade(S_MSG_GUILD_UPGRADE data)
    {
        GuildModel.Instance.guild.level = data.level;
        GuildModel.Instance.guild.gold = data.money;
        EventManager.Instance.DispatchEvent(GuildEvent.GuildUpgrade);
    }

    public void ReqGuildUpgrade()
    {
        C_MSG_GUILD_UPGRADE c_MSG_GUILD_UPGRADE = new C_MSG_GUILD_UPGRADE();
        SendCmd((int)MessageCode.C_MSG_GUILD_UPGRADE, c_MSG_GUILD_UPGRADE);
    }

    public void GuildEditApproval(S_MSG_GUILD_EDIT_APPLY_CONDITION data)
    {
        GuildModel.Instance.guild.reviewType = data.reviewType;
        GuildModel.Instance.guild.memberLimitLevel = data.memberLimitLevel;
        GuildModel.Instance.guild.memberLimitFighting = (uint)data.memberLimitFighting;
        EventManager.Instance.DispatchEvent(GuildEvent.GuildEditApproval);
    }

    public void ReqGuildEditApproval(uint approvalType,uint memberLimitLevel,uint memberLimitFighting)
    {
        C_MSG_GUILD_EDIT_APPLY_CONDITION c_MSG_GUILD_EDIT_APPLY_CONDITION = new C_MSG_GUILD_EDIT_APPLY_CONDITION();
        c_MSG_GUILD_EDIT_APPLY_CONDITION.reviewType = approvalType;
        c_MSG_GUILD_EDIT_APPLY_CONDITION.memberLimitLevel = memberLimitLevel;
        c_MSG_GUILD_EDIT_APPLY_CONDITION.memberLimitFighting = memberLimitFighting;
        SendCmd((int)MessageCode.C_MSG_GUILD_EDIT_APPLY_CONDITION, c_MSG_GUILD_EDIT_APPLY_CONDITION);
    }

    public void GuildQuit(S_MSG_GUILD_QUIT data)
    {
        MyselfModel.Instance.UpdateUserInfo(UserInfoType.INFO_TYPE_GUILD_ID, "");
        EventManager.Instance.DispatchEvent(GuildEvent.GuildQuit);
        EventManager.Instance.DispatchEvent(ChatEvent.GuildChatHistory);
    }

    public void ReqGuildQuit()
    {
        C_MSG_GUILD_QUIT c_MSG_GUILD_QUIT = new C_MSG_GUILD_QUIT();
        SendCmd((int)MessageCode.C_MSG_GUILD_QUIT, c_MSG_GUILD_QUIT);
    }

    public void GuildDissolve(S_MSG_GUILD_DISSOLVE data)
    {
        MyselfModel.Instance.UpdateUserInfo(UserInfoType.INFO_TYPE_GUILD_ID, "");
        EventManager.Instance.DispatchEvent(GuildEvent.GuildQuit);
        EventManager.Instance.DispatchEvent(ChatEvent.GuildChatHistory);
    }

    public void ReqGuildDissolve()
    {
        C_MSG_GUILD_DISSOLVE c_MSG_GUILD_DISSOLVE = new C_MSG_GUILD_DISSOLVE();
        SendCmd((int)MessageCode.C_MSG_GUILD_DISSOLVE, c_MSG_GUILD_DISSOLVE);
    }

    public void GuildMemberList(S_MSG_GUILD_MEMBERLIST data)
    {
        GuildModel.Instance.ParseMemberList(data);
        EventManager.Instance.DispatchEvent(GuildEvent.GuildMemberList);
    }

    public void ReqGuildMemberList(int page)
    {
        C_MSG_GUILD_MEMBERLIST c_MSG_GUILD_MEMBERLIST = new C_MSG_GUILD_MEMBERLIST();
        c_MSG_GUILD_MEMBERLIST.page = page;
        SendCmd((int)MessageCode.C_MSG_GUILD_MEMBERLIST, c_MSG_GUILD_MEMBERLIST,0);
    }

    public void GuildKick(S_MSG_GUILD_KICK data)
    {
        GuildModel.Instance.RemoveMemberList(data.targetUserId);
        ReqGuildInfo();
        EventManager.Instance.DispatchEvent(GuildEvent.GuildKick);
    }

    public void ReqGuildKick(uint targetUserId)
    {
        C_MSG_GUILD_KICK c_MSG_GUILD_KICK = new C_MSG_GUILD_KICK();
        c_MSG_GUILD_KICK.targetUserId = targetUserId;
        SendCmd((int)MessageCode.C_MSG_GUILD_KICK, c_MSG_GUILD_KICK);
    }

    public void GuildPromotion(S_MSG_GUILD_MODIFY_POWER data)
    {
        GuildModel.Instance.ChangePosition(data.targetUserId, data.powerId);
        //转让会长特殊处理
        if(data.powerId == 1)
        {
            GuildModel.Instance.ChangePosition(MyselfModel.Instance.userId, 4);
        }
        EventManager.Instance.DispatchEvent(GuildEvent.GuildPromotion);
    }

    public void ReqGuildPromotion(uint targetUserId, uint position)
    {
        C_MSG_GUILD_MODIFY_POWER c_MSG_GUILD_MODIFY_POWER = new C_MSG_GUILD_MODIFY_POWER();
        c_MSG_GUILD_MODIFY_POWER.targetUserId = targetUserId;
        c_MSG_GUILD_MODIFY_POWER.powerId = position;
        SendCmd((int)MessageCode.C_MSG_GUILD_MODIFY_POWER, c_MSG_GUILD_MODIFY_POWER);
    }

    public void GuildApplyList(S_MSG_GUILD_APPLY_LIST data)
    {
        GuildModel.Instance.ParseApplyList(data);
        EventManager.Instance.DispatchEvent(GuildEvent.GuildApplyList);
    }

    public void ReqGuildApplyList(int page)
    {
        C_MSG_GUILD_APPLY_LIST c_MSG_GUILD_APPLY_LIST = new C_MSG_GUILD_APPLY_LIST();
        c_MSG_GUILD_APPLY_LIST.page = page;
        SendCmd((int)MessageCode.C_MSG_GUILD_APPLY_LIST, c_MSG_GUILD_APPLY_LIST,0);
    }

    public void GuildDealApply(S_MSG_GUILD_DEAL_APPLY data)
    {
        if(data.targetUserId == 0)
        {
            GuildModel.Instance.applyList.Clear();
        }
        else
        {
            if(data.dealType == 1)
            {
                GuildModel.Instance.guild.memberCnt++;
                EventManager.Instance.DispatchEvent(GuildEvent.GuildInfo);
            }
            GuildModel.Instance.UpdateApplyList(data.targetUserId);
        }
        
        EventManager.Instance.DispatchEvent(GuildEvent.GuildApplyList);
    }

    public void ReqGuildDealApply(int targetUserId,uint behavior)
    {
        C_MSG_GUILD_DEAL_APPLY c_MSG_GUILD_DEAL_APPLY = new C_MSG_GUILD_DEAL_APPLY();
        c_MSG_GUILD_DEAL_APPLY.targetUserId = targetUserId;
        c_MSG_GUILD_DEAL_APPLY.dealType = behavior;
        SendCmd((int)MessageCode.C_MSG_GUILD_DEAL_APPLY, c_MSG_GUILD_DEAL_APPLY);
    }

    public void GuildDonate(S_MSG_GUILD_DONATE data)
    {
        var dnoteData = GuildModel.Instance.GetDonasiData((int)data.donateId);

        var dropList = new List<StorageItemVO>();
        foreach (var item in dnoteData.Dapatkans)
        {
            var itemDefId = IDUtil.GetEntityValue(item.EntityID);
            
            var drop = new StorageItemVO();
            drop.itemDefId = itemDefId;
            drop.count = item.Value;
            dropList.Add(drop);
        }

        DropManager.ShowDrop(dropList);
        DropManager.ShowDropItem2(ImageDataModel.Instance.GuildMoneyIconUrl(), dnoteData.Peraga);

        GuildModel.Instance.guildMember.donateCnt = data.cnt;
        GuildModel.Instance.guildDonate = data.guildDonate;
        ReqGuildInfo();
        EventManager.Instance.DispatchEvent(GuildEvent.GuildDonate);
    }

    public void ReqGuildDonate(uint id)
    {
        C_MSG_GUILD_DONATE c_MSG_GUILD_DONATE = new C_MSG_GUILD_DONATE();
        c_MSG_GUILD_DONATE.donateId = id;
        SendCmd((int)MessageCode.C_MSG_GUILD_DONATE, c_MSG_GUILD_DONATE);
    }


    public void GuildMoney(S_MSG_GUILD_MONEY data)
    {
        GuildModel.Instance.messageList = data.messageList;
        GuildModel.Instance.userInfos = data.userInfos;
        EventManager.Instance.DispatchEvent(GuildEvent.GuildMoney);
    }

    public void ReqGuildMoney()
    {
        C_MSG_GUILD_MONEY c_MSG_GUILD_MONEY = new C_MSG_GUILD_MONEY();
        SendCmd((int)MessageCode.C_MSG_GUILD_MONEY, c_MSG_GUILD_MONEY);
    }

    public void GuildDonateProgress(S_MSG_GUILD_DONATE_PROGRESS data)
    {
        var proData = GuildModel.Instance.GetJrewardInfo((int)data.id);
        GuildModel.Instance.haveDrawDonateIds.Add(data.id);
        var dropList = new List<StorageItemVO>();
        foreach (var item in proData.Rewards)
        {
            var itemDefId = IDUtil.GetEntityValue(item.EntityID);

            var drop = new StorageItemVO();
            drop.itemDefId = itemDefId;
            drop.count = item.Value;
            dropList.Add(drop);
        }
        DropManager.ShowDrop(dropList);
        EventManager.Instance.DispatchEvent(GuildEvent.GuildDonateProgress);
    }

    public void ReqGuildDonateProgress(uint id)
    {
        C_MSG_GUILD_DONATE_PROGRESS c_MSG_GUILD_DONATE_PROGRESS = new C_MSG_GUILD_DONATE_PROGRESS();
        c_MSG_GUILD_DONATE_PROGRESS.id = id;
        SendCmd((int)MessageCode.C_MSG_GUILD_DONATE_PROGRESS, c_MSG_GUILD_DONATE_PROGRESS);
    }
    //砍价
    public void GuildKan(S_MSG_GUILD_KAN data)
    {
        GuildModel.Instance.kanInfo.kanPrice = data.kanPrice;
        GuildModel.Instance.kanInfo.haveKan = true;
        GuildModel.Instance.kanInfo.kanCnt += 1;
        var myKanInfo = new I_KAN_VO();
        var myInfo = new I_USER_PROFILE();
        var name = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_NICKNAME);
        myInfo.townName = name != null ? name.info : "";
        myKanInfo.userInfo = myInfo;
        myKanInfo.kanPrice = data.mePrice;
        GuildModel.Instance.kanList.Insert(0, myKanInfo);
        EventManager.Instance.DispatchEvent(GuildEvent.GuildKan);
    }

    public void ReqGuildKan()
    {
        C_MSG_GUILD_KAN c_MSG_GUILD_KAN = new C_MSG_GUILD_KAN();
        SendCmd((int)MessageCode.C_MSG_GUILD_KAN, c_MSG_GUILD_KAN);
    }

    //砍价用户列表
    public void GuildKanDetail(S_MSG_GUILD_KAN_DETAIL data)
    {
        GuildModel.Instance.ParseKanList(data);
        EventManager.Instance.DispatchEvent(GuildEvent.GuildKanDetail);
    }

    public void ReqGuildKanDetail(int page)
    {
        C_MSG_GUILD_KAN_DETAIL c_MSG_GUILD_KAN_DETAIL = new C_MSG_GUILD_KAN_DETAIL();
        c_MSG_GUILD_KAN_DETAIL.page = page;
        SendCmd((int)MessageCode.C_MSG_GUILD_KAN_DETAIL, c_MSG_GUILD_KAN_DETAIL);
    }
    //社团未砍价用户列表
    public void GuildKanNot(S_MSG_GUILD_KAN_NOT data)
    {
        GuildModel.Instance.ParseNotKanList(data);
        EventManager.Instance.DispatchEvent(GuildEvent.GuildKanNot);
    }


    public void ReqGuildKanNot(int page)
    {
        C_MSG_GUILD_KAN_NOT c_MSG_GUILD_KAN_NOT = new C_MSG_GUILD_KAN_NOT();
        c_MSG_GUILD_KAN_NOT.page = page;
        SendCmd((int)MessageCode.C_MSG_GUILD_KAN_NOT, c_MSG_GUILD_KAN_NOT);
    }
    //砍价信息
    public void GuildKanInfo(S_MSG_GUILD_KAN_INFO data)
    {
        GuildModel.Instance.kanInfo = data;
        EventManager.Instance.DispatchEvent(GuildEvent.GuildKanInfo);
    }

    public void ReqGuildKanInfo()
    {
        C_MSG_GUILD_KAN_INFO c_MSG_GUILD_KAN_INFO = new C_MSG_GUILD_KAN_INFO();
        SendCmd((int)MessageCode.C_MSG_GUILD_KAN_INFO, c_MSG_GUILD_KAN_INFO);
    }
    //砍价购买
    public void GuildKanBuy(S_MSG_GUILD_KAN_BUY data)
    {
        var dropList = ItemModel.Instance.GetDropData(data.items);
        DropManager.ShowDrop(dropList);
        GuildModel.Instance.kanInfo.haveBuy = true;
        EventManager.Instance.DispatchEvent(GuildEvent.GuildKanBuy);
    }

    public void ReqGuildKanBuy()
    {
        C_MSG_GUILD_KAN_BUY c_MSG_GUILD_KAN_BUY = new C_MSG_GUILD_KAN_BUY();
        SendCmd((int)MessageCode.C_MSG_GUILD_KAN_BUY, c_MSG_GUILD_KAN_BUY);
    }
    //社团商店
    public void GuildShopInfo(S_MSG_GUILD_SHOP_INFO data)
    {
        if(data.buyCntStat == null)
        {
            GuildModel.Instance.buyCntStat = new Dictionary<uint, uint>();
        }
        else
        {
            GuildModel.Instance.buyCntStat = data.buyCntStat;
        }
        EventManager.Instance.DispatchEvent(GuildEvent.GuildShopInfo);

    }

    public void ReqGuildShopInfo()
    {
        C_MSG_GUILD_SHOP_INFO c_MSG_GUILD_SHOP_INFO = new C_MSG_GUILD_SHOP_INFO();
        SendCmd((int)MessageCode.C_MSG_GUILD_SHOP_INFO, c_MSG_GUILD_SHOP_INFO);
    }
    //社团商店购买
    public void GuildShopBuy(S_MSG_GUILD_SHOP_BUY data)
    {
        GuildModel.Instance.UpdateShop(data.id, data.buyCnt);
        var dropList = ItemModel.Instance.GetDropData(data.items);
        DropManager.ShowDrop(dropList);
        EventManager.Instance.DispatchEvent(GuildEvent.GuildShopBuy);
    }

    public void ReqGuildShopBuy(uint id)
    {
        C_MSG_GUILD_SHOP_BUY c_MSG_GUILD_SHOP_BUY = new C_MSG_GUILD_SHOP_BUY();
        c_MSG_GUILD_SHOP_BUY.id = id;
        SendCmd((int)MessageCode.C_MSG_GUILD_SHOP_BUY, c_MSG_GUILD_SHOP_BUY);
    }
    //我已经申请加入的社团id
    public void ApplyGuildList(S_MSG_APPLY_GUILD_LIST data)
    {
        if(data.guildIds == null)
        {
            GuildModel.Instance.guildIds = new List<uint>();
        }
        else
        {
            GuildModel.Instance.guildIds = data.guildIds.ToList();
        }

        GuildModel.Instance.cdTime = data.cdTime;
        GuildController.Instance.ReqGuildList(0);
        EventManager.Instance.DispatchEvent(GuildEvent.ApplyGuildList);
    }

    public void ReqApplyGuildList()
    {
        C_MSG_APPLY_GUILD_LIST c_MSG_APPLY_GUILD_LIST = new C_MSG_APPLY_GUILD_LIST();
        SendCmd((int)MessageCode.C_MSG_APPLY_GUILD_LIST, c_MSG_APPLY_GUILD_LIST);
    }
}
