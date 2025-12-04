using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using ADK;

public class V_GuildFunc
{
    public fun_Guild.guild_func view;
    private List<M_GuildFunc> listData;
    public V_GuildFunc(fun_Guild.guild_func ui)
    {
        view = ui;
        //view.list_func.itemRenderer = RenderMember;
    }

    //public void initList()
    //{
    //    listData = GuildModel.Instance.GetFuncBtnList();
    //    view.list_func.numItems = 12;
    //}

    //private void RenderMember(int index,GObject item)
    //{
    //    var cell = item as fun_Guild.guild_func_btn;
    //    if(index < listData.Count)
    //    {
    //        var data = listData[index];
    //        cell.data = data;
    //        cell.txt_name.text = data.name;
    //        cell.icon_loader.url = data.icon;
    //        cell.onClick.Add(ClickFunc);
    //    }
    //    else
    //    {
    //        cell.txt_name.text = "";
    //        cell.icon_loader.url = "";
    //    }
       
    //}

    //private void ClickFunc(EventContext context)
    //{
    //    M_GuildFunc data = (context.sender as GComponent).data as M_GuildFunc;
    //    if(data._func == AssociationFunType.GuildDonate)
    //    {
    //        UIManager.Instance.OpenWindow<GuildDonateWindow>(UIName.GuildDonateWindow);
    //    }else if(data._func == AssociationFunType.GuildPlanting)
    //    {
    //        UIManager.Instance.OpenWindow<GuildPlantingWindow>(UIName.GuildPlantingWindow);
    //    }else if(data._func == AssociationFunType.FlowerShare)
    //    {
    //        UIManager.Instance.OpenWindow<FlowerShareWindow>(UIName.FlowerShareWindow);
    //    }
    //}
}
