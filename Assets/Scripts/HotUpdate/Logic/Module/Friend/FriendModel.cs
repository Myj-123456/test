using System.Collections;
using System.Collections.Generic;
using protobuf.common;
using protobuf.friend;
using protobuf.messagecode;
using protobuf.plant;
using UnityEngine;
using ADK;
using static protobuf.friend.S_MSG_CRONY_LIST;

public class FriendModel : Singleton<FriendModel>
{
    public uint friendCount;
    public List<I_FRIEND_PROFILE> friendList = new List<I_FRIEND_PROFILE>();
    public List<I_USER_PROFILE> applyList = new List<I_USER_PROFILE>();
    public List<I_USER_PROFILE> blackList = new List<I_USER_PROFILE>();
    public List<I_USER_PROFILE> recommendList = new List<I_USER_PROFILE>();
    // 存储好友关系建立时间
    public Dictionary<uint, uint> friendRelationTime = new Dictionary<uint, uint>();

    public List<I_CRONY_VO> cronyList = new List<I_CRONY_VO>();//密友列表
    public uint unlockCronyCnt = 2; // 已解锁的密友位数量，初始为2

    public List<uint> applyUserIds = new List<uint>();//申请加我为密友的好友id
    // 存储密友申请时间
    public Dictionary<uint, uint> applyTimeDictionary = new Dictionary<uint, uint>();
    // 记录当前正在发送申请的好友ID，防止重复发送申请
    private Dictionary<uint, bool> isApplyingDictionary = new Dictionary<uint, bool>();

    public List<uint> blackUserIds = new List<uint>();//屏蔽的好友id

    public S_MSG_FRIEND_STEAL_MESSAGE friendStealMsg;

    public void AddBlackId(uint id)
    {
        if(blackUserIds.IndexOf(id) == -1)
        {
            blackUserIds.Add(id);
        }
    }
    public void RemoveBlackId(uint id)
    {
        var index = blackUserIds.IndexOf(id);
        if(index != -1)
        {
            blackUserIds.RemoveAt(index);
        }
    }
    public void AddApplyListToFriendList(uint[] friendIds)
    {
        foreach (uint id in friendIds)
        {
            I_FRIEND_PROFILE friendData = new I_FRIEND_PROFILE();
            int index = GetApplyListIndex(id);
            if (index == -1)
            {
                return;
            }
            I_USER_PROFILE applyData = applyList[index];
            friendData.userId = applyData.userId;
            friendData.userLevel = applyData.userLevel;
            friendData.townName = applyData.townName;
            friendData.headImgId = applyData.headImgId;
            friendData.headFrame = applyData.headFrame;
            //friendData.flowerLevel = applyData.flowerLevel;
            //friendData.flowerLevelExpireTime = applyData.flowerLevelExpireTime;
            friendData.lastLoginTime = applyData.lastLoginTime;
            friendData.isMark = false;
            friendData.canSteal = false;
            friendList.Add(friendData);
            applyList.RemoveAt(index);
            friendCount++;
            
            // 记录好友关系建立时间
            friendRelationTime[id] = MyselfModel.Instance.lastServerTime;
        }
    }

    public void RemoveApplyList(uint[] friendIds)
    {
        foreach (uint id in friendIds)
        {
            int index = GetApplyListIndex(id);
            if (index != -1)
            {
                applyList.RemoveAt(index);
            }
        }
    }

    public void RemoveRecommendList(uint[] friendIds)
    {
        if (recommendList == null) return;
        foreach (uint id in friendIds)
        {
            int index = GetRecommendListIndex(id);
            if (index != -1)
            {
                recommendList.RemoveAt(index);
            }
        }
    }

    public int GetApplyListIndex(uint id)
    {
        for (int i = 0; i < applyList.Count; i++)
        {
            if (applyList[i].userId == id)
            {
                return i;
            }
        }
        return -1;
    }

    public int GetRecommendListIndex(uint id)
    {
        for (int i = 0; i < recommendList.Count; i++)
        {
            if (recommendList[i].userId == id)
            {
                return i;
            }
        }
        return -1;
    }

