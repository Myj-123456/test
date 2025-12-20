
/// <summary>
/// 系统事件
/// </summary>
public class SystemEvent
{
    public static string UpdateProfile = "UpdateProfile";//更新第一条信息
    public static string UpdateLevel = "UpdateLevel";//更新玩家等级
    public static string UpdateWater = "UpdateWater";//更新水
    public static string CrossDay = "CrossDay";//跨天
    public static string Reconnect = "Reconnect";//重连
    public static string ShowOrHideMainUI = "ShowOrHideMainUI";//主界面ui显示/隐藏
    public static string HidePlantUI = "HidePlantUI";//隐藏种植ui
    public static string UpdateItemNum = "UpdateItemNum";//一些道具数量
    public static string StageTouchBegin = "StageTouchBegin";//全屏舞台点击事件
    public static string ShowHidePanel = "ShowHidePanel";//打开/关闭面板
    public static string CameraOrthoSizeFinish = "CameraOrthoSizeFinish";//镜头缩放结束
    public static string UpdateTownName = "UpdateTownName";//更新城镇名字
    public static string UpdatePower = "UpdatePower";//更新第一朵鲜花战力
    public static string UpdateFighting = "UpdateFighting";//更新我方速度
    public static string UpdateDressCharm = "UpdateDressCharm";//更新时装魅力值
}
/// <summary>
/// 花卖事件
/// </summary>
public class FloweSellEvent
{
    public static string TABLE_UNLOCK = "TABLE_UNLOCK";//解锁柜台
    public static string OnShelfFlower = "OnShelfFlower";//上架花台
    public static string SellFlowerReward = "SellFlowerReward";//获取售卖奖励
    public static string ShowStandFlower = "ShowStandFlower";//展示花架
    public static string SwitchFlowerStand = "SwitchFlowerStand";//切换花架
}

/// <summary>
/// 花订单事件
/// </summary>
public class FlowerOrderEvent
{
    public static string ResOrderSubmit = "ResOrderSubmit";//提交订单
    public static string ResDailyMissionReward = "ResDailyMissionReward";//领取奖励
    public static string FlowerOrderInfo = "FlowerOrderInfo";//订单详情
    public static string UpdateFlowerOrderCd = "UpdateFlowerOrderCd";//小叮当花订单cd
    public static string UpdateFlowerOrderInfo = "UpdateFlowerOrderInfo";//更新小叮当花订单
}

/// <summary>
/// 游戏事件
/// </summary>
public class SceneEvent
{
    public static string SceneObjectClick = "SceneObjectClick";//场景物体点击事件
    public static string SceneCameraMove = "SceneCameraMove";//场景相机移动事件
    public static string RefreshScene = "RefreshScene";//刷新场景
    public static string OrgPointReleaseTouch = "OrgPointReleaseTouch";//原点释放触摸事件
    public static string FlowerHarvest = "FlowerHarvest";//花朵收获
}
public class CultivationEvent
{
    public static string CultivationSpeed = "CultivationSpeed";//培养加速
    public static string CultivationRepair = "CultivationRepair";//培养修复
    public static string CultivationPlant = "CultivationPlant";//培养种植
    public static string CultivationHarvest = "CultivationHarvest";//培养收获
    public static string CultivateVideo = "CultivateVideo";//培养 - 观看视频
    public static string CultivateHelp = "CultivateHelp";//培养帮助
}

public class FlowerHandBookEvent
{
    public static string SeedUpgrade = "SeedUpgrade";//种子升级
    public static string VaseRewardInfo = "VaseRewardInfo";//花圃种植 - 花瓶奖励信息
    public static string VaseReward = "VaseReward";//花圃种植 - 领取某个花瓶奖励
    public static string VaseFlowerReward = "VaseFlowerReward";//花圃种植 - 领取某个花瓶某个花朵奖励
    public static string VaseGatherReward = "VaseGatherReward";//花圃种植 - 领取花瓶+花朵奖励
    public static string VaseOnekeyReward = "VaseOnekeyReward";//花圃种植 - 一键领取某个花瓶奖励
    public static string PlaySpine = "PlaySpine";

