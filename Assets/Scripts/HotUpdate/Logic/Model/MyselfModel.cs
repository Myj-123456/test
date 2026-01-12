using ADK;
using Elida.Config;
using protobuf.login;
using protobuf.misc;
using protobuf.user;
using protobuf.welfare;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTimer;
using static protobuf.user.I_PROFILE_INFO_VO;
using static protobuf.user.I_PROFILE_TIME_INFO_VO;

/// <summary>
/// 玩家模型
/// </summary>
public class MyselfModel : Singleton<MyselfModel>
{

    private Ft_player_levelConfigData module_Profile_LevelConfigData;

    public uint userId;
    public uint level;
    public uint exp;//玩家经验值,当前等级前的经验值
    public uint gold;
    public uint diamond;
    public uint vipTime;
    public uint registerTime;
    public uint lastLoginTime;
    public uint fighting;//玩家战斗力
    public uint dressCharm;//玩家装扮魅力值
    public uint serverId;//玩家服务器id

    public uint tipId;//提示id,用于显示提示信息

    private WaterVO waterVO;//玩家当前浇水信息


    public List<protobuf.user.I_PROFILE_INFO_VO> userInfoList;

    public protobuf.user.I_BEHAVIORDAILY_VO behaviorDaily;//玩家每日行为信息


    //public List<I_USER_SHOP> userShop;//玩家商店信息

    public uint lastServerTime = 0;
    public uint maxLevel = 0;//玩家最大等级

    public bool atHome = true;//玩家是否在家
    public uint interactionCnt;//玩家与npc交互次数
    public uint friendId;//玩家当前好友id

    public int expVip = 0;

    public bool isBackgroundMuted;//背景音乐静音
    public bool isEffectMuted;//音效静音
    public bool fastHarvest;//快速收获
    public bool plantTween;//种植动画
    public bool isInAdventure = false;//是否在冒险模式
    public bool isFirstEnterGame = true;//是否第一次进入游戏

    public uint npcGiftGive;//玩家与npc交互次数;玩家给npc的奖励次数
    public uint npcIkebanaGive;//玩家与npc交互次数;玩家给npc的奖励次数
    public uint arenaRefreshCnt;// 玩家冒险模式刷新次数

    public uint waterBucketCnt;// 玩家当前水位值

    public S_MSG_WELFARE_INFO welfareInfo;//信息

    public List<int> waterBucketSeries;//8个水位值的状态
    public bool isShowUpLevel = false;//是否显示升级提示
    public bool isShowReward = false;//是否显示奖励提示

    public List<I_DAILY_STAT> shopList;//每日经营

    public void InitData(S_MSG_GAMEINIT data)
    {
        InitProfile(data.profile);
        InitDynamicInfo(data.dynamicInfo);
        behaviorDaily = data.behaviorDaily;
        userInfoList = data.profileInfos;

        isBackgroundMuted = Saver.GetBool("background_sound" + MyselfModel.Instance.userId, true);
        isEffectMuted = Saver.GetBool("effect_sound" + MyselfModel.Instance.userId, true);
        fastHarvest = Saver.GetBool("key_harvest" + MyselfModel.Instance.userId, true);
        plantTween = Saver.GetBool("plant_Tween" + MyselfModel.Instance.userId, true);
        SoundManager.Instance.musicEnabled = isBackgroundMuted;
        SoundManager.Instance.soundEnabled = isEffectMuted;
    }

    /// <summary>
    /// 初始化玩家基本信息
    /// </summary>
    private void InitProfile(protobuf.user.I_PROFILE_VO profile)
    {
        module_Profile_LevelConfigData = ConfigManager.Instance.GetConfig<Ft_player_levelConfigData>("ft_player_levelsConfig");
        maxLevel = (uint)module_Profile_LevelConfigData.DataList.Count;

        userId = profile.userId;
        level = profile.level;
        exp = profile.exp;
        gold = profile.gold;
        diamond = profile.diamond;
        vipTime = profile.vipTime;
        registerTime = profile.registerTime;
        lastLoginTime = profile.lastLoginTime;
        fighting = profile.fighting;
        dressCharm = profile.dressCharm;
        serverId = profile.serverId;
        Debug.Log("userId: " + userId);
        Debug.Log("Lv:" + level);
        Debug.Log("exp:" + exp);
        Debug.Log("gold:" + gold);
    }

