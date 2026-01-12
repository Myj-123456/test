using protobuf.common;
using protobuf.messagecode;
using protobuf.misc;
using protobuf.rob;
using protobuf.user;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ADK;
using protobuf.login;
using protobuf.welfare;
using protobuf.notify;

/// <summary>
/// 我的信息
/// </summary>
public class MyselfController : BaseController<MyselfController>
{
    protected override void InitListeners()
    {
        AddNetListener<S_SYSTEM_ITEM_NOTIFY>((int)MessageCode.S_SYSTEM_ITEM_NOTIFY, ResSystemItemNotify);
        AddNetListener<S_MSG_UPDATE_TOWNNAME>((int)MessageCode.S_MSG_UPDATE_TOWNNAME, UpdateTownName);
        //画笔升级
        AddNetListener<S_MSG_PEN_UPGRADE>((int)MessageCode.S_MSG_PEN_UPGRADE, PenUpgrade);
        AddEventListener(SystemEvent.UpdateLevel, OnUpdateLevel);

        //画笔战斗属性
        AddNetListener<S_MSG_PEN_FIGHTATTR>((int)MessageCode.S_MSG_PEN_FIGHTATTR, PenFightattr);
        //根据用户id批量获取用户信息
        AddNetListener<S_MSG_BATCH_USERINFO_GUILD_DRESS>((int)MessageCode.S_MSG_BATCH_USERINFO_GUILD_DRESS, GetUserInfo);
        //更新个性签名
        AddNetListener<S_MSG_LOVE_FLOWER_ART>((int)MessageCode.S_MSG_LOVE_FLOWER_ART, LoveFlowerArt);
        //获取其他用户信息
        AddNetListener<S_MSG_OTHER_USER_INFO>((int)MessageCode.S_MSG_OTHER_USER_INFO, OtherUserInfo);
        //领取激活码
        AddNetListener<S_MSG_GIFT_CODE>((int)MessageCode.S_MSG_GIFT_CODE, GiftCode);
        //修改头像框
        AddNetListener<S_MSG_USER_SET_AVATAR_FRAME>((int)MessageCode.S_MSG_USER_SET_AVATAR_FRAME, SetAvatarFrame);
        //修改称号
        AddNetListener<S_MSG_USER_SET_TITLE>((int)MessageCode.S_MSG_USER_SET_TITLE, SetTitle);
        //修改头像
        AddNetListener<S_MSG_UPDATE_ICON>((int)MessageCode.S_MSG_UPDATE_ICON, SetHead);
        //游戏跨天
        AddNetListener<S_MSG_GAME_CROSS_DAY>((int)MessageCode.S_MSG_GAME_CROSS_DAY, GameCrossDay);
        //获取水桶奖励
        AddNetListener<S_MSG_WATER_BUCKET_AWARD>((int)MessageCode.S_MSG_WATER_BUCKET_AWARD, WaterBucketAward);
        //每日签到领取水滴
        AddNetListener<S_MSG_WELFARE_WATER_STAGE>((int)MessageCode.S_MSG_WELFARE_WATER_STAGE, WaterStage);

        AddNetListener<S_MSG_WELFARE_INFO>((int)MessageCode.S_MSG_CHANGE_WATERBUCKET, ChangeWaterBucket);
        //打开礼包
        AddNetListener<S_MSG_OPEN_GIFT_PACK>((int)MessageCode.S_MSG_OPEN_GIFT_PACK, OpenGiftPack);
        //点击道具
        AddNetListener<S_MSG_CLICK_ITEM>((int)MessageCode.S_MSG_CLICK_ITEM, ClickItem);
        //注销账号
        AddNetListener<S_MSG_DELETE_ACCOUNT>((int)MessageCode.S_MSG_DELETE_ACCOUNT, DeleteAccount);
        //每日登录签到数据变更 I_DAILY_LOGIN
        AddNetListener<I_DAILY_LOGIN>((int)MessageCode.S_MSG_CHANGE_DAILYLOGIN, ChangeDailyLogin);
        //每日经营
        AddNetListener<S_MSG_DAILY_MANAGER_STAT>((int)MessageCode.S_MSG_DAILY_MANAGER_STAT, DailyManagerStat);
    }

