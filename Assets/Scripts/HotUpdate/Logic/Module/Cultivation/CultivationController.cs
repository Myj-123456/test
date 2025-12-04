using System.Collections;
using System.Collections.Generic;
using protobuf.messagecode;
using protobuf.plant;
using UnityEngine;
using ADK;

public class CultivationController : BaseController<CultivationController>
{
    protected override void InitListeners()
    {
        AddNetListener<S_MSG_CULTIVATE_SPEEDUP>((int)MessageCode.S_MSG_CULTIVATE_SPEEDUP, CultivationSpeedUp);
        AddNetListener<S_MSG_CULTIVATE_REPAIR>((int)MessageCode.S_MSG_CULTIVATE_REPAIR, CultivationRepair);
        AddNetListener<S_MSG_CULTIVATE_PLANT>((int)MessageCode.S_MSG_CULTIVATE_PLANT, CultivationPlant);
        AddNetListener<S_MSG_CULTIVATE_HARVEST>((int)MessageCode.S_MSG_CULTIVATE_HARVEST, CultivationHarvest);
        //培育 - 观看视频
        AddNetListener<S_MSG_CULTIVATE_VIDEO>((int)MessageCode.S_MSG_CULTIVATE_VIDEO, CultivateVideo);
        //助力
        AddNetListener<S_MSG_CULTIVATE_HELP>((int)MessageCode.S_MSG_CULTIVATE_HELP, CultivateHelp);
    }

    public void CultivationSpeedUp(S_MSG_CULTIVATE_SPEEDUP data)
    {
        CultivationModel.Instance.harvestTime = (int)ServerTime.Time;
        EventManager.Instance.DispatchEvent(CultivationEvent.CultivationSpeed);
    }

    public void ResCultivationSpeedUp()
    {
        C_MSG_CULTIVATE_SPEEDUP c_MSG_CULTIVATE_SPEEDUP = new C_MSG_CULTIVATE_SPEEDUP();
        SendCmd((int)MessageCode.C_MSG_CULTIVATE_SPEEDUP, c_MSG_CULTIVATE_SPEEDUP);
    }

    public void CultivationRepair(S_MSG_CULTIVATE_REPAIR data)
    {
        //StorageModel.Instance.AddToStorageByItemId((int)data.itemId, (int)data.count);
        StorageModel.Instance.AddToStorageItems(data.items);
        EventManager.Instance.DispatchEvent(CultivationEvent.CultivationRepair);
    }

    public void ResCultivationRepair(uint flowerId)
    {
        C_MSG_CULTIVATE_REPAIR c_MSG_CULTIVATE_REPAIR = new C_MSG_CULTIVATE_REPAIR();
        c_MSG_CULTIVATE_REPAIR.flowerId = flowerId;
        SendCmd((int)MessageCode.C_MSG_CULTIVATE_REPAIR, c_MSG_CULTIVATE_REPAIR, 0f);

    }

    public void CultivationPlant(S_MSG_CULTIVATE_PLANT data)
    {
        CultivationModel.Instance.flowerId = (int)data.flowerId;
        CultivationModel.Instance.harvestTime = (int)data.harvestTime;
        var items = FlowerHandbookModel.Instance.GetStaticSeedCondition((int)data.flowerId);
        if (items != null)
        {
            foreach (var item in items.ItemIds)
            {
                StorageModel.Instance.AddToStorageByItemId(item.EntityID, -item.Value);
            }
        }

        //UIManager.Instance.OpenWindow<CultivationNewTipWindow>(UIName.CultivationNewTipWindow, (int)data.flowerId);
        EventManager.Instance.DispatchEvent(CultivationEvent.CultivationPlant);
    }

    public void ResCultivationPlant(uint flowerId)
    {
        C_MSG_CULTIVATE_PLANT c_MSG_CULTIVATE_PLANT = new C_MSG_CULTIVATE_PLANT();
        c_MSG_CULTIVATE_PLANT.flowerId = flowerId;
        SendCmd((int)MessageCode.C_MSG_CULTIVATE_PLANT, c_MSG_CULTIVATE_PLANT);
    }

    public void CultivationHarvest(S_MSG_CULTIVATE_HARVEST data)
    {
        StorageModel.Instance.AddToSeedlist(data.seed);
        CultivationModel.Instance.flowerId = (int)data.cultivate.flowerId;
        CultivationModel.Instance.harvestTime = (int)data.cultivate.harvestTime;
        CultivationModel.Instance.videoTime = (int)data.cultivate.videoTimes;
        CultivationModel.Instance.helpCnt = (int)data.cultivate.helpCnt;
        //UIManager.Instance.OpenWindow<CultivationNewSeedWindow>(UIName.CultivationNewSeedWindow, (int)data.seed.flowerId);
        EventManager.Instance.DispatchEvent(CultivationEvent.CultivationHarvest);
        EventManager.Instance.DispatchEvent(TaskEvent.MainTaskCount,4);
    }

    public void ResCultivationHarvest()
    {
        C_MSG_CULTIVATE_HARVEST c_MSG_CULTIVATE_HARVEST = new C_MSG_CULTIVATE_HARVEST();
        SendCmd((int)MessageCode.C_MSG_CULTIVATE_HARVEST, c_MSG_CULTIVATE_HARVEST);

    }

    public void CultivateVideo(S_MSG_CULTIVATE_VIDEO data)
    {
        CultivationModel.Instance.videoTime = 1;
        CultivationModel.Instance.harvestTime = (int)data.harvestTime;
        EventManager.Instance.DispatchEvent(CultivationEvent.CultivateVideo);
    }

    public void ReqCultivateVideo()
    {
        C_MSG_CULTIVATE_VIDEO c_MSG_CULTIVATE_VIDEO = new C_MSG_CULTIVATE_VIDEO();
        SendCmd((int)MessageCode.C_MSG_CULTIVATE_VIDEO, c_MSG_CULTIVATE_VIDEO);
    }

    public void CultivateHelp(S_MSG_CULTIVATE_HELP data)
    {
        CultivationModel.Instance.helpCnt = (int)data.helpCnt;
        CultivationModel.Instance.harvestTime = (int)data.harvestTime;
        EventManager.Instance.DispatchEvent(CultivationEvent.CultivateHelp);
    }

    public void ReqCultivateHelp()
    {
        C_MSG_CULTIVATE_HELP c_MSG_CULTIVATE_HELP = new C_MSG_CULTIVATE_HELP();
        SendCmd((int)MessageCode.C_MSG_CULTIVATE_HELP, c_MSG_CULTIVATE_HELP);
    }
}