    public static string SeedUpGradeBreakLv = "SeedUpGradeBreakLv";//种子突破等级
    public static string SeedUpGradeGrade = "SeedUpGradeGrade";//种子提升品阶
    public static string ExchangeFlowerCard = "ExchangeFlowerCard";//花卡片兑换奖励
}

public class IkebanaEvent
{
    public static string IkebanaMake = "IkebanaMake";//插花制作
    public static string IkeUpdateCount = "IkeUpdateCount";//更新数量
    public static string IkebanaReward = "IkebanaReward";//插花奖励，获取奖励物品或信息
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
    public static string MailDel = "MailDel";//删除邮件
}

public class SeventhSignEvent
{
    public static string DailyLoginAward = "DailyLoginAward";//每日登录奖励
}

public class NpcCollectEvent
{
    public static string GrandmaInfo = "GrandmaInfo";// grandma信息
    public static string GrandmaExchange = "GrandmaExchange";// grandma兑换
    public static string GrandmaReward = "GrandmaReward";// grandma奖励
}

public class FriendEvent
{
    public static string FriendList = "FriendList";//好友列表
    public static string FriendApplyList = "FriendApplyList";//好友申请列表 
    public static string FriendRecommendList = "FriendRecommendList";//好友推荐列表
    public static string FriendBlackList = "FriendBlackList";//好友黑名单
    public static string FriendVisit = "FriendVisit";//好友访问
    public static string FriendSteal = "FriendSteal";//好友偷取

    public static string CronyList = "CronyList";//密友列表
    public static string CronyBeApply = "CronyBeApply";//密友申请列表
    public static string CronyAgree = "CronyAgree";//同意密友关系
    public static string CronyReject = "CronyReject";///拒绝密友关系
    public static string CronyBookBuySuccess = "CronyBookBuySuccess";///购买结书成功
    public static string CronyUnlockSuccess = "CronyUnlockSuccess";///解锁密友成功
    public static string CronyCancel = "CronyCancel";//取消密友的关系
    public static string CronyBackCancel = "CronyBackCancel";//密友返回取消关系
    public static string CronySpeedCancel = "CronySpeedCancel";//密友关系取消
    public static string ApplyExpired = "ApplyExpired";//密友申请过期

    public static string FriendStealMesg = "FriendStealMesg";//好友偷取消息
    public static string FriendCoinExchange = "FriendCoinExchange";
}

public class RobEvent
{
    public static string RobInfo = "RobInfo";//抢劫信息
    public static string RobUnlock = "RobUnlock";//抢劫解锁
    public static string RobFriendList = "RobFriendList";//抢劫好友列表
    public static string RobEnemyList = "RobEnemyList";//抢劫敌人列表
    public static string RobRecommendList = "RobRecommendList";//抢劫推荐列表
    public static string RobDailyReward = "RobDailyReward";//每日抢劫奖励
    public static string RobReward = "RobReward";//抢劫奖励
    public static string RobBuy = "RobBuy";//抢劫购买
    public static string RobSetshield = "RobSetshield";//设置/取消屏蔽
    public static string RobMessage = "RobMessage";//抢劫消息
}

public class DailyTaskEvent
{
    public static string DailyTask = "DailyTask";//每日任务信息
    public static string DailyAllTaskAward = "DailyAllTaskAward";//领取所有每日任务奖励
}

public class CultivationShopEvent
{
    public static string CultivateRefresh = "CultivateRefresh";//刷新花圃
    public static string ReqCultivateBuy = "ReqCultivateBuy";//购买花圃
}

public class TradeEvent
{
    public static string TradeInfomation = "TradeInfomation";//交易信息
    public static string TradeUnlock = "TradeUnlock";//交易解锁
    public static string TradeUpdateCount = "TradeUpdateCount";//更新数量
    public static string TradeUpdatePrice = "TradeUpdatePrice";//更新价格
    public static string TradeUpperShelf = "TradeUpperShelf";//上货架
    public static string TradeFriendShop = "TradeFriendShop";//好友交易信息
    public static string Trade = "Trade";//交易
    public static string Message = "Message";//交易消息
    public static string TradeHelp = "TradeHelp";//交易帮助
}


