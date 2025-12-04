using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using System;

public class FlowerShareEditWindow : BaseWindow
{
   private fun_GuildFlowerShare.flowerShare_flowerLs _view;
    private List<SeedCropVO> _flowerLs;
    private List<SeedCropVO> _selectFlowerLs;
    private int _maxPage;
    private int lastPageX;
    public FlowerShareEditWindow()
    {
        packageName = "fun_GuildFlowerShare";
        // 设置委托
        BindAllDelegate = fun_GuildFlowerShare.fun_GuildFlowerShareBinder.BindAll;
        CreateInstanceDelegate = fun_GuildFlowerShare.flowerShare_flowerLs.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        _view = ui as fun_GuildFlowerShare.flowerShare_flowerLs;
        //_view.lb_tip.text = Lang.GetValue("Share_txt15");
        //_view.titleLab.text = Lang.GetValue("Share_txt14");
        //StringUtil.SetBtnTab(_view.btn_edit, Lang.GetValue("Share_txt16"));
        //_view.list.itemRenderer = FlowerItemRenderer;

        //_view.list.SetVirtual();

        //_view.btn_turn_left.onClick.Add(() =>
        //{
        //    _view.list.scrollPane.ScrollLeft(1, true);
        //});

        //_view.btn_turn_right.onClick.Add(() =>
        //{
        //    _view.list.scrollPane.ScrollRight(1, true);
        //});

        //_view.list.scrollPane.onScroll.Add(() =>
        //{
        //    UpdatePage();
        //});

        //_view.btn_edit.onClick.Add(() =>
        //{
        //    string flowerIds = _selectFlowerLs[0].flowerId.ToString();
        //    for(int i = 1;i < _selectFlowerLs.Count; i++)
        //    {
        //        flowerIds += "," + _selectFlowerLs[i].flowerId;
        //    }
        //    FlowerShareController.Instance.ReqGuidShareCollect(flowerIds);
        //    UIManager.Instance.CloseWindow(UIName.FlowerShareEditWindow);
        //});
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        //UpdateList();
    }

    //private void UpdateList()
    //{
    //    _flowerLs = StorageModel.Instance.seedList;
    //    _selectFlowerLs = FlowerShareModel.Instance.GetDefaultFlowerList();
    //    _view.list.numItems = _flowerLs.Count;
    //    _maxPage = (int)Math.Floor((double)_flowerLs.Count / 16);
    //    UpdatePage();
    //}

    //private void UpdatePage()
    //{
    //    //if(lastPageX != _view.list.scrollPane.currentPageX)
    //    //{
    //    //    lastPageX = _view.list.scrollPane.currentPageX;
    //    //}
    //    _view.lb_pageCount.text = (_view.list.scrollPane.currentPageX + 1) + "/" + (_maxPage + 1);
    //}

    //private void FlowerItemRenderer(int index,GObject item)
    //{
    //    var cell = item as fun_GuildFlowerShare.flowerShare_cell_3;
    //    var crop = _flowerLs[index];
    //    cell.img_flower.url = "";
    //    if(crop != null)
    //    {
    //        cell.img_flower.url = ImageDataModel.Instance.GetIconUrl(crop.item);
    //        cell.lb_level.text = crop.level.ToString();
    //        int count = StorageModel.Instance.GetItemCount(crop.item.ItemDefId);
    //        cell.lb_count.text = count.ToString();
    //        cell.status.selectedIndex = CheckIsSame(crop.flowerId) ? 1 : 0;
    //        cell.data = crop;
    //        cell.onClick.Add(FlowerClickHander);
            
    //    }
    //}

    //private void FlowerClickHander(EventContext context)
    //{
    //    var cell = context.sender as fun_GuildFlowerShare.flowerShare_cell_3;
    //    var crop = cell.data as SeedCropVO;
    //    if(cell.status.selectedIndex == 1)
    //    {
    //        cell.status.selectedIndex = 0;
    //        RemoveFlowerList(crop.flowerId);
    //        _view.list.RefreshVirtualList();
    //    }
    //    else
    //    {
    //        if(_selectFlowerLs.Count < FlowerShareModel.maxDefaultFlowerCount)
    //        {
    //            cell.status.selectedIndex = 1;
    //            _selectFlowerLs.Add(crop);
    //            _view.list.RefreshVirtualList();
    //        }
    //        else
    //        {
    //            UILogicUtils.ShowNotice(Lang.GetValue("Share_txt32"));
    //        }
    //    }
    //}

    //private void RemoveFlowerList(int flowerId)
    //{
    //    int len = _selectFlowerLs.Count;
    //    int index = -1;
    //    for(int i = 0;i < len; i++)
    //    {
    //        if(_selectFlowerLs[i].flowerId == flowerId)
    //        {
    //            index = i;
    //            break;
    //        }
    //    }
    //    if(index != -1)
    //    {
    //        _selectFlowerLs.RemoveAt(index);
    //    }
    //}

    //private bool CheckIsSame(int flowerId)
    //{
    //    foreach( var value in _selectFlowerLs)
    //    {
    //        if(value.flowerId == flowerId)
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

