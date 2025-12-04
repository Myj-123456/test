using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ADK;
using Elida.Config;
using UnityEngine;

/// <summary>
/// 种植鲜花种子数据
/// </summary>
public class SeedCropVO
{
    public int flowerId;
    public int level;
    public int brealLv;
    public int gradeLv;
    public Module_item_defConfig item;//物品静态配置
    public int quality
    {
        get
        {
            var flowerInfo = FlowerHandbookModel.Instance.GetStaticSeedCondition(flowerId);
            return flowerInfo.FlowerQuality;
        }
    }
}

public class StorageModel : Singleton<StorageModel>
{
    private Dictionary<int, Ft_gift_packConfig> _itemGiftMap;
    public Dictionary<int, Ft_gift_packConfig> itemGiftMap { get
        {
            if (_itemGiftMap == null)
            {
                var itemGiftData = ConfigManager.Instance.GetConfig<Ft_gift_packConfigData>("ft_gift_packsConfig");
                _itemGiftMap = itemGiftData.DataMap;
            }
            return _itemGiftMap;
        } }

    private Dictionary<int, SeedCropVO> seedDic;
    private List<SeedCropVO> _seedList;
    public Dictionary<int, StorageItemVO> itemList;

    //服务器通知物品id，新增需要自己加上去
    private int[] serverNotificeIds = new int[] { (int)BaseType.EXP, (int)BaseType.GOLD, (int)BaseType.CASH, (int)BaseType.FST_WATER, (int)BaseType.SPD_DRUG, (int)BaseType.TURNTABLE_COIN, (int)BaseType.GRANDMA_TICKET, (int)BaseType.GUILD_MEDAL };

    public Ft_gift_packConfig GetItemGiftInfo(int id)
    {
        if (itemGiftMap.ContainsKey(id))
        {
            return itemGiftMap[id];
        }
        return null;
    }
    public List<SeedCropVO> seedList
    {
        get { return _seedList; }
    }

    public int seedCount { get
        {
            return _seedList.Count;
        } }
    public void InitSeedList(List<protobuf.plant.I_PLANT_SEED_VO> plantSeedList)
    {
        seedDic = new Dictionary<int, SeedCropVO>();
        _seedList = new List<SeedCropVO>();
        var itemDataConfig = ConfigManager.Instance.GetConfig<Module_item_defConfigData>("module_item_defsConfig");
        foreach (var seedVo in plantSeedList)
        {
            var seedCropData = new SeedCropVO() { flowerId = (int)seedVo.flowerId, level = (int)seedVo.level,brealLv = (int)seedVo.breakLv,gradeLv=(int)seedVo.gradeLv, item = itemDataConfig.Get((int)seedVo.flowerId) };
            _seedList.Add(seedCropData);
            seedDic.Add((int)seedVo.flowerId, seedCropData);
        }
    }

    public SeedCropVO GetSeedCropVO(int flowerItemId)
    {
        if (seedDic.ContainsKey(flowerItemId))
        {
            return seedDic[flowerItemId];
        }


        return null;
    }

    public bool AlreadyUnlockSeed(int flowerItemId)
    {
        if (!ItemModel.Instance.IsSucculent(flowerItemId))
        {
            return GetSeedCropVO(flowerItemId) != null;
        }
        else
        {
            return false;
        }
    }


    /// <summary>
    /// 获取种子列表
    /// </summary>
    /// <param name="type">0：bookIs排序 1:库存数量</param>
    /// <param name="filter"></param>
    public List<SeedCropVO> GetSortedSeedList(int type = 0, string filter = "")
    {
        var seedList = _seedList;
        if (type == 0)
        {
            seedList.Sort(this.SortByBookId);
        }
        else
        {
            seedList.Sort(this.SortByStorageCount);
        }

        if (!string.IsNullOrEmpty(filter))
        {
            seedList = seedList.Where(value =>
            {
                if (value?.item?.Name != null)
                {
                    string name = Lang.GetValue(value.item.Name);
                    if (!string.IsNullOrEmpty(name) && name.Contains(filter))
                    {
                        return true;
                    }
                }
                return false;
            }).ToList();
        }

        return seedList;
    }

    /**按库存数量排序 */
    private int SortByStorageCount(SeedCropVO a, SeedCropVO b)
    {
        var aCount = GetItemCount(a.flowerId);
        var bCount = GetItemCount(b.flowerId);
        return aCount - bCount;
    }

    public List<SeedCropVO> GetSeedSortLevel()
    {
        List<SeedCropVO> list = new List<SeedCropVO>(_seedList);
        list.Sort((a, b) => b.level - a.level);
        return list;
    }


