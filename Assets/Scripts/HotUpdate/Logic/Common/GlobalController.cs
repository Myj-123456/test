using protobuf.common;
using protobuf.messagecode;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTimer;

public enum ErrorCode
{
    Code_1201 = 1201,//�û�token����Ϊ��
    Code_1202 = 1202,//token�������ʧЧ 
    Code_1203 = 1203,//���������ͻ��˵�¼
    Code_3013 = 3013,//����ͨ��ʵ����֤��
    Code_3014 = 3014,//������ ��ʾδ�����˲��ڿ�����Ϸ��ʱ����
    Code_3021 = 3021,//������ ��ʾδ�����˲��ڿ�����Ϸ��ʱ����
    Code_3022 = 3022,//������ ��ʾδ�����˲��ڿ�����Ϸ��ʱ����
    Code_3023 = 3023,//������ ��ʾδ�����˲��ڿ�����Ϸ��ʱ����
    Code_4414 = 4414,//������ ��ֵ��ʾ
    Code_1102 = 1102//�������쳣�������½�����Ϸ
}

/// <summary>
/// ͨ�ÿ�����
/// </summary>
public class GlobalController : BaseController<GlobalController>
{
    private uint heartBeatInterval = 30;//�������

    private bool runningGameServerHeartBeat = false;//�Ƿ�������Ϸ��������
    private bool runningChatServerHeartBeat = false;//�Ƿ����������������

    private Timer timer;
    private Timer timer2;
    private float reqStartTime = 0;//����ʼʱ��
    private float reqEndTime = 0;//�������ʱ��

    protected override void InitListeners()
    {
        AddNetListener<S_Exception>((int)MessageCode.S_EXCEPTION, ResException);
        AddNetListener<S_PING>((int)MessageCode.S_PING, ResHeartBeatPong);
    }

