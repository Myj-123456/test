using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Elida.Config;
using protobuf.npc;
using UnityEngine;

public class CustomerModel : Singleton<CustomerModel>
{
    //居民表
    private List<NpcConfig> _npcList;
    public List<NpcConfig> npcList
    {
        get
        {
            if (_npcList == null)
            {
                _npcList = new List<NpcConfig>();
                var npcData = ConfigManager.Instance.GetConfig<Ft_npcConfigData>("ft_npcsConfig");
                foreach (var value in npcData.DataList)
                {
                    var npc = new NpcConfig(value);
                    _npcList.Add(npc);
                }
            }
            return _npcList;
        }
    }


    //居民奖励表
    private Dictionary<string, Ft_npc_rewardConfig> _npcRewardMap;
    public Dictionary<string, Ft_npc_rewardConfig> npcRewardMap
    {
        get
        {
            if (_npcRewardMap == null)
            {
                var npcRewardData = ConfigManager.Instance.GetConfig<Ft_npc_rewardConfigData>("ft_npc_rewardsConfig");
                _npcRewardMap = npcRewardData.DataMap;
            }
            return _npcRewardMap;
        }
    }
    //总好感属性加成表
    private Dictionary<int, Ft_npc_buffConfig> _npcBuffMap;
    public Dictionary<int, Ft_npc_buffConfig> npcBuffMap
    {
        get
        {
            if (_npcBuffMap == null)
            {
                var npcBuffData = ConfigManager.Instance.GetConfig<Ft_npc_buffConfigData>("ft_npc_buffsConfig");
                _npcBuffMap = npcBuffData.DataMap;
            }
            return _npcBuffMap;
        }
    }
    //喜好礼物表
    private Dictionary<int, Ft_npc_giftConfig> _npcGiftMap;

    private Dictionary<int, Ft_npc_giftConfig> npcGiftMap
    {
        get
        {
            if (_npcGiftMap == null)
            {
                var npcGiftData = ConfigManager.Instance.GetConfig<Ft_npc_giftConfigData>("ft_npc_giftsConfig");
                _npcGiftMap = npcGiftData.DataMap;
            }
            return _npcGiftMap;
        }
    }

    public List<NpcConfig> npcHome;

    public List<I_NPC_VO> customerList;
    public uint surplusGiveGiftCnt;//剩余赠送礼物次数
    public uint surplusGiveIkebanaCnt;//剩余赠送花艺品次数
    public uint buyGiftCnt;//购买赠送礼物次数
    public uint buyIkebanaCnt;//购买赠送花艺品次数
    public uint totalLevel;//总等级
    public uint totalExp;//总经验

    public void InitCustomerData(I_NPC_INFO data)
    {
        customerList = data.npcList;
        surplusGiveGiftCnt = data.surplusGiveGiftCnt;
        surplusGiveIkebanaCnt = data.surplusGiveIkebanaCnt;
        buyGiftCnt = data.buyGiftCnt;
        buyIkebanaCnt = data.buyIkebanaCnt;
        totalLevel = data.totalLevel;
        totalExp = data.totalExp;
    }
    //获取居民信息
    public NpcConfig GetNpcInfo(int id)
    {
        return npcList.Find(value => value.Id == id);
    }
    //获取居民奖励
    public Ft_npc_rewardConfig GetNpcRewardInfo(int id, int level)
    {
        var str = id + "#" + level;
        if (npcRewardMap.ContainsKey(str))
        {
            return npcRewardMap[str];
        }
        return null;
    }

    //获取总好感属性加成
    public Ft_npc_buffConfig GetNpcBuffInfo(int level)
    {
        if (npcBuffMap.ContainsKey(level))
        {
            return npcBuffMap[level];
        }
        return null;
    }
    //喜好礼物表
    public Ft_npc_giftConfig GetNpcGift(int id)
    {
        if (npcGiftMap.ContainsKey(id))
        {
            return npcGiftMap[id];
        }
        return null;
    }

    public void InitNpcBook()
    {
        npcHome = new List<NpcConfig>(npcList);
        npcHome.Sort(SortBook);
    }

