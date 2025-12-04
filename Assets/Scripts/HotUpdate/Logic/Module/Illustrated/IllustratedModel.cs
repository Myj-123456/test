//using System.Collections;
//using System.Collections.Generic;
//using Elida.Config;
//using protobuf.illustrated;
//using UnityEngine;

//public class IllustratedModel : Singleton<IllustratedModel>
//{
//    //图鉴等级表
//    private Dictionary<int, Ft_illustrated_levelConfig> _illLevelMap;
//    public Dictionary<int, Ft_illustrated_levelConfig> illLevelMap { get
//        {
//            if(_illLevelMap == null)
//            {
//                var illLevelData = ConfigManager.Instance.GetConfig<Ft_illustrated_levelConfigData>("ft_illustrated_levelsConfig");
//                _illLevelMap = illLevelData.DataMap;
//            }
//            return _illLevelMap;
//        } }

//    //图鉴物品表
//    private Dictionary<string, Ft_illustrated_itemConfig> _illItemlMap;
//    public Dictionary<string, Ft_illustrated_itemConfig> illItemlMap { get
//        {
//            if(_illItemlMap == null)
//            {
//                var illItemData = ConfigManager.Instance.GetConfig<Ft_illustrated_itemConfigData>("ft_illustrated_itemsConfig");
//                _illItemlMap = illItemData.DataMap;

//            }
//            return _illItemlMap;
//        } }

//    public I_ILLUSTRATED_INFO_VO illustratedInfo;//图鉴信息
//    public List<I_ILLUSTRATED_VO> illustratedItems;//图鉴已领取道具收集值
//    //花仙
//    public List<FairyDataConfig> fairyIllData;
//    public void InitFairyIllData()
//    {
//        if(fairyIllData == null)
//        {
//            fairyIllData = new List<FairyDataConfig>(FlowerGoldModel.Instance.fairyList);
//        }
        
//        fairyIllData.Sort(SortFairyIll);
//    }
//    public int SortFairyIll(FairyDataConfig a, FairyDataConfig b)
//    {
//        if (a.UnLockReward && !b.UnLockReward) return -1;
//        if (!a.UnLockReward && b.UnLockReward) return 1;
//        if (a.LevelReward && !b.UnLockReward) return -1;
//        if (!a.LevelReward && b.UnLockReward) return 1;
//        if (a.Unlock && !b.Unlock) return -1;
//        if (b.Unlock && !a.Unlock) return 1;
//        return b.Quality - a.Quality;
//    }
//    //宠物
//    public List<PetDataConfig> PetIllData;
//    public void InitPetIllData()
//    {
//        if(PetIllData == null)
//        {
//            PetIllData = new List<PetDataConfig>(PetModel.Instance.petList);
//        }
        
//        PetIllData.Sort(SortPetIll);
//    }
//    public int SortPetIll(PetDataConfig a, PetDataConfig b)
//    {
//        if (a.UnLockReward && !b.UnLockReward) return -1;
//        if (!a.UnLockReward && b.UnLockReward) return 1;
//        if (a.IllShowPoint && !b.IllShowPoint) return -1;
//        if (!a.IllShowPoint && b.IllShowPoint) return 1;
//        if (a.Unlock && !b.Unlock) return -1;
//        if (!a.Unlock && b.Unlock) return 1;
//        return b.Quality - a.Quality;
//    }
//    //家具
//    public List<FloristSuitConfig> floristIllData;
//    public void InitFloristIllData()
//    {
//        if(floristIllData == null)
//        {
//            floristIllData = new List<FloristSuitConfig>(FlowerShopModel.Instance.floristSuitList);
//        }
//        floristIllData.Sort(SortFloristIll);
//    }
//    private int SortFloristIll(FloristSuitConfig a, FloristSuitConfig b)
//    {
//        if (a.UnLockReward && !b.UnLockReward) return -1;
//        if (!a.UnLockReward && b.UnLockReward) return 1;
//        if (a.Unlock && !b.Unlock) return -1;
//        if (!a.Unlock && b.Unlock) return 1;
//        return b.Quality - a.Quality;
//    }
//    //服装
//    public List<SuitConfig> dressIllData;
//    public void InitDressIllData()
//    {
//        if (dressIllData == null)
//        {
//            dressIllData = new List<SuitConfig>(DressModel.Instance.suitList);
//        }
        
