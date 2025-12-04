using ADK;
using protobuf.messagecode;
using protobuf.npcorder;
using protobuf.order;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FlowerOrderController : BaseController<FlowerOrderController>
{
    protected override void InitListeners()
    {
        AddNetListener<S_MSG_ORDER_SUBMIT>((int)MessageCode.S_MSG_ORDER_SUBMIT, ResOrderSubmit);
        AddNetListener<S_MSG_ORDER_DAILY_MISSION_REWARD>((int)MessageCode.S_MSG_ORDER_DAILY_MISSION_REWARD, ResDailyMissionReward);
        //花市订单
        AddNetListener<S_MSG_FLOWERORDER_INFO>((int)MessageCode.S_MSG_FLOWERORDER_INFO, FlowerOrderInfo);
        //提交花市订单
        AddNetListener<S_MSG_FLOWERORDER_SUBMIT>((int)MessageCode.S_MSG_FLOWERORDER_SUBMIT, FlowerOrderSubmit);
        //刷新花市订单
        AddNetListener<S_MSG_FLOWERORDER_REFRESH>((int)MessageCode.S_MSG_FLOWERORDER_REFRESH, FlowerOrderRerest);
        AddNetListener<S_MSG_ORDER_INFO>((int)MessageCode.S_MSG_ORDER_INFO, ResOderInfo);
        //视频订单观看
        AddNetListener<S_MSG_ORDER_VIDEO>((int)MessageCode.S_MSG_ORDER_VIDEO, OrderVideo);
    }

    public void ShowView()
    {
        if (!GlobalModel.Instance.GetUnlocked(SysId.Order,true))//功能未开启
        {
            return;
        }
        UIManager.Instance.OpenWindow<FlowerOrderWindow>(UIName.FlowerOrderWindow);
    }

    public void ReqOderInfo()
    {
        if (!GlobalModel.Instance.GetUnlocked(SysId.Order))
        {
            return;
        }
        C_MSG_ORDER_INFO c_MSG_ORDER_INFO = new C_MSG_ORDER_INFO();
        SendCmd((int)MessageCode.C_MSG_ORDER_INFO, c_MSG_ORDER_INFO);
    }

    private void ResOderInfo(S_MSG_ORDER_INFO s_MSG_ORDER_INFO)
    {
        FlowerOrderModel.Instance.InitOrderList(s_MSG_ORDER_INFO.orderList);
        DispatchEvent(FlowerOrderEvent.UpdateFlowerOrderInfo);
    }


    public void ReqOrderSubmit(protobuf.order.I_ORDER_VO oderVo)
    {
        C_MSG_ORDER_SUBMIT c_MSG_ORDER_SUBMIT = new C_MSG_ORDER_SUBMIT();
        c_MSG_ORDER_SUBMIT.position = oderVo.position;
        SendCmd((int)MessageCode.C_MSG_ORDER_SUBMIT, c_MSG_ORDER_SUBMIT);
        //点击就直接保存下个引导步骤(如果放到回包去存 可能会失败情况)
        //GuideController.Instance.SaveGuide(GuideModel.Instance.curGuideStep + 1);
    }

    private void ResOrderSubmit(S_MSG_ORDER_SUBMIT s_MSG_ORDER_SUBMIT)
    {
        MyselfModel.Instance.behaviorDaily.orderCnt = s_MSG_ORDER_SUBMIT.orderCnt;
        FlowerOrderModel.Instance.UpdateOrderVo(s_MSG_ORDER_SUBMIT.order);
        FlowerOrderModel.Instance.AddOrderCdMonitor(s_MSG_ORDER_SUBMIT.order);
        //消耗的道具
        foreach (KeyValuePair<ulong, ulong> keyValuePair in s_MSG_ORDER_SUBMIT.costItems)
        {
            StorageModel.Instance.AddToStorageByItemId((int)keyValuePair.Key, -(int)keyValuePair.Value);
        }
        DropManager.ShowDrop(ItemModel.Instance.GetDropData(s_MSG_ORDER_SUBMIT.items));
        DispatchEvent(FlowerOrderEvent.ResOrderSubmit);
    }

    public void ReqDailyMissionReward(uint treasureChest)
    {
        C_MSG_ORDER_DAILY_MISSION_REWARD c_MSG_ORDER_DAILY_MISSION_REWARD = new C_MSG_ORDER_DAILY_MISSION_REWARD();
        c_MSG_ORDER_DAILY_MISSION_REWARD.treasureChest = treasureChest;
        SendCmd((int)MessageCode.C_MSG_ORDER_DAILY_MISSION_REWARD, c_MSG_ORDER_DAILY_MISSION_REWARD);
    }

    private void ResDailyMissionReward(S_MSG_ORDER_DAILY_MISSION_REWARD data)
    {
        MyselfModel.Instance.behaviorDaily.orderStageAward = data.orderStageAward;
        //获得的道具
        StorageModel.Instance.AddToStorage(data.items);
        var itemsVo = ItemModel.Instance.GetDropData(data.items);
        UILogicUtils.ShowGetReward(itemsVo, () =>
        {
            DropManager.ShowDrop(itemsVo, false);
        });
        DispatchEvent(FlowerOrderEvent.ResDailyMissionReward);
    }

    public void FlowerOrderInfo(S_MSG_FLOWERORDER_INFO data)
    {
        FlowerOrderModel.Instance.flowerOrder = data.flowerOrder;
        DispatchEvent(FlowerOrderEvent.FlowerOrderInfo);
    }

    public void ReqFlowerOrderInfo()
    {
        C_MSG_FLOWERORDER_INFO c_MSG_FLOWERORDER_INFO = new C_MSG_FLOWERORDER_INFO();
        SendCmd((int)MessageCode.C_MSG_FLOWERORDER_INFO, c_MSG_FLOWERORDER_INFO);
    }

    public void FlowerOrderSubmit(S_MSG_FLOWERORDER_SUBMIT data)
    {
        FlowerOrderModel.Instance.flowerOrder.status = 1;
        var info = FlowerOrderModel.Instance.flowerOrder;
        var flowerId = info.needItems.Keys.ToArray()[0];
        var count = info.needItems.Values.ToArray()[0];
        StorageModel.Instance.AddToStorageByItemId((int)flowerId, -(int)count);
        DropManager.ShowDrop(ItemModel.Instance.GetDropData(data.items));
        DispatchEvent(FlowerOrderEvent.FlowerOrderInfo);
    }

    public void ReqFlowerOrderSubmit()
    {
        C_MSG_FLOWERORDER_SUBMIT c_MSG_FLOWERORDER_SUBMIT = new C_MSG_FLOWERORDER_SUBMIT();
        SendCmd((int)MessageCode.C_MSG_FLOWERORDER_SUBMIT, c_MSG_FLOWERORDER_SUBMIT);
    }

    public void FlowerOrderRerest(S_MSG_FLOWERORDER_REFRESH data)
    {
        FlowerOrderModel.Instance.flowerOrder = data.flowerOrder;
        DispatchEvent(FlowerOrderEvent.FlowerOrderInfo);
    }

    public void ReqFlowerOrderRerest()
    {
        C_MSG_FLOWERORDER_REFRESH c_MSG_FLOWERORDER_REFRESH = new C_MSG_FLOWERORDER_REFRESH();
        SendCmd((int)MessageCode.C_MSG_FLOWERORDER_REFRESH, c_MSG_FLOWERORDER_REFRESH);
    }
    //视频订单观看
    public void OrderVideo(S_MSG_ORDER_VIDEO data)
    {
        var orderData = FlowerOrderModel.Instance.GetOrderVo(1);
        orderData.status = 1;
        DispatchEvent(FlowerOrderEvent.ResOrderSubmit);
    }

    public void ReqOrderVideo(uint postion)
    {
        C_MSG_ORDER_VIDEO c_MSG_ORDER_VIDEO = new C_MSG_ORDER_VIDEO();
        c_MSG_ORDER_VIDEO.position = postion;
        SendCmd((int)MessageCode.C_MSG_ORDER_VIDEO, c_MSG_ORDER_VIDEO);
    }
}
