using ADK;
using Elida.Config;
using protobuf.dress;
using protobuf.item;
using protobuf.login;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum DressPartType
{
    Hair = 1,//头发
    Skirt,//裙子
    Up_clothes,//上衣
    Dw_clothes,//下衣
    Shoe,//鞋子
    Face,//脸部
    Accessories,//配件
    Ear//耳朵(仅用于旧版客户端，新版客户端需要替换)
}

/// <summary>
/// 穿戴数据
/// </summary>
public class DressData
{
    public int clothesId; // 穿戴ID(对应商品id)
    public Ft_suit_dressConfig ft_Dress_Config;//状态配置
}
/// <summary>
/// 穿戴模型
/// </summary>
public class DressModel : Singleton<DressModel>
{
    private Dictionary<int, DressData> clientWearDic;//当前穿戴列表
    private Dictionary<int, DressData> serverWearDic;//服务器穿戴列表
    public List<I_SUIT_VO> suits;//穿戴列表
    public uint score;//积分
    public uint rewardId;//奖励id
    public List<I_ITEM_VO> itemList;//获得的物品列表
    public uint dressShopExp;// DressShop经验值

    public void InitData(S_MSG_DRESS_INFO data)
    {
        score = data.score;
        rewardId = data.rewardId;
        suits = data.suitList;
        dressShopExp = data.dressShopExp;
        
        // 初始化客户端穿戴列表
        if (clientWearDic == null)
        {
            clientWearDic = new Dictionary<int, DressData>();
        }
    }
    // 套装列表
    private List<SuitConfig> _suitList;
    public List<SuitConfig> suitList
    {
        get
        {
            if (_suitList == null)
            {
                var suitData = ConfigManager.Instance.GetConfig<Ft_suit_configConfigData>("ft_suit_configsConfig");
                _suitList = new List<SuitConfig>();
                foreach (var value in suitData.DataList)
                {
                    var suit = new SuitConfig(value);
                    _suitList.Add(suit);
                }
            }
            return _suitList;
        }
    }
    // 时装商店
    private List<Ft_shop_clothesConfig> _dressShopList;
    public List<Ft_shop_clothesConfig> dressShopList { get
        {
            if(_dressShopList == null)
            {
                var dressShopData = ConfigManager.Instance.GetConfig<Ft_shop_clothesConfigData>("ft_shop_clothessConfig");
                _dressShopList = dressShopData.DataList;
            }
            return _dressShopList;
        } }

    // 时装商店等级列表
    private List<Ft_shop_cloLvConfig> _shopLvList;
    public List<Ft_shop_cloLvConfig> shopLvList { get
        {
            if(_shopLvList == null)
            {
                var shopLvData = ConfigManager.Instance.GetConfig<Ft_shop_cloLvConfigData>("ft_shop_cloLvsConfig");
                _shopLvList = shopLvData.DataList;
            }
            return _shopLvList;
        } }
    // 套装等级列表
    private Dictionary<string, Ft_suit_starConfig> _suitStarMap;
    public Dictionary<string, Ft_suit_starConfig> suitStarMap
    {
        get
        {
            if (_suitStarMap == null)
            {
                var suitStarData = ConfigManager.Instance.GetConfig<Ft_suit_starConfigData>("ft_suit_starsConfig");
                _suitStarMap = suitStarData.DataMap;
            }
            return _suitStarMap;
        }
    }

    private Dictionary<int, Ft_suit_skillConfig> _skillMap;
    public Dictionary<int, Ft_suit_skillConfig> skillMap { get
        {
            if(_skillMap == null)
            {
                var skillData = ConfigManager.Instance.GetConfig<Ft_suit_skillConfigData>("ft_suit_skillsConfig");
                _skillMap = skillData.DataMap;
            }
            return _skillMap;
        } }

    // 套装升级配置
    private Dictionary<string, Ft_suit_advanceConfig> _suitAdvanceMap;
    public Dictionary<string, Ft_suit_advanceConfig> suitAdvanceMap
    {
        get
        {
            if (_suitAdvanceMap == null)
            {
                var suitAdvanceData = ConfigManager.Instance.GetConfig<Ft_suit_advanceConfigData>("ft_suit_advancesConfig");
                _suitAdvanceMap = suitAdvanceData.DataMap;
            }
            return _suitAdvanceMap;
        }
    }
    // 套装绘制配置
    private List<Ft_suit_drawConfig> _suitDrawList;
    public List<Ft_suit_drawConfig> suitDrawList
    {
        get
        {
            if (_suitDrawList == null)
            {
                var suitDrawData = ConfigManager.Instance.GetConfig<Ft_suit_drawConfigData>("ft_suit_drawsConfig");
                _suitDrawList = suitDrawData.DataList;
            }
            return _suitDrawList;
        }
    }

