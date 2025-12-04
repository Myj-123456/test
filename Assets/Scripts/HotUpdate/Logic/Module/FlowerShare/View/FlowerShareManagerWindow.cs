using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class FlowerShareManagerWindow : BaseWindow
{
   private fun_GuildFlowerShare.flowerShare_manager _view;
    private List<SeedCropVO> _flowerLs;
   public FlowerShareManagerWindow()
    {
        packageName = "fun_GuildFlowerShare";
        // 设置委托
        BindAllDelegate = fun_GuildFlowerShare.fun_GuildFlowerShareBinder.BindAll;
        CreateInstanceDelegate = fun_GuildFlowerShare.flowerShare_manager.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        _view = ui as fun_GuildFlowerShare.flowerShare_manager;
        //_view.lb_tip.text = Lang.GetValue("Share_txt8");
        //_view.panel_flower.title.text = Lang.GetValue("Share_txt9");
        //_view.panel_flower.lb_tip.text = Lang.GetValue("Share_txt10");
        //_view.titleLab.text = Lang.GetValue("flower_arrangement_title");
        //_view.panel_desc.title.text = Lang.GetValue("Share_txt12");
        //_view.panel_desc.lb_info.text = Lang.GetValue("Share_txt13");

        //StringUtil.SetBtnTab(_view.panel_flower.btn_edit, Lang.GetValue("Share_txt11"));
        //_view.list.itemRenderer = ShareItemRenderer;

        //_view.panel_flower.flowerList.itemRenderer = FlowerItemRenderer;

        //_view.btn_logs.onClick.Add(() =>
        //{
        //    UIManager.Instance.OpenWindow<FlowerShareLogsWindow>(UIName.FlowerShareLogsWindow);
        //});

        //_view.panel_flower.btn_edit.onClick.Add(() =>
        //{
        //    UIManager.Instance.OpenWindow<FlowerShareEditWindow>(UIName.FlowerShareEditWindow);
        //});

        //_view.btn_turn_left.onClick.Add(ChangePage);
        //_view.btn_turn_right.onClick.Add(ChangePage);

        //EventManager.Instance.AddEventListener(FlowerShareEvent.GuildUnlockShareFlower, UpdateCellInfo);
        //EventManager.Instance.AddEventListener(FlowerShareEvent.GuildShareFlower, UpdateData);
        //EventManager.Instance.AddEventListener(FlowerShareEvent.GuidShareCollect, UpdateFlowerList);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        //UpdateCellInfo();
        //UpdateFlowerList();
    }

    //private void ChangePage()
    //{
    //    if(_view.status.selectedIndex == 0)
    //    {
    //        _view.status.selectedIndex = 1;
    //    }
    //    else
    //    {
    //        _view.status.selectedIndex = 0;
    //    }
    //}

    //private void UpdateData()
    //{
    //    UpdateCellInfo();
    //    UpdateFlowerList();
    //}

    //private void UpdateCellInfo()
    //{
    //    _view.list.numItems = 3;
    //    UpdateViewStatus();
    //}
    //private void UpdateFlowerList()
    //{
    //    _flowerLs = FlowerShareModel.Instance.GetDefaultFlowerList();
    //    _view.panel_flower.flowerList.numItems = _flowerLs.Count;
    //}

    //private void UpdateViewStatus()
    //{
    //    var flowers = FlowerShareModel.Instance.flowerShareInfos;
    //    int status = 1;
    //    foreach (var value in flowers)
    //    {
    //        if (value.flowerId == "0")
    //        {
    //            status = 0;
    //            break;
    //        }
    //    }
    //    _view.status.selectedIndex = status;
    //}

    //private void ShareItemRenderer(int index,GObject item)
    //{
    //    var cell = item as fun_GuildFlowerShare.flowerShare_cell_1;
    //    var shareInfo = FlowerShareModel.Instance.GetFlowerShareInfo((uint)index + 1);
    //    if(shareInfo != null)
    //    {
    //        cell.data = null;
    //        if (shareInfo.flowerId != "0" && shareInfo.flowerId != "")
    //        {
    //            if (TimeUtil.IsSameDayInt((int)shareInfo.shelfTime))
    //            {
    //                if(shareInfo.times >= FlowerShareModel.getFlowerMaxCount)
    //                {
    //                    cell.sellstatus.selectedIndex = 3;
    //                }
    //                else
    //                {
    //                    var itemVo = ItemModel.Instance.GetItemByEntityID(shareInfo.flowerId);
    //                    cell.img_flower.url = ImageDataModel.Instance.GetIconUrl(itemVo);
    //                    cell.sellstatus.selectedIndex = 0;
    //                    cell.lb_count.text = (uint.Parse(shareInfo.count) * (FlowerShareModel.getFlowerMaxCount - shareInfo.times)).ToString();
    //                }
    //            }
    //            else
    //            {
    //                cell.data = new object[] { 1, index };
    //                cell.sellstatus.selectedIndex = 4;
    //            }
    //        }
    //        else
    //        {
    //            cell.sellstatus.selectedIndex = 1;
    //        }
    //    }
    //    else
    //    {
    //        cell.data = new object[] {2,index};
    //        cell.sellstatus.selectedIndex = 2;
    //    }
    //    cell.onClick.Add(CellClickHander);
    //}

    //private void CellClickHander(EventContext context)
    //{
    //    var data = (context.sender as GComponent).data as object[];
    //    if(data != null)
    //    {
    //        int type = (int)data[0];
    //        if(type == 1)
    //        {
    //            int pos = (int)data[1] + 1;
    //            FlowerShareController.Instance.ReqGuildShareFlowerReward((uint)pos);
    //        }
    //        else
    //        {
    //            int pos = (int)data[1] + 1;
    //            if(pos > FlowerShareModel.Instance.flowerShareInfos.Count + 1)
    //            {
    //                UILogicUtils.ShowNotice(Lang.GetValue("Share_txt39"));
    //                return;
    //            }
    //            int needCount = 0;
    //            if(pos == 2)
    //            {
    //                needCount = FlowerShareModel.Instance.shareConfig.Box1;
    //            }
    //            else if(pos == 3)
    //            {
    //                needCount = FlowerShareModel.Instance.shareConfig.Box2;
    //            }
    //            if(MyselfModel.Instance.diamond < needCount)
    //            {
    //                UILogicUtils.ShowNotice(Lang.GetValue("common_hint_txt3"));
    //                return;
    //            }
    //            var param = new FlowerShareAlert(1, needCount, () =>
    //            {
    //                FlowerShareController.Instance.ReqGuildUnlockShareFlower((uint)pos);
    //            });
    //            UIManager.Instance.OpenWindow<FlowerShareAlertWindow>(UIName.FlowerShareAlertWindow, param);
    //        }
    //    }
    //}

    //private void FlowerItemRenderer(int index,GObject item)
    //{
    //    var cell = item as fun_GuildFlowerShare.flowerShare_cell_3;
    //    var crop = _flowerLs[index];
    //    if(crop != null)
    //    {
    //        cell.img_flower.url = ImageDataModel.Instance.GetIconUrl(crop.item);
    //        cell.lb_level.text = crop.level.ToString();
    //        int count = StorageModel.Instance.GetItemCount(crop.item.ItemDefId);
    //        cell.lb_count.text = count.ToString();
    //        cell.data = crop;
    //        if(count >= crop.level * 10)
    //        {
    //            cell.grayed = false;
    //        }
    //        else
    //        {
    //            cell.grayed = true;
    //        }
    //    }
    //    cell.onClick.Add(FlowerClickHander);
    //}

    //private void FlowerClickHander(EventContext context)
    //{
    //    var crop = (context.sender as GComponent).data as SeedCropVO;
    //    if(crop != null)
    //    {
    //        uint pos = FlowerShareModel.Instance.GetEmptyPostion();
    //        if(pos == 0)
    //        {
    //            UILogicUtils.ShowNotice(Lang.GetValue("Share_txt41"));
    //            return;
    //        }
    //        int count = StorageModel.Instance.GetItemCount(crop.item.ItemDefId);
    //        if (count < crop.level * 10)
    //        {
    //            UILogicUtils.ShowNotice(Lang.GetValue("Share_txt40"));
    //            return;
    //        }
    //        var param = new FlowerShareAlert(3, crop, () =>{
    //            FlowerShareController.Instance.ReqGuildShareFlower(pos, (uint)crop.flowerId);
    //        });
    //        UIManager.Instance.OpenWindow<FlowerShareAlertWindow>(UIName.FlowerShareAlertWindow, param);
    //    }
    //}

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

