using System.Collections;
using System.Collections.Generic;
using protobuf.guild;
using protobuf.messagecode;
using UnityEngine;

public class ChatController : BaseController<ChatController>
{
    protected override void InitListeners()
    {
        //历史聊天（只保留最近30天）
        AddNetListener<S_MSG_GUILD_CHAT_HISTORY>((int)MessageCode.S_MSG_GUILD_CHAT_HISTORY, GuildChatHistory);
        //发送聊天
        AddNetListener<S_MSG_GUILD_CHAT>((int)MessageCode.S_MSG_GUILD_CHAT, GuildChat);
        //收到社团其他成员的聊天信息，发送用户也会收到
        AddNetListener<S_MSG_GUILD_RECEIVE_CHAT>((int)MessageCode.S_MSG_GUILD_RECEIVE_CHAT, GuildReceiveChat);
        //创建好友私聊联系人
        AddNetListener<S_MSG_CREATE_FRIEND_CONTACT>((int)MessageCode.S_MSG_CREATE_FRIEND_CONTACT,CreateFriendContact);
        //获取好友私聊联系人
        AddNetListener<S_MSG_FRIEND_CONTACT>((int)MessageCode.S_MSG_FRIEND_CONTACT, FriendContact);
        //好友频道历史聊天记录
        AddNetListener<S_MSG_FRIEND_CHAT_HISTORY>((int)MessageCode.S_MSG_FRIEND_CHAT_HISTORY, FriendChatHisTory);
        //收到好友频道聊天信息
        AddNetListener<S_MSG_FRIEND_RECEIVE_CHAT>((int)MessageCode.S_MSG_FRIEND_RECEIVE_CHAT, FriendReceiveChat);
        //好友频道发送聊天
        AddNetListener<S_MSG_FRIEND_CHAT>((int)MessageCode.S_MSG_FRIEND_CHAT, FriendChat);
        //删除与好友的聊天会话
        AddNetListener<S_MSG_DEL_FRIEND_CONTACT>((int)MessageCode.S_MSG_DEL_FRIEND_CONTACT, DelFriendContact);
    }

    public void GuildChatHistory(S_MSG_GUILD_CHAT_HISTORY data)
    {
        ChatModel.Instance.chatHistory = data.chatHistory;
        ChatModel.Instance.chatHistory.Reverse();
        EventManager.Instance.DispatchEvent(ChatEvent.GuildChatHistory);
    }

    public void ReqGuildChatHistory()
    {
        C_MSG_GUILD_CHAT_HISTORY c_MSG_GUILD_CHAT_HISTORY = new C_MSG_GUILD_CHAT_HISTORY();
        //SendCmd((int)MessageCode.C_MSG_GUILD_CHAT_HISTORY, c_MSG_GUILD_CHAT_HISTORY);
        ChatNetWorkManager.Instance.Send((int)MessageCode.C_MSG_GUILD_CHAT_HISTORY, c_MSG_GUILD_CHAT_HISTORY);
    }

    public void GuildChat(S_MSG_GUILD_CHAT data)
    {
        //ChatModel.Instance.UpdateMyChat(data.content);
        //EventManager.Instance.DispatchEvent(ChatEvent.GuildChat);
    }

    public void ReqGuildChat(I_SEND_CHAT_VO content)
    {
        C_MSG_GUILD_CHAT c_MSG_GUILD_CHAT = new C_MSG_GUILD_CHAT();
        c_MSG_GUILD_CHAT.chatContent = content;
        ChatNetWorkManager.Instance.Send((int)MessageCode.C_MSG_GUILD_CHAT, c_MSG_GUILD_CHAT);
    }

    public void GuildReceiveChat(S_MSG_GUILD_RECEIVE_CHAT data)
    {
        ChatModel.Instance.UpdateChatInfo(data);
        EventManager.Instance.DispatchEvent(ChatEvent.GuildChat);
    }
    //创建好友私聊联系人
    public void CreateFriendContact(S_MSG_CREATE_FRIEND_CONTACT data)

    {
        FriendChatModel.Instance.CreateFriendContract(data.contractUserInfo);
        UIManager.Instance.OpenWindow<ChatMainWindow>(UIName.ChatMainWindow, (int)data.contractUserInfo.userId);
        EventManager.Instance.DispatchEvent(ChatEvent.CreateFriendContact);
    }

