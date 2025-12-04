
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GuildWindow : BaseWindow
{
   private fun_Guild.guild _view;
    private int curTab = -1;

    private V_GuildInfo _info;
    private V_GuildMembers _member;
    private V_GuildFunc _func;
    private V_GuildApplicant _applicant;


   public GuildWindow()
    {
        packageName = "fun_Guild";
        // 设置委托
        BindAllDelegate = fun_Guild.fun_GuildBinder.BindAll;
        CreateInstanceDelegate = fun_Guild.guild.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        _view = ui as fun_Guild.guild;

    //    _view.title_txt.text = Lang.GetValue("guild_test_4");//园艺社
    //    _view.txt_code.text = Lang.GetValue("slang_50");//编号
    //    _view.btn_info.title1.text = _view.btn_info.title2.text = Lang.GetValue("guild.tab_title_guild");
    //    _view.btn_member.title1.text = _view.btn_member.title2.text = Lang.GetValue("guild.tab_title_member");
    //    _view.btn_func.title1.text = _view.btn_func.title2.text = Lang.GetValue("guild.tab_title_func");
    //    _view.btn_applicant.title1.text = _view.btn_applicant.title2.text = Lang.GetValue("guild.tab_title_applicant");

    //    _info = new V_GuildInfo(_view.content_info);
    //    _member = new V_GuildMembers(_view.content_member);
    //    _func = new V_GuildFunc(_view.content_func);
    //    _applicant = new V_GuildApplicant(_view.content_applicant);

    //    _view.btn_info.onClick.Add(() =>
    //    {
    //        ChangeTab(0);
    //    });

    //    _view.btn_member.onClick.Add(() =>
    //    {
    //        ChangeTab(1);
    //    });

    //    _view.btn_func.onClick.Add(() =>
    //    {
    //        ChangeTab(2);
    //    });

    //    _view.btn_applicant.onClick.Add(() =>
    //    {
    //        ChangeTab(3);
    //    });

    //    _view.btn_changeName.onClick.Add(() =>
    //    {
    //        UIManager.Instance.OpenWindow<GuildChangeNameWindow>(UIName.GuildChangeNameWindow);
    //    });

    //    _view.setPassBtn.onClick.Add(() =>
    //    {
    //        UIManager.Instance.OpenWindow<GuildPassSetWindow>(UIName.GuildPassSetWindow);
    //    });

    //    EventManager.Instance.AddEventListener(GuildEvent.GuildInfo, UpdateGuildInfo);
    //    EventManager.Instance.AddEventListener(GuildEvent.GuildChangName, UpdateName);
    //    EventManager.Instance.AddEventListener(GuildEvent.GuildQuit, CloseView);

    //    EventManager.Instance.AddEventListener(GuildEvent.GuildMemberList, UpdateMembers);
    //    EventManager.Instance.AddEventListener(GuildEvent.GuildTransfer, UpdateMembers);
    //    EventManager.Instance.AddEventListener(GuildEvent.GuildKick, UpdateMembers);
    //    EventManager.Instance.AddEventListener(GuildEvent.GuildPromotion, UpdateMembers);
    //    EventManager.Instance.AddEventListener(GuildEvent.GuildApplyList, UpdateApplyList);
    //}

    //public override void OnShown()
    //{
    //    base.OnShown();
    //    // 其他打开面板的逻辑
    //    curTab = -1;
    //    ChangeTab(0);
    }

    //private void ChangeTab(int tab)
    //{
    //    if (curTab == tab) return;
    //    curTab = tab;
    //    _view.tab.selectedIndex = tab;
    //    if(tab == 0)
    //    {
    //        GuildController.Instance.ReqGuildInfo();
    //    }else if(tab == 1)
    //    {
    //        GuildController.Instance.ReqGuildMemberList();
    //    }else if(tab == 2)
    //    {
    //        _func.initList();
    //    }
    //    else
    //    {
    //        GuildController.Instance.ReqGuildApplyList();
    //    }
    //}

    //private void UpdateGuildInfo()
    //{
    //    UpdateName();
    //    _view.txt_id.text = GuildModel.Instance.guild.guildId.ToString();
    //    _info.UpdateInfo();
    //}

    //private void UpdateMembers()
    //{
    //    _member.UpdatePlayers();
    //}

    //private void UpdateApplyList()
    //{
    //    _applicant.UpdateApplicant();
    //}

    //private void UpdateName()
    //{
    //    if(GuildModel.Instance.guild != null)
    //    {
    //       _view.txt_name.text = GuildModel.Instance.guild.name;
    //        _view.setPassBtn.visible = (GuildModel.Instance.guildMember.position == 1 || GuildModel.Instance.guildMember.position == 2);
    //        _view.btn_changeName.visible = GuildModel.Instance.guildMember.position == 1;
    //    }
    //    else
    //    {
    //        _view.txt_name.text = "";
    //        _view.setPassBtn.visible = false;
    //        _view.btn_changeName.visible = false;
    //    }
    //}

    //private void CloseView()
    //{
    //    UIManager.Instance.CloseWindow(UIName.GuildWindow);
    //}

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