public class GuildEvent
{
    public static string GuildList = "GuildList";//公会列表
    public static string GuildApply = "GuildApply";// 申请加入公会
    public static string GuildFound = "GuildFound";//创建公会
    public static string GuildRandomJoin = "GuildRandomJoin";// 随机加入公会
    public static string GuildInfo = "GuildInfo";//公会信息
    public static string GuildChangName = "GuildChangName";//修改公会名称
    public static string GuildChangeTxt = "GuildChangeTxt";//修改公会描述
    public static string GuildPositionName = "GuildPositionName";//修改公会职位名称
    public static string GuildUpgrade = "GuildUpgrade";// 升级公会
    public static string GuildEditApproval = "GuildEditApproval";//修改公会审核样式
    public static string GuildQuit = "GuildQuit";//退出公会
    public static string GuildMemberList = "GuildMemberList";//公会成员列表
    public static string GuildTransfer = "GuildTransfer";//转让公会
    public static string GuildKick = "GuildKick";// 踢出公会成员
    public static string GuildPromotion = "GuildPromotion";// 公会职位变更
    public static string GuildApplyList = "GuildApplyList";//公会申请列表
    public static string GuildDonate = "GuildDonate";// 公会捐献
    public static string GuildFlowerPotinfo = "GuildFlowerPotinfo";// 公会花圃信息
    public static string GuildUnlockFlowerPot = "GuildUnlockFlowerPot";// 解锁公会花圃
    public static string ReqGuildUpgradeFlowerPot = "ReqGuildUpgradeFlowerPot";// 升级公会花圃
    public static string GuildMoney = "GuildMoney";// 公会资金
    public static string LeaveGuild = "LeaveGuild";//退出公会
    public static string ChoseIcon = "ChoseIcon";//选择公会图标
    public static string GuildDonateProgress = "GuildDonateProgress";// 公会捐献进度

    public static string GuildKan = "GuildKan";//公会审核
    public static string GuildKanDetail = "GuildKanDetail";//公会审核详情
    public static string GuildKanNot = "GuildKanNot";//公会待审核列表
    public static string GuildKanInfo = "GuildKanInfo";//公会审核信息
    public static string GuildKanBuy = "GuildKanBuy";//公会审核购买

    public static string GuildShopInfo = "GuildShopInfo";//公会商店信息
    public static string GuildShopBuy = "GuildShopBuy";//公会商店购买

    public static string ApplyGuildList = "ApplyGuildList";//已申请加入公会列表
}

public class FlowerShareEvent
{
    public static string GuildShareFlowerInfo = "GuildShareFlowerInfo";// 公会分享花信息
    public static string GuildAddShareNum = "GuildAddShareNum";// 公会分享花增加数量
    public static string GuildUnlockShareFlower = "GuildUnlockShareFlower";// 公会分享花解锁
    public static string GuildShareFlower = "GuildShareFlower";// 公会分享花
    public static string GuildShareFlowerLog = "GuildShareFlowerLog";// 公会分享花日志
    public static string GuidShareCollect = "GuidShareCollect";// 公会分享花收集
}


public class ChatEvent
{
    public static string GuildChatHistory = "GuildChatHistory";//公会聊天历史消息事件
    public static string GuildChat = "GuildChat";//公会聊天
    public static string WorldChatHistory = "WorldChatHistory";//世界频道历史消息事件
    public static string WorldReceiveChat = "WorldReceiveChat";//收到世界频道消息事件

    public static string FriendContact = "FriendContact";//获取好友联系人事件
    public static string CreateFriendContact = "CreateFriendContact";//创建好友联系人事件
    public static string FriendChatHisTory = "FriendChatHisTory";//好友频道历史消息事件
    public static string FriendReceiveChat = "FriendReceiveChat";//收到好友频道消息事件
    public static string FriendChat = "FriendChat";//好友聊天
    public static string DelFriendContact = "DelFriendContact";//删除好友联系人事件
}


public class RechargeEvent
{
    public static string GiftPackInfo = "GiftPackInfo";//礼包信息事件
    public static string HaveGamePay = "HaveGamePay";//已支付游戏内 currency 事件
    public static string HaveGiftPay = "HaveGiftPay";//已支付礼包 currency 事件
    public static string haveDiamondPay = "haveDiamondPay";//已支付钻石 currency 事件
    public static string VipPay = "VipPay";//Vip支付事件
    public static string AccRecharge = "AccRecharge";//累计充值事件
    public static string FristRecharge = "FristRecharge";//首次充值事件
    public static string RechargeInfo = "RechargeInfo";//充值信息事件
    public static string MonthCard = "MonthCard";//vip每日奖励事件
    public static string VideoPay = "VideoPay";//视频支付事件
    public static string Normal = "Normal";//普通支付事件
    public static string TourReward = "TourReward";//获取锦标赛奖励事件