    public void ReqCreateFriendContact(uint friendId)
    {
        C_MSG_CREATE_FRIEND_CONTACT c_MSG_CREATE_FRIEND_CONTACT = new C_MSG_CREATE_FRIEND_CONTACT();
        c_MSG_CREATE_FRIEND_CONTACT.friendId = friendId;
        ChatNetWorkManager.Instance.Send((int)MessageCode.C_MSG_CREATE_FRIEND_CONTACT, c_MSG_CREATE_FRIEND_CONTACT);
    }
    //获取好友私聊联系人
    public void FriendContact(S_MSG_FRIEND_CONTACT data)
    {
        FriendChatModel.Instance.contractUserInfos = data.contractUserInfos;
        EventManager.Instance.DispatchEvent(ChatEvent.FriendContact);
    }

    public void ReqFriendContact()
    {
        C_MSG_FRIEND_CONTACT c_MSG_FRIEND_CONTACT = new C_MSG_FRIEND_CONTACT();
        ChatNetWorkManager.Instance.Send((int)MessageCode.C_MSG_FRIEND_CONTACT, c_MSG_FRIEND_CONTACT);
    }
    //好友频道历史聊天记录
    public void FriendChatHisTory(S_MSG_FRIEND_CHAT_HISTORY data)
    {
        FriendChatModel.Instance.FriendChatHistory(data);
        EventManager.Instance.DispatchEvent(ChatEvent.FriendChatHisTory);
    }

    public void ReqFriendChatHisTory(uint friendId,uint page = 1)
    {
        C_MSG_FRIEND_CHAT_HISTORY c_MSG_FRIEND_CHAT_HISTORY = new C_MSG_FRIEND_CHAT_HISTORY();
        c_MSG_FRIEND_CHAT_HISTORY.friendId = friendId;
        c_MSG_FRIEND_CHAT_HISTORY.page = page;
        ChatNetWorkManager.Instance.Send((int)MessageCode.C_MSG_FRIEND_CHAT_HISTORY, c_MSG_FRIEND_CHAT_HISTORY);
    }



    //好友频道发送聊天
    public void ReqFriendChat(uint friendId, I_SEND_CHAT_VO chatContent)
    {
        C_MSG_FRIEND_CHAT c_MSG_FRIEND_CHAT = new C_MSG_FRIEND_CHAT();
        c_MSG_FRIEND_CHAT.friendId = friendId;
        c_MSG_FRIEND_CHAT.chatContent = chatContent;
        ChatNetWorkManager.Instance.Send((int)MessageCode.C_MSG_FRIEND_CHAT, c_MSG_FRIEND_CHAT);
    }
    public void FriendChat(S_MSG_FRIEND_CHAT data)
    {
        FriendChatModel.Instance.FriendChat(data);
        EventManager.Instance.DispatchEvent(ChatEvent.FriendChat);
    }

    //收到好友频道聊天信息
    public void FriendReceiveChat(S_MSG_FRIEND_RECEIVE_CHAT data)
    {
        FriendChatModel.Instance.ReceiveChat(data);
        EventManager.Instance.DispatchEvent(ChatEvent.FriendReceiveChat,data.friendId);
    }
    //删除与好友的聊天会话
    public void DelFriendContact(S_MSG_DEL_FRIEND_CONTACT data)
    {
        var userInfo = FriendChatModel.Instance.GetUserInfo(data.friendId);
        var friendChat = FriendChatModel.Instance.GetFriendChatHistory(data.friendId);
        FriendChatModel.Instance.friendChatDatas.Remove(friendChat);
        FriendChatModel.Instance.contractUserInfos.Remove(userInfo);
        EventManager.Instance.DispatchEvent(ChatEvent.DelFriendContact);
    }
    public void ReqDelFriendContact(uint friendId)
    {
        C_MSG_DEL_FRIEND_CONTACT c_MSG_DEL_FRIEND_CONTACT = new C_MSG_DEL_FRIEND_CONTACT();
        c_MSG_DEL_FRIEND_CONTACT.friendId = friendId;
        ChatNetWorkManager.Instance.Send((int)MessageCode.C_MSG_DEL_FRIEND_CONTACT, c_MSG_DEL_FRIEND_CONTACT);
    }
}
