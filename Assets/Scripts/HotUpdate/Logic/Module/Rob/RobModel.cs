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

    public List<I_ROB_ARREST_VO> arrestList;//抓捕位置信息
    public I_ROB_INFO_VO info;//抓花农信息
    public I_ROB_VO robInfo;//我被抓的信息
    public I_USER_PROFILE targetUserInfo;//抓捕我的人的用户信息

    public List<I_FRIEND_VO> enemyList;//冤家列表
    public List<I_FRIEND_VO> recommendList;//推荐列表
    public List<I_FRIEND_VO> friendList;////好友列表
    public List<I_ROB_MESSAGE_VO> messageList;//抓捕日志

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
}

