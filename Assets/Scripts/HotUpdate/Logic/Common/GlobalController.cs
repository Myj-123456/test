using protobuf.common;
using protobuf.messagecode;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTimer;

public enum ErrorCode
{
    Code_1201 = 1201,//用户token不能为空
    Code_1202 = 1202,//token错误或已失效 
    Code_1203 = 1203,//已在其他客户端登录
    Code_3013 = 3013,//请先通过实名认证。
    Code_3014 = 3014,//防沉迷 表示未成年人不在可玩游戏的时间内
    Code_3021 = 3021,//防沉迷 表示未成年人不在可玩游戏的时间内
    Code_3022 = 3022,//防沉迷 表示未成年人不在可玩游戏的时间内
    Code_3023 = 3023,//防沉迷 表示未成年人不在可玩游戏的时间内
    Code_4414 = 4414,//防沉迷 充值提示
    Code_1102 = 1102//服务器异常，请重新进入游戏
}

/// <summary>
/// 通用控制器
/// </summary>
public class GlobalController : BaseController<GlobalController>
{
    private uint heartBeatInterval = 30;//心跳间隔

    private bool runningGameServerHeartBeat = false;//是否启动游戏服心跳包
    private bool runningChatServerHeartBeat = false;//是否启动聊天服心跳包

    private Timer timer;
    private Timer timer2;
    private float reqStartTime = 0;//请求开始时间
    private float reqEndTime = 0;//请求结束时间

    protected override void InitListeners()
    {
        AddNetListener<S_Exception>((int)MessageCode.S_EXCEPTION, ResException);
        AddNetListener<S_PING>((int)MessageCode.S_PING, ResHeartBeatPong);
    }

    private void ResException(S_Exception exception)
    {
        Debug.LogError("收到返回错误码 code:" + exception.code);
        if (!string.IsNullOrEmpty(exception.message))
        {
            if (exception.code == (uint)ErrorCode.Code_4414)
            {
                ADK.UILogicUtils.ShowConfirm(exception.message, null, null, false);
            }
            else
            {
                ADK.UILogicUtils.ShowNotice(exception.message);
            }
            Debug.LogError("message:" + exception.message);
        }
        else//如果存在对应配置，读取配置显示
        {
            ADK.UILogicUtils.ShowNotice(Lang.GetValue("error_name") + exception.code);
        }
        if (!string.IsNullOrEmpty(exception.trace))
        {
            Debug.LogError("trace:" + exception.trace);
        }
        if (exception.code == (uint)ErrorCode.Code_1102)//服务器异常，请重新进入游戏 
        {
            NetWorkManager.Instance.Clear();//主动关闭socket
            ChatNetWorkManager.Instance.Clear();//主动关闭socket
            ReConnectManager.Instance.StopReConnect();//停止重连
            ChatReConnectManager.Instance.StopReConnect();//停止重连
            StopHeartBeat();//关闭心跳包
            StopChatServerHeartBeat();
            ADK.UILogicUtils.ShowConfirm(exception.message, ReLoadGame, null, false);
        }
        else if (exception.code == (uint)ErrorCode.Code_1201)//用户token不能为空 
        {
            NetWorkManager.Instance.Clear();//主动关闭socket
            ChatNetWorkManager.Instance.Clear();//主动关闭socket
            ReConnectManager.Instance.StopReConnect();//停止重连
            ChatReConnectManager.Instance.StopReConnect();//停止重连
            StopHeartBeat();//关闭心跳包
            StopChatServerHeartBeat();
            ADK.UILogicUtils.ShowConfirm(exception.message, ReLoadGame, null, false);
        }
        else if (exception.code == (uint)ErrorCode.Code_1202)//token错误或已失效 
        {
            NetWorkManager.Instance.Clear();//主动关闭socket
            ChatNetWorkManager.Instance.Clear();//主动关闭socket
            ReConnectManager.Instance.StopReConnect();//停止重连
            ChatReConnectManager.Instance.StopReConnect();//停止重连
            StopHeartBeat();//关闭心跳包
            StopChatServerHeartBeat();
            ADK.UILogicUtils.ShowConfirm(Lang.GetValue("text_fang_tips10"), ReLoadGame, null, false);
        }
        else if (exception.code == (uint)ErrorCode.Code_1203)//顶号了
        {
            NetWorkManager.Instance.Clear();//主动关闭socket
            ChatNetWorkManager.Instance.Clear();//主动关闭socket
            ReConnectManager.Instance.StopReConnect();//停止重连
            ChatReConnectManager.Instance.StopReConnect();//停止重连
            StopHeartBeat();//关闭心跳包
            StopChatServerHeartBeat();
            ADK.UILogicUtils.ShowConfirm(Lang.GetValue("text_fang_tips11"), ReLoadGame, null, false);
        }
        else if (exception.code == (uint)ErrorCode.Code_3014 || exception.code == (uint)ErrorCode.Code_3021 || exception.code == (uint)ErrorCode.Code_3022 || exception.code == (uint)ErrorCode.Code_3023)//防沉迷 表示未成年人不在可玩游戏的时间内
        {
            NetWorkManager.Instance.Clear();//主动关闭socket
            ChatNetWorkManager.Instance.Clear();//主动关闭socket
            ReConnectManager.Instance.StopReConnect();//停止重连
            ChatReConnectManager.Instance.StopReConnect();//停止重连
            StopHeartBeat();//关闭心跳包
            StopChatServerHeartBeat();
            var tips = Lang.GetValue("error_" + exception.code);
            ADK.UILogicUtils.ShowConfirm(tips, ADK.ADKTool.QuitGame, null, false);
        }
        else if (exception.code == (uint)ErrorCode.Code_3013)//请先通过实名认证
        {
            NetWorkManager.Instance.Clear();//主动关闭socket
            ChatNetWorkManager.Instance.Clear();//主动关闭socket
            ReConnectManager.Instance.StopReConnect();//停止重连
            ChatReConnectManager.Instance.StopReConnect();//停止重连
            StopHeartBeat();//关闭心跳包
            StopChatServerHeartBeat();
            ADK.UILogicUtils.ShowConfirm(exception.message, ADK.ADKTool.QuitGame, null, false);
        }
    }

