using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using protobuf.cultivateshop;
using UnityEngine;

public class CultivationShopModel : Singleton<CultivationShopModel>
{
    public uint refreshTime;//上次刷新时间
    public uint refreshCnt;//当天已刷新次数
    public List<I_SHOP_ITEM> cultivateShops;//6个位置信息
    //刷新间隔时间
    public int refrushTimeGap;
    //免费刷新次数
    public uint freeMaxTime;

    private Dictionary<int, Ft_breedshop_itemConfig> _breedShopMap;
    public Dictionary<int, Ft_breedshop_itemConfig> breedShopMap { get
        {
            if(_breedShopMap == null)
            {
                Ft_breedshop_itemConfigData breedShopData = ConfigManager.Instance.GetConfig<Ft_breedshop_itemConfigData>("ft_breedshop_itemsConfig");
                _breedShopMap = breedShopData.DataMap;
            }
            return _breedShopMap;
        } }


    public void UpdateCultivateShops(I_SHOP_ITEM data)
    {
        for(int i = 0;i < cultivateShops.Count; i++)
        {
            if(cultivateShops[i].position == data.position)
            {
                cultivateShops[i] = data;
                return;
            }
        }
    }
}

