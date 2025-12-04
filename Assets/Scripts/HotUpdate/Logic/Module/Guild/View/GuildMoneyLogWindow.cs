
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class GuildMoneyLogWindow : BaseWindow
{
   private fun_Guild.guild_money_log _view;

   public GuildMoneyLogWindow()
    {
        packageName = "fun_Guild";
        // 设置委托
        BindAllDelegate = fun_Guild.fun_GuildBinder.BindAll;
        CreateInstanceDelegate = fun_Guild.guild_money_log.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        _view = ui as fun_Guild.guild_money_log;
        _view.lb_title.text = Lang.GetValue("fund_log");
        _view.lb_tip.text = Lang.GetValue("text_message1");
        _view.ls_message.itemRenderer = MessageRenderer;
        _view.ls_message.SetVirtual();

        EventManager.Instance.AddEventListener(GuildEvent.GuildMoney, UpdateList);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        GuildController.Instance.ReqGuildMoney();
        
    }

    private void UpdateList()
    {
        _view.ls_message.numItems = GuildModel.Instance.messageList.Count;
    }

    private void MessageRenderer(int index,GObject item)
    {
        var cell = item as fun_Guild.guild_money_log_Cell;
        var message = GuildModel.Instance.messageList[index];
        var userData = GuildModel.Instance.GetMember(message.userId);
        cell.txt_userName.text = userData.townName;
        var head = cell.head as common.robbedHead_big;
        head.img_head.url = "Avatar/ELIDA_common_touxiangdi01.png";
        head.txt_lv.text = userData.userLevel.ToString();
        cell.txt_date.text = TimeUtil.GenerateTimeDesc((int)message.operateTime);
        cell.txt_info_0.text = Lang.GetValue("guildStore_25", message.cnt.ToString()) + "\n";
        switch (message.type)
        {
            case 2:
                var skillid = message.targetId;
                //if(GuildModel.Instance.storeskill[(int)skillid].LineType == 1)
                //{
                //    cell.txt_info_0.text += Lang.GetValue("guildStore_26", Lang.GetValue("guildStore_7", GuildModel.Instance.storeskill[(int)skillid].Skills[1].ToString()));
                //}
                //else
                //{
                //    cell.txt_info_0.text += Lang.GetValue("guildStore_26", skillid == 10 ? Lang.GetValue("guildStore_8") : Lang.GetValue("guildStore_9"));
                //}
                break;
            case 1:
                cell.txt_info_0.text += Lang.GetValue("guildStore_27", message.targetId.ToString());
                break;
            case 3:
                cell.txt_info_0.text += Lang.GetValue("guildStore_29");
                break;

        }
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

