using System.Collections;
using System.Collections.Generic;
using ADK;
using Elida.Config;
using protobuf.misc;
using UnityEngine;
using static protobuf.misc.S_MSG_VIP_SHOP_INFO;

public class VipShopModel : Singleton<VipShopModel>
{
    private List<Ft_item_vip_shopConfig> _shopDataList;
    public List<Ft_item_vip_shopConfig> shopDataList { get
        {
            if(_shopDataList == null)
            {
                Ft_item_vip_shopConfigData shopData = ConfigManager.Instance.GetConfig<Ft_item_vip_shopConfigData>("ft_item_vip_shopsConfig");
                _shopDataList = shopData.DataList;
            }
            return _shopDataList;
        } }

    private List<Ft_shop_storeConfig> _storeList;
    public List<Ft_shop_storeConfig> storeList
    { get
        {
            if(_storeList == null)
            {
                var storeData = ConfigManager.Instance.GetConfig<Ft_shop_storeConfigData>("ft_shop_storesConfig");
                _storeList = storeData.DataList;
            }
            return _storeList;
        } }

    //特卖和专属信息
    public List<I_MESSAGE_VIPSHOP_BUY_VO> vipShopBuy;

    public uint dailyId;//每日特价配置id
    public uint specialId;//专属特卖配置id

    public List<I_MESSAGE_SHOPSTORE_VO> shopStore;//杂货店铺信息
    public List<Ft_item_vip_shopConfig> GetVipShopList()
    {
        return shopDataList.FindAll((value) =>
        {
            return value.Type == 0;
        });
    }

    public List<Ft_item_vip_shopConfig> FilterVipShopList(string str = "")
    {
        var listData = GetVipShopList();
        var daily = GetShopConfigData((int)dailyId);
        listData.Insert(0, daily);
        if(str == "")
        {
            return listData;
        }
        else
        {
            return listData.FindAll(value => value.ItemName.Contains(str));
        }
        
    }

    public string GetURLByPriceType(int priceTye)
    {
        string url = "";
        switch (priceTye)
        {
            case 1:
                url = ImageDataModel.CASH_ICON_URL;
                break;
            case 2:
                url = ImageDataModel.Instance.GetIconUrlByItemId((long)BaseType.GRANDMA_TICKET);
                break;
        }
        return url;
    }

    public bool IsCurrencyEnough(int priceTye,int count,bool log = true)
    {
        bool enough = false;
        switch (priceTye)
        {
            case 1:
                enough = count <= MyselfModel.Instance.diamond;
                if (!enough && log)
                {
                    UILogicUtils.ShowNotice(Lang.GetValue("common_hint_txt3"));
                }
                break;
            case 2:
                var have = StorageModel.Instance.GetItemCount((int)BaseType.GRANDMA_TICKET);
                enough = count <= have;
                if (!enough && log)
                {
                    var item = ItemModel.Instance.GetItemById((int)BaseType.GRANDMA_TICKET);
                    UILogicUtils.ShowNotice(Lang.GetValue("guild.notEnough",Lang.GetValue(item.Name)));
                }
                break;
        }
        return enough;
    }

    public I_MESSAGE_SHOPSTORE_VO GetShopStoreData(uint id)
    {
        return shopStore.Find(value => value.id == id);
    }

    public void UpdateShopStore(I_MESSAGE_SHOPSTORE_VO data)
    {
        var storeData = GetShopStoreData(data.id);
        if(storeData != null)
        {
            storeData.oddCount = data.oddCount;
        }
        else
        {
            shopStore.Add(data);
        }
    }

    public void AddBuyTimes(S_MSG_VIP_SHOP_BUY shopInfo)
    {
        var shopData = GetVipShopData(shopInfo.id);
       if(shopData != null)
        {
            shopData.buyCount = shopInfo.buyCount;
        }
        else
        {
            var shop = new I_MESSAGE_VIPSHOP_BUY_VO();
            shop.indexId = shopInfo.id;
            shop.buyCount = shopInfo.buyCount;
            vipShopBuy.Add(shop);
        }
    }

    public I_MESSAGE_VIPSHOP_BUY_VO GetVipShopData(uint id)
    {
        return vipShopBuy.Find(value => value.indexId == id);
    }

    public Ft_item_vip_shopConfig GetShopConfigData(int id)
    {
        return shopDataList.Find(value => value.Id == id);
    }

    public Ft_shop_storeConfig GetStoreInfo(int id)
    {
        return storeList.Find(value => value.Id == id);
    }
}