    // 套装奖励配置
    private Dictionary<int, Ft_suit_dRewardConfig> _suitRewardMap;
    public Dictionary<int, Ft_suit_dRewardConfig> suitRewardMap
    {
        get
        {
            if (_suitRewardMap == null)
            {
                var suitRewardData = ConfigManager.Instance.GetConfig<Ft_suit_dRewardConfigData>("ft_suit_dRewardsConfig");
                _suitRewardMap = suitRewardData.DataMap;
            }
            return _suitRewardMap;
        }
    }
    // 套装脱下配置
    private Dictionary<int, Ft_suit_backConfig> _suitBackMap;
    public Dictionary<int, Ft_suit_backConfig> suitBackMap
    {
        get
        {
            if (_suitBackMap == null)
            {
                var suitBackData = ConfigManager.Instance.GetConfig<Ft_suit_backConfigData>("ft_suit_backsConfig");
                _suitBackMap = suitBackData.DataMap;
            }
            return _suitBackMap;
        }
    }

    // 套装穿戴配置
    private Dictionary<int, Ft_suit_dressConfig> _suitDressMap;
    public Dictionary<int, Ft_suit_dressConfig> suitDressMap
    {
        get
        {
            if (_suitDressMap == null)
            {
                var suitDressData = ConfigManager.Instance.GetConfig<Ft_suit_dressConfigData>("ft_suit_dresssConfig");
                _suitDressMap = suitDressData.DataMap;
            }
            return _suitDressMap;
        }
    }
    private List<DressConfig> _suitDressList;
    public List<DressConfig> suitDressList { get
        {
            if(_suitDressList == null)
            {
                var suitData = ConfigManager.Instance.GetConfig<Ft_suit_dressConfigData>("ft_suit_dresssConfig");
                _suitDressList = new List<DressConfig>();
                foreach (var value in suitData.DataList)
                {
                    var suit = new DressConfig(value);
                    _suitDressList.Add(suit);
                }
            }
            return _suitDressList;
        } }
    private List<StorageItemVO> _defaultDress;
    public List<StorageItemVO> defaultDress
    {
        get
        {
            if (_defaultDress == null)
            {
                _defaultDress = new List<StorageItemVO>();
                foreach (var value in suitDressMap)
                {
                    if (value.Value.IsDefault == 1)
                    {
                        var dress = new StorageItemVO();
                        var ItemVo = ItemModel.Instance.GetItemById(value.Key);
                        dress.item = ItemVo;
                        dress.count = 1;
                        dress.itemDefId = value.Key;
                        _defaultDress.Add(dress);
                    }
                }
            }
            return _defaultDress;
        }
    }
    public Ft_suit_skillConfig GetSuitSkillInfo(int id)
    {
        if (skillMap.ContainsKey(id))
        {
            return skillMap[id];
        }
        return null;
    }
    public Ft_suit_skillConfig GetSuitSkillInfo1(int type)
    {
       foreach(var value in skillMap)
        {
            if(value.Value.SkillType == type)
            {
                return value.Value;
            }
        }
        return null;
    }
    public Ft_shop_clothesConfig GetDressShopInfo(int id)
    {
        return dressShopList.Find(value => value.Id == id);
    }
    public Ft_shop_clothesConfig GetDressShopInfo1(int itemId)
    {
        foreach(var value in dressShopList)
        {
            var itemVo = ItemModel.Instance.GetItemByEntityID(value.ItemIds[0].EntityID);
            if(itemId == itemVo.ItemDefId)
            {
                return value;
            }
        }
        return null;
    }
    public DressConfig GetDressInfo(int id)
    {
        return suitDressList.Find(value => value.ClothesId == id);
    }
    public Dictionary<int, DressData> GetDefaultDress()
    {
        var dressMap = new Dictionary<int, DressData>();
        foreach(var value in defaultDress)
        {
            var dress = new DressData();
            dress.clothesId = value.itemDefId;
            var dressVo = GetDressConfig(value.itemDefId);
            dress.ft_Dress_Config = dressVo;
            dressMap.Add(dressVo.Type, dress);
        }
        return dressMap;
    }

