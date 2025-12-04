using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

#if UNITY_WEBGL && !WEIXINMINIGAME
public class WebGLUtil
{

    [DllImport("__Internal")] private static extern string GetQuerySearch();

    // localStorage 字符串操作
    [DllImport("__Internal")]
    private static extern int SaveToLocalStorage(string key, string value);

    [DllImport("__Internal")]
    private static extern string LoadFromLocalStorage(string key);

    [DllImport("__Internal")]
    private static extern int RemoveFromLocalStorage(string key);

    [DllImport("__Internal")]
    private static extern int HasKeyInLocalStorage(string key);

    [DllImport("__Internal")]
    private static extern int ClearLocalStorage();

    private static string querySearch;//网页端webgl传递的参数

    /// <summary>
    /// 初始化
    /// </summary>
    public static void Init()
    {
        try
        {
            querySearch = GetQuerySearch();
        }
        catch (Exception e)
        {
        }
        Debug.Log("querySearch:" + querySearch);
    }

    /// <summary>
    /// 获取网页参数
    /// </summary>
    /// <param name="variable"></param>
    /// <returns></returns>
    public static string GetQueryVariable(string variable)
    {
        if (string.IsNullOrEmpty(querySearch)) return "";
        var query = querySearch.Substring(1);
        var vars = query.Split("&");
        for (var i = 0; i < vars.Length; i++)
        {
            var pair = vars[i].Split("=");
            if (pair[0] == variable)
            {
                return pair[1];
            }
        }
        return "";
    }

    // 字符串存储
    public static bool SaveString(string key, string value)
    {
        return SaveToLocalStorage(key, value) == 1;
    }

    public static string GetString(string key, string defaultValue = "")
    {
        string result = LoadFromLocalStorage(key);
        return string.IsNullOrEmpty(result) ? defaultValue : result;
    }

    public static bool HasKey(string key)
    {
        return HasKeyInLocalStorage(key) == 1;
    }
    public static void DeleteKey(string key)
    {
        RemoveFromLocalStorage(key);
    }

    public static void ClearAll()
    {
        ClearLocalStorage();
    }
}
#endif
