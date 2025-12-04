using System.Collections;
using System.Collections.Generic;
using protobuf.flowerstar;
using protobuf.messagecode;
using UnityEngine;
using ADK;

public class FlowerStarController : BaseController<FlowerStarController>
{
    protected override void InitListeners()
    {
        //解锁
        AddNetListener<S_FLOWERSTAR_UNLOCK>((int)MessageCode.S_FLOWERSTAR_UNLOCK, FlowerStarUnlock);
        //研究
        AddNetListener<S_FLOWERSTAR_UPGREADE>((int)MessageCode.S_FLOWERSTAR_UPGREADE, FlowerStarUpgrstar);
        //替换
        AddNetListener<S_FLOWERSTAR_REPLACE>((int)MessageCode.S_FLOWERSTAR_REPLACE, FlowerStarReplace);
    }
    //解锁
    public void FlowerStarUnlock(S_FLOWERSTAR_UNLOCK data)
    {
        FlowerStarModel.Instance.UpdateBuffInfo(data.flowerId, (uint)data.pos, data.buffId);
        EventManager.Instance.DispatchEvent<uint>(FlowerStarEvent.FlowerStarUnlock, (uint)data.pos);
    }

    public void ReqFlowerStarUnlock(uint flowerId,uint pos)
    {
        C_FLOWERSTAR_UNLOCK c_FLOWERSTAR_UNLOCK = new C_FLOWERSTAR_UNLOCK();
        c_FLOWERSTAR_UNLOCK.flowerId = flowerId;
        c_FLOWERSTAR_UNLOCK.pos = (int)pos;
        SendCmd((int)MessageCode.C_FLOWERSTAR_UNLOCK, c_FLOWERSTAR_UNLOCK);
    }
    //研究
    public void FlowerStarUpgrstar(S_FLOWERSTAR_UPGREADE data)
    {
        var costConfig = FlowerStarModel.Instance.flowerStarRefreshConfig[data.pos + 1];
        var staticSeedCondition = FlowerHandbookModel.Instance.staticSeedCondition[(int)data.flowerId];
        var needItem = staticSeedCondition.ItemIds[data.pos];
        var needCount = Mathf.Ceil((float)needItem.Value * (float)costConfig.PropPercent / 100f);
        StorageModel.Instance.AddToStorageByItemId(IDUtil.GetEntityValue(needItem.EntityID), -(int)needCount);

        FlowerStarModel.Instance.UpdateUpgradeBuffInfo(data.flowerId, (uint)data.pos, data.buffId);
        EventManager.Instance.DispatchEvent<uint>(FlowerStarEvent.FlowerStarUpgrstar, (uint)data.pos);
    }

    public void ReqFlowerStarUpgrstar(uint flowerId, uint pos)
    {
        C_FLOWERSTAR_UPGREADE c_FLOWERSTAR_UPGREADE = new C_FLOWERSTAR_UPGREADE();
        c_FLOWERSTAR_UPGREADE.flowerId = flowerId;
        c_FLOWERSTAR_UPGREADE.pos = (int)pos;
        SendCmd((int)MessageCode.C_FLOWERSTAR_UPGREADE, c_FLOWERSTAR_UPGREADE);
    }
    //替换
    public void FlowerStarReplace(S_FLOWERSTAR_REPLACE data)
    {
        FlowerStarModel.Instance.UpdateBuffInfo(data.flowerId, (uint)data.pos, data.buffId);
        EventManager.Instance.DispatchEvent<uint>(FlowerStarEvent.FlowerStarReplace, (uint)data.pos);
    }

    public void ReqFlowerStarReplace(uint flowerId, uint pos)
    {
        C_FLOWERSTAR_REPLACE c_FLOWERSTAR_REPLACE = new C_FLOWERSTAR_REPLACE();
        c_FLOWERSTAR_REPLACE.flowerId = flowerId;
        c_FLOWERSTAR_REPLACE.pos = (int)pos;
        SendCmd((int)MessageCode.C_FLOWERSTAR_REPLACE, c_FLOWERSTAR_REPLACE);
    }
}
