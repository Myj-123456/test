using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PbHelper
{
    // 单线程对象池
    private static readonly Stack<MemoryStream> _streamPool = new Stack<MemoryStream>();
    private const int MaxPoolSize = 10;

    /// <summary>
    /// 序列化（单线程优化版）
    /// </summary>
    public static byte[] ProtoSerialize<T>(T obj) where T : class
    {
        MemoryStream stream = null;
        try
        {
            stream = GetStream();
            stream.SetLength(0);
            stream.Position = 0;
            ProtoBuf.Serializer.Serialize(stream, obj);
            return stream.ToArray();
        }
        catch (IOException ex)
        {
            Debug.LogError($"[ProtoSerialize] 错误：{ex.Message}");
            return null;
        }
        finally
        {
            if (stream != null)
            {
                ReturnStream(stream);
            }
        }
    }

    /// <summary>
    /// 反序列化（单线程优化版）
    /// </summary>
    public static T ProtoDeSerialize<T>(byte[] msg)
    {
        MemoryStream stream = null;
        try
        {
            stream = GetStream();
            stream.SetLength(0);
            stream.Write(msg, 0, msg.Length);
            stream.Position = 0;
            return (T)ProtoBuf.Serializer.Deserialize(stream, typeof(T));
        }
        catch (Exception ex)
        {
            Debug.LogError($"[ProtoDeSerialize] 错误：{ex.Message}, {ex.StackTrace}");
            return default;
        }
        finally
        {
            if (stream != null)
            {
                ReturnStream(stream);
            }
        }
    }

    private static MemoryStream GetStream()
    {
        return _streamPool.Count > 0
            ? _streamPool.Pop()
            : new MemoryStream();
    }

    private static void ReturnStream(MemoryStream stream)
    {
        if (_streamPool.Count < MaxPoolSize)
        {
            _streamPool.Push(stream);
        }
        else
        {
            stream.Dispose();
        }
    }

    /// <summary>
    /// 清空对象池（如切换场景时调用）
    /// </summary>
    public static void ClearPool()
    {
        foreach (var stream in _streamPool)
        {
            stream.Dispose();
        }
        _streamPool.Clear();
    }
}