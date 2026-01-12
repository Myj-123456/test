using ADK;
using Elida.Config;
using protobuf.common;
using protobuf.friend;
using protobuf.mail;
using protobuf.messagecode;
using protobuf.plant;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static protobuf.friend.S_MSG_CRONY_LIST;
using static protobuf.friend.S_MSG_FRIEND_APPLY_LIST;
using static protobuf.friend.S_MSG_FRIEND_BLACK_LIST;
using static protobuf.friend.S_MSG_FRIEND_LIST;
using static protobuf.friend.S_MSG_FRIEND_RECOMMEND_LIST;

public class FriendModel : Singleton<FriendModel>
{
    public uint friendCount;
    public List<I_FRIEND_PROFILE_VO> friendList = new List<I_FRIEND_PROFILE_VO>();
    public List<I_APPLY_VO> applyList = new List<I_APPLY_VO>();
    public List<I_BLACK_VO> blackList = new List<I_BLACK_VO>();
    public List<I_RECOMMEND_VO> recommendList = new List<I_RECOMMEND_VO>();

    public List<I_CRONY_VO> cronyList = new List<I_CRONY_VO>();//密友列表
    public List<protobuf.friend.S_MSG_CRONY_FRIEND_LIST.I_CRONY_VO> cronyFriendList = new List<protobuf.friend.S_MSG_CRONY_FRIEND_LIST.I_CRONY_VO>();//密友好友列表

    private uint unlockCronyCnt;
    // 已解锁的密友位数量
    public uint UnlockCronyCnt
    {
        get { return unlockCronyCnt; }
    }
    // 密友位数量
    public void UpdateUnlockCronyCntFromServer(uint count)
    {
        unlockCronyCnt = count;
    }
    private uint friendCoinExchangeCnt = 0;
    public uint FriendCoinExchangeCnt
    {
        get { return friendCoinExchangeCnt; }
        set { friendCoinExchangeCnt = value; }
    }
    public List<uint> applyUserIds = new List<uint>();//申请加我为密友的好友id

    //密友数据
    private Dictionary<int, Ft_mfriend_configConfig> _configDataDic;
    public Dictionary<int, Ft_mfriend_configConfig> configDataDic
    {
        get
        {
            if (_configDataDic == null)
            {
                var gameEventData = ConfigManager.Instance.GetConfig<Ft_mfriend_configConfigData>("ft_mfriend_configsConfig");
                _configDataDic = gameEventData.DataMap;
            }
            return _configDataDic;
        }
    }
    

    // 获得密友数据
    public Ft_mfriend_configConfig GetBestFriendConfigData(int level)
    {
        Ft_mfriend_configConfig data;
        _configDataDic.TryGetValue(level, out data);
        if (data == null) { Debug.LogError("等级不存在:" + level); }
        return data;
    }
    
    // 获取密友等级的最大级别
    public int GetMaxCronyLevel()
    {
        if (configDataDic == null || configDataDic.Count == 0)
        {
            return 1;
        }
        return configDataDic.Max(kvp => kvp.Key);
    }
    
    // 获取当前等级需要显示的升级经验
    public int GetDisplayExpForLevel(int currentLevel)
    {
        int maxLevel = GetMaxCronyLevel();
        
        // 如果已经是最高级，显示当前级别的经验
        if (currentLevel >= maxLevel)
        {
            Ft_mfriend_configConfig config = GetBestFriendConfigData(maxLevel);
            return config != null ? config.Exp : 0;
        }
        // 否则显示下一级别的经验
        Ft_mfriend_configConfig nextLevelConfig = GetBestFriendConfigData(currentLevel + 1);
        return nextLevelConfig != null ? nextLevelConfig.Exp : 0;
    }

    // 记录当前正在发送申请的好友ID，防止重复发送申请
    private Dictionary<uint, bool> isApplyingDictionary = new Dictionary<uint, bool>();
    
    // 检查是否正在发送密友申请
    public bool IsApplyingCrony(uint friendId)
    {
        return isApplyingDictionary.ContainsKey(friendId) && isApplyingDictionary[friendId];
    }

    public List<uint> blackUserIds = new List<uint>();//屏蔽的好友id

    public S_MSG_FRIEND_STEAL_MESSAGE friendStealMsg;//偷花返回消息

    public void AddBlackId(uint id)
    {
        if (blackUserIds.IndexOf(id) == -1)
        {
            blackUserIds.Add(id);
        }
    }
    public void RemoveBlackId(uint id)
    {
        var index = blackUserIds.IndexOf(id);
        if (index != -1)
        {
            blackUserIds.RemoveAt(index);
        }
    }

