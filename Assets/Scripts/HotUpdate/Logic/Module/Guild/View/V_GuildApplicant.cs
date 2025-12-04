using System.Collections;
using System.Collections.Generic;
using ADK;
using UnityEngine;
using FairyGUI;
using protobuf.guild;
using protobuf.common;

public class V_GuildApplicant
{
    public fun_Guild.guild_applicant view;
    public List<I_USER_PROFILE> listData;
    public V_GuildApplicant(fun_Guild.guild_applicant ui)
    {
        view = ui;
        StringUtil.SetBtnTab(view.btn_refuseAll, Lang.GetValue("slang_92"));//Ò»¼ü¾Ü¾ø
        view.list_applicant.itemRenderer = RenderApplicant;
        view.list_applicant.SetVirtual();
        view.btn_refuseAll.onClick.Add(RefuseAll);
    }

    public void UpdateApplicant()
    {
        listData = GuildModel.Instance.applyList;
        view.list_applicant.numItems = listData.Count;
        view.btn_refuseAll.enabled = GuildModel.Instance.CanAcept() && listData.Count > 0;
    }

    private void RenderApplicant(int index,GObject item)
    {
        var cell = item as fun_Guild.guild_applicant_list_cell;
        var userInfo = listData[index];
        StringUtil.SetBtnTab(cell.btn_accept, Lang.GetValue("slang_48"));//½ÓÊÜ
        StringUtil.SetBtnTab(cell.btn_refuse, Lang.GetValue("slang_49"));//¾Ü¾ø
        if (GuildModel.Instance.CanAcept())
        {
            cell.btn_accept.visible = true;
            cell.btn_refuse.visible = true;
        }
        else
        {
            cell.btn_accept.visible = false;
            cell.btn_refuse.visible = false;
        }
        cell.head.imgLoader.url = "Avatar/ELIDA_common_touxiangdi01.png";
        
        cell.txt_name.text = userInfo.townName;
        cell.head.txt_lv.text = userInfo.userLevel.ToString();
        cell.btn_accept.data = userInfo.userId;
        cell.btn_refuse.data = userInfo.userId;
        cell.btn_accept.onClick.Add(AcceptHandle);
        cell.btn_refuse.onClick.Add(RefuseHandle);
    }

    private void RefuseAll()
    {
        GuildController.Instance.ReqGuildDealApply(0,2);
    }

    private void AcceptHandle(EventContext context)
    {
        int id = (int)(context.sender as GComponent).data;
        GuildController.Instance.ReqGuildDealApply(id, 1);
    }

    private void RefuseHandle(EventContext context)
    {
        int id = (int)(context.sender as GComponent).data;
        GuildController.Instance.ReqGuildDealApply(id, 2);
    }

}
