using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using protobuf.flowerstar;
using UnityEngine;

public class FlowerStarModel : Singleton<FlowerStarModel>
{
    //所有花朵信息
    public List<I_FLOWERSTAR_VO> flowerStarVo;

    private Dictionary<int, Ft_flower_star_additionConfig> _flowerStarAdditioConfig;
    //buff加成
    public Dictionary<int, Ft_flower_star_additionConfig> flowerStarAdditioConfig
    {
        get
        {
            if(_flowerStarAdditioConfig == null)
            {
                var starConfig = ConfigManager.Instance.GetConfig<Ft_flower_star_additionConfigData>("ft_flower_star_additionsConfig");
                _flowerStarAdditioConfig = starConfig.DataMap;
            }
            return _flowerStarAdditioConfig;
        }
    }

    private List<Ft_flower_star_additionConfig> _flowerStarAdditioList;
    //buff加成
    public List<Ft_flower_star_additionConfig> flowerStarAdditioList
    {
        get
        {
            if (_flowerStarAdditioList == null)
            {
                var starConfig = ConfigManager.Instance.GetConfig<Ft_flower_star_additionConfigData>("ft_flower_star_additionsConfig");
                _flowerStarAdditioList = starConfig.DataList;
            }
            return _flowerStarAdditioList;
        }
    }

    private Dictionary<int, Ft_flower_star_refreshConfig> _flowerStarRefreshConfig;
    //buff研究
    public Dictionary<int, Ft_flower_star_refreshConfig> flowerStarRefreshConfig
    {
        get
        {
            if (_flowerStarRefreshConfig == null)
            {
                var starConfig = ConfigManager.Instance.GetConfig<Ft_flower_star_refreshConfigData>("ft_flower_star_refreshsConfig");
                _flowerStarRefreshConfig = starConfig.DataMap;
            }
            return _flowerStarRefreshConfig;
        }
    }
    public Ft_flower_star_additionConfig GetBuffConfig(int buffId)
    {
        if (flowerStarAdditioConfig.ContainsKey(buffId)){
            return flowerStarAdditioConfig[buffId];
        }
        return null;
    }
    //获取花的buff信息
    public I_FLOWERSTAR_VO GetFlowerStarInfo(int flowerId)
    {
        return flowerStarVo.Find((value) => value.flowerId == (uint)flowerId);
    }
    //更新buff信息
    public void UpdateBuffInfo(uint flowerId,uint pos,uint buffId)
    {
        var buffInfo = flowerStarVo.Find((value) => value.flowerId == (uint)flowerId);
        if(buffInfo != null)
        {
            buffInfo.buff[pos] = buffId;
        }
        else
        {
            var starInfo = new I_FLOWERSTAR_VO();
            starInfo.flowerId = flowerId;
            starInfo.buff = new Dictionary<uint, uint>();
            starInfo.upgradeBuff = new Dictionary<uint, uint>();
            for(uint i = 1;i < 4; i++)
            {
                starInfo.buff.Add(i, 0);
                starInfo.upgradeBuff.Add(i, 0);
            }
            starInfo.buff[pos] = buffId;
            flowerStarVo.Add(buffInfo);
        }
        
    }
    //更新研究buff信息
    public void UpdateUpgradeBuffInfo(uint flowerId, uint pos, uint buffId)
    {
        var buffInfo = flowerStarVo.Find((value) => value.flowerId == (uint)flowerId);
        if (buffInfo != null)
        {
            buffInfo.upgradeBuff[pos] = buffId;
        }
        else
        {
            var starInfo = new I_FLOWERSTAR_VO();
            starInfo.flowerId = flowerId;
            starInfo.buff = new Dictionary<uint, uint>();
            starInfo.upgradeBuff = new Dictionary<uint, uint>();
            for (uint i = 1; i < 4; i++)
            {
                starInfo.buff.Add(i, 0);
                starInfo.upgradeBuff.Add(i, 0);
            }
            starInfo.upgradeBuff[pos] = buffId;
            flowerStarVo.Add(starInfo);
        }
    }
    //根据type获取buff
    public List<Ft_flower_star_additionConfig> GetProperty(int type)
    {
        var ls = flowerStarAdditioList.FindAll((value) => value.AdditionKind == type);
        ls.Sort((a, b) =>
        {
            if (a.AdditionNum == b.AdditionNum)
            {
                return a.AdditionPercent - b.AdditionPercent;
            }
            else
            {
                return a.AdditionNum - b.AdditionNum;
            }
        });
        return ls;
    }

    public List<int> GetPropertyRange(int type)
    {
        var ls = GetProperty(type);
        var range = new List<int>();
        if(ls[0].NumKind == 1)
        {
            range.Add(ls[0].AdditionPercent);
            range.Add(ls[ls.Count - 1].AdditionPercent);
        }
        else
        {
            range.Add(ls[0].AdditionNum);
            range.Add(ls[ls.Count - 1].AdditionNum);
        }
        return range;
    }

    public int GetPropertyRangeIndex(int id,int additionId)
    {
        var ls = GetProperty(additionId);
        for(var i = 0;i < ls.Count; i++)
        {
            if(ls[i].ID == id)
            {
                return i;
            }
        }
        return 0;
    }

    public List<SeedCropVO> GetFlowersList()
    {
        var minFlowerLv = GlobalModel.Instance.module_profileConfig.flowerStarPremise[0];
        var flowers = StorageModel.Instance.seedList;
        return flowers.FindAll((value) => value.level >= minFlowerLv);
    }

    //根据鲜花id获取加成数量
    public int GetAddCount(int id,int type)
    {
        var count = 0;
        var starData = GetFlowerStarInfo(id);
        if(starData != null)
        {
            foreach (var star in starData.buff)
            {
                var buffConfig = GetBuffConfig((int)star.Value);
                if (buffConfig != null && buffConfig.NumKind != 1 && buffConfig.AdditionKind == type)
                {
                    count += buffConfig.AdditionNum;
                }
            }
        }
        return count;
    }

    public float GetAddRate(int id, int type)
    {
        var rate = 0f;
        var starData = GetFlowerStarInfo(id);
        if (starData != null)
        {
            foreach (var star in starData.buff)
            {
                var buffConfig = GetBuffConfig((int)star.Value);
                if (buffConfig != null && buffConfig.NumKind == 1 && buffConfig.AdditionKind == type)
                {
                    rate += ((float)buffConfig.AdditionPercent / 100f);
                }
            }
        }
        return rate;
    }

    public int GetStarCount()
    {
        var count = 0;
        if(flowerStarVo != null)
        {
            foreach(var star in flowerStarVo)
            {
                foreach(var buff in star.buff)
                {
                    if(buff.Value != 0)
                    {
                        count ++;
                    }
                }
            }
        }
        return count;
    }
}

