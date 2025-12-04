using System;
using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using protobuf.fund;
using UnityEngine;

public class FundModel : Singleton<FundModel>
{
    public List<I_FUND_VO> fundInfo;//ÅàÓý»ù½ð

    private Dictionary<int, Ft_fundConfig> _fundMap;
    public Dictionary<int, Ft_fundConfig> fundMap { get
        {
            if(_fundMap == null)
            {
                var fundData = ConfigManager.Instance.GetConfig<Ft_fundConfigData>("ft_fundsConfig");
                _fundMap = fundData.DataMap;
            }
            return _fundMap;
        } }

    public Ft_fundConfig GetFundInfo(int id)
    {
        if (fundMap.ContainsKey(id))
        {
            return fundMap[id];
        }
        return null;
    }

    public List<Ft_fundConfig> GetFundList(int type)
    {
        var list = new List<Ft_fundConfig>();
        foreach(var value in fundMap)
        {
            if(value.Value.FundType == type)
            {
                list.Add(value.Value);
            }
        }
        return list;
    }

    public I_FUND_VO GetFundData(uint type)
    {
        return fundInfo.Find(value => value.fundType == type);
    }

    public bool IsGetted(uint type,uint id)
    {
        var fundData = GetFundData(type);
        if(fundData.stageReward == null || Array.IndexOf(fundData.stageReward,id) == -1)
        {
            return false;
        }
        return true;
    }

    public void UpdateFundData(I_FUND_VO fund)
    {
        var fundData = GetFundData(fund.fundType);
        fundData.triggerTime = fund.triggerTime;
        fundData.stageReward = fund.stageReward;
    }
}

