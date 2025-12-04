using System.Collections;
using System.Collections.Generic;
using protobuf.messagecode;
using protobuf.plant;
using protobuf.table;
using UnityEngine;

public class FlowerSellController : BaseController<FlowerSellController>
{
    protected override void InitListeners()
    {
        AddNetListener<S_MSG_TABLE_UNLOCK>((int)MessageCode.S_MSG_TABLE_UNLOCK, ResTableUnLock);
        AddNetListener<S_MSG_TABLE_SELL_REWARD>((int)MessageCode.S_MSG_TABLE_SELL_REWARD, ResSellFlowerReward);
        AddNetListener<S_MSG_TABLE_ONSHELF>((int)MessageCode.S_MSG_TABLE_ONSHELF, ResFlowerOnShelf);
        AddNetListener<S_MSG_TABLE_ONEKEY_ONSHELF>((int)MessageCode.S_MSG_TABLE_ONEKEY_ONSHELF, ResFlowerOneKeyOnShelf);
    }

    public void ReqTableUnLock(uint tableId)
    {
        C_MSG_TABLE_UNLOCK c_MSG_TABLE_UNLOCK = new C_MSG_TABLE_UNLOCK();
        c_MSG_TABLE_UNLOCK.gridId = tableId;
        SendCmd((int)MessageCode.C_MSG_TABLE_UNLOCK, c_MSG_TABLE_UNLOCK);
    }

    private void ResTableUnLock(S_MSG_TABLE_UNLOCK s_MSG_TABLE_UNLOCK)
    {
        var tableVo = FlowerSellModel.Instance.UpdateTable(s_MSG_TABLE_UNLOCK.table);
        DispatchEvent(FloweSellEvent.TABLE_UNLOCK, tableVo);
        DispatchEvent(TaskEvent.MainTaskCount,20);
    }


    private int sellGold;
    public void ReqSellFlowerReward(uint tableId, int sellGold)
    {
        this.sellGold = sellGold;
        C_MSG_TABLE_SELL_REWARD c_MSG_TABLE_SELL_REWARD = new C_MSG_TABLE_SELL_REWARD();
        c_MSG_TABLE_SELL_REWARD.gridId = tableId;
        SendCmd((int)MessageCode.C_MSG_TABLE_SELL_REWARD, c_MSG_TABLE_SELL_REWARD);
    }


    public void ResSellFlowerReward(S_MSG_TABLE_SELL_REWARD s_MSG_TABLE_SELL_REWARD)
    {
        FlowerSellModel.Instance.UpdateTable(s_MSG_TABLE_SELL_REWARD.table);
        DispatchEvent(FloweSellEvent.SellFlowerReward, s_MSG_TABLE_SELL_REWARD.table.gridId);
        if (sellGold > 0)
        {
            var flowerStand = SceneManager.Instance.GetFlowerStand(s_MSG_TABLE_SELL_REWARD.table.gridId);
            if (flowerStand != null)
            {
                Vector2 pt = ADK.UILogicUtils.TransformPos(flowerStand.transform.position);
                DropManager.ShowDropItem1((int)ADK.BaseType.GOLD, sellGold, false, pt);
                sellGold = 0;
            }
        }
    }

    //摆台上架
    public void ReqFlowerOnShelf(uint gridId, uint itemId, uint cnt)
    {
        C_MSG_TABLE_ONSHELF c_MSG_TABLE_ONSHELF = new C_MSG_TABLE_ONSHELF();
        c_MSG_TABLE_ONSHELF.gridId = gridId;
        c_MSG_TABLE_ONSHELF.itemId = itemId;
        c_MSG_TABLE_ONSHELF.cnt = cnt;
        SendCmd((int)MessageCode.C_MSG_TABLE_ONSHELF, c_MSG_TABLE_ONSHELF);
    }

    private void ResFlowerOnShelf(S_MSG_TABLE_ONSHELF s_MSG_TABLE_ONSHELF)
    {
        FlowerSellModel.Instance.UpdateTable(s_MSG_TABLE_ONSHELF.table);
        StorageModel.Instance.AddToStorageByItemId((int)s_MSG_TABLE_ONSHELF.itemId, -(int)s_MSG_TABLE_ONSHELF.costCnt);
        DispatchEvent(FloweSellEvent.OnShelfFlower, s_MSG_TABLE_ONSHELF.table.gridId);
    }


    /// <summary>
    /// 花一键摆台上架
    /// </summary>
    /// <param name="tableId"></param>
    public void ReqFlowerOneKeyOnShelf(uint itemId)
    {
        C_MSG_TABLE_ONEKEY_ONSHELF c_MSG_TABLE_SELL_REWARD = new C_MSG_TABLE_ONEKEY_ONSHELF();
        c_MSG_TABLE_SELL_REWARD.itemId = itemId;
        SendCmd((int)MessageCode.C_MSG_TABLE_ONEKEY_ONSHELF, c_MSG_TABLE_SELL_REWARD);
    }

    private void ResFlowerOneKeyOnShelf(S_MSG_TABLE_ONEKEY_ONSHELF s_MSG_TABLE_ONEKEY_ONSHELF)
    {
        foreach (var table in s_MSG_TABLE_ONEKEY_ONSHELF.tableList)
        {
            FlowerSellModel.Instance.UpdateTable(table);
            DispatchEvent(FloweSellEvent.OnShelfFlower, table.gridId);
        }
        StorageModel.Instance.AddToStorageByItemId((int)s_MSG_TABLE_ONEKEY_ONSHELF.itemId, -(int)s_MSG_TABLE_ONEKEY_ONSHELF.costCnt);
    }

    public void ShowStandFlower(uint deskId, int itemId)
    {
        DispatchEvent(FloweSellEvent.ShowStandFlower, deskId, itemId);
    }
}
