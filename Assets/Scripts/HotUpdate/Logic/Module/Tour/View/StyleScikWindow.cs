
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Elida.Config;

public class StyleScikWindow : BaseWindow
{
   private fun_Tour_Land.style_sick_view view;
    private Ft_island_stageConfig cidData;

    public StyleScikWindow()
    {
        packageName = "fun_Tour_Land";
        // 设置委托
        BindAllDelegate = fun_Tour_Land.fun_Tour_LandBinder.BindAll;
        CreateInstanceDelegate = fun_Tour_Land.style_sick_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Tour_Land.style_sick_view;
        SetBg(view.bg, "Common/ELIDA_common_littledi01.png");
        view.styleLab.text = view.style1Lab.text = Lang.GetValue("battle_monster_3");
        view.effectLab.text = Lang.GetValue("battle_monster_8");

        view.detail_btn.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<StyleInfoWindow>(UIName.StyleInfoWindow);
        });
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        var id = (int)data;
        cidData = AdventureModel.Instance.GetIslandStageConfig(id);
        var styleArr = cidData.EnemyStyle.Split("#");
        var styleNum = int.Parse(styleArr[1]);
        var myStyle = PlayerModel.Instance.GetStyleValue(uint.Parse(styleArr[0]));
        view.style_my.url = view.style_monster.url = "HandBookNew/style_icon_" + styleArr[0] + ".png";
        view.style_num.text = myStyle.ToString();
        view.style_num.text = styleArr[1];
        view.nameLab.text = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_NICKNAME).info;
        var monsterData = AdventureModel.Instance.GetEnemyConfig(cidData.EnemyGroups[0]);
        view.monsterLab.text = Lang.GetValue(monsterData.Name);
        var target = (float)myStyle / (float)styleNum;
        if (target >= 1.2f)
        {
            view.emote.status.selectedIndex = 0;
            view.compareLab.text = Lang.GetValue("battle_monster_4");
            view.effectLab1.text = Lang.GetValue("battle_monster_9");
        }
        else if (target >= 1f)
        {
            view.emote.status.selectedIndex = 1;
            view.compareLab.text = Lang.GetValue("battle_monster_5");
            view.effectLab1.text = Lang.GetValue("battle_monster_10");
        }
        else if (target < 0.8f)
        {
            view.emote.status.selectedIndex = 3;
            view.compareLab.text = Lang.GetValue("battle_monster_7");
            view.effectLab1.text = Lang.GetValue("battle_monster_11");
        }
        else
        {
            view.emote.status.selectedIndex = 2;
            view.compareLab.text = Lang.GetValue("battle_monster_6");
            view.effectLab1.text = Lang.GetValue("battle_monster_11");
        }
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

