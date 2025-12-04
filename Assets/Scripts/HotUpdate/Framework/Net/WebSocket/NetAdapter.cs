
using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 网络适配器
/// </summary>
public partial class NetWorkManager : Singleton<NetWorkManager>
{

    private Dictionary<int, ListenerData> listenerDic;

    /// <summary>
    /// 网络协议分发
    /// </summary>
    /// <param name="type"></param>
    /// <param name="data"></param>
    public void TriggerNet(int type, byte[] data)
    {
        ListenerData listener;
        if (listenerDic.TryGetValue(type, out listener))
        {
            listener.SetData(data);
            listener.Call();
        }
        EventManager.Instance.DispatchEvent(NetEvent.TriggerNet, type);
    }

    public void AddNetListener<T>(int type, Action<T> callback, bool always = false)
    {
        if (callback == null)
        {
            Debug.LogError("BaseEventAdapter Listen: Callback is null,type=" + type);
            return;
        }
        if (listenerDic == null)
            listenerDic = new Dictionary<int, ListenerData>();

        ListenerData listener = CreateListenerData<T>();
        listener.type = type;
        listener.always = always;
        listener.callback = callback;
        listenerDic.Add(type, listener);
    }

    public void RemoveNetListener(int type)
    {
        if (listenerDic.ContainsKey(type))
        {
            listenerDic.Remove(type);
        }
    }

    private ListenerData CreateListenerData<T>()
    {
        //var item = PoolManager.Instance.GetObject<ListenerData>(false);
        //if (item == null)
        //    item = new ListenerData();
        var item = new ListenerData<T>();
        return item;
    }

    private class ListenerData<T> : ListenerData
    {
        public T data;

        public override void SetData(object d)
        {
            data = PbHelper.ProtoDeSerialize<T>(d as byte[]);//在这里统一反序列化
            if (Config.EnableNetLog)//排除心跳包和Error
            {
                if (type == (int)protobuf.messagecode.MessageCode.S_PING || type == (int)protobuf.messagecode.MessageCode.S_EXCEPTION) return;
                Debug.Log("服务器返回>>> MsgId: " + type + " Body: " + ADK.StringUtil.SerializeObject(data));
            }
        }

        public override void Call()
        {
            if (callback is Action<T>)
                ((Action<T>)callback)(data);
            else if (callback is Action<object>)
                ((Action<object>)callback)(data);
            else if (callback is Action)
                ((Action)callback)();
            else
                Debug.LogErrorFormat("协议={0}，回调方法{1},委托类型不对{2}", type, callback?.Method?.Name, callback?.ToString());
        }
    }

    private class ListenerData
    {
        public int type;
        public bool always;
        public Delegate callback;

        public virtual void SetData(object d)
        {

        }

        public virtual void Call()
        {

        }
    }
}
