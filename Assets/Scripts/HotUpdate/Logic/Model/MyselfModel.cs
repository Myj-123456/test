using ADK;
using Elida.Config;
using protobuf.login;
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
/// 自己玩家数据
/// </summary>
public class MyselfModel : Singleton<MyselfModel>
{

    private Ft_player_levelConfigData module_Profile_LevelConfigData;

    public uint userId;
    public uint level;
    public uint exp;//等级经验,包含了之前等级的经验
    public uint gold;
    public uint diamond;
    public uint vipTime;
    public uint registerTime;
    public uint lastLoginTime;
    public uint fighting;//繁荣度
    public uint dressCharm;//时装魅力
    public uint serverId;//服id

    public uint tipId;//弹窗礼包id；

    private WaterVO waterVO;//水滴数据


    public List<protobuf.user.I_PROFILE_INFO_VO> userInfoList;

    public protobuf.user.I_BEHAVIORDAILY_VO behaviorDaily;//每日0点清空的用户信息


    public List<I_USER_SHOP> userShop;//店铺收益

    public uint lastServerTime = 0;
    public uint maxLevel = 0;//最大等级

    public bool atHome = true;//是否是自己家
    public uint interactionCnt;//已互动次数
    public uint friendId;//当前访问的好友id

    public int expVip = 0;

    public bool isBackgroundMuted;//背景音乐
    public bool isEffectMuted;//提示音效
    public bool fastHarvest;//一键收花
    public bool plantTween;//种植动画
    public bool isInAdventure = false;//是否在探险玩法中
    public bool isFirstEnterGame = true;//是否首次进入游戏

    public uint npcGiftGive;//当日赠送居民礼物次数
    public uint npcIkebanaGive;//当日赠送居民花艺品次数
    public uint arenaRefreshCnt;// 竞技场今日刷新次数

    public uint waterBucketCnt;// 今日已领取水桶次数

    public S_MSG_WELFARE_INFO welfareInfo;//水桶信息

    public List<int> waterBucketSeries;//8个水桶位置状态
    public bool isShowUpLevel = false;//是否显示升级弹框
    public bool isShowReward = false;//是否显示通用奖励弹框

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
    /// 初始化用户基础信息
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
    /// 每日0点清空的用户信息
    /// </summary>
    public void UpdateDailyInfo(I_DAILY_STAT_VO data)
    {
        npcGiftGive = data.npcGiftGive;
        npcIkebanaGive = data.npcIkebanaGive;
        arenaRefreshCnt = data.arenaRefreshCnt;

    }
    /// <summary>
    /// 跨天清除数据
    /// 需要清除的数据暂时都在这里清除吧
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
    /**是否是vip */
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
    /// 获取当前水
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
    ///减水滴
    ///此接口只能前端预表现浇水才使用
    ///其他的更新血量需要根据服务器返回更新
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
    /// 获取当前水总量
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
    /// 轮询更新水
    /// </summary>
    public void OnTick()
    {
        if (waterVO != null)
        {
            waterVO.Renew();
        }
        if (lastServerTime > 0 && TimeUtil.IsCrossDay(lastServerTime, ServerTime.Time))//跨天了
        {
            //CrossDayClearData();
            MyselfController.Instance.ReqGameCrossDay();
        }
        lastServerTime = ServerTime.Time;
    }



    /// <summary>
    /// 水滴转盘等带时间的信息
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
    /// 用户基础信息变更
    /// </summary>
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
        if (keyStr.Length == 12)//兼容12位格式
        {
            keyStr = keyStr.Substring(4);//截取后8个作为物品id
        }
        if (keyStr.Length < 8) return;//没有8位物品id长度 不执行

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
                StorageModel.Instance.UpdateStorageByItemId((int)itemId, (int)value);
                break;
        }
        EventManager.Instance.DispatchEvent(SystemEvent.UpdateProfile, itemId);
    }

    ////更新经验和等级,经验以服务器为准，等级根据公式计算
    private void UpdateExpAndLevel(ulong exp)
    {
        if (exp > 0)
        {
            var dataList = module_Profile_LevelConfigData.DataList;
            var count = dataList.Count;

            //倒序查找
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
        if (GuideModel.Instance.IsGuide)//引导中如果打开了获得奖励弹框，先不弹升级弹框了
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
    /// 用户动态信息变更
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
            }
        }
    }

    /// <summary>
    /// //检查是否还可以继续交互（浇水/偷花）
    /// </summary>
    /// <returns></returns>
    public bool CheckInterAction()
    {
        return interactionCnt < GlobalModel.Instance.module_profileConfig.umberOfMutualaid;
    }


    /// <summary>
    /// 检测玩家等级是否满足
    /// </summary>
    /// <param name="checkLevel"></param>
    /// <param name="showPromt">是否提示</param>
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
}

public enum UserInfoType
{
    EMPTY = 0,
    INFO_TYPE_NICKNAME = 1, //平台昵称
    INFO_TYPE_AVATAR = 2, //平台头像
    INFO_TYPE_HEAD_FRAME = 3, //当前使用的头像框（是游戏内的道具）

    INFO_TYPE_SKIP_VIDEO_CARD = 4, //跳过视频有效期
    INFO_TYPE_PLATFORM = 5, //用户注册平台
    INFO_TYPE_PLATFORM_ID = 6, //用户openid

    INFO_TYPE_ROB_MASTER_USER_ID = 7, //抓花农，抓走我的人
    INFO_TYPE_ROB_ACQUITTAL_TIME = 8, //抓花农 我被抓走了，释放时间

    PLOT = 9, //用户上周鲜花排行榜奖励下标id
    INFO_TYPE_RANK_FLOWER_AWARD_EXPIRETIME = 10, //用户上周鲜花排行榜奖励过期时间（应该是奖励是title之类的）
    INFO_TYPE_RANK_WATER_AWARD = 11, //用户上周浇水排行榜奖励下标id
    INFO_TYPE_RANK_WATER_AWARD_EXPIRETIME = 12, //用户上周鲜花排行榜奖励过期时间（应该是奖励是title之类的）
    INFO_TYPE_RANK_CULTIVATE_AWARD = 13, //用户上周培育排行榜奖励下标id
    INFO_TYPE_RANK_CULTIVATE_AWARD_EXPIRETIME = 14, //用户上周培育排行榜奖励过期时间（应该是奖励是title之类的）
    INFO_TYPE_GUILD_ID = 15, //我现在所在的社团id
    INFO_LOGIN_PLATFORM = 16, //当前登录的平台
    INFO_VIDEO_BUFF = 17, //看视频3小时内收益翻倍（17001）
    INFO_GUIDE = 18, //引导
    LIKE_SHOW = 20,//用户选择的喜欢的鲜花或者花艺品,多个之间用#号隔开
    TITLE = 21,//用户选择的称号（是游戏内的道具）
}
