using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using protobuf.fairy;
using UnityEngine;

public class FlowerGoldModel : Singleton<FlowerGoldModel>
{
    //花仙
    public List<I_FAIRY_VO> fairys;
    //祭坛信息
    public I_ALTAR_VO altar;
    private List<FairyDataConfig> _fairyList;
    public List<FairyDataConfig> fairyList { get
        {
            if(_fairyList == null)
            {
                var fairyData = ConfigManager.Instance.GetConfig<Ft_fairy_configConfigData>("ft_fairy_configsConfig");
                _fairyList = new List<FairyDataConfig>();
                foreach (var value in fairyData.DataList)
                {
                    var fairyItem = new FairyDataConfig(value);
                    _fairyList.Add(fairyItem);
                }
            }
            return _fairyList;
        } }

    private Dictionary<string, Ft_fairy_levelConfig> _fairyLvMap;
    public Dictionary<string, Ft_fairy_levelConfig> fairyLvMap
    {
        get
        {
            if (_fairyLvMap == null)
            {
                var fairyLvData = ConfigManager.Instance.GetConfig<Ft_fairy_levelConfigData>("ft_fairy_levelsConfig");
                _fairyLvMap = fairyLvData.DataMap;
            }
            return _fairyLvMap;
        }
    }

    private Dictionary<int, Ft_fairy_luckyConfig> _fairyLuckMap;
    public Dictionary<int, Ft_fairy_luckyConfig> fairyLuckMap
    {
        get
        {
            if (_fairyLuckMap == null)
            {
                var fairyLuckData = ConfigManager.Instance.GetConfig<Ft_fairy_luckyConfigData > ("ft_fairy_luckysConfig");
                _fairyLuckMap = fairyLuckData.DataMap;
            }
            return _fairyLuckMap;
        }
    }
    //花仙羁绊表  
    private List<Ft_fairy_relationConfig> _fairyRelatMap;
    public List<Ft_fairy_relationConfig> fairyRelatMap { get
        {
            if(_fairyRelatMap == null)
            {
                var fairyRelatData = ConfigManager.Instance.GetConfig<Ft_fairy_relationConfigData>("ft_fairy_relationsConfig");
                _fairyRelatMap = fairyRelatData.DataList;
            }
            return _fairyRelatMap;
        } }

    public List<FairyDataConfig> fairyHome;

    public Ft_fairy_relationConfig GetFairyRelationInfo(int id)
    {
        return fairyRelatMap.Find(value => value.Id == id);
    }
    //获取花仙配置
    public FairyDataConfig GetFairyInfo(int id)
    {
        return fairyList.Find(value => value.Id == id);
    }

    //获取花仙配置
    public FairyDataConfig GetFairyInfo1(int shardId)
    {
        return fairyList.Find(value => value.ShardId == shardId);
    }

    //获取花仙等级配置
    public Ft_fairy_levelConfig GetFairyLvInfo(int id,int level)
    {
        var str = id + "#" + level;
        if (fairyLvMap.ContainsKey(str))
        {
            return fairyLvMap[str];
        }
        return null;
    }

    //获取花仙幸运值配置
    public Ft_fairy_luckyConfig GetFairyLuckInfo(int id)
    {
        
        if (fairyLuckMap.ContainsKey(id))
        {
            return fairyLuckMap[id];
        }
        return null;
    }
    //获取花仙服务器数据
    public I_FAIRY_VO GetFairyServerData(uint fairyId)
    {
        return fairys.Find(value => value.fairyId == fairyId);
    }
    public void UpdateFairy(I_FAIRY_VO data)
    {
        var fairyData = GetFairyServerData(data.fairyId);
        if(fairyData != null)
        {
            fairyData.level = data.level;
        }
    }

    public void FilterBookData(int quality = 0)
    {
        if (fairyHome != null)
        {
            fairyHome.Clear();
        }

        if (quality == 0)
        {
            fairyHome = new List<FairyDataConfig>(fairyList);
        }
        else
        {
            fairyHome = fairyList.FindAll(value => value.Quality == quality);
        }
        fairyHome.Sort(BookSort);
    }

    public void ParseBattleData()
    {
        if (fairyHome != null)
        {
            fairyHome.Clear();
        }
        fairyHome = fairyList.FindAll(value => value.Unlock);
        fairyHome.Sort(BattleSort);
    }

    private int BattleSort(FairyDataConfig a, FairyDataConfig b)
    {
        if (a.Quality == b.Quality)
        {
            return b.Level - a.Level;
        }
        else
        {
            return b.Quality - a.Quality;
        }
    }

    public int BookSort(FairyDataConfig a, FairyDataConfig b)
    {
        if (a.IsShard && !b.IsShard) return -1;
        if (!a.IsShard && b.IsShard) return 1;
        if (IsCanLevel(a.Id) && !IsCanLevel(b.Id)) return -1;
        if (!IsCanLevel(a.Id) && IsCanLevel(b.Id)) return 1;
        if (a.Unlock && !b.Unlock) return -1;
        if (!a.Unlock && b.Unlock) return 1;
        return b.Quality - a.Quality;
    }

