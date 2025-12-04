
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ADK;

public class GuildChangeNameWindow : BaseWindow
{
   private fun_Guild.guild_changeName view;

   public GuildChangeNameWindow()
    {
        packageName = "fun_Guild";
        // 设置委托
        BindAllDelegate = fun_Guild.fun_GuildBinder.BindAll;
        CreateInstanceDelegate = fun_Guild.guild_changeName.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Guild.guild_changeName;
        StringUtil.SetBtnTab(view.btn_cancel, Lang.GetValue("gui_btn_cancel"));
        StringUtil.SetBtnTab(view.btn_sure, Lang.GetValue("gui_btn_sure"));
        view.btn_cancel.onClick.Add(() =>
        {
            UIManager.Instance.CloseWindow(UIName.GuildChangeNameWindow);
        });

        view.btn_sure.onClick.Add(() =>
        {
            if(view.txt_input.text == "")
            {
                return;
            }
            //GuildController.Instance.ReqGuildChangName(view.txt_input.text);
            UIManager.Instance.CloseWindow(UIName.GuildChangeNameWindow);
        });
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        //var costInfo = GlobalModel.Instance.module_profileConfig.guildChangeNameCost;
        //var costName = ItemModel.Instance.GetNameByEntityID(costInfo.Keys.ToList()[0]);
        //var costNum = costInfo.Values.ToList()[0];
        //view.tip.text = Lang.GetValue("guild.needCost", costName + costNum);
        //view.btn_sure.enabled = MyselfModel.Instance.diamond >= costNum;
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

