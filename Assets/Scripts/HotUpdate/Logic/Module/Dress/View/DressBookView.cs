using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class DressBookView
{
   private fun_Dress.dress_book_view view;
   private int curQuality = 0;
    private int typeDress = 0;

    private string[] txtColorArr = new string[] { "#209323", "#2c93e5", "#f45bfc", "#fb6eaa", "#f5b535", "#b579f5" };
    public DressBookView(fun_Dress.dress_book_view ui)
    {
        view = ui;
        
        StringUtil.SetBtnTab(view.chose_btn, Lang.GetValue("guild_Match_3"));
        view.list.itemRenderer = RenderList;
        view.list.SetVirtual();

        view.chose_grp.list.itemRenderer = RenderQualityList;

        view.list_filter.itemRenderer = FilterItemRender;
        view.list_filter.onClickItem.Add(OnFilterItemClick);
        view.list_filter.numItems = 8;

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
        DressModel.Instance.FilterBookData1(typeDress, curQuality);
        UpdataList();
    }

    private void InitUI()
    {
        curQuality = 0;
        typeDress = 0;
        view.chose_grp.quality.selectedIndex = curQuality;
        view.list_filter.selectedIndex = typeDress;
        InitQualityList();
        view.showChose.selectedIndex = 0;
    }
    private void InitQualityList()
    {
        view.chose_grp.list.numItems = 6;
        view.chose_grp.quality.selectedIndex = curQuality;
        StringUtil.SetBtnTab(view.chose_btn, curQuality == 0 ? Lang.GetValue("guild_Match_3") : Lang.GetValue("quality_" + curQuality));
    }

    private void UpdataList()
    {
        view.list.numItems = DressModel.Instance.suitDressHome.Count;
    }

    private void RenderList(int idnex,GObject item)
    {
        var cell = item as fun_Dress.dress_book_item1;
        var dressInfo = DressModel.Instance.suitDressHome[idnex];
        var ItemVo = ItemModel.Instance.GetItemById(dressInfo.ClothesId);
        cell.nameLab.text = Lang.GetValue(ItemVo.Name);
        cell.nameLab.color = StringUtil.HexToColor(txtColorArr[dressInfo.Quality - 1]);
        cell.bg.url = "Dress/dress_quality_" + dressInfo.Quality + ".png";
        cell.pic.url = ImageDataModel.Instance.GetIconUrl(ItemVo);
        cell.data = idnex;
        cell.onClick.Add(ClickItem);
    }
    private void ClickItem(EventContext context)
    {
        var index = (int)(context.sender as GComponent).data;
        var dressInfo = DressModel.Instance.suitDressHome[index];
        UIManager.Instance.OpenWindow<DressDetailWindow>(UIName.DressDetailWindow, dressInfo.ClothesId);

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
            view.chose_grp.quality.selectedIndex =  curQuality;
            StringUtil.SetBtnTab(view.chose_btn, curQuality == 0 ? Lang.GetValue("guild_Match_3") : Lang.GetValue("quality_" + curQuality));
            view.showChose.selectedIndex = 0;
            DressModel.Instance.FilterBookData1(typeDress, curQuality);
            UpdataList();
        }
    }

    private void FilterItemRender(int index, GObject item)
    {
        fun_Dress.DressFilterBtn cell = item as fun_Dress.DressFilterBtn;
        cell.img_icon.url = "Dress/PartIcon/" + index + ".png";
    }
    private void OnFilterItemClick(EventContext context)
    {
        var index = view.list_filter.selectedIndex;
        if(index != typeDress)
        {
            typeDress = index;
            DressModel.Instance.FilterBookData1(typeDress, curQuality);
            UpdataList();
        }
    }
}

