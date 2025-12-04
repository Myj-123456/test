
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class GuildUpgradeWindow : BaseWindow
{
   private fun_Guild_New.guild_manager_View _view;

    private List<M_UpgradeCell> _upgradeChangeds;

   public GuildUpgradeWindow()
    {
        packageName = "fun_Guild_New";
        // 设置委托
        BindAllDelegate = fun_Guild_New.fun_Guild_NewBinder.BindAll;
        CreateInstanceDelegate = fun_Guild_New.guild_manager_View.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        _view = ui as fun_Guild_New.guild_manager_View;

        //StringUtil.SetBtnTab(_view.btn_sure, Lang.GetValue("gui_btn_sure"));
        //StringUtil.SetBtnTab(_view.btn_cancel, Lang.GetValue("gui_btn_cancel"));
        //_view.realTitleLab.text = Lang.GetValue("guild_6");
        //_view.descLab1.text = Lang.GetValue("guild_challenge_13");
        //_view.descLab2.text = Lang.GetValue("guild_7");

        //_view.list_desc.itemRenderer = ItemRender;

        //_view.btn_cancel.onClick.Add(CancelUpgrade);
        //_view.btn_sure.onClick.Add(() =>
        //{
        //    var curLv = GuildModel.Instance.guildLvMap[(int)GuildModel.Instance.guild.lv];
        //    if(GuildModel.Instance.guild.money >= curLv.Peraga)
        //    {
        //        GuildController.Instance.ReqGuildUpgrade();
        //    }
        //});
        //EventManager.Instance.AddEventListener(GuildEvent.GuildUpgrade, CancelUpgrade);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        //var curLv = GuildModel.Instance.guildLvMap[(int)GuildModel.Instance.guild.lv];
        //_upgradeChangeds = new List<M_UpgradeCell>();
        //if (GuildModel.Instance.guildLvMap.ContainsKey((int)GuildModel.Instance.guild.lv + 1))
        //{
        //    var nextLv = GuildModel.Instance.guildLvMap[(int)GuildModel.Instance.guild.lv + 1];
        //    _view.txt_title.text = "X" + curLv.Peraga;//是否消耗{0}资金升级社团
        //    _view.txt_desc_title.text = Lang.GetValue("guild.upgradeTitle", nextLv.Level.ToString());//{0}级社团升级效果
             
        //    if (nextLv.JumlahOrang > curLv.JumlahOrang)
        //    {

        //        _upgradeChangeds.Add(new M_UpgradeCell(0,nextLv.JumlahOrang - curLv.JumlahOrang));
        //    }

        //    if(nextLv.PotBunga > curLv.PotBunga)
        //    {
        //        _upgradeChangeds.Add(new M_UpgradeCell(1,nextLv.PotBunga - curLv.PotBunga));
        //    }

        //    if(nextLv.Experience > curLv.Experience)
        //    {
        //        _upgradeChangeds.Add(new M_UpgradeCell(2, nextLv.Experience - curLv.Experience));
        //    }

        //    if(nextLv.VicePresident > curLv.VicePresident)
        //    {
        //        _upgradeChangeds.Add(new M_UpgradeCell(3, nextLv.VicePresident - curLv.VicePresident));
        //    }
        //    _view.list_desc.numItems = _upgradeChangeds.Count;
        //}

    }
    //private void ItemRender(int index,GObject item)
    //{
    //    var view = item as fun_Guild.guild_upgrade_confirm_list_cell;
    //    string str = "<font color='#ff8d3a'>+" +_upgradeChangeds[index].value + "</font>";
    //    string name = "";
    //    if(_upgradeChangeds[index].type == 0)
    //    {
    //        name = Lang.GetValue("guild.jumlahOrang");
    //    }
    //    else if(_upgradeChangeds[index].type == 1)
    //    {
    //        name = Lang.GetValue("guild.potBunga");
    //    }
    //    else if (_upgradeChangeds[index].type == 2)
    //    {
    //        name = Lang.GetValue("guild.experience");
    //    }
    //    else
    //    {
    //        name = Lang.GetValue("guild.vicePresident");
    //    }
    //    view.txt_desc.text = name + str;
    //}

    //private void CancelUpgrade()
    //{
    //    UIManager.Instance.CloseWindow(UIName.GuildUpgradeWindow);
    //}

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

public class M_UpgradeCell
{
    public int type;
    public int value;
    public M_UpgradeCell(int type,int value)
    {
        this.type = type;
        this.value = value;
    }
}