    public void AddApplyListToFriendList(uint[] friendIds)
    {
        foreach (uint id in friendIds)
        {
            I_FRIEND_PROFILE_VO friendData = new I_FRIEND_PROFILE_VO();
            friendData.userInfo = new I_USER_PROFILE();
            int index = GetApplyListIndex(id);
            if (index == -1)
            {
                return;
            }
            I_APPLY_VO applyData = applyList[index];
            friendData.userInfo.userId = applyData.userInfo.userId;
            friendData.userInfo.userLevel = applyData.userInfo.userLevel;
            friendData.userInfo.townName = applyData.userInfo.townName;
            friendData.userInfo.headImgId = applyData.userInfo.headImgId;
            friendData.userInfo.headFrame = applyData.userInfo.headFrame;
            friendData.userInfo.lastLoginTime = applyData.userInfo.lastLoginTime;
            friendData.isMark = false;
            friendData.canSteal = false;
            friendList.Add(friendData);
            applyList.RemoveAt(index);
            friendCount++;
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
            if (applyList[i].userInfo.userId == id)
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
            if (recommendList[i].userInfo.userId == id)
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
            if (friendData.userInfo.userId == friendId)
            {
                friendData.isMark = mark;
                break;
            }
        }
    }

    public I_FRIEND_PROFILE_VO GetFriendData(uint friendId)
    {
        foreach (var friendData in friendList)
        {
            if (friendData.userInfo.userId == friendId)
            {
                return friendData;
            }
        }
        return null;
    }

    public List<I_FRIEND_PROFILE_VO> GetFriendListfilter(uint friendId)
    {
        List<I_FRIEND_PROFILE_VO> filterFriendList = new List<I_FRIEND_PROFILE_VO>();
        foreach (var friendData in friendList)
        {
            if (friendData.userInfo.userId != friendId)
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
        }
    }

    public int GetFriendListIndex(uint id)
    {
        if (friendList == null)
        {
            return -1;
        }
        for (int i = 0; i < friendList.Count; i++)
        {
            if (friendList[i].userInfo.userId == id)
            {
                return i;
            }
        }
        return -1;
    }

    public I_FRIEND_PROFILE_VO GetFriendInfo(uint friendId)
    {
        return friendList.Find(value => value.userInfo.userId == friendId);
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
            I_FRIEND_PROFILE_VO friendData = friendList[index];
            I_BLACK_VO blackData = new I_BLACK_VO();
            blackData.userInfo = new I_USER_PROFILE();
            blackData.userInfo.userId = friendData.userInfo.userId;
            blackData.userInfo.userLevel = friendData.userInfo.userLevel;
            blackData.userInfo.townName = friendData.userInfo.townName;
            blackData.userInfo.headImgId = friendData.userInfo.headImgId;
            blackData.userInfo.headFrame = friendData.userInfo.headFrame;
            blackData.userInfo.lastLoginTime = friendData.userInfo.lastLoginTime;
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
        if (blackList == null)
        {
            return -1;
        }
        for (int i = 0; i < blackList.Count; i++)
        {
            if (blackList[i].userInfo.userId == id)
            {
                return i;
            }
        }
        return -1;
    }

    public List<I_FRIEND_PROFILE_VO> FindFriendDataArr(string str)
    {
        if (str == "")
        {
            return friendList;
        }
        var arr = new List<I_FRIEND_PROFILE_VO>();
        foreach (var value in friendList)
        {
            if (value.userInfo.userId.ToString().Contains(str) || value.userInfo.townName.Contains(str))
            {
                arr.Add(value);
            }
        }
        return arr;
    }

    public List<protobuf.friend.S_MSG_CRONY_FRIEND_LIST.I_CRONY_VO> FindCronyFriendDataArr(string str)
    {
        if (str == "")
        {
            return cronyFriendList;
        }
        var arr = new List<protobuf.friend.S_MSG_CRONY_FRIEND_LIST.I_CRONY_VO>();
        foreach (var value in cronyFriendList)
        {
            if (value.userInfo.userId.ToString().Contains(str) || value.userInfo.townName.Contains(str))
            {
                arr.Add(value);
            }
        }
        return arr;
    }

    public I_CRONY_VO GetCronyData(uint friendId)
    {
        return cronyList.Find(value => value.friendId == friendId);
    }
    
    public protobuf.friend.S_MSG_CRONY_FRIEND_LIST.I_CRONY_VO GetCronyFriendData(uint friendId)
    {
        return cronyFriendList.Find(value => value.userInfo.userId == friendId);
    }

    // 根据密友经验值计算密友等级
    public int CalculateCronyLevel(int exp)
    {
        // 如果配置为空，返回默认等级1
        if (configDataDic == null || configDataDic.Count == 0)
        {
            return 1;
        }
        var sortedConfigs = configDataDic.OrderBy(kvp => kvp.Key).ToList();
        int maxLevel = sortedConfigs.Last().Key;
        // 如果只有一个配置
        if (sortedConfigs.Count == 1)
        {
            return maxLevel;
        }
        // 遍历配置，使用下一级别的经验作为当前级别的升级阈值
        for (int i = 0; i < sortedConfigs.Count - 1; i++)
        {
            int currentLevel = sortedConfigs[i].Key;
            int nextLevel = sortedConfigs[i + 1].Key;
            int nextLevelExp = sortedConfigs[i + 1].Value.Exp;
            
            // 如果经验不足以达到下一级别的要求，返回当前级别
            if (exp < nextLevelExp)
            {
                return currentLevel;
            }
        }
        return maxLevel;
    }

