using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct HttpLoginData
{
    public string token;
    public string gameWssUrl;
    public string chatWssUrl;
    public bool isRegister;
    public uint serverTime;
}
public struct HttpAppLoginRegisterData
{
    public string openid;
    public string token;
    public string salt;
    public int verifyStatus;
    public string idCard;
    public string realName;
}
/// <summary>
/// 登录模块数据
/// </summary>
public class LoginModel : Singleton<LoginModel>
{
    public string gameWssUrl;
    public string chatWssUrl;
    public string loginToken;

    public bool isReConnect = false;//是否重连
    public bool isEnterGameScene = false;//是否已进入游戏场景
    public bool isResGameMisc = false;
    public bool isGameInit = false;//游戏是否初始化过

    public string openid;
    public string token;
    public string salt;
    public int verifyStatus; //实名认证状态 -1:未填写身份证 0:认证成功 1：认证中 2：认证失败

    //服务器列表
    public string[] serverList = new string[3] { "测试服#https://elida-api-test-v2.tigermoon.cn/api", "测试稳定服#https://elida-api-test-stable.tigermoon.cn/api", "彭震本地服#http://192.168.3.53:8585/api" };
}
