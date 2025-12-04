using ADK;
using Elida.Config;
using protobuf.floristshop;
using System;
using System.Collections.Generic;
using System.Linq;


/// <summary>
/// 家具数据
/// </summary>
public class FurnitureData
{
    public int id;//家具id
    public uint floor;//编辑位置(0：花店 1：阁楼) 先预留这个字段 需要区分是花店还是阁楼的
    public uint x;
    public uint y;
}

public class FlowerShopModel : Singleton<FlowerShopModel>
{
    public bool IsChangeFurniture = false;//是否换家具了

    //家具套装表
    private List<FloristSuitConfig> _floristSuitList;
    public List<FloristSuitConfig> floristSuitList
    {
        get
        {
            if (_floristSuitList == null)
            {
                var floristSuitConfigData = ConfigManager.Instance.GetConfig<Ft_florist_suitConfigData>("ft_florist_suitsConfig");
                _floristSuitList = new List<FloristSuitConfig>();
                foreach (var value in floristSuitConfigData.DataList)
                {
                    var floristSuit = new FloristSuitConfig(value);
                    _floristSuitList.Add(floristSuit);
                }
            }
            return _floristSuitList;
        }
    }
    //店铺等级表
    private Dictionary<int, Ft_florist_levelConfig> _floristLvMap;
    public Dictionary<int, Ft_florist_levelConfig> floristLvMap
    {
        get
        {
            if (_floristLvMap == null)
            {
                var floristLvData = ConfigManager.Instance.GetConfig<Ft_florist_levelConfigData>("ft_florist_levelsConfig");
                _floristLvMap = floristLvData.DataMap;
            }
            return _floristLvMap;
        }
    }

    public List<FloristSuitConfig> floristSuitHome;
    public Dictionary<int, Dictionary<int, FurnitureData>> furnitureDataDic = new Dictionary<int, Dictionary<int, FurnitureData>>();//外层key=>type 内层value=>id
    public Decoration curEditDecoration;//当前编辑的可移动家具
    public uint floor = 0;//0:花店 1：阁楼
    public uint shopLevel = 3;//商店等级 默认改为2扩展等级的商店
    public List<uint> rewardIds;//已领取的奖励 1绘力 2：用户等级 3：培育鲜花 4：解锁花瓶
    public bool isEditing = false;//是否编辑中
    private List<I_FURNITURE_VO> clientDecoration;//客户端装饰
    public List<I_FURNITURE_VO> serverDecoration;//服务器装饰
    public ulong floristDrawingPower;//家具绘力

    public void InitData(I_FLORIST_SHOP_VO floristShop)
    {
        //shopLevel = floristShop.level;
        if (floristShop.rewardIds == null)
        {
            rewardIds = new List<uint>();
        }
        else
        {
            rewardIds = floristShop.rewardIds.ToList();
        }
        InitDecorations(floristShop.decoration);
    }
    public void InitDecorations(List<I_FURNITURE_VO> decoration)
    {
        serverDecoration = decoration;
        furnitureDataDic.Clear();
        foreach (var furniture in decoration)
        {
            var decoraFurnitureConfig = GetFurniture((int)furniture.itemId);
            if (decoraFurnitureConfig != null)
            {
                FurnitureData furnitureData = new FurnitureData();
                furnitureData.id = (int)furniture.itemId;
                furnitureData.floor = furniture.floor;
                furnitureData.x = furniture.x;
                furnitureData.y = furniture.y;
                AddFurnitureData(decoraFurnitureConfig.Type, furnitureData);
            }
        }
    }

    /// <summary>
    /// 家具替换更新 前端自己更新 根据类型去做替换 不存在则直接塞进去
    /// </summary>
    public void UpdateDecoration(uint id)
    {
        var furnitureData = GetFurnitureData((int)id);
        if (furnitureData != null) return;//已使用了 新替换的家具这里一定是null
        var furnitureConfig = GetFurniture((int)id);
        if (furnitureConfig == null) return;
        var type = furnitureConfig.Type;//要使用新的家具的类型
        var furnitureDatas = GetFurnitureDatas(type);//先拿到之前旧家具组
        if (furnitureDatas != null)
        {
            var oldFurnitureData = furnitureDatas.Values.First();//目前的设置每个组只有一个家具 所以先这样子拿
            furnitureDatas.Remove(oldFurnitureData.id);
            oldFurnitureData.id = (int)id;//替换为新的id
            furnitureDatas.Add(oldFurnitureData.id, oldFurnitureData);
        }
        else//找不到指定类型的家具组
        {
            AddFurnitureData(type, new FurnitureData() { id = (int)id, x = 0, y = 0, floor = 1 });
        }
        IsChangeFurniture = true;
    }

