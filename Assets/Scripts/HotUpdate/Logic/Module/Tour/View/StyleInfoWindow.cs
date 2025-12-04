
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StyleInfoWindow : BaseWindow
{
   private fun_Tour_Land.style_info_view view;

   public StyleInfoWindow()
    {
        packageName = "fun_Tour_Land";
        // 设置委托
        BindAllDelegate = fun_Tour_Land.fun_Tour_LandBinder.BindAll;
        CreateInstanceDelegate = fun_Tour_Land.style_info_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Tour_Land.style_info_view;
        SetBg(view.bg, "Common/ELIDA_common_littledi01.png");
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        view.pareLab1.text = Lang.GetValue("battle_monster_12", ">=", "120%");
        view.effectLab1.text = Lang.GetValue("battle_monster_9");

        view.pareLab2.text = Lang.GetValue("battle_monster_12", ">=", "");
        view.effectLab2.text = Lang.GetValue("battle_monster_10");

        view.pareLab3.text = Lang.GetValue("battle_monster_12", "<", "");
        view.effectLab3.text = Lang.GetValue("battle_monster_11");

        view.pareLab4.text = Lang.GetValue("battle_monster_12", "<", "");
        view.effectLab4.text = Lang.GetValue("battle_monster_11");
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