    // 检查密友关系是否正在解除中
    public bool IsCronyRelationshipCancelling(uint friendId)
    {
        if (friendId == 0) return false;
        foreach (var cronyData in cronyList)
        {
            if (cronyData.friendId == friendId)
            {
                if (cronyData.cancelTime <= 0) return false;
                return true;
            }
        }
        return false;
    }
    // 获取密友解除的剩余时间
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
            currentServerTime = MyselfModel.Instance.lastServerTime;
        }
        int remainingSeconds = Mathf.Max(0, (int)(currentServerTime - cronyData.cancelTime));
        return remainingSeconds;
    }

    // 获取密友解除的剩余时间
    public int GetCronyRemainingCancelTime2(uint friendId)
    {
        const int twelveHoursInSeconds = 24 * 60 * 60;
        var cronyData = GetCronyData(friendId);
        if (cronyData == null || cronyData.cancelTime <= 0)
        {
            return 0;
        }
        uint currentServerTime = ServerTime.Time;
        if (currentServerTime <= 0)
        {
            currentServerTime = MyselfModel.Instance.lastServerTime;
        }
        int timed = Mathf.Max(0, (int)(currentServerTime - cronyData.cancelTime));
        int remainingSeconds = Mathf.Max(0, twelveHoursInSeconds - timed);
        return remainingSeconds;
    }

    // 检查好友关系是否满12小时
    public bool IsFriendRelationOver12Hours(uint friendId)
    {
        const uint twelveHoursInSeconds = 12 * 60 * 60;
        var cronyFriendData = GetCronyFriendData(friendId);
        if (cronyFriendData != null && cronyFriendData.time > 0)
        {
            uint relationStartTime = (uint)cronyFriendData.time;
            uint currentServerTime = MyselfModel.Instance.lastServerTime;
            uint elapsedTime = currentServerTime - relationStartTime;
            return elapsedTime >= twelveHoursInSeconds;
        }
        return true;
    }
    // 获取好友关系剩余时间
    public uint GetFriendRelationRemainingTime(uint friendId)
    {
        const uint twelveHoursInSeconds = 12 * 60 * 60;
        var cronyFriendData = GetCronyFriendData(friendId);
        if (cronyFriendData != null && cronyFriendData.time > 0)
        {
            uint relationStartTime = (uint)cronyFriendData.time;
            uint currentServerTime = MyselfModel.Instance.lastServerTime;
            uint elapsedTime = currentServerTime - relationStartTime;
            // 如果已经超过12小时，返回0
            if (elapsedTime >= twelveHoursInSeconds)
            {
                return 0;
            }
            return twelveHoursInSeconds - elapsedTime;
        }
        return 0;
    }

    // 发送密友申请
    public void SendApplyBestFriend(uint friendId)
    {
        // 检查该好友ID是否已经在申请中
        if (isApplyingDictionary.ContainsKey(friendId) && isApplyingDictionary[friendId])
        {
            return;
        }
        // 标记该好友ID正在申请中
        isApplyingDictionary[friendId] = true;
        FriendController.Instance.ReqCronyApply(friendId);
    }

    /// 清除申请标记
    private IEnumerator ClearApplyingFlag(uint friendId, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        if (isApplyingDictionary.ContainsKey(friendId))
        {
            isApplyingDictionary[friendId] = false;
        }
    }

    /// 直接清除申请标记
    public void ClearApplyingFlag(uint friendId)
    {
        if (isApplyingDictionary.ContainsKey(friendId))
        {
            isApplyingDictionary[friendId] = false;
        }
    }

    /// 检查密友申请是否已过期
    public bool IsApplyExpired(uint friendId)
    {
        // 首先检查是否已经是密友关系
        if (GetCronyData(friendId) != null)
        {
            return true;
        }
        if (applyUserIds.Contains(friendId))
        {
            return false;
        }
        
        // 检查我是否已向对方发送申请
        var cronyFriendData = GetCronyFriendData(friendId);
        if (cronyFriendData != null && cronyFriendData.isApplyCrony)
        {
            return false;
        }
        return true;
    }

    public void UpdateriendChatRed(uint friendId)
    {
        if(friendList != null)
        {
            var info = GetFriendInfo(friendId);
            if(info != null)
            {
                info.unreadNum = 0;
            }
        }
    }

    public bool GetFriendChatRed()
    {
        if(friendList != null)
        {
            foreach(var value in friendList)
            {
                if(value.unreadNum > 0)
                {
                    return true;
                }
            }
        }
        return false;
    }
}

