using System.Collections;
using System.Collections.Generic;
using protobuf.guild;
using UnityEngine;

public class WorldChatModel : Singleton<WorldChatModel>
{
    public List<S_MSG_GUILD_RECEIVE_CHAT> chatHistory;
}