    /// <summary>
    /// 更新玩家每日行为信息
    /// </summary>
    public void UpdateDailyInfo(I_DAILY_STAT_VO data)
    {
        npcGiftGive = data.npcGiftGive;
        npcIkebanaGive = data.npcIkebanaGive;
        arenaRefreshCnt = data.arenaRefreshCnt;

    }
    /// <summary>
    /// 跨天清除玩家每日行为信息
    /// 玩家每日行为信息跨天清除，需要在跨天时调用
    /// </summary>
    private void CrossDayClearData()
    {
        behaviorDaily = new protobuf.user.I_BEHAVIORDAILY_VO();
    }

    public protobuf.user.I_PROFILE_INFO_VO GetUserInfo(UserInfoType type)
    {
        return userInfoList.Find((value) =>
        {
            return (UserInfoType)value.infoType == type;
        });
    }
    /// <summary>
    /// 是否为vip
    /// </summary>
    /// <returns></returns>
    public bool IsVip()
    {
        return vipTime > ServerTime.Time;
    }

    public int CurrVipExp()
    {
        return IsVip() ? this.expVip : 0;
    }

    public bool IsVideoDouble()
    {
        var videoDouble = GetUserInfo(UserInfoType.INFO_VIDEO_BUFF);
        var card = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_SKIP_VIDEO_CARD);
        var videoTime = videoDouble == null ? 0 : int.Parse(videoDouble.info);
        var cardTime = card == null ? 0 : int.Parse(card.info);
        var endTime = videoTime > cardTime ? videoTime : cardTime;
        return endTime > ServerTime.Time;
    }

    /// <summary>
    /// 获取当前水位值
    /// </summary>
    public uint WaterCur
    {
        get
        {
            if (waterVO != null) return waterVO.waterCur;
            return 0;
        }
    }

    /// <summary>
    /// 减少水位值
    /// 玩家只能在当前水位值大于0时减少水位值
    /// 玩家水位值减少时，需要更新水位值
    /// </summary>
    public void SubWater(uint waterNum)
    {
        if (waterVO != null)
        {
            waterVO.waterCur -= waterNum;
            if (waterVO.waterCur <= 0) waterVO.waterCur = 0;
            EventManager.Instance.DispatchEvent(SystemEvent.UpdateWater);
        }
    }

    /// <summary>
    /// 获取当前水位值的最大值
    /// </summary>
    public uint WaterMax
    {
        get
        {
            if (waterVO != null) return waterVO.waterMax;
            return 0;
        }
        set
        {
            waterVO.waterMax = value;
        }
    }

    /// <summary>
    /// 查询当前水位值
    /// </summary>
    public void OnTick()
    {
        if (waterVO != null)
        {
            waterVO.Renew();
        }
        if (lastServerTime > 0 && TimeUtil.IsCrossDay(lastServerTime, ServerTime.Time))//跨天
        {
            //CrossDayClearData();
            MyselfController.Instance.ReqGameCrossDay();
        }
        lastServerTime = ServerTime.Time;
    }



    /// <summary>
    /// 水位值转换为时间
    /// </summary>
    /// <param name="dynamicInfo"></param>
    private void InitDynamicInfo(List<protobuf.user.I_PROFILE_TIME_INFO_VO> datas)
    {
        foreach (var data in datas)
        {
            if (data.infoType == 1)
            {
                waterVO = new WaterVO();
                waterVO.Init(uint.Parse(data.info), data.time);
            }else if(data.infoType == 2)
            {
                TurnBoxManager.Instance.boxNum = int.Parse(data.info);
                TurnBoxManager.Instance.time = (int)data.time;
                TurnBoxManager.Instance.UpdateBoxData();
            }
        }
    }

    /// <summary>
    /// 更新玩家个人信息
    /// </summary>
    /// <param name="items"></param>
    public void UpdateProfile(Dictionary<ulong, ulong> items)
    {
        foreach (KeyValuePair<ulong, ulong> item in items)
        {
            HandlerProfile(item.Key, item.Value);
        }
    }

    private void HandlerProfile(ulong key, ulong value)
    {
        string keyStr = key.ToString();
        if (keyStr.Length == 12)//12位数字，可能是商品id
        {
            keyStr = keyStr.Substring(4);//截取8位为商品id
        }
        if (keyStr.Length < 8) return;//8位商品id，否则忽略

        var itemId = uint.Parse(keyStr);
        switch (itemId)
        {
            case (uint)BaseType.CASH:
                diamond = (uint)value;
                break;
            case (uint)BaseType.GOLD:
                gold = (uint)value;
                Debug.Log("gold:" + gold);
                break;
            case (uint)BaseType.EXP:
                exp = (uint)value;
                UpdateExpAndLevel(exp);
                Debug.Log("exp:" + exp);
                Debug.Log("Lv:" + level);
                break;
            case (uint)BaseType.SPD_DRUG:
            case (uint)BaseType.GRANDMA_TICKET:
            case (uint)BaseType.GUILD_MEDAL:
            case (uint)BaseType.Friend_Coin:
                StorageModel.Instance.UpdateStorageByItemId((int)itemId, (int)value);
                break;
        }
        EventManager.Instance.DispatchEvent(SystemEvent.UpdateProfile, itemId);
        EventManager.Instance.DispatchEvent(RedPointEvent.UpdateItem);
    }

    /// <summary>
    /// 更新玩家经验与等级，以配置表为准，等级数据公式计算
    /// </summary>
    private void UpdateExpAndLevel(ulong exp)
    {
        if (exp > 0)
        {
            var dataList = module_Profile_LevelConfigData.DataList;
            var count = dataList.Count;

            //从配置表中查找玩家当前等级
            while (--count >= 0)
            {
                if ((ulong)dataList[count].Exp <= exp)
                {
                    var curLevel = (uint)dataList[count].Level;
                    if (curLevel > level)
                    {
                        var stepLevel = curLevel - level;
                        level = curLevel;
                        if (level > maxLevel)
                        {
                            level = maxLevel;
                        }
                        else
                        {
                            EventManager.Instance.DispatchEvent(SystemEvent.UpdateLevel);
                            ShowLevelupWindow(stepLevel);
                            SoundManager.Instance.PlaySound("levelUp");
                            EventManager.Instance.DispatchEvent(TaskEvent.MainTaskCount, 21);
                        }
                        Debug.Log("Lv:" + level);

                    }
                    break;
                }
            }

        }
    }

    private void ShowLevelupWindow(uint stepLevel)
    {

        var minLevel = (int)level - stepLevel;
        for (int i = (int)level; i > minLevel; i--)
        {
            var levelConfig = PlayerModel.Instance.GetLevelupBonus(i);
            if (levelConfig != null)
            {
                var rewards = levelConfig.Rewards;
                foreach (var reward in rewards)
                {
                    var itemConfig = ItemModel.Instance.GetItemByEntityID(reward.EntityID);
                    StorageModel.Instance.AddToStorageByItemId(itemConfig.ItemDefId, reward.Value);
                    Debug.Log("itemId：" + itemConfig.ItemDefId + "count：" + reward.Value);
                }
            }
            
        }

        if (GuideModel.Instance.IsGuide)//如果在新手引导中，则暂不弹出升级窗口
        {
            var getRewardWindow = UIManager.Instance.GetWindow(UIName.GetRewardWindow);
            if (getRewardWindow != null && getRewardWindow.Visible)
            {
                return;
            }
        }
        isShowUpLevel = true;
        UIManager.Instance.OpenWindow<LevelupWindow>(UIName.LevelupWindow, stepLevel);
    }

    public Ft_player_levelConfig GetLevelInfo(int level)
    {
        return module_Profile_LevelConfigData.Get(level);
    }

    /// <summary>
    /// 更新玩家动态信息，如水位值、宝箱开放时间等
    /// </summary>
    public void UpdateDynamicInfo(List<protobuf.user.I_PROFILE_TIME_INFO_VO> dynamicInfo)
    {
        foreach (var data in dynamicInfo)
        {
            if (data.infoType == 1)
            {
                if (waterVO != null)
                {
                    waterVO.UpdateWater(uint.Parse(data.info), data.time);
                }
            }else if(data.infoType == 2)
            {
                TurnBoxManager.Instance.boxNum = int.Parse(data.info);
                TurnBoxManager.Instance.time = (int)data.time;
                TurnBoxManager.Instance.UpdateBoxData();
            }
        }
    }

    /// <summary>
    /// 检查是否还可以继续浇水/偷菜
    /// </summary>
    /// <returns></returns>
    public bool CheckInterAction()
    {
        return interactionCnt < (GlobalModel.Instance.module_profileConfig.umberOfMutualaid + FriendModel.Instance.FriendCoinExchangeCnt);
    }


    /// <summary>
    /// 检查我的等级是否满足
    /// </summary>
    /// <param name="checkLevel"></param>
    /// <param name="showPromt">是否显示提示</param>
    /// <returns></returns>
    public bool CheckLevelMeet(uint checkLevel, bool showPromt = false)
    {
        var isMeet = level >= checkLevel;
        if (!isMeet && showPromt) ADK.UILogicUtils.ShowNotice(string.Format(Lang.GetValue("unlock_Level"), checkLevel));
        return isMeet;
    }

    public void UpdateUserInfo(UserInfoType type, string info)
    {
        var userInfo = GetUserInfo(type);
        if (userInfo == null)
        {
            var data = new protobuf.user.I_PROFILE_INFO_VO();
            data.infoType = (uint)type;
            data.info = info;
            userInfoList.Add(data);
        }
        else
        {
            userInfo.info = info;
        }
    }

    public bool GetVipRed()
    {
        if (IsVip() && behaviorDaily.monthCardAward == 0)
        {
            return true;
        }
        return false;
    }
}