    /// <summary>
    /// 系统物品变更信息通知
    /// </summary>
    /// <param name="systemItemNotify"></param>
    private void ResSystemItemNotify(S_SYSTEM_ITEM_NOTIFY systemItemNotify)
    {
        MyselfModel.Instance.UpdateProfile(systemItemNotify.items);
        MyselfModel.Instance.UpdateDynamicInfo(systemItemNotify.dynamicInfo);
    }

    /// <summary>
    /// 等级更新
    /// </summary>
    private void OnUpdateLevel()
    {
        //当订单系统解锁且未请求过数据
        if (GlobalModel.Instance.GetUnlocked(SysId.Order) && !FlowerOrderModel.Instance.HaveReqData())
        {
            //FlowerOrderController.Instance.ReqOderInfo();
        }
        if (GlobalModel.Instance.GetUnlockLevel(SysId.dress) == MyselfModel.Instance.level)
        {
            //FlowerOrderController.Instance.ReqOderInfo();
        }
        if (GlobalModel.Instance.GetUnlocked(SysId.NpcOrder) && NpcManager.Instance.npcOrderUnOpen)
        {
            NpcOrderModel.Instance.npcOrderRefreshTime = ServerTime.Time + GlobalModel.Instance.module_profileConfig.npcRefreshTime;
            NpcManager.Instance.StartOrderNpc(false);
        }
    }

    //更新小镇名称
    private void UpdateTownName(S_MSG_UPDATE_TOWNNAME data)
    {
        MyselfModel.Instance.UpdateUserInfo(UserInfoType.INFO_TYPE_NICKNAME, data.townName);
        EventManager.Instance.DispatchEvent(SystemEvent.UpdateTownName);
    }

    public void ReqUpdateTownName(string name)
    {
        C_MSG_UPDATE_TOWNNAME c_MSG_UPDATE_TOWNNAME = new C_MSG_UPDATE_TOWNNAME();
        c_MSG_UPDATE_TOWNNAME.townName = name;
        SendCmd((int)MessageCode.C_MSG_UPDATE_TOWNNAME, c_MSG_UPDATE_TOWNNAME);
    }
    //画笔升级
    public void PenUpgrade(S_MSG_PEN_UPGRADE data)
    {
        //PlayerModel.Instance.pen.penGrade = data.penGrade;
        EventManager.Instance.DispatchEvent(PlayerEvent.PenUpgrade);
    }

    public void PenUpgrade()
    {
        C_MSG_PEN_UPGRADE c_MSG_PEN_UPGRADE = new C_MSG_PEN_UPGRADE();
        SendCmd((int)MessageCode.C_MSG_PEN_UPGRADE, c_MSG_PEN_UPGRADE);
    }
    //画笔战斗属性
    public void PenFightattr(S_MSG_PEN_FIGHTATTR data)
    {
        //PlayerModel.Instance.fightAttr = data.fightAttr;
        EventManager.Instance.DispatchEvent(PlayerEvent.PenFightattr);

    }

    public void ReqPenFightattr()
    {
        C_MSG_PEN_FIGHTATTR c_MSG_PEN_FIGHTATTR = new C_MSG_PEN_FIGHTATTR();
        SendCmd((int)MessageCode.C_MSG_PEN_FIGHTATTR, c_MSG_PEN_FIGHTATTR);
    }
    //根据用户id批量获取用户信息
    public void GetUserInfo(S_MSG_BATCH_USERINFO_GUILD_DRESS data)
    {
        //ArenaModel.Instance.userList.AddRange(data.userList);
        //EventManager.Instance.DispatchEvent(ArenaEvent.ArenaRefreshUser);
        if (data.type == (uint)UserType.Prosperity)
        {
            FlowerRankModel.Instance.prosperityUserInfo = data.userList;
            EventManager.Instance.DispatchEvent(FlowerRankEvent.prosperityUserInfo);
        }
        else if (data.type == (uint)UserType.Cultivate)
        {
            FlowerRankModel.Instance.cultivateUserInfo = data.userList;
            EventManager.Instance.DispatchEvent(FlowerRankEvent.cultivateUserInfo);
        }
        else if (data.type == (uint)UserType.Art)
        {
            FlowerRankModel.Instance.artUserInfo = data.userList;
            EventManager.Instance.DispatchEvent(FlowerRankEvent.artUserInfo);
        }
        else if (data.type == (uint)UserType.Dress)
        {
            FlowerRankModel.Instance.dressUserInfo = data.userList;
            EventManager.Instance.DispatchEvent(FlowerRankEvent.dressUserInfo);
        }
        else if (data.type == (uint)UserType.best)
        {
            FlowerRankModel.Instance.bestUserInfo = data.userList;
            EventManager.Instance.DispatchEvent(FlowerRankEvent.dressUserInfo);
        }
    }

