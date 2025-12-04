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
/// ��ҿ�����
/// </summary>
public class MyselfController : BaseController<MyselfController>
{
    protected override void InitListeners()
    {
        AddNetListener<S_SYSTEM_ITEM_NOTIFY>((int)MessageCode.S_SYSTEM_ITEM_NOTIFY, ResSystemItemNotify);
        AddNetListener<S_MSG_UPDATE_TOWNNAME>((int)MessageCode.S_MSG_UPDATE_TOWNNAME, UpdateTownName);
        //�����Ʒ��
        AddNetListener<S_MSG_PEN_UPGRADE>((int)MessageCode.S_MSG_PEN_UPGRADE, PenUpgrade);
        AddEventListener(SystemEvent.UpdateLevel, OnUpdateLevel);

        //���ս������
        AddNetListener<S_MSG_PEN_FIGHTATTR>((int)MessageCode.S_MSG_PEN_FIGHTATTR, PenFightattr);
        //�����û�id������ȡ������װ���̻���û���Ϣ
        AddNetListener<S_MSG_BATCH_USERINFO_GUILD_DRESS>((int)MessageCode.S_MSG_BATCH_USERINFO_GUILD_DRESS, GetUserInfo);
        //����ϲ�����ʻ����߻���Ʒ
        AddNetListener<S_MSG_LOVE_FLOWER_ART>((int)MessageCode.S_MSG_LOVE_FLOWER_ART, LoveFlowerArt);
        //��ȡ�����û�����Ϣ
        AddNetListener<S_MSG_OTHER_USER_INFO>((int)MessageCode.S_MSG_OTHER_USER_INFO, OtherUserInfo);
        //�һ���һ�
        AddNetListener<S_MSG_GIFT_CODE>((int)MessageCode.S_MSG_GIFT_CODE, GiftCode);
        //�޸�ͷ���
        AddNetListener<S_MSG_USER_SET_AVATAR_FRAME>((int)MessageCode.S_MSG_USER_SET_AVATAR_FRAME, SetAvatarFrame);
        //�޸ĳƺ�
        AddNetListener<S_MSG_USER_SET_TITLE>((int)MessageCode.S_MSG_USER_SET_TITLE, SetTitle);
        //�޸�ͷ��
        AddNetListener<S_MSG_UPDATE_ICON>((int)MessageCode.S_MSG_UPDATE_ICON, SetHead);
        //���ˢ��
        AddNetListener<S_MSG_GAME_CROSS_DAY>((int)MessageCode.S_MSG_GAME_CROSS_DAY, GameCrossDay);
        //��ȡˮͰ
        AddNetListener<S_MSG_WATER_BUCKET_AWARD>((int)MessageCode.S_MSG_WATER_BUCKET_AWARD, WaterBucketAward);
        //ÿ�ն�����ȡˮ��
        AddNetListener<S_MSG_WELFARE_WATER_STAGE>((int)MessageCode.S_MSG_WELFARE_WATER_STAGE, WaterStage);

        AddNetListener<S_MSG_WELFARE_INFO>((int)MessageCode.S_MSG_CHANGE_WATERBUCKET, ChangeWaterBucket);
        //��������
        AddNetListener<S_MSG_OPEN_GIFT_PACK>((int)MessageCode.S_MSG_OPEN_GIFT_PACK, OpenGiftPack);
    }

    /// <summary>
    /// �����������Ʒ�����Ϣ֪ͨ
    /// </summary>
    /// <param name="systemItemNotify"></param>
    private void ResSystemItemNotify(S_SYSTEM_ITEM_NOTIFY systemItemNotify)
    {
        MyselfModel.Instance.UpdateProfile(systemItemNotify.items);
        MyselfModel.Instance.UpdateDynamicInfo(systemItemNotify.dynamicInfo);
    }

    /// <summary>
    /// ��ҵȼ����
    /// </summary>
    private void OnUpdateLevel()
    {
        //���������С�ڰ嶩��
        if (GlobalModel.Instance.GetUnlocked(SysId.Order) && !FlowerOrderModel.Instance.HaveReqData())
        {
            FlowerOrderController.Instance.ReqOderInfo();
        }
        if(GlobalModel.Instance.GetUnlockLevel(SysId.dress) == MyselfModel.Instance.level)
        {
            FlowerOrderController.Instance.ReqOderInfo();
        }
        if (GlobalModel.Instance.GetUnlocked(SysId.NpcOrder) && NpcManager.Instance.npcOrderUnOpen)
        {
            NpcOrderModel.Instance.npcOrderRefreshTime = ServerTime.Time + GlobalModel.Instance.module_profileConfig.npcRefreshTime;
            NpcManager.Instance.StartOrderNpc(false);
        }
    }

    //�����������
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
    //�����Ʒ��
    public void PenUpgrade(S_MSG_PEN_UPGRADE data)
    {
        PlayerModel.Instance.pen.penGrade = data.penGrade;
        EventManager.Instance.DispatchEvent(PlayerEvent.PenUpgrade);
    }

    public void PenUpgrade()
    {
        C_MSG_PEN_UPGRADE c_MSG_PEN_UPGRADE = new C_MSG_PEN_UPGRADE();
        SendCmd((int)MessageCode.C_MSG_PEN_UPGRADE, c_MSG_PEN_UPGRADE);
    }
    //���ս������
    public void PenFightattr(S_MSG_PEN_FIGHTATTR data)
    {
        PlayerModel.Instance.fightAttr = data.fightAttr;
        EventManager.Instance.DispatchEvent(PlayerEvent.PenFightattr);

    }