    /**按bookId */
    private int SortByBookId(SeedCropVO a, SeedCropVO b)
    {
        var that = FlowerHandbookModel.Instance;
        var aCond = that.GetBookConfigByFlowerId(a.flowerId);
        var bCond = that.GetBookConfigByFlowerId(b.flowerId);
        if (aCond.BookId < bCond.BookId)
            return -1;
        if (aCond.BookId > bCond.BookId)
            return 1;
        return 0;
    }

    public void ParseItemList(List<protobuf.item.I_ITEM_VO> data)
    {
        itemList = new Dictionary<int, StorageItemVO>();
        foreach (protobuf.item.I_ITEM_VO item in data)
        {
            Module_item_defConfig vo = ItemModel.Instance.GetItemById((int)item.itemDefId);
            StorageItemVO itemData = new StorageItemVO() { itemDefId = (int)item.itemDefId, count = (int)item.count, item = vo };
            itemList.Add(itemData.itemDefId, itemData);
        }
    }
    public StorageItemVO GetItemById(int id)
    {
        if (itemList.ContainsKey(id))
        {
            return itemList[id];
        }
        return null;
    }

    public StorageItemVO GetItemById(string id)
    {
        int itemId = IDUtil.GetEntityValue(id);
        if (itemList.ContainsKey(itemId))
        {
            return itemList[itemId];
        }
        return null;
    }
    public int GetItemCount(int id)
    {
        if (id == (int)BaseType.CASH)
        {
            return (int)MyselfModel.Instance.diamond;
        }
        else if (id == (int)BaseType.GOLD)
        {
            return (int)MyselfModel.Instance.gold;
        }
        else if (id == (int)BaseType.FST_WATER)
        {
            return (int)MyselfModel.Instance.WaterCur;
        }
        else if (id == (int)BaseType.GUILDGOLD)
        {
            return GuildModel.Instance.guild != null ? (int)GuildModel.Instance.guild.gold : 0;
        }else if(id == (int)BaseType.EXP)
        {
            return (int)MyselfModel.Instance.exp;
        }
        var item = GetItemById(id);
        if (item != null)
        {
            return item.count;
        }
        return 0;
    }

    public int GetItemCount(string id)
    {
        int itemId = IDUtil.GetEntityValue(id);
        if (itemId == (int)BaseType.CASH)
        {
            return (int)MyselfModel.Instance.diamond;
        }
        else if (itemId == (int)BaseType.GOLD)
        {
            return (int)MyselfModel.Instance.gold;
        }else if(itemId == (int)BaseType.GUILDGOLD)
        {
            return GuildModel.Instance.guild != null ? (int)GuildModel.Instance.guild.gold : 0;
        }
        else if (itemId == (int)BaseType.EXP)
        {
            return (int)MyselfModel.Instance.exp;
        }
        var item = GetItemById(itemId);
        if (item != null)
        {
            return item.count;
        }
        return 0;
    }

    public bool CheckEntityIDIsEnough(string entityId, int count)
    {
        int tid = IDUtil.GetEntityValue(entityId);
        bool bol = true;
        if (tid == (int)BaseType.GOLD)
        {
            if (MyselfModel.Instance.gold < count)
            {
                bol = false;
            }
        }
        else if (tid == (int)BaseType.CASH)
        {
            if (MyselfModel.Instance.diamond < count)
            {
                bol = false;
            }
        }
        else if (tid == (int)BaseType.FST_WATER)
        {
            bol = false;
        }
        else
        {
            if (GetItemCount(tid) < count)
            {
                bol = false;
            }
        }
        return bol;
    }

    public int GetCommonShardNum()
    {
        return GetItemCount(GlobalModel.Instance.module_profileConfig.universalShardId);
    }


    /// <summary>
    /// 获得的物品添加到仓库中
    /// </summary>
    /// <param name="items"></param>
    public void AddToStorage(Dictionary<ulong, ulong> items)
    {
        foreach (var item in items)
        {
            var itemId = ADK.IDUtil.GetEntityValue(item.Key);
            AddToStorageByItemId(itemId, (int)item.Value);
        }
    }

    public void AddToStorageByItemId(int itemId, int count)
    {
        //特殊物品前端不自己计算，由服务器通知
        if (System.Array.IndexOf(serverNotificeIds, itemId) != -1)
        {
            return;
        }
        if (itemList.ContainsKey(itemId))
        {
            itemList[itemId].count += count;
            if (itemList[itemId].count < 0)
            {
                itemList[itemId].count = 0;
            }
        }
        else
        {
            if (count < 0)
            {
                return;
            }
            Module_item_defConfig vo = ItemModel.Instance.GetItemById((int)itemId);
            StorageItemVO itemData = new StorageItemVO() { itemDefId = (int)itemId, count = (int)count, item = vo };
            itemList.Add(itemId, itemData);
        }
        EventManager.Instance.DispatchEvent(SystemEvent.UpdateItemNum);
    }

