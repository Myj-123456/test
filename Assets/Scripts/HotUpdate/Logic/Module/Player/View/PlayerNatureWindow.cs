
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerNatureWindow : BaseWindow
{
   private fun_Player.player_nature_view view;

   public PlayerNatureWindow()
    {
        packageName = "fun_Player";
        // 设置委托
        BindAllDelegate = fun_Player.fun_PlayerBinder.BindAll;
        CreateInstanceDelegate = fun_Player.player_nature_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Player.player_nature_view;
        view.titleLab.text = Lang.GetValue("player_info_5") + Lang.GetValue("details_title");
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
        var attrs = PlayerModel.Instance.fightAttr;
        view.num_attack.text = attrs.attack.ToString();
        view.num_hp.text = attrs.health.ToString();
        view.num_def.text = attrs.defense.ToString();
        view.num_speed.text = attrs.speed.ToString();



        view.num_crit.text = attrs.critRate + "%";
        view.num_dodge.text = attrs.dodgeRate + "%";
        view.num_stun.text = attrs.stunRate + "%";
        view.num_lifeSteal.text = attrs.lifestealPer + "%";
        view.num_counter.text = attrs.reflectPer + "%";
        view.num_combo.text = attrs.chaseRate + "%";

        view.num_antiCrit.text = attrs.critResistanceRate + "%";
        view.num_antiDodge.text = attrs.dodgeResistanceRate + "%";
        view.num_antiStun.text = attrs.stuneResistanceRate + "%";
        view.num_antiLifeSteal.text = attrs.lifestealResistancePer + "%";
        view.num_antiCounter.text = attrs.reflectResistancePer + "%";

        view.num_petUp.text = attrs.finalPetIncreasePer + "%";
        view.num_petDown.text = attrs.finalPetDecreasePer + "%";
        view.num_cureUp.text = attrs.finalHealPer + "%";
        view.num_cureDown.text = attrs.finalHealResistancePer + "%";
        view.num_finalUp.text = attrs.finalIncreaseDamagePer + "%";
        view.num_finalDown.text = attrs.finalDefensePer + "%";
        view.num_ignoreAttributes.text = attrs.innoreRate + "%";
        view.num_ignoreResistance.text = attrs.innoreResistanceRate + "%";
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

