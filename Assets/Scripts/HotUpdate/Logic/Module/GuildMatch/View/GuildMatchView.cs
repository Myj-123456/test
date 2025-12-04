
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using protobuf.guild;
using ADK;

public class GuildMatchView : BaseView
{
   private fun_Guild_Match.guild_match_main_view view;

    private Dictionary<int,fun_Guild_Match.pro_item> proItemList;

    private int curQuality = 0;

    private CountDownTimer timer;

    private MacthTimeManger matchTimer;

    public List<I_COMPETITION_TASK_VO> listData;
    public GuildMatchView()
    {
        packageName = "fun_Guild_Match";
        // 设置委托
        BindAllDelegate = fun_Guild_Match.fun_Guild_MatchBinder.BindAll;
        CreateInstanceDelegate = fun_Guild_Match.guild_match_main_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Guild_Match.guild_match_main_view;
        proItemList = new Dictionary<int, fun_Guild_Match.pro_item>();
        InitPro();
        SetBg(view.bg, "Guild/ELIDA_huameng_hdjs_bg.jpg");
        
        view.title_txt.text = Lang.GetValue("guild_main_4");
        view.rankLab.text = Lang.GetValue("flower_rank6");
        StringUtil.SetBtnTab(view.task_btn, Lang.GetValue("guild_Match_6"));
        StringUtil.SetBtnTab(view.score_btn, Lang.GetValue("guild_Match_7"));
        StringUtil.SetBtnTab(view.rank_btn, Lang.GetValue("Point_rank_tytle3"));
        StringUtil.SetBtnTab(view.flower_btn, Lang.GetValue("guild_Match_8"));

        matchTimer = new MacthTimeManger();
        view.list.itemRenderer = RenderList;
        view.list.SetVirtual();

        view.chose_grp.list.itemRenderer = RenderQualityList;
        

        view.task_btn.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<MatchMyTaskWindow>(UIName.MatchMyTaskWindow);
        });
        view.score_btn.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<MatchRankWindow>(UIName.MatchRankWindow);
        });
        view.flower_btn.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<MatchFlowerWindow>(UIName.MatchFlowerWindow);
        });

        view.chose_btn.onClick.Add(() =>
        {
            if(view.showChose.selectedIndex == 1)
            {
                view.showChose.selectedIndex = 0;
            }
            else
            {
                view.showChose.selectedIndex = 1;
            }
            
        });
        view.help_btn.onClick.Add(() =>
        {
            string[] str = new string[] { Lang.GetValue("train_help"), Lang.GetValue("guildMatch_6") };
            UIManager.Instance.OpenWindow<HelpWindow>(UIName.HelpWindow, str);
        });
        EventManager.Instance.AddEventListener(GuildMatchEvent.GuildProReward, UpdateProData);
        EventManager.Instance.AddEventListener(GuildMatchEvent.GuildCompetition, InitMatchInfo);

        EventManager.Instance.AddEventListener(GuildMatchEvent.GuildRefresh, UpdataList);

        EventManager.Instance.AddEventListener(GuildMatchEvent.GuildReceive, UpdataList);

        EventManager.Instance.AddEventListener(GuildMatchEvent.GuildSubmit, UpdateMacthTaskInfo);

        EventManager.Instance.AddEventListener(GuildMatchEvent.GuildPosTask, UpdataList);

        view.spine.url = "huadjd";
        view.spine.loop = true;
        view.spine.animationName = "idle";
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        GuildMatchController.Instance.ReqGuildCompetition();
        InitUI();
    }

    private void InitQualityList()
    {
        view.chose_grp.list.numItems = 7;
        view.chose_grp.quality.selectedIndex = curQuality;
        StringUtil.SetBtnTab(view.chose_btn, curQuality == 0?Lang.GetValue("guild_Match_3"):Lang.GetValue("quality_" + curQuality));
    }

    private void RenderQualityList(int index,GObject item)
    {
        var cell = item as fun_Guild_Match.chose_quality_item;
        if(index == 0)
        {
            cell.quality_img.url = "";
            cell.titileLab.text = Lang.GetValue("guild_Match_3");
        }
        else
        {
            cell.quality_img.url = "HandBookNew/rare_icon_" + index + ".png";
            cell.titileLab.text = Lang.GetValue("quality_" + index);
        }
        cell.data = index;
        cell.onClick.Add(ChoseQualityClick);
    }

    private void ChoseQualityClick(EventContext context)
    {
        int type = (int)(context.sender as GComponent).data;
        if(type != curQuality)
        {
            curQuality = type;
            view.chose_grp.quality.selectedIndex = curQuality;
            StringUtil.SetBtnTab(view.chose_btn, curQuality == 0 ? Lang.GetValue("guild_Match_3") : Lang.GetValue("quality_" + curQuality));
            view.showChose.selectedIndex = 0;
            UpdataList();
        }
    }

    private void InitMatchInfo()
    {
        UpdateProData();
        UpdataList();
        UpdateStatus();
        matchTimer.MatchTimer();
    }

    private void UpdateMacthTaskInfo()
    {
        UpdateProData();
        UpdataList();
    }

    private void UpdataList()
    {
        view.limitLab.text = Lang.GetValue("guildMatch_8",GuildMatchModel.Instance.oddTaskCnt.ToString(), GuildModel.Instance.othersConfig.TaskLimits[(int)GuildMatchModel.Instance.matchLv - 1].ToString());
        if(GuildMatchModel.Instance.taskList == null)
        {
            view.list.numItems = 0;
        }
        else
        {
            listData = GuildMatchModel.Instance.GetTaskListData(curQuality);
            view.list.numItems = listData.Count;
        }
        matchTimer.UpdateTimer();
    }

    private void RenderList(int index,GObject item)
    {
        var cell = item as fun_Guild_Match.task_item;
        var taskData = listData[index];
        var taskInfo = GuildMatchModel.Instance.GetMatchTaskInfo((int)taskData.id);
        cell.quality_img.url = "HandBookNew/rare_icon_"+ taskInfo.TaskRank +".png";
        if (taskData.userInfo != null && taskData.userInfo.userId != 0)
        {
            if (taskData.userInfo.userId == MyselfModel.Instance.userId)
            {
                cell.status.selectedIndex = 1;
                cell.scoreLab2.text = "<font color = '#85b57d'>" + taskData.curCnt + "</font>/" + taskData.needCnt;
            }
            else
            {
                cell.status.selectedIndex = 2;
                cell.running_txt.text = Lang.GetValue("guild_Match_2") + "......";
            }
        }
        else
        {
            cell.status.selectedIndex = 0;
            
            cell.scoreLab1.text = GuildMatchModel.Instance.score + "<font color = '#85b57d'> +" + (float.Parse(taskInfo.Score) * taskData.needCnt) + "</font>";
        }
        if (taskInfo.TaskType == 1)
        {
            var ItemVo = ItemModel.Instance.GetItemById((int)taskData.needItem);
            var itemName = ItemVo == null ? "" : Lang.GetValue(ItemVo.Name);
            cell.titleLab.text = Lang.GetValue(taskInfo.Description, taskData.needCnt.ToString(), itemName);
        }
        else if (taskInfo.TaskType == 2)
        {
            var ItemVo = ItemModel.Instance.GetItemById((int)taskData.needItem);
            var itemName = ItemVo == null ? "" : Lang.GetValue(ItemVo.Name);
            cell.titleLab.text = Lang.GetValue(taskInfo.Description, taskData.needCnt.ToString(), itemName);
        }
        else
        {
            cell.titleLab.text = Lang.GetValue(taskInfo.Description, taskData.needCnt.ToString());
        }

        cell.data = taskData.pos;
        cell.onClick.Add(ClickTask);
    }

    private void ClickTask(EventContext context)
    {
        var pos = (uint)(context.sender as GComponent).data;
        UIManager.Instance.OpenWindow<MatchTaskInfoWindow>(UIName.MatchTaskInfoWindow, pos);
    }

    private void InitPro()
    {
        fun_Guild_Match.pro_item proItem = null;
        var maxData = GuildMatchModel.Instance.GetMatchProInfo(GuildMatchModel.Instance.matchProMap.Count);
        foreach (var value in GuildMatchModel.Instance.matchProMap)
        {
            
            if (proItemList.ContainsKey(value.Key))
            {
                proItem = proItemList[value.Key];
            }
            else
            {
                proItem = fun_Guild_Match.pro_item.CreateInstance();
                proItemList.Add(value.Key, proItem);
            }
            view.proGrp.AddChildAt(proItem,0);
            proItem.y = 8;
            proItem.x = ((float)value.Value.Progress / maxData.Progress * 567);
            proItem.data = value.Key;
            proItem.onClick.Add(GetProReward);
            var rewardList = value.Value.Rewards;
            proItem.reward.pro_list.width = 62f * rewardList.Length + 5 * (rewardList.Length - 1);
            proItem.reward.pro_list.itemRenderer = (int index, GObject item) =>
            {
                var cell = item as fun_Guild_Match.pre_item;
                cell.pic.url = ImageDataModel.Instance.GetIconUrlByEntityId(rewardList[index].EntityID);
                cell.numLab.text = rewardList[index].Value.ToString();
            };
            proItem.reward.pro_list.numItems = rewardList.Length;

            LongPressGesture gesture = new LongPressGesture(proItem);
            gesture.trigger = 0.3f;
            gesture.onAction.Add(OnGestureAction);
            gesture.onEnd.Add(OnGestureEnd);
        }
    }

    private void OnGestureAction(EventContext context)
    {
        var cell = (context.sender as LongPressGesture).host as fun_Guild_Match.pro_item;
        cell.show.selectedIndex = 1;
    }

    private void OnGestureEnd(EventContext context)
    {
        var cell = (context.sender as LongPressGesture).host as fun_Guild_Match.pro_item;
        cell.show.selectedIndex = 0;
    }

    private void GetProReward(EventContext context)
    {
        var id = (int)(context.sender as GComponent).data;
        var cell = (context.sender as fun_Guild_Match.pro_item);
        if(cell.status.selectedIndex == 2)
        {
            GuildMatchController.Instance.ReqGuildProReward((uint)id);
        }
        
    }

    private void UpdateStatus()
    {
        if(timer != null)
        {
            timer.Clear();
            timer = null;
        }
        if (GuildMatchModel.Instance.GetIsOpenMatch())
        {
            view.showBtn.selectedIndex = 0;
            view.timeLab.text = "";
            if (!GuildMatchModel.Instance.join)
            {
                view.status.selectedIndex = 1;
                view.showLab.text = Lang.GetValue("guildMatch_119", GuildModel.Instance.othersConfig.BuddyNum.ToString());
                view.unlockLab.text = Lang.GetValue("guild_Match_14");
                view.rankLab.text = Lang.GetValue("last_rank");
                view.rankNum.text = GuildMatchModel.Instance.rankNum == 0 ? Lang.GetValue("no_rank") : GuildMatchModel.Instance.rankNum.ToString();
                SetUpateTime();
            }
            else if (!GuildMatchModel.Instance.memberJoinStatus)
            {
                view.status.selectedIndex = 1;
                view.showLab.text = Lang.GetValue("guild_Match_15");
                view.unlockLab.text = Lang.GetValue("guild_Match_14");
                view.rankLab.text = Lang.GetValue("last_rank");
                view.rankNum.text = GuildMatchModel.Instance.rankNum == 0?Lang.GetValue("no_rank") : GuildMatchModel.Instance.rankNum.ToString();
                SetUpateTime();
            }
            else
            {
                view.showBtn.selectedIndex = 1;
                view.status.selectedIndex = 0;
                int end = (int)GuildMatchModel.Instance.endTime - (int)ServerTime.Time;
                timer = new CountDownTimer(view.unlockLab, end);
                timer.suffixString = Lang.GetValue("guild_Match_5");
                view.rankLab.text = Lang.GetValue("flower_rank6");
                view.rankNum.text = GuildMatchModel.Instance.rankNum.ToString();
                timer.CompleteCallBacker = () =>
                {
                    GuildMatchController.Instance.ReqGuildCompetition();
                    InitUI();
                };
            }
        }
        else
        {
            view.unlockLab.text = Lang.GetValue("Common_Function_Not_Open");
            view.showLab.text = Lang.GetValue("guild_Match_4");
            view.status.selectedIndex = 1;
            view.rankLab.text = Lang.GetValue("last_rank");
            view.rankNum.text = GuildMatchModel.Instance.rankNum == 0 ? Lang.GetValue("no_rank") : GuildMatchModel.Instance.rankNum.ToString();
            int end =  (int)GuildMatchModel.Instance.startTime - (int)ServerTime.Time;
            timer = new CountDownTimer(view.timeLab, end);
            timer.CompleteCallBacker = () =>
            {
                GuildMatchController.Instance.ReqGuildCompetition();
                InitUI();
            };
            view.showBtn.selectedIndex = 0;
        }
    }

    private void SetUpateTime()
    {
        int end = (int)GuildMatchModel.Instance.endTime - (int)ServerTime.Time;
        timer = new CountDownTimer(null, end);
       
        timer.CompleteCallBacker = () =>
        {
            GuildMatchController.Instance.ReqGuildCompetition();
            InitUI();
        };
    }

    private void InitUI()
    {
        curQuality = 0;
        view.chose_grp.quality.selectedIndex = curQuality;
        InitQualityList();
        view.showChose.selectedIndex = 0;
    }

    private void UpdateProData()
    {
        var maxValue = GuildMatchModel.Instance.GetMatchProInfo(GuildMatchModel.Instance.matchProMap.Count).Progress;
        view.scoreNum.text = GuildMatchModel.Instance.guildScore.ToString();
        view.proGrp.pro.max = maxValue;
        view.proGrp.pro.value = GuildMatchModel.Instance.guildScore;
        foreach (var value in proItemList)
        {
            var cell = value.Value;
            var proInfo = GuildMatchModel.Instance.GetMatchProInfo(value.Key);
            cell.proLab.text = proInfo.Progress.ToString();

            if(GuildMatchModel.Instance.guildScore < proInfo.Progress)
            {
                value.Value.status.selectedIndex = 0;
            }
            else
            {
                if(GuildMatchModel.Instance.rewardIds.IndexOf((uint)proInfo.Id) == -1)
                {
                    value.Value.status.selectedIndex = 2;
                }
                else
                {
                    value.Value.status.selectedIndex = 1;
                }
            }
        }
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
        if(matchTimer != null)
        {
            matchTimer.Clear();
        }
        if(timer != null)
        {
            timer.Clear();
            timer = null;
        }
    }
}

