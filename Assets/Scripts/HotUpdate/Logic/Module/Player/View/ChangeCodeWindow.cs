using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class ChangeCodeWindow : BaseWindow
{
   private fun_MyInfo.change_code_view view;

   public ChangeCodeWindow()
    {
        packageName = "fun_MyInfo";
        // 设置委托
        BindAllDelegate = fun_MyInfo.fun_MyInfoBinder.BindAll;
        CreateInstanceDelegate = fun_MyInfo.change_code_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_MyInfo.change_code_view;
        SetBg(view.bg, "Common/ELIDA_common_littledi01.png");
        StringUtil.SetBtnTab(view.btn_sure, Lang.GetValue("levelup_button"));
        StringUtil.SetBtnTab(view.cancle_btn, Lang.GetValue("common_button_cancel"));


        view.btn_sure.onClick.Add(() =>
        {
            if (view.txt_input.text.Trim() == "")
            {
                UILogicUtils.ShowNotice(Lang.GetValue("guild.name_can_not_empty"));
                return;
            }
            var code = view.txt_input.text.Trim();
            MyselfController.Instance.ReqGiftCode(code);
        });
        view.cancle_btn.onClick.Add(Close);
        view.txt_input.onFocusIn.Add(() =>
        {
            view.tipLab.visible = false;
        });

        view.txt_input.onFocusOut.Add(() =>
        {

        });
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        view.tipLab.visible = true;
        view.txt_input.text = "";
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

