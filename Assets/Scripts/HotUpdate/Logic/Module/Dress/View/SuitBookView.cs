using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class SuitBookView
{
   private fun_Dress.suit_book_view view;
    private int curQuality = 0;
    private string[] txtColorArr = new string[] { "#209323", "#2c93e5", "#f45bfc", "#fb6eaa", "#f5b535", "#b579f5" };
    public SuitBookView(fun_Dress.suit_book_view ui)
    {
        view = ui;
        StringUtil.SetBtnTab(view.chose_btn, Lang.GetValue("guild_Match_3"));
        view.chose_grp.list.itemRenderer = RenderQualityList;
        view.list.itemRenderer = RenderList;
        view.list.SetVirtual();

        view.chose_btn.onClick.Add(() =>
        {
            if (view.showChose.selectedIndex == 1)
            {
                view.showChose.selectedIndex = 0;
            }
            else
            {
                view.showChose.selectedIndex = 1;
            }

        });
    }


    public void OnShown()
    {
        InitUI();
        DressModel.Instance.FilterBookData(curQuality);
        UpdataList();
    }
    private void UpdataList()
    {
        view.list.numItems = DressModel.Instance.dressHome.Count;
    }
    private void InitUI()
    {
        curQuality = 0;
        view.chose_grp.quality.selectedIndex = curQuality;
        InitQualityList();
        view.showChose.selectedIndex = 0;
    }
    private void InitQualityList()
    {
        view.chose_grp.list.numItems = 6;
        view.chose_grp.quality.selectedIndex = curQuality;
        StringUtil.SetBtnTab(view.chose_btn, curQuality == 0 ? Lang.GetValue("guild_Match_3") : Lang.GetValue("quality_" + curQuality));
    }
    private void RenderList(int idnex, GObject item)
    {
        var cell = item as fun_Dress.dress_book_item;
        var dressInfo = DressModel.Instance.dressHome[idnex];
        
        cell.nameLab.text = Lang.GetValue(dressInfo.Name);
        cell.nameLab.color = StringUtil.HexToColor(txtColorArr[dressInfo.Quality - 1]);
        cell.bg.url = "Dress/suit_quality_" + dressInfo.Quality + ".png";
        cell.rare_img.url = "HandBookNew/rare_icon_" + dressInfo.Quality + ".png";
        cell.pro.max = dressInfo.ContainDress.Length;
        cell.pro.value = dressInfo.HaveCount;
        cell.proLab.text = dressInfo.HaveCount + "/" + dressInfo.ContainDress.Length;
        cell.data = idnex;
        cell.onClick.Add(ClickItem);
    }
    private void ClickItem(EventContext context)
    {
        var index = (int)(context.sender as GComponent).data;
        UIManager.Instance.OpenPanel<DressInfoWindow>(UIName.DressInfoWindow, UILayer.UI, index);

    }
    private void RenderQualityList(int index, GObject item)
    {
        var cell = item as fun_Dress.chose_quality_item;
        if (index == 0)
        {
            cell.quality_img.url = "";
            cell.titileLab.text = Lang.GetValue("guild_Match_3");
        }
        else
        {
            cell.quality_img.url = "HandBookNew/rare_icon_" + index + ".png";
            cell.titileLab.text = Lang.GetValue("quality_" + index);
        }
        cell.data = index;
        cell.onClick.Add(ChoseQualityClick);
    }
    private void ChoseQualityClick(EventContext context)
    {
        int type = (int)(context.sender as GComponent).data;
        if (type != curQuality)
        {
            curQuality = type;
            view.chose_grp.quality.selectedIndex = curQuality;
            StringUtil.SetBtnTab(view.chose_btn, curQuality == 0 ? Lang.GetValue("guild_Match_3") : Lang.GetValue("quality_" + curQuality));
            view.showChose.selectedIndex = 0;
            DressModel.Instance.FilterBookData(curQuality);
            UpdataList();
        }
    }
    public void OnHide()
    {
        
    }
}

