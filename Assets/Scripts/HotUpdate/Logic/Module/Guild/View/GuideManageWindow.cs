
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class GuideManageWindow : BaseWindow
{
   private fun_Guild.guild_manage _view;

   public GuideManageWindow()
    {
        packageName = "fun_Guild";
        // 设置委托
        BindAllDelegate = fun_Guild.fun_GuildBinder.BindAll;
        CreateInstanceDelegate = fun_Guild.guild_manage.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        _view = ui as fun_Guild.guild_manage;
        //_view.txt_title_manage.text = Lang.GetValue("guild.tt_manage");//社团管理
        //_view.txt_title_posName.text = Lang.GetValue("guild.tt_posName");//社团职称名
        //StringUtil.SetBtnTab(_view.btn_max, Lang.GetValue("guild.bt_manage_full"));//满级
        //StringUtil.SetBtnTab(_view.btn_upgrade, Lang.GetValue("guild_5"));//升级为
        //_view.list_positionName.itemRenderer = ItemRender;

        //_view.btn_upgrade.onClick.Add(() =>
        //{
        //    UIManager.Instance.OpenWindow<GuildUpgradeWindow>(UIName.GuildUpgradeWindow);
        //});

        //EventManager.Instance.AddEventListener(GuildEvent.GuildPositionName, UpdateList);
        //EventManager.Instance.AddEventListener(GuildEvent.GuildUpgrade, UpdateMoney);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        //UpdateMoney();
        //UpdateList();
    }

    //private void UpdateMoney()
    //{
    //    var curLv = GuildModel.Instance.guildLvMap[(int)GuildModel.Instance.guild.lv];
    //    _view.txt_lv.text = Lang.GetValue("guild.manager_lv", GuildModel.Instance.guild.lv.ToString());//{0}级社团
    //    if (GuildModel.Instance.guildLvMap.ContainsKey((int)GuildModel.Instance.guild.lv + 1))
    //    {
    //        var nextLv = GuildModel.Instance.guildLvMap[(int)GuildModel.Instance.guild.lv + 1];
    //        _view.txt_money.text = Lang.GetValue("guild.manager_money", GuildModel.Instance.guild.money + "/" + curLv.Peraga);
    //       if (GuildModel.Instance.guild.money >= nextLv.Peraga)
    //        {
    //            _view.progress.value = 1;
    //            _view.progress.max = 1;
    //        }
    //        else
    //        {
    //            _view.progress.value = GuildModel.Instance.guild.money;
    //            _view.progress.max = curLv.Peraga;
    //        }
    //        _view.btn_upgrade.lvLab.text = "Lv" + nextLv.Level;
    //        _view.btn_max.visible = false;
    //        _view.btn_upgrade.visible = true;
    //        _view.btn_upgrade.enabled = GuildModel.Instance.guild.money > curLv.Peraga;
    //    }
    //    else
    //    {
    //        _view.txt_money.text = Lang.GetValue("guild.manager_money", GuildModel.Instance.guild.money.ToString());//资金：{0}
    //        _view.progress.value = 1;
    //        _view.progress.max = 1;
    //        _view.btn_upgrade.enabled = false;
    //        _view.btn_max.visible = true;
    //    }
    //}

    //private void UpdateList()
    //{
    //    _view.list_positionName.numItems = 4;
    //}

    //private void ItemRender(int index,GObject item)
    //{
    //    var cell = item as fun_Guild.guild_posName_list_cell;
    //    cell.btn_changeName.data = index + 1;
    //    int pos = index + 1;
    //    cell.txt_posNameDefault.text = Lang.GetValue(GuildModel.Instance.positionNameMap[pos].Name);
    //    cell.txt_posName.text = GuildModel.Instance.GetPositionName((uint)pos);
    //    StringUtil.SetBtnTab(cell.btn_changeName, Lang.GetValue("guild.pos_change"));
    //    cell.btn_changeName.onClick.Add(ChangeNameBtn);
    //}

    //private void ChangeNameBtn(EventContext context)
    //{
    //    int pos = (int)(context.sender as GComponent).data;
    //    UIManager.Instance.OpenWindow<CreateGuildWindow>(UIName.CreateGuildWindow, (uint)pos);
    //}

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

