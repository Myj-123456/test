
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class GuildInputWindow : BaseWindow
{
   private common_New.guild_input view;
    private string title;
    private string eventName;

   public GuildInputWindow()
    {
        packageName = "common_New";
        // 设置委托
        BindAllDelegate = common_New.common_NewBinder.BindAll;
        CreateInstanceDelegate = common_New.guild_input.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        
        view = ui as common_New.guild_input;
        SetBg(view.bg,"Common/ELIDA_common_littledi01.png");
        view.btn_sure.onClick.Add(OnClick);
        view.txt_input.restrict = "[0-9]*";
        view.txt_input.maxLength = 9;
        StringUtil.SetBtnTab(view.btn_sure, Lang.GetValue("levelup_button"));
        
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        object[] param = data as object[];
        title = (string)param[0];
        eventName = (string)param[1];
        view.title.text = title;
        view.txt_input.text = "";
    }

    private void OnClick()
    {
        if(view.txt_input.text == "")
        {
            return;
        }
        EventManager.Instance.DispatchEvent(eventName, view.txt_input.text);
        UIManager.Instance.CloseWindow(UIName.GuildInputWindow);
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

