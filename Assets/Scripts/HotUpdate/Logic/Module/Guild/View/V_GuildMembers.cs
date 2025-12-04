using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using protobuf.guild;
using ADK;

public class V_GuildMembers
{
    public fun_Guild.guild_members view;
    private List<I_MEMBER_VO> listData;//成员列表
    public V_GuildMembers(fun_Guild.guild_members ui)
    {
        view = ui;
        //view.list_players.itemRenderer = RenderMember;
        //view.list_players.SetVirtual();
    }

    //public void UpdatePlayers()
    //{
    //    listData = GuildModel.Instance.GetMemberList();
    //    view.list_players.numItems = listData.Count;
    //}

    //private void RenderMember(int index,GObject item)
    //{
    //    var cell = item as fun_Guild.guild_member_list_cell;
    //    var userInfo = listData[index];
    //    cell.data = userInfo;
    //    cell.head.imgLoader.url = "Avatar/ELIDA_common_touxiangdi01.png";
    //    UILogicUtils.ChangeOthersFrameDisplay(userInfo.flowerLevel, userInfo.flowerLevelExpireTime, (cell.head.picFrame as common_New.PictureFrame), userInfo.headFrame);
    //    cell.head.txt_lv.text = userInfo.userLevel.ToString();
    //    cell.txt_name.text = userInfo.townName;
    //    cell.txt_position.text = GuildModel.Instance.GetPositionName(userInfo.position);
    //    cell.txt_money.text = Lang.GetValue("guild.tt_donate", userInfo.money.ToString());//贡献：{0}
    //    cell.txt_loginTime.text = Lang.GetValue("guild.tt_loginTime", TimeUtil.GenerateTimeDesc((int)userInfo.lastLoginTime));//最后登录：{0}
    //    cell.onClick.Add(ClickMember);
    //}

    //private void ClickMember(EventContext context)
    //{
    //    I_MEMBER_VO param = (context.sender as GComponent).data as I_MEMBER_VO;
    //    if(param.userId == GuildModel.Instance.guildMember.userId)
    //    {
    //        return;
    //    }
    //    UIManager.Instance.OpenWindow<GuildMemberPopWindow>(UIName.GuildMemberPopWindow,param);
    //}
}
