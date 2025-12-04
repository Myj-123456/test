
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class GuildNotBargainWindow : BaseWindow
{
   private fun_Guild_New.guild_not_bargain view;

   public GuildNotBargainWindow()
    {
        packageName = "fun_Guild_New";
        // 设置委托
        BindAllDelegate = fun_Guild_New.fun_Guild_NewBinder.BindAll;
        CreateInstanceDelegate = fun_Guild_New.guild_not_bargain.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Guild_New.guild_not_bargain;
        SetBg(view.bg, "Common/ELIDA_common_bigdi01.png");
        

        view.name_title.text = Lang.GetValue("persekutuan_name_04");
        view.time_title.text = Lang.GetValue("bargain_5");

        view.list.itemRenderer = RenderList;
        view.list.SetVirtual();

        EventManager.Instance.AddEventListener(GuildEvent.GuildKanNot, UpdateList);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        GuildModel.Instance.ClearNotKanList();
        GuildController.Instance.ReqGuildKanNot(0);
    }

    private void UpdateList()
    {
        view.list.numItems = GuildModel.Instance.notKan.Count;
    }

    private void RenderList(int index, GObject item)
    {
        var cell = item as fun_Guild_New.guild_not_bargain_item;
        var info = GuildModel.Instance.notKan[index];
        cell.type.selectedIndex = index % 2;
        cell.nameLab.text = info.userInfo.townName;
        cell.timeLab.text = TimeUtil.GenerateTimeDesc((int)info.userInfo.lastLoginTime);
        GuildModel.Instance.GetNotKanListNext(index);
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