    public void UpdateFriendMark(uint friendId, bool mark)
    {
        foreach (var friendData in friendList)
        {
            if (friendData.userId == friendId)
            {
                friendData.isMark = mark;
                break;
            }
        }
    }

    public I_FRIEND_PROFILE GetFriendData(uint friendId)
    {
        foreach (var friendData in friendList)
        {
            if (friendData.userId == friendId)
            {
                return friendData;
            }
        }
        return null;
    }

    public List<I_FRIEND_PROFILE> GetFriendListfilter(uint friendId)
    {
        List<I_FRIEND_PROFILE> filterFriendList = new List<I_FRIEND_PROFILE>();
        foreach (var friendData in friendList)
        {
            if (friendData.userId != friendId)
            {
                filterFriendList.Add(friendData);
            }
        }
        return filterFriendList;
    }

    public void RemoveFriendList(uint[] friendIds)
    {
        foreach (uint id in friendIds)
        {
            int index = GetFriendListIndex(id);
            if (index != -1)
            {
                friendList.RemoveAt(index);
                friendCount--;
                
                // 移除好友关系时间记录
                if (friendRelationTime.ContainsKey(id))
                {
                    friendRelationTime.Remove(id);
                }
            }
        }
    }

    public void RemoveFriend(uint friendId)
    {
        int index = GetFriendListIndex(friendId);
        if (index != -1)
        {
            friendList.RemoveAt(index);
            friendCount--;
            
            // 移除好友关系时间记录
            if (friendRelationTime.ContainsKey(friendId))
            {
                friendRelationTime.Remove(friendId);
            }
        }
    }

    public int GetFriendListIndex(uint id)
    {
        if(friendList == null)
        {
            return -1;
        }
        for (int i = 0; i < friendList.Count; i++)
        {
            if (friendList[i].userId == id)
            {
                return i;
            }
        }
        return -1;
    }

    //���ݺ���id��ȡ��������
    public I_FRIEND_PROFILE GetFriendInfo(uint friendId)
    {
        return friendList.Find(value => value.userId == friendId);
    }

    public void AddFriendListToBlackList(uint[] friendIds)
    {
        foreach (uint id in friendIds)
        {
            int index = GetFriendListIndex(id);
            if (index == -1)
            {
                return;
            }
            I_FRIEND_PROFILE friendData = friendList[index];
            I_USER_PROFILE blackData = new I_USER_PROFILE();
            blackData.userId = friendData.userId;
            blackData.userLevel = friendData.userLevel;
            blackData.townName = friendData.townName;
            blackData.headImgId = friendData.headImgId;
            blackData.headFrame = friendData.headFrame;
            //blackData.flowerLevel = friendData.flowerLevel;
            //blackData.flowerLevelExpireTime = friendData.flowerLevelExpireTime;
            blackData.lastLoginTime = friendData.lastLoginTime;
            blackList.Add(blackData);
            friendList.RemoveAt(index);
            friendCount--;
        }
    }

    public void RemoveBlackList(uint friendId)
    {
        
        int index = GetBlackListIndex(friendId);
        if (index != -1)
        {
            blackList.RemoveAt(index);
        }
    }

    public int GetBlackListIndex(uint id)
    {
        if(blackList == null)
        {
            return -1;
        }
        for (int i = 0; i < blackList.Count; i++)
        {
            if (blackList[i].userId == id)
            {
                return i;
            }
        }
        return -1;
    }

    public List<I_FRIEND_PROFILE> FindFriendDataArr(string str)
    {
        if (str == "")
        {
            return friendList;
        }
        var arr = new List<I_FRIEND_PROFILE>();
        foreach (var value in friendList)
        {
            if (value.userId.ToString().Contains(str) || value.townName.Contains(str))
            {
                arr.Add(value);
            }
        }
        return arr;
    }
    //��ȡ������Ϣ
    public I_CRONY_VO GetCronyData(uint friendId)
    {
        return cronyList.Find(value => value.friendId == friendId);
    }
    
