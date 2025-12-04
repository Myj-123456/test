
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class serYinSiWindow : BaseWindow
{
   private fun_MyInfo.yinsixieyi view;

   public serYinSiWindow()
    {
        packageName = "fun_MyInfo";
        // 设置委托
        BindAllDelegate = fun_MyInfo.fun_MyInfoBinder.BindAll;
        CreateInstanceDelegate = fun_MyInfo.yinsixieyi.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_MyInfo.yinsixieyi;
        SetBg(view.bg,"Common/ELIDA_common_bigdi01.png");
        view.title_txt.text = Lang.GetValue("text_yisi");//隐私条款
        view.list.itemRenderer = ItemRender;
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑

        int len = 0;
        while (Lang.CheckLangExists("text_yinsixieyi_" + len))
        {
            len++;
        }
        view.list.numItems = len;
    }

    private void ItemRender(int index, GObject item)
    {
        var itemCell = item as fun_MyInfo.txtListItem;
        itemCell.lb_content.text = Lang.GetValue("text_yinsixieyi_" + index);
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

