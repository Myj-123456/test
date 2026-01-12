using System.Collections;
using System.Collections.Generic;
using protobuf.common;
using protobuf.guild;
using UnityEngine;
using static protobuf.guild.S_MSG_WORLD_CHAT_HISTORY;

public class WorldChatModel : Singleton<WorldChatModel>
{
    public List<I_WORLD_CHAT_HISTORY_VO> chatHistory;

    public Dictionary<uint, I_USER_PROFILE> userInfos;//用户信息

    public I_USER_PROFILE GetUserInfo(uint userId)
    {
        if (userInfos.ContainsKey(userId))
        {
            return userInfos[userId];
        }
        return null;
    }
    public void AddUserInfo(I_USER_PROFILE data)
    {
        if (userInfos.ContainsKey(data.userId))
        {
            userInfos[data.userId] = data;
        }
        else
        {
            userInfos.Add(data.userId, data);
        }
    }
}

