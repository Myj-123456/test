using Elida.Config;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderModel : Singleton<OrderModel>
{
    private Dictionary<int, OrderStaticRewardVo> _orderRewards;
    public Dictionary<int, OrderStaticRewardVo> orderRewards { get { 
        if(_orderRewards == null)
            {
                Ft_order_rewardConfigData rewardConfigData = ConfigManager.Instance.GetConfig<Ft_order_rewardConfigData>("ft_order_rewardsConfig");
                _orderRewards = new Dictionary<int, OrderStaticRewardVo>();
                foreach (Ft_order_rewardConfig item in rewardConfigData.DataList)
                {
                    OrderStaticRewardVo orderStaticReward = new OrderStaticRewardVo(item);
                    _orderRewards.Add(orderStaticReward.Id, orderStaticReward);
                }
            }
            return _orderRewards;
        } }
    //public void initData()
    //{
    //    Order_rewardConfigData rewardConfigData = ConfigManager.Instance.GetConfig<Order_rewardConfigData>("ft_order_rewardConfig");

    //    orderRewards = new Dictionary<int, OrderStaticRewardVo>();
    //    foreach (Order_rewardConfig item in rewardConfigData.DataList)
    //    {
    //        OrderStaticRewardVo orderStaticReward = new OrderStaticRewardVo(item);
    //        orderRewards.Add(orderStaticReward.Id, orderStaticReward);
    //    }
    //}
    /**获取加成后的金币 */
    public int GetFlowerAdditionGold(int flowerId)
    {
        if (orderRewards.ContainsKey(flowerId))
        {
            OrderStaticRewardVo info = orderRewards[flowerId];
            return info.Gold;
        }
        else
        {
            return 0;
        }
    }

    /**获取加成后的金币 */
    public int GetFlowerAdditionGold(string flowerId)
    {
        int id = int.Parse(flowerId);
        if (orderRewards.ContainsKey(id))
        {
            OrderStaticRewardVo info = orderRewards[id];
            return info.Gold;
        }
        else
        {
            return 0;
        }
    }
    /**获取加成后的经验 */
    public int GetFlowerAdditionExp(string flowerId)
    {
        int id = int.Parse(flowerId);
        if (orderRewards.ContainsKey(id))
        {
            OrderStaticRewardVo info = orderRewards[id];
            return info.Experience;
        }
        else
        {
            return 0;
        }
    }

    /**获取加成后的经验 */
    public int GetFlowerAdditionExp(int flowerId)
    {
        int id = flowerId;
        if (orderRewards.ContainsKey(id))
        {
            OrderStaticRewardVo info = orderRewards[id];
            return info.Experience;
        }
        else
        {
            return 0;
        }
    }

    public OrderStaticRewardVo GetOrderInfo(int flowerId)
    {
        if (orderRewards.ContainsKey(flowerId))
        {
            return orderRewards[flowerId];
        }
        return null;
    }
}

public class OrderStaticRewardVo
{
    public int Id { get; set; }
    public int Experience { get; set; }
    public int Gold { get; set; }

    public OrderStaticRewardVo(Ft_order_rewardConfig obj)
    {
        Id = obj.Id;
        Experience = obj.Experience;
        Gold = obj.Gold;
    }
}

