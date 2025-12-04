using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class NatureInfoWindow : BaseWindow
{
   private fun_FlowerGold.nature_info_view view;

   public NatureInfoWindow()
    {
        packageName = "fun_FlowerGold";
        // 设置委托
        BindAllDelegate = fun_FlowerGold.fun_FlowerGoldBinder.BindAll;
        CreateInstanceDelegate = fun_FlowerGold.nature_info_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_FlowerGold.nature_info_view;
        SetBg(view.bg, "Common/ELIDA_common_bigdi01.png");

        view.txt_base.text = Lang.GetValue("battle_monster_13");
        view.txt_battle.text = Lang.GetValue("battle_monster_14");
        view.txt_defene.text = Lang.GetValue("battle_monster_15");
        view.txt_special.text = Lang.GetValue("battle_monster_16");

        view.txt_attack.text = Lang.GetValue("player_attack");
        view.txt_hp.text = Lang.GetValue("player_hp");
        view.txt_def.text = Lang.GetValue("player_defense");
        view.txt_speed.text = Lang.GetValue("player_speed");

        view.txt_crit.text = Lang.GetValue("crit_name");
        view.txt_dodge.text = Lang.GetValue("dodge_name");
        view.txt_stun.text = Lang.GetValue("stun_name");
        view.txt_lifeSteal.text = Lang.GetValue("lifeSteal_name");
        view.txt_counter.text = Lang.GetValue("counter_name");
        view.txt_combo.text = Lang.GetValue("combo_name");

        view.txt_antiCrit.text = Lang.GetValue("antiCrit_name");
        view.txt_antiDodge.text = Lang.GetValue("antiDodge_name");
        view.txt_antiStun.text = Lang.GetValue("antiStun_name");
        view.txt_antiLifeSteal.text = Lang.GetValue("antiLifeSteal_name");
        view.txt_antiCounter.text = Lang.GetValue("antiCounter_name");

        view.txt_petUp.text = Lang.GetValue("petUp_name");
        view.txt_petDown.text = Lang.GetValue("petDown_name");
        view.txt_cureUp.text = Lang.GetValue("cureUp_name");
        view.txt_cureDown.text = Lang.GetValue("cureDown_name");
        view.txt_finalUp.text = Lang.GetValue("finalUp_name");
        view.txt_finalDown.text = Lang.GetValue("finalDown_name");
        view.txt_ignoreAttributes.text = Lang.GetValue("ignoreAttributes_name");
        view.txt_ignoreResistance.text = Lang.GetValue("ignoreResistance_name");
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        var attrs = FlowerGoldModel.Instance.GetFairyAttr();
        view.num_attack.text = (attrs.ContainsKey((int)PlayerAttr.Attack)? attrs[(int)PlayerAttr.Attack]:0).ToString();
        view.num_hp.text = (attrs.ContainsKey((int)PlayerAttr.Hp) ? attrs[(int)PlayerAttr.Hp] : 0).ToString();
        view.num_def.text = (attrs.ContainsKey((int)PlayerAttr.Defense) ? attrs[(int)PlayerAttr.Defense] : 0).ToString();
        view.num_speed.text = (attrs.ContainsKey((int)PlayerAttr.Speed) ? attrs[(int)PlayerAttr.Speed] : 0).ToString();

        

        view.num_crit.text = (attrs.ContainsKey((int)PlayerAttr.Crit) ? attrs[(int)PlayerAttr.Crit] : 0) + "%";
        view.num_dodge.text = (attrs.ContainsKey((int)PlayerAttr.Dodge) ? attrs[(int)PlayerAttr.Dodge] : 0) + "%";
        view.num_stun.text = (attrs.ContainsKey((int)PlayerAttr.Stun) ? attrs[(int)PlayerAttr.Stun] : 0) + "%";
        view.num_lifeSteal.text = (attrs.ContainsKey((int)PlayerAttr.LifeSteal) ? attrs[(int)PlayerAttr.LifeSteal] : 0) + "%";
        view.num_counter.text = (attrs.ContainsKey((int)PlayerAttr.Counter) ? attrs[(int)PlayerAttr.Counter] : 0) + "%";
        view.num_combo.text = (attrs.ContainsKey((int)PlayerAttr.Combo) ? attrs[(int)PlayerAttr.Combo] : 0) + "%";

        view.num_antiCrit.text = (attrs.ContainsKey((int)PlayerAttr.AntiCrit) ? attrs[(int)PlayerAttr.AntiCrit] : 0) + "%";
        view.num_antiDodge.text = (attrs.ContainsKey((int)PlayerAttr.AntiDodge) ? attrs[(int)PlayerAttr.AntiDodge] : 0) + "%";
        view.num_antiStun.text = (attrs.ContainsKey((int)PlayerAttr.AntiStun) ? attrs[(int)PlayerAttr.AntiStun] : 0) + "%";
        view.num_antiLifeSteal.text = (attrs.ContainsKey((int)PlayerAttr.AntiLifeSteal) ? attrs[(int)PlayerAttr.AntiLifeSteal] : 0) + "%";
        view.num_antiCounter.text = (attrs.ContainsKey((int)PlayerAttr.AntiCounter) ? attrs[(int)PlayerAttr.AntiCounter] : 0) + "%";

        view.num_petUp.text = (attrs.ContainsKey((int)PlayerAttr.PetUp) ? attrs[(int)PlayerAttr.PetUp] : 0) + "%";
        view.num_petDown.text = (attrs.ContainsKey((int)PlayerAttr.PetDown) ? attrs[(int)PlayerAttr.PetDown] : 0) + "%";
        view.num_cureUp.text = (attrs.ContainsKey((int)PlayerAttr.CureUp) ? attrs[(int)PlayerAttr.CureUp] : 0) + "%";
        view.num_cureDown.text = (attrs.ContainsKey((int)PlayerAttr.CureDown) ? attrs[(int)PlayerAttr.CureDown] : 0) + "%";
        view.num_finalUp.text = (attrs.ContainsKey((int)PlayerAttr.FinalUp) ? attrs[(int)PlayerAttr.FinalUp] : 0) + "%";
        view.num_finalDown.text = (attrs.ContainsKey((int)PlayerAttr.FinalDown) ? attrs[(int)PlayerAttr.FinalDown] : 0) + "%";
        view.num_ignoreAttributes.text = (attrs.ContainsKey((int)PlayerAttr.IgnoreAttributes) ? attrs[(int)PlayerAttr.IgnoreAttributes] : 0) + "%";
        view.num_ignoreResistance.text = (attrs.ContainsKey((int)PlayerAttr.IgnoreResistance) ? attrs[(int)PlayerAttr.IgnoreResistance] : 0) + "%";
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