    public List<SuitConfig> dressHome;
    public List<DressConfig> suitDressHome;
    // 套装信息
    public SuitConfig GetSuitInfo(int id)
    {
        return suitList.Find(value => value.Id == id);
    }
    // 套装数量
    public int GetSuitCount()
    {
        var list = suitList.FindAll(value => value.HaveCount >= value.ContainDress.Length);
        return list.Count;
    }

    // 套装星级信息
    public Ft_suit_starConfig GetSuitStarInfo(int id, int starLv)
    {
        string key = id + "#" + starLv;
        if (suitStarMap.ContainsKey(key))
        {
            return suitStarMap[key];
        }
        return null;
    }
    // 套装升级配置
    public Ft_suit_advanceConfig GetSuitAdvanceInfo(int id, int advanceLv)
    {
        string key = id + "#" + advanceLv;
        if (suitAdvanceMap.ContainsKey(key))
        {
            return suitAdvanceMap[key];
        }
        return null;
    }
    // 套装绘制配置
    public Ft_suit_drawConfig GetSuitDrawInfo(int id)
    {

        return suitDrawList.Find(value => value.Id == id);
    }
    // 套装奖励配置
    public Ft_suit_dRewardConfig GetSuitRewardInfo(int id)
    {

        if (suitRewardMap.ContainsKey(id))
        {
            return suitRewardMap[id];
        }
        return null;
    }
    // 套装脱下配置
    public Ft_suit_backConfig GetSuitBackInfo(int id)
    {

        if (suitBackMap.ContainsKey(id))
        {
            return suitBackMap[id];
        }
        return null;
    }
    /// <summary>
    /// 套装脱装备配置
    /// </summary>
    /// <param name="clothesId"></param>
    /// <returns></returns>
    public Ft_suit_dressConfig GetDressConfig(int clothesId)
    {
        if (suitDressMap.ContainsKey(clothesId))
        {
            return suitDressMap[clothesId];
        }
        return null;
    }

    /// <summary>
    /// 获取套装部位的物品列表
    /// </summary>
    /// <returns></returns>
    public List<StorageItemVO> GetPartItemList(int dressPartType)
    {
        List<StorageItemVO> storageItemVOs = new List<StorageItemVO>();
        var dressStorageList = StorageModel.Instance.GetStorageListByCategory((int)CategoryType.Dress);
        foreach (var dress in defaultDress)
        {
            if (dressStorageList.Find(value => value.itemDefId == dress.itemDefId) == null)
            {
                dressStorageList.Add(dress);
            }
        }
        if (dressPartType > 0)
        {


            foreach (var dressStorage in dressStorageList)
            {
                var ft_dress_config = GetDressConfig(dressStorage.itemDefId);
                if (ft_dress_config != null && ft_dress_config.Type == dressPartType)
                {
                    storageItemVOs.Add(dressStorage);
                }
            }
            //return storageItemVOs;
        }
        else
        {
            storageItemVOs = dressStorageList;
        }
        return storageItemVOs;
    }


    public int GetDressCount()
    {
        var dressData = GetPartItemList(0);
        return dressData.Count;
    }


    /// <summary>
    /// 获取客户端装备列表
    /// </summary>
    /// <returns></returns>
    public uint[] GetClientWearList()
    {
        List<uint> wearList = new List<uint>();
        
        // 确保clientWearDic已经初始化
        if (clientWearDic != null)
        {
            foreach (var clientWear in clientWearDic)
            {
                wearList.Add((uint)clientWear.Value.clothesId);
            }
        }
        
        return wearList.ToArray();
    }

    /// <summary>
    /// 获取服务器装备列表
    /// </summary>
    /// <returns></returns>
    public uint[] GetServerWearList()
    {
        List<uint> wearList = new List<uint>();
        foreach (var serverWear in serverWearDic)
        {
            wearList.Add((uint)serverWear.Value.clothesId);
        }
        return wearList.ToArray();
    }


    /// <summary>
    /// 更新服务器装备列表
    /// </summary>
    /// <param name="dressList"></param>
    public void UpdateDressData(uint[] dressList)
    {
        serverWearDic = new Dictionary<int, DressData>();
        foreach (var dressId in dressList)
        {
            var dressData = new DressData();
            dressData.clothesId = (int)dressId;
            var ft_dress_config = GetDressConfig(dressData.clothesId);
            if (ft_dress_config != null)
            {
                dressData.ft_Dress_Config = ft_dress_config;
                serverWearDic.Add(dressData.ft_Dress_Config.Type, dressData);
            }
        }
    }


