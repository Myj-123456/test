using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using protobuf.common;
using protobuf.rob;
using UnityEngine;

public class RobModel : Singleton<RobModel>
{
    public static string item_shield_id = "720119000007";
    public static string item_snatch_id = "740119000006";
    public static string item_petal_id = "740119000008";

    private Ft_rob_othersConfig _robOtherConfig;
    public Ft_rob_othersConfig robOtherConfig
    {
        get
        {
            if (_robOtherConfig == null)
            {
                Ft_rob_othersConfigData robConfigData = ConfigManager.Instance.GetConfig<Ft_rob_othersConfigData>("ft_rob_otherssConfig");
                _robOtherConfig = robConfigData.DataList[0];
            }
            return _robOtherConfig;
        }
    }

    public Dictionary<int, Ft_rob_rewardConfig> _staticRobRewardConfig;
    public Dictionary<int, Ft_rob_rewardConfig> staticRobRewardConfig
    {
        get
        {
            if (_staticRobRewardConfig == null)
            {
                Ft_rob_rewardConfigData robRewardConfig = ConfigManager.Instance.GetConfig<Ft_rob_rewardConfigData>("ft_rob_rewardsConfig");
                _staticRobRewardConfig = robRewardConfig.DataMap;
            }
            return _staticRobRewardConfig;
        }
    }

    public Dictionary<int, Ft_rob_buyConfig> _staticRobBuyConfig;
    public Dictionary<int,Ft_rob_buyConfig> staticRobBuyConfig
    {
        get
        {
            if (_staticRobBuyConfig == null)
            {
                Ft_rob_buyConfigData robBuyConfig = ConfigManager.Instance.GetConfig<Ft_rob_buyConfigData>("ft_rob_buysConfig");
                _staticRobBuyConfig = robBuyConfig.DataMap;
            }
            return _staticRobBuyConfig;
        }
    }

    public List<I_ROB_ARREST_VO> arrestList;//抓捕位信息
    public I_ROB_INFO_VO info;//农场信息
    public I_ROB_VO robInfo;//自己抢的信息
    public I_USER_PROFILE targetUserInfo;//目标玩家的用户信息
    

    // 存储已购买数量的字典
    public Dictionary<uint, int> haveBuyCount = new Dictionary<uint, int>();

    public List<I_FRIEND_VO> enemyList;//仇人列表
    public List<I_FRIEND_VO> recommendList;//推荐列表
    public List<I_FRIEND_VO> friendList;//好友列表
    public List<I_ROB_MESSAGE_VO> messageList;//抢点消息列表

    public void UpdateRobUnlock(I_ROB_ARREST_VO data)
    {
        int index = GetArrestListIndex(data.position);
        if (index == -1)
        {
            arrestList.Add(data);
        }
        else
        {
            arrestList[index] = data;
        }
    }

    public int GetArrestListIndex(uint pos)
    {
        for (int i = 0; i < arrestList.Count; i++)
        {
            if (arrestList[i].position == pos)
            {
                return i;
            }
        }
        return -1;
    }

    public I_ROB_ARREST_VO GetArrestInfo(uint pos)
    {
        return arrestList.Find((value) => value.position == pos);
    }

    public Ft_rob_rewardConfig GeRobRewardConfig(int id)
    {
        if (staticRobRewardConfig.ContainsKey(id))
        {
            return staticRobRewardConfig[id];
        }
        return null;
    }

    public Ft_rob_buyConfig GetRobBuyConfig(int indexId)
    {
        if (staticRobBuyConfig.ContainsKey(indexId))
        {
            return staticRobBuyConfig[indexId];
        }
        return null;
    }

}

