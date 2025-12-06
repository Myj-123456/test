
/// <summary>
/// 系统事件
/// </summary>
public class SystemEvent
{
    public static string UpdateProfile = "UpdateProfile";//更新玩家基础信息
    public static string UpdateLevel = "UpdateLevel";//更新玩家等级
    public static string UpdateWater = "UpdateWater";//更新水
    public static string CrossDay = "CrossDay";//跨天了
    public static string Reconnect = "Reconnect";//网络重连
    public static string ShowOrHideMainUI = "ShowOrHideMainUI";//主界面ui显示隐藏
    public static string HidePlantUI = "HidePlantUI";//隐藏种植ui
    public static string UpdateItemNum = "UpdateItemNum";//一些特殊物品更新
    public static string StageTouchBegin = "StageTouchBegin";//全局舞台点击事件
    public static string ShowHidePanel = "ShowHidePanel";//打开/关闭界面
    public static string CameraOrthoSizeFinish = "CameraOrthoSizeFinish";//镜头缓动完毕
    public static string UpdateTownName = "UpdateTownName";//更新玩家名字
    public static string UpdatePower = "UpdatePower";//更新玩家花韵或战力
    public static string UpdateFighting = "UpdateFighting";//更新玩家繁荣度
    public static string UpdateDressCharm = "UpdateDressCharm";//更新玩家时装魅力
}

/// <summary>
/// 鲜花售卖
/// </summary>
public class FloweSellEvent
{
    public static string TABLE_UNLOCK = "TABLE_UNLOCK";//解锁摆台
    public static string OnShelfFlower = "OnShelfFlower";//上架花台
    public static string SellFlowerReward = "SellFlowerReward";//领取卖花奖励
    public static string ShowStandFlower = "ShowStandFlower";//显示插花
    public static string SwitchFlowerStand = "SwitchFlowerStand";//切换桌子
}

/// <summary>
/// 鲜花订单
/// </summary>
public class FlowerOrderEvent
{
    public static string ResOrderSubmit = "ResOrderSubmit";//提交订单
    public static string ResDailyMissionReward = "ResDailyMissionReward";//领取宝箱
    public static string FlowerOrderInfo = "FlowerOrderInfo";//花市订单
    public static string UpdateFlowerOrderCd = "UpdateFlowerOrderCd";//小黑板鲜花订单cd
    public static string UpdateFlowerOrderInfo = "UpdateFlowerOrderInfo";//更新小黑板鲜花订单
}

/// <summary>
/// 场景事件
/// </summary>
public class SceneEvent
{
    public static string SceneObjectClick = "SceneObjectClick";//场景对象点击事件
    public static string SceneCameraMove = "SceneCameraMove";//场景相机移动抛出
    public static string RefreshScene = "RefreshScene";//刷新场景
    public static string OrgPointReleaseTouch = "OrgPointReleaseTouch";//原点点击释放抛出
    public static string FlowerHarvest = "FlowerHarvest";//鲜花收获
}

public class CultivationEvent
{
    public static string CultivationSpeed = "CultivationSpeed";//培育加速
    public static string CultivationRepair = "CultivationRepair";//培育购买
    public static string CultivationPlant = "CultivationPlant";//培育种植
    public static string CultivationHarvest = "CultivationHarvest";//培育收获
    public static string CultivateVideo = "CultivateVideo";//培育 - 观看视频
    public static string CultivateHelp = "CultivateHelp";//助力
}

public class FlowerHandBookEvent
{
    public static string SeedUpgrade = "SeedUpgrade";//花朵升级
    public static string VaseRewardInfo = "VaseRewardInfo";//鲜花手册 - 花瓶奖励信息
    public static string VaseReward = "VaseReward";//鲜花手册 - 解锁了某个花瓶奖励
    public static string VaseFlowerReward = "VaseFlowerReward";//鲜花手册 - 解锁了某个花瓶某个花奖励
    public static string VaseGatherReward = "VaseGatherReward";//鲜花手册 - 集齐花瓶+花奖励
    public static string VaseOnekeyReward = "VaseOnekeyReward";//鲜花手册 - 一键领取某个花瓶奖励
    public static string PlaySpine = "PlaySpine";

