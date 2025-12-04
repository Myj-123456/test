using System.Collections;
using System.Collections.Generic;
using System.Linq;
using protobuf.common;
using protobuf.guild;
using protobuf.messagecode;
using UnityEngine;

public class GuildMatchController : BaseController<GuildMatchController>
{
    public int tatol = 0;

    protected override void InitListeners()
    {
        //社团竞赛
        AddNetListener<S_MSG_GUILD_COMPETITION_INFO>((int)MessageCode.S_MSG_GUILD_COMPETITION_INFO, GuildCompetition);
        //获取某个位置的任务
        AddNetListener<S_MSG_GUILD_COMPETITION_POS_TASK>((int)MessageCode.S_MSG_GUILD_COMPETITION_POS_TASK, GuildPosTask);
        //领取任务
        AddNetListener<S_MSG_GUILD_COMPETITION_RECEIVE>((int)MessageCode.S_MSG_GUILD_COMPETITION_RECEIVE, GuildReceive);
        //刷新任务
        AddNetListener<S_MSG_GUILD_COMPETITION_REFRESH>((int)MessageCode.S_MSG_GUILD_COMPETITION_REFRESH, GuildRefresh);
        //提交任务
        AddNetListener<S_MSG_GUILD_COMPETITION_SUBMIT>((int)MessageCode.S_MSG_GUILD_COMPETITION_SUBMIT, GuildSubmit);
        //个人积分进度奖励
        AddNetListener<S_MSG_GUILD_COMPETITION_SELF_REWARD>((int)MessageCode.S_MSG_GUILD_COMPETITION_SELF_REWARD, GuildSelfReward);
        //社团积分进度奖励
        AddNetListener<S_MSG_GUILD_COMPETITION_PROGRESS_REWARD>((int)MessageCode.S_MSG_GUILD_COMPETITION_PROGRESS_REWARD, GuildProReward);
        //花盟排行
        AddNetListener<S_MSG_GUILD_COMPETITION_GUILD_RANK>((int)MessageCode.S_MSG_GUILD_COMPETITION_GUILD_RANK, GuildMatchRank);
        //花盟成员排行
        AddNetListener<S_MSG_GUILD_COMPETITION_MEMBER_RANK>((int)MessageCode.S_MSG_GUILD_COMPETITION_MEMBER_RANK, MemberMatchRank);
        //成员列表
        AddNetListener<S_MSG_GUILD_BATCH_MEMBER_INFO>((int)MessageCode.S_MSG_GUILD_BATCH_MEMBER_INFO, MemberInfo);
    }

    //社团竞赛
    public void GuildCompetition(S_MSG_GUILD_COMPETITION_INFO data)
    {
        GuildMatchModel.Instance.join = data.join;
        GuildMatchModel.Instance.oddTaskCnt = data.oddTaskCnt; 
        GuildMatchModel.Instance.score = data.score;
        GuildMatchModel.Instance.guildScore = data.guildScore;
        GuildMatchModel.Instance.matchLv = data.matchLv;
        GuildMatchModel.Instance.rankNum = data.rankNum;
        GuildMatchModel.Instance.taskList = data.taskList;
        GuildMatchModel.Instance.memberJoinStatus = data.memberJoinStatus;
        GuildMatchModel.Instance.endTime = data.endTime;
        GuildMatchModel.Instance.startTime = data.startTime;

        GuildMatchModel.Instance.resultStat = data.resultStat;
        GuildMatchModel.Instance.preRank = data.preRank;
        GuildMatchModel.Instance.preGrade = data.preGrade;
        GuildMatchModel.Instance.taskCnt = data.taskCnt;
        if (data.selfRewardIds == null)
        {
            GuildMatchModel.Instance.selfRewardIds = new List<uint>();
        }
        else
        {
            GuildMatchModel.Instance.selfRewardIds = data.selfRewardIds.ToList();
        }

        if (data.rewardIds == null)
        {
            GuildMatchModel.Instance.rewardIds = new List<uint>();
        }
        else
        {
            GuildMatchModel.Instance.rewardIds = data.rewardIds.ToList();
        }
        if(data.specialFlowers == null)
        {
            GuildMatchModel.Instance.specialFlowers = new List<uint>();
        }
        else
        {
            GuildMatchModel.Instance.specialFlowers = data.specialFlowers.ToList();
        }

        EventManager.Instance.DispatchEvent(GuildMatchEvent.GuildCompetition);
    }