    public void ReqGetUserInfo(uint[] userIds, uint[] withClosethUserIds, uint type, List<string> otherModules = null)
    {
        C_MSG_BATCH_USERINFO_GUILD_DRESS c_MSG_BATCH_USERINFO_GUILD_DRESS = new C_MSG_BATCH_USERINFO_GUILD_DRESS();
        c_MSG_BATCH_USERINFO_GUILD_DRESS.userIds = userIds;
        c_MSG_BATCH_USERINFO_GUILD_DRESS.withClosethUserIds = withClosethUserIds;
        c_MSG_BATCH_USERINFO_GUILD_DRESS.type = type;
        c_MSG_BATCH_USERINFO_GUILD_DRESS.otherModules = otherModules;
        SendCmd((int)MessageCode.C_MSG_BATCH_USERINFO_GUILD_DRESS, c_MSG_BATCH_USERINFO_GUILD_DRESS);
    }
    //更新个性签名
    public void LoveFlowerArt(S_MSG_LOVE_FLOWER_ART data)
    {
        MyselfModel.Instance.UpdateUserInfo(UserInfoType.LIKE_SHOW, data.loveFlowerArt);
        EventManager.Instance.DispatchEvent(PlayerEvent.LoveFlowerArt);
    }

    public void ReqLoveFlowerArt(string loveFlowerArt)
    {
        C_MSG_LOVE_FLOWER_ART c_MSG_LOVE_FLOWER_ART = new C_MSG_LOVE_FLOWER_ART();
        c_MSG_LOVE_FLOWER_ART.loveFlowerArt = loveFlowerArt;
        SendCmd((int)MessageCode.C_MSG_LOVE_FLOWER_ART, c_MSG_LOVE_FLOWER_ART);
    }
    //获取其他用户信息
    public void OtherUserInfo(S_MSG_OTHER_USER_INFO data)
    {
        //获取其他用户信息
        UIManager.Instance.OpenWindow<PlayerInfoView>(UIName.PlayerInfoView, data);
    }

    public void ReqOtherUserInfo(uint otherUserId)
    {
        C_MSG_OTHER_USER_INFO c_MSG_OTHER_USER_INFO = new C_MSG_OTHER_USER_INFO();
        c_MSG_OTHER_USER_INFO.otherUserId = otherUserId;
        SendCmd((int)MessageCode.C_MSG_OTHER_USER_INFO, c_MSG_OTHER_USER_INFO);
    }
    //领取激活码
    public void GiftCode(S_MSG_GIFT_CODE data)
    {
        var dropList = ItemModel.Instance.GetDropData(data.items);
        UILogicUtils.ShowGetReward(dropList, () =>
        {
            DropManager.ShowDrop(dropList);
        });
    }

    public void ReqGiftCode(string code)
    {
        C_MSG_GIFT_CODE c_MSG_GIFT_CODE = new C_MSG_GIFT_CODE();
        c_MSG_GIFT_CODE.code = code;
        SendCmd((int)MessageCode.C_MSG_GIFT_CODE, c_MSG_GIFT_CODE);
    }
    //修改头像框
    public void SetAvatarFrame(S_MSG_USER_SET_AVATAR_FRAME data)
    {
        MyselfModel.Instance.UpdateUserInfo(UserInfoType.INFO_TYPE_HEAD_FRAME, data.itemId.ToString());
        EventManager.Instance.DispatchEvent(PlayerEvent.SetAvatarFrame);
    }