    public static string SeedUpGradeBreakLv = "SeedUpGradeBreakLv";//鲜花突破等级
    public static string SeedUpGradeGrade = "SeedUpGradeGrade";//鲜花升阶级
    public static string ExchangeFlowerCard = "ExchangeFlowerCard";//鲜花碎片兑换花卡
}

public class IkebanaEvent
{
    public static string IkebanaMake = "IkebanaMake";//制作插花
    public static string IkeUpdateCount = "IkeUpdateCount";//数量改变
    public static string IkebanaReward = "IkebanaReward";//鲜花手册， 领取花艺品解锁奖励
}

public class FlowerRankEvent
{
    public static string RankList = "RankList";//排行榜列表
    public static string prosperityUserInfo = "prosperityUserInfo";
    public static string cultivateUserInfo = "cultivateUserInfo";
    public static string artUserInfo = "artUserInfo";
    public static string dressUserInfo = "dressUserInfo";
}

public class MailEvent
{
    public static string MailListInfo = "MailListInfo";//邮件列表
    public static string MailReward = "MailReward";//领取奖励
    public static string MailDel = "MailDel";//领取奖励
}

public class SeventhSignEvent
{
    public static string DailyLoginAward = "DailyLoginAward";//排行榜列表
}

public class NpcCollectEvent
{
    public static string GrandmaInfo = "GrandmaInfo";//萝莉信息
    public static string GrandmaExchange = "GrandmaExchange";//萝莉兑换
    public static string GrandmaReward = "GrandmaReward";//萝莉兑换
}

public class FriendEvent
{
    public static string FriendList = "FriendList";//好友列表
    public static string FriendApplyList = "FriendApplyList";//申请加我为好友的列表
    public static string FriendRecommendList = "FriendRecommendList";//好友推荐列表
    public static string FriendBlackList = "FriendBlackList";//黑名单列表
    public static string FriendVisit = "FriendVisit";//访问好友
    public static string FriendSteal = "FriendSteal";//好友偷花返回

    public static string CronyList = "CronyList";//蜜友列表
    public static string CronyBeApply = "CronyBeApply";//被申请列表
    public static string CronyAgree = "CronyAgree";//同意蜜友申请
    public static string CronyReject = "CronyReject";//拒绝蜜友申请
    public static string CronyCancel = "CronyCancel";//解除与蜜友的关系
    public static string CronyBackCancel = "CronyBackCancel";//撤销解除与蜜友的关系
    public static string CronySpeedCancel = "CronySpeedCancel";//加速解除

    public static string FriendStealMesg = "FriendStealMesg";//偷花消息
    public static string CronyUnlockSuccess = "CronyUnlockSuccess";// 触发解锁成功事件
    public static string CronyBookBuySuccess = "CronyBookBuySuccess";
    public static string ApplyExpired = "ApplyExpired";
}

public class RobEvent
{
    public static string RobInfo = "RobInfo";//花农信息
    public static string RobUnlock = "RobUnlock";//解锁牢笼
    public static string RobFriendList = "RobFriendList";//好友列表
    public static string RobEnemyList = "RobEnemyList";//冤家列表
    public static string RobRecommendList = "RobRecommendList";//推荐列表
    public static string RobDailyReward = "RobDailyReward";//每日奖励
    public static string RobReward = "RobReward";//领取抓花农奖励
    public static string RobBuy = "RobBuy";//购买护盾或者抢夺令
    public static string RobSetshield = "RobSetshield";//开启/关闭护盾模式
    public static string RobMessage = "RobMessage";//抓捕日志
}

public class DailyTaskEvent
{
    public static string DailyTask = "DailyTask";//任务信息
    public static string DailyAllTaskAward = "DailyAllTaskAward";//完成全部任务奖励
}

public class CultivationShopEvent
{
    public static string CultivateRefresh = "CultivateRefresh";//概览
    public static string ReqCultivateBuy = "ReqCultivateBuy";//购买
}