    public void ReqGuildCompetition()
    {
        C_MSG_GUILD_COMPETITION_INFO c_MSG_GUILD_COMPETITION_INFO = new C_MSG_GUILD_COMPETITION_INFO();
        SendCmd((int)MessageCode.C_MSG_GUILD_COMPETITION_INFO, c_MSG_GUILD_COMPETITION_INFO);
    }
    //获取某个位置的任务
    public void GuildPosTask(S_MSG_GUILD_COMPETITION_POS_TASK data)
    {
        GuildMatchModel.Instance.UpdateTaskInfo(data.pos, data.taskList);
        EventManager.Instance.DispatchEvent(GuildMatchEvent.GuildPosTask);
    }

    public void ReqGuildPosTask(uint pos)
    {
        C_MSG_GUILD_COMPETITION_POS_TASK c_MSG_GUILD_COMPETITION_POS_TASK = new C_MSG_GUILD_COMPETITION_POS_TASK();
        c_MSG_GUILD_COMPETITION_POS_TASK.pos = pos;
        SendCmd((int)MessageCode.C_MSG_GUILD_COMPETITION_POS_TASK, c_MSG_GUILD_COMPETITION_POS_TASK);
    }
    //领取任务
    public void GuildReceive(S_MSG_GUILD_COMPETITION_RECEIVE data)
    {
        //var myInfo = new I_USER_PROFILE();
        //var name = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_NICKNAME);
        //myInfo.townName = name != null ? name.info : "";
        //myInfo.headFrame = uint.Parse(MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_HEAD_FRAME).info);
        //myInfo.headImgId = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_AVATAR).info;
        //data.task.userInfo = myInfo;
        GuildMatchModel.Instance.oddTaskCnt--;
        GuildMatchModel.Instance.UpdateTaskInfo(data.pos, data.task);
        EventManager.Instance.DispatchEvent(GuildMatchEvent.GuildReceive);
    }

    public void ReqGuildReceive(uint pos,uint id)
    {
        C_MSG_GUILD_COMPETITION_RECEIVE c_MSG_GUILD_COMPETITION_RECEIVE = new C_MSG_GUILD_COMPETITION_RECEIVE();
        c_MSG_GUILD_COMPETITION_RECEIVE.pos = pos;
        c_MSG_GUILD_COMPETITION_RECEIVE.id = id;
        SendCmd((int)MessageCode.C_MSG_GUILD_COMPETITION_RECEIVE, c_MSG_GUILD_COMPETITION_RECEIVE);
    }
    //刷新任务
    public void GuildRefresh(S_MSG_GUILD_COMPETITION_REFRESH data)
    {
        GuildMatchModel.Instance.UpdateTaskInfo(data.pos, data.task);
        EventManager.Instance.DispatchEvent(GuildMatchEvent.GuildRefresh);
    }

    public void ReqGuildRefresh(uint pos,uint id)
    {
        C_MSG_GUILD_COMPETITION_REFRESH c_MSG_GUILD_COMPETITION_REFRESH = new C_MSG_GUILD_COMPETITION_REFRESH();
        c_MSG_GUILD_COMPETITION_REFRESH.pos = pos;
        c_MSG_GUILD_COMPETITION_REFRESH.id = id;
        SendCmd((int)MessageCode.C_MSG_GUILD_COMPETITION_REFRESH, c_MSG_GUILD_COMPETITION_REFRESH);
    }
    //提交任务
    public void GuildSubmit(S_MSG_GUILD_COMPETITION_SUBMIT data)
    {
        GuildMatchModel.Instance.score = data.score;
        GuildMatchModel.Instance.guildScore = data.guildScore;
        GuildMatchModel.Instance.taskCnt = data.taskCnt;

        GuildMatchModel.Instance.UpdateTaskInfo(data.pos, data.task);
        EventManager.Instance.DispatchEvent(GuildMatchEvent.GuildSubmit);
    }

    public void ReqGuildSubmit(uint pos,uint id)
    {
        C_MSG_GUILD_COMPETITION_SUBMIT c_MSG_GUILD_COMPETITION_SUBMIT = new C_MSG_GUILD_COMPETITION_SUBMIT();
        c_MSG_GUILD_COMPETITION_SUBMIT.pos = pos;
        c_MSG_GUILD_COMPETITION_SUBMIT.id = id;
        SendCmd((int)MessageCode.C_MSG_GUILD_COMPETITION_SUBMIT, c_MSG_GUILD_COMPETITION_SUBMIT);
    }
    //个人积分进度奖励
    public void GuildSelfReward(S_MSG_GUILD_COMPETITION_SELF_REWARD data)
    {
        var dropList = ItemModel.Instance.GetDropData(data.items);
        DropManager.ShowDrop(dropList);
        GuildMatchModel.Instance.selfRewardIds.Add(data.id);
        EventManager.Instance.DispatchEvent(GuildMatchEvent.GuildSelfReward);
    }

