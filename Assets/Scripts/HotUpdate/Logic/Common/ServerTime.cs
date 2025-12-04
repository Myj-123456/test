

using System;
using UnityEngine;
/// <summary>
/// 服务器时间
/// </summary>
public class ServerTime
{
    private static uint tickOffset;
    private static bool IsSyncTime = false;//是否同步过服务器时间

    /// <summary>
    /// 更新矫正服务器时间
    /// </summary>
    /// <param name="serverTime"></param>
    /// <param name="halfRtt"></param>
    public static void UpdateServerTime(uint serverTime, float halfRtt)
    {
        uint realtimeSinceStartup = (uint)UnityEngine.Time.realtimeSinceStartup;
        tickOffset = (serverTime + (uint)halfRtt - realtimeSinceStartup);
        if (tickOffset <= 10000)
        {
            Debug.LogError("ServerTime tickOffset不对1!!:" + tickOffset);
        }
        Debug.Log("同步服务器时间 serverTime: " + serverTime + " realtimeSinceStartup: " + realtimeSinceStartup + " tickOffset: " + tickOffset);
        if (!IsSyncTime)
            IsSyncTime = true;
    }

    /// <summary>
    /// 服务器时间(时间戳秒)
    /// </summary>
    public static uint Time
    {
        get
        {
            if (!IsSyncTime)
            {

                Debug.Log("ServerTime未同步过服务器时间返回0");
                return 0;//未同步过服务器时间返回0
            }
            if (tickOffset <= 10000)
            {
                Debug.LogError("ServerTime tickOffset不对2!!:" + tickOffset);
            }
            return ((uint)UnityEngine.Time.realtimeSinceStartup + tickOffset);
        }
    }

}
