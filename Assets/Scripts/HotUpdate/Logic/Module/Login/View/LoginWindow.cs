using ADK;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class LoginWindow : BaseWindow
{
    private fun_Login.LoginWindow viewSkin;

    public LoginWindow()
    {
        packageName = "fun_Login";
        // 设置委托
        BindAllDelegate = fun_Login.fun_LoginBinder.BindAll;
        CreateInstanceDelegate = fun_Login.LoginWindow.CreateInstance;
    }
    public override void OnInit()
    {
        base.OnInit();
        viewSkin = ui as fun_Login.LoginWindow;
        SetBg(viewSkin.bg, "Common/ELIDA_common_littledi01.png");
        StringUtil.SetBtnTab(viewSkin.btn_login, "登录");
        StringUtil.SetBtnTab(viewSkin.btn_register, "注册");
        var loginAccount = Saver.GetString(Saver.LoginAccout);
        var loginPwd = Saver.GetString(Saver.LoginPwd);
        if (!string.IsNullOrEmpty(loginAccount))
        {
            viewSkin.input_account.text = loginAccount;
        }
        if (!string.IsNullOrEmpty(loginPwd))
        {
            viewSkin.input_pwd.text = loginPwd;
        }
        AddEvent();
    }

    private void AddEvent()
    {
        viewSkin.btn_login.onClick.Add(OnLogin);
        viewSkin.btn_register.onClick.Add(OnRegister);
    }

    private void OnLogin()
    {
        string inputAccountText = viewSkin.input_account.text.Trim();
        string inputPwdText = viewSkin.input_pwd.text.Trim();

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

        Saver.SaveAsString(Saver.LoginAccout, inputAccountText);
        Saver.SaveAsString(Saver.LoginPwd, inputPwdText);
        LoginController.Instance.ReqAppPreLogin(inputAccountText, inputPwdText);
    }

    private void OnRegister()
    {
        Close(true);
        UIManager.Instance.OpenWindow<RegisterWindow>(UIName.RegisterWindow);
    }
}
