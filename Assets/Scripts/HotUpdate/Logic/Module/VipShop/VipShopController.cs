using System.Collections;
using System.Collections.Generic;
using protobuf.messagecode;
using protobuf.misc;
using UnityEngine;
using ADK;

public class VipShopController : BaseController<VipShopController>
{
    protected override void InitListeners()
    {
        //vip…ÃµÍ–≈œ¢
        AddNetListener<S_MSG_VIP_SHOP_INFO>((int)MessageCode.S_MSG_VIP_SHOP_INFO, VipShopInfo);
        //vip…ÃµÍπ∫¬Ú
        AddNetListener<S_MSG_VIP_SHOP_BUY>((int)MessageCode.S_MSG_VIP_SHOP_BUY, VipShopBuy);
        //‘”ªıµÍ∆Ã - –≈œ¢
        AddNetListener<S_MSG_SHOPSTORE_INFO>((int)MessageCode.S_MSG_SHOPSTORE_INFO, ShopStoreInfo);
        //‘”ªıµÍ∆Ã - π∫¬Ú
        AddNetListener<S_MSG_SHOPSTORE_BUY>((int)MessageCode.S_MSG_SHOPSTORE_BUY, ShopStoreBuy);
    }

    public void VipShopInfo(S_MSG_VIP_SHOP_INFO data)
    {
        VipShopModel.Instance.vipShopBuy = data.vipShopBuy;
        VipShopModel.Instance.dailyId = data.dailyId;
        VipShopModel.Instance.specialId = data.specialId;
        EventManager.Instance.DispatchEvent(VipShopEvent.VipShopInfo);
    }

    public void ReqVipShopInfo()
    {
        C_MSG_VIP_SHOP_INFO c_MSG_VIP_SHOP_INFO = new C_MSG_VIP_SHOP_INFO();
        SendCmd((int)MessageCode.C_MSG_VIP_SHOP_INFO, c_MSG_VIP_SHOP_INFO);
    }


    public void VipShopBuy(S_MSG_VIP_SHOP_BUY data)
    {
        VipShopModel.Instance.AddBuyTimes(data);
        var shopData = VipShopModel.Instance.GetShopConfigData((int)data.id);
        var reward = new StorageItemVO();
        reward.itemDefId = IDUtil.GetEntityValue(shopData.ItemId);
        reward.count = shopData.ItemNum;
        StorageModel.Instance.AddToStorageByItemId(reward.itemDefId, reward.count);
        var dropData = new List<StorageItemVO> { reward };
        UILogicUtils.ShowGetReward(dropData, () =>
        {
            DropManager.ShowDropItem1(reward.itemDefId,reward.count, false);
        });
        EventManager.Instance.DispatchEvent(VipShopEvent.VipShopBuy);
    }


    public void ReqVipShopBuy(int id)
    {
        C_MSG_VIP_SHOP_BUY c_MSG_VIP_SHOP_BUY = new C_MSG_VIP_SHOP_BUY();
        c_MSG_VIP_SHOP_BUY.id = (uint)id;
        SendCmd((int)MessageCode.C_MSG_VIP_SHOP_BUY, c_MSG_VIP_SHOP_BUY);
    }
    //‘”ªıµÍ∆Ã - –≈œ¢
    public void ShopStoreInfo(S_MSG_SHOPSTORE_INFO data)
    {
        VipShopModel.Instance.shopStore = data.shopStore;
        EventManager.Instance.DispatchEvent(VipShopEvent.ShopStoreInfo);
    }

    public void ReqShopStoreInfo()
    {
        C_MSG_SHOPSTORE_INFO c_MSG_SHOPSTORE_INFO = new C_MSG_SHOPSTORE_INFO();
        SendCmd((int)MessageCode.C_MSG_SHOPSTORE_INFO, c_MSG_SHOPSTORE_INFO);
    }
    //‘”ªıµÍ∆Ã - π∫¬Ú
    public void ShopStoreBuy(S_MSG_SHOPSTORE_BUY data)
    {
        VipShopModel.Instance.UpdateShopStore(data.store);
        var store = VipShopModel.Instance.GetStoreInfo((int)data.store.id);
        var dropData = new List<StorageItemVO> ();
        foreach(var value in store.ItemIds)
        {
            var reward = new StorageItemVO();
            var itemVo = ItemModel.Instance.GetItemByEntityID(value.EntityID);
            reward.itemDefId = itemVo.ItemDefId;
            reward.count = value.Value;
            dropData.Add(reward);
        }
        DropManager.ShowDrop(dropData);
        EventManager.Instance.DispatchEvent(VipShopEvent.ShopStoreBuy);
    }

    public void ReqShopStoreBuy(uint id)
    {
        C_MSG_SHOPSTORE_BUY c_MSG_SHOPSTORE_BUY = new C_MSG_SHOPSTORE_BUY();
        c_MSG_SHOPSTORE_BUY.id = id;
        SendCmd((int)MessageCode.C_MSG_SHOPSTORE_BUY, c_MSG_SHOPSTORE_BUY);
    }
}
