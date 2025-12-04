using Elida.Config;
using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 家具摆放弹窗
/// </summary>
public class FurnitureArrangementWindow : BaseWindow
{
    private fun_FlowerShop.FurnitureArrangementWindow view;
    private List<int> filterName1Types = new List<int>(9) { 3, 4, 2, 1, 5, 6, 7, 8 };
    private List<int> filterName2Types = new List<int>() { 9, 10, 11, 12, 13 };
    private List<Ft_florist_furnitureConfig> partItemList;
    private int type;
    private bool isConfirm = false;

    public FurnitureArrangementWindow()
    {
        packageName = "fun_FlowerShop";
        // 设置委托
        BindAllDelegate = fun_FlowerShop.fun_FlowerShopBinder.BindAll;
        CreateInstanceDelegate = fun_FlowerShop.FurnitureArrangementWindow.CreateInstance;
        showModal = false;
        IsShowOrHideMainUI = true;
        IsAddShowNum = false;
    }
    public override void OnInit()
    {
        base.OnInit();
        view = ui as fun_FlowerShop.FurnitureArrangementWindow;
        AddEvent();
        ADK.StringUtil.SetBtnTab2(view.btn_confirm, "确认");

        view.list_filter.itemRenderer = FilterItemRender;
        view.list_filter.onClickItem.Add(OnFilterItemClick);


        view.list_part.SetVirtual();
        view.list_part.itemRenderer = PartItemRender;
        view.list_part.onClickItem.Add(OnPartItemClick);
    }
    private void AddEvent()
    {
        view.btn_confirm.onClick.Add(OnConfirm);
    }

    private void OnConfirm()
    {
        isConfirm = true;
        Close();
        FlowerShopModel.Instance.isEditing = false;
    }

    public override void OnShown()
    {
        base.OnShown();
        isConfirm = false;
        type = (int)data;
        UpdateListFilter(true);
    }

    private void UpdateListFilter(bool isInit = false)
    {
        if (FlowerShopModel.Instance.floor == 0)
        {
            view.list_filter.numItems = filterName1Types.Count;
            if (isInit) view.list_filter.selectedIndex = filterName1Types.IndexOf(type);
        }
        else if (FlowerShopModel.Instance.floor == 1)
        {
            view.list_filter.numItems = filterName2Types.Count;
            if (isInit) view.list_filter.selectedIndex = filterName2Types.IndexOf(type);
        }
        if (!isInit) view.list_filter.selectedIndex = 0;
        UpdatePartList(view.list_filter.selectedIndex);
    }

    private void UpdatePartList(int part)
    {
        var type = -1;
        if (FlowerShopModel.Instance.floor == 0)
        {
            type = filterName1Types[part];
        }
        else if (FlowerShopModel.Instance.floor == 1)
        {
            type = filterName2Types[part];
        }
        partItemList = FlowerShopModel.Instance.GetGetFurnituresByType(type);
        partItemList = partItemList.FindAll(value => FlowerShopModel.Instance.HaveFurniture(value.Id));//过滤已拥有的
        view.list_part.numItems = partItemList.Count;
        view.txt_noDress.visible = partItemList.Count <= 0;
    }

    private void FilterItemRender(int index, GObject item)
    {
        fun_FlowerShop.FurnitureFilterBtn cell = item as fun_FlowerShop.FurnitureFilterBtn;
        if (FlowerShopModel.Instance.floor == 0)
        {
            cell.img_icon.url = "FlowerShop/PartIcon/" + index + ".png";
        }
        if (FlowerShopModel.Instance.floor == 1)
        {
            cell.img_icon.url = "FlowerShop/PartIcon/" + filterName2Types[index] + ".png";
        }
    }
    private void PartItemRender(int index, GObject item)
    {
        fun_FlowerShop.FurnitureItem cell = item as fun_FlowerShop.FurnitureItem;
        var data = partItemList[index];
        if (data != null)
        {
            cell.data = data;
            var itemConfig = ItemModel.Instance.GetItemById(data.Id);
            cell.img_icon.url = ImageDataModel.Instance.GetIconUrl(itemConfig);
            var quality = FlowerShopModel.Instance.GetFurniture(data.Id).Quality;
            cell.img_quality.url = $"MyInfo/show_flower_bg{quality}.png";
            var isUse = FlowerShopModel.Instance.CheckFurnitureIsUse(data.Id);
            if (isUse)
            {
                cell.txt_use.visible = true;
            }
            else
            {
                cell.txt_use.visible = false;
            }
        }
    }


    private void OnFilterItemClick(EventContext context)
    {
        var index = view.list_filter.selectedIndex;
        UpdatePartList(index);
    }

    private void OnPartItemClick(EventContext context)
    {
        object data = (context.data as GComponent).data;
        if (data is Ft_florist_furnitureConfig furnitureConfig)
        {
            var isUse = FlowerShopModel.Instance.CheckFurnitureIsUse(furnitureConfig.Id);
            if (!isUse)
            {
                FlowerShopController.Instance.ReqUseFurniture(furnitureConfig.Id);
                UpdatePartList(view.list_filter.selectedIndex);//重新再刷新一次
            }
        }
    }

    public override void OnHide()
    {
        base.OnHide();
        if (!isConfirm)
        {
            FlowerShopController.Instance.HideFurnitureArrangement();
        }
        else
        {
            FlowerShopController.Instance.ReqFloristDecoration();
        }
    }
}