    /// <summary>
    /// 检查密友关系是否正在解除中
    /// </summary>
    public bool IsCronyRelationshipCancelling(uint friendId)
    {
        if (friendId == 0) return false;
        foreach (var cronyData in cronyList)
        {
            if (cronyData.friendId == friendId)
            {
                // 检查解除时间是否有效
                if (cronyData.cancelTime <= 0) return false;
                // 密友关系正在解除中
                return true;
            }
        }
        return false;
    }
    /// <summary>
    /// 获取密友解除的剩余时间
    /// </summary>
    public int GetCronyRemainingCancelTime(uint friendId)
    {
        var cronyData = GetCronyData(friendId);
        if (cronyData == null || cronyData.cancelTime <= 0)
        {
            return 0;
        }
        uint currentServerTime = ServerTime.Time;
        if (currentServerTime <= 0)
        {
        // 使用本地缓存的服务器时间
        currentServerTime = MyselfModel.Instance.lastServerTime;
        }
        // 确保剩余时间不为负
        int remainingSeconds = Mathf.Max(0, (int)(cronyData.cancelTime - currentServerTime));
        return remainingSeconds;
    }
    // 检查好友关系是否满12小时
    public bool IsFriendRelationOver12Hours(uint friendId)
    {
        const uint twelveHoursInSeconds = 12 * 60 * 60;
        
        // 如果没有记录，返回false
        if (!friendRelationTime.ContainsKey(friendId))
        {
            return false;
        }
        uint relationStartTime = friendRelationTime[friendId];
        uint currentServerTime = MyselfModel.Instance.lastServerTime;
        uint elapsedTime = currentServerTime - relationStartTime;
        // 检查是否已满12小时
        return elapsedTime >= twelveHoursInSeconds;
    }
    // 获取好友关系剩余时间
    public uint GetFriendRelationRemainingTime(uint friendId)
    {
        const uint twelveHoursInSeconds = 12 * 60 * 60;
        
        if (!friendRelationTime.ContainsKey(friendId))
        {
            return twelveHoursInSeconds; // 如果没有记录，返回完整的12小时
        }
        uint relationStartTime = friendRelationTime[friendId];
        uint currentServerTime = MyselfModel.Instance.lastServerTime;
        uint elapsedTime = currentServerTime - relationStartTime;
        // 如果已经超过12小时，返回0
        if (elapsedTime >= twelveHoursInSeconds)
        {
            return 0;
        }
        return twelveHoursInSeconds - elapsedTime;
    }
    

    // 发送密友申请
    public void SendApplyBestFriend(uint friendId)
    {
        // 检查该好友ID是否已经在申请中，如果是则不重复发送请求
        if (isApplyingDictionary.ContainsKey(friendId) && isApplyingDictionary[friendId])
        {
            return;
        }
        
        // 标记该好友ID正在申请中
        isApplyingDictionary[friendId] = true;
        
        // 调用FriendController中的带参数方法
        FriendController.Instance.ReqCronyApply(friendId);

        uint currentServerTime = MyselfModel.Instance.lastServerTime;
        if (applyTimeDictionary.ContainsKey(friendId))
        {
            applyTimeDictionary[friendId] = currentServerTime;
        }
        else
        {
            applyTimeDictionary.Add(friendId, currentServerTime);
        }
        
        // 申请发送后，延迟一段时间清除标记（防止网络问题导致标记一直存在）
        Coroutiner.StartCoroutine(ClearApplyingFlag(friendId, 3.0f));
    }
    
    /// <summary>
    /// 清除申请标记
    /// </summary>
    /// <param name="friendId">好友ID</param>
    /// <param name="delayTime">延迟时间（秒）</param>
    /// <returns></returns>
    private IEnumerator ClearApplyingFlag(uint friendId, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        
        if (isApplyingDictionary.ContainsKey(friendId))
        {
            isApplyingDictionary[friendId] = false;
        }
    }
    
    /// <summary>
    /// 检查密友申请是否已过期
    /// </summary>
    /// <param name="friendId">好友ID</param>
    /// <returns>是否过期</returns>
    public bool IsApplyExpired(uint friendId)
    {
        if (!applyTimeDictionary.ContainsKey(friendId))
        {
            // 如果没有记录申请时间，则认为已过期
            return true;
        }
        uint applyTime = applyTimeDictionary[friendId];
        uint currentServerTime = MyselfModel.Instance.lastServerTime;
        const uint twentyFourHoursInSeconds = 24 * 60 * 60;
        
        return (currentServerTime - applyTime) >= twentyFourHoursInSeconds;
    }
    
