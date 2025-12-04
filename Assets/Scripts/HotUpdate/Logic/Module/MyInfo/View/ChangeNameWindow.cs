
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class ChangeNameWindow : BaseWindow
{
    private fun_MyInfo.name_input view;

    public ChangeNameWindow()
    {
        packageName = "fun_MyInfo";
        // 设置委托
        BindAllDelegate = fun_MyInfo.fun_MyInfoBinder.BindAll;
        CreateInstanceDelegate = fun_MyInfo.name_input.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        view = ui as fun_MyInfo.name_input;

        SetBg(view.bg, "Common/ELIDA_common_littledi01.png");
        StringUtil.SetBtnTab(view.btn_sure, Lang.GetValue("levelup_button"));

        view.txt_input.maxLength = 6;
        view.txt_input.restrict = "[\u4E00-\u9FA5]";
        view.btn_sure.onClick.Add(() =>
        {
            if (view.txt_input.text.Trim() == "")
            {
                UILogicUtils.ShowNotice(Lang.GetValue("guild.name_can_not_empty"));
                return;
            }

            var guildName = view.txt_input.text.Trim();
            
            MyselfController.Instance.ReqUpdateTownName(guildName);
            view.tipLab.visible = true;
            view.txt_input.text = "";
            UIManager.Instance.CloseWindow(UIName.ChangeNameWindow);
        });

        view.txt_input.onFocusIn.Add(() =>
        {
            view.tipLab.visible = false;
        });

        view.txt_input.onFocusOut.Add(() =>
        {

        });
        view.random_btn.onClick.Add(() =>
        {
            int idx = Random.Range(0, PlayerModel.Instance.playerNameList.Count - 1);
            var id = PlayerModel.Instance.playerNameList[idx].Id;
            var listData = PlayerModel.Instance.playerNameList.FindAll(value => value.Id != id);
            int idx1 = Random.Range(0, PlayerModel.Instance.playerNameList.Count - 1);
            var name = PlayerModel.Instance.playerNameList[idx].LastName + listData[idx1].FirstName;
            view.tipLab.visible = false;
            view.txt_input.text = name;
        });

    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        view.tipLab.visible = true;
        //var name = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_NICKNAME).info;
        view.txt_input.text = "";
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

