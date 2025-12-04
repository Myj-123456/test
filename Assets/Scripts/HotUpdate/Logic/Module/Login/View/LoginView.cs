using ADK;
using FairyGUI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginView : BaseView
{
    private fun_Login.LoginView viewSkin;
    private string[] serverList;

    public LoginView()
    {
        packageName = "fun_Login";
        // …Ë÷√ŒØÕ–
        BindAllDelegate = fun_Login.fun_LoginBinder.BindAll;
        CreateInstanceDelegate = fun_Login.LoginView.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        viewSkin = ui as fun_Login.LoginView;
        serverList = LoginModel.Instance.serverList;
        viewSkin.list_server.itemRenderer = OnItemRenderer;
        viewSkin.list_server.onClickItem.Add(OnClickItem);
        AddEvent();
    }


    public override void OnShown()
    {
        base.OnShown();
        var localAccount = Saver.GetString(Saver.LoginSaveAccout);
        var localServerHost = Saver.GetString(Saver.LoginServerHost);
        if (!string.IsNullOrEmpty(localAccount))
        {
            viewSkin.input_account.text = localAccount;
        }
        viewSkin.list_server.numItems = serverList.Length;
        if (!string.IsNullOrEmpty(localServerHost))
        {
            Config.ApiHost = localServerHost;
            var selectedIndex = GetSelectIndex(localServerHost);
            viewSkin.list_server.selectedIndex = selectedIndex;
        }
        viewSkin.btn_skipGuide.selected = Saver.GetBool(Saver.LoginSkipGuide);
        GuideModel.Instance.IsNeedGuide = !viewSkin.btn_skipGuide.selected;
    }

    private int GetSelectIndex(string serverHost)
    {
        for (var i = 0; i < serverList.Length; i++)
        {
            if (serverList[i].Contains(serverHost))
            {
                return i;
            }
        }
        return -1;
    }

    private void OnItemRenderer(int index, GObject item)
    {
        var cell = item as fun_Login.ServerRenderItem;
        var serverConfig = serverList[index];
        var serverName = serverConfig.Split("#")[0];
        var serverHost = serverConfig.Split("#")[1];
        cell.txt_serverName.text = serverName;
        cell.txt_host.text = serverHost;
    }

    private void OnClickItem(EventContext context)
    {
        var cell = context.data as fun_Login.ServerRenderItem;
        Config.ApiHost = cell.txt_host.text;
    }
    private void AddEvent()
    {
        viewSkin.btn_login.onClick.Add(OnLogin);
        viewSkin.btn_skipGuide.onChanged.Add(OnChanged);
    }
    private void OnLogin()
    {
        if (string.IsNullOrEmpty(viewSkin.input_account.text) || string.IsNullOrEmpty(Config.ApiHost))
        {
            return;
        }
        Config.pid = viewSkin.input_account.text;
        SaveData();
        StartPreLoad();
    }
    private void OnChanged()
    {
        GuideModel.Instance.IsNeedGuide = !viewSkin.btn_skipGuide.selected;
        Saver.SaveAsString(Saver.LoginSkipGuide, viewSkin.btn_skipGuide.selected);
    }

    private void StartPreLoad()
    {
        UIManager.Instance.ClosePanel(UIName.LoginView);
        PreLoadManager.Instance.ShowLoadingView();
        Coroutiner.StartCoroutine(PreLoadManager.Instance.StartPreLoad());
    }

    private void SaveData()
    {
        Saver.SaveAsString(Saver.LoginSaveAccout, viewSkin.input_account.text);
        Saver.SaveAsString(Saver.LoginServerHost, Config.ApiHost);
    }
}