    public void AddToStorageByItemId(string id, int count)
    {
        int itemId = IDUtil.GetEntityValue(id);
        //特殊物品前端不自己计算，由服务器通知
        if (System.Array.IndexOf(serverNotificeIds, itemId) != -1)
        {
            return;
        }
        if (itemList.ContainsKey(itemId))
        {
            itemList[itemId].count += count;
            if (itemList[itemId].count < 0)
            {
                itemList[itemId].count = 0;
            }
        }
        else
        {
            if (count < 0)
            {
                return;
            }
            Module_item_defConfig vo = ItemModel.Instance.GetItemById((int)itemId);
            StorageItemVO itemData = new StorageItemVO() { itemDefId = (int)itemId, count = (int)count, item = vo };
            itemList.Add(itemId, itemData);
        }
        EventManager.Instance.DispatchEvent(SystemEvent.UpdateItemNum);
    }

    /// <summary>
    /// 服务器下发通知物品变更,前端自己变更请不要调用这个方法
    /// </summary>
    /// <param name="itemId"></param>
    /// <param name="count"></param>
    public void UpdateStorageByItemId(int itemId, int count)
    {
        //玩家属性值 不存到物品里面
        if (itemId == (int)BaseType.EXP || itemId == (int)BaseType.GOLD || itemId == (int)BaseType.CASH || itemId == (int)BaseType.FST_WATER || itemId == (int)BaseType.TURNTABLE_COIN)
        {
            return;
        }
        if (itemList.ContainsKey(itemId))
        {
            itemList[itemId].count = count;
        }
        else
        {
            if (count < 0)
            {
                return;
            }
            Module_item_defConfig vo = ItemModel.Instance.GetItemById((int)itemId);
            StorageItemVO itemData = new StorageItemVO() { itemDefId = (int)itemId, count = (int)count, item = vo };
            itemList.Add(itemId, itemData);
        }
    }

    public void AddToStorageItems(Dictionary<ulong, ulong> items)
    {
        foreach (KeyValuePair<ulong, ulong> item in items)
        {
            AddToStorageByItemId(IDUtil.GetEntityValue((long)item.Key), (int)item.Value);
        }
    }

    public void OddToStorageItems(Dictionary<ulong, ulong> items)
    {
        foreach (KeyValuePair<ulong, ulong> item in items)
        {
            AddToStorageByItemId(IDUtil.GetEntityValue((long)item.Key), -(int)item.Value);
        }
    }
    public void AddToSeedlist(protobuf.plant.I_PLANT_SEED_VO data)
    {
        Module_item_defConfig itemData = ItemModel.Instance.GetItemById((int)data.flowerId);
        SeedCropVO vo = new SeedCropVO() { flowerId = (int)data.flowerId, level = (int)data.level,brealLv=(int)data.breakLv,gradeLv=(int)data.gradeLv, item = itemData };
        seedDic.Add((int)data.flowerId, vo);
        _seedList.Add(vo);
    }

    public void AddToSeedlist(string id)
    {
        int flowerId = IDUtil.GetEntityValue(id);
        Module_item_defConfig itemData = ItemModel.Instance.GetItemById(flowerId);
        SeedCropVO vo = new SeedCropVO() { flowerId = flowerId, level = 1, brealLv = 1, gradeLv = 1, item = itemData };
        seedDic.Add(flowerId, vo);
        _seedList.Add(vo);
    }

    public void AddToSeedlist(int flowerId)
    {
        Module_item_defConfig itemData = ItemModel.Instance.GetItemById(flowerId);
        SeedCropVO vo = new SeedCropVO() { flowerId = flowerId, level = 1, brealLv = 1, gradeLv = 1, item = itemData };
        seedDic.Add(flowerId, vo);
    }

    public void UpLevelSeed(protobuf.plant.I_PLANT_SEED_VO data)
    {
        if (seedDic.ContainsKey((int)data.flowerId))
        {
            seedDic[(int)data.flowerId].level = (int)data.level;
        }
    }

    public void UpBreakLv(protobuf.plant.I_PLANT_SEED_VO data)
    {
        if (seedDic.ContainsKey((int)data.flowerId))
        {
            seedDic[(int)data.flowerId].brealLv = (int)data.breakLv;
        }
    }

