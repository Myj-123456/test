using System.Collections.Generic;
using ADK;
using protobuf.dress;
using protobuf.messagecode;
/// <summary>
/// 换装管理器
/// </summary>
public class DressController : BaseController<DressController>
{
    protected override void InitListeners()
    {
        AddNetListener<S_MSG_DRESS_WARE>((int)MessageCode.S_MSG_DRESS_WARE, ResSaveWearList);
        //换装 - 开箱
        AddNetListener<S_MSG_DRESS_DRAW>((int)MessageCode.S_MSG_DRESS_DRAW, DressDraw);
        //换装 - 开箱积分奖励
        AddNetListener<S_MSG_DRESS_SCORE_REWARD>((int)MessageCode.S_MSG_DRESS_SCORE_REWARD, DressScoreReward);
        //换装 - 套装升星
        AddNetListener<S_MSG_DRESS_STAR_LV>((int)MessageCode.S_MSG_DRESS_STAR_LV, DressStarLv);
        //换装 - 套装升阶
        AddNetListener<S_MSG_DRESS_UPGRADE_LV>((int)MessageCode.S_MSG_DRESS_UPGRADE_LV, DressUpgradeLv);
        //换装 - 衣服商店购买
        AddNetListener<S_MSG_DRESS_CLOTHES_BUY>((int)MessageCode.S_MSG_DRESS_CLOTHES_BUY, DressClothesBuy);
    }

    /// <summary>
    /// 请求穿戴部件(前端自己更改 不保存后端)
    public void ReqWearPart(uint clothesId)
    {
        DressModel.Instance.Wear(clothesId);
        EventManager.Instance.DispatchEvent(DressEvent.WearPart);
    }
    /// <summary>
    /// 请求穿戴部件(前端自己更改 不保存后端)
    public void ReqWearPartSuit(uint clothesId)
    {
        //Dictionary<int, DressData>
        DressModel.Instance.Wear(clothesId);
        EventManager.Instance.DispatchEvent(DressEvent.WearPart);
    }
    /// <summary>
    /// 发送服务器保存穿戴列表
    /// </summary>
    /// <param name="clientClothesId"></param>
    public void ReqSaveWearList(uint[] clientClothesId)
    {
        var serverClothesId = DressModel.Instance.GetServerWearList();
        if (ADK.ADKTool.AreArraysEqual(clientClothesId, serverClothesId))//数据没更改 不需要请求服务器
            return;

        C_MSG_DRESS_WARE c_MSG_DRESS_WARE = new C_MSG_DRESS_WARE();
        c_MSG_DRESS_WARE.clothesIds = string.Join(",", clientClothesId);
        SendCmd((int)MessageCode.C_MSG_DRESS_WARE, c_MSG_DRESS_WARE);
    }

    private void ResSaveWearList(S_MSG_DRESS_WARE s_MSG_DRESS_WARE)
    {
        //更改服务器列表
        DressModel.Instance.UpdateDressData(s_MSG_DRESS_WARE.ware);
        EventManager.Instance.DispatchEvent(DressEvent.ChangeSceneHeroModel);
    }
    //换装 - 开箱
    public void DressDraw(S_MSG_DRESS_DRAW data)
    {
        DressModel.Instance.score = data.score;
        StorageModel.Instance.OddToStorageItems(data.costItems);
        foreach (protobuf.item.I_ITEM_VO item in data.itemList)
        {
            StorageModel.Instance.AddToStorageByItemId(IDUtil.GetEntityValue(item.itemDefId), (int)item.count);
        }
        UIManager.Instance.OpenWindow<DressCallResultWindow>(UIName.DressCallResultWindow, data.itemList);
        EventManager.Instance.DispatchEvent(DressEvent.DressDraw);
    }

