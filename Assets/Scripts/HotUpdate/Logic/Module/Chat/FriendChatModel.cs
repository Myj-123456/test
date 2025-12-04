using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using protobuf.common;
using protobuf.guild;
using UnityEngine;
using static protobuf.guild.S_MSG_FRIEND_CHAT_HISTORY;

public class FriendChatModel : Singleton<FriendChatModel>
{
    public List<I_USER_PROFILE> contractUserInfos = new List<I_USER_PROFILE>();

    public List<FriendChatData> friendChatDatas = new List<FriendChatData>();

    private List<Ft_emojiConfig> _emojieList;
    public List<Ft_emojiConfig> emojieList { get
        {
            if(_emojieList == null)
            {
                var emojieData = ConfigManager.Instance.GetConfig<Ft_emojiConfigData>("ft_emojisConfig");
                _emojieList = emojieData.DataList;
            }
            return _emojieList;
        } }

    public Ft_emojiConfig GetEmojieInfo(int id)
    {
        return emojieList.Find(value => value.Id == id);
    }
    public void CreateFriendContract(I_USER_PROFILE data)
    {
        contractUserInfos.Add(data);
    }

    public I_USER_PROFILE GetUserInfo(uint friendId)
    {
        return contractUserInfos.Find(value => value.userId == friendId);
    }

    public void FriendChatHistory(S_MSG_FRIEND_CHAT_HISTORY data)
    {
        var userInfo = GetUserInfo(data.friendId);
        var friendChat = new FriendChatData();
        friendChat.userInfo = userInfo;
        friendChat.chatHistory = data.chatHistory;
        friendChat.chatHistory.Reverse();
        friendChatDatas.Add(friendChat);
    }
    public FriendChatData GetFriendChatHistory(uint friendId)
    {
        return friendChatDatas.Find(value => value.userInfo.userId == friendId);
    }
    public void ReceiveChat(S_MSG_FRIEND_RECEIVE_CHAT data)
    {
        var friendChat = GetFriendChatHistory(data.friendId);
        if(friendChat != null)
        {
            var chat = new I_FRIEND_CHAT_HISTORY();
            chat.chatContent = data.chatContent;
            chat.operateTime = data.operateTime;
            chat.isSelf = false;
            friendChat.chatHistory.Add(chat);
        }
    }

    public void FriendChat(S_MSG_FRIEND_CHAT data)
    {
        var friendChat = GetFriendChatHistory(data.friendId);
        if (friendChat != null)
        {
            var chat = new I_FRIEND_CHAT_HISTORY();
            chat.chatContent = data.chatContent;
            chat.operateTime = data.operateTime;
            chat.isSelf = true;
            friendChat.chatHistory.Add(chat);
        }
    }

    public void CreateFriendChat(uint id)
    {
        var friendChat = GetUserInfo(id);
        if(friendChat != null)
        {
            UIManager.Instance.OpenWindow<ChatMainWindow>(UIName.ChatMainWindow, (int)id);
        }
        else
        {
            ChatController.Instance.ReqCreateFriendContact(id);
        }
    }
}

public class FriendChatData
{
    public I_USER_PROFILE userInfo;
    public List<I_FRIEND_CHAT_HISTORY> chatHistory;
}

