
/// <summary>
/// ϵͳ�¼�
/// </summary>
public class SystemEvent
{
    public static string UpdateProfile = "UpdateProfile";//������һ�����Ϣ
    public static string UpdateLevel = "UpdateLevel";//������ҵȼ�
    public static string UpdateWater = "UpdateWater";//����ˮ
    public static string CrossDay = "CrossDay";//������
    public static string Reconnect = "Reconnect";//��������
    public static string ShowOrHideMainUI = "ShowOrHideMainUI";//������ui��ʾ����
    public static string HidePlantUI = "HidePlantUI";//������ֲui
    public static string UpdateItemNum = "UpdateItemNum";//һЩ������Ʒ����
    public static string StageTouchBegin = "StageTouchBegin";//ȫ����̨����¼�
    public static string ShowHidePanel = "ShowHidePanel";//��/�رս���
    public static string CameraOrthoSizeFinish = "CameraOrthoSizeFinish";//��ͷ�������
    public static string UpdateTownName = "UpdateTownName";//�����������
    public static string UpdatePower = "UpdatePower";//������һ��ϻ�ս��
    public static string UpdateFighting = "UpdateFighting";//������ҷ��ٶ�
    public static string UpdateDressCharm = "UpdateDressCharm";//�������ʱװ����
}

/// <summary>
/// �ʻ�����
/// </summary>
public class FloweSellEvent
{
    public static string TABLE_UNLOCK = "TABLE_UNLOCK";//������̨
    public static string OnShelfFlower = "OnShelfFlower";//�ϼܻ�̨
    public static string SellFlowerReward = "SellFlowerReward";//��ȡ��������
    public static string ShowStandFlower = "ShowStandFlower";//��ʾ�廨
    public static string SwitchFlowerStand = "SwitchFlowerStand";//�л�����
}

/// <summary>
/// �ʻ�����
/// </summary>
public class FlowerOrderEvent
{
    public static string ResOrderSubmit = "ResOrderSubmit";//�ύ����
    public static string ResDailyMissionReward = "ResDailyMissionReward";//��ȡ����
    public static string FlowerOrderInfo = "FlowerOrderInfo";//���ж���
    public static string UpdateFlowerOrderCd = "UpdateFlowerOrderCd";//С�ڰ��ʻ�����cd
    public static string UpdateFlowerOrderInfo = "UpdateFlowerOrderInfo";//����С�ڰ��ʻ�����
}

/// <summary>
/// �����¼�
/// </summary>
public class SceneEvent
{
    public static string SceneObjectClick = "SceneObjectClick";//�����������¼�
    public static string SceneCameraMove = "SceneCameraMove";//��������ƶ��׳�
    public static string RefreshScene = "RefreshScene";//ˢ�³���
    public static string OrgPointReleaseTouch = "OrgPointReleaseTouch";//ԭ�����ͷ��׳�
    public static string FlowerHarvest = "FlowerHarvest";//�ʻ��ջ�
}

public class CultivationEvent
{
    public static string CultivationSpeed = "CultivationSpeed";//��������
    public static string CultivationRepair = "CultivationRepair";//��������
    public static string CultivationPlant = "CultivationPlant";//������ֲ
    public static string CultivationHarvest = "CultivationHarvest";//�����ջ�
    public static string CultivateVideo = "CultivateVideo";//���� - �ۿ���Ƶ
    public static string CultivateHelp = "CultivateHelp";//����
}

public class FlowerHandBookEvent
{
    public static string SeedUpgrade = "SeedUpgrade";//��������
    public static string VaseRewardInfo = "VaseRewardInfo";//�ʻ��ֲ� - ��ƿ������Ϣ
    public static string VaseReward = "VaseReward";//�ʻ��ֲ� - ������ĳ����ƿ����
    public static string VaseFlowerReward = "VaseFlowerReward";//�ʻ��ֲ� - ������ĳ����ƿĳ��������
    public static string VaseGatherReward = "VaseGatherReward";//�ʻ��ֲ� - ���뻨ƿ+������
    public static string VaseOnekeyReward = "VaseOnekeyReward";//�ʻ��ֲ� - һ����ȡĳ����ƿ����
    public static string PlaySpine = "PlaySpine";