    public void ReqSetAvatarFrame(uint itemId)
    {
        C_MSG_USER_SET_AVATAR_FRAME c_MSG_USER_SET_AVATAR_FRAME = new C_MSG_USER_SET_AVATAR_FRAME();
        c_MSG_USER_SET_AVATAR_FRAME.itemId = itemId;
        SendCmd((int)MessageCode.C_MSG_USER_SET_AVATAR_FRAME, c_MSG_USER_SET_AVATAR_FRAME);
    }
    //修改称号
    public void SetTitle(S_MSG_USER_SET_TITLE data)
    {
        MyselfModel.Instance.UpdateUserInfo(UserInfoType.TITLE, data.itemId.ToString());
        EventManager.Instance.DispatchEvent(PlayerEvent.SetTitle);
    }
    public void ReqSetTitle(uint itemId)
    {
        C_MSG_USER_SET_TITLE c_MSG_USER_SET_TITLE = new C_MSG_USER_SET_TITLE();
        c_MSG_USER_SET_TITLE.itemId = itemId;
        SendCmd((int)MessageCode.C_MSG_USER_SET_TITLE, c_MSG_USER_SET_TITLE);
    }
    //修改头像
    public void SetHead(S_MSG_UPDATE_ICON data)
    {
        MyselfModel.Instance.UpdateUserInfo(UserInfoType.INFO_TYPE_AVATAR, data.itemId.ToString());
        EventManager.Instance.DispatchEvent(PlayerEvent.SetHead);
    }

    public void ReqSetHead(uint itemId)
    {
        C_MSG_UPDATE_ICON c_MSG_UPDATE_ICON = new C_MSG_UPDATE_ICON();
        c_MSG_UPDATE_ICON.itemId = itemId;
        SendCmd((int)MessageCode.C_MSG_UPDATE_ICON, c_MSG_UPDATE_ICON);
    }

    public void GameCrossDay(S_MSG_GAME_CROSS_DAY data)
    {
        SeventhSignModel.Instance.ParseData(data.dailyLoginInfo);
        WelfareModel.Instance.InitDailyLogin(data.dailyLoginInfo);
        MyselfModel.Instance.behaviorDaily = data.behaviorDaily;
        TaskModel.Instance.progress = data.progress;

        DailyTaskModel.Instance.dailyTask = data.dailyTaskInfo.dailyTask;
        DailyTaskModel.Instance.weeklyTask = data.dailyTaskInfo.weeklyTask;

        VideoModel.Instance.videoWatch = data.videoWatch;

        FlowerOrderModel.Instance.InitOrderList(data.orderList);

        RechargeModel.Instance.UpdateRechargeInfo(data.rechargeInfo);
        EventManager.Instance.DispatchEvent(PlayerEvent.GameCrossDay);
    }

    public void ReqGameCrossDay()
    {
        C_MSG_GAME_CROSS_DAY c_MSG_GAME_CROSS_DAY = new C_MSG_GAME_CROSS_DAY();
        SendCmd((int)MessageCode.C_MSG_GAME_CROSS_DAY, c_MSG_GAME_CROSS_DAY);
    }
    //获取水桶奖励
    public void WaterBucketAward(S_MSG_WATER_BUCKET_AWARD data)
    {
        var dropList = ItemModel.Instance.GetDropData(data.items);
        DropManager.ShowDrop(dropList);

        MyselfModel.Instance.behaviorDaily.waterBucketCnt = data.WaterBucketCnt;
        MyselfModel.Instance.waterBucketSeries = TextUtil.ToStringList(data.waterBucketSeries);
        MyselfModel.Instance.welfareInfo.waterBucketTime = data.waterBucketTime;
        if(data.type == 2)
        {
            VideoModel.Instance.AddWatchVideoCount((int)VideoSeeType.mouse_video_id);
        }
        EventManager.Instance.DispatchEvent(PlayerEvent.WaterBucketAward);
    }

    public void ReqWaterBucketAward(uint pos, uint type)
    {
        C_MSG_WATER_BUCKET_AWARD c_MSG_WATER_BUCKET_AWARD = new C_MSG_WATER_BUCKET_AWARD();
        c_MSG_WATER_BUCKET_AWARD.pos = pos;
        c_MSG_WATER_BUCKET_AWARD.type = type;
        SendCmd((int)MessageCode.C_MSG_WATER_BUCKET_AWARD, c_MSG_WATER_BUCKET_AWARD, 0.1f);
    }
    //每日签到领取水滴
    public void WaterStage(S_MSG_WELFARE_WATER_STAGE data)
    {
        MyselfModel.Instance.welfareInfo.waterStage = data.waterStage;
        var drop = new StorageItemVO();
        drop.itemDefId = (int)BaseType.FST_WATER;
        drop.count = GlobalModel.Instance.module_profileConfig.dianWaterReward;
        var dropList = new List<StorageItemVO> { drop };
        DropManager.ShowDrop(dropList);
        EventManager.Instance.DispatchEvent(PlayerEvent.WaterStage);
    }

