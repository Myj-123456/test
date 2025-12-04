using ADK;
using FairyGUI;
using protobuf.fight;
using protobuf.login;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 战斗主界面
/// </summary>
public class BattleView : BaseWindow
{
    private fun_Battle.BattleView view;
    private List<uint> myFlowerFairiesList;
    private List<uint> otherFlowerFairiesList;
    private List<FightHeroUnit> heroCamps = new List<FightHeroUnit>();//主角阵容
    private Dictionary<int, FightPetUnit> petMyCamps = new Dictionary<int, FightPetUnit>();//我方宠物列表
    private Dictionary<int, FightPetUnit> petOtherCamps = new Dictionary<int, FightPetUnit>();//对方宠物列表
    private List<FightEnemyUnit> petEnemyCamps = new List<FightEnemyUnit>();//对方敌人列表(pve专用)
    private Dictionary<int, fun_Battle.FlowerFairiesItem> myFlowerFairies = new Dictionary<int, fun_Battle.FlowerFairiesItem>();
    private Dictionary<int, fun_Battle.FlowerFairiesItem> otherFlowerFairies = new Dictionary<int, fun_Battle.FlowerFairiesItem>();
    private BattlePlayer battlePlayer;
    private I_BATTLE_PLAYER_VO myPlayerVo;
    private I_BATTLE_PLAYER_VO enemyPlayerVo;
    public BattleView()
    {
        packageName = "fun_Battle";
        // 设置委托
        BindAllDelegate = fun_Battle.fun_BattleBinder.BindAll;
        CreateInstanceDelegate = fun_Battle.BattleView.CreateInstance;
        openWithTween = false;
    }

    public override void OnInit()
    {
        base.OnInit();
        view = ui as fun_Battle.BattleView;
        UpdateBtnSpeed();
        StringUtil.SetBtnTab2(view.btn_back, "返回");
        AddEvent();
    }

    private void AddEvent()
    {
        AddEventListener<ulong>(BattleEvent.UpdateRound, UpdateRound);
        AddEventListener<uint>(BattleEvent.ChangeTimeScale, SpeedUp);
        view.btn_speedUp.onClick.Add(OnSpeedUp);
        view.btn_back.onClick.Add(OnBack);
        view.txt_skip.onClick.Add(OnSkip);
    }

    public override void OnShown()
    {
        base.OnShown();
        view.c1.selectedIndex = BattleModel.Instance.isPve ? 1 : 0;
        view.n23.visible = false;
        InitCamp();
        UpdateRound(1);
        UpdateFlowerFairies();
        InitBattlePlayer();
        TweenScene();
        StartCoroutine(StartPlay());
    }

    /// <summary>
    /// 场景层缓动
    /// </summary>
    private void TweenScene()
    {
        var time = 0.5f;
        var scale = 0.85f;
        view.bg.map.scale = new Vector2(scale, scale);
        view.bg.map.TweenScale(Vector2.one, time);

        view.myHero.scale = new Vector2(scale, scale);
        view.myHero.TweenScale(Vector2.one, time);

        view.otherHero.scale = new Vector2(scale, scale);
        view.otherHero.TweenScale(Vector2.one, time);

        view.myPet0.scale = new Vector2(scale, scale);
        view.myPet0.TweenScale(Vector2.one, time);

        view.myPet1.scale = new Vector2(scale, scale);
        view.myPet1.TweenScale(Vector2.one, time);

        view.otherPet0.scale = new Vector2(scale, scale);
        view.otherPet0.TweenScale(Vector2.one, time);

        view.otherPet1.scale = new Vector2(scale, scale);
        view.otherPet1.TweenScale(Vector2.one, time);

        view.enemy0.scale = new Vector2(scale, scale);
        view.enemy0.TweenScale(Vector2.one, time);

        view.enemy1.scale = new Vector2(scale, scale);
        view.enemy1.TweenScale(Vector2.one, time);

        view.enemy2.scale = new Vector2(scale, scale);
        view.enemy2.TweenScale(Vector2.one, time);

        view.fairyGroup.alpha = 0;
        view.fairyGroup.TweenFade(1, time);
    }

    private void InitCamp()
    {
        myPlayerVo = BattleModel.Instance.myPlayerVo;
        enemyPlayerVo = BattleModel.Instance.enemyPlayerVo;
        InitHeroCamp();
        InitPetCamp();
    }

    private void InitHeroCamp()
    {
        //创建主角阵容
        heroCamps.Clear();

        view.myHero.visible = view.otherHero.visible = false;

        FightHeroUnit myHero = new FightHeroUnit();
        myHero.fightUnitId = 0;
        myHero.Init(view.myHero, true, myPlayerVo);
        view.myHero.visible = true;
        heroCamps.Add(myHero);

        if (!BattleModel.Instance.isPve)////pvp才创建对方主角
        {
            FightHeroUnit otherHero = new FightHeroUnit();
            otherHero.fightUnitId = 1;
            otherHero.Init(view.otherHero, false, enemyPlayerVo);
            view.otherHero.visible = true;
            heroCamps.Add(otherHero);
        }
    }

