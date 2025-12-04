
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
        SetBg(view.bg, "Common/ELIDA_common_bigdi01.png");
        
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

        if(cell.spine.url == null || cell.spine.url == "")
        {
            cell.spine.url = "huadjingd_a";
            cell.spine.loop = true;
            cell.spine.animationName = "idle";
        }

        if (cell.spine1.url == null || cell.spine1.url == "")
        {
            cell.spine1.url = "huadjingd_c";
            cell.spine1.loop = true;
            cell.spine1.animationName = "idle";
        }

        if (cell.pro1.url == null || cell.pro1.url == "")
        {
            cell.pro1.url = "huadjingd_b";
            cell.pro1.loop = true;
            cell.pro1.animationName = "idle";
        }


        var rankData = GuildMatchModel.Instance.guildRankList[index];
        cell.rankLan.text = rankData.rankNum.ToString();
        cell.status.selectedIndex = index < 3 ? index : 3;
        cell.nameLab.text = rankData.guildName;
        var max = GuildMatchModel.Instance.GetMaxScore();
        var proX = Mathf.Floor(350f * rankData.score / max);
        cell.pro1.x = 150 + proX;
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
            
            cell.levelLab.text = userInfo.userLevel.ToString();
            cell.nameLab.text = userInfo.townName;
            cell.powerLab.text = Lang.GetValue("power_name")+"："+ TextUtil.ChangeCoinShow1(userInfo.fighting);
        }
    }

    private void SetMyRankInfo()
    {
        var myView = view.my_rank;
        var myInfo = GuildMatchModel.Instance.memberRankList.Find(value => value.userId == MyselfModel.Instance.userId);
        if(myInfo == null)
        {
            myView.rankLab.text = "";
        }
        else
        {
            myView.rankLab.text = myInfo.rankNum.ToString();
        }
        myView.taskLab.text = GuildMatchModel.Instance.taskCnt.ToString();
        myView.scoreLab.text = GuildMatchModel.Instance.score.ToString();
        myView.nameLab.text = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_NICKNAME).info;
        myView.head.pic.url = "Avatar/ELIDA_common_touxiangdi01.png";
        //UILogicUtils.ChangeOthersFrameDisplay(userInfo.flowerLevel, userInfo.flowerLevelExpireTime, (_view.myInfo.head.picFrame as common_New.PictureFrame), userInfo.headFrame);
        myView.levelLab.text = MyselfModel.Instance.level.ToString();
        myView.powerLab.text = Lang.GetValue("power_name") + "：" + TextUtil.ChangeCoinShow1(PlayerModel.Instance.pen.drawingPower);
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