    public bool IsCanLevel(int id)
    {
        var fairyInfo = GetFairyInfo(id);
       if(!fairyInfo.Unlock || fairyInfo.IsMaxLeve)
        {
            return false;
        }
        var leveInfo = GetFairyLvInfo(fairyInfo.Id, fairyInfo.Level + 1);
        var count = StorageModel.Instance.GetItemCount(fairyInfo.ShardId);
        return count >= leveInfo.CostNum;
    }
    public Dictionary<int, float> GetFairyAttr()
    {
        var attrs = new Dictionary<int, float>();
        foreach(var value in fairys)
        {
            var fairyInfo = GetFairyInfo((int)value.fairyId);
            for(int i = 1;i < value.level + 1; i++)
            {
                var lvInfo = GetFairyLvInfo(fairyInfo.Id, i);
                var attr = lvInfo.LevelAtts.Split(",");
                for(int index = 0;index < attr.Length;index++)
                {
                    var attrVo = attr[index].Split("#");
                    var attrType = int.Parse(attrVo[0]);
                    var sttrValue = float.Parse(attrVo[1]);
                    if (!attrs.ContainsKey(attrType))
                    {
                        attrs.Add(attrType, sttrValue);
                    }
                    else
                    {
                        attrs[attrType] = attrs[attrType] + sttrValue;
                    }
                }
            }
        }
        return attrs;
    }

    public Dictionary<int, float> GetFairyAttr(int id,int level)
    {
        var attrs = new Dictionary<int, float>();
        var lvInfo = GetFairyLvInfo(id, level);
        var attr = lvInfo.LevelAtts.Split(",");
        for (int index = 0; index < attr.Length; index++)
        {
            var attrVo = attr[index].Split("#");
            var attrType = int.Parse(attrVo[0]);
            var sttrValue = float.Parse(attrVo[1]);
            if (!attrs.ContainsKey(attrType))
            {
                attrs.Add(attrType, sttrValue);
            }
            else
            {
                attrs[attrType] = attrs[attrType] + sttrValue;
            }
        }
        return attrs;
    }

    public List<AttrData> GetFairyAttrList(Dictionary<int, float> attrs)
    {
        var attrList = new List<AttrData>();
        foreach(var value in attrs)
        {
            var attr = new AttrData();
            attr.type = value.Key;
            attr.value = value.Value;
            attrList.Add(attr);
        }
        return attrList;
    }

    public List<Ft_fairy_levelConfig> GetFairyLvList(int id)
    {
        var lvList = new List<Ft_fairy_levelConfig>();
        foreach (var value in fairyLvMap)
        {
            if(value.Value.FairyId == id)
            {
                lvList.Add(value.Value);
            }
        }
        lvList.Sort((a, b) => a.Level - b.Level);

        return lvList;

    }


    public float GetGoldAddRate(int flowerId)
    {
        float rate = 0;
        foreach(var value in fairys)
        {
            var fairyInfo = GetFairyInfo((int)value.fairyId);
            if (fairyInfo.Unlock)
            {
                var leveInfo = GetFairyLvInfo(fairyInfo.Id, fairyInfo.Level);
                foreach (var id in fairyInfo.FavorFlowers)
                {
                    if(flowerId == id)
                    {
                        rate += (float)leveInfo.FavorGoldUp;
                        break;
                    }
                }
            }
            
        }
        return rate/100;
    }

    public bool FettersActive(int id)
    {
        var relation = GetFairyRelationInfo(id);

        foreach (var value in relation.FairyCombinations)
        {
            if (GetFairyServerData((uint)value) == null)
            {
                return false;
            }
        }
        return true;
    }

    public int GetRelationLevel(int id)
    {
        var relation = GetFairyRelationInfo(id);
        var level = 0;
        var min = 40;
        foreach (var value in relation.FairyCombinations)
        {
            var fairyData = GetFairyServerData((uint)value);
            if(fairyData == null)
            {
                min = 0;
                break;
            }
            else if(min > fairyData.level)
            {
                min = fairyData.level;
            }
        }
        level = min == 0 ? 0 : ((min + 1) % 2);
        return level;
    }

}

public class FairyDataConfig
{
    public int Id;
    public string Name;
    public string Desc;
    public int Quality;
    public int ShardId;
    public int ComposeNum;
    public int SummonProb;
    public int[] SummonNums;
    public int[] FavorFlowers;

    public int Level { get
        {
            var fairyData = FlowerGoldModel.Instance.GetFairyServerData((uint)Id);
            if (fairyData != null)
            {
                return fairyData.level;
            }
            return 1;
        } }
    public bool Unlock
    {
        get
        {
            return FlowerGoldModel.Instance.GetFairyServerData((uint)Id) != null;
        }
    }

    public bool IsMaxLeve { get
        {
            var fairyData = FlowerGoldModel.Instance.GetFairyServerData((uint)Id);
            if (fairyData != null)
            {
                var leveInfo = FlowerGoldModel.Instance.GetFairyLvInfo(Id, fairyData.level + 1);
                return leveInfo == null;
            }
            return false;

        } }


    
    public bool IsShard { get
        {
            if (!Unlock)
            {
                var count = StorageModel.Instance.GetItemCount(ShardId);
                return count >= ComposeNum;
            }
            return false;
        } }
    public FairyDataConfig(Ft_fairy_configConfig data)
    {
        Id = data.Id;
        Name = data.Name;
        Desc = data.Desc;
        Quality = data.Quality;
        ShardId = data.ShardId;
        ComposeNum = data.ComposeNum;
        SummonProb = data.SummonProb;
        SummonNums = data.SummonNums;
        FavorFlowers = data.FavorFlowers;
    }
}


public class AttrData
{
    public int type;
    public float value;
}

