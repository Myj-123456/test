using System.Collections;
using System.Collections.Generic;
using ADK;
using protobuf.cultivateshop;
using protobuf.messagecode;
using UnityEngine;

public class CultivationShopController : BaseController<CultivationShopController>
{
    protected override void InitListeners()
    {
        AddNetListener<S_MSG_CULTIVATE_REFRESH>((int)MessageCode.S_MSG_CULTIVATE_REFRESH, CultivateRefresh);
        AddNetListener<S_MSG_CULTIVATE_BUY>((int)MessageCode.S_MSG_CULTIVATE_BUY, CultivateBuy);
        AddNetListener<S_MSG_CULTIVATE_SHOP>((int)MessageCode.S_MSG_CULTIVATE_SHOP, CultivateShop);
    }

    public void CultivateRefresh(S_MSG_CULTIVATE_REFRESH data)
    {
        CultivationShopModel.Instance.cultivateShops = data.cultivateShops;
        CultivationShopModel.Instance.refreshCnt = data.refreshCnt;
        CultivationShopModel.Instance.refreshTime = data.refreshTime;
        EventManager.Instance.DispatchEvent(CultivationShopEvent.CultivateRefresh);
    }

    public void ReqCultivateRefresh()
    {
        C_MSG_CULTIVATE_REFRESH c_MSG_CULTIVATE_REFRESH = new C_MSG_CULTIVATE_REFRESH();
        SendCmd((int)MessageCode.C_MSG_CULTIVATE_REFRESH, c_MSG_CULTIVATE_REFRESH);
    }

    public void CultivateBuy(S_MSG_CULTIVATE_BUY data)
    {
        var vo = CultivationShopModel.Instance.breedShopMap[(int)data.cultivateShop.itemId];
        //StorageModel.Instance.AddToStorageByItemId(vo.GetItem.ToString(), (int)data.cultivateShop.itemCnt);
        CultivationShopModel.Instance.UpdateCultivateShops(data.cultivateShop);
        var dropList = new List<StorageItemVO>();
        var drop = new StorageItemVO();
        drop.itemDefId = IDUtil.GetEntityValue(vo.GetItem.ToString());
        drop.count = (int)data.cultivateShop.itemCnt;
        dropList.Add(drop);
        DropManager.ShowDrop(dropList);
        EventManager.Instance.DispatchEvent(CultivationShopEvent.ReqCultivateBuy);
    }

    public void ReqCultivateBuy(uint position)
    {
        C_MSG_CULTIVATE_BUY c_MSG_CULTIVATE_BUY = new C_MSG_CULTIVATE_BUY();
        c_MSG_CULTIVATE_BUY.position = position;
        SendCmd((int)MessageCode.C_MSG_CULTIVATE_BUY, c_MSG_CULTIVATE_BUY);
    }

    public void CultivateShop(S_MSG_CULTIVATE_SHOP data)
    {
        CultivationShopModel.Instance.cultivateShops = data.cultivateShops;
        CultivationShopModel.Instance.refreshCnt = data.refreshCnt;
        CultivationShopModel.Instance.refreshTime = data.refreshTime;
        EventManager.Instance.DispatchEvent(CultivationShopEvent.CultivateRefresh);
    }

    public void ReqCultivateShop()
    {
        C_MSG_CULTIVATE_SHOP c_MSG_CULTIVATE_SHOP = new C_MSG_CULTIVATE_SHOP();
        SendCmd((int)MessageCode.C_MSG_CULTIVATE_SHOP, c_MSG_CULTIVATE_SHOP);
    }
}
