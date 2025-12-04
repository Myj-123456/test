
using Elida.Config;
using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 多语言配置
/// </summary>
public class Lang
{
    private static Ft_zhcnConfigData zhcnConfigData;
    public static string GetValue(string key, params string[] args)
    {
        if (zhcnConfigData == null)
        {
            zhcnConfigData = ConfigManager.Instance.GetConfig<Ft_zhcnConfigData>("ft_zhcnsConfig");
        }

        Ft_zhcnConfig zhcnConfig = zhcnConfigData.Get(key);
        if (zhcnConfig == null)
        {
            Debug.LogWarning("未配置多语言 key：" + key);
            return "";
        }
        string result = zhcnConfig.Value;
        if (args != null)
        {
            for (int i = 0; i < args.Length; i++)
            {
                result = result.Replace("{" + i + "}", args[i]);
            }
        }
        return result;
    }

    /**检测语言配置是否存在是否 */
    public static bool CheckLangExists(string key)
    {
        if (zhcnConfigData == null)
        {
            return false;
        }
        Ft_zhcnConfig zhcnConfig = zhcnConfigData.Get(key);
        if (zhcnConfig == null)
        {
            return false;
        }
        return true;
    }

    public static string GetValue1(string key, List<string> args)
    {
        string result = key;
        if (args != null)
        {
            for (int i = 0; i < args.Count; i++)
            {
                result = result.Replace("{" + i + "}", args[i]);
            }
        }
        return result;
    }
}

