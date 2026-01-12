using System;
using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using protobuf.fund;
using UnityEngine;

public class FundModel : Singleton<FundModel>
{
    public List<I_FUND_VO> fundInfo;//基金信息

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
    
    public bool GetFundRed()
    {
        if (fundInfo == null || fundInfo.Count == 0)
        {
            return false;
        }
        
        for (int type = 1; type <= 3; type++)
        {
            Ft_diamond_valueConfig diamondData = null;
            if (type == 1)
            {
                diamondData = RechargeModel.Instance.GetDiamondVo((int)E_DIAMOND_VALUE_TYPE.CASH);
            }
            else if (type == 2)
            {
                diamondData = RechargeModel.Instance.GetDiamondVo((int)E_DIAMOND_VALUE_TYPE.INTROD);
            }
            else if (type == 3)
            {
                diamondData = RechargeModel.Instance.GetDiamondVo((int)E_DIAMOND_VALUE_TYPE.STEP);
            }
            if (diamondData == null || !RechargeModel.Instance.haveDiamondValue.ContainsKey((uint)diamondData.IndexId))
            {
                continue;
            }
            
            var fundList = GetFundList(type);
            foreach (var config in fundList)
            {
                if (!IsGetted((uint)type, (uint)config.Id) && MyselfModel.Instance.level >= config.ReceiveLv)
                {
                    return true;
                }
            }
        }
        
        return false;
    }
}