    /// <summary>
    /// 获取密友申请剩余有效时间
    /// </summary>
    /// <param name="friendId">好友ID</param>
    /// <returns>剩余时间（格式化的字符串）</returns>
    public string GetApplyRemainingTime(uint friendId)
    {
        if (!applyTimeDictionary.ContainsKey(friendId))
        {
            return "未知";
        }
        
        uint applyTime = applyTimeDictionary[friendId];
        uint currentServerTime = MyselfModel.Instance.lastServerTime;
        const uint twentyFourHoursInSeconds = 24 * 60 * 60;
        
        uint elapsedTime = currentServerTime - applyTime;
        
        // 如果已经超过24小时，返回0
        if (elapsedTime >= twentyFourHoursInSeconds)
        {
            return "0小时0分钟";
        }
        uint remainingTime = twentyFourHoursInSeconds - elapsedTime;
        uint hours = remainingTime / 3600;
        uint minutes = (remainingTime % 3600) / 60;
        
        return $"{hours}小时{minutes}分钟";
    }
    
    /// <summary>
    /// 清理过期的密友申请
    /// </summary>
    public void CleanExpiredApplies()
    {
        List<uint> expiredFriendIds = new List<uint>();
        
        foreach (var kvp in applyTimeDictionary)
        {
            if (IsApplyExpired(kvp.Key))
            {
                expiredFriendIds.Add(kvp.Key);
            }
        }
        foreach (uint friendId in expiredFriendIds)
        {
            // 移除过期的申请记录（我发送的申请）
            applyTimeDictionary.Remove(friendId);
            // 触发申请过期事件
            EventManager.Instance.DispatchEvent(FriendEvent.ApplyExpired, friendId);
            // 发送邮件退还结书
            SendReturnCronyBookMail(friendId, true);
        }
    }
    
    /// <summary>
    /// 发送退还结书邮件
    /// </summary>
    /// <param name="friendId">好友ID</param>
    /// <param name="isExpired">是否为过期</param>
    public void SendReturnCronyBookMail(uint friendId, bool isExpired)
    {
        try
        {
            // 密友结书物品ID
            const int cronyBookItemId = 41013043;
            // 由于ItemType枚举中没有Item值，使用一个基础数值来表示物品类型
            EntityID cronyBookEntityIdObj = new EntityID(1, (long)cronyBookItemId, 0);
                ulong cronyBookEntityId = (ulong)(cronyBookEntityIdObj.action * 10000000000 + cronyBookEntityIdObj.module * 100000000 + cronyBookEntityIdObj.value);
            
            // 创建邮件数据
            var mailVo = new I_MAIL_VO();
            mailVo.mailId = System.Guid.NewGuid().ToString();
            mailVo.title1 = "系统邮件";
            mailVo.title2 = isExpired ? "密友申请已过期" : "密友申请已被拒绝";
            mailVo.title3 = isExpired ? "您发出的密友申请已超过24小时有效期，系统已自动退还您的密友结书。" : "您发出的密友申请未被对方接受，系统已退还您的密友结书。";
            mailVo.status = 0; // 未读
            mailVo.createTime = TimeUtil.GetTimestamp();
            
            // 添加结书作为附件
            mailVo.reward = new System.Collections.Generic.Dictionary<ulong, uint>();
            mailVo.reward.Add(cronyBookEntityId, 1);
            
            // 添加到邮件列表
            MailModel.Instance.mailData.Add(mailVo);
            
            // 触发邮件列表更新事件
            EventManager.Instance.DispatchEvent(MailEvent.MailListInfo);
            
            Debug.Log($"已发送退还结书邮件，好友ID: {friendId}，是否过期: {isExpired}");
        }
        catch (System.Exception ex)
        {
            Debug.LogError("发送退还结书邮件失败: " + ex.Message);
        }
    }
}

