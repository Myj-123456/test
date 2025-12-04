
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class UserInfoWindow : BaseWindow
{
    private fun_MyInfo.user_info _view;

    public UserInfoWindow()
    {
        packageName = "fun_MyInfo";
        // 设置委托
        BindAllDelegate = fun_MyInfo.fun_MyInfoBinder.BindAll;
        CreateInstanceDelegate = fun_MyInfo.user_info.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        _view = ui as fun_MyInfo.user_info;
        SetBg(_view.bg, "Common/ELIDA_common_littledi01.png");
        _view.txt_sound.text = Lang.GetValue("slang_7") + ":";//提示音效
        _view.txt_bgm.text = Lang.GetValue("slang_8") + ":";//背景音乐
        _view.txt_onekey.text = Lang.GetValue("slang_9") + ":";//一键收花
        _view.agreeBtn.xieyi_txt.text = Lang.GetValue("slang_10");//用户服务协议
        _view.privacyBtn.tiaoluan_txt.text = Lang.GetValue("slang_11");//隐私条款
        _view.txt_anim.text = Lang.GetValue("userinfo_plant_amin") + ":";
        _view.tip.text = Lang.GetValue("userinfo_plant_tip");
        _view.txt_gameVer.text = "gameVer：" + Config.appVer;

        string openStr = Lang.GetValue("UserInfoOn");//开启
        string closeStr = Lang.GetValue("slang_77");//关闭
        _view.toggle_2.txt_open.text = openStr;//开启
        _view.toggle_1.txt_open.text = openStr;//开启
        _view.toggle_harvest.txt_open.text = openStr;//开启
        _view.toggle_anim.txt_open.text = openStr;//开启

        _view.toggle_2.txt_close.text = closeStr;//关闭
        _view.toggle_1.txt_close.text = closeStr;//关闭
        _view.toggle_harvest.txt_close.text = closeStr;//关闭
        _view.toggle_anim.txt_close.text = closeStr;//关闭
        UpdateToggles();

        _view.agreeBtn.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<UserXieYiWindow>(UIName.UserXieYiWindow);
        });

        _view.privacyBtn.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<serYinSiWindow>(UIName.serYinSiWindow);
        });

        _view.toggle_1.onClick.Add(() =>
        {
            var str = MyselfModel.Instance.isBackgroundMuted ? Lang.GetValue("Function_switch_1") : Lang.GetValue("Function_switch_2");
            UILogicUtils.ShowNotice(str);
            MyselfModel.Instance.isBackgroundMuted = !MyselfModel.Instance.isBackgroundMuted;
            SoundManager.Instance.musicEnabled = MyselfModel.Instance.isBackgroundMuted;
            Saver.SaveAsString<bool>("background_sound" + MyselfModel.Instance.userId, MyselfModel.Instance.isBackgroundMuted);
            UpdateToggles();
        });
        _view.toggle_2.onClick.Add(() =>
        {
            var str = MyselfModel.Instance.isEffectMuted ? Lang.GetValue("Function_switch_3") : Lang.GetValue("Function_switch_4");
            UILogicUtils.ShowNotice(str);
            MyselfModel.Instance.isEffectMuted = !MyselfModel.Instance.isEffectMuted;
            SoundManager.Instance.soundEnabled = MyselfModel.Instance.isEffectMuted;
            Saver.SaveAsString<bool>("effect_sound" + MyselfModel.Instance.userId, MyselfModel.Instance.isEffectMuted);
            UpdateToggles();
        });

        _view.toggle_harvest.onClick.Add(() =>
        {
            var str = MyselfModel.Instance.fastHarvest ? Lang.GetValue("Function_switch_6") : Lang.GetValue("Function_switch_5");
            UILogicUtils.ShowNotice(str);
            MyselfModel.Instance.fastHarvest = !MyselfModel.Instance.fastHarvest;
            Saver.SaveAsString<bool>("key_harvest" + MyselfModel.Instance.userId, MyselfModel.Instance.fastHarvest);
            UpdateToggles();
        });

        _view.toggle_anim.onClick.Add(() =>
        {
            var str = Lang.GetValue("userinfo_plant_amin") + (MyselfModel.Instance.plantTween ? Lang.GetValue("slang_77") : Lang.GetValue("UserInfoOn"));
            UILogicUtils.ShowNotice(str);
            MyselfModel.Instance.plantTween = !MyselfModel.Instance.plantTween;
            PlantController.Instance.UpdatePlantAni();
            Saver.SaveAsString<bool>("plant_Tween" + MyselfModel.Instance.userId, MyselfModel.Instance.plantTween);
            UpdateToggles();
        });
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
    }
    private void UpdateToggles()
    {
        _view.toggle_1.select.selectedIndex = MyselfModel.Instance.isBackgroundMuted ? 0 : 1;
        _view.toggle_2.select.selectedIndex = MyselfModel.Instance.isEffectMuted ? 0 : 1;
        _view.toggle_harvest.select.selectedIndex = MyselfModel.Instance.fastHarvest ? 0 : 1;
        _view.toggle_anim.select.selectedIndex = MyselfModel.Instance.plantTween ? 0 : 1;
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

