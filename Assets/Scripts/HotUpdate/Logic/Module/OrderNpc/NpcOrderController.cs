using protobuf.messagecode;
using protobuf.npcorder;
using protobuf.order;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// npc订单控制器
/// </summary>
public class NpcOrderController : BaseController<NpcOrderController>
{

    protected override void InitListeners()
    {
        AddNetListener<S_MSG_NPCORDER_LIST>((int)MessageCode.S_MSG_NPCORDER_LIST, ResGetNpcOrder);
        AddNetListener<S_MSG_NPCORDER_SUBMIT>((int)MessageCode.S_MSG_NPCORDER_SUBMIT, ResSumitOrder);
    }


    /// <summary>
    /// 接取新的NPC订单
    /// </summary>
    public void ReqGetNpcOrder()
    {
        C_MSG_NPCORDER_LIST c_MSG_NPCORDER_LIST = new C_MSG_NPCORDER_LIST();
        SendCmd((int)MessageCode.C_MSG_NPCORDER_LIST, c_MSG_NPCORDER_LIST);
    }


    private void ResGetNpcOrder(S_MSG_NPCORDER_LIST s_MSG_ORDER_SUBMIT)
    {
        NpcOrderModel.Instance.UpdateOrderNpc(s_MSG_ORDER_SUBMIT);
    }


    public void ReqSumitOrder(uint indexId, uint type)
    {
        C_MSG_NPCORDER_SUBMIT c_MSG_ORDER_SUBMIT = new C_MSG_NPCORDER_SUBMIT();
        c_MSG_ORDER_SUBMIT.indexId = indexId;
        c_MSG_ORDER_SUBMIT.type = type;
        SendCmd((int)MessageCode.C_MSG_NPCORDER_SUBMIT, c_MSG_ORDER_SUBMIT);
    }

    private void ResSumitOrder(S_MSG_NPCORDER_SUBMIT s_MSG_NPCORDER)
    {
        var sumitOrderRewards = NpcOrderModel.Instance.sumitOrderRewards;
        if (sumitOrderRewards != null)
        {
            DropManager.ShowDrop(sumitOrderRewards);
            NpcOrderModel.Instance.sumitOrderRewards = null;
        }
        if(NpcOrderModel.Instance.sumitOrderItem != null)
        {
            StorageModel.Instance.AddToStorageByItemId(NpcOrderModel.Instance.sumitOrderItem.itemDefId, -NpcOrderModel.Instance.sumitOrderItem.count);
            NpcOrderModel.Instance.sumitOrderItem = null;
        }
        NpcOrderModel.Instance.npcOrderRefreshTime = (uint)s_MSG_NPCORDER.npcOrderRefreshTime;
        NpcManager.Instance.OrderNpcLeave(s_MSG_NPCORDER.indexId, s_MSG_NPCORDER.type);

        var npcOrderVO = NpcOrderModel.Instance.GetNpcOrderVO(s_MSG_NPCORDER.indexId);
        if (npcOrderVO != null)//离开场景状态
        {
            npcOrderVO.isStandInScene = false;
            NpcOrderModel.Instance.RemoveNpcOrder(npcOrderVO);
        }
        
    }
}