    public static string DrawGift = "DrawGift";//抽卡礼包购买
}

public class VipShopEvent
{
    public static string VipShopInfo = "VipShopInfo";//vip商店信息事件
    public static string VipShopBuy = "VipShopBuy";//vip商店购买事件
    public static string ShopStoreInfo = "ShopStoreInfo";//商店商店信息事件
    public static string ShopStoreBuy = "ShopStoreBuy";//商店商店购买事件
}

public class VideoEvent
{
    public static string videoDoubleTime = "videoDoubleTime";//视频3倍时间事件
    public static string videoDoubleEnd = "videoDoubleEnd";//视频3倍时间结束事件
    public static string videoGuildDonate = "videoGuildDonate";//视频公会捐献事件
}

public class GuideEvent
{
    public static string HideGuideHand = "HideGuideHand";//隐藏引导手
    public static string HideGuideUI = "HideGuideUI";//隐藏引导UI
    public static string ContinueCurGuide = "ContinueCurGuide";//继续当前引导
    public static string NextGuide = "NextGuide";//下一步引导
}

public class DressEvent
{
    public static string WearPart = "WearPart";//穿戴部位事件
    public static string ChangeSceneHeroModel = "ChangeSceneHeroModel";//切换场景中的英雄模型
    public static string DressDraw = "DressDraw";//时装 - 绘制
    public static string DressScoreReward = "DressScoreReward";//时装 - 奖励积分
    public static string DressStarLv = "DressStarLv";//时装 - 星级
    public static string DressUpgradeLv = "DressUpgradeLv";//时装 - 升级等级
    public static string DressDrawPower = "DressDrawPower";//时装 - 绘制能力
    public static string DressClothesBuy = "DressClothesBuy";//时装 - 背包格子点击
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
    public static string CultivationResearchStart = "CultivationResearchStart";//科学种植 - 研究开始事件
    public static string CultivationResearchCooltime = "CultivationResearchCooltime";//科学种植 - 研究冷却事件

}

public class FlowerStarEvent
{
    public static string FlowerStarSelect = "FlowerStarSelect";//选择花星事件
    public static string FlowerStarUnlock = "FlowerStarUnlock";////解锁花星事件
    public static string FlowerStarUpgrstar = "FlowerStarUpgrstar";//升级花星事件
    public static string FlowerStarReplace = "FlowerStarReplace";//替换花星事件
}


public class BattleEvent
{
    public static string SwitchNextActionUnit = "SwitchNextActionUnit";//切换下一个操作单位事件
    public static string UpdateRound = "UpdateRound";//刷新回合事件
    public static string UpdateActionUnit = "UpdateActionUnit";//更新操作单位事件
    public static string ChangeTimeScale = "ChangeTimeScale";//改变时间缩放事件
}


public class GuildGiftEvent
{
    public static string GuildGiftList = "GuildGiftList";//公会礼包列表事件
    public static string GuildGiftInfo = "GuildGiftInfo";//公会礼包信息事件
    public static string GuildGiftDraw = "GuildGiftDraw";//领取公会礼包事件
    public static string GuildGiftGradient = "GuildGiftGradient";//领取公会礼包奖励事件
}

public class GuildPlantEvent
{
    public static string GuildHouseInfo = "GuildHouseInfo";//公会房子信息事件
    public static string GuildHouseEnable = "GuildHouseEnable";//公会房子启用事件
    public static string GuildHousePlant = "GuildHousePlant";//公会房子种植事件
    public static string GuildHouseDetail = "GuildHouseDetail";//公会房子详情事件
    public static string GuildHouseHarvest = "GuildHouseHarvest";//公会房子收获事件
    public static string GuildHouseMembers = "GuildHouseMembers";//公会房子成员事件
}

