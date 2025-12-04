//using System.Collections;
//using System.Collections.Generic;
//using Elida.Config;
//using protobuf.cultivateresearch;
//using UnityEngine;

//public class ScientificPlantingModel : Singleton<ScientificPlantingModel>
//{
//    public I_CULTIVATION_RESEARCH_VO cultivateSearch;

//    public Ft_lottery_cultivateConfig _lotteryCultivateConfig;
//    public Ft_lottery_cultivateConfig lotteryCultivateConfig { get
//        {
//            if(_lotteryCultivateConfig == null)
//            {
//                Ft_lottery_cultivateConfigData lotteryData = ConfigManager.Instance.GetConfig<Ft_lottery_cultivateConfigData>("ft_lottery_cultivatesConfig");
//                _lotteryCultivateConfig = lotteryData.DataList[0];
//            }
//            return _lotteryCultivateConfig;
//        } }
//    public Dictionary<int, Ft_lottery_quantityConfig> _lotteryQuantityConfig;
//    public Dictionary<int,Ft_lottery_quantityConfig> lotteryQuantityConfig
//    {
//        get
//        {
//            if (_lotteryQuantityConfig == null)
//            {
//                Ft_lottery_quantityConfigData lotteryData = ConfigManager.Instance.GetConfig<Ft_lottery_quantityConfigData>("ft_lottery_quantitysConfig");
//                _lotteryQuantityConfig = lotteryData.DataMap;
//            }
//            return _lotteryQuantityConfig;
//        }
//    }

//    public float costMinTime;
//    public float costMinRate;

//    public void ParseCostInfo(string str)
//    {
//        var costs = str.Split(",");
//        costMinTime = float.Parse(costs[0]);
//        costMinRate = float.Parse(costs[1]);
//    }
//}