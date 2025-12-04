
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterInfoWindow : BaseWindow
{
   private fun_Tour_Land.monster_info_view view;

   public MonsterInfoWindow()
    {
        packageName = "fun_Tour_Land";
        // 设置委托
        BindAllDelegate = fun_Tour_Land.fun_Tour_LandBinder.BindAll;
        CreateInstanceDelegate = fun_Tour_Land.monster_info_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Tour_Land.monster_info_view;
        SetBg(view.bg, "Common/ELIDA_common_bigdi01.png");
        view.powerLab.text = Lang.GetValue("power_name");
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
        var id = (int)data;
        var cidData = AdventureModel.Instance.GetIslandStageConfig(id);
        var monsterData = AdventureModel.Instance.GetEnemyConfig(cidData.EnemyGroups[0]);
        var monsterAttr = AdventureModel.Instance.GetEnemyAtt(monsterData.AttId);
        view.powerNum.text = TextUtil.ChangeCoinShow(cidData.EnemyPower);
        view.num_attack.text = monsterAttr.Attack.ToString();
        view.num_hp.text = monsterAttr.Hp.ToString();
        view.num_def.text = monsterAttr.Def.ToString();
        view.num_speed.text = cidData.Speed.ToString();

        view.num_crit.text = monsterAttr.Crit.ToString() + "%";
        view.num_dodge.text = monsterAttr.Dodge.ToString() + "%";
        view.num_stun.text = monsterAttr.Stun.ToString() + "%";
        view.num_lifeSteal.text = monsterAttr.LifeSteal.ToString() + "%";
        view.num_counter.text = monsterAttr.Counter.ToString() + "%";
        view.num_combo.text = monsterAttr.Combo.ToString() + "%";

        view.num_antiCrit.text = monsterAttr.AntiCrit.ToString() + "%";
        view.num_antiDodge.text = monsterAttr.AntiDodge.ToString() + "%";
        view.num_antiStun.text = monsterAttr.AntiStun.ToString() + "%";
        view.num_antiLifeSteal.text = monsterAttr.AntiLifeSteal.ToString() + "%";
        view.num_antiCounter.text = monsterAttr.AntiCounter.ToString() + "%";

        view.num_petUp.text = monsterAttr.PetUp.ToString() + "%";
        view.num_petDown.text = monsterAttr.PetDown.ToString() + "%";
        view.num_cureUp.text = monsterAttr.CureUp.ToString() + "%";
        view.num_cureDown.text = monsterAttr.CureDown.ToString() + "%";
        view.num_finalUp.text = monsterAttr.FinalUp.ToString() + "%";
        view.num_finalDown.text = monsterAttr.FinalDown.ToString() + "%";
        view.num_ignoreAttributes.text = monsterAttr.IgnoreAttributes.ToString() + "%";
        view.num_ignoreResistance.text = monsterAttr.IgnoreResistance.ToString() + "%";
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

