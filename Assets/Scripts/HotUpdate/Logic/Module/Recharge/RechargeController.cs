using System.Collections;
using System.Collections.Generic;
using System.Linq;
using protobuf.messagecode;
using UnityEngine;
using ADK;
using protobuf.misc;
using protobuf.recharge;

public class RechargeController : BaseController<RechargeController>
{
    protected override void InitListeners()
    {
        //vip每日奖励
        AddNetListener<S_MSG_MONTH_CARD>((int)MessageCode.S_MSG_MONTH_CARD, MonthCard);

        // 礼包信息
        AddNetListener<S_MSG_GIFT_PACK_INFO>((int)MessageCode.S_MSG_GIFT_PACK_INFO, GiftPackInfo);

        //下单
        AddNetListener<S_MSG_PLACE_ORDER>((int)MessageCode.S_MSG_PLACE_ORDER, PlaceOrder);

        //发货
        AddNetListener<S_MSG_DELIVER>((int)MessageCode.S_MSG_DELIVER, Deliver);
        //累充奖励
        AddNetListener<S_MSG_ACC_RECHARGE>((int)MessageCode.S_MSG_ACC_RECHARGE, AccRecharge);
        //首充奖励
        AddNetListener<S_MSG_FIRST_RECHARGE>((int)MessageCode.S_MSG_FIRST_RECHARGE, FristRecharge);
        //支付相关信息
        AddNetListener<S_MSG_RECHARGE_INFO>((int)MessageCode.S_MSG_RECHARGE_INFO, RechargeInfo);
        //商城免费领取
        AddNetListener<S_MSG_RECHARGE_FREE>((int)MessageCode.S_MSG_RECHARGE_FREE, RechargeFree);
        //领取巡回礼包奖励
        AddNetListener<S_MSG_TOUR_REWARD>((int)MessageCode.S_MSG_TOUR_REWARD, TourReward);
    }
    //累充奖励
    public void AccRecharge(S_MSG_ACC_RECHARGE data)
    {
        RechargeModel.Instance.rechargeRewards = data.rechargeRewards;
        DispatchEvent(RechargeEvent.AccRecharge);
    }

    public void ReqAccRecharge(uint indexId)
    {
        C_MSG_ACC_RECHARGE c_MSG_ACC_RECHARGE = new C_MSG_ACC_RECHARGE();
        c_MSG_ACC_RECHARGE.indexId = indexId;
        SendCmd((int)MessageCode.C_MSG_ACC_RECHARGE, c_MSG_ACC_RECHARGE);
    }
    //首充奖励
    public void FristRecharge(S_MSG_FIRST_RECHARGE data)
    {
        RechargeModel.Instance.firstRechargeRewards = data.firstRechargeRewards;
        var dropList = ItemModel.Instance.GetDropData(data.items);
        DropManager.ShowDrop(dropList);
        DispatchEvent(RechargeEvent.FristRecharge);
    }

    public void ReqFristRecharge(uint dayNum)
    {
        C_MSG_FIRST_RECHARGE c_MSG_FIRST_RECHARGE = new C_MSG_FIRST_RECHARGE();
        c_MSG_FIRST_RECHARGE.dayNum = dayNum;
        SendCmd((int)MessageCode.C_MSG_FIRST_RECHARGE, c_MSG_FIRST_RECHARGE);
    }
    //支付相关信息
    public void RechargeInfo(S_MSG_RECHARGE_INFO data)
    {
        RechargeModel.Instance.UpdateRechargeInfo(data);
        //RechargeModel.Instance.haveDiamondValue = data.haveDiamondValue == null ? new List<uint>() : data.haveDiamondValue.ToList();
        DispatchEvent(RechargeEvent.RechargeInfo);
    }

    public void ReqRechargeInfo()
    {
        C_MSG_RECHARGE_INFO c_MSG_RECHARGE_INFO = new C_MSG_RECHARGE_INFO();
        SendCmd((int)MessageCode.C_MSG_RECHARGE_INFO, c_MSG_RECHARGE_INFO);
    }
    public void MonthCard(S_MSG_MONTH_CARD data)
    {
        var dropData = new List<StorageItemVO>();
        var target = GlobalModel.Instance.module_profileConfig.everyVipReward;
        foreach(var reward in target)
        {
            var dropItem = new StorageItemVO();
            dropItem.itemDefId = IDUtil.GetEntityValue(reward.Key);
            dropItem.count = reward.Value;
            dropData.Add(dropItem);
        }
        DropManager.ShowDrop(dropData);
        MyselfModel.Instance.behaviorDaily.monthCardAward = 1;
        DispatchEvent(RechargeEvent.MonthCard);
    }

