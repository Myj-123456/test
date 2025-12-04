using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ADK;
using FairyGUI;

public class V_GuildInfo
{
    public fun_Guild.guild_info view;

    //public V_GuildInfo(fun_Guild.guild_info ui)
    //{
    //    view = ui;
    //    view.txt_notice_title.text = Lang.GetValue("slang_52");//公告
    //    view.txt_title_slogan.text = Lang.GetValue("slang_51");//标语：
    //    StringUtil.SetBtnTab(view.btn_manage, Lang.GetValue("guild.bt_manager"));//会长管理
    //    StringUtil.SetBtnTab(view.btn_quit, Lang.GetValue("guild.bt_quit"));//脱离社区

    //    view.txt_title_coin.text = Lang.GetValue("guild_test_3");
    //    view.txt_money_title.text = Lang.GetValue("guild_test_2");//资金
    //    view.txt_num_desc.text = Lang.GetValue("guild_test_1");//人数
    //    view.txt_lv_desc.text = Lang.GetValue("slang_27");//等级

    //    view.btn_changeNotice.onClick.Add(() =>
    //    {
    //        UIManager.Instance.OpenWindow<GuildChangeNoticeWindow>(UIName.GuildChangeNoticeWindow, (uint)2);
    //    });

    //    view.btn_changeSlogan.onClick.Add(() =>
    //    {
    //        UIManager.Instance.OpenWindow<GuildChangeNoticeWindow>(UIName.GuildChangeNoticeWindow, (uint)1);
    //    });

    //    view.btn_manage.onClick.Add(() =>
    //    {
    //        UIManager.Instance.OpenWindow<GuideManageWindow>(UIName.GuideManageWindow);
    //    });

    //    view.btn_quit.onClick.Add(() =>
    //    {
    //        if(GuildModel.Instance.guildMember.position == 1)
    //        {
    //            if(GuildModel.Instance.guild.memberNum == 1)
    //            {
    //                UILogicUtils.ShowConfirm(Lang.GetValue("guild.freeGuild"), () =>
    //                {
    //                    GuildController.Instance.ReqGuildDissolve();
    //                });
    //            }
    //            else
    //            {
    //                UILogicUtils.ShowNotice(Lang.GetValue("guild.transferFirst"));//请先转让会长
    //            }
    //        }
    //        else
    //        {
    //            UILogicUtils.ShowConfirm(Lang.GetValue("guild.quitConfirm2"), () =>
    //            {
    //                GuildController.Instance.ReqGuildQuit();
    //            });
    //        }
    //    });

    //    view.btn_log_money.onClick.Add(() =>
    //    {
    //        UIManager.Instance.OpenWindow<GuildMoneyLogWindow>(UIName.GuildMoneyLogWindow);
    //    });

    //    EventManager.Instance.AddEventListener(GuildEvent.GuildChangeTxt, UpdateGuildInfo);
    //    EventManager.Instance.AddEventListener(GuildEvent.GuildUpgrade, UpdateGuildInfo);

    //}

    //public void UpdateInfo()
    //{
    //    UpdateGuildInfo();
    //    UpdateMyInfo();
    //}

    //public void UpdateGuildInfo()
    //{
    //    var data = GuildModel.Instance.guild;
    //    view.txt_lv.text = data.lv.ToString();
    //    view.txt_money_content.text = data.money.ToString();
    //    view.txt_slogan.text = data.slogan;
    //    view.txt_notice.text = data.notice;
    //    view.txt_coin.text = StorageModel.Instance.GetItemCount(GuildModel.guildCoinId).ToString();
    //    int maxNum = GuildModel.Instance.guildLvMap[(int)data.lv].JumlahOrang;
    //    view.txt_num.text = data.memberNum + "/" + maxNum;
    //}

    //public void UpdateMyInfo()
    //{
    //    var userInfo = GuildModel.Instance.guildMember;
    //    view.txt_leaderName.text = userInfo.townName;
    //    view.leaderName.text = GuildModel.Instance.GetPositionName(userInfo.position);
    //    view.head.imgLoader.url = "Avatar/ELIDA_common_touxiangdi01.png";
    //    UILogicUtils.ChangeOthersFrameDisplay(userInfo.flowerLevel, userInfo.flowerLevelExpireTime, (view.head.picFrame as common_New.PictureFrame), userInfo.headFrame);
    //    view.head.txt_lv.text = userInfo.userLevel.ToString();
    //    view.btn_changeNotice.visible = view.btn_changeSlogan.visible = GuildModel.Instance.CanChangeNotice((int)userInfo.position);
    //    view.btn_manage.visible = (int)userInfo.position == 1;
    //    if (view.btn_manage.visible)
    //    {
    //        view.btn_quit.x = 349;
    //    }
    //    else
    //    {
    //        view.btn_quit.x = 236;
    //    }
    //}
}