    private void ResException(S_Exception exception)
    {
        Debug.LogError("�յ����ش����� code:" + exception.code);
        if (!string.IsNullOrEmpty(exception.message))
        {
            if (exception.code == (uint)ErrorCode.Code_4414)
            {
                ADK.UILogicUtils.ShowConfirm(exception.message, null, null, false);
            }
            else if (exception.message.Contains("Duplicate entry") && exception.message.Contains("el_crony2.PRIMARY"))
            {
                // 处理密友关系主键重复错误
                ADK.UILogicUtils.ShowNotice("该好友已经是您的密友");
                // 刷新密友列表，确保客户端数据与服务器一致
                FriendController.Instance.ReqCronyList();
            }
            else
            {
                ADK.UILogicUtils.ShowNotice(exception.message);
            }
            Debug.LogError("message:" + exception.message);
        }
        else//������ڶ�Ӧ���ã���ȡ������ʾ
        {
            ADK.UILogicUtils.ShowNotice("������:" + exception.code);
        }
        if (!string.IsNullOrEmpty(exception.trace))
        {
            Debug.LogError("trace:" + exception.trace);
        }
        if (exception.code == (uint)ErrorCode.Code_1102)//�������쳣�������½�����Ϸ 
        {
            NetWorkManager.Instance.Clear();//�����ر�socket
            ChatNetWorkManager.Instance.Clear();//�����ر�socket
            ReConnectManager.Instance.StopReConnect();//ֹͣ����
            ChatReConnectManager.Instance.StopReConnect();//ֹͣ����
            StopHeartBeat();//�ر�������
            StopChatServerHeartBeat();
            ADK.UILogicUtils.ShowConfirm(exception.message, ReLoadGame, null, false);
        }
        else if(exception.code == (uint)ErrorCode.Code_1201)//�û�token����Ϊ�� 
        {
            NetWorkManager.Instance.Clear();//�����ر�socket
            ChatNetWorkManager.Instance.Clear();//�����ر�socket
            ReConnectManager.Instance.StopReConnect();//ֹͣ����
            ChatReConnectManager.Instance.StopReConnect();//ֹͣ����
            StopHeartBeat();//�ر�������
            StopChatServerHeartBeat();
            ADK.UILogicUtils.ShowConfirm(exception.message, ReLoadGame, null, false);
        }
        else if (exception.code == (uint)ErrorCode.Code_1202)//token�������ʧЧ 
        {
            NetWorkManager.Instance.Clear();//�����ر�socket
            ChatNetWorkManager.Instance.Clear();//�����ر�socket
            ReConnectManager.Instance.StopReConnect();//ֹͣ����
            ChatReConnectManager.Instance.StopReConnect();//ֹͣ����
            StopHeartBeat();//�ر�������
            StopChatServerHeartBeat();
            ADK.UILogicUtils.ShowConfirm(Lang.GetValue("text_fang_tips10"), ReLoadGame, null, false);
        }
        else if (exception.code == (uint)ErrorCode.Code_1203)//������
        {
            NetWorkManager.Instance.Clear();//�����ر�socket
            ChatNetWorkManager.Instance.Clear();//�����ر�socket
            ReConnectManager.Instance.StopReConnect();//ֹͣ����
            ChatReConnectManager.Instance.StopReConnect();//ֹͣ����
            StopHeartBeat();//�ر�������
            StopChatServerHeartBeat();
            ADK.UILogicUtils.ShowConfirm(Lang.GetValue("text_fang_tips11"), ReLoadGame, null, false);
        }
        else if (exception.code == (uint)ErrorCode.Code_3014 || exception.code == (uint)ErrorCode.Code_3021 || exception.code == (uint)ErrorCode.Code_3022 || exception.code == (uint)ErrorCode.Code_3023)//������ ��ʾδ�����˲��ڿ�����Ϸ��ʱ����
        {
            NetWorkManager.Instance.Clear();//�����ر�socket
            ChatNetWorkManager.Instance.Clear();//�����ر�socket
            ReConnectManager.Instance.StopReConnect();//ֹͣ����
            ChatReConnectManager.Instance.StopReConnect();//ֹͣ����
            StopHeartBeat();//�ر�������
            StopChatServerHeartBeat();
            var tips = Lang.GetValue("error_" + exception.code);
            ADK.UILogicUtils.ShowConfirm(tips, ADK.ADKTool.QuitGame, null, false);
        }
        else if (exception.code == (uint)ErrorCode.Code_3013)//����ͨ��ʵ����֤
        {
            NetWorkManager.Instance.Clear();//�����ر�socket
            ChatNetWorkManager.Instance.Clear();//�����ر�socket
            ReConnectManager.Instance.StopReConnect();//ֹͣ����
            ChatReConnectManager.Instance.StopReConnect();//ֹͣ����
            StopHeartBeat();//�ر�������
            StopChatServerHeartBeat();
            ADK.UILogicUtils.ShowConfirm(exception.message, ADK.ADKTool.QuitGame, null, false);
        }
    }

    /// <summary>
    /// ������Ϸ
    /// </summary>
    private void ReLoadGame()
    {
        Debug.Log("���������Ϸ");
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
    /// ���������������
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
    /// �ر������������
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
    /// ���������ذ�
    /// </summary>
    private void ReqHeartBeatPing(bool isGameServer)
    {
        reqStartTime = Time.realtimeSinceStartup;
        C_PING c_PING = new C_PING();
        if (isGameServer)//��Ϸ��
        {
            if (!runningGameServerHeartBeat) return;
            Debug.Log("������Ϸ��������");
            SendCmd((int)MessageCode.C_PING, c_PING);
        }
        else//�����
        {
            if (!runningChatServerHeartBeat) return;
            Debug.Log("���������������");
            ChatNetWorkManager.Instance.Send((int)MessageCode.C_PING, c_PING);
        }
    }

    //�յ������ذ�
    private void ResHeartBeatPong(S_PING s_PING)
    {
        Debug.Log("�յ�������");
        reqEndTime = Time.realtimeSinceStartup;
        var halfRtt = (reqEndTime - reqStartTime) / 2;
        ServerTime.UpdateServerTime(s_PING.serverTime, halfRtt);
    }

}