    public void ReqPenFightattr()
    {
        C_MSG_PEN_FIGHTATTR c_MSG_PEN_FIGHTATTR = new C_MSG_PEN_FIGHTATTR();
        SendCmd((int)MessageCode.C_MSG_PEN_FIGHTATTR, c_MSG_PEN_FIGHTATTR);
    }
    //�����û�id������ȡ������װ���̻���û���Ϣ
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
    //����ϲ�����ʻ����߻���Ʒ
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
    //��ȡ�����û�����Ϣ
    public void OtherUserInfo(S_MSG_OTHER_USER_INFO data)
    {
        //��ȡ�����û�����Ϣ
        UIManager.Instance.OpenWindow<PlayerInfoView>(UIName.PlayerInfoView, data);
    }

    public void ReqOtherUserInfo(uint otherUserId)
    {
        C_MSG_OTHER_USER_INFO c_MSG_OTHER_USER_INFO = new C_MSG_OTHER_USER_INFO();
        c_MSG_OTHER_USER_INFO.otherUserId = otherUserId;
        SendCmd((int)MessageCode.C_MSG_OTHER_USER_INFO, c_MSG_OTHER_USER_INFO);
    }
    //�һ���һ�
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
    //�޸�ͷ���
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
    //�޸ĳƺ�
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
    //�޸�ͷ��
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

        DailyTaskModel.Instance.dailyTask = data.dailyTask;
        DailyTaskModel.Instance.weeklyTask = data.weeklyTask;

        VideoModel.Instance.videoWatch = data.videoWatch;

        RechargeModel.Instance.UpdateRechargeInfo(data.rechargeInfo);
        EventManager.Instance.DispatchEvent(PlayerEvent.GameCrossDay);
    }

    public void ReqGameCrossDay()
    {
        C_MSG_GAME_CROSS_DAY c_MSG_GAME_CROSS_DAY = new C_MSG_GAME_CROSS_DAY();
        SendCmd((int)MessageCode.C_MSG_GAME_CROSS_DAY, c_MSG_GAME_CROSS_DAY);
    }
    //��ȡˮͰ
    public void WaterBucketAward(S_MSG_WATER_BUCKET_AWARD data)
    {
        var dropList = ItemModel.Instance.GetDropData(data.items);
        DropManager.ShowDrop(dropList);

        MyselfModel.Instance.behaviorDaily.waterBucketCnt = data.WaterBucketCnt;
        MyselfModel.Instance.waterBucketSeries = TextUtil.ToStringList(data.waterBucketSeries);
        MyselfModel.Instance.welfareInfo.waterBucketTime = data.waterBucketTime;
        
        EventManager.Instance.DispatchEvent(PlayerEvent.WaterBucketAward);
    }

    public void ReqWaterBucketAward(uint pos,uint type)
    {
        C_MSG_WATER_BUCKET_AWARD c_MSG_WATER_BUCKET_AWARD = new C_MSG_WATER_BUCKET_AWARD();
        c_MSG_WATER_BUCKET_AWARD.pos = pos;
        c_MSG_WATER_BUCKET_AWARD.type = type;
        SendCmd((int)MessageCode.C_MSG_WATER_BUCKET_AWARD, c_MSG_WATER_BUCKET_AWARD,0.1f);
    }
    //ÿ�ն�����ȡˮ��
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

    public void ReqWaterStage(uint stage,bool isRetroactive)
    {
        C_MSG_WELFARE_WATER_STAGE c_MSG_WELFARE_WATER_STAGE = new C_MSG_WELFARE_WATER_STAGE();
        c_MSG_WELFARE_WATER_STAGE.stage = stage;
        c_MSG_WELFARE_WATER_STAGE.isRetroactive = isRetroactive;
        SendCmd((int)MessageCode.C_MSG_WELFARE_WATER_STAGE, c_MSG_WELFARE_WATER_STAGE);
    }
    //ˮͰ���ܴ����󷵻ص�����
    public void ChangeWaterBucket(S_MSG_WELFARE_INFO data)
    {
        MyselfModel.Instance.welfareInfo = data;
        MyselfModel.Instance.waterBucketSeries = TextUtil.ToStringList(data.waterBucketSeries);
        EventManager.Instance.DispatchEvent(PlayerEvent.ChangeWaterBucket);
        Debug.Log("������ˮͰ��" + ServerTime.Time + "��һ��ˮͰʱ�䣺"+data.waterBucketTime);
    }
    //��������
    public void OpenGiftPack(S_MSG_OPEN_GIFT_PACK data)
    {
        StorageModel.Instance.OddToStorageItems(data.costItems);
        var dropList = ItemModel.Instance.GetDropData(data.items);
        DropManager.ShowDrop(dropList);
        EventManager.Instance.DispatchEvent(PlayerEvent.OpenGiftPack);
    }

    public void ReqOpenGiftPack(uint itemId,uint cnt)
    {
        C_MSG_OPEN_GIFT_PACK c_MSG_OPEN_GIFT_PACK = new C_MSG_OPEN_GIFT_PACK();
        c_MSG_OPEN_GIFT_PACK.itemId = itemId;
        c_MSG_OPEN_GIFT_PACK.cnt = cnt;
        SendCmd((int)MessageCode.C_MSG_OPEN_GIFT_PACK, c_MSG_OPEN_GIFT_PACK);
    }
}

public enum UserType
{
    Prosperity = 1,//���ٶ����а�
    Cultivate,//�������а�
    Art,//����Ʒ���а�
    Dress,//ʱװ�������а�
    best //密友的服装
}


