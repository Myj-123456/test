using System;
using System.Text;
using UnityEngine;

/// <summary>
/// 通用本地缓存
/// </summary>

public static class Saver
{
    private const string SaveKey = "yufu.elida";//唯一保存key

    public const string Plantsortvalue = "plantsortvalue";
    public const string Uid = "uid";
    public const string LoginAccout = "loginAccout";
    public const string LoginPwd = "loginPwd";
    public const string LoginSaveAccout = "LoginSaveAccout";
    public const string LoginServerHost = "LoginServerHost";
    public const string LoginSkipGuide = "LoginSkipGuide";

    public static string SaveAsString<T>(string dataName, T val)
    {
        string strData = val.ToString();
        var key = SaveKey + "_" + dataName;
#if UNITY_WEBGL && !UNITY_EDITOR && !WEIXINMINIGAME//网页端
        WebGLUtil.SaveString(key, strData);
#else
        PlayerPrefs.SetString(key, strData);
        PlayerPrefs.Save();
#endif
        return strData;
    }

    /// <summary>
    /// Get string from local storage
    /// </summary>
    /// <param name="val"></param>
    /// <param name="encryptKey"></param>
    /// <returns>Saved value</returns>
    public static string GetString(string dataName)
    {
        var key = SaveKey + "_" + dataName;
        if (!HasData(dataName))
        {
            return null;
        }
#if UNITY_WEBGL && !UNITY_EDITOR && !WEIXINMINIGAME//网页端
        return WebGLUtil.GetString(key);
#else
        return PlayerPrefs.GetString(key);
#endif
    }

    /// <summary>
    /// Get int from local storage
    /// </summary>
    /// <param name="val"></param>
    /// <param name="encryptKey"></param>
    /// <returns>Saved value</returns>
    public static int GetInt(string dataName, int defaultValue = 0, string encryptKey = null)
    {
        if (int.TryParse(GetString(dataName), out var result))
        {
            return result;
        }
        return defaultValue;
    }

    /// <summary>
    /// Get int from local storage
    /// </summary>
    /// <param name="val"></param>
    /// <param name="encryptKey"></param>
    /// <returns>Saved value</returns>
    public static uint GetUInt(string dataName, uint defaultValue = 0, string encryptKey = null)
    {
        if (uint.TryParse(GetString(dataName), out var result))
        {
            return result;
        }
        return defaultValue;
    }

    /// <summary>
    /// Get short from local storage
    /// </summary>
    /// <param name="val"></param>
    /// <param name="encryptKey"></param>
    /// <returns>Saved value</returns>
    public static short GetShort(string dataName, short defaultValue = 0)
    {
        if (short.TryParse(GetString(dataName), out var result))
        {
            return result;
        }
        return defaultValue;
    }

    /// <summary>
    /// Get long from local storage
    /// </summary>
    /// <param name="val"></param>
    /// <param name="encryptKey"></param>
    /// <returns>Saved value</returns>
    public static long GetLong(string dataName, long defaultValue = 0, string encryptKey = null)
    {
        if (long.TryParse(GetString(dataName), out var result))
        {
            return result;
        }
        return defaultValue;
    }

    /// <summary>
    /// Get decimal from local storage
    /// </summary>
    /// <param name="val"></param>
    /// <param name="encryptKey"></param>
    /// <returns>Saved value</returns>
    public static decimal GetDecimal(string dataName, decimal defaultValue = 0m, string encryptKey = null)
    {
        if (decimal.TryParse(GetString(dataName), out var result))
        {
            return result;
        }
        return defaultValue;
    }

    /// <summary>
    /// Get double from local storage
    /// </summary>
    /// <param name="val"></param>
    /// <param name="encryptKey"></param>
    /// <returns>Saved value</returns>
    public static double GetDouble(string dataName, double defaultValue = 0d, string encryptKey = null)
    {
        if (double.TryParse(GetString(dataName), out var result))
        {
            return result;
        }
        return defaultValue;
    }

    /// <summary>
    /// Get float from local storage
    /// </summary>
    /// <param name="val"></param>
    /// <param name="encryptKey"></param>
    /// <returns>Saved value</returns>
    public static float GetFloat(string dataName, float defaultValue = 0f, string encryptKey = null)
    {
        if (float.TryParse(GetString(dataName), out var result))
        {
            return result;
        }
        return defaultValue;
    }

    /// <summary>
    /// Get bool from local storage
    /// </summary>
    /// <param name="val"></param>
    /// <param name="encryptKey"></param>
    /// <returns>Saved value</returns>
    public static bool GetBool(string dataName, bool defaultValue = false, string encryptKey = null)
    {
        if (bool.TryParse(GetString(dataName), out var result))
        {
            return result;
        }
        return defaultValue;
    }

    /// <summary>
    /// Get object from local storage from JSON
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="val"></param>
    /// <param name="encryptKey"></param>
    /// <returns>Saved value</returns>


    /// <summary>
    /// Get object from local storage from protobuf
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="val"></param>
    /// <param name="encryptKey"></param>
    /// <returns>Saved value</returns>

    /// <summary>
    /// Whether or not has specific data
    /// </summary>
    /// <param name="dataName"></param>
    /// <returns></returns>
    public static bool HasData(string dataName)
    {
        var key = SaveKey + "_" + dataName;
#if UNITY_WEBGL && !UNITY_EDITOR && !WEIXINMINIGAME//网页端
        return WebGLUtil.HasKey(key);
#else
        return PlayerPrefs.HasKey(key);
#endif
    }

    /// <summary>
    /// Delete specific data
    /// </summary>
    /// <param name="dataName"></param>
    public static void DeleteData(string dataName)
    {
        var key = SaveKey + "_" + dataName;
        PlayerPrefs.DeleteKey(key);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Delete all data
    /// </summary>
    ///
    public static void DeleteAllData()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}

