using ADK;
using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YooAsset;

public class AdventureView : BaseView
{
    private fun_Adventure.AdventureView viewSkin;

    public AdventureView()
    {
        packageName = "fun_Adventure";
        // ÉèÖÃÎ¯ÍÐ
        BindAllDelegate = fun_Adventure.fun_AdventureBinder.BindAll;
        CreateInstanceDelegate = fun_Adventure.AdventureView.CreateInstance;
    }
    public override void OnInit()
    {
        base.OnInit();
        viewSkin = ui as fun_Adventure.AdventureView;
        StringUtil.SetBtnTab(viewSkin.pack_btn, Lang.GetValue("pack_name"));
        StringUtil.SetBtnTab(viewSkin.arraying_btn, Lang.GetValue("into_battle_1"));
        StringUtil.SetBtnTab(viewSkin.power_btn, Lang.GetValue("player_info_4"));
        DropManager.AddAdventureFlyPos((int)BaseType.FST_WATER, viewSkin.water_icon.LocalToRoot(new Vector2(-20, -30), GRoot.inst));
        DropManager.AddAdventureFlyPos((int)BaseType.CASH, viewSkin.cash_icon.LocalToRoot(new Vector2(-20, -30), GRoot.inst));
        DropManager.AddAdventureFlyPos((int)BaseType.GOLD, viewSkin.gold_icon.LocalToRoot(new Vector2(-20, -30), GRoot.inst));
        DropManager.AddAdventureFlyPos((int)BaseType.ColorPower, viewSkin.colorPower_icon.LocalToRoot(new Vector2(-20, -30), GRoot.inst));
        AddEvent();
    }

    public override void OnShown()
    {
        base.OnShown();
        UpdatePlayerInfo();
        UpdateColorPower();
    }
    private void UpdatePlayerInfo()
    {
        UpdateGold();
        UpdateDiamond();
        UpdateWater();
    }

    private void UpdateColorPower()
    {
        var colorPowerItemNum = StorageModel.Instance.GetItemCount((int)ADK.BaseType.ColorPower);
        viewSkin.txt_colorPower.text = colorPowerItemNum.ToString();
    }

    private void UpdateGold()
    {
        viewSkin.txt_gold.text = TextUtil.ChangeCoinShow(MyselfModel.Instance.gold);
    }
    private void UpdateDiamond()
    {
        viewSkin.txt_diamond.text = TextUtil.ChangeCoinShow(MyselfModel.Instance.diamond);
    }

    private void UpdateWater()
    {
        viewSkin.txt_water.text = MyselfModel.Instance.WaterCur.ToString();
    }
    private void AddEvent()
    {
        viewSkin.btn_backHome.onClick.Add(OnBackHome);
        viewSkin.help_btn.onClick.Add(OnHelp);
        viewSkin.pack_btn.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<TourPackWindow>(UIName.TourPackWindow);
        });
        viewSkin.power_btn.onClick.Add(() =>
        {
            if (!GlobalModel.Instance.GetUnlocked(SysId.PlayerInfo, true))
            {
                return;
            }
            //UIManager.Instance.OpenPanel<PlayerInfoView>(UIName.PlayerInfoView);
        });
        viewSkin.arraying_btn.onClick.Add(() =>
        {
            //UIManager.Instance.OpenPanel<IntoBattleView>(UIName.IntoBattleView);
        });
        AddEventListener(SystemEvent.UpdateItemNum, UpdateColorPower);
        AddEventListener<uint>(SystemEvent.UpdateProfile, UpdateProfile);
        AddEventListener(SystemEvent.UpdateWater, UpdateWater);
    }
    private void UpdateProfile(uint itemId)
    {
        if (itemId == (uint)BaseType.CASH)
        {
            UpdateDiamond();
        }
        else if (itemId == (uint)BaseType.GOLD)
        {
            UpdateGold();
        }
    }

    private void OnHelp()
    {
        string[] str = new string[] { Lang.GetValue("adventure_title"), Lang.GetValue("adventure_help") };
        UIManager.Instance.OpenWindow<HelpWindow>(UIName.HelpWindow, str);
    }

    private void OnBackHome()
    {
        AdventureController.Instance.QuitAdventure();
    }

}
