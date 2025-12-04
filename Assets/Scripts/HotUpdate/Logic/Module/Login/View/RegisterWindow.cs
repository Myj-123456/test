using ADK;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class RegisterWindow : BaseWindow
{
    private fun_Login.RegisterWindow viewSkin;

    public RegisterWindow()
    {
        packageName = "fun_Login";
        // 设置委托
        BindAllDelegate = fun_Login.fun_LoginBinder.BindAll;
        CreateInstanceDelegate = fun_Login.RegisterWindow.CreateInstance;
    }
    public override void OnInit()
    {
        base.OnInit();
        viewSkin = ui as fun_Login.RegisterWindow;
        SetBg(viewSkin.bg,"Common/ELIDA_common_littledi01.png");
        StringUtil.SetBtnTab(viewSkin.btn_confirm, "确定");
        StringUtil.SetBtnTab(viewSkin.btn_cancel, "取消");
        AddEvent();
    }

    private void AddEvent()
    {
        viewSkin.btn_confirm.onClick.Add(OnConfirm);
        viewSkin.btn_cancel.onClick.Add(OnCancel);
    }

    private void OnConfirm()
    {
        string inputAccountText = viewSkin.input_account.text.Trim();
        string inputPwdText = viewSkin.input_pwd.text.Trim();
        string inputConfirmPwdText = viewSkin.input_confirmPwd.text.Trim();

        if (string.IsNullOrEmpty(inputAccountText))
        {
            ADK.UILogicUtils.ShowNotice("请输入账号");
            return;
        }
        
        if (string.IsNullOrEmpty(inputPwdText))
        {
            ADK.UILogicUtils.ShowNotice("请输入密码");
            return;
        }
        if (string.IsNullOrEmpty(inputConfirmPwdText))
        {
            ADK.UILogicUtils.ShowNotice("请输入确认密码");
            return;
        }

        if (inputPwdText != inputConfirmPwdText)
        {
            ADK.UILogicUtils.ShowNotice("二次密码确认不通过");
            return;
        }

        //校验账号(只允许字母和数字的组合)
        string regexPattern = @"^[a-zA-Z0-9]+$";
        if (!Regex.IsMatch(inputAccountText, regexPattern))
        {
            ADK.UILogicUtils.ShowNotice("账户名不能含有特殊符号");
            return;
        }
        //校验密码
        regexPattern = @"^[0-9]+$";
        if (!Regex.IsMatch(inputPwdText, regexPattern))
        {
            ADK.UILogicUtils.ShowNotice("密码只允许输入纯数字组合");
            return;
        }
        //校验确认密码
        regexPattern = @"^[0-9]+$";
        if (!Regex.IsMatch(inputConfirmPwdText, regexPattern))
        {
            ADK.UILogicUtils.ShowNotice("确认密码只允许输入纯数字组合");
            return;
        }
        Saver.SaveAsString(Saver.LoginAccout, inputAccountText);
        Saver.SaveAsString(Saver.LoginPwd, inputPwdText);
        LoginController.Instance.ReqAppRegister(inputAccountText, inputPwdText, inputConfirmPwdText);
    }

    private void OnCancel()
    {
        Close(true);
        UIManager.Instance.OpenWindow<LoginWindow>(UIName.LoginWindow);
    }
}