    public void ReqDressDraw(uint id,uint num)
    {
        C_MSG_DRESS_DRAW c_MSG_DRESS_DRAW = new C_MSG_DRESS_DRAW();
        c_MSG_DRESS_DRAW.id = id;
        c_MSG_DRESS_DRAW.num = num;
        SendCmd((int)MessageCode.C_MSG_DRESS_DRAW, c_MSG_DRESS_DRAW);
    }
    //换装 - 开箱积分奖励
    public void DressScoreReward(S_MSG_DRESS_SCORE_REWARD data)
    {
        DressModel.Instance.score = data.score;
        DressModel.Instance.rewardId = data.rewardId;
        //StorageModel.Instance.AddToStorage(data.items);
        var drapList = ItemModel.Instance.GetDropData(data.items);
        DropManager.ShowDrop(drapList);
        EventManager.Instance.DispatchEvent(DressEvent.DressScoreReward);
    }

    public void ReqDressScoreReward()
    {
        C_MSG_DRESS_SCORE_REWARD c_MSG_DRESS_SCORE_REWARD = new C_MSG_DRESS_SCORE_REWARD();
        SendCmd((int)MessageCode.C_MSG_DRESS_SCORE_REWARD, c_MSG_DRESS_SCORE_REWARD);
    }
    //换装 - 套装升星
    public void DressStarLv(S_MSG_DRESS_STAR_LV data)
    {
        DressModel.Instance.UpdateStarLv(data.suitId, data.starLv);
        StorageModel.Instance.OddToStorageItems(data.costItems); 
        EventManager.Instance.DispatchEvent(DressEvent.DressStarLv);

    }

    public void ReqDressStarLv(uint suitId)
    {
        C_MSG_DRESS_STAR_LV c_MSG_DRESS_STAR_LV = new C_MSG_DRESS_STAR_LV();
        c_MSG_DRESS_STAR_LV.suitId = suitId;
        SendCmd((int)MessageCode.C_MSG_DRESS_STAR_LV, c_MSG_DRESS_STAR_LV);
    }
    //换装 - 套装升阶
    public void DressUpgradeLv(S_MSG_DRESS_UPGRADE_LV data)
    {
        DressModel.Instance.UpdateGradeLv(data.suitId, data.gradeLv);
        StorageModel.Instance.OddToStorageItems(data.costItems);
        EventManager.Instance.DispatchEvent(DressEvent.DressUpgradeLv);
    }

    public void ReqDressUpgradeLv(uint suitId)
    {
        C_MSG_DRESS_UPGRADE_LV cMSG_DRESS_UPGRADE_LV = new C_MSG_DRESS_UPGRADE_LV();
        cMSG_DRESS_UPGRADE_LV.suitId = suitId;
        SendCmd((int)MessageCode.C_MSG_DRESS_UPGRADE_LV, cMSG_DRESS_UPGRADE_LV);
    }
    //换装 - 衣服商店购买
    public void DressClothesBuy(S_MSG_DRESS_CLOTHES_BUY data)
    {
        DressModel.Instance.dressShopExp = data.dressShopExp;
        var shopInfo = DressModel.Instance.GetDressShopInfo((int)data.indexId);
        StorageModel.Instance.AddToStorageByItemId(shopInfo.Prices[0].EntityID, -shopInfo.Prices[0].Value);
        var dropList = new List<StorageItemVO>();
        foreach(var value in shopInfo.ItemIds)
        {
            var drop = new StorageItemVO();
            var itemVo = ItemModel.Instance.GetItemByEntityID(value.EntityID);
            drop.itemDefId = itemVo.ItemDefId;
            drop.count = value.Value;
            dropList.Add(drop);
        }
        DropManager.ShowDrop(dropList);
        EventManager.Instance.DispatchEvent(DressEvent.DressClothesBuy);
    }

    public void ReqDressClothesBuy(uint indexId)
    {
        C_MSG_DRESS_CLOTHES_BUY c_MSG_DRESS_CLOTHES_BUY = new C_MSG_DRESS_CLOTHES_BUY();
        c_MSG_DRESS_CLOTHES_BUY.indexId = indexId;
        SendCmd((int)MessageCode.C_MSG_DRESS_CLOTHES_BUY, c_MSG_DRESS_CLOTHES_BUY);
    }
}
