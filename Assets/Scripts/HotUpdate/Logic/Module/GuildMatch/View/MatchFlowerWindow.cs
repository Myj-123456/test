
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MatchFlowerWindow : BaseWindow
{
   private fun_Guild_Match.match_flower_view view;

   public MatchFlowerWindow()
    {
        packageName = "fun_Guild_Match";
        // 设置委托
        BindAllDelegate = fun_Guild_Match.fun_Guild_MatchBinder.BindAll;
        CreateInstanceDelegate = fun_Guild_Match.match_flower_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Guild_Match.match_flower_view;
        SetBg(view.bg, "Common/ELIDA_common_bigdi01.png");
        view.tipLab.text = Lang.GetValue("guild_Match_13");
        view.list.itemRenderer = RenderList;
        view.list.SetVirtual();
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        view.list.numItems = GuildMatchModel.Instance.specialFlowers.Count;
    }

    private void RenderList(int index,GObject item)
    {
        var cell = item as fun_Guild_Match.match_flower_item;
        var flowerId = GuildMatchModel.Instance.specialFlowers[index];
        var itemVo = ItemModel.Instance.GetItemByEntityID(flowerId.ToString());
        cell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