    public int SortBook(NpcConfig a, NpcConfig b)
    {
        if (a.Unlock && !b.Unlock) return -1;
        if (!a.Unlock && b.Unlock) return 1;
        return a.Id - b.Id;
    }

    public List<StorageItemVO> FilterVaseData(int type = 0)
    {

        if (type != 0)
        {
            var listData = new List<StorageItemVO>();
            var vaseData = StorageModel.Instance.GetStorageListByType_1(4501);
            foreach (var value in vaseData)
            {
                var formula = IkeModel.Instance.GetFormulaByItemId(value.itemDefId);
                foreach (var cfg in formula.FlowerCombinationIds)
                {
                    var flower = FlowerHandbookModel.Instance.GetStaticSeedCondition(int.Parse(cfg.CounterCount));
                    if (flower.StyleType == type)
                    {
                        listData.Add(value);
                        break;
                    }
                }
            }
            return listData;
        }
        else
        {
            return StorageModel.Instance.GetStorageListByType_1(4501);
        }
    }

    public bool IsHaveStyle(int id, int[] styles)
    {
        var formula = IkeModel.Instance.GetFormulaByItemId(id);
        foreach (var cfg in formula.FlowerCombinationIds)
        {
            var flower = FlowerHandbookModel.Instance.GetStaticSeedCondition(int.Parse(cfg.CounterCount));
            if (Array.IndexOf(styles, flower.StyleType) != -1)
            {
                return true;
            }
        }
        return false;
    }
    //获取npc数据
    public I_NPC_VO GetNpcData(uint id)
    {
        return customerList.Find(value => value.npcId == id);
    }
    //更新npc数据
    public void UpdateNpcData(I_NPC_VO npc)
    {
        var npcData = GetNpcData(npc.npcId);
        if (npcData == null)
        {
            customerList.Add(npc);
        }
        else
        {
            npcData.level = npc.level;
            npcData.exp = npc.exp;
        }
    }

    public List<Ft_npc_rewardConfig> GetNpcRewardList(int id)
    {
        var npcList = new List<Ft_npc_rewardConfig>();
        foreach(var value in npcRewardMap)
        {
            if(value.Value.NpcId == id)
            {
                npcList.Add(value.Value);
            }
        }
        return npcList;
    }

    public void UpdateLevelReward(uint npcId,uint[] levelRewards)
    {
        var npcData = GetNpcData(npcId);
        npcData.levelRewards = levelRewards;
    }

    /// <summary>
    /// 获取所有解锁的npc配置
    /// </summary>
    /// <returns></returns>
    public List<NpcConfig> GetAllUnLockNpc()
    {
        return npcList.FindAll(value => value.Unlock);
    }
}

public class NpcConfig
{
    public int Id;
    public string Name;
    public string Idle;
    public string Head;
    public int[] LikeGifts;
    public int[] LikeLabels;
    public string Introduce;
    public int[] UnlockConditions;
    public string[] Tags;
    public string Resouce;
    public string Personality;
    public string Preference;
    public string Identity;

    public uint Level
    {
        get
        {
            var npcData = CustomerModel.Instance.GetNpcData((uint)Id);
            if (npcData != null)
            {
                return npcData.level;
            }
            return 0;
        }
    }
    public uint Exp
    {
        get
        {
            var npcData = CustomerModel.Instance.GetNpcData((uint)Id);
            if (npcData != null)
            {
                return npcData.exp;
            }
            return 0;
        }
    }

    public uint[] LevelRewards { get
        {
            var npcData = CustomerModel.Instance.GetNpcData((uint)Id);
            if (npcData != null)
            {
                return npcData.levelRewards;
            }
            return null;
        } }

    public bool Unlock
    {
        get
        {
            return UnlockConditions[0] <= MyselfModel.Instance.level;
        }
    }

    public NpcConfig(Ft_npcConfig data)
    {
        Id = data.Id;
        Name = data.Name;
        Idle = data.Idle;
        Head = data.Head;
        LikeGifts = data.LikeGifts;
        LikeLabels = data.LikeLabels;
        Introduce = data.Introduce;
        UnlockConditions = data.UnlockConditions;
        Tags = data.Tags;
        Resouce = data.Resouce;
        Preference = data.Preference;
        Personality = data.Personality;
        Identity = data.Identity;
    }
}