    public void ReqMonthCard()
    {
        C_MSG_MONTH_CARD c_MSG_MONTH_CARD = new C_MSG_MONTH_CARD();
        SendCmd((int)MessageCode.C_MSG_MONTH_CARD, c_MSG_MONTH_CARD);
    }

    public void GiftPackInfo(S_MSG_GIFT_PACK_INFO data)
    {
        PopGiftModel.Instance.giftPackList = data.giftPackList;
        PopGiftModel.Instance.tourList = data.tourList;
        if (MyselfModel.Instance.tipId != 0)
        {
            UIManager.Instance.OpenWindow<PopGiftWindow>(UIName.PopGiftWindow, MyselfModel.Instance.tipId);
            MyselfModel.Instance.tipId = 0;
        }
        EventManager.Instance.DispatchEvent(RechargeEvent.GiftPackInfo);
    }

    public void ReqGiftPackInfo()
    {
        C_MSG_GIFT_PACK_INFO c_MSG_GIFT_PACK_INFO = new C_MSG_GIFT_PACK_INFO();
        SendCmd((int)MessageCode.C_MSG_GIFT_PACK_INFO, c_MSG_GIFT_PACK_INFO);
    }

    public void PlaceOrder(S_MSG_PLACE_ORDER data)
    {
        ReqDeliver(data.orderNo);
    }


    /// <summary>
    /// 下单
    /// </summary>
    /// <param name="payConfType">配置类型id  1、ft_diamond_gift_pack 2、ft_diamond_value 3、ft_game_pay </param>
    /// <param name="payDefId">/配置id</param>
    /// <param name="osType">操作系统类型 1:web 2：安卓 3：ios</param>
    /// <param name="payType">支付类型 1:微信米大师支付 2:微信jsapi支付 3：微信NATIVE支付 11:抖音钻石支付 12：抖音虚拟币支付 30：web支付</param>
    /// <param name="platformType">支付渠道 1:web 2:微信 3：抖音 4:app</param>
    public void ReqPlaceOrder(uint payConfType,uint payDefId)
    {
        C_MSG_PLACE_ORDER c_MSG_PLACE_ORDER = new C_MSG_PLACE_ORDER();
        c_MSG_PLACE_ORDER.payConfType = payConfType;
        c_MSG_PLACE_ORDER.payDefId = payDefId;
        if(Application.platform == RuntimePlatform.Android)
        {
            c_MSG_PLACE_ORDER.osType = 2;
        }
        else if(Application.platform == RuntimePlatform.IPhonePlayer)
        {
            c_MSG_PLACE_ORDER.osType = 3;
        }
        else
        {
            c_MSG_PLACE_ORDER.osType = 1;
        }
        if(LoginHelper.GetPlatform() == "app")
        {
            c_MSG_PLACE_ORDER.payType = 30;
            c_MSG_PLACE_ORDER.platformType = 4;
        }else if(LoginHelper.GetPlatform() == "wm")
        {
            c_MSG_PLACE_ORDER.payType = 30;
            c_MSG_PLACE_ORDER.platformType = 2;
        }
        else if(LoginHelper.GetPlatform() == "dev")
        {
            c_MSG_PLACE_ORDER.payType = 30;
            c_MSG_PLACE_ORDER.platformType = 1;
        }
        else
        {
            c_MSG_PLACE_ORDER.payType = 30;
            c_MSG_PLACE_ORDER.platformType = 1;
        }
        
        SendCmd((int)MessageCode.C_MSG_PLACE_ORDER, c_MSG_PLACE_ORDER);
    }

