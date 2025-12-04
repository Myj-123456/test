using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GuildEnterView : BaseView
{
   private fun_Guild_New.guild_enter_view view;

   public GuildEnterView()
    {
        packageName = "fun_Guild_New";
        // 设置委托
        BindAllDelegate = fun_Guild_New.fun_Guild_NewBinder.BindAll;
        CreateInstanceDelegate = fun_Guild_New.guild_enter_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Guild_New.guild_enter_view;
        SetBg(view.bg, "Guild/ELIDA_huameng_dycjr_bg.png");

        view.join_btn.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<GuildJoinWindow>(UIName.GuildJoinWindow);
        });
        view.create_btn.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<CreateGuildWindow>(UIName.CreateGuildWindow);
        });
        EventManager.Instance.AddEventListener(GuildEvent.GuildApply, Close);
        EventManager.Instance.AddEventListener(GuildEvent.GuildFound, Close);
        AddEventListener(GuildEvent.GuildRandomJoin, Close);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
    }
    private void OnClose()
    {
        Close();
    }
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

