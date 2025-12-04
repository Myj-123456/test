using System.Collections;
using System.Collections.Generic;
using protobuf.guild;
using protobuf.messagecode;
using UnityEngine;

public class WorldChatController : BaseController<WorldChatController>
{
    protected override void InitListeners()
    {
        //世界频道发送聊天消息
        AddNetListener<S_MSG_WORLD_CHAT>((int)MessageCode.S_MSG_WORLD_CHAT, WorldChat);
        //收到世界频道聊天信息，发送用户也会收到
        AddNetListener<S_MSG_WORLD_RECEIVE_CHAT>((int)MessageCode.S_MSG_WORLD_RECEIVE_CHAT, WorldReceiveChat);
        //世界频道历史聊天记录
        AddNetListener<S_MSG_WORLD_CHAT_HISTORY>((int)MessageCode.S_MSG_WORLD_CHAT_HISTORY, WorldChatHistory);
    }

    public void WorldChat(S_MSG_WORLD_CHAT data)
    {

    }

    public void ReqWorldChat(I_SEND_CHAT_VO chatContent)
    {
        C_MSG_WORLD_CHAT c_MSG_WORLD_CHAT = new C_MSG_WORLD_CHAT();
        c_MSG_WORLD_CHAT.chatContent = chatContent;
        ChatNetWorkManager.Instance.Send((int)MessageCode.C_MSG_WORLD_CHAT, c_MSG_WORLD_CHAT);
    }
    //收到世界频道聊天信息，发送用户也会收到
    public void WorldReceiveChat(S_MSG_WORLD_RECEIVE_CHAT data)
    {
        var chatInfo = new S_MSG_GUILD_RECEIVE_CHAT();
        chatInfo.userInfo = data.userInfo;
        chatInfo.chatContent = data.chatContent;
        chatInfo.operateTime = data.operateTime;
        WorldChatModel.Instance.chatHistory.Add(chatInfo);
        DispatchEvent(ChatEvent.WorldReceiveChat);
    }
    //世界频道历史聊天记录
    public void WorldChatHistory(S_MSG_WORLD_CHAT_HISTORY data)
    {
        WorldChatModel.Instance.chatHistory = data.chatHistory;
        WorldChatModel.Instance.chatHistory.Reverse();
        DispatchEvent(ChatEvent.WorldChatHistory);
    }

    public void ReqWorldChatHistory(uint page)
    {
        C_MSG_WORLD_CHAT_HISTORY c_MSG_WORLD_CHAT_HISTORY = new C_MSG_WORLD_CHAT_HISTORY();
        c_MSG_WORLD_CHAT_HISTORY.page = page;
        ChatNetWorkManager.Instance.Send((int)MessageCode.C_MSG_WORLD_CHAT_HISTORY, c_MSG_WORLD_CHAT_HISTORY);
    }
}
