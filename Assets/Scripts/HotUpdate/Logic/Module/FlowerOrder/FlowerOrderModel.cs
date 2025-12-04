using Elida.Config;
using protobuf.npcorder;
using protobuf.order;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTimer;
using static protobuf.order.I_ORDER_VO;

public class FlowerOrderModel : Singleton<FlowerOrderModel>
{
    private Dictionary<uint, I_ORDER_VO> orderDic;

    public float orthoSize;//之前的orthoSize
    public Vector3 cameraPos;//之前的cameraPos

    public I_FLOWERORDER_VO flowerOrder;//花市订单信息

    /// <summary>
    /// 初始化小黑板订单列表
    /// </summary>
    public void InitOrderList(List<I_ORDER_VO> orderList)
    {
        orderDic = new Dictionary<uint, I_ORDER_VO>();
        foreach (var order in orderList)
        {
            orderDic.Add(order.position, order);
        }
    }

    public void UpdateOrderVo(I_ORDER_VO i_ORDER_VO)
    {
        if (orderDic.ContainsKey(i_ORDER_VO.position))
        {
            orderDic[i_ORDER_VO.position] = i_ORDER_VO;
        }
    }

    public void AddOrderCdMonitor(I_ORDER_VO order)
    {
        if (order.cdTime > ServerTime.Time)//cd中
        {
            Timer.Regist(order.cdTime - ServerTime.Time, OnCdFinishCall);
        }
    }
    private void OnCdFinishCall()
    {
        if (!MyselfModel.Instance.atHome) return;
        EventManager.Instance.DispatchEvent(FlowerOrderEvent.UpdateFlowerOrderCd);
    }

    public I_ORDER_VO GetOrderVo(uint position)
    {
        if (orderDic.TryGetValue(position, out I_ORDER_VO i_ORDER_VO))
        {
            return i_ORDER_VO;
        }
        return null;
    }

    /// <summary>
    /// 获取一个可以提交的订单数据
    /// </summary>
    /// <returns></returns>
    public I_ORDER_VO GetCanSubmitOrderVo()
    {
        for (uint i = 1; i < 7; i++)
        {
            var orderVo = GetOrderVo(i);
            if (orderVo != null && orderVo.cdTime <= ServerTime.Time && GetIsEnoughByPosition(i))//获取一个未cd并且满足鲜花条件的
            {
                return orderVo;
            }
        }
        return null;
    }

    public bool CheckCanSubmit(I_ORDER_VO orderVo)
    {
        if (orderVo != null && orderVo.cdTime <= ServerTime.Time && GetIsEnoughByPosition(orderVo.position))//获取一个未cd并且满足鲜花条件的
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 检测订单所需要对应的花item是否足够
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public bool GetIsEnoughByPosition(uint position)
    {
        var enough = true;
        var order = GetOrderVo(position);
        if (order == null)
        {
            return false;
        }
        var needItems = order.needItems;
        foreach (var needItem in needItems)
        {
            var needId = needItem.Key;
            var needNum = needItem.Value;
            var have_count = StorageModel.Instance.GetItemCount((int)needId);
            if (needNum > (ulong)have_count)
            {
                enough = false;
                break;
            }
        }
        //如果是视频订单
        if (order.orderType == 2 && order.status <= 0)
        {
            enough = true;
        }
        return enough;
    }


    private Ft_daily_purposeConfigData daily_LoginConfigData;
    public Ft_daily_purposeConfig GetDailyPurposeConfig(int id)
    {
        daily_LoginConfigData ??= ConfigManager.Instance.GetConfig<Ft_daily_purposeConfigData>("ft_daily_purposesConfig");
        return daily_LoginConfigData.Get(id);
    }

    /// <summary>
    /// 是否已拉取过数据
    /// </summary>
    /// <returns></returns>
    public bool HaveReqData()
    {
        return orderDic.Count > 0;
    }
}
