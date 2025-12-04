
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using Elida.Config;
using System;
using System.IO;

public class GuildDonateWindow : BaseWindow
{
    private fun_Guild_New.guild_donate _view;
    private List<Ft_club_donasiConfig> listData;
    private List<Ft_club_jrewardConfig> proData;
    public GuildDonateWindow()
    {
        packageName = "fun_Guild_New";
        // 设置委托
        BindAllDelegate = fun_Guild_New.fun_Guild_NewBinder.BindAll;
        CreateInstanceDelegate = fun_Guild_New.guild_donate.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        _view = ui as fun_Guild_New.guild_donate;
        SetBg(_view.bg, "Common/ELIDA_common_bigdi01.png");
        _view.tip.text = Lang.GetValue("guild.donateTimeUpdate");//捐献次数每日0点刷新
        _view.txt_num_title.text = Lang.GetValue("guild.leftDonateTimes");//今日可捐献次数
        //_view.txt_title_donate.text = Lang.GetValue("guild.title_donate");//社团捐献

        StringUtil.SetBtnTab(_view.video_donate.btn_video, Lang.GetValue("flower_order_05"));
        _view.video_donate.txt_reward_title.text = Lang.GetValue("donate_title_reward");//奖励

        proData = GuildModel.Instance.jrewardData.DataList;

        _view.list_donate.itemRenderer = ItemRender;
        _view.status_share.selectedIndex = 0;

        _view.list_pro.itemRenderer = ItemProRender;

        _view.video_donate.btn_video.onClick.Add(() =>
        {
            VideoController.Instance.ReqVideoWatch((uint)VideoSeeType.guild_video_id);
        });

        EventManager.Instance.AddEventListener(GuildEvent.GuildDonate, UpdateList);

        EventManager.Instance.AddEventListener(VideoEvent.videoGuildDonate, UpdateVideoData);
        EventManager.Instance.AddEventListener(GuildEvent.LeaveGuild, Close);

        EventManager.Instance.AddEventListener(GuildEvent.GuildDonateProgress, UpdateProList);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        UpdateList();
        UpdateVideoData();

    }


    public void UpdateProList()
    {
        _view.list_pro.numItems = proData.Count;
        var maxNum = proData[proData.Count - 1].Progress;
        var proNum = ((float)GuildModel.Instance.guildDonate / maxNum * 100f).ToString("F2");
        _view.proLab.text = proNum + "%";
    }

    private void ItemProRender(int index, GObject item)
    {
        var cell = item as fun_Guild_New.guild_donate_pro_cell;
        var pro = proData[index];
        if(GuildModel.Instance.guildDonate < pro.Progress)
        {
            cell.type.selectedIndex = 0;
        }
        else
        {
            if(GuildModel.Instance.haveDrawDonateIds.IndexOf((uint)pro.Id) == -1)
            {
                cell.type.selectedIndex = 1;
            }
            else
            {
                cell.type.selectedIndex = 2;
            }
        }
        cell.getBtn.data = pro.Id;
        cell.getBtn.onClick.Add(GetProReward);
    }

    private void GetProReward(EventContext context)
    {
        var id = (int)(context.sender as GObject).data;
        GuildController.Instance.ReqGuildDonateProgress((uint)id);
    }

    public void UpdateList()
    {
        listData = GuildModel.Instance.donateList;
        _view.list_donate.numItems = listData.Count;
        DonatimesChanged();
        UpdateProList();
    }

    private void ItemRender(int index, GObject item)
    {
        var cell = item as fun_Guild_New.guild_donate_list_cell;
        var data = listData[index];
        cell.txt_reward_title.text = Lang.GetValue("donate_title_reward");//奖励

        var maxNum = GuildModel.Instance.othersConfig.PersekutuanjumlahDonasi;
        cell.donateType.selectedIndex = 0;
        StringUtil.SetBtnTab(cell.btn_donate, Lang.GetValue("slang_47"));
        StringUtil.SetBtnTab(cell.btn_video, Lang.GetValue("flower_order_05"));
        cell.list.itemRenderer = (int index, GObject item) =>
        {

            var cell = item as fun_Guild_New.itemView;
            if (index == data.Dapatkans.Length)
            {
                cell.img_loader.url = ImageDataModel.Instance.GuildMoneyIconUrl();
                cell.txt_num.text = data.Peraga.ToString();
            }
            else
            {
                cell.img_loader.url = ImageDataModel.Instance.GetIconUrlByEntityId(data.Dapatkans[index].EntityID);
                cell.txt_num.text = data.Dapatkans[index].Value.ToString();
            }
        };
        cell.list.numItems = data.Dapatkans.Length + 1;
        var str = "";
        foreach(var cost in data.Konsumsis)
        {
            var name = ItemModel.Instance.GetNameByEntityID(cost.EntityID);
            str += cost.Value + name;
        }
        
        cell.txt_content.text = Lang.GetValue("donate_desc", str);
        cell.btn_donate.enabled = GuildModel.Instance.guildMember.donateCnt < maxNum;
        cell.btn_donate.data = data.Jenis;
        cell.btn_donate.onClick.Add((ClickDonate));
    }

    private void ClickDonate(EventContext context)
    {

        int id = (int)(context.sender as GComponent).data;
        var donateData = GuildModel.Instance.GetDonasiData(id);
        int count = StorageModel.Instance.GetItemCount(donateData.Konsumsis[0].EntityID);
        if (count < donateData.Konsumsis[0].Value)
        {
            string str = ItemModel.Instance.GetNameByEntityID(donateData.Konsumsis[0].EntityID);
            UILogicUtils.ShowNotice(Lang.GetValue("guild.notEnough", str));
            return;
        }
        GuildController.Instance.addMony = donateData.Peraga;
        GuildController.Instance.ReqGuildDonate((uint)id);
    }

    private void DonatimesChanged()
    {
        var maxNum = GuildModel.Instance.othersConfig.PersekutuanjumlahDonasi;
        _view.txt_num_title.text = Lang.GetValue("guild.leftDonateTimes");
        _view.txt_num.text = (maxNum - GuildModel.Instance.guildMember.donateCnt) + "/" + maxNum;
    }

    private void UpdateVideoData()
    {
        _view.video_donate.donateType.selectedIndex = 1;
        var video = VideoModel.Instance.GetVideo((int)VideoSeeType.guild_video_id);
        var curCount = VideoModel.Instance.GetWatchVideoCount((int)VideoSeeType.guild_video_id);
        _view.video_donate.txt_content.text = Lang.GetValue("guild.donate_video", $"({ video.Sp_limit - curCount}/{ video.Sp_limit})");//视频捐献每天一次
        _view.video_donate.btn_video.enabled = video.Sp_limit - curCount > 0;
        _view.video_donate.list.itemRenderer = (int index, GObject item) =>
        {

            var cell = item as fun_Guild_New.itemView;
            if (index == video.Sp_rewards.Length)
            {
                cell.img_loader.url = ImageDataModel.Instance.GuildMoneyIconUrl();
                cell.txt_num.text = video.Peraga.ToString();
            }
            else
            {
                cell.img_loader.url = ImageDataModel.Instance.GetIconUrlByEntityId(video.Sp_rewards[index].EntityID);
                cell.txt_num.text = video.Sp_rewards[index].Value.ToString();
            }
        };
        _view.video_donate.list.numItems = video.Sp_rewards.Length + 1;
        _view.video_donate.list.columnGap = -40;
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