    public void ReqGuildSelfReward(uint id)
    {
        C_MSG_GUILD_COMPETITION_SELF_REWARD c_MSG_GUILD_COMPETITION_SELF_REWARD = new C_MSG_GUILD_COMPETITION_SELF_REWARD();
        c_MSG_GUILD_COMPETITION_SELF_REWARD.id = id;
        SendCmd((int)MessageCode.C_MSG_GUILD_COMPETITION_SELF_REWARD, c_MSG_GUILD_COMPETITION_SELF_REWARD);
    }
    //社团积分进度奖励
    public void GuildProReward(S_MSG_GUILD_COMPETITION_PROGRESS_REWARD data)
    {
        var dropList = ItemModel.Instance.GetDropData(data.items);
        DropManager.ShowDrop(dropList);
        GuildMatchModel.Instance.rewardIds.Add(data.id);
        EventManager.Instance.DispatchEvent(GuildMatchEvent.GuildProReward);
    }

    public void ReqGuildProReward(uint id)
    {
        C_MSG_GUILD_COMPETITION_PROGRESS_REWARD c_MSG_GUILD_COMPETITION_PROGRESS_REWARD = new C_MSG_GUILD_COMPETITION_PROGRESS_REWARD();
        c_MSG_GUILD_COMPETITION_PROGRESS_REWARD.id = id;
        SendCmd((int)MessageCode.C_MSG_GUILD_COMPETITION_PROGRESS_REWARD, c_MSG_GUILD_COMPETITION_PROGRESS_REWARD);
    }
    //花盟排行
    public void GuildMatchRank(S_MSG_GUILD_COMPETITION_GUILD_RANK data)
    {
        GuildMatchModel.Instance.guildRankList = data.rankList;
        EventManager.Instance.DispatchEvent(GuildMatchEvent.GuildMatchRank);

    }
    public void ReqGuildMatchRank()
    {
        C_MSG_GUILD_COMPETITION_GUILD_RANK c_MSG_GUILD_COMPETITION_GUILD_RANK = new C_MSG_GUILD_COMPETITION_GUILD_RANK();
        SendCmd((int)MessageCode.C_MSG_GUILD_COMPETITION_GUILD_RANK, c_MSG_GUILD_COMPETITION_GUILD_RANK);
    }
    //花盟成员排行
    public void MemberMatchRank(S_MSG_GUILD_COMPETITION_MEMBER_RANK data)
    {
        GuildMatchModel.Instance.memberRankList = data.rankList;
        EventManager.Instance.DispatchEvent(GuildMatchEvent.MemberMatchRank);
    }

    public void ReqMemberMatchRank()
    {
        C_MSG_GUILD_COMPETITION_MEMBER_RANK c_MSG_GUILD_COMPETITION_MEMBER_RANK = new C_MSG_GUILD_COMPETITION_MEMBER_RANK();
        SendCmd((int)MessageCode.C_MSG_GUILD_COMPETITION_MEMBER_RANK, c_MSG_GUILD_COMPETITION_MEMBER_RANK);
    }
    //成员列表
    public void MemberInfo(S_MSG_GUILD_BATCH_MEMBER_INFO data)
    {
        if(GuildMatchModel.Instance.memberList == null)
        {
            GuildMatchModel.Instance.memberList = new List<I_MEMBER_VO>();
        }
        GuildMatchModel.Instance.memberList.AddRange(data.memberList);
        EventManager.Instance.DispatchEvent(GuildMatchEvent.MemberInfo);
    }

    public void ReqMemberInfo(uint[] userIds)
    {
        C_MSG_GUILD_BATCH_MEMBER_INFO c_MSG_GUILD_BATCH_MEMBER_INFO = new C_MSG_GUILD_BATCH_MEMBER_INFO();
        c_MSG_GUILD_BATCH_MEMBER_INFO.userIds = userIds;
        SendCmd((int)MessageCode.C_MSG_GUILD_BATCH_MEMBER_INFO, c_MSG_GUILD_BATCH_MEMBER_INFO,0);
    }

    public void ReqMemberPage(int index)
    {
        if(index > tatol)
        {
            var need = GuildMatchModel.Instance.memberRankList.Count - index - 1;
            var len = need < 50 ? GuildMatchModel.Instance.memberRankList.Count : index + 50;
            tatol = len - 1;
            var userIds = new List<uint>();
            for (int i = index;i < len; i++)
            {
                userIds.Add(GuildMatchModel.Instance.memberRankList[i].userId);
            }
            ReqMemberInfo(userIds.ToArray());
        }
    }
}
