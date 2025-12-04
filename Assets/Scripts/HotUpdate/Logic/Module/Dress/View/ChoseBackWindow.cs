using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChoseBackWindow : BaseWindow
{
   private fun_Dress.chose_back_view view;

   public ChoseBackWindow()
    {
        packageName = "fun_Dress";
        // 设置委托
        BindAllDelegate = fun_Dress.fun_DressBinder.BindAll;
        CreateInstanceDelegate = fun_Dress.chose_back_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Dress.chose_back_view;
        SetBg(view.bg, "Common/ELIDA_common_littledi01.png");
        view.list.itemRenderer = RenderList;
        view.list.SetVirtual();
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        view.list.selectedIndex = 0;
        view.list.numItems = 4;
    }

    private void RenderList(int index,GObject item)
    {
        var cell = item as fun_Dress.chose_back_item;
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

