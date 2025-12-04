using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using System;
using Elida.Config;
using ADK;

public class VaseHandbookView
{
    private fun_CultivationManual_new.vasePanel _view;

    private int _spotMaxPage = 0;

    private float SPOT_PER_PAGE = 10;

    private int _maxPage;

    private int _lastSpotPage = 0;

    private int had = 0;
    private string name = "";
    private int color = 0;

    private string[] txtColorArr = new string[] { "#209323", "#2c93e5", "#f45bfc", "#fb6eaa", "#f5b535", "#b579f5" };
    public VaseHandbookView(fun_CultivationManual_new.vasePanel view)
    {
        _view = view;
        _view.vaseList.itemRenderer = ItemRenderer;
        _view.vaseList.SetVirtual();

        _view.vaseList.onClickItem.Add((EventContext context) =>
        {
            int index = (int)(context.data as GComponent).data;
            UIManager.Instance.OpenPanel<VaseTipView>(UIName.VaseTipView, UILayer.UI, index);
        });

        _view.vase_page_list.itemRenderer = PageNumItemRenderer;

        _view.vaseLeftBtn.onClick.Add(SpotLeft);
        _view.vaseRightBtn.onClick.Add(SpotRight);

        _view.vaseList.scrollPane.onScroll.Add(() =>
        {
            UpdatePage();
        });

        //_view.vase_page_list.onClickItem.Add(ChangePage);

        _view.vase_page_list.scrollPane.onScrollEnd.Add(() =>
        {
            if(_lastSpotPage != _view.vase_page_list.scrollPane.currentPageX)
            {
                _lastSpotPage = _view.vase_page_list.scrollPane.currentPageX;
                RenderSpotList();
            }
        });

        EventManager.Instance.AddEventListener(FlowerHandBookEvent.VaseRewardInfo, UpdateData);
        EventManager.Instance.AddEventListener(FlowerHandBookEvent.VaseOnekeyReward, UpdateData);
        EventManager.Instance.AddEventListener(FlowerHandBookEvent.VaseFlowerReward, UpdateData);
        EventManager.Instance.AddEventListener(FlowerHandBookEvent.VaseGatherReward, UpdateData);
    }

    //private void ChangePage(EventContext context)
    //{
    //    int numIndex = (int)(context.data as common.PageListItem_new1).data;
    //    _view.vaseList.scrollPane.SetCurrentPageX(numIndex, false);
    //}

    private void ChangePage(EventContext context)
    {
        int numIndex = (int)(context.sender as GLoader).parent.data;
        _view.vaseList.scrollPane.SetCurrentPageX(numIndex, false);
    }

    public void UpdateHandbookByFilter(int had = 0,string name = "",int color = 0)
    {
        this.had = had;
        this.name = name;
        this.color = color;
        UpdateData();
    }
    
    private void UpdateData()
    {
        UpdateSelectInfo(had, name, color);
        SpotCurrent();
        _view.vaseList.scrollPane.currentPageX = 0;
    }

    private void UpdateSelectInfo(int had = 0, string name = "", int color = 0)
    {
        IkeModel.Instance.vaseFilterList(had, name, color);
        int vaseNum = IkeModel.Instance.bookDatHome.Count;
        _maxPage = (int)Mathf.Ceil(vaseNum / FlowerHandbookModel.ITEM_COUNT_PER_SPOT);
        _view.vaseList.numItems = vaseNum;
        _spotMaxPage = (int)Mathf.Ceil(_maxPage / SPOT_PER_PAGE);
        _view.vase_page_list.numItems = _maxPage;
        RenderSpotList();
    }

    private void ItemRenderer(int index, GObject item)
    {
        fun_CultivationManual_new.handbook_VaseItem cell = item as fun_CultivationManual_new.handbook_VaseItem;
        StaticFlowerPoint data = IkeModel.Instance.bookDatHome[index];
        cell.data = index;
        cell.bg.url = "HandBookNew/bg_new_" + data.VaseQuality + ".png";
        int vaseId = data.VaseId;
        cell.img1.url = ImageDataModel.Instance.GetVaseUrl(vaseId);
        Module_item_defConfig itemData = ItemModel.Instance.GetItemById(vaseId);
        cell.name_txt.text = Lang.GetValue(itemData.Name);
        cell.name_txt.color = StringUtil.HexToColor(txtColorArr[data.VaseQuality - 1]);
        ChangeItemStatus(vaseId, cell);
    }

    private void ChangeItemStatus(int vaseId, fun_CultivationManual_new.handbook_VaseItem cell)
    {
        bool unlock = IkeModel.Instance.IsUnlockVase(vaseId);
        if(unlock)
        {
            cell.unlockStatus.selectedIndex = 1;
            //if (IkeModel.Instance.IsCanGetVaseReward(vaseId))
            //{
            //    cell.rewardStatus.selectedIndex = 1;
            //}else if (IkeModel.Instance.IsAllGetted(vaseId))
            //{
            //    cell.rewardStatus.selectedIndex = 2;
            //}
            //else
            //{
            //    cell.rewardStatus.selectedIndex = 0;
            //}
            cell.rewardStatus.selectedIndex = 0;
            cell.process_txt.text = IkeModel.Instance.HasFlowerDesc(vaseId);
        }
        else
        {
            cell.unlockStatus.selectedIndex = 0;
            cell.rewardStatus.selectedIndex = 0;
        }
       
    }

    private void PageNumItemRenderer(int index, GObject item)
    {
        item.data = index;
        var cell = item as common_New.PageListItem_new1;
        cell.n5.onClick.Add(ChangePage);
    }

    private void SpotLeft()
    {
        if (_view.vase_page_list.scrollPane.currentPageX <= 0)
        {
            return;
        }
        _view.vase_page_list.scrollPane.SetCurrentPageX(_view.vase_page_list.scrollPane.currentPageX - 1, true);
    }

    private void SpotRight()
    {
        if (_view.vase_page_list.scrollPane.currentPageX >= _spotMaxPage - 1)
        {
            return;
        }
        _view.vase_page_list.scrollPane.SetCurrentPageX(_view.vase_page_list.scrollPane.currentPageX + 1, true);
    }

    private void SpotCurrent()
    {
        for(int i = 0;i < _view.vase_page_list.numItems; i++)
        {
            common_New.PageListItem_new1 cell = _view.vase_page_list.GetChildAt(_view.vase_page_list.ItemIndexToChildIndex(i)) as common_New.PageListItem_new1;
            cell.status.selectedIndex = i == _view.vaseList.scrollPane.currentPageX ? 1 : 0;
        }
    }

    private void ScrollToPage(int page)
    {
        _view.vase_page_list.scrollPane.SetCurrentPageX((int)Mathf.Floor(page / SPOT_PER_PAGE), false);
        RenderSpotList();
    }

    private void RenderSpotList()
    {
        _view.vaseLeftBtn.alpha = _view.vase_page_list.scrollPane.currentPageX > 0 ? 1f : 0.5f;
        _view.vaseRightBtn.alpha = _view.vase_page_list.scrollPane.currentPageX < _spotMaxPage - 1 ? 1f : 0.5f;
    }

    private void UpdatePage()
    {
        SpotCurrent();
        ScrollToPage(_view.vaseList.scrollPane.currentPageX);
    }

}
