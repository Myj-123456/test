using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// 用于封包解包
/// </summary>
public class PackHelper
{

    /// <summary>
    /// 封包
    /// </summary>
    /// <param name="messageId">消息ID。</param>
    /// <param name="data">pb数据。</param>
    public static byte[] Pack(ushort messageId, byte[] data)
    {
        var timestamp = ServerTime.Time;
        Debug.Log("Pack MSG messageId:" + messageId + "timestamp: " + timestamp);
        using (var ms = new System.IO.MemoryStream())
        using (var bw = new System.IO.BinaryWriter(ms))
        {
            bw.Write(messageId);
            bw.Write(timestamp);//自己回包服务器测试的话 这里需要屏蔽掉
            bw.Write(data);
            return ms.ToArray();
        }
    }

    /// <summary>
    /// 解包
    /// </summary>
    public static void UnPack(byte[] data)
    {
        ushort messageId;
        byte[] pbBytes;
        try
        {
            using (var ms = new System.IO.MemoryStream(data))
            using (var br = new System.IO.BinaryReader(ms))
            {
                messageId = br.ReadUInt16();
                pbBytes = br.ReadBytes(data.Length - 2);
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"解包数据时出错 Message: {ex.Message} StackTrace：{ex.StackTrace}");
            return;
        }
        NetWorkManager.Instance.TriggerNet((int)messageId, pbBytes);
    }
}