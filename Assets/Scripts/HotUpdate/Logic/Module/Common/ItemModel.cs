using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ADK;
using Elida.Config;

public class ItemModel : Singleton<ItemModel>
{
    public Module_item_defConfigData staticItemData = ConfigManager.Instance.GetConfig<Module_item_defConfigData>("module_item_defsConfig");

    //根据id找到物品数据
    public Module_item_defConfig GetItemById(int id)
    {
        //if(staticItemData == null) staticItemData = ConfigManager.Instance.GetConfig<Module_item_defConfigData>("module_item_defConfig");
        return staticItemData.Get(id);
    }

    public Module_item_defConfig GetItemByEntityID(string id)
    {
        int _id = IDUtil.GetEntityValue(id);
        return staticItemData.Get(_id);
    }


    public bool IsSucculent(Module_item_defConfig item)
    {
        return item.Category == (int)CategoryType.Flower && item.Type == (int)ItemType.SUCCULENT;
    }

    public bool IsFlower(int itemId)
    {
        var item = GetItemById(itemId);
        if (item == null) return false;
        return item.Category == (int)CategoryType.Flower && item.Type == (int)ItemType.flower;
    }

    public bool IsFlower(Module_item_defConfig item)
    {
        return item.Category == (int)CategoryType.Flower && item.Type == (int)ItemType.flower;
    }

    public bool IsSucculent(int flowerId)
    {
        Module_item_defConfig item = GetItemById(flowerId);
        if (item != null)
        {
            return item.Category == (int)CategoryType.Flower && item.Type == (int)ItemType.SUCCULENT;
        }
        else
        {
            Debug.Log("无用的花：" + flowerId);
        }
        return false;
    }

    public string GetNameByEntityID(int entityID)
    {
        var item = GetItemById(entityID);
        return Lang.GetValue(item == null ? "" : item.Name);
    }
    public string GetNameByEntityID(string entityID)
    {
        var item = GetItemByEntityID(entityID);
        return Lang.GetValue(item == null ? "" : item.Name);
    }

    /**花id 获得种子id */
    public int GetSeedIdByFlowerId(int flowerId)
    {
        var itemlist = staticItemData.DataList;
        var vo = itemlist.Find((value) =>
        {
            if (value.Type == (int)ItemType.Seed && value.UnlockFlowerId == flowerId)
            {
                return true;
            }
            return false;
        });
        if (vo != null)
        {
            return vo.ItemDefId;
        }
        return 0;
    }

    /// <summary>
    /// 获取掉落物品数据
    /// </summary>
    /// <param name="items"></param>
    /// <param name="filterFlower">是否过滤花朵</param>
    /// <returns></returns>
    public List<StorageItemVO> GetDropData(Dictionary<ulong, ulong> items, bool filterFlower = false)
    {
        var dropList = new List<StorageItemVO>();
        foreach (var item in items)
        {
            var itemDefId = IDUtil.GetEntityValue(item.Key.ToString());
            if (filterFlower && IsFlower(itemDefId))
            {
                continue;
            }
            var drop = new StorageItemVO();
            drop.itemDefId = itemDefId;
            drop.count = (int)item.Value;
            dropList.Add(drop);
        }
        return dropList;
    }
    public List<StorageItemVO> GetDropData(Dictionary<long, long> items, bool filterFlower = false)
    {
        var dropList = new List<StorageItemVO>();
        foreach (var item in items)
        {
            var itemDefId = IDUtil.GetEntityValue(item.Key.ToString());
            if (filterFlower && IsFlower(itemDefId))
            {
                continue;
            }
            var drop = new StorageItemVO();
            drop.itemDefId = itemDefId;
            drop.count = (int)item.Value;
            dropList.Add(drop);
        }
        return dropList;
    }
}

public enum CategoryType
{
    FarmLand = 21,
    Storage = 24,
    ProduceTools = 25,
    Tree = 26,
    FlowerTable = 27,
    OrderBoard = 28,
    ProduceItem = 42,
    FlowerArt = 43,
    Flower = 40,
    UpdateTools = 41,
    Decorations2 = 23,
    Debris = 12,
    Vase = 44,
    Ike = 45,
    IFrame = 47, //头像框
    Dress = 48, //换装道具
    pigment = 58 //颜料卡包/颜料卡
}

public enum ItemType
{
    Null = 0,
    flower = 4001,
    /**多肉植物 */
    SUCCULENT = 4002,
    Aquatic = 4003,
    Flower_card = 4105,
    Seed = 4005,
    Cash = 1000,
    Vase = 4401, //花瓶,
    FlowerShelf = 2812,
    EXP = 1400,
    Gold = 1100,
    SUCCULENT_FORMULA = 4502,
    Vase_card = 4402,   //花瓶卡
    cp_gift = 4116, //姻缘系统的心意礼物
    clothes = 4801, //衣服
    doll = 4802,    //玩偶道具
    clothesBox = 4803,  //衣服礼盒
    starFlowerSeed = 4008,  //星光花种子/花粉（升级的）
    petFood = 4009, // 宠物 食物
    petPhoto = 4010,    // 宠物 相册
    petAlbum = 4011,    // 宠物 纪念品
    petAct = 4012,  // 宠物动作解锁道具
    dressItem = 4801,	//换装部件
    pigmentBox = 5801,  // 颜料卡包
    pigmentCard = 5802	// 颜料卡道具
}