public class TradeEvent
{
    public static string TradeInfomation = "TradeInfomation";//概览
    public static string TradeUnlock = "TradeUnlock";//解锁
    public static string TradeUpdateCount = "TradeUpdateCount";//数量改变
    public static string TradeUpdatePrice = "TradeUpdatePrice";//价格改变
    public static string TradeUpperShelf = "TradeUpperShelf";//上架
    public static string TradeFriendShop = "TradeFriendShop";//好友店铺信息
    public static string Trade = "Trade";//交易
    public static string Message = "Message";//交易消息
    public static string TradeHelp = "TradeHelp";//好友助力
}


public class GuildEvent
{
    public static string GuildList = "GuildList";//社团列表
    public static string GuildApply = "GuildApply";// 申请加入社团
    public static string GuildFound = "GuildFound";//创建社团
    public static string GuildRandomJoin = "GuildRandomJoin";// 随机申请加入社团
    public static string GuildInfo = "GuildInfo";//社团信息
    public static string GuildChangName = "GuildChangName";//修改社团名称
    public static string GuildChangeTxt = "GuildChangeTxt";//修改社团公告 slogan
    public static string GuildPositionName = "GuildPositionName";//修改社团name
    public static string GuildUpgrade = "GuildUpgrade";// 升级社团
    public static string GuildEditApproval = "GuildEditApproval";//修改社团审批方式
    public static string GuildQuit = "GuildQuit";//退出社团
    public static string GuildMemberList = "GuildMemberList";//成员列表
    public static string GuildTransfer = "GuildTransfer";//转让社长
    public static string GuildKick = "GuildKick";// 踢出社团
    public static string GuildPromotion = "GuildPromotion";// 降职/升职
    public static string GuildApplyList = "GuildApplyList";//申请用户列表
    public static string GuildDonate = "GuildDonate";// 社团捐献
    public static string GuildFlowerPotinfo = "GuildFlowerPotinfo";// 社团花盆信息
    public static string GuildUnlockFlowerPot = "GuildUnlockFlowerPot";// 解锁花盆
    public static string ReqGuildUpgradeFlowerPot = "ReqGuildUpgradeFlowerPot";// 升级花盆
    public static string GuildMoney = "GuildMoney";// 社团资金使用明细
    public static string LeaveGuild = "LeaveGuild";//离开社团
    public static string ChoseIcon = "ChoseIcon";//选择徽章
    public static string GuildDonateProgress = "GuildDonateProgress";// 社团捐献进度奖励

    public static string GuildKan = "GuildKan";//砍价
    public static string GuildKanDetail = "GuildKanDetail";//砍价用户列表
    public static string GuildKanNot = "GuildKanNot";//社团未砍价用户列表
    public static string GuildKanInfo = "GuildKanInfo";//砍价信息
    public static string GuildKanBuy = "GuildKanBuy";//砍价购买

    public static string GuildShopInfo = "GuildShopInfo";//社团商店
    public static string GuildShopBuy = "GuildShopBuy";//社团商店购买

    public static string ApplyGuildList = "ApplyGuildList";//我已经申请加入的社团id
}

public class FlowerShareEvent
{
    public static string GuildShareFlowerInfo = "GuildShareFlowerInfo";// 鲜花分享
    public static string GuildAddShareNum = "GuildAddShareNum";// 增加鲜花分享次数
    public static string GuildUnlockShareFlower = "GuildUnlockShareFlower";// 解锁鲜花分享位置
    public static string GuildShareFlower = "GuildShareFlower";// 分享鲜花
    public static string GuildShareFlowerLog = "GuildShareFlowerLog";// 分享鲜花日志
    public static string GuidShareCollect = "GuidShareCollect";// // 鲜花分享 收藏鲜花
}


public class ChatEvent
{
    public static string GuildChatHistory = "GuildChatHistory";//历史聊天（只保留最近30天）
    public static string GuildChat = "GuildChat";//发送聊天
    public static string WorldChatHistory = "WorldChatHistory";//世界频道历史聊天记录
    public static string WorldReceiveChat = "WorldReceiveChat";//收到世界频道聊天信息，发送用户也会收到

