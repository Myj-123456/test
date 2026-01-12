
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class MatchRankWindow : BaseWindow
{
   private fun_Guild_Match.rank_view view;
    private int curType = 0;
   public MatchRankWindow()
    {
        packageName = "fun_Guild_Match";
        // 设置委托
        BindAllDelegate = fun_Guild_Match.fun_Guild_MatchBinder.BindAll;
        CreateInstanceDelegate = fun_Guild_Match.rank_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Guild_Match.rank_view;
        SetBg(view.bg, "Common/common_big_tip_bg.png");

        view.txt_Title.text = Lang.GetValue("guild_Match_7"); //积分排行
        
        StringUtil.SetBtnTab(view.match_btn, Lang.GetValue("guild_Match_9"));
        StringUtil.SetBtnTab(view.history_btn, Lang.GetValue("guild_Match_10"));
        StringUtil.SetBtnTab(view.people_btn, Lang.GetValue("guild_Match_11"));

        StringUtil.SetBtnTab3(view.match_btn, Lang.GetValue("guild_Match_9"));
        StringUtil.SetBtnTab3(view.history_btn, Lang.GetValue("guild_Match_10"));
        StringUtil.SetBtnTab3(view.people_btn, Lang.GetValue("guild_Match_11"));

        view.item1.titileLab.text = Lang.GetValue("guildMatch_3");
        view.item2.titileLab.text = Lang.GetValue("guildMatch_4");
        view.item3.titileLab.text = Lang.GetValue("guildMatch_5");
        view.item4.titileLab.text = Lang.GetValue("guild_Match_12");

        view.match_list.itemRenderer = RenderMacthList;
        view.match_list.SetVirtual();

        view.my_rank.list.itemRenderer = RenderMyRenkList;
        view.my_rank.list.SetVirtual();

        EventManager.Instance.AddEventListener(GuildMatchEvent.GuildMatchRank, UpdateMatchList);
        EventManager.Instance.AddEventListener(GuildMatchEvent.MemberMatchRank, UpdateMemberList);
        EventManager.Instance.AddEventListener(GuildMatchEvent.MemberInfo, UpdateMemberList);
        view.match_btn.onClick.Add(() =>
        {
            if(curType != 0)
            {
                UpdateTab(0);
            }
        });
        view.history_btn.onClick.Add(() =>
        {
            if (curType != 1)
            {
                UpdateTab(1);
            }
        });
        view.people_btn.onClick.Add(() =>
        {
            if (curType != 2)
            {
                UpdateTab(2);
            }
        });
    }

    public override void OnShown()
    {
        base.OnShown();
        view.pic.url = "Guild/guild_match_" + GuildMatchModel.Instance.matchLv + ".png";
        if(GuildMatchModel.Instance.matchLv == 1)
        {
            view.txt_title2.text = Lang.GetValue("guildMatch_3"); 
        }
        else if (GuildMatchModel.Instance.matchLv == 2)
        {
            view.txt_title2.text = Lang.GetValue("guildMatch_4"); 
        }
        else if (GuildMatchModel.Instance.matchLv == 3)
        {
            view.txt_title2.text = Lang.GetValue("guildMatch_5"); 
        }
        else
        {
            view.txt_title2.text = Lang.GetValue("guild_Match_12"); //钻石联赛
        }
        // 其他打开面板的逻辑
        curType = 0;
        view.status.selectedIndex = 0;
        UpdateTab(0);
    }

    private void UpdateTab(int type)
    {
        curType = type;
        if(curType == 0)
        {
            GuildMatchController.Instance.ReqGuildMatchRank();
        }else if(curType == 1)
        {
            UpdateHistory();
        }
        else if(curType == 2)
        {
            view.my_rank.list.numItems = 0;
            GuildMatchController.Instance.ReqMemberMatchRank();
        }
    }

    private void UpdateHistory()
    {
        for(int i = 0;i < GuildMatchModel.Instance.resultStat.Count; i++)
        {
            var cell = view.GetChild("item" + (i + 1)) as fun_Guild_Match.match_history_item;
            var times = GuildMatchModel.Instance.resultStat[i].Split(",");
            cell.fristLab.text = times[0];
            cell.sedLab.text = times[1];
            cell.threeLab.text = times[2];
        }
    }

    private void UpdateMatchList()
    {
        view.match_list.numItems = GuildMatchModel.Instance.guildRankList.Count;
    }

    private void UpdateMemberList()
    {
        view.my_rank.list.numItems = GuildMatchModel.Instance.memberRankList.Count;
        SetMyRankInfo();
    }

    private void RenderMacthList(int index,GObject item)
    {
        var cell = item as fun_Guild_Match.match_rank_item;

        //if(cell.spine.url == null || cell.spine.url == "")
        //{
        //    cell.spine.url = "huadjingd_a";
        //    cell.spine.loop = true;
        //    cell.spine.animationName = "idle";
        //}

        //if (cell.spine1.url == null || cell.spine1.url == "")
        //{
        //    cell.spine1.url = "huadjingd_c";
        //    cell.spine1.loop = true;
        //    cell.spine1.animationName = "idle";
        //}

        //if (cell.pro1.url == null || cell.pro1.url == "")
        //{
        //    cell.pro1.url = "huadjingd_b";
        //    cell.pro1.loop = true;
        //    cell.pro1.animationName = "idle";
        //}


        var rankData = GuildMatchModel.Instance.guildRankList[index];
        cell.rankLan.text = rankData.rankNum.ToString();
        cell.status.selectedIndex = index < 3 ? index : 3;
        cell.nameLab.text = rankData.guildName;
        //var max = GuildMatchModel.Instance.GetMaxScore();
        //var proX = Mathf.Floor(350f * rankData.score / max);
        //cell.pro1.x = 150 + proX;
        var iconArr = rankData.flagId.Split("#");
        cell.guild_icon.icon.url = "Guild/" + GuildModel.Instance.GetIconImgName(int.Parse(iconArr[0])) + ".png";
        cell.guild_icon.bg.url = "Guild/" + GuildModel.Instance.GetIconImgName(int.Parse(iconArr[1])) + ".png";
        cell.scoreLab.text = rankData.score.ToString();

    }

    private void RenderMyRenkList(int index,GObject item)
    {
        var cell = item as fun_Guild_Match.my_rank_item;
        var rankData = GuildMatchModel.Instance.memberRankList[index];
        cell.rankLab.text = rankData.rankNum.ToString();
        cell.status.selectedIndex = index < 3 ? index : 3;
        cell.taskLab.text = rankData.taskCnt.ToString();
        cell.scoreLab.text = rankData.score.ToString();
        var userInfo = GuildMatchModel.Instance.GetMemberInfo(rankData.userId);
        if(userInfo == null)
        {
            GuildMatchController.Instance.ReqMemberPage(index);
        }
        else
        {
            cell.head.pic.url = "Avatar/ELIDA_common_touxiangdi01.png";
            
            cell.levelLab.text = userInfo.userInfo.userLevel.ToString();
            cell.nameLab.text = TextUtil.GetServerName(userInfo.userInfo.serverId,userInfo.userInfo.townName);
            cell.powerLab.text = Lang.GetValue("fighting_title") +"："+ TextUtil.ChangeCoinShow1(userInfo.userInfo.fighting);

            var frameVo = ItemModel.Instance.GetItemById((int)userInfo.userInfo.headFrame);
            UILogicUtils.ShowHeadFrames(cell.head.frame as common_New.PictureFrame, frameVo);
            var headVo = ItemModel.Instance.GetItemById(int.Parse(userInfo.userInfo.headImgId));
            cell.head.pic.url = ImageDataModel.Instance.GetIconUrl(headVo);
        }
    }

    private void SetMyRankInfo()
    {
        var myView = view.my_rank;
        var myInfo = GuildMatchModel.Instance.memberRankList.Find(value => value.userId == MyselfModel.Instance.userId);
        if(myInfo == null)
        {
            myView.rankLab.text = Lang.GetValue("flower_rank9");
        }
        else
        {
            myView.rankLab.text = myInfo.rankNum.ToString();
        }
        var head = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_AVATAR);
        var headVo = ItemModel.Instance.GetItemById(int.Parse(head.info));
        myView.head.pic.url = ImageDataModel.Instance.GetIconUrl(headVo);

        var headFrame = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_HEAD_FRAME);
        var item = ItemModel.Instance.GetItemById(int.Parse(headFrame.info));
        UILogicUtils.ShowHeadFrames(myView.head.frame as common_New.PictureFrame, item);

        myView.taskLab.text = GuildMatchModel.Instance.taskCnt.ToString();
        myView.scoreLab.text = GuildMatchModel.Instance.score.ToString();
        myView.nameLab.text = TextUtil.GetServerName(MyselfModel.Instance.serverId, MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_NICKNAME).info);
        
        //UILogicUtils.ChangeOthersFrameDisplay(userInfo.flowerLevel, userInfo.flowerLevelExpireTime, (_view.myInfo.head.picFrame as common_New.PictureFrame), userInfo.headFrame);
        myView.levelLab.text = MyselfModel.Instance.level.ToString();
        myView.powerLab.text = Lang.GetValue("fighting_title") + "：" + TextUtil.ChangeCoinShow1(MyselfModel.Instance.fighting);
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