    public void UpGradeLv(protobuf.plant.I_PLANT_SEED_VO data)
    {
        if (seedDic.ContainsKey((int)data.flowerId))
        {
            seedDic[(int)data.flowerId].gradeLv = (int)data.gradeLv;
        }
    }

    public List<StorageItemVO> GetStorageListByTypes(int[] types, bool isSort = true, bool isFlower = false)
    {
        List<StorageItemVO> list = new List<StorageItemVO>();
        foreach (var type in types)
        {
            list.AddRange(GetStorageListByType_1(type));
        }
        return list;
    }

    public List<StorageItemVO> GetStorageListByType_1(int type, bool isSort = true, bool isFlower = false)
    {
        List<StorageItemVO> item_list = new List<StorageItemVO>();
        foreach (KeyValuePair<int, StorageItemVO> item in itemList)
        {
            if (item.Value.item == null)
            {
                continue;
            }
            if (item.Value.item.Type == type && item.Value.count > 0)
            {
                item_list.Add(item.Value);
            }
        }
        return item_list;
    }

    public List<StorageItemVO> GetStorageListByCategory(int category, bool needWarehouseId = false)
    {
        List<StorageItemVO> item_list = new List<StorageItemVO>();
        foreach (KeyValuePair<int, StorageItemVO> item in itemList)
        {
            if (item.Value.item == null)
            {
                continue;
            }
            if ((!needWarehouseId || (needWarehouseId && item.Value.item.WarehouseId > 0)) && item.Value.item.Category == category && item.Value.count > 0)
            {
                item_list.Add(item.Value);
            }
        }
        return item_list;
    }

    public List<StorageItemVO> GetStorageList()
    {
        var item_list = GetStorageListByCategory(41, true);
        var listData = new List<StorageItemVO>();
        foreach (KeyValuePair<int, StorageItemVO> item in itemList)
        {
            if (item.Value.item == null)
            {
                continue;
            }
            
            else if (item.Value.item.Type == 5201 && item.Value.count > 0)
            {
                listData.Add(item.Value);
            }
        }
        listData.Sort((a, b) => a.itemDefId - b.itemDefId);
        listData.AddRange(item_list);
        return listData;
    }

    public int GetSeedTotalCount()
    {
        int count = 0;
        foreach (var value in seedList)
        {
            count += value.level;
        }

        return count;
    }

    public int GetFlowerTotalCount()
    {
        var flowers = GetStorageListByType_1(4001);
        int count = 0;
        foreach (var flower in flowers)
        {
            count += flower.count;
        }
        return count;
    }

    public float GetExpAddRate(int flowerId)
    {
        float rate = 0;
        if (seedDic.ContainsKey(flowerId))
        {
            var seed = FlowerHandbookModel.Instance.GetStaticSeedCondition(flowerId);
            var gradeInfo = FLowerModel.Instance.GetFlowerGradeConfig(seed.FlowerQuality, seedDic[flowerId].gradeLv);
            if (gradeInfo != null)
            {
                var attrs = gradeInfo.GradeAttribute.Split(";");
                foreach (var attr in attrs)
                {
                    var attrVo = attr.Split("#");
                    if (attrVo[0] == "5")
                    {
                        rate += float.Parse(attrVo[1]);
                    }
                }
            }


        }
        return rate/100;
    }

    public float GetGoldAddRate(int flowerId)
    {
        float rate = 0;
        if (seedDic.ContainsKey(flowerId))
        {
            var seed = FlowerHandbookModel.Instance.GetStaticSeedCondition(flowerId);
            var gradeInfo = FLowerModel.Instance.GetFlowerGradeConfig(seed.FlowerQuality, seedDic[flowerId].gradeLv);
            if (gradeInfo != null)
            {
                var attrs = gradeInfo.GradeAttribute.Split(";");
                foreach (var attr in attrs)
                {
                    var attrVo = attr.Split("#");
                    if (attrVo[0] == "2")
                    {
                        rate += float.Parse(attrVo[1]);
                    }

                }
            }

           
        }
        return rate/100;
    }


    //public List<StorageItemVO> GetStorageListByTypes(int types,bool isFlower)
    //{
    //    List<StorageItemVO> list = new List<StorageItemVO>();
    //    foreach(var )
    //}
    public List<SeedCropVO> GetFlowerList()
    {
        _seedList.Sort((a, b) => b.quality - a.quality);
        return _seedList;
    }
}

public class StorageItemVO
{
    public int count = 0;
    public int itemDefId;
    public Module_item_defConfig item;
}

