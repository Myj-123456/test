
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using protobuf.guild;
using ADK;

public class GuildSearchResultWindow : BaseWindow
{
    private fun_Guild.guild_search_result _view;
    private I_GUILD_LIST_VO guild;

    public GuildSearchResultWindow()
    {
        packageName = "fun_Guild";
        // 设置委托
        BindAllDelegate = fun_Guild.fun_GuildBinder.BindAll;
        CreateInstanceDelegate = fun_Guild.guild_search_result.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        _view = ui as fun_Guild.guild_search_result;
        //_view.txt_title.text = Lang.GetValue("slang_58");//查找结果
        //_view.guildListTitle.txt_code.text = Lang.GetValue("slang_50");//编号
        //AddEventListener<bool>(GuildEvent.GuildApply, UpdateData1);
        //_view.guild_list_cell.btn_operate.onClick.Add(OperateClick);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        //guild = data as I_GUILD_LIST_VO;
        //UpdateData();
    }

    //public void UpdateData1(bool join)
    //{
    //    if (join)
    //    {
    //        UIManager.Instance.CloseWindow(UIName.GuildSearchResultWindow);
    //    }
    //    else
    //    {
    //        UpdateData();
    //    }
    //}

    //public void UpdateData()
    //{
    //    var view = _view.guild_list_cell;
    //    view.txt_id.text = guild.guildId.ToString();
    //    view.txt_name.text = guild.name;
    //    view.txt_lv.text = "Lv" + guild.lv;
    //    int maxNum = GuildModel.Instance.guildLvMap[(int)guild.lv].JumlahOrang;
    //    view.txt_num.text = guild.memberNum + "/" + maxNum;
    //    view.txt_slogan.text = guild.slogan;
    //    if (guild.memberNum >= maxNum)
    //    {
    //        StringUtil.SetBtnTab(view.btn_operate, Lang.GetValue("guild.guild_list_full"));
    //        view.btn_operate.enabled = false;
    //    }
    //    else
    //    {
    //        if (GuildModel.Instance.IsApplied(guild.guildId))
    //        {
    //            StringUtil.SetBtnTab(view.btn_operate, Lang.GetValue("guild.guild_list_apply"));
    //            view.btn_operate.enabled = false;
    //        }
    //        else
    //        {
    //            StringUtil.SetBtnTab(view.btn_operate, Lang.GetValue("guild.guild_list_apply"));
    //            view.btn_operate.enabled = true;
    //        }
    //    }
    //}

    //private void OperateClick()
    //{
    //    GuildController.Instance.ReqGuildApply(guild.guildId);
    //}

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