    public static string SeedUpGradeBreakLv = "SeedUpGradeBreakLv";//�ʻ�ͻ�Ƶȼ�
    public static string SeedUpGradeGrade = "SeedUpGradeGrade";//�ʻ����׼�
    public static string ExchangeFlowerCard = "ExchangeFlowerCard";//�ʻ���Ƭ�һ�����
}

public class IkebanaEvent
{
    public static string IkebanaMake = "IkebanaMake";//�����廨
    public static string IkeUpdateCount = "IkeUpdateCount";//�����ı�
    public static string IkebanaReward = "IkebanaReward";//�ʻ��ֲᣬ ��ȡ����Ʒ��������
}

public class FlowerRankEvent
{
    public static string RankList = "RankList";//���а��б�
    public static string prosperityUserInfo = "prosperityUserInfo";
    public static string cultivateUserInfo = "cultivateUserInfo";
    public static string artUserInfo = "artUserInfo";
    public static string dressUserInfo = "dressUserInfo";
}

public class MailEvent
{
    public static string MailListInfo = "MailListInfo";//�ʼ��б�
    public static string MailReward = "MailReward";//��ȡ����
    public static string MailDel = "MailDel";//��ȡ����
}

public class SeventhSignEvent
{
    public static string DailyLoginAward = "DailyLoginAward";//���а��б�
}

public class NpcCollectEvent
{
    public static string GrandmaInfo = "GrandmaInfo";//������Ϣ
    public static string GrandmaExchange = "GrandmaExchange";//����һ�
    public static string GrandmaReward = "GrandmaReward";//����һ�
}

public class FriendEvent
{
    public static string FriendList = "FriendList";//�����б�
    public static string FriendApplyList = "FriendApplyList";//�������Ϊ���ѵ��б�
    public static string FriendRecommendList = "FriendRecommendList";//�����Ƽ��б�
    public static string FriendBlackList = "FriendBlackList";//�������б�
    public static string FriendVisit = "FriendVisit";//���ʺ���
    public static string FriendSteal = "FriendSteal";//����͵������

    public static string CronyList = "CronyList";//�����б�
    public static string CronyBeApply = "CronyBeApply";//�������б�
    public static string CronyAgree = "CronyAgree";//ͬ����������
    public static string CronyReject = "CronyReject";///���ܾ���������
    public static string CronyBookBuySuccess = "CronyBookBuySuccess";///购买结书成功
    public static string CronyUnlockSuccess = "CronyUnlockSuccess";///解锁密友成功
    public static string CronyCancel = "CronyCancel";//取消密友的关系
    public static string CronyBackCancel = "CronyBackCancel";//������������ѵĹ�ϵ
    public static string CronySpeedCancel = "CronySpeedCancel";//���ٽ��
    public static string ApplyExpired = "ApplyExpired";//密友申请过期

    public static string FriendStealMesg = "FriendStealMesg";//͵����Ϣ
}

public class RobEvent
{
    public static string RobInfo = "RobInfo";//��ũ��Ϣ
    public static string RobUnlock = "RobUnlock";//��������
    public static string RobFriendList = "RobFriendList";//�����б�
    public static string RobEnemyList = "RobEnemyList";//ԩ���б�
    public static string RobRecommendList = "RobRecommendList";//�Ƽ��б�
    public static string RobDailyReward = "RobDailyReward";//ÿ�ս���
    public static string RobReward = "RobReward";//��ȡץ��ũ����
    public static string RobBuy = "RobBuy";//���򻤶ܻ���������
    public static string RobSetshield = "RobSetshield";//����/�رջ���ģʽ
    public static string RobMessage = "RobMessage";//ץ����־
}

public class DailyTaskEvent
{
    public static string DailyTask = "DailyTask";//������Ϣ
    public static string DailyAllTaskAward = "DailyAllTaskAward";//���ȫ��������
}

public class CultivationShopEvent
{
    public static string CultivateRefresh = "CultivateRefresh";//����
    public static string ReqCultivateBuy = "ReqCultivateBuy";//����
}