    /// <summary>
    /// 重启游戏
    /// </summary>
    private void ReLoadGame()
    {
        Debug.Log("点击重启游戏");
        ADK.ADKTool.RestartApp();
    }

    private void OnTick()
    {
        ReqHeartBeatPing(true);
    }

    public void StartHeartBeat()
    {
        runningGameServerHeartBeat = true;
        if (timer != null)
        {
            timer.Cancel();
            timer = null;
        }
        timer = Timer.RegistGlobal(heartBeatInterval, OnTick, true);
    }


    public void StopHeartBeat()
    {
        runningGameServerHeartBeat = false;
        if (timer != null)
        {
            timer.Cancel();
            timer = null;
        }
    }

    /// <summary>
    /// 开启聊天服心跳包
    /// </summary>
    public void StartChatServerHeartBeat()
    {
        runningChatServerHeartBeat = true;
        if (timer2 != null)
        {
            timer2.Cancel();
            timer2 = null;
        }
        timer2 = Timer.RegistGlobal(heartBeatInterval, OnTick2, true);
    }

    private void OnTick2()
    {
        ReqHeartBeatPing(false);
    }

    /// <summary>
    /// 关闭聊天服心跳包
    /// </summary>
    public void StopChatServerHeartBeat()
    {
        runningChatServerHeartBeat = false;
        if (timer2 != null)
        {
            timer2.Cancel();
            timer2 = null;
        }
    }

    /// <summary>
    /// 发送心跳回包
    /// </summary>
    private void ReqHeartBeatPing(bool isGameServer)
    {
        reqStartTime = Time.realtimeSinceStartup;
        C_PING c_PING = new C_PING();
        if (isGameServer)//游戏服
        {
            if (!runningGameServerHeartBeat) return;
            Debug.Log("发送游戏服心跳包");
            SendCmd((int)MessageCode.C_PING, c_PING);
        }
        else//聊天服
        {
            if (!runningChatServerHeartBeat) return;
            Debug.Log("发送聊天服心跳包");
            ChatNetWorkManager.Instance.Send((int)MessageCode.C_PING, c_PING);
        }
    }

    //收到心跳回包
    private void ResHeartBeatPong(S_PING s_PING)
    {
        Debug.Log("收到心跳包");
        reqEndTime = Time.realtimeSinceStartup;
        var halfRtt = (reqEndTime - reqStartTime) / 2;
        ServerTime.UpdateServerTime(s_PING.serverTime, halfRtt);
    }

}
