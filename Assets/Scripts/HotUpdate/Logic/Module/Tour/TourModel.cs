//using System.Collections;
//using System.Collections.Generic;
//using Elida.Config;
//using protobuf.fairy;
//using protobuf.pets;
//using UnityEngine;

//public class TourModel : Singleton<TourModel>
//{
//    //巡游等级表
//    private Dictionary<int, Ft_island_tourConfig> _tourMap;
//    public Dictionary<int, Ft_island_tourConfig> tourMap { get
//        {
//            if(_tourMap == null)
//            {
//                var tourData = ConfigManager.Instance.GetConfig<Ft_island_tourConfigData>("ft_island_toursConfig");
//                _tourMap = tourData.DataMap;
//            }
//            return _tourMap;
//        } }
//    //巡游事件表
//    private Dictionary<int, Ft_island_eventConfig> _tourEventMap;
//    public Dictionary<int, Ft_island_eventConfig> tourEventMap
//    {
//        get
//        {
//            if (_tourEventMap == null)
//            {
//                var tourData = ConfigManager.Instance.GetConfig<Ft_island_eventConfigData>("ft_island_eventsConfig");
//                _tourEventMap = tourData.DataMap;
//            }
//            return _tourEventMap;
//        }
//    }

//    public Ft_island_tourConfig GetTourFromId(int id)
//    {
//        if (tourMap.ContainsKey(id))
//        {
//            return tourMap[id];
//        }
//        return null;
//    }

//    public Ft_island_eventConfig GetTourEventFromId(int id)
//    {
//        if (tourEventMap.ContainsKey(id))
//        {
//            return tourEventMap[id];
//        }
//        return null;
//    }

//    //获取已有宠物列表
//    public List<I_PETS_VO> GetPetList()
//    {
//        var dataList = new List<I_PETS_VO>(PetModel.Instance.petsList);
//        dataList.Sort(PetSort);
//        return dataList;
//    }

//    private int PetSort(I_PETS_VO a, I_PETS_VO b)
//    {
//        var qualityA = PetModel.Instance.GetPetQuality((int)a.petId);
//        var qualityB = PetModel.Instance.GetPetQuality((int)b.petId);
//        if (qualityB == qualityA)
//        {
//            return b.level - a.level;
//        }
//        else
//        {
//            return qualityB - qualityA;
//        }
//    }

//    //获取已有花仙列表
//    public List<I_FAIRY_VO> GetFairyList()
//    {
//        var dataList = new List<I_FAIRY_VO>(FlowerGoldModel.Instance.fairys);
//        dataList.Sort(FairySort);
//        return dataList;
//    }

//    private int FairySort(I_FAIRY_VO a, I_FAIRY_VO b)
//    {
//        var qualityA = FlowerGoldModel.Instance.GetFairyInfo((int)a.fairyId).Quality;
//        var qualityB = FlowerGoldModel.Instance.GetFairyInfo((int)b.fairyId).Quality;
//        if(qualityB == qualityA)
//        {
//            return b.level - a.level;
//        }
//        else
//        {
//            return qualityB - qualityA;
//        }
        
//    }
//}