public class TradeEvent
{
    public static string TradeInfomation = "TradeInfomation";//����
    public static string TradeUnlock = "TradeUnlock";//����
    public static string TradeUpdateCount = "TradeUpdateCount";//�����ı�
    public static string TradeUpdatePrice = "TradeUpdatePrice";//�۸�ı�
    public static string TradeUpperShelf = "TradeUpperShelf";//�ϼ�
    public static string TradeFriendShop = "TradeFriendShop";//���ѵ�����Ϣ
    public static string Trade = "Trade";//����
    public static string Message = "Message";//������Ϣ
    public static string TradeHelp = "TradeHelp";//��������
}


public class GuildEvent
{
    public static string GuildList = "GuildList";//�����б�
    public static string GuildApply = "GuildApply";// �����������
    public static string GuildFound = "GuildFound";//��������
    public static string GuildRandomJoin = "GuildRandomJoin";// ��������������
    public static string GuildInfo = "GuildInfo";//������Ϣ
    public static string GuildChangName = "GuildChangName";//�޸���������
    public static string GuildChangeTxt = "GuildChangeTxt";//�޸����Ź��� slogan
    public static string GuildPositionName = "GuildPositionName";//�޸�����name
    public static string GuildUpgrade = "GuildUpgrade";// ��������
    public static string GuildEditApproval = "GuildEditApproval";//�޸�����������ʽ
    public static string GuildQuit = "GuildQuit";//�˳�����
    public static string GuildMemberList = "GuildMemberList";//��Ա�б�
    public static string GuildTransfer = "GuildTransfer";//ת���糤
    public static string GuildKick = "GuildKick";// �߳�����
    public static string GuildPromotion = "GuildPromotion";// ��ְ/��ְ
    public static string GuildApplyList = "GuildApplyList";//�����û��б�
    public static string GuildDonate = "GuildDonate";// ���ž���
    public static string GuildFlowerPotinfo = "GuildFlowerPotinfo";// ���Ż�����Ϣ
    public static string GuildUnlockFlowerPot = "GuildUnlockFlowerPot";// ��������
    public static string ReqGuildUpgradeFlowerPot = "ReqGuildUpgradeFlowerPot";// ��������
    public static string GuildMoney = "GuildMoney";// �����ʽ�ʹ����ϸ
    public static string LeaveGuild = "LeaveGuild";//�뿪����
    public static string ChoseIcon = "ChoseIcon";//ѡ�����
    public static string GuildDonateProgress = "GuildDonateProgress";// ���ž��׽��Ƚ���

    public static string GuildKan = "GuildKan";//����
    public static string GuildKanDetail = "GuildKanDetail";//�����û��б�
    public static string GuildKanNot = "GuildKanNot";//����δ�����û��б�
    public static string GuildKanInfo = "GuildKanInfo";//������Ϣ
    public static string GuildKanBuy = "GuildKanBuy";//���۹���

    public static string GuildShopInfo = "GuildShopInfo";//�����̵�
    public static string GuildShopBuy = "GuildShopBuy";//�����̵깺��

    public static string ApplyGuildList = "ApplyGuildList";//���Ѿ�������������id
}

public class FlowerShareEvent
{
    public static string GuildShareFlowerInfo = "GuildShareFlowerInfo";// �ʻ�����
    public static string GuildAddShareNum = "GuildAddShareNum";// �����ʻ���������
    public static string GuildUnlockShareFlower = "GuildUnlockShareFlower";// �����ʻ�����λ��
    public static string GuildShareFlower = "GuildShareFlower";// �����ʻ�
    public static string GuildShareFlowerLog = "GuildShareFlowerLog";// �����ʻ���־
    public static string GuidShareCollect = "GuidShareCollect";// // �ʻ����� �ղ��ʻ�
}


public class ChatEvent
{
    public static string GuildChatHistory = "GuildChatHistory";//��ʷ���죨ֻ�������30�죩
    public static string GuildChat = "GuildChat";//��������
    public static string WorldChatHistory = "WorldChatHistory";//����Ƶ����ʷ�����¼
    public static string WorldReceiveChat = "WorldReceiveChat";//�յ�����Ƶ��������Ϣ�������û�Ҳ���յ�

