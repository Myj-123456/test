using ProtoBuf;

[ProtoContract()]
public class RewardObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class InitItemObject
{
    [ProtoMember(1)]
    public string ItemEntityId;
    [ProtoMember(2)]
    public int Count;
}

[ProtoContract()]
public class InitMoneyObject
{
    [ProtoMember(1)]
    public string ItemEntityId;
    [ProtoMember(2)]
    public int Count;
}

[ProtoContract()]
public class SpecialOrderDailyLimitObject
{
    [ProtoMember(1)]
    public string Type;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class SpecialOrderDailyResetPriceObject
{
    [ProtoMember(1)]
    public string Time;
    [ProtoMember(2)]
    public int Price;
}

[ProtoContract()]
public class HelpRewardObject
{
    [ProtoMember(1)]
    public string EntityId;
    [ProtoMember(2)]
    public int Count;
}

[ProtoContract()]
public class NewPlayerGuideIdObject
{
    [ProtoMember(1)]
    public string GuideGroup;
    [ProtoMember(2)]
    public int Step;
}

[ProtoContract()]
public class GiftForWebPlayersObject
{
    [ProtoMember(1)]
    public string EntityId;
    [ProtoMember(2)]
    public int Count;
}

[ProtoContract()]
public class IdleTimeObject
{
    [ProtoMember(1)]
    public string Level;
    [ProtoMember(2)]
    public int IdleTime;
}

[ProtoContract()]
public class UnlockRewardObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class GatherRewardObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class SlotObject
{
    [ProtoMember(1)]
    public string CounterCount;
    [ProtoMember(2)]
    public int Limit;
}

[ProtoContract()]
public class FlowerCombinationIdObject
{
    [ProtoMember(1)]
    public string CounterCount;
    [ProtoMember(2)]
    public int Limit;
}

[ProtoContract()]
public class CustomPriceObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class Reward1Object
{
    [ProtoMember(1)]
    public string Level;
    [ProtoMember(2)]
    public int Limit;
}

[ProtoContract()]
public class Fx_success1Object
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class Sp_rewardObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class ItemIdObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class BreakCostObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class ProgressRewardObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class TaskRewardObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class ExpendObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class PetalConsumeObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class PetalGainObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class UnlockConsume1Object
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class UnlockConsume2Object
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class SnatchOrderObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class ShieldNumObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class ShieldCostObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class TokenNumObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class TokenCostObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class EverydayOrderObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class CompensationNumObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class ItemNumObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class NeedItemObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class UnlockConsumeObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class ItemObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class ItemsObject
{
    [ProtoMember(1)]
    public string Level;
    [ProtoMember(2)]
    public int Limit;
}

[ProtoContract()]
public class MustDropItemsObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class PayOutObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class AnimationObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class TokenObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class PriceObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class StarCostObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class ScoreRewardObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class ClearCostObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class StageRewardObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class EventRewardObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class EventChooseReward1Object
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class EventChooseReward2Object
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class KonsumsiObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class DapatkanObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class GiftRewardObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class NormalOpenCostObject
{
    [ProtoMember(1)]
    public string CounterCount;
    [ProtoMember(2)]
    public int Limit;
}

[ProtoContract()]
public class TaskRefreshObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class PersekutuanBuatObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class ShopItemObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class PowerRewardObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class LvRewardObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class FlowerRewardObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class VaseRewardObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class ClothesRewardObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class UpRewardObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class CreateCostObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class DiamondConsumptionObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class AwardObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class Award_0Object
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class Award_1Object
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class Award_2Object
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class Award_3Object
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class Award_4Object
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class Award_5Object
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class Award_6Object
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class GiftPackCostItemObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class GiftpackRewardObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class GetItemObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class RewardIdObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class ReplaceRewardObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class CommonRewardObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class AdvancedRewardObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class SupremeRewardObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class ItemRewardObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class DrawItemObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class ScoreItemObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class PoolItemObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class SpeciaConverObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class RewardPropsObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class IdentifyRewardObject
{
    [ProtoMember(1)]
    public string ItemEntityId;
    [ProtoMember(2)]
    public int Value;
}

[ProtoContract()]
public class SingleCostObject
{
    [ProtoMember(1)]
    public string EntityID;
    [ProtoMember(2)]
    public int Value;
}

