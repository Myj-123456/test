//using System.Collections;
//using System.Collections.Generic;
//using Elida.Config;
//using protobuf.pets;
//using UnityEngine;
//using static protobuf.pets.S_MSG_PET_DRAW;

//public class PetModel : Singleton<PetModel>
//{
//    //宠物列表
//    public List<I_PETS_VO> petsList;
//    //抽到的道具
//    public List<I_ITEM_VO> petItems;
//    private List<PetDataConfig> _petList;

//    public List<PetDataConfig> petList { get
//        {
//            if(_petList == null)
//            {
//                var petData = ConfigManager.Instance.GetConfig<Ft_pet_configConfigData>("ft_pet_configsConfig");
//                _petList = new List<PetDataConfig>();
//                foreach(var value in petData.DataList)
//                {
//                    var petItem = new PetDataConfig(value);
//                    _petList.Add(petItem);
//                }
//            }
//            return _petList;
//        } }
//    private Dictionary<int, Ft_pet_levelConfig> _petLevelMap;
//    public Dictionary<int, Ft_pet_levelConfig> petLevelMap { get
//        {
//            if(_petLevelMap == null)
//            {
//                var petLeveData = ConfigManager.Instance.GetConfig<Ft_pet_levelConfigData>("ft_pet_levelsConfig");
//                _petLevelMap = petLeveData.DataMap;
//            }
//            return _petLevelMap;
//        } }

//    private Dictionary<int, Ft_pet_itemConfig> _petItemMap;
//    public Dictionary<int, Ft_pet_itemConfig> petItemMap
//    {
//        get
//        {
//            if (_petItemMap == null)
//            {
//                var petItemData = ConfigManager.Instance.GetConfig<Ft_pet_itemConfigData>("ft_pet_itemsConfig");
//                _petItemMap = petItemData.DataMap;
//            }
//            return _petItemMap;
//        }
//    }

//    private List<Ft_pet_relationConfig> _petRelationList;
//    public List<Ft_pet_relationConfig> petRelationList
//    {
//        get
//        {
//            if (_petRelationList == null)
//            {
//                var petRelationData = ConfigManager.Instance.GetConfig<Ft_pet_relationConfigData>("ft_pet_relationsConfig");
//                _petRelationList = petRelationData.DataList;
//            }
//            return _petRelationList;
//        }
//    }

//    private Dictionary<string, Ft_pet_starConfig> _petStarMap;
//    public Dictionary<string, Ft_pet_starConfig> petStarMap { get
//        {
//            if(_petStarMap == null)
//            {
//                var petStarData = ConfigManager.Instance.GetConfig<Ft_pet_starConfigData>("ft_pet_starsConfig");
//                _petStarMap = petStarData.DataMap;
//            }
//            return _petStarMap;
//        } }

//    public List<PetDataConfig> petHome;

//    //获取宠物配置
//    public PetDataConfig GetPetInfo(int id)
//    {
//        return petList.Find(value => value.Id == id);
//    }
//    //获取宠物配置通过碎片Id
//    public PetDataConfig GetPetInfo1(int shardId)
//    {
//        return petList.Find(value => value.ShardId == shardId);
//    }
//    //获取宠物等级配置
//    public Ft_player_levelConfig GetPetLevelInfo(int level)
//    {
//        if (petLevelMap.ContainsKey(level))
//        {
//            return petLevelMap[level];
//        }
//        return null;
//    }

//    //获取宠物最大等级

//    public int GetMaxLevel()
//    {
//        return petLevelMap.Count;
//    }


//    //获取温泉宝物配置
//    public Ft_pet_itemConfig GetPetItemInfo(int id)
//    {
//        if (petItemMap.ContainsKey(id))
//        {
//            return petItemMap[id];
//        }
//        return null;
//    }

//    //获取宠物羁绊配置
//    public Ft_pet_relationConfig GetPetRelationInfo(int id)
//    {
//        return petRelationList.Find(value => value.Id == id);
//    }

//    //获取宠物羁绊列表
//    public List<Ft_pet_relationConfig> GetPetRelationList()
//    {
//        petRelationList.Sort((a, b) =>
//        {
//            if (FettersActive(a.Id) && !FettersActive(a.Id)) return -1;
//            if (!FettersActive(a.Id) && FettersActive(a.Id)) return 1;
//            return a.Id - b.Id;
//        });
//        return petRelationList;
//    }

//    public bool FettersActive(int id)
//    {
//        var relation = GetPetRelationInfo(id);
        