    /// <summary>
    /// 获取装备数据字典
    /// </summary>
    /// <param name="dressList"></param>
    public Dictionary<int, DressData> GetDressData(uint[] dressList)
    {
        var dressDatas = new Dictionary<int, DressData>();
        if (dressList == null)
            return dressDatas;
            
        foreach (var dressId in dressList)
        {
            var dressData = new DressData();
            dressData.clothesId = (int)dressId;
            var ft_dress_config = GetDressConfig(dressData.clothesId);
            if (ft_dress_config != null)
            {
                dressData.ft_Dress_Config = ft_dress_config;
                dressDatas.Add(dressData.ft_Dress_Config.Type, dressData);
            }
        }
        return dressDatas;
    }


    /// <summary>
    /// 更新客户端装备数据
    /// </summary>
    public void UpdateClientWearData()
    {
        clientWearDic = new Dictionary<int, DressData>();
        foreach (var serverWear in serverWearDic)
        {
            var dressData = new DressData();
            dressData.clothesId = serverWear.Value.clothesId;
            var ft_dress_config = GetDressConfig(dressData.clothesId);
            if (ft_dress_config != null)
            {
                dressData.ft_Dress_Config = ft_dress_config;
                clientWearDic.Add(dressData.ft_Dress_Config.Type, dressData);
            }
        }
    }

    public Dictionary<int, DressData> GetClientWearData()
    {
        var map = new Dictionary<int, DressData>();
        foreach (var value in clientWearDic)
        {
            var dress = new DressData();
            dress.clothesId = value.Value.clothesId;
            dress.ft_Dress_Config = value.Value.ft_Dress_Config;
            map.Add(value.Key, dress);
        }
        return map;
    }

    public void UpdateClientWearDic(Dictionary<int, DressData> data)
    {
        clientWearDic.Clear();
        foreach(var value in data)
        {
            var dress = new DressData();
            dress.clothesId = value.Value.clothesId;
            dress.ft_Dress_Config = value.Value.ft_Dress_Config;
            clientWearDic.Add(value.Key, dress);
        }
    }

    /// <summary>
    /// <summary>
    /// 穿戴（改变客户端缓存）
    /// </summary>
    /// </summary>
    public void Wear(uint clothesId)
    {
        var ft_dress_config = GetDressConfig((int)clothesId);
        if (ft_dress_config != null)
        {
            if (ft_dress_config.Type == (int)DressPartType.Skirt)//如果穿的是连衣裙，那么需要脱下上下装
            {
                TakeOff((int)DressPartType.Up_clothes);
                TakeOff((int)DressPartType.Dw_clothes);
            }
            else if (ft_dress_config.Type == (int)DressPartType.Up_clothes || ft_dress_config.Type == (int)DressPartType.Dw_clothes)//如果穿的是上装或下装，那么需要脱下连衣裙
            {
                TakeOff((int)DressPartType.Skirt);
            }
            if (clientWearDic.TryGetValue(ft_dress_config.Type, out DressData wearDressData))//如果当前位置已经有装备了，那么需要先脱下
            {
                wearDressData.clothesId = (int)clothesId;
                wearDressData.ft_Dress_Config = ft_dress_config;
            }
            else//如果当前位置没有装备，那么直接穿上
            {
                var dressData = new DressData();
                dressData.clothesId = (int)clothesId;
                dressData.ft_Dress_Config = ft_dress_config;
                clientWearDic.Add(dressData.ft_Dress_Config.Type, dressData);
            }
        }
    }


    /// <summary>
    /// 脱下某个部位的装备（改变客户端缓存）
    /// </summary>
    public void TakeOff(int type)
    {
        if (clientWearDic.ContainsKey(type))
        {
            clientWearDic.Remove(type);
        }
    }

    /// <summary>
        /// 脱下指定衣服id
    /// </summary>
    public void TakeOff(uint clothesId)
    {
        var ft_dress_config = GetDressConfig((int)clothesId);
        if (ft_dress_config != null)
        {
            if (clientWearDic.ContainsKey(ft_dress_config.Type))
            {
                clientWearDic.Remove(ft_dress_config.Type);
            }
        }
    }


    /// <summary>
    /// 获取指定部位的装备数据
    /// </summary>
    /// <param name="part"></param>
    /// <returns></returns>
    public DressData GetPartDressData(int part)
    {
        if (clientWearDic.TryGetValue(part, out DressData dressData))
        {
            return dressData;
        }
        return null;
    }