    public void Deliver(S_MSG_DELIVER data)
    {
        var dropData = ItemModel.Instance.GetDropData(data.items);
        if(dropData.Count > 0)
        {
            DropManager.ShowDrop(dropData);
        }
        else
        {
            UILogicUtils.ShowNotice(Lang.GetValue("functionBuilding_button") + Lang.GetValue("guildMatch_78"));
        }
        ReqRechargeInfo();
        if(data.payConfType == 3)
        {
            //if (!RechargeModel.Instance.haveGamePay.Contains(data.payDefId))
            //{
            //    RechargeModel.Instance.haveGamePay.Add(data.payDefId);
            //    EventManager.Instance.DispatchEvent(RechargeEvent.HaveGamePay);
            //}
        }
        else if(data.payConfType == 2)
        {
            
            if (RechargeModel.Instance.diamondValueHome.ContainsKey((int)data.payDefId))
            {
                var value = RechargeModel.Instance.diamondValueHome[(int)data.payDefId];
                switch ((E_DIAMOND_VALUE_TYPE)value.Type)
                {
                    case E_DIAMOND_VALUE_TYPE.DAILY://每日循环特惠礼包
                       
                        break;
                    case E_DIAMOND_VALUE_TYPE.NORMAL://每日循环特惠礼包
                        EventManager.Instance.DispatchEvent(RechargeEvent.Normal);
                        break;
                    case E_DIAMOND_VALUE_TYPE.VIP://Vip特权
                        
                        EventManager.Instance.DispatchEvent(RechargeEvent.VipPay);
                        break;
                    case E_DIAMOND_VALUE_TYPE.VIDEO_PRIVILEGE://视频特权
                        
                        
                         EventManager.Instance.DispatchEvent(RechargeEvent.VideoPay);
                        break;

                    case E_DIAMOND_VALUE_TYPE.CONTRACT://高级合约
                    case E_DIAMOND_VALUE_TYPE.CONTRACT_SUPER://至尊合约
                    case E_DIAMOND_VALUE_TYPE.BUY_CONTRACT_LEVEL://购买合约等级
                        var activityId = DrawModel.Instance.GetActivityId(ActivityType.Contract);
                        ContractController.Instance.ReqContractInfo((uint)activityId);
                        break;
                }
            }
               
                
            
        }
        else if (data.payConfType == 1)
        {
            RechargeController.Instance.ReqGiftPackInfo();
        }

    }

    public void ReqDeliver(string orderNo)
    {
        C_MSG_DELIVER c_MSG_DELIVER = new C_MSG_DELIVER();
        c_MSG_DELIVER.orderNo = orderNo;
        SendCmd((int)MessageCode.C_MSG_DELIVER, c_MSG_DELIVER);
    }
    //商城免费领取
    public void RechargeFree(S_MSG_RECHARGE_FREE data)
    {
        var dropList = ItemModel.Instance.GetDropData(data.items);
        DropManager.ShowDrop(dropList);
        //配置类型id  1、ft_diamond_gift_pack 2、ft_diamond_value 3、ft_game_pay
        if (data.payConfType == 1)
        {

        }else if(data.payConfType == 2)
        {
            if (RechargeModel.Instance.haveDiamondValue.ContainsKey(data.payDefId))
            {
                RechargeModel.Instance.haveDiamondValue[data.payDefId] += 1;
            }
            else
            {
                RechargeModel.Instance.haveDiamondValue.Add(data.payDefId, 1);
            }
            EventManager.Instance.DispatchEvent(RechargeEvent.Normal);
        }
        else if (data.payConfType == 3)
        {

        }


    }
    public void ReqRechargeFree(uint payConfType,uint payDefId)
    {
        C_MSG_RECHARGE_FREE c_MSG_RECHARGE_FREE = new C_MSG_RECHARGE_FREE();
        c_MSG_RECHARGE_FREE.payConfType = payConfType;
        c_MSG_RECHARGE_FREE.payDefId = payDefId;
        SendCmd((int)MessageCode.C_MSG_RECHARGE_FREE, c_MSG_RECHARGE_FREE);
    }
    //领取巡回礼包奖励
    public void TourReward(S_MSG_TOUR_REWARD data)
    {
        var dropList = ItemModel.Instance.GetDropData(data.items);
        PopGiftModel.Instance.UpdateTourList(data.tourId, data.rewardIds);
        UILogicUtils.ShowGetReward(dropList, () =>
        {
            DropManager.ShowDrop(dropList);
        });
        EventManager.Instance.DispatchEvent(RechargeEvent.TourReward);
    }

    public void ReqTourReward(uint tourId,uint indexId)
    {
        C_MSG_TOUR_REWARD c_MSG_TOUR_REWARD = new C_MSG_TOUR_REWARD();
        c_MSG_TOUR_REWARD.tourId = tourId;
        c_MSG_TOUR_REWARD.indexId = indexId;
        SendCmd((int)MessageCode.C_MSG_TOUR_REWARD, c_MSG_TOUR_REWARD);
    }
}