//        foreach(var value in relation.PetCombinations)
//        {
//            if(GetPetServerData((uint)value) == null)
//            {
//                return false;
//            }
//        }
//        return true;
//    }

//    //获取温泉宝物列表
//    public List<StorageItemVO> GetTreasureList()
//    {
        
//        return StorageModel.Instance.GetStorageListByType_1(5702);
//    }

//    //获取宠物星级列表
//    public Ft_pet_starConfig GetStarInfo(int id,int level)
//    {
//        var str = id + "#" + level;
//        if (petStarMap.ContainsKey(str))
//        {
//            return petStarMap[str];
//        }
//        return null;
//    }

//    public void ParseBattleData()
//    {
//        if (petHome != null)
//        {
//            petHome.Clear();
//        }
//        petHome = petList.FindAll(value => value.Unlock);
//        petHome.Sort(BattleSort);
//    }

//    private int BattleSort(PetDataConfig a, PetDataConfig b)
//    {
//        if(a.Quality == b.Quality)
//        {
//            return b.Level - a.Level;
//        }
//        else
//        {
//            return b.Quality - a.Quality;
//        }
//    }

//    public void FilterBookData(int quality = 0)
//    {
//        if(petHome != null)
//        {
//            petHome.Clear();
//        }
        
//        if(quality == 0)
//        {
//            petHome = new List<PetDataConfig>(petList);
//        }
//        else
//        {
//            petHome = petList.FindAll(value => value.Quality == quality);
//        }
//        petHome.Sort(BookSort);
//    }

//    public int BookSort(PetDataConfig a, PetDataConfig b)
//    {
//        if(a.IsShard && !b.IsShard) return -1;
//        if (!a.IsShard && b.IsShard) return 1;
//        if (IsCanLevelStar(a.Id) && !IsCanLevelStar(b.Id)) return -1;
//        if (!IsCanLevelStar(a.Id) && IsCanLevelStar(b.Id)) return 1;
//        if (a.Unlock && !b.Unlock) return -1;
//        if (!a.Unlock && b.Unlock) return 1;
//        return b.Quality - a.Quality;
//    }
    

//    //获取宠物服务端数据
//    public I_PETS_VO GetPetServerData(uint petId)
//    {
//        return petsList.Find(value => value.petId == petId);
//    }

//    //宠物更新
//    public void UpdatePet(I_PETS_VO data)
//    {
//        var petData = GetPetServerData(data.petId);
//        if(petData != null)
//        {
//            petData.exp = data.exp;
//            petData.level = data.level;
//            petData.starLevel = data.starLevel;
//        }
//    }

//    //宠物更新
//    public void UpdateLevelup(I_PETS_VO data)
//    {
//        var petData = GetPetServerData(data.petId);
//        if (petData != null)
//        {
//            if(petData.level != data.level)
//            {
//                var lvData = new LevelData(petData.level,data.level,(int)data.petId);
//                UIManager.Instance.OpenWindow<LevelInfoWindow>(UIName.LevelInfoWindow, lvData);
//            }
//        }
//    }

//    public bool IsCanLevelStar(int petId)
//    {
//        var petInfo = GetPetInfo(petId);
//        if (!petInfo.Unlock)
//        {
//            return false;
//        }
//        var petData = GetPetServerData((uint)petId);
//        bool level = false;
//        if (!petInfo.IsLevelMax)
//        {
//            var nextLevelInfo = GetPetLevelInfo(petData.level + 1);
            
//            int nextLv = petInfo.Quality == 5 ? nextLevelInfo.Exps[3] : nextLevelInfo.Exps[petInfo.Quality - 1];
//            int exp = 0;
//            for (int i = 0; i < GlobalModel.Instance.module_profileConfig.petExpItem.Count; i++)
//            {
//                var count = StorageModel.Instance.GetItemCount(GlobalModel.Instance.module_profileConfig.petExpItem[i]);
//                exp += count * GlobalModel.Instance.module_profileConfig.petExpItemNum[i];
//                level = exp >= (nextLv - petData.exp) && !petInfo.IsLevelMax;
//            }
//        }
//        bool star = false;
//        if (!petInfo.IsStarMax)
//        {
//            var starInfo = GetStarInfo(petId, petData.starLevel);
//            var num = StorageModel.Instance.GetItemCount(petInfo.ShardId);
//            star = num >= starInfo.Cost && !petInfo.IsStarMax;
//        }
        
//        return level || star;
//    }

//    public int GetPetQuality(int id)
//    {
//        var petInfo = GetPetInfo(id);
//        return petInfo.Quality;
//    }
//}

