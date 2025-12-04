using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using UnityEngine;

public class MarqueeModel : Singleton<MarqueeModel>
{
    private Dictionary<int, Ft_paom_configConfig> _marqueeMap;
    public Dictionary<int, Ft_paom_configConfig> marqueeMap { get
        {
            if(_marqueeMap == null)
            {
                var marqueeData = ConfigManager.Instance.GetConfig<Ft_paom_configConfigData>("ft_paom_configsConfig");
                _marqueeMap = marqueeData.DataMap;
            }
            return _marqueeMap;
        } }

   
    public List<string> marqueeList = new List<string>();
    public Ft_paom_configConfig GetMarqueeInfo(int id)
    {
        if (marqueeMap.ContainsKey(id))
        {
            return marqueeMap[id];
        }
        return null;
    }
}


public enum MarqueeType
{
    Diamond_Fund = 1,//开通钻石基金
    Enter_Fund = 2,//开通入门基金
    Step_Fund = 3,//开通进阶基金
    Diamond_Draw = 4,//钻石抽卡抽到大奖
    Month_Draw = 5,//月度抽卡抽到大奖
    Dress_Draw = 6,//衣服抽卡抽到大奖
    Vip = 7,//开通VIP
    Senior_Constract = 8,//开通尊享版合约
    Blind_Draw = 8,//盲盒抽中隐藏款
}

