using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 聊天服网络重连管理器
/// 如果需要再严谨点 在心跳包加个回包超时机制2*30=60s未收到回包则表示断开连接了 这种是为了兼容机房突然断电或者没网络情况下 但是一般不处理也问题不大
/// </summary>
public class ChatReConnectManager : MonoSingleton<ChatReConnectManager>
{
    private bool isStartReConnect = false;
    private const float ReconnectTime = 2.0f;//重连间隔(每隔2s发起一次)
    private const uint MaxConnectTime = 5;//最大重连次数
    private uint reConnectTime = 0;//当前已重连次数

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    //开始检测重连
    public void StarReConnect()
    {
        dt = 0;
        reConnectTime = 0;
        isStartReConnect = true;
    }

    public void StopReConnect()
    {
        isStartReConnect = false;
    }

    private float dt = 0;
    private void Update()
    {
        if (!isStartReConnect || !ChatNetWorkManager.Instance.CheckIsNeedReConnect || !LoginModel.Instance.isGameInit) return;

        dt += Time.unscaledDeltaTime;
        if (dt >= ReconnectTime + reConnectTime * 0.5f)//每隔2s去发起一次重连 每次递增0.5s
        {
            if (reConnectTime < MaxConnectTime)
            {
                reConnectTime += 1;
                ReConnect();
            }
            else//弹框提示告知玩家离线了 重试/重启app
            {
                StopReConnect();//达到最大重试次数，取消重试,直接告知玩家
                Debug.LogError("聊天服达到最大重试次数连接失败!");
                //ADK.UILogicUtils.ShowConfirm(Lang.GetValue("internet_error_tips"), ReLoadGame, null, false, false, UILayer.Top);
            }
            dt = 0;
        }
    }

    private void ReLoadGame()
    {
        Debug.Log("重启游戏");
        ADK.ADKTool.RestartApp();
    }

    private void ReConnect()
    {
        Debug.Log("聊天服重试连接中，次数:" + reConnectTime);
        LoginController.Instance.ReConnectChatServer();
    }
}