    public static string FriendContact = "FriendContact";//��ȡ����˽����ϵ��
    public static string CreateFriendContact = "CreateFriendContact";//��������˽����ϵ��
    public static string FriendChatHisTory = "FriendChatHisTory";//����Ƶ����ʷ�����¼
    public static string FriendReceiveChat = "FriendReceiveChat";//�յ�����Ƶ��������Ϣ�������û������յ�
    public static string FriendChat = "FriendChat";//����Ƶ����������
    public static string DelFriendContact = "DelFriendContact";//ɾ������ѵ�����Ự
}


public class RechargeEvent
{
    public static string GiftPackInfo = "GiftPackInfo";//�����Ϣ
    public static string HaveGamePay = "HaveGamePay";//˫������
    public static string HaveGiftPay = "HaveGiftPay";//�������
    public static string haveDiamondPay = "haveDiamondPay";//�ػ��������
    public static string VipPay = "VipPay";//Vip����
    public static string AccRecharge = "AccRecharge";//�۳佱��
    public static string FristRecharge = "FristRecharge";//�׳佱��
    public static string RechargeInfo = "RechargeInfo";//֧�������Ϣ
    public static string MonthCard = "MonthCard";//vipÿ�ս���
    public static string VideoPay = "VideoPay";//����
    public static string Normal = "Normal";//���������
    public static string TourReward = "TourReward";//��ȡѲ���������
}

public class VipShopEvent
{
    public static string VipShopInfo = "VipShopInfo";//vip�̵���Ϣ
    public static string VipShopBuy = "VipShopBuy";//vip�̵깺��
    public static string ShopStoreInfo = "ShopStoreInfo";//�ӻ�������Ϣ
    public static string ShopStoreBuy = "ShopStoreBuy";//�ӻ����� - ����
}

public class VideoEvent
{
    public static string videoDoubleTime = "videoDoubleTime";//����Ƶ3Сʱ�����淭����17001��
    public static string videoDoubleEnd = "videoDoubleEnd";//����Ƶ3Сʱ�����淭��������17001��
    public static string videoGuildDonate = "videoGuildDonate";//����Ƶ����
}

public class GuideEvent
{
    public static string HideGuideHand = "HideGuideHand";//����������ָ
    public static string HideGuideUI = "HideGuideUI";//��������UI
    public static string NextGuide = "NextGuide";//������һ��
}

public class DressEvent
{
    public static string WearPart = "WearPart";//��������
    public static string ChangeSceneHeroModel = "ChangeSceneHeroModel";//���³����е����ģ��
    public static string DressDraw = "DressDraw";//��װ - ����
    public static string DressScoreReward = "DressScoreReward";//��װ - ������ֽ���
    public static string DressStarLv = "DressStarLv";//��װ - ��װ����
    public static string DressUpgradeLv = "DressUpgradeLv";//��װ - ��װ����
    public static string DressDrawPower = "DressDrawPower";
    public static string DressClothesBuy = "DressClothesBuy";//��װ - �·��̵깺��
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
    public static string CultivationResearchStart = "CultivationResearchStart";//�����о���ʼ
    public static string CultivationResearchCooltime = "CultivationResearchCooltime";//�����о���ȴʱ�乺��

}

public class FlowerStarEvent
{
    public static string FlowerStarSelect = "FlowerStarSelect";//����ѡ��
    public static string FlowerStarUnlock = "FlowerStarUnlock";////����
    public static string FlowerStarUpgrstar = "FlowerStarUpgrstar";//�о�
    public static string FlowerStarReplace = "FlowerStarReplace";//�滻
}


public class BattleEvent
{
    public static string SwitchNextActionUnit = "SwitchNextActionUnit";//�л���һ���ж���Ԫ
    public static string UpdateRound = "UpdateRound";//���»غ�
    public static string UpdateActionUnit = "UpdateActionUnit";//�����ж���Ԫ
    public static string ChangeTimeScale = "ChangeTimeScale";//���Ĳ����ٶ�
}


public class GuildGiftEvent
{
    public static string GuildGiftList = "GuildGiftList";//�����б�
    public static string GuildGiftInfo = "GuildGiftInfo";//��������
    public static string GuildGiftDraw = "GuildGiftDraw";//��ȡ����
    public static string GuildGiftGradient = "GuildGiftGradient";//��ȡ����
}