    /// <summary>
    /// 检查指定衣服id是否在指定部位上
    /// </summary>
    /// <param name="clothesId"></param>
    /// <returns></returns>
    public bool CheckPartIsWeared(uint clothesId)
    {
        var ft_dress_config = GetDressConfig((int)clothesId);
        if (ft_dress_config != null)
        {
            var partDressData = GetPartDressData(ft_dress_config.Type);
            if (partDressData != null && partDressData.clothesId == clothesId)
            {
                return true;
            }
            return false;
        }
        return false;
    }


    /// <summary>
    /// 获取指定部位的装备id 0表示没有装备
    /// </summary>
    /// <param name="part"></param>
    /// <returns></returns>
    public int GetWearPartId(int part)
    {
        if (serverWearDic.TryGetValue(part, out DressData dressData))
        {
            return dressData.clothesId;
        }
        return 0;
    }

    public void FilterBookData(int quality = 0)
    {
        if (dressHome != null)
        {
            dressHome.Clear();
        }

        if (quality == 0)
        {
            dressHome = new List<SuitConfig>(suitList);
        }
        else
        {
            dressHome = suitList.FindAll(value => value.Quality == quality);
        }
        dressHome.Sort(BookSort);
    }
    private int BookSort(SuitConfig a, SuitConfig b)
    {
        if (a.Unlock && !b.Unlock) return -1;
        if (!a.Unlock && b.Unlock) return 1;
        return b.Quality - a.Quality;
    }

    public void FilterBookData1(int type = 0,int quality = 0)
    {
        if (suitDressHome != null)
        {
            suitDressHome.Clear();
        }
        else
        {
            suitDressHome = new List<DressConfig>();
        }
        foreach(var value in suitDressList)
        {
            if(type != 0 && value.Type != type)
            {
                continue;
            }
            if (quality != 0 && value.Quality != quality)
            {
                continue;
            }
            suitDressHome.Add(value);
        }


        suitDressHome.Sort(BookSort1);
    }
    private int BookSort1(DressConfig a, DressConfig b)
    {
        if (a.Unlock && !b.Unlock) return -1;
        if (!a.Unlock && b.Unlock) return 1;
        return b.Quality - a.Quality;
    }

    public bool IsCanLevel(int suitId)
    {
        return false;
    }

    // 获取服务器套装数据
    public I_SUIT_VO GetSuitServerData(uint suitId)
    {
        return suits.Find(value => value.suitId == suitId);
    }

    public void UpdateStarLv(uint suitId, uint starLv)
    {
        var suitData = GetSuitServerData(suitId);
        if (suitData == null)
        {
            var suit = new I_SUIT_VO();
            suit.suitId = suitId;
            suit.starLv = starLv;
            suit.gradeLv = 0;
            suits.Add(suit);
        }
        else
        {
            suitData.starLv = starLv;
        }
    }

    public void UpdateGradeLv(uint suitId, uint gradeLv)
    {
        var suitData = GetSuitServerData(suitId);
        if (suitData == null)
        {
            var suit = new I_SUIT_VO();
            suit.suitId = suitId;
            suit.starLv = 1;
            suit.gradeLv = gradeLv;
            suits.Add(suit);
        }
        else
        {
            suitData.gradeLv = gradeLv;
        }
    }

    //检查是否有指定套装装备
    public bool IsHaveSuitDress(int id)
    {
        if (defaultDress.Find(dress => dress.itemDefId == id) == null)
        {
            return StorageModel.Instance.GetItemCount(id) > 0;
        }
        else
        {
            return true;
        }
    }
    //获取套装 charm值
    public int GetSuitCharm()
    {
        int charmNum = 0;
        foreach(var value in suitList)
        {
            for(var i = 0;i < value.CollectNums.Length; i++)
            {
                if (value.CollectNums[i] > value.HaveCount)
                {
                    break;
                }
                charmNum += value.CollectAdds[i];
            }
        }
        return charmNum;
    }
    //获取当前装备的charm值
    public int GetDressCharm()
    {
        int charmNum = 0;
        foreach (var value in suitDressList)
        {
            if (value.Unlock)
            {
                charmNum += value.CharmNum;
            }
        }
        return charmNum;
    }
    //当前装备的套装收集进度
    public List<int> GetDressCollectPro(int quality)
    {
        var dressList = suitDressList.FindAll(value => value.Quality == quality);
        var haveList = dressList.FindAll(value => value.Unlock);
        return new List<int> { haveList.Count, dressList.Count };
    }