public enum UserInfoType
{
    EMPTY = 0,
    INFO_TYPE_NICKNAME = 1, //平台昵称
    INFO_TYPE_AVATAR = 2, //平台头像
    INFO_TYPE_HEAD_FRAME = 3, //当前使用的头像框

    INFO_TYPE_SKIP_VIDEO_CARD = 4, //是否跳过视频广告
    INFO_TYPE_PLATFORM = 5, //用户注册平台
    INFO_TYPE_PLATFORM_ID = 6, //用户openid

    INFO_TYPE_ROB_MASTER_USER_ID = 7, //抢主用户id  
    INFO_TYPE_ROB_ACQUITTAL_TIME = 8, //抢主用户确认时间

    PLOT = 9, //用户当前所在地块id
    INFO_TYPE_RANK_FLOWER_AWARD_EXPIRETIME = 10, //用户当前地块的花朵奖励过期时间
    INFO_TYPE_RANK_WATER_AWARD = 11, //用户当前地块的水奖励id
    INFO_TYPE_RANK_WATER_AWARD_EXPIRETIME = 12, //用户当前地块的水奖励过期时间
    INFO_TYPE_RANK_CULTIVATE_AWARD = 13, //用户当前地块的菜奖励id
    INFO_TYPE_RANK_CULTIVATE_AWARD_EXPIRETIME = 14, //用户当前地块的菜奖励过期时间
    INFO_TYPE_GUILD_ID = 15, //用户当前所在公会id
    INFO_LOGIN_PLATFORM = 16, //当前登录平台
    INFO_VIDEO_BUFF = 17, //视频广告3秒缓冲时间，单位毫秒
    INFO_GUIDE = 18, //是否新手引导
    LIKE_SHOW = 20,//用户是否选择了显示好友点赞的商品
    TITLE = 21,//用户选择的标题
}
