
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class GuildChangeNoticeWindow : BaseWindow
{
   private fun_Guild_New.guild_changeNotice view;
    private uint type;
   public GuildChangeNoticeWindow()
    {
        packageName = "fun_Guild_New";
        // 设置委托
        BindAllDelegate = fun_Guild_New.fun_Guild_NewBinder.BindAll;
        CreateInstanceDelegate = fun_Guild_New.guild_changeNotice.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Guild_New.guild_changeNotice;
        SetBg(view.bg, "Common/ELIDA_common_littledi01.png");
        StringUtil.SetBtnTab(view.btn_sure, Lang.GetValue("Share_txt28"));
        view.btn_sure.onClick.Add(() =>
        {
            if (view.txt_input.text.Trim() == "")
            {
                Lang.GetValue("guild.name_can_not_empty");
                return;
            }
            string txt = view.txt_input.text;
            GuildController.Instance.ReqGuildChangeTxt(txt);
            UIManager.Instance.CloseWindow(UIName.GuildChangeNoticeWindow);
        });
        view.txt_input.onFocusIn.Add(() =>
        {
            view.tip.text = "";
        });
        view.txt_input.onFocusOut.Add(() =>
        {
            if (view.txt_input.text.Trim() == "")
            {
                view.tip.text = "请输入您的公告内容";
            }

        });
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        view.tip.text = "请输入您的公告内容";
        type = (uint)data;
        view.txt_input.text = "";
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

