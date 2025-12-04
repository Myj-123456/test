using ADK;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class CertificationWindow : BaseWindow
{
    private fun_AntiAddiction.CertificationWindow viewSkin;

    public CertificationWindow()
    {
        packageName = "fun_AntiAddiction";
        // 设置委托
        BindAllDelegate = fun_AntiAddiction.fun_AntiAddictionBinder.BindAll;
        CreateInstanceDelegate = fun_AntiAddiction.CertificationWindow.CreateInstance;
    }
    public override void OnInit()
    {
        base.OnInit();
        viewSkin = ui as fun_AntiAddiction.CertificationWindow;
        SetBg(viewSkin.bg,"Common/ELIDA_common_bigdi01.png");
        StringUtil.SetBtnTab(viewSkin.btn_submit, "提交");
        viewSkin.txtMsg.text = Lang.GetValue("text_fang_tips4");
        AddEvent();
    }

    private void AddEvent()
    {
        viewSkin.btn_submit.onClick.Add(OnSubmit);
        viewSkin.lab_antiAddiction.onClick.Add(OnShowAntiAddiction);
    }

    private void OnSubmit()
    {
        string inputNameText = viewSkin.input_name.text.Trim();
        string inputIdentityCardText = viewSkin.input_identityCard.text.Trim();

        if (string.IsNullOrEmpty(inputNameText))
        {
            ADK.UILogicUtils.ShowNotice("请输入姓名");
            return;
        }
        if (string.IsNullOrEmpty(inputIdentityCardText))
        {
            ADK.UILogicUtils.ShowNotice("请输入身份证号码");
            return;
        }

        //校验身份证
        string regexPattern = @"^[1-9]\d{5}(18|19|20)\d{2}(0[1-9]|1[0-2])(0[1-9]|[12]\d|3[01])\d{3}[\dXx]$";
        if (!Regex.IsMatch(inputIdentityCardText, regexPattern))
        {
            ADK.UILogicUtils.ShowNotice("请输入正确的身份证号码");
            return;
        }
        AntiAddictionController.Instance.ReqCertification(LoginModel.Instance.openid, LoginModel.Instance.token, LoginModel.Instance.salt, inputIdentityCardText, inputNameText);
    }

    private void OnShowAntiAddiction()
    {
        UIManager.Instance.OpenWindow<AntiAddictionWindow>(UIName.AntiAddictionWindow);
    }
}