    /// <summary>
    /// 移除一个使用中家具信息
    /// </summary>
    /// <param name="furniture"></param>
    private void RemoveFurnitureData(int type, int furniture)
    {
        Dictionary<int, FurnitureData> dicIds = null;
        if (furnitureDataDic.TryGetValue(type, out dicIds))
        {
            if (dicIds.ContainsKey(furniture))
            {
                dicIds.Remove(furniture);
            }
        }
    }

    /// <summary>
    /// 添加一个使用中家具信息
    /// </summary>
    /// <param name="type"></param>
    /// <param name="furniture"></param>
    private void AddFurnitureData(int type, FurnitureData furnitureData)
    {
        Dictionary<int, FurnitureData> dicIds = null;
        if (!furnitureDataDic.TryGetValue(type, out dicIds))
        {
            dicIds = new Dictionary<int, FurnitureData>();
            furnitureDataDic.Add(type, dicIds);
        }
        dicIds.Add(furnitureData.id, furnitureData);
    }

    /// <summary>
    /// 客户端装饰列表
    /// </summary>
    /// <returns></returns>
    public List<I_FURNITURE_VO> GetClientDecoration()
    {
        if (clientDecoration == null)
        {
            clientDecoration = new List<I_FURNITURE_VO>();
        }
        else
        {
            clientDecoration.Clear();
        }

        foreach (KeyValuePair<int, Dictionary<int, FurnitureData>> kv in furnitureDataDic)
        {
            foreach (KeyValuePair<int, FurnitureData> kv2 in kv.Value)
            {
                var furnitureData = kv2.Value;
                var clientItem = new I_FURNITURE_VO
                {
                    itemId = (uint)furnitureData.id,
                    floor = furnitureData.floor,
                    x = furnitureData.x,
                    y = furnitureData.y
                };
                clientDecoration.Add(clientItem);
            }
        }
        return clientDecoration;
    }


    /// <summary>
    /// 检测某个家具是否使用中
    /// </summary>
    /// <returns></returns>
    public bool CheckFurnitureIsUse(int furniture)
    {
        var furnitureData = GetFurnitureData(furniture);
        return furnitureData != null;
    }

    public FurnitureData GetFurnitureData(int furniture)
    {
        var decoraFurnitureConfig = GetFurniture(furniture);
        if (decoraFurnitureConfig != null)
        {
            Dictionary<int, FurnitureData> dicIds = null;
            if (furnitureDataDic.TryGetValue(decoraFurnitureConfig.Type, out dicIds))
            {
                if (dicIds.TryGetValue(furniture, out FurnitureData value))
                {
                    return value;
                }
            }
        }
        return null;
    }

    /// <summary>
    /// 获取一组同类型的家具
    /// </summary>
    /// <param name="furniture"></param>
    /// <returns></returns>
    public Dictionary<int, FurnitureData> GetFurnitureDatas(int type)
    {
        Dictionary<int, FurnitureData> dicIds = null;
        if (furnitureDataDic.TryGetValue(type, out dicIds))
        {
            return dicIds;
        }
        return null;
    }


    /// <summary>
    /// 是否已拥有某个家具
    /// </summary>
    /// <param name="furnitureid"></param>
    /// <returns></returns>
    public bool HaveFurniture(int furnitureid)
    {
        if (StorageModel.Instance.GetItemById(furnitureid) != null)//在仓库中存在
        {
            return true;
        }
        for (var i = 1; i <= shopLevel; i++)
        {
            var furnitures = GetDefaultFurnituresByShopLevel(i);
            bool exists = Array.Exists(furnitures, id => id == furnitureid);
            if (exists) return true;//找到了直接返回
        }
        return false;
    }

    /// <summary>
    /// 检测某套家具套装是否使用中
    /// </summary>
    /// <param name="furniture"></param>
    /// <returns></returns>
    public bool CheckFurnitureSuitIsUse(int[] suitFurnitures)
    {
        var matchInd = 0;
        foreach (var furnitureId in suitFurnitures)//判断身上的有没有跟套装的对应上
        {
            if (CheckFurnitureIsUse(furnitureId))
            {
                matchInd += 1;
            }
        }
        return matchInd >= suitFurnitures.Length;
    }

    /// <summary>
    /// 检测某套家具套装都拥有了
    /// </summary>
    /// <param name="furniture"></param>
    /// <returns></returns>
    public bool CheckFurnitureSuitIsOwn(int[] suitFurnitures)
    {
        var matchInd = 0;
        foreach (var furnitureId in suitFurnitures)//判断身上的有没有跟套装的对应上
        {
            if (StorageModel.Instance.GetItemById(furnitureId) != null)
            {
                matchInd += 1;
            }
        }
        return matchInd >= suitFurnitures.Length;
    }

