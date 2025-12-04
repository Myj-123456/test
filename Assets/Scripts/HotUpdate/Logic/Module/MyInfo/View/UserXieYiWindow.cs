
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserXieYiWindow : BaseWindow
{
    private fun_MyInfo.yonghuxieyi view;

    public UserXieYiWindow()
    {
        packageName = "fun_MyInfo";
        // 设置委托
        BindAllDelegate = fun_MyInfo.fun_MyInfoBinder.BindAll;
        CreateInstanceDelegate = fun_MyInfo.yonghuxieyi.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        view = ui as fun_MyInfo.yonghuxieyi;
        SetBg(view.bg, "Common/ELIDA_common_bigdi01.png");
        view.title_txt.text = Lang.GetValue("text_user_xiyi");
        view.list.itemRenderer = ItemRender;
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        int len = 0;
        while (Lang.CheckLangExists("text_yonghuxieyi_" + len))
        {
            len++;
        }
        view.list.numItems = len;
    }

    private void ItemRender(int index, GObject item)
    {
        var itemCell = item as fun_MyInfo.txtListItem;
        itemCell.lb_content.text = Lang.GetValue("text_yonghuxieyi_" + index);
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

