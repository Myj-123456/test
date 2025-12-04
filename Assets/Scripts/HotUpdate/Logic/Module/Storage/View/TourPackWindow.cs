
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TourPackWindow : BaseWindow
{
   private fun_Warehouse.tour_backpack view;
    private List<StorageItemVO> listData;
   public TourPackWindow()
    {
        packageName = "fun_Warehouse";
        // 设置委托
        BindAllDelegate = fun_Warehouse.fun_WarehouseBinder.BindAll;
        CreateInstanceDelegate = fun_Warehouse.tour_backpack.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Warehouse.tour_backpack;
        SetBg(view.bg, "Common/ELIDA_common_bigdi01.png");
        view.tipLab.text = Lang.GetValue("tour_pack_1");

        view.list.itemRenderer = RenderList;
        view.list.SetVirtual();
    }

    public override void OnShown()     
    {
        base.OnShown();
        // 其他打开面板的逻辑
        
        listData = AdventureModel.Instance.GetPackReward((uint)AdventureModel.Instance.curMapId);
        view.list.numItems = listData.Count;
    }

    private void RenderList(int index,GObject item)
    {
        var cell = item as fun_Warehouse.tour_backpack_item;
        var itemInfo = listData[index];
        cell.icon.url = ImageDataModel.Instance.GetIconUrl(itemInfo.item);
        cell.nameLab.text = Lang.GetValue(itemInfo.item.Name);
        cell.numLab.text = itemInfo.count.ToString();

    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