    /// <summary>
    /// 获取家具列表
    /// </summary>
    /// <returns></returns>
    public List<Ft_florist_furnitureConfig> GetFurnitureList()
    {
        var furnitureData = ConfigManager.Instance.GetConfig<Ft_florist_furnitureConfigData>("ft_florist_furnituresConfig");
        return furnitureData.DataList;
    }

    /// <summary>
    /// 获取一个家具
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Ft_florist_furnitureConfig GetFurniture(int id)
    {
        var furnitureData = ConfigManager.Instance.GetConfig<Ft_florist_furnitureConfigData>("ft_florist_furnituresConfig");
        return furnitureData.DataMap[id];
    }

    public List<Ft_florist_furnitureConfig> GetGetFurnituresByType(int type)
    {
        var furnitureList = GetFurnitureList();
        return furnitureList.FindAll(value => value.Type == type);
    }

    /// <summary>
    /// 获取套装列表
    /// </summary>
    /// <returns></returns>
    public List<Ft_florist_suitConfig> GetFloristSuitList()
    {
        var floristSuitConfigData = ConfigManager.Instance.GetConfig<Ft_florist_suitConfigData>("ft_florist_suitsConfig");
        return floristSuitConfigData.DataList;
    }

    public Ft_florist_suitConfig GetFloristSuit(int level)
    {
        var floristSuitConfigData = ConfigManager.Instance.GetConfig<Ft_florist_suitConfigData>("ft_florist_suitsConfig");
        return floristSuitConfigData.Get(level);
    }

    public Ft_florist_suitConfig GetFloristSuitByExpandLv(int expandLv)
    {
        var floristSuitList = GetFloristSuitList().FindAll(value => value.IsDefault == 1);//获取默认的套装
        return floristSuitList.Find(value => value.ExpandLv == expandLv);
    }

    //获取店铺信息
    public Ft_florist_levelConfig GetShopLvInfo(int level)
    {
        if (floristLvMap.ContainsKey(level))
        {
            return floristLvMap[level];
        }
        return null;
    }

    public List<FloristSuitConfig> FilterBook(int had = 0, int quality = 0)
    {
        if (floristSuitHome != null)
        {
            floristSuitHome.Clear();
        }
        if (had > 0)
        {
            floristSuitHome = floristSuitList.FindAll(value => value.IsCollect == (had == 1 ? true : false));
        }
        else
        {
            floristSuitHome = new List<FloristSuitConfig>(floristSuitList);
        }
        if (quality > 0)
        {
            floristSuitHome = floristSuitHome.FindAll(value => value.Quality == quality);
        }

        floristSuitHome.Sort(BookSort);
        return floristSuitHome;
    }

    public int BookSort(FloristSuitConfig a, FloristSuitConfig b)
    {
        if (a.IsCanCreateFlorist && !b.IsCanCreateFlorist) return -1;
        if (!a.IsCanCreateFlorist && b.IsCanCreateFlorist) return 1;
        return b.Quality - a.Quality;
    }

    public bool IsCanCreateFlorist(int id)
    {
        var floristInfo = GetFurniture(id);
        if (StorageModel.Instance.GetItemCount(id) > 0)
        {
            return false;
        }
        foreach (var value in floristInfo.CreateCosts)
        {
            var count = StorageModel.Instance.GetItemCount(value.EntityID);
            if (count < value.Value)
            {
                return false;
            }
        }
        return true;
    }
    //是否已达最大等级
    public bool IsMaxShopLv()
    {
        return GetShopLvInfo((int)shopLevel + 1) == null;
    }
    //获取鲜花可升级的最大等级
    public int GetMaxFlowerLevel()
    {
        var lvInfo = GetShopLvInfo((int)shopLevel);
        return lvInfo.FlowerLimit;
    }
    public List<LimitData> GetLimitList(int level)
    {
        var shopLvInfo = GetShopLvInfo(level);
        var limitData = new List<LimitData>();
        if (shopLvInfo.PowerNum != 0)
        {
            var limit = new LimitData();
            limit.type = 1;
            limit.num = shopLvInfo.PowerNum;
            limit.value = shopLvInfo.PowerRewards[0].Value;
            limit.itemId = shopLvInfo.PowerRewards[0].EntityID;
            limitData.Add(limit);
        }

        if (shopLvInfo.LvNum != 0)
        {
            var limit = new LimitData();
            limit.type = 2;
            limit.num = shopLvInfo.LvNum;
            limit.value = shopLvInfo.LvRewards[0].Value;
            limit.itemId = shopLvInfo.LvRewards[0].EntityID;
            limitData.Add(limit);
        }

        if (shopLvInfo.FlowerNum != 0)
        {
            var limit = new LimitData();
            limit.type = 3;
            limit.num = shopLvInfo.FlowerNum;
            limit.value = shopLvInfo.FlowerRewards[0].Value;
            limit.itemId = shopLvInfo.FlowerRewards[0].EntityID;
            limitData.Add(limit);
        }
        if (shopLvInfo.VaseNum != 0)
        {
            var limit = new LimitData();
            limit.type = 4;
            limit.num = shopLvInfo.VaseNum;
            limit.value = shopLvInfo.VaseRewards[0].Value;
            limit.itemId = shopLvInfo.VaseRewards[0].EntityID;
            limitData.Add(limit);
        }
        if (shopLvInfo.ClothesNum != 0)
        {
            var limit = new LimitData();
            limit.type = 5;
            limit.num = shopLvInfo.ClothesNum;
            limit.value = shopLvInfo.ClothesRewards[0].Value;
            limit.itemId = shopLvInfo.ClothesRewards[0].EntityID;
            limitData.Add(limit);
        }
        return limitData;
    }