public class GuildMatchEvent
{
    public static string GuildCompetition = "GuildCompetition";//公会比赛事件
    public static string GuildPosTask = "GuildPosTask";// 获取某个职位的任务
    public static string GuildReceive = "GuildReceive";//领取公会任务事件
    public static string GuildRefresh = "GuildRefresh";//刷新公会任务事件
    public static string GuildSubmit = "GuildSubmit";//提交公会任务事件
    public static string GuildSelfReward = "GuildSelfReward";//公会成员奖励事件
    public static string GuildProReward = "GuildProReward";//公会专业奖励事件
    public static string GuildMatchRank = "GuildMatchRank";//公会比赛排名事件
    public static string MemberMatchRank = "MemberMatchRank";//公会成员比赛排名事件
    public static string MemberInfo = "MemberInfo";//公会成员信息事件
}

public class PlayerEvent
{
    public static string PenUpgrade = "PenUpgrade";//升级培养品阶
    public static string PenFightattr = "PenFightattr";//升级战斗属性

    public static string GetUserInfo = "GetUserInfo";//根据用户id批量获取用户信息
    public static string LoveFlowerArt = "LoveFlowerArt";//升级喜爱花的花艺、绘画或作品
    public static string SetAvatarFrame = "SetAvatarFrame";//修改头像框
    public static string SetTitle = "SetTitle";//修改称号
    public static string SetHead = "SetHead";//修改头像
    public static string GameCrossDay = "GameCrossDay";//跨天

    public static string WaterBucketAward = "WaterBucketAward";//获取水桶
    public static string WaterStage = "WaterStage";//每日签到领取水滴
    public static string ChangeWaterBucket = "ChangeWaterBucket";//水桶被他人偷取后返回的数量

    public static string OpenGiftPack = "OpenGiftPack";//打开礼包
}

public class PetEvent
{
    public static string PetInfo = "PetInfo";//宠物信息事件
    public static string PetDraw = "PetDraw";//领取宠物事件
    public static string PetUpGrade = "PetUpGrade";//升级宠物事件
    public static string PetStar = "PetStar";//宠物星数事件
    public static string PetExchange = "PetExchange";//兑换宠物事件
    public static string BattlePet = "BattlePet";//战斗宠物事件
}

public class FlowerGoldEvent
{
    public static string FairyInfo = "FairyInfo";//仙子信息事件
    public static string FairyDraw = "FairyDraw";//领取仙子事件
    public static string FairyExchange = "FairyExchange";//兑换仙子事件
    public static string FairyUpgrade = "FairyUpgrade";//升级仙子事件
    public static string FairyRefresh = "FairyRefresh";//刷新仙子榜事件
    public static string BattleFairy = "BattleFairy";//战斗仙子事件
    public static string FairyDrawItem = "FairyDrawItem";//领取仙子奖励事件
}

public class FloristEvent
{
    public static string FloristReward = "FloristReward";// 奖励事件
    public static string FloristUpgrade = "FloristUpgrade";// 升级事件
    public static string FloristForge = "FloristForge";// 锻造事件
    public static string FloristInfo = "FloristInfo";// 信息事件
}

public class NpcEvent
{
    public static string NpcGiveGift = "NpcGiveGift";//赠送礼物事件
    public static string NpcBuyTimes = "NpcBuyTimes";//npc购买次数事件
    public static string ChangeNpc = "ChangeNpc";//切换npc事件
    public static string NpcGetReward = "NpcGetReward";//npc获取奖励事件
}

public class IllEvent
{
    public static string IllCetCollect = "IllCetCollect";//收集临床数据事件
    public static string IllUpgradeLevel = "IllUpgradeLevel";//升级临床等级事件
}

public class ArenaEvent
{
    public static string ArenaRankInfo = "ArenaRankInfo";//排名信息事件
    public static string ArenaRankRival = "ArenaRankRival";//排名对手事件
    public static string ArenaRefreshRival = "ArenaRefreshRival";//刷新对手事件
    public static string ArenaRefreshUser = "ArenaRefreshUser";//刷新用户
}

