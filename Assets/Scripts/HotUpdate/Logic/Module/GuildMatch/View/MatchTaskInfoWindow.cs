
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using protobuf.guild;
using ADK;

public class MatchTaskInfoWindow : BaseWindow
{
   private fun_Guild_Match.task_info_view view;

    private I_COMPETITION_TASK_VO taskData;

    private CountDownTimer timer;
    private uint pos;
   public MatchTaskInfoWindow()
    {
        packageName = "fun_Guild_Match";
        // 设置委托
        BindAllDelegate = fun_Guild_Match.fun_Guild_MatchBinder.BindAll;
        CreateInstanceDelegate = fun_Guild_Match.task_info_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Guild_Match.task_info_view;
        SetBg(view.bg, "Common/common_three_tip_bg.png");

        view.txt_Title.text = Lang.GetValue("newguild_07"); //任务详细
        StringUtil.SetBtnTab(view.getBtn, Lang.GetValue("guildMatch_21"));
        StringUtil.SetBtnTab(view.submit_btn, Lang.GetValue("Common_Btn_Submit"));
        StringUtil.SetBtnTab(view.refresh_btn, Lang.GetValue("common_button_refresh"));
        StringUtil.SetBtnTab(view.jump_btn, Lang.GetValue("travel_button_go"));

        view.refresh_btn.onClick.Add(() =>
        {
            var itemVo = ItemModel.Instance.GetItemByEntityID(GuildModel.Instance.othersConfig.TaskRefreshs[0].EntityID);
            var num = StorageModel.Instance.GetItemCount(itemVo.ItemDefId);
            if(num < GuildModel.Instance.othersConfig.TaskRefreshs[0].Value)
            {
                UILogicUtils.ShowNotice(Lang.GetValue("guildMatch_87", Lang.GetValue(itemVo.Name)));
                return;
            }
            GuildMatchController.Instance.ReqGuildRefresh(taskData.pos,taskData.id);
        });

        view.getBtn.onClick.Add(() =>
        {
            GuildMatchController.Instance.ReqGuildReceive(taskData.pos, taskData.id);
            Close();
        });
        view.submit_btn.onClick.Add(() =>
        {
            GuildMatchController.Instance.ReqGuildSubmit(taskData.pos, taskData.id);
            Close();
        });
        EventManager.Instance.AddEventListener(GuildMatchEvent.GuildRefresh, UpdateData);

        EventManager.Instance.AddEventListener(GuildMatchEvent.GuildPosTask, UpdatePosData);
        EventManager.Instance.AddEventListener(GuildMatchEvent.GuildCompetition, UpdateData);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        pos = (uint)data;
        UpdateData();
    }

    public void UpdateData()
    {
        taskData = GuildMatchModel.Instance.GetTaskData(pos);
        if (timer != null)
        {
            timer.Clear();
            timer = null;
        }
        if(taskData.userInfo != null && taskData.userInfo.userId != 0)
        {
            if (taskData.userInfo.userId == MyselfModel.Instance.userId)
            {
                if(taskData.curCnt < taskData.needCnt)
                {
                    view.status.selectedIndex = 1;
                }
                else
                {
                    view.status.selectedIndex = 2;
                }
            }
            else
            {
                view.status.selectedIndex = 3;
            }
            int endTime = (int)taskData.limitedTime - (int)ServerTime.Time;
            if (endTime > 0)
            {
                timer = new CountDownTimer(view.timeLab, endTime, false, 2);
                timer.prefixString = Lang.GetValue("lshop_ui_label_duration") + "：";
                timer.Run();
            }
            else
            {
                view.timeLab.text = Lang.GetValue("lshop_ui_label_duration") + "：00:00:00";
            }
            var frameVo = ItemModel.Instance.GetItemById((int)taskData.userInfo.headFrame);
            UILogicUtils.ShowHeadFrames(view.head.frame as common_New.PictureFrame, frameVo);
            var headVo = ItemModel.Instance.GetItemById(int.Parse(taskData.userInfo.headImgId));
            view.head.pic.url = ImageDataModel.Instance.GetIconUrl(headVo);
        }
        else
        {
            view.status.selectedIndex = 0;
            int endTime = GuildMatchModel.Instance.GetMarchUpdateTime();
            if (endTime > 0)
            {
                timer = new CountDownTimer(view.timeLab, endTime, false, 2);
                timer.prefixString = Lang.GetValue("lshop_ui_label_duration") + "：";
                timer.Run();
            }
        }
        var taskInfo = GuildMatchModel.Instance.GetMatchTaskInfo((int)taskData.id);
        view.decLab.text = TaskModel.Instance.GetTaskDec(taskInfo.Description, taskInfo.TaskType, (int)taskData.needCnt, (int)taskData.needItem);
       
        view.rare_img.url = "HandBookNew/rare_icon_" + taskInfo.TaskRank + ".png";
        var score = Mathf.Ceil(float.Parse(taskInfo.Score) * taskData.needCnt);
        if (GuildMatchModel.Instance.specialFlowers.IndexOf(taskData.needItem) == -1)
        {
            view.scoreLab.text = score.ToString();
        }
        else
        {
            view.scoreLab.text = score + "<font color = '#85b57d'> +" + Mathf.Floor(score * (GuildModel.Instance.othersConfig.SpecialFlowerAdd / 100)) + "</font>";
        }
        
        view.costLab.text = GuildModel.Instance.othersConfig.TaskRefreshs[0].Value.ToString();
        view.needLab.text = taskData.curCnt + "/" + taskData.needCnt;
    }

    private void UpdatePosData()
    {
        UpdateData();
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