    public static string FriendContact = "FriendContact";//获取好友私聊联系人
    public static string CreateFriendContact = "CreateFriendContact";//创建好友私聊联系人
    public static string FriendChatHisTory = "FriendChatHisTory";//好友频道历史聊天记录
    public static string FriendReceiveChat = "FriendReceiveChat";//收到好友频道聊天信息，发送用户不会收到
    public static string FriendChat = "FriendChat";//好友频道发送聊天
    public static string DelFriendContact = "DelFriendContact";//删除与好友的聊天会话
}


public class RechargeEvent
{
    public static string GiftPackInfo = "GiftPackInfo";//礼包信息
    public static string HaveGamePay = "HaveGamePay";//双倍购买
    public static string HaveGiftPay = "HaveGiftPay";//礼包购买
    public static string haveDiamondPay = "haveDiamondPay";//特惠礼包购买
    public static string VipPay = "VipPay";//Vip购买
    public static string AccRecharge = "AccRecharge";//累充奖励
    public static string FristRecharge = "FristRecharge";//首充奖励
    public static string RechargeInfo = "RechargeInfo";//支付相关信息
    public static string MonthCard = "MonthCard";//vip每日奖励
    public static string VideoPay = "VideoPay";//免广告
    public static string Normal = "Normal";//常规礼包；
    public static string TourReward = "TourReward";//领取巡回礼包奖励

    public static string DrawGift = "DrawGift";//抽卡礼包购买
}

public class VipShopEvent
{
    public static string VipShopInfo = "VipShopInfo";//vip商店信息
    public static string VipShopBuy = "VipShopBuy";//vip商店购买
    public static string ShopStoreInfo = "ShopStoreInfo";//杂货店铺信息
    public static string ShopStoreBuy = "ShopStoreBuy";//杂货店铺 - 购买
}

public class VideoEvent
{
    public static string videoDoubleTime = "videoDoubleTime";//看视频3小时内收益翻倍（17001）
    public static string videoDoubleEnd = "videoDoubleEnd";//看视频3小时内收益翻倍结束（17001）
    public static string videoGuildDonate = "videoGuildDonate";//看视频捐献
}

public class GuideEvent
{
    public static string HideGuideHand = "HideGuideHand";//隐藏引导手指
    public static string HideGuideUI = "HideGuideUI";//隐藏引导UI
    public static string NextGuide = "NextGuide";//引导下一步
}

public class DressEvent
{
    public static string WearPart = "WearPart";//穿戴部件
    public static string ChangeSceneHeroModel = "ChangeSceneHeroModel";//更新场景中的玩家模型
    public static string DressDraw = "DressDraw";//换装 - 开箱
    public static string DressScoreReward = "DressScoreReward";//换装 - 开箱积分奖励
    public static string DressStarLv = "DressStarLv";//换装 - 套装升星
    public static string DressUpgradeLv = "DressUpgradeLv";//换装 - 套装升阶
    public static string DressDrawPower = "DressDrawPower";
    public static string DressClothesBuy = "DressClothesBuy";//换装 - 衣服商店购买
}

public class AdventureEvent
{
    public static string ResClearObstacle = "ResGridLock";
    public static string UpdateCrystalnItem = "UpdateCrystalnItem";
    public static string AdventureInfo = "AdventureInfo";
    public static string AdventureSettleReward = "AdventureSettleReward";
    public static string AdventureEventReward = "AdventureEventReward";
    public static string AdventureProReward = "AdventureProReward";
}

public class ScientificPlantingEvent
{
    public static string CultivationResearchStart = "CultivationResearchStart";//培育研究开始
    public static string CultivationResearchCooltime = "CultivationResearchCooltime";//培育研究冷却时间购买

}

public class FlowerStarEvent
{
    public static string FlowerStarSelect = "FlowerStarSelect";//升星选择
    public static string FlowerStarUnlock = "FlowerStarUnlock";////解锁
    public static string FlowerStarUpgrstar = "FlowerStarUpgrstar";//研究
    public static string FlowerStarReplace = "FlowerStarReplace";//替换
}


public class BattleEvent
{
    public static string SwitchNextActionUnit = "SwitchNextActionUnit";//切换下一个行动单元
    public static string UpdateRound = "UpdateRound";//更新回合
    public static string UpdateActionUnit = "UpdateActionUnit";//更新行动单元
    public static string ChangeTimeScale = "ChangeTimeScale";//更改播放速度
}


