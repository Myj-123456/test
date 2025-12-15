using ADK;
using common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 登录辅助类
/// </summary>
public class LoginHelper
{
    /// <summary>
    /// 获取设备唯一ID
    /// </summary>
    /// <returns></returns>
    public static string GetIdentifierID()
    {
        return SystemInfo.deviceUniqueIdentifier + Random.Range(1, 10000) + TimeUtil.GetTimestamp();
    }

    public static string GetPid()
    {
        var pid = "";
#if !UNITY_EDITOR && UNITY_WEBGL && !WEIXINMINIGAME//网页web直接读取pid参数
       pid = Config.pid;
#elif UNITY_EDITOR//编辑器下先写死 后面直接读取本地
        pid = Saver.GetString(Saver.Uid);
        if (string.IsNullOrEmpty(pid))//如果都没有 先创建uid
        {
            pid = Config.pid;
            Saver.SaveAsString(Saver.Uid, pid);
        }
#elif !UNITY_EDITOR && UNITY_WEBGL && WEIXINMINIGAME//微信小游戏暂时没接入登录，客户端先模拟一个pid
        pid = Saver.GetString(Saver.Uid);
        if (string.IsNullOrEmpty(pid))//如果都没有 先创建uid
        {
            pid = LoginHelper.GetIdentifierID();
            Saver.SaveAsString(Saver.Uid, pid);
        }
#elif !UNITY_EDITOR && (UNITY_ANDROID || UNITY_IOS)//移动端上
        pid = LoginModel.Instance.openid;
#endif
        return pid;
    }

    /// <summary>
    /// 用户所属平台 
    /// </summary>
    /// <returns></returns>
    public static string GetPlatform()
    {
        var platform = "";
#if !UNITY_EDITOR && UNITY_WEBGL && WEIXINMINIGAME//微信小游戏
        platform = "wm";
#elif UNITY_EDITOR || UNITY_WEBGL//编辑器或者网页端
        platform = "dev";
#elif !UNITY_EDITOR && (UNITY_ANDROID || UNITY_IOS)//移动app端
        platform = "app";
#endif
        return platform;
    }

    /// <summary>
    /// 当前登录平台 
    /// </summary>
    /// <returns></returns>
    public static string GetLoginPlatform()
    {
        var platform = "";
#if !UNITY_EDITOR && UNITY_WEBGL && WEIXINMINIGAME//微信小游戏
        platform = "wm";
#elif UNITY_EDITOR || UNITY_WEBGL//编辑器或者网页端
        platform = "dev";
#elif !UNITY_EDITOR && (UNITY_ANDROID || UNITY_IOS)//移动app端
        platform = "app";
#endif
        return platform;
    }

    public static string GetToken()
    {
        var token = "";
#if !UNITY_EDITOR && UNITY_WEBGL && WEIXINMINIGAME//微信小游戏
        token = "!rg0Vx9Sfuqr*rZcUXR";
#elif UNITY_EDITOR || UNITY_WEBGL//编辑器或者网页端
        token = "!rg0Vx9Sfuqr*rZcUXR";
#elif !UNITY_EDITOR && (UNITY_ANDROID || UNITY_IOS)//移动app端
        token = LoginModel.Instance.token;
#endif
        return token;
    }

    public static string GetSalt()
    {
        var salt = "";
#if !UNITY_EDITOR && UNITY_WEBGL && WEIXINMINIGAME//微信小游戏
        salt = "eheP&GvIa5jFEc3e";
#elif UNITY_EDITOR || UNITY_WEBGL//编辑器或者网页端
        salt = "eheP&GvIa5jFEc3e";
#elif !UNITY_EDITOR && (UNITY_ANDROID || UNITY_IOS)//移动app端
        salt = LoginModel.Instance.salt;
#endif
        return salt;
    }
}