    public void ReqWaterStage(uint stage, bool isRetroactive)
    {
        C_MSG_WELFARE_WATER_STAGE c_MSG_WELFARE_WATER_STAGE = new C_MSG_WELFARE_WATER_STAGE();
        c_MSG_WELFARE_WATER_STAGE.stage = stage;
        c_MSG_WELFARE_WATER_STAGE.isRetroactive = isRetroactive;
        SendCmd((int)MessageCode.C_MSG_WELFARE_WATER_STAGE, c_MSG_WELFARE_WATER_STAGE);
    }
    //水桶信息变更返回的信息
    public void ChangeWaterBucket(S_MSG_WELFARE_INFO data)
    {
        MyselfModel.Instance.welfareInfo = data;
        MyselfModel.Instance.waterBucketSeries = TextUtil.ToStringList(data.waterBucketSeries);
        EventManager.Instance.DispatchEvent(PlayerEvent.ChangeWaterBucket);
        Debug.Log("当前时间:" + ServerTime.Time + "下一个水桶时间:" + data.waterBucketTime);
    }
    //打开礼包
    public void OpenGiftPack(S_MSG_OPEN_GIFT_PACK data)
    {
        StorageModel.Instance.OddToStorageItems(data.costItems);
        var dropList = ItemModel.Instance.GetDropData(data.items);
        DropManager.ShowDrop(dropList);
        EventManager.Instance.DispatchEvent(PlayerEvent.OpenGiftPack);
    }

    public void ReqOpenGiftPack(uint itemId, uint cnt)
    {
        C_MSG_OPEN_GIFT_PACK c_MSG_OPEN_GIFT_PACK = new C_MSG_OPEN_GIFT_PACK();
        c_MSG_OPEN_GIFT_PACK.itemId = itemId;
        c_MSG_OPEN_GIFT_PACK.cnt = cnt;
        SendCmd((int)MessageCode.C_MSG_OPEN_GIFT_PACK, c_MSG_OPEN_GIFT_PACK);
    }
    //点击道具
    public void ClickItem(S_MSG_CLICK_ITEM data)
    {
        StorageModel.Instance.clickItems.Add(data.itemId);
        EventManager.Instance.DispatchEvent(RedPointEvent.ClickItem);
    }
    public void ReqClickItem(uint itemId)
    {
        C_MSG_CLICK_ITEM c_MSG_CLICK_ITEM = new C_MSG_CLICK_ITEM();
        c_MSG_CLICK_ITEM.itemId = itemId;
        SendCmd((int)MessageCode.C_MSG_CLICK_ITEM, c_MSG_CLICK_ITEM);
    }
    //注销账号
    public void DeleteAccount(S_MSG_DELETE_ACCOUNT data)
    {
        EventManager.Instance.DispatchEvent(PlayerEvent.DeleteAccount);
    }
    public void ReqDeleteAccount()
    {
        C_MSG_DELETE_ACCOUNT c_MSG_DELETE_ACCOUNT = new C_MSG_DELETE_ACCOUNT();
        SendCmd((int)MessageCode.C_MSG_DELETE_ACCOUNT, c_MSG_DELETE_ACCOUNT);
    }

    public void ChangeDailyLogin(I_DAILY_LOGIN data)
    {
        WelfareModel.Instance.InitDailyLogin(data);
        EventManager.Instance.DispatchEvent(PlayerEvent.ChangeDailyLogin);
    }
    //每日经营
    public void DailyManagerStat(S_MSG_DAILY_MANAGER_STAT data)
    {
        MyselfModel.Instance.shopList = data.data;
        EventManager.Instance.DispatchEvent(PlayerEvent.DailyManagerStat);
    }

    public void ReqDailyManagerStat()
    {
        C_MSG_DAILY_MANAGER_STAT c_MSG_DAILY_MANAGER_STAT = new C_MSG_DAILY_MANAGER_STAT();
        SendCmd((int)MessageCode.C_MSG_DAILY_MANAGER_STAT, c_MSG_DAILY_MANAGER_STAT);
    }
}

public enum UserType
{
    Prosperity = 1,//繁荣度排行榜
    Cultivate,//养成度排行榜
    Art,//艺术作品排行榜
    Dress,//时尚穿搭排行榜
    best //密友的服装
}