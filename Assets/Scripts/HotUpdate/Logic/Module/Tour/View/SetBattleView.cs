
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class SetBattleView : BaseView
{
   private fun_Tour_Land.into_battle view;

   public SetBattleView()
    {
        packageName = "fun_Tour_Land";
        // 设置委托
        BindAllDelegate = fun_Tour_Land.fun_Tour_LandBinder.BindAll;
        CreateInstanceDelegate = fun_Tour_Land.into_battle.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Tour_Land.into_battle;
        SetBg(view.bg, "Player/ELIDA_huibi_bg.jpg");
        view.titleLab.text = Lang.GetValue("into_battle_1");
        StringUtil.SetBtnTab(view.pet_btn, Lang.GetValue("into_battle_2"));
        StringUtil.SetBtnTab(view.flower_god_btn, Lang.GetValue("into_battle_3"));
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

