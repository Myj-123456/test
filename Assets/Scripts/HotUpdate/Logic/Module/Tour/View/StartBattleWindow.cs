
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using Elida.Config;

public class StartBattleWindow : BaseWindow
{
    private fun_Tour_Land.start_battle_view view;
    private Ft_island_stageConfig cidData;
    private StageRewardObject[] listData;
    private int objectId;
    public StartBattleWindow()
    {
        packageName = "fun_Tour_Land";
        // 设置委托
        BindAllDelegate = fun_Tour_Land.fun_Tour_LandBinder.BindAll;
        CreateInstanceDelegate = fun_Tour_Land.start_battle_view.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        view = ui as fun_Tour_Land.start_battle_view;
        SetBg(view.bg, "Tour/ELIDA_yunzhonghuayu_zhandou_bg01.png");
        SetBg(view.bg1, "Tour/ELIDA_yunzhonghuayu_zhandou_bg02.png");
        SetBg(view.bg2, "Tour/ELIDA_yunzhonghuayu_zhandou_bg03.png");
        view.monster_info_txt.text = Lang.GetValue("battle_monster_1");
        view.titleLab.text = Lang.GetValue("battle_monster_2") + Lang.GetValue("common_rewards_txt");
        view.powerLab.text = Lang.GetValue("power_name");
        StringUtil.SetBtnTab(view.battle_btn, Lang.GetValue("battle_monster_2"));

        view.list.itemRenderer = RenderList;
        view.list.SetVirtual();

        view.battle_btn.onClick.Add(() =>
        {
            Close();
            //BattleController.Instance.ReqPveBattleStart(objectId);
            //if (objectId == 156 || objectId == 157)//pve
            //{
            //    BattleController.Instance.ReqPveBattleStart(165);//写死165
            //}
            //if (objectId == 158)//pve
            //{
            //    BattleController.Instance.ReqPveBattleStart(158);//写死165
            //}
            //else if (objectId == 165)//pvp
            //{
            //    BattleController.Instance.ReqPvpBattleStart();//写死165
            //}
            BattleController.Instance.ReqPveBattleStart((ulong)objectId);//写死165

        });
        view.detail_btn.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<MonsterInfoWindow>(UIName.MonsterInfoWindow, cidData.Id);
        });
        view.emote_btn.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<StyleScikWindow>(UIName.StyleScikWindow, cidData.Id);
        });
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        objectId = (int)data;
        var gridConfig = AdventureModel.Instance.GetGridConfig(objectId);
        cidData = AdventureModel.Instance.GetIslandStageConfig(int.Parse(gridConfig.ClearReward));
        view.powerNum.text = TextUtil.ChangeCoinShow(cidData.EnemyPower);
        var monsterData = AdventureModel.Instance.GetEnemyConfig(cidData.EnemyGroups[0]);
        view.nameLab.text = Lang.GetValue(monsterData.Name);
        view.decLab.text = Lang.GetValue(monsterData.Desc);
        listData = cidData.StageRewards;
        view.list.numItems = listData.Length;

        var styleArr = cidData.EnemyStyle.Split("#");
        var styleNum = int.Parse(styleArr[1]);
        var myStyle = PlayerModel.Instance.GetStyleValue(uint.Parse(styleArr[0]));
        var target = (float)myStyle / (float)styleNum;

        view.spine.url = "enemy/" + monsterData.SpineName;
        view.spine.loop = true;
        view.spine.animationName = "idle";

        if (target >= 1.2f)
        {
            view.emote_btn.status.selectedIndex = 0;
        }
        else if (target >= 1f)
        {
            view.emote_btn.status.selectedIndex = 1;
        }
        else if (target < 0.8f)
        {
            view.emote_btn.status.selectedIndex = 3;
        }
        else
        {
            view.emote_btn.status.selectedIndex = 2;
        }
    }

    private void RenderList(int index, GObject item)
    {
        var cell = item as fun_Tour_Land.tour_reward_item;
        var reward = listData[index];
        var itemVo = ItemModel.Instance.GetItemByEntityID(reward.EntityID);
        cell.icon.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        cell.numLab.text = TextUtil.ChangeCoinShow(reward.Value);
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