    public int GetFurnitureCount(int id)
    {
        var floristSuitList = GetFurnitureUnlock();
        var have = floristSuitList.Find(value => value.itemDefId == id);
        if (have != null)
        {
            return 1;
        }
        return 0;
    }

    public List<StorageItemVO> GetFurnitureUnlock()
    {
        var floistList = floristSuitList.FindAll(value => value.IsDefault == 1);
        var list = new List<StorageItemVO>();
        foreach (var value in floistList)
        {
            if (value.ExpandLv <= MyselfModel.Instance.level)
            {
                foreach (var furniture in value.Furnitures)
                {
                    var itemVo = ItemModel.Instance.GetItemById(furniture);
                    var storage = new StorageItemVO();
                    storage.count = 1;
                    storage.item = itemVo;
                    storage.itemDefId = itemVo.ItemDefId;
                    list.Add(storage);
                }
            }
        }
        var furnitureList = StorageModel.Instance.GetStorageListByType_1(5901);
        list.AddRange(furnitureList);
        return list;

    }

    /// <summary>
    /// 根据商店等级获取默认的家具等级
    /// </summary>
    /// <returns></returns>
    public int[] GetDefaultFurnituresByShopLevel(int level)
    {
        var floristSuitList = GetFloristSuitList().FindAll(value => value.IsDefault == 1);//获取默认的套装
        if (floristSuitList != null && floristSuitList.Count > 0)
        {
            return floristSuitList[level - 1].Furnitures;
        }
        return null;
    }
}

public class FloristSuitConfig
{
    public int Id;
    public string Name;
    public string Icon;
    public int[] Furnitures;
    public int Quality;
    public int[] RequireNums;
    public List<string> AttrsAdd;
    public int IsDefault;
    public int ExpandLv;

    public bool IsCanCreateFlorist
    {
        get
        {
            if (IsDefault == 1)
            {
                return false;
            }
            foreach (var value in Furnitures)
            {
                if (FlowerShopModel.Instance.IsCanCreateFlorist(value))
                {
                    return true;
                }
            }
            return false;
        }
    }

    public int HavecCount
    {
        get
        {
            if (IsDefault == 1)
            {
                if (ExpandLv > FlowerShopModel.Instance.shopLevel)
                {
                    return 0;
                }
                return Furnitures.Length;
            }
            var count = 0;
            foreach (var value in Furnitures)
            {
                if (StorageModel.Instance.GetItemCount(value) > 0)
                {
                    count++;
                }
            }
            return count;
        }
    }

    public bool Unlock { get
        {
            return HavecCount >= Furnitures.Length;
        } }


    public bool IsCollect
    {
        get
        {
            if (IsDefault == 1)
            {
                return ExpandLv <= FlowerShopModel.Instance.shopLevel;
            }
            else
            {
                foreach (var value in Furnitures)
                {
                    if (StorageModel.Instance.GetItemCount(value) <= 0)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }


    public FloristSuitConfig(Ft_florist_suitConfig data)
    {
        Id = data.Id;
        Name = data.Name;
        Icon = data.Icon;
        Furnitures = data.Furnitures;
        Quality = data.Quality;
        RequireNums = data.RequireNums;
        AttrsAdd = StringUtil.DeserializeObject<List<string>>(data.AttrsAdd);
        IsDefault = data.IsDefault;
        ExpandLv = data.ExpandLv;
    }
}

public class LimitData
{
    public int type;
    public int num;
    public int value;
    public string itemId;
}