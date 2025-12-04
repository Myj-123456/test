
using System;
using System.Collections.Generic;
/// <summary>
/// 控制器基类
/// </summary>
public class BaseController<T> : Singleton<T> where T : new()
{
    private Dictionary<int, float> lockReqDic = new Dictionary<int, float>();
    public BaseController()
    {
        InitListeners();
    }
    protected virtual void InitListeners()
    {

    }

    #region Socket事件
    /// <summary>
    /// 发送socket
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="msgId"></param>
    /// <param name="msg"></param>
    /// <param name="msg">请求cd检测时间</param>
    public void SendCmd<T1>(int msgId, T1 msg, float checkTime = 0.2f) where T1 : class
    {
        if (CheckReqIsUnLock(msgId, checkTime))
        {
            NetWorkManager.Instance.Send((ushort)msgId, msg);
        }
    }
    /// <summary>
    /// 监听socket事件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="type"></param>
    /// <param name="callback"></param>
    public void AddNetListener<T1>(int type, Action<T1> callback) => NetWorkManager.Instance.AddNetListener(type, callback);
    /// <summary>
    /// 移除socket事件
    /// </summary>
    /// <param name="type"></param>
    public void RemoveNetListener(int type) => NetWorkManager.Instance.RemoveNetListener(type);
    #endregion

    #region 游戏事件
    public void DispatchEvent(string eventName) => EventManager.Instance.DispatchEvent(eventName);
    public void DispatchEvent<T1>(string eventName, T1 arg1) => EventManager.Instance.DispatchEvent(eventName, arg1);
    public void DispatchEvent<T1, T2>(string eventName, T1 arg1, T2 arg2) => EventManager.Instance.DispatchEvent(eventName, arg1, arg2);
    public void DispatchEvent<T1, T2, T3>(string eventName, T1 arg1, T2 arg2, T3 arg3) => EventManager.Instance.DispatchEvent(eventName, arg1, arg2, arg3);
    public void DispatchEvent<T1, T2, T3, T4>(string eventName, T1 arg1, T2 arg2, T3 arg3, T4 arg4) => EventManager.Instance.DispatchEvent(eventName, arg1, arg2, arg3, arg4);

    public void AddEventListener(string eventName, Action action) => EventManager.Instance.AddEventListener(eventName, action);
    public void AddEventListener<T1>(string eventName, Action<T1> action) => EventManager.Instance.AddEventListener(eventName, action);
    public void AddEventListener<T1, T2>(string eventName, Action<T1, T2> action) => EventManager.Instance.AddEventListener(eventName, action);
    public void AddEventListener<T1, T2, T3>(string eventName, Action<T1, T2, T3> action) => EventManager.Instance.AddEventListener(eventName, action);
    public void AddEventListener<T1, T2, T3, T4>(string eventName, Action<T1, T2, T3, T4> action) => EventManager.Instance.AddEventListener(eventName, action);

    public void RemoveEventListener(string eventName, Action action) => EventManager.Instance.RemoveEventListener(eventName, action);
    public void RemoveEventListener<T1>(string eventName, Action<T1> action) => EventManager.Instance.RemoveEventListener(eventName, action);
    public void RemoveEventListener<T1, T2>(string eventName, Action<T1, T2> action) => EventManager.Instance.RemoveEventListener(eventName, action);
    public void RemoveEventListener<T1, T2, T3>(string eventName, Action<T1, T2, T3> action) => EventManager.Instance.RemoveEventListener(eventName, action);
    public void RemoveEventListener<T1, T2, T3, T4>(string eventName, Action<T1, T2, T3, T4> action) => EventManager.Instance.RemoveEventListener(eventName, action);
    #endregion


    /// <summary>
    /// 需要锁cd操作的请求都在请求之前调用下
    /// </summary>
    /// <param name="msgId"></param>
    private bool CheckReqIsUnLock(int msgId, float checkTime)
    {
        if (checkTime <= 0) return true;
        lockReqDic.TryGetValue(msgId, out var lastReqTime);
        var curReqTime = UnityEngine.Time.unscaledTime;
        var isUnLock = curReqTime - lastReqTime >= checkTime;
        if (isUnLock)
        {
            lockReqDic[msgId] = curReqTime;
        }
        else
        {
            UnityEngine.Debug.Log("请求cd中 msgId:" + msgId);
        }
        return isUnLock;
    }

}