    //获取当前装备的套装技能buff
    public Dictionary<int, int> GetSkillBuff()
    {
        var skillMap = new Dictionary<int, int>();
        foreach (var value in suitList)
        {
            if(value.HaveCount >= value.ContainDress.Length)
            {
                if (value.suitSkill == 0) continue;
                var skillInfo = GetSuitSkillInfo(value.suitSkill);
                if (skillInfo == null) continue;
                if (skillMap.ContainsKey(skillInfo.SkillType))
                {
                    skillMap[skillInfo.SkillType] += skillInfo.SkillProb;
                }
                else
                {
                    skillMap.Add(skillInfo.SkillType, skillInfo.SkillProb);
                }
            }
        }
        return skillMap;
    }
    //获取当前装备的套装商店等级
    public int GetShopLv()
    {
        int lv = shopLvList[shopLvList.Count - 1].Id;
        foreach (var value in shopLvList)
        {
            if(value.Exp > dressShopExp)
            {
                lv = value.Id - 1;
                break;
            }
        }
        return lv;
    }
    //获取当前装备的套装商店等级信息
    public Ft_shop_cloLvConfig GetShopLvInfo(int lv)
    {
        return shopLvList.Find(value => value.Id == lv);
    }
    //获取当前装备的套装商店等级的金币奖励比例
    public float GetGoldRate()
    {
        var goldRate = 0;
        foreach (var value in suitList)
        {
            if(value.CollectNums.Length >= value.HaveCount)
            {
                var skillInfo = GetSuitSkillInfo(value.suitSkill);
                if(skillInfo != null && skillInfo.SkillType == 2)
                {
                    goldRate += skillInfo.SkillProb;
                }
            }
        }
        return (float)goldRate / 100;
    }
    //获取当前装备的套装商店等级的经验奖励比例
    public float GetExpRate()
    {
        var expRate = 0;
        foreach (var value in suitList)
        {
            if (value.CollectNums.Length >= value.HaveCount)
            {
                var skillInfo = GetSuitSkillInfo(value.suitSkill);
                if (skillInfo != null && skillInfo.SkillType == 5)
                {
                    expRate += skillInfo.SkillProb;
                }
            }
        }
        return (float)expRate / 100;
    }
}


public class SuitConfig
{
    public int Id;
    public string Name;
    public int Quality;
    public int[] ContainDress;
    public int[] CollectNums;
    public List<int> CollectAdds;
    public int[] SuitNum;
    public string[] SuitAdd;
    public int StarLevelMax;
    public int ShardId;
    public int suitSkill;

    public uint StarLv
    {
        get
        {
            var suitData = DressModel.Instance.GetSuitServerData((uint)Id);
            if (suitData != null)
            {
                return suitData.starLv;
            }
            return 1;
        }
    }
    public uint GradeLv
    {
        get
        {
            var suitData = DressModel.Instance.GetSuitServerData((uint)Id);
            if (suitData != null)
            {
                return suitData.gradeLv;
            }
            return 0;
        }
    }
    public int HaveCount
    {
        get
        {
            int count = 0;
            foreach (var value in ContainDress)
            {
                if (DressModel.Instance.defaultDress.Find(dress => dress.itemDefId == value) == null)
                {
                    if (StorageModel.Instance.GetItemCount(value) > 0)
                    {
                        count++;
                    }
                }
                else
                {
                    count++;
                }

            }
            return count;
        }
    }

    public bool Unlock
    {
        get
        {
            return HaveCount > 0;
        }
    }



    
    public SuitConfig(Ft_suit_configConfig data)
    {
        Id = data.Id;
        Name = data.Name;
        Quality = data.Quality;
        ContainDress = data.ContainDresss;
        suitSkill = data.SuitSkill;
        CollectNums = data.CollectNums;
        CollectAdds = StringUtil.DeserializeObject < List<int> > (data.CollectAdd);
    }
}


public class DressConfig
{
    public int ClothesId;
    public int Type;
    public int Quality;
    public int CharmNum;
    public int IsDefault;
    public int IsSingle;
    public int Prosperity;
    public bool Unlock { get
        {
            if (DressModel.Instance.defaultDress.Find(dress => dress.itemDefId == ClothesId) == null)
            {
                if (StorageModel.Instance.GetItemCount(ClothesId) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        } }

    public DressConfig(Ft_suit_dressConfig data)
    {
        ClothesId = data.ClothesId;
        Type = data.Type;
        Quality = data.Quality;
        CharmNum = data.CharmNum;
        IsDefault = data.IsDefault;
        IsSingle = data.IsSingle;
        Prosperity = data.Prosperity;
    }
}
