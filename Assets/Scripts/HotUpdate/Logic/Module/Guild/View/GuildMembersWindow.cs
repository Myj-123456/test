
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using protobuf.guild;

public class GuildMembersWindow
{
    private fun_Guild_New.guild_members view;
    private List<I_MEMBER_VO> listData;//成员列表

    private bool _end;

    private uint page = 0;
    //public GuildMembersWindow()
    //{
    //    packageName = "fun_Guild_New";
    //    // 设置委托
    //    BindAllDelegate = fun_Guild_New.fun_Guild_NewBinder.BindAll;
    //    CreateInstanceDelegate = fun_Guild_New.guild_members.CreateInstance;
    //}

    public GuildMembersWindow(fun_Guild_New.guild_members ui)
    {
        view = ui;
        view.list_players.itemRenderer = RenderMember;
        view.list_players.SetVirtual();

        EventManager.Instance.AddEventListener(GuildEvent.GuildMemberList, UpdatePlayers);
        EventManager.Instance.AddEventListener(GuildEvent.GuildTransfer, UpdatePlayers);
        EventManager.Instance.AddEventListener(GuildEvent.GuildKick, UpdatePlayers);
        EventManager.Instance.AddEventListener(GuildEvent.GuildPromotion, UpdatePlayers);
        //EventManager.Instance.AddEventListener(GuildEvent.LeaveGuild, Close);
    }

    //public override void OnInit()
    //{
    //    base.OnInit();
    //    view = ui as fun_Guild_New.guild_members;
    //    SetBg(view.bg, "Common/ELIDA_common_bigdi01.png");
    //    view.list_players.itemRenderer = RenderMember;
    //    view.list_players.SetVirtual();

    //    EventManager.Instance.AddEventListener(GuildEvent.GuildMemberList, UpdatePlayers);
    //    EventManager.Instance.AddEventListener(GuildEvent.GuildTransfer, UpdatePlayers);
    //    EventManager.Instance.AddEventListener(GuildEvent.GuildKick, UpdatePlayers);
    //    EventManager.Instance.AddEventListener(GuildEvent.GuildPromotion, UpdatePlayers);
    //    EventManager.Instance.AddEventListener(GuildEvent.LeaveGuild, Close);
    //}

    public void UpdatePlayers()
    {
        listData = GuildModel.Instance.GetMemberList();
        view.list_players.numItems = listData.Count;
    }

    private void RenderMember(int index, GObject item)
    {
        var cell = item as fun_Guild_New.guild_member_list_cell;
        var userInfo = listData[index];
        cell.data = userInfo;
        cell.head.imgLoader.url = "Avatar/ELIDA_common_touxiangdi01.png";
        cell.head.txt_lv.text = userInfo.userLevel.ToString();
        cell.txt_name.text = userInfo.townName;
        cell.txt_position.txt_position.text = GuildModel.Instance.GetPositionName(userInfo.powerId);
        cell.txt_position.type.selectedIndex = userInfo.powerId < 3 ? (int)userInfo.powerId - 1 : 2;

        cell.power_num.text = TextUtil.ChangeCoinShow1(userInfo.fighting);
        GuildModel.Instance.GetMemberListNext(index);
        cell.txt_money.text = Lang.GetValue("guild.tt_donate", userInfo.money.ToString());//贡献：{0}
        cell.txt_loginTime.text = Lang.GetValue("guild.tt_loginTime", TimeUtil.GenerateTimeDesc((int)userInfo.lastLoginTime));//最后登录：{0}
        cell.onClick.Add(ClickMember);
    }

    private void ClickMember(EventContext context)
    {
        I_MEMBER_VO param = (context.sender as GComponent).data as I_MEMBER_VO;
        if (param.userId == MyselfModel.Instance.userId)
        {
            return;
        }
        UIManager.Instance.OpenWindow<GuildMemberPopWindow>(UIName.GuildMemberPopWindow, param);
    }

    //public override void OnShown()
    //{
    //    base.OnShown();
    //    // 其他打开面板的逻辑
    //    GuildModel.Instance.ClearMemberList();

    //    GuildController.Instance.ReqGuildMemberList(0);
    //}

    public void OnShow()
    {
        view.list_players.numItems = 0;
        GuildModel.Instance.ClearMemberList();
        GuildController.Instance.ReqGuildMemberList(0);
    }

    //public override void OnHide()
    //{
    //    base.OnHide();
    //    // 其他关闭面板的逻辑
    //}
}

