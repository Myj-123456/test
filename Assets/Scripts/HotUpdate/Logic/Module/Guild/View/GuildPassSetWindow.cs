
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class GuildPassSetWindow : BaseWindow
{
   private fun_Guild.guild_pass_set_view view;
    private common.radioButton handBtn;
    private common.radioButton autoBtn;
    private uint approval;
    public GuildPassSetWindow()
    {
        packageName = "fun_Guild";
        // 设置委托
        BindAllDelegate = fun_Guild.fun_GuildBinder.BindAll;
        CreateInstanceDelegate = fun_Guild.guild_pass_set_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Guild.guild_pass_set_view;
        //view.titleLab.text = Lang.GetValue("guild_1");
        //view.handLab.text = Lang.GetValue("guild_2");
        //view.autoLab.text = Lang.GetValue("guild_3");

        //StringUtil.SetBtnTab(view.saveBtn, Lang.GetValue("guild.pos_save"));

        //handBtn = view.handBtn as common.radioButton;
        //autoBtn = view.autoBtn as common.radioButton;

        //handBtn.onClick.Add(() =>
        //{
        //    if (approval == 2) return;
        //    approval = 2;
        //    AutoStatus();
        //});

        //autoBtn.onClick.Add(() =>
        //{
        //    if (approval == 1) return;
        //    approval = 1;
        //    AutoStatus();
        //});

        //view.saveBtn.onClick.Add(() =>
        //{
        //    GuildController.Instance.ReqGuildEditApproval(approval);
        //    UIManager.Instance.CloseWindow(UIName.GuildPassSetWindow);
        //});
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        //approval = GuildModel.Instance.approval;
        //AutoStatus();
    }

    //private void AutoStatus()
    //{
    //    view.saveBtn.enabled = approval != GuildModel.Instance.approval;
    //    handBtn.selStatus.selectedIndex = approval == 2 ? 1 : 0;
    //    autoBtn.selStatus.selectedIndex = approval == 1 ? 1 : 0;
    //}

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