//        dressIllData.Sort(SortDressIll);
//    }
//    private int SortDressIll(SuitConfig a, SuitConfig b)
//    {
//        if (a.UnLockReward && !b.UnLockReward) return -1;
//        if (!a.UnLockReward && b.UnLockReward) return 1;
//        if (a.IllShowPoint && !b.IllShowPoint) return -1;
//        if (!a.IllShowPoint && b.IllShowPoint) return 1;
//        if (a.Unlock && !b.Unlock) return -1;
//        if (!a.Unlock && b.Unlock) return 1;
//        return b.Quality - a.Quality;
//    }

//    //花瓶
//    public List<StaticFlowerPoint> vaseIllData;
//    public void InitvaseIllData()
//    {
//        if (vaseIllData == null)
//        {
//            vaseIllData = new List<StaticFlowerPoint>(IkeModel.Instance.vaseConfigList);
//        }
        
//        vaseIllData.Sort(SortVaseIll);
//    }
//    private int SortVaseIll(StaticFlowerPoint a, StaticFlowerPoint b)
//    {
//        if (a.UnLockReward && !b.UnLockReward) return -1;
//        if (!a.UnLockReward && b.UnLockReward) return 1;
//        if (IkeModel.Instance.IsUnlockVase(a.VaseId) && !IkeModel.Instance.IsUnlockVase(b.VaseId)) return -1;
//        if (!IkeModel.Instance.IsUnlockVase(a.VaseId) && IkeModel.Instance.IsUnlockVase(b.VaseId)) return -1;
//        return b.VaseQuality - a.VaseQuality;
//    }
//    //鲜花
//    public List<StaticSeedCondition> flowerIllData;
    
//    public void InitFlowerIllData()
//    {
//        if (flowerIllData == null)
//        {
//            flowerIllData = new List<StaticSeedCondition>(FlowerHandbookModel.Instance.seedConditionList);
//        }
        
//        flowerIllData.Sort(SortFlowerIll);

//    }

//    private int SortFlowerIll(StaticSeedCondition a, StaticSeedCondition b)
//    {
//        if (a.UnLockReward && !b.UnLockReward) return -1;
//        if (!a.UnLockReward && b.UnLockReward) return 1;
//        if (a.IllShowPoint && !b.IllShowPoint) return -1;
//        if (!a.IllShowPoint && b.IllShowPoint) return 1;
//        if (a.AlreadyCulitivated && !b.AlreadyCulitivated) return -1;
//        if (!a.AlreadyCulitivated && b.AlreadyCulitivated) return 1;
//        return b.FlowerQuality - a.FlowerQuality;
//    }


//    //获取图鉴等级信息
//    public Ft_illustrated_levelConfig GetIllLevelInfo(int level)
//    {
//        if (illLevelMap.ContainsKey(level))
//        {
//            return illLevelMap[level];
//        }
//        return null;
//    }
//    //获取图鉴物品信息
//    public Ft_illustrated_itemConfig GetIllItemInfo(int itemType,int collectType)
//    {
//        var key = itemType + "#" + collectType;
//        if (illItemlMap.ContainsKey(key))
//        {
//            return illItemlMap[key];
//        }
//        return null;
//    }

//    //获取道具收集信息
//    public I_ILLUSTRATED_VO GetIllItemData(uint itemId)
//    {
//        return illustratedItems.Find(value => value.itemId == itemId);
//    }

//    public void UpdateIllItem(I_ILLUSTRATED_VO data)
//    {
//        var illItem = GetIllItemData(data.itemId);
//        if(illItem == null)
//        {
//            illustratedItems.Add(data);
//        }
//        else
//        {
//            illItem.unlockReward = data.unlockReward;
//            illItem.levelReward = data.levelReward;
//            illItem.gradeReward = data.gradeReward;
//        }
//    }
//}