public class GuildGiftEvent
{
    public static string GuildGiftList = "GuildGiftList";//礼物列表
    public static string GuildGiftInfo = "GuildGiftInfo";//礼物详情
    public static string GuildGiftDraw = "GuildGiftDraw";//领取礼物
    public static string GuildGiftGradient = "GuildGiftGradient";//领取大宝箱
}

public class GuildPlantEvent
{
    public static string GuildHouseInfo = "GuildHouseInfo";//花房信息
    public static string GuildHouseEnable = "GuildHouseEnable";//花房启用
    public static string GuildHousePlant = "GuildHousePlant";//花房种植
    public static string GuildHouseDetail = "GuildHouseDetail";//花房详情
    public static string GuildHouseHarvest = "GuildHouseHarvest";//花房收获
    public static string GuildHouseMembers = "GuildHouseMembers";//花房其他社团成员信息;
}

public class GuildMatchEvent
{
    public static string GuildCompetition = "GuildCompetition";//社团竞赛
    public static string GuildPosTask = "GuildPosTask";// 获取某个位置的任务
    public static string GuildReceive = "GuildReceive";//领取任务
    public static string GuildRefresh = "GuildRefresh";//刷新任务
    public static string GuildSubmit = "GuildSubmit";//提交任务
    public static string GuildSelfReward = "GuildSelfReward";//个人积分进度奖励
    public static string GuildProReward = "GuildProReward";//社团积分进度奖励
    public static string GuildMatchRank = "GuildMatchRank";//花盟排行
    public static string MemberMatchRank = "MemberMatchRank";//花盟成员排行
    public static string MemberInfo = "MemberInfo";//成员列表
}

public class PlayerEvent
{
    public static string PenUpgrade = "PenUpgrade";//绘笔升品阶
    public static string PenFightattr = "PenFightattr";//绘笔战斗属性

    public static string GetUserInfo = "GetUserInfo";//根据用户id批量获取包含换装和商会的用户信息
    public static string LoveFlowerArt = "LoveFlowerArt";//设置喜欢的鲜花或者花艺品
    public static string SetAvatarFrame = "SetAvatarFrame";//修改头像框
    public static string SetTitle = "SetTitle";//修改称号
    public static string SetHead = "SetHead";//修改头像
    public static string GameCrossDay = "GameCrossDay";//零点更新

    public static string WaterBucketAward = "WaterBucketAward";//领取水桶
    public static string WaterStage = "WaterStage";//每日定点领取水滴
    public static string ChangeWaterBucket = "ChangeWaterBucket";//水桶功能触发后返回的数据

    public static string OpenGiftPack = "OpenGiftPack";//打开随机礼包
}

public class PetEvent
{
    public static string PetInfo = "PetInfo";//宠物信息
    public static string PetDraw = "PetDraw";//温泉吸引宠物
    public static string PetUpGrade = "PetUpGrade";//升级
    public static string PetStar = "PetStar";//升星
    public static string PetExchange = "PetExchange";//碎片兑换宠物
    public static string BattlePet = "BattlePet";//宠物上阵
}

public class FlowerGoldEvent
{
    public static string FairyInfo = "FairyInfo";//花仙信息
    public static string FairyDraw = "FairyDraw";//领取花仙碎片
    public static string FairyExchange = "FairyExchange";//兑换花仙
    public static string FairyUpgrade = "FairyUpgrade";//升级
    public static string FairyRefresh = "FairyRefresh";//刷新祭坛
    public static string BattleFairy = "BattleFairy";//花仙上阵
    public static string FairyDrawItem = "FairyDrawItem";//领取花仙碎片
}

public class FloristEvent
{
    public static string FloristReward = "FloristReward";//鲜花店铺领取条件奖励
    public static string FloristUpgrade = "FloristUpgrade";//鲜花店铺升级
    public static string FloristForge = "FloristForge";////家具锻造
    public static string FloristInfo = "FloristInfo";//鲜花店铺信息
}

public class NpcEvent
{
    public static string NpcGiveGift = "NpcGiveGift";//赠送礼物、花艺品给居民
    public static string NpcBuyTimes = "NpcBuyTimes";//购买赠送礼物、花艺赠送次数
    public static string ChangeNpc = "ChangeNpc";//切换npc
    public static string NpcGetReward = "NpcGetReward";//领取居民等级奖励
}