public class GuildPlantEvent
{
    public static string GuildHouseInfo = "GuildHouseInfo";//������Ϣ
    public static string GuildHouseEnable = "GuildHouseEnable";//��������
    public static string GuildHousePlant = "GuildHousePlant";//������ֲ
    public static string GuildHouseDetail = "GuildHouseDetail";//��������
    public static string GuildHouseHarvest = "GuildHouseHarvest";//�����ջ�
    public static string GuildHouseMembers = "GuildHouseMembers";//�����������ų�Ա��Ϣ;
}

public class GuildMatchEvent
{
    public static string GuildCompetition = "GuildCompetition";//���ž���
    public static string GuildPosTask = "GuildPosTask";// ��ȡĳ��λ�õ�����
    public static string GuildReceive = "GuildReceive";//��ȡ����
    public static string GuildRefresh = "GuildRefresh";//ˢ������
    public static string GuildSubmit = "GuildSubmit";//�ύ����
    public static string GuildSelfReward = "GuildSelfReward";//���˻��ֽ��Ƚ���
    public static string GuildProReward = "GuildProReward";//���Ż��ֽ��Ƚ���
    public static string GuildMatchRank = "GuildMatchRank";//��������
    public static string MemberMatchRank = "MemberMatchRank";//���˳�Ա����
    public static string MemberInfo = "MemberInfo";//��Ա�б�
}

public class PlayerEvent
{
    public static string PenUpgrade = "PenUpgrade";//�����Ʒ��
    public static string PenFightattr = "PenFightattr";//���ս������

    public static string GetUserInfo = "GetUserInfo";//�����û�id������ȡ������װ���̻���û���Ϣ
    public static string LoveFlowerArt = "LoveFlowerArt";//����ϲ�����ʻ����߻���Ʒ
    public static string SetAvatarFrame = "SetAvatarFrame";//�޸�ͷ���
    public static string SetTitle = "SetTitle";//�޸ĳƺ�
    public static string SetHead = "SetHead";//�޸�ͷ��
    public static string GameCrossDay = "GameCrossDay";//������

    public static string WaterBucketAward = "WaterBucketAward";//��ȡˮͰ
    public static string WaterStage = "WaterStage";//ÿ�ն�����ȡˮ��
    public static string ChangeWaterBucket = "ChangeWaterBucket";//ˮͰ���ܴ����󷵻ص�����

    public static string OpenGiftPack = "OpenGiftPack";//��������
}

public class PetEvent
{
    public static string PetInfo = "PetInfo";//������Ϣ
    public static string PetDraw = "PetDraw";//��Ȫ��������
    public static string PetUpGrade = "PetUpGrade";//����
    public static string PetStar = "PetStar";//����
    public static string PetExchange = "PetExchange";//��Ƭ�һ�����
    public static string BattlePet = "BattlePet";//��������
}

public class FlowerGoldEvent
{
    public static string FairyInfo = "FairyInfo";//������Ϣ
    public static string FairyDraw = "FairyDraw";//��ȡ������Ƭ
    public static string FairyExchange = "FairyExchange";//�һ�����
    public static string FairyUpgrade = "FairyUpgrade";//����
    public static string FairyRefresh = "FairyRefresh";//ˢ�¼�̳
    public static string BattleFairy = "BattleFairy";//��������
    public static string FairyDrawItem = "FairyDrawItem";//��ȡ������Ƭ
}

public class FloristEvent
{
    public static string FloristReward = "FloristReward";//�ʻ�������ȡ��������
    public static string FloristUpgrade = "FloristUpgrade";//�ʻ���������
    public static string FloristForge = "FloristForge";////�Ҿ߶���
    public static string FloristInfo = "FloristInfo";//�ʻ�������Ϣ
}

public class NpcEvent
{
    public static string NpcGiveGift = "NpcGiveGift";//�����������Ʒ������
    public static string NpcBuyTimes = "NpcBuyTimes";//������������������ʹ���
    public static string ChangeNpc = "ChangeNpc";//�л�npc
    public static string NpcGetReward = "NpcGetReward";//��ȡ����ȼ�����
}