    private Vector2 oneOrgPos = Vector2.zero;
    private void InitPetCamp()
    {
        petMyCamps.Clear();
        petOtherCamps.Clear();
        petEnemyCamps.Clear();
        view.myPet0.visible = view.myPet1.visible = view.otherPet0.visible = view.otherPet1.visible = false;
        view.enemy0.visible = view.enemy1.visible = view.enemy2.visible = false;
        //我方
        var myPetIds = myPlayerVo.battlePetIds;
        var pos = -1;//站位
        if (myPetIds != null && myPetIds.Length > 0)
        {
            foreach (var myPetId in myPetIds)
            {
                pos += 1;
                if (myPetId == 0)//0代表没有宠物
                {
                    continue;
                }
                FightPetUnit fightPetUnit = new FightPetUnit();
                var petUnit = view.GetChild("myPet" + pos) as fun_Battle.FightPetUnit;
                petUnit.visible = true;
                fightPetUnit.fightUnitId = myPetId;
                fightPetUnit.Init(petUnit, true, myPetId);
                petMyCamps[pos] = fightPetUnit;//对应槽位
            }
        }

        if (!BattleModel.Instance.isPve)//pvp才创建对方宠物阵容
        {
            //对方
            var otherPetIds = enemyPlayerVo.battlePetIds;
            if (otherPetIds != null && otherPetIds.Length > 0)
            {
                pos = -1;//站位
                foreach (var otherPetId in otherPetIds)
                {
                    pos += 1;
                    if (otherPetId == 0)//0代表没有宠物
                    {
                        continue;
                    }
                    FightPetUnit fightPetUnit = new FightPetUnit();
                    var petUnit = view.GetChild("otherPet" + pos) as fun_Battle.FightPetUnit;
                    petUnit.visible = true;
                    fightPetUnit.fightUnitId = otherPetId;
                    fightPetUnit.Init(petUnit, false, otherPetId);
                    petOtherCamps[pos] = fightPetUnit;//对应槽位
                }
            }
        }
        else//pve前端根据配置去初始化敌人怪物
        {
            var gridConfig = AdventureModel.Instance.GetGridConfig(BattleModel.Instance.islandStage);
            if (gridConfig != null)
            {
                var ft_island_stageConfig = AdventureModel.Instance.GetIslandStageConfig(int.Parse(gridConfig.ClearReward));
                if (ft_island_stageConfig != null)
                {
                    //对方
                    var otherPetIds = ft_island_stageConfig.EnemyGroups;
                    var one = view.GetChild("enemy" + 0) as fun_Battle.FightEnemyUnit;
                    var two = view.GetChild("enemy" + 1) as fun_Battle.FightEnemyUnit;
                    if (oneOrgPos != Vector2.zero)
                    {
                        one.position = oneOrgPos;
                    }
                    if (otherPetIds.Length == 1)//只有一个怪那么默认站在中间
                    {
                        oneOrgPos = one.position;
                        one.position = two.position;
                    }
                    if (otherPetIds != null)
                    {
                        var petInd = 0;
                        foreach (var otherPetId in otherPetIds)
                        {
                            FightEnemyUnit fightPetUnit = new FightEnemyUnit();
                            var enemyUnit = view.GetChild("enemy" + petInd) as fun_Battle.FightEnemyUnit;
                            enemyUnit.visible = true;
                            fightPetUnit.fightUnitId = (ulong)otherPetId;
                            fightPetUnit.Init(enemyUnit, false, (ulong)otherPetId);
                            petInd += 1;
                            petEnemyCamps.Add(fightPetUnit);
                        }
                    }
                }
            }
        }

    }

    //初始化播放器
    private void InitBattlePlayer()
    {
        battlePlayer = new BattlePlayer();
        battlePlayer.heroCamps = heroCamps;
        battlePlayer.petMyCamps = petMyCamps;
        battlePlayer.petOtherCamps = petOtherCamps;
        battlePlayer.enemys = petEnemyCamps;
        battlePlayer.myFlowerFairies = myFlowerFairies;
        battlePlayer.otherFlowerFairies = otherFlowerFairies;
        battlePlayer.playFinishCall = playFinishCall;
        SkillManager.Instance.SetPlayLayer(ui);//设置技能播放层级
        FloatHelper.SetPlayLayer(ui);
    }

    private IEnumerator StartPlay()
    {
        yield return new WaitForSeconds(0.5f);
        view.n23.visible = true;
        view.t2.Play();
        yield return new WaitForSeconds(2f);
        battlePlayer.Start();
    }

    private void playFinishCall()
    {
        //UIManager.Instance.OpenWindow<SettlementWindow>(UIName.SettlementWindow);
    }