public class TaskEvent
{
    public static string MainTaskReward = "MainTaskReward";//领取主线任务奖励事件
    public static string ResMainTaskReward = "ResMainTaskReward";//领取主线任务奖励事件
    public static string MainTaskCount = "MainTaskCount";//主线任务数量事件
    public static string TaskProAreward = "TaskProAreward";//专业任务奖励事件
    public static string AchievTaskInfo = "AchievTaskInfo";//已完成任务信息事件
    public static string AchievTaskReward = "AchievTaskReward";//已完成任务奖励事件
}

public class FundEvent
{
    public static string FundReward = "FundReward";
}

public class PlotEvent
{
    public static string PlotWatch = "PlotWatch";//查看地块事件
}

public class ActivityEvent
{
    public static string MonthDraw = "MonthDraw";//月度抽奖
    public static string DiamondDraw = "DiamondDraw";//钻石抽奖事件
    public static string DressDraw = "DressDraw";//服装抽奖事件
    public static string MonthDrawWhetherDisplay = "MonthDrawWhetherDisplay";//月度抽奖是否显示
}

public class ExhcangeEvent
{
    public static string MonthDraw = "MonthDraw";//月度抽奖事件
    public static string DiamondDraw = "DiamondDraw";//钻石抽奖事件
    public static string DressDraw = "DressDraw";//服装抽奖事件
    public static string FurnitureShop = "FurnitureShop";//家具商店事件
}

public class WelfareEvent
{
    public static string DailySign = "DailySign";//每日签到事件
    public static string DailyRetroactive = "DailyRetroactive";//每日签到回退事件
    public static string RookieInfo = "RookieInfo";//萌新之路信息事件
    public static string RookieReward = "RookieReward";//萌新之路领取奖励事件
    public static string TurnTable = "TurnTable";//转牌事件
    public static string DailyLoginAward = "DailyLoginAward";//每日登录 - 领取奖励事件
}

public class ContractEvent
{
    public static string Contract = "Contract";//合同事件
    public static string ContractTaskReward = "ContractTaskReward";//合同任务奖励事件
    public static string ContractLevelReward = "ContractLevelReward";//合同等级奖励事件
}

public class NetEvent {

    public static string TriggerNet = "TriggerNet";
}

public class FairyFlowerEvent
{
    public static string FlowerFairyInfo = "FlowerFairyInfo";//仙子信息事件
    public static string FairyContractTask = "FairyContractTask";//合同任务事件
    public static string FairyContractLevel = "FairyContractLevel";//合同等级事件
    public static string FairyFiguireUp = "FairyFiguireUp";//仙子升级事件
    public static string FairyBlindDraw = "FairyBlindDraw";//仙子盲盒事件
    public static string FairyDispatch = "FairyDispatch";//仙子分发事件
    public static string FairyDispatchUnlock = "FairyDispatchUnlock";//仙子分发解锁事件
    public static string FairyDispatchSpeed = "FairyDispatchSpeed";//仙子分发速度事件
    public static string FairyDispatchHarvest = "FairyDispatchHarvest";//仙子分发收获事件
    public static string FairyHelpApply = "FairyHelpApply";//仙子帮助申请事件
    public static string FairyHelpEffect = "FairyHelpEffect";//仙子帮助效果事件
    public static string FairyBlindInfo = "FairyBlindInfo";//仙子盲盒信息事件
}

public class ShareEvent
{
    public static string ShareLevelReward = "ShareLevelReward";//分享等级奖励事件
    public static string ShareIkeReward = "ShareIkeReward";//分享好友奖励事件
    public static string ShareFlowerReward = "ShareFlowerReward";//分享花朵奖励事件
}

public class RedPointEvent
{
    public static string UpdateItem = "UpdateItem";//物品更新
    public static string FlowerCultivation = "FlowerCultivation";//培育更新
    public static string UpdateTradeMain = "UpdateTradeMain";//好友交易被购买
    public static string UpdateTradeTip = "UpdateTradeTip";//好友交易被购买
    public static string RechargeBuy = "RechargeBuy";//充值购买
    public static string RedDotChange = "RedDotChange";//红点更新
    public static string GameMild = "GameMild";//不重要信息。客户端不依赖接口字段就可以进入游戏
    public static string UpdateTodayFirstLogin = "UpdateTodayFirstLogin";//今天第一次登录
    public static string OnRechargeDelevier = "OnRechargeDelevier";//发货
    public static string ClickItem = "ClickItem";//点击道具
}