public class IllEvent
{
    public static string IllCetCollect = "IllCetCollect";//ͼ�� - ��ȡ�ռ�ֵ
    public static string IllUpgradeLevel = "IllUpgradeLevel";//����
}

public class ArenaEvent
{
    public static string ArenaRankInfo = "ArenaRankInfo";//����
    public static string ArenaRankRival = "ArenaRankRival";//������Ϣ
    public static string ArenaRefreshRival = "ArenaRefreshRival";//ˢ�¶���
    public static string ArenaRefreshUser = "ArenaRefreshUser";//ˢ���û�
}

public class TaskEvent
{
    public static string MainTaskReward = "MainTaskReward";//��ȡ����������
    public static string ResMainTaskReward = "ResMainTaskReward";//��ȡ����������
    public static string MainTaskCount = "MainTaskCount";//����
    public static string TaskProAreward = "TaskProAreward";//���Ƚ���
    public static string AchievTaskInfo = "AchievTaskInfo";//�ɾ�������Ϣ
    public static string AchievTaskReward = "AchievTaskReward";//�ɾ�����-��ȡ����
}

public class FundEvent
{
    public static string FundReward = "FundReward";
}

public class PlotEvent
{
    public static string PlotWatch = "PlotWatch";//�ۿ�����
}

public class ActivityEvent
{
    public static string MonthDraw = "MonthDraw";//�¶ȳ鿨
    public static string DiamondDraw = "DiamondDraw";//��ʯ�鿨
    public static string DressDraw = "DressDraw";//��װ�鿨
    public static string MonthDrawWhetherDisplay = "MonthDrawWhetherDisplay";//�¶ȳ鿨�Ƿ�ɼ�
}

public class ExhcangeEvent
{
    public static string MonthDraw = "MonthDraw";//�¶ȳ鿨
    public static string DiamondDraw = "DiamondDraw";//��ʯ�鿨
    public static string DressDraw = "DressDraw";//��װ�鿨
    public static string FurnitureShop = "FurnitureShop";//�Ҿ��̵�
}

public class WelfareEvent
{
    public static string DailySign = "DailySign";//ǩ��
    public static string DailyRetroactive = "DailyRetroactive";//��ǩ
    public static string RookieInfo = "RookieInfo";//�ɳ�֮·��Ϣ
    public static string RookieReward = "RookieReward";//�ɳ�֮·��ȡ����
    public static string TurnTable = "TurnTable";//ת�̳齱
    public static string DailyLoginAward = "DailyLoginAward";//ÿ�յ�¼ - ��ȡ����
}

public class ContractEvent
{
    public static string Contract = "Contract";//��Լ
    public static string ContractTaskReward = "ContractTaskReward";//��Լ������
    public static string ContractLevelReward = "ContractLevelReward";//��Լ�ȼ�����
}

public class NetEvent {

    public static string TriggerNet = "TriggerNet";
}

public class FairyFlowerEvent
{
    public static string FlowerFairyInfo = "FlowerFairyInfo";//��Ϣ
    public static string FairyContractTask = "FairyContractTask";//��Լ������
    public static string FairyContractLevel = "FairyContractLevel";//��Լ�ȼ�����
    public static string FairyFiguireUp = "FairyFiguireUp";//���ɲ�Ʒ����
    public static string FairyBlindDraw = "FairyBlindDraw";//ä�г鿨
    public static string FairyDispatch = "FairyDispatch";//��ǲ����
    public static string FairyDispatchUnlock = "FairyDispatchUnlock";//������ǲλ��
    public static string FairyDispatchSpeed = "FairyDispatchSpeed";//��ǲ����
    public static string FairyDispatchHarvest = "FairyDispatchHarvest";//��ǲ�ջ�
    public static string FairyHelpApply = "FairyHelpApply";//��������
    public static string FairyHelpEffect = "FairyHelpEffect";//����������Ч
    public static string FairyBlindInfo = "FairyBlindInfo";//ä����Ϣ
}

public class ShareEvent
{
    public static string ShareLevelReward = "ShareLevelReward";//�ȼ�����
    public static string ShareIkeReward = "ShareIkeReward";//�״���������Ʒ����
    public static string ShareFlowerReward = "ShareFlowerReward";//����������
}

