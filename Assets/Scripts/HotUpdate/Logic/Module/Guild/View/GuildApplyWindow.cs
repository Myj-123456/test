
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using protobuf.common;

public class GuildApplyWindow
{
   private fun_Guild_New.guild_applicant view;
    public List<I_USER_PROFILE> listData;
    //public GuildApplyWindow()
    //{
    //    packageName = "fun_Guild_New";
    //    // 设置委托
    //    BindAllDelegate = fun_Guild_New.fun_Guild_NewBinder.BindAll;
    //    CreateInstanceDelegate = fun_Guild_New.guild_applicant.CreateInstance;
    //}

    public GuildApplyWindow(fun_Guild_New.guild_applicant ui)
    {
        view = ui;
        //SetBg(view.bg, "Common/ELIDA_common_bigdi01.png");
        StringUtil.SetBtnTab(view.btn_refuseAll, Lang.GetValue("slang_92"));//一键拒绝
        view.list_applicant.itemRenderer = RenderApplicant;
        view.list_applicant.SetVirtual();
        view.btn_refuseAll.onClick.Add(RefuseAll);

        EventManager.Instance.AddEventListener(GuildEvent.GuildApplyList, UpdateApplicant);
    }

    //public override void OnInit()
    //{
    //     base.OnInit();
    //    view = ui as fun_Guild_New.guild_applicant;
    //    SetBg(view.bg, "Common/ELIDA_common_bigdi01.png");
    //    StringUtil.SetBtnTab(view.btn_refuseAll, Lang.GetValue("slang_92"));//一键拒绝
    //    view.list_applicant.itemRenderer = RenderApplicant;
    //    view.list_applicant.SetVirtual();
    //    view.btn_refuseAll.onClick.Add(RefuseAll);

    //    EventManager.Instance.AddEventListener(GuildEvent.GuildApplyList, UpdateApplicant);
    //}

    //public override void OnShown()
    //{
    //    base.OnShown();
    //    // 其他打开面板的逻辑
    //    GuildModel.Instance.ClearApplyList();
    //    GuildController.Instance.ReqGuildApplyList(0);
    //}

    public void OnShow()
    {
        view.list_applicant.numItems = 0;
         GuildModel.Instance.ClearApplyList();
        GuildController.Instance.ReqGuildApplyList(0);
    }

    //public override void OnHide()
    //{
    //    base.OnHide();
    //    // 其他关闭面板的逻辑
    //}

    public void UpdateApplicant()
    {
        listData = GuildModel.Instance.applyList;
        view.list_applicant.numItems = listData.Count;
        view.btn_refuseAll.enabled = GuildModel.Instance.CanAcept() && listData.Count > 0;
    }

    private void RenderApplicant(int index, GObject item)
    {
        var cell = item as fun_Guild_New.guild_apply_item;
        var userInfo = listData[index];
        cell.job.selectedIndex = GuildModel.Instance.CanAcept() ? 0 : 1;
        StringUtil.SetBtnTab(cell.btn_accept, Lang.GetValue("slang_48"));//接受
        StringUtil.SetBtnTab(cell.btn_refuse, Lang.GetValue("slang_49"));//拒绝
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
        cell.power_num.text = TextUtil.ChangeCoinShow1(userInfo.fighting);
        GuildModel.Instance.GetApplyListNext(index);
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
        GuildController.Instance.ReqGuildDealApply(0, 2);
    }

    private void AcceptHandle(EventContext context)
    {
        var id = (uint)(context.sender as GComponent).data;
        GuildController.Instance.ReqGuildDealApply((int)id, 1);
    }

    private void RefuseHandle(EventContext context)
    {
        var id = (uint)(context.sender as GComponent).data;
        GuildController.Instance.ReqGuildDealApply((int)id, 2);
    }
}

