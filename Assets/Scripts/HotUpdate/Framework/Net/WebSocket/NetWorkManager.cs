
using System;
using UnityWebSocket;
using UnityEngine;
using System.Text;

/// <summary>
/// 网络管理器
/// </summary>
public partial class NetWorkManager : Singleton<NetWorkManager>
{
    private WebSocket socket;
    private Action connectSuccess;
    private Action connectFail;
    private Action OnCloseCall;
    public void Connect(string serverAddress, Action connectSuccess, Action connectFail = null, Action OnCloseCall = null)
    {
        Debug.Log("连接游戏服,serverAddress：" + serverAddress);
        Clear();//清除旧状态
        this.connectSuccess = connectSuccess;
        this.connectFail = connectFail;
        this.OnCloseCall = OnCloseCall;
        InitSocket(serverAddress);
        socket.ConnectAsync();
    }

    /// <summary>
    /// 重连
    /// </summary>
    /// <param name="serverAddress"></param>
    /// <param name="connectSuccess"></param>
    /// <param name="connectFail"></param>
    /// <param name="OnCloseCall"></param>
    public void ReConnect(string serverAddress, Action connectSuccess, Action connectFail = null, Action OnCloseCall = null)
    {
        Clear();//清除旧状态
        this.connectSuccess = connectSuccess;
        this.connectFail = connectFail;
        this.OnCloseCall = OnCloseCall;
        InitSocket(serverAddress);
        socket.ConnectAsync();
    }

    private void InitSocket(string address)
    {
        if (socket == null)
            socket = new WebSocket(address);
        // 注册回调
        socket.OnOpen += OnOpen;
        socket.OnClose += OnClose;
        socket.OnMessage += OnMessage;
        socket.OnError += OnError;
    }

    public void Clear()
    {
        if (socket != null)
        {
            Close();
            socket.OnOpen -= OnOpen;
            socket.OnClose -= OnClose;
            socket.OnMessage -= OnMessage;
            socket.OnError -= OnError;
            socket = null;
        }
        this.connectSuccess = null;
        this.connectFail = null;
        this.OnCloseCall = null;
    }

    public void Send<T>(ushort msgId, T msg) where T : class
    {
        if (socket == null || socket.ReadyState != WebSocketState.Open)
            return;

        var pbMsg = PbHelper.ProtoSerialize(msg);
        if (Config.EnableNetLog && msgId != (ushort)protobuf.messagecode.MessageCode.C_PING)//排除心跳包
        {
            Debug.Log("前端请求>>> MsgId: " + msgId + " Body: " + ADK.StringUtil.SerializeObject(msg));
        }
        var packData = PackHelper.Pack(msgId, pbMsg);
        if (packData != null && packData.Length > 0)
        {
            socket.SendAsync(packData);
        }
    }

    /// <summary>
    /// 是否连接了
    /// </summary>
    public bool isConnected
    {
        get
        {
            if (socket != null)
            {
                return socket.ReadyState == WebSocketState.Open;
            }
            return false;
        }
    }

    public void Close()
    {
        if (socket != null && socket.ReadyState != WebSocketState.Closed)
        {
            socket.CloseAsync();
        }
    }

    /// <summary>
    /// 是否需要开启检测重连
    /// 只有存在socket对象并且当前断开的情况下才需要发起重连
    /// </summary>
    /// <returns></returns>
    public bool CheckIsNeedReConnect
    {
        get
        {
            if (socket == null) return false;
            return socket.ReadyState != WebSocketState.Open;
        }
    }

    private void OnOpen(object sender, OpenEventArgs e)
    {
        connectSuccess?.Invoke();
    }

    private void OnClose(object sender, CloseEventArgs e)
    {
        Debug.LogError("游戏服WebSocket触发OnClose,Code:" + e.Code + " Reason:" + e.Reason);
        OnCloseCall?.Invoke();
    }

    private void OnMessage(object sender, MessageEventArgs e)
    {
        if (e.IsBinary)
        {
            PackHelper.UnPack(e.RawData);
        }
        else if (e.IsText)
        {
            Debug.Log(e.Data.ToString());
        }
    }
    private void OnError(object sender, ErrorEventArgs e)
    {
        Debug.LogError("游戏服WebSocket触发OnError:" + e.Message);
        connectFail?.Invoke();
    }
}

