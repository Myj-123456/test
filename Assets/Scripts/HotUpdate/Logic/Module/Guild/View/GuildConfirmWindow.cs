
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class GuildConfirmWindow : BaseWindow
{
   private fun_Guild_New.guild_confirmTips view;

   public GuildConfirmWindow()
    {
        packageName = "fun_Guild_New";
        // 设置委托
        BindAllDelegate = fun_Guild_New.fun_Guild_NewBinder.BindAll;
        CreateInstanceDelegate = fun_Guild_New.guild_confirmTips.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Guild_New.guild_confirmTips;
        SetBg(view.bg, "Common/ELIDA_common_littledi01.png");
        StringUtil.SetBtnTab(view.btn_confirm, Lang.GetValue("gui_btn_confirm"));
        StringUtil.SetBtnTab(view.btn_cancel, Lang.GetValue("gui_btn_cancel"));

        view.tip_title.text = Lang.GetValue("bargain_6");
        view.content.text = Lang.GetValue("bargain_7");
        view.btn_cancel.onClick.Add(() =>
        {
            Close();
        });
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

