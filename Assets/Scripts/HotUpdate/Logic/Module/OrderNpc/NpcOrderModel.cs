using protobuf.login;
using protobuf.npcorder;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NpcOrderVO
{
    /**
     * NPC路线ID
     */
    public uint indexId;

    /**
     * 订单ID
     */
    public uint orderId;

    /**
     * NPC
     */
    public uint npc;

    /**
     * 是否是翻倍订单
     */
    public uint isDouble;

    /**
     * 是不是old的npc
     */
    public bool isOld;

    public uint expBuff;//经验加成，exp*(expBuff/100+1)
    public uint goldBuff;//金币加成，如上

    /**
     * 需求数量
     */
    public uint ratio = 1;

    public uint isJump = 0;//该顾客订单是否被玩家手动跳过

    public bool hasRejected;

    public bool isStandInScene = false;//是否站立在场景中


    public void Parse(protobuf.npcorder.I_NPCORDER_VO data)
    {
        indexId = data.indexId;
        orderId = data.orderId;
        ratio = data.ratio;
        npc = data.npc;
        isDouble = data.isDouble;
    }
}
/// <summary>
/// npc订单数据
/// </summary>
public class NpcOrderModel : Singleton<NpcOrderModel>
{
    public uint npcOrderRefreshTime;//上次NPC订单刷新时间

    public List<NpcOrderVO> npcOrderList;
    public Dictionary<uint, NpcOrderVO> npcOrderDic;

    public List<StorageItemVO> sumitOrderRewards;

    public StorageItemVO sumitOrderItem;
    public void InitOrderNpc(S_MSG_GAMEINIT data)
    {
        npcOrderDic = new Dictionary<uint, NpcOrderVO>();
        npcOrderList = new List<NpcOrderVO>();
        npcOrderRefreshTime = data.npcOrderRefreshTime;
        foreach (var npcNew in data.npcOrderNewList)
        {
            var npcOrderVO = new NpcOrderVO();
            npcOrderVO.Parse(npcNew);
            npcOrderVO.isOld = false;
            npcOrderList.Add(npcOrderVO);
            npcOrderDic.Add(npcOrderVO.indexId, npcOrderVO);
        }
        foreach (var npcOld in data.npcOrderOldList)
        {
            var npcOrderVO = new NpcOrderVO();
            npcOrderVO.Parse(npcOld);
            npcOrderVO.isOld = true;
            npcOrderList.Add(npcOrderVO);
            npcOrderDic.Add(npcOrderVO.indexId, npcOrderVO);
        }
    }


    public void UpdateOrderNpc(S_MSG_NPCORDER_LIST data)
    {
        npcOrderRefreshTime = (uint)data.npcOrderRefreshTime;//刷新为当前服务器时间
        foreach (var npcNew in data.npcOrderNewList)
        {
            var npcOrderVO = GetNpcOrderVO(npcNew.indexId);
            if (npcOrderVO == null)
            {
                npcOrderVO = new NpcOrderVO();
                npcOrderList.Add(npcOrderVO);
                npcOrderDic.Add(npcNew.indexId, npcOrderVO);
            }
            npcOrderVO.Parse(npcNew);
            npcOrderVO.isOld = true;

            if (!TaskModel.Instance.CheckIsCompleteTask(10))//未完成顾客订单任务
            {
                npcOrderVO.isOld = true;
            }
            else
            {
                npcOrderVO.isOld = false;
            }
            NpcManager.Instance.CreateNpcOrder(npcOrderVO, false);
        }
    }

    public NpcOrderVO GetNpcOrderVO(uint orderId)
    {
        if (npcOrderDic.TryGetValue(orderId, out NpcOrderVO npcOrderVO))
        {
            return npcOrderVO;
        }
        return null;
    }

    /// <summary>
    /// 移除npc订单数据(在拒绝和完成时候调用下)
    /// </summary>
    /// <param name="npcOrderVO"></param>
    public void RemoveNpcOrder(NpcOrderVO npcOrderVO)
    {
        if (npcOrderVO == null) return;
        if (npcOrderDic.ContainsKey(npcOrderVO.indexId))
        {
            npcOrderDic.Remove(npcOrderVO.indexId);
            npcOrderList.Remove(npcOrderVO);
        }
    }

    /// <summary>
    /// 获取站场订单npc列表
    /// </summary>
    /// <returns></returns>
    public List<NpcOrderVO> GetStandNpcOrderList()
    {
        List<NpcOrderVO> list = new List<NpcOrderVO>(npcOrderList.Count);
        foreach (var npcOrder in npcOrderList)
        {
            if (npcOrder.isStandInScene)
            {
                list.Add(npcOrder);
            }
        }
        return list;
    }


}
