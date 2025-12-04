using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlowerIkeVaseWindow : BaseWindow
{
   private fun_CultivationManual_new.flower_ike_vase view;

    private List<StaticFlowerPoint> dataList;

   public FlowerIkeVaseWindow()
    {
        packageName = "fun_CultivationManual_new";
        // 设置委托
        BindAllDelegate = fun_CultivationManual_new.fun_CultivationManual_newBinder.BindAll;
        CreateInstanceDelegate = fun_CultivationManual_new.flower_ike_vase.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_CultivationManual_new.flower_ike_vase;
        SetBg(view.bg, "Common/ELIDA_common_littledi01.png");
        view.list.itemRenderer = RenderList;
        view.list.SetVirtual();
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        var flowerId = (int)data;
        dataList = IkeModel.Instance.GetVaseByFowerId(flowerId);
        dataList.Sort(VaseListSort);
        view.list.numItems = dataList.Count;
    }

    private int VaseListSort(StaticFlowerPoint a, StaticFlowerPoint b)
    {
        if(IkeModel.Instance.IsUnlockVase(a.VaseId) && !IkeModel.Instance.IsUnlockVase(b.VaseId))
        {
            return -1;
        }else if(!IkeModel.Instance.IsUnlockVase(a.VaseId) && IkeModel.Instance.IsUnlockVase(b.VaseId))
        {
            return 1;
        }
        return 0;
    }

    private void RenderList(int index,GObject item)
    {
        var cell = item as fun_CultivationManual_new.show_vase_item;
        var vaseData = dataList[index];
        cell.img.url = ImageDataModel.Instance.GetVaseUrl(vaseData.VaseId);
        cell.status.selectedIndex = IkeModel.Instance.IsUnlockVase(vaseData.VaseId)?0:1;
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