    private void SpeedUp(uint timeScale)
    {
        if (battlePlayer != null)
        {
            battlePlayer.SpeedUp(timeScale);
        }
    }

    private void UpdateRound(ulong round)
    {
        view.txt_round.text = $"第{round}/{BattleModel.Instance.MaxRound}回合";
        UpdateSkip(round);
    }

    private void UpdateFlowerFairies()
    {
        view.myFairy0.visible = view.myFairy1.visible = view.myFairy2.visible = false;
        view.enmeyFairy0.visible = view.enmeyFairy1.visible = view.enmeyFairy2.visible = false;
        myFlowerFairies.Clear();
        otherFlowerFairies.Clear();
        UpdateMyFlowerFairies();
        UpdateOtherFlowerFairies();
    }

    private void OnMyFlowerFairiesRenderer(int index, GObject item)
    {
        var cell = item as fun_Battle.FlowerFairiesItem;
        var myflowerFairyIds = myPlayerVo.battleFairyIds;
        if (myflowerFairyIds != null)
        {
            cell.isMyCamp = true;
            cell.fightUnitId = myflowerFairyIds[index];
            var itemVo = ItemModel.Instance.GetItemById(cell.fairieId);
            cell.img_icon.url = ImageDataModel.Instance.GetIconUrl1(itemVo);
            myFlowerFairies.Add(index, cell);
        }
    }

    private void OnOtherFlowerFairiesRenderer(int index, GObject item)
    {
        var cell = item as fun_Battle.FlowerFairiesItem;
        var otherFlowerFairiesIds = enemyPlayerVo.battleFairyIds;
        if (otherFlowerFairiesIds != null)
        {
            cell.isMyCamp = false;
            cell.fightUnitId = otherFlowerFairiesIds[index];
            var flowerFairyId = (int)cell.data;
            var itemVo = ItemModel.Instance.GetItemById(flowerFairyId);
            cell.img_icon.url = ImageDataModel.Instance.GetIconUrl1(itemVo);
            otherFlowerFairies.Add(index, cell);
        }
    }


    private void OnSpeedUp()
    {
        ChangeSpeed();
        UpdateBtnSpeed();
    }

    private void OnBack()
    {
        UIManager.Instance.CloseWindow(UIName.BattleView);
    }
    private void OnSkip()
    {
        if (battlePlayer != null)
        {
            battlePlayer.End();
        }
        //显示战斗结算界面
    }

    private void UpdateBtnSpeed()
    {
        StringUtil.SetBtnTab(view.btn_speedUp, "x" + BattleModel.Instance.TimeScale);
    }

    private void ChangeSpeed()
    {
        uint timeScale = (uint)(BattleModel.Instance.TimeScale == 1 ? 2 : 1);
        EventManager.Instance.DispatchEvent(BattleEvent.ChangeTimeScale, timeScale);
    }

    private void UpdateSkip(ulong round)
    {
        if (round >= 6)//超过6回合就默认解锁
        {
            view.txt_skip.text = "点击此处跳过战斗";
            view.txt_skip.touchable = true;
        }
        else
        {
            view.txt_skip.text = (6 - round) + "个回合后，可跳过战斗";
            view.txt_skip.touchable = false;
        }
    }

    private void UpdateMyFlowerFairies()
    {
        var flowerFairyIds = myPlayerVo.battleFairyIds;
        if (flowerFairyIds == null || flowerFairyIds.Length <= 0) return;
        var pos = -1;//站位
        foreach (var flowerFairyId in flowerFairyIds)
        {
            pos += 1;
            if (flowerFairyId == 0) continue;//0代表没有花仙
            var flowerFairiesItem = view.GetChild("myFairy" + pos) as fun_Battle.FlowerFairiesItem;
            flowerFairiesItem.visible = true;
            flowerFairiesItem.fairieId = (int)flowerFairyId;
            if (flowerFairiesItem.visible)
            {
                OnMyFlowerFairiesRenderer(pos, flowerFairiesItem);
            }
        }
    }
    private void UpdateOtherFlowerFairies()
    {
        if (!BattleModel.Instance.isPve)
        {
            var flowerFairyIds = enemyPlayerVo.battleFairyIds;
            if (flowerFairyIds == null || flowerFairyIds.Length <= 0) return;
            var pos = -1;//站位
            foreach (var flowerFairyId in flowerFairyIds)
            {
                pos += 1;
                if (flowerFairyId == 0) continue;//0代表没有花仙
                var flowerFairiesItem = view.GetChild("enmeyFairy" + pos) as fun_Battle.FlowerFairiesItem;
                flowerFairiesItem.visible = true;
                flowerFairiesItem.fairieId = (int)flowerFairyId;
                if (flowerFairiesItem.visible)
                {
                    OnOtherFlowerFairiesRenderer(pos, flowerFairiesItem);
                }
            }
        }
    }

    public override void OnHide()
    {
        base.OnHide();
        if (battlePlayer != null)
        {
            battlePlayer.Clear();
        }
    }

}