public class IllEvent
{
    public static string IllCetCollect = "IllCetCollect";//图鉴 - 获取收集值
    public static string IllUpgradeLevel = "IllUpgradeLevel";//升级
}

public class ArenaEvent
{
    public static string ArenaRankInfo = "ArenaRankInfo";//排行
    public static string ArenaRankRival = "ArenaRankRival";//对手信息
    public static string ArenaRefreshRival = "ArenaRefreshRival";//刷新对手
    public static string ArenaRefreshUser = "ArenaRefreshUser";//刷新用户
}

public class TaskEvent
{
    public static string MainTaskReward = "MainTaskReward";//领取主线任务奖励
    public static string ResMainTaskReward = "ResMainTaskReward";//领取主线任务奖励
    public static string MainTaskCount = "MainTaskCount";//更新
    public static string TaskProAreward = "TaskProAreward";//进度奖励
    public static string AchievTaskInfo = "AchievTaskInfo";//成就任务信息
    public static string AchievTaskReward = "AchievTaskReward";//成就任务-领取奖励
}

public class FundEvent
{
    public static string FundReward = "FundReward";
}

public class PlotEvent
{
    public static string PlotWatch = "PlotWatch";//观看剧情
}

public class ActivityEvent
{
    public static string MonthDraw = "MonthDraw";//月度抽卡
    public static string DiamondDraw = "DiamondDraw";//钻石抽卡
    public static string DressDraw = "DressDraw";//服装抽卡
    public static string MonthDrawWhetherDisplay = "MonthDrawWhetherDisplay";//月度抽卡是否可见
}

public class ExhcangeEvent
{
    public static string MonthDraw = "MonthDraw";//月度抽卡
    public static string DiamondDraw = "DiamondDraw";//钻石抽卡
    public static string DressDraw = "DressDraw";//服装抽卡
    public static string FurnitureShop = "FurnitureShop";//家具商店
}

public class WelfareEvent
{
    public static string DailySign = "DailySign";//签到
    public static string DailyRetroactive = "DailyRetroactive";//补签
    public static string RookieInfo = "RookieInfo";//成长之路信息
    public static string RookieReward = "RookieReward";//成长之路领取奖励
    public static string TurnTable = "TurnTable";//转盘抽奖
    public static string DailyLoginAward = "DailyLoginAward";//每日登录 - 领取奖励
}

public class ContractEvent
{
    public static string Contract = "Contract";//合约
    public static string ContractTaskReward = "ContractTaskReward";//合约任务奖励
    public static string ContractLevelReward = "ContractLevelReward";//合约等级奖励
}

public class NetEvent {

    public static string TriggerNet = "TriggerNet";
}

public class FairyFlowerEvent
{
    public static string FlowerFairyInfo = "FlowerFairyInfo";//信息
    public static string FairyContractTask = "FairyContractTask";//合约任务奖励
    public static string FairyContractLevel = "FairyContractLevel";//合约等级奖励
    public static string FairyFiguireUp = "FairyFiguireUp";//花仙藏品升级
    public static string FairyBlindDraw = "FairyBlindDraw";//盲盒抽卡
    public static string FairyDispatch = "FairyDispatch";//派遣花仙
    public static string FairyDispatchUnlock = "FairyDispatchUnlock";//解锁派遣位置
    public static string FairyDispatchSpeed = "FairyDispatchSpeed";//派遣加速
    public static string FairyDispatchHarvest = "FairyDispatchHarvest";//派遣收获
    public static string FairyHelpApply = "FairyHelpApply";//申请助力
    public static string FairyHelpEffect = "FairyHelpEffect";//好友助力生效
    public static string FairyBlindInfo = "FairyBlindInfo";//盲盒信息
}

public class ShareEvent
{
    public static string ShareLevelReward = "ShareLevelReward";//等级分享
    public static string ShareIkeReward = "ShareIkeReward";//首次制作花艺品分享
    public static string ShareFlowerReward = "ShareFlowerReward";//培育花分享
}

