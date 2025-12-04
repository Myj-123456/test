using System;
using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using protobuf.ikebana;
using protobuf.item;
using protobuf.messagecode;
using protobuf.plant;
using UnityEngine;

public class FlowerHandbookController : BaseController<FlowerHandbookController>
{
    protected override void InitListeners()
    {
        AddNetListener<S_MSG_SEED_UPGRADE>((int)MessageCode.S_MSG_SEED_UPGRADE, SeedUpgrade);

        //AddNetListener<S_MSG_VASE_REWARD_INFO>((int)MessageCode.S_MSG_VASE_REWARD_INFO, VaseRewardInfo);
        //AddNetListener<S_MSG_VASE_REWARD>((int)MessageCode.S_MSG_VASE_REWARD, VaseReward);
        AddNetListener<S_MSG_VASE_FLOWER_REWARD>((int)MessageCode.S_MSG_VASE_FLOWER_REWARD, VaseFlowerReward);
        AddNetListener<S_MSG_VASE_GATHER_REWARD>((int)MessageCode.S_MSG_VASE_GATHER_REWARD, VaseGatherReward);
        AddNetListener<S_MSG_VASE_ONEKEY_REWARD>((int)MessageCode.S_MSG_VASE_ONEKEY_REWARD, VaseOnekeyReward);
        //ÏÊ»¨Í»ÆÆµÈ¼¶
        AddNetListener<S_MSG_SEED_UPGRADE_BREAKLV>((int)MessageCode.S_MSG_SEED_UPGRADE_BREAKLV, SeedUpGradeBreakLv);
        //ÏÊ»¨Éý½×¼¶
        AddNetListener<S_MSG_SEED_UPGRADE_GRADE>((int)MessageCode.S_MSG_SEED_UPGRADE_GRADE, SeedUpGradeGrade);
        //ÏÊ»¨ËéÆ¬¶Ò»»»¨¿¨
        AddNetListener<S_MSG_EXCHANGE_FLOWER_CARD>((int)MessageCode.S_MSG_EXCHANGE_FLOWER_CARD, ExchangeFlowerCard);
    }

    public void SeedUpgrade(S_MSG_SEED_UPGRADE data)
    {
        
        SeedCropVO exp = FlowerHandbookModel.Instance.GetCropVoByBook((int)data.seed.flowerId);
        var seed = FlowerHandbookModel.Instance.GetStaticSeedCondition((int)data.seed.flowerId);
        var cropVo = PlantModel.Instance.GetPlantCropConfigData(seed.LevelMould + "#" + exp.level);
        
        
        StorageModel.Instance.AddToStorageByItemId(seed.SeedId, -cropVo.SeedCost);
        StorageModel.Instance.UpLevelSeed(data.seed);
        EventManager.Instance.DispatchEvent(FlowerHandBookEvent.SeedUpgrade);
        EventManager.Instance.DispatchEvent(FlowerHandBookEvent.PlaySpine);
    }

    public void ResSeedUpgrade(uint flowerId)
    {
        C_MSG_SEED_UPGRADE c_MSG_SEED_UPGRADE = new C_MSG_SEED_UPGRADE();
        c_MSG_SEED_UPGRADE.flowerId = flowerId;
        SendCmd((int)MessageCode.C_MSG_SEED_UPGRADE, c_MSG_SEED_UPGRADE);
    }

    public void VaseRewardInfo(S_MSG_VASE_REWARD_INFO data)
    {
        FlowerHandbookModel.Instance.parseData(data.vaseRewardInfo);
        EventManager.Instance.DispatchEvent(FlowerHandBookEvent.VaseRewardInfo);
    }

    public void ReqVaseRewardInfo()
    {
        C_MSG_VASE_REWARD_INFO c_MSG_VASE_REWARD_INFO = new C_MSG_VASE_REWARD_INFO();
        SendCmd((int)MessageCode.C_MSG_VASE_REWARD_INFO, c_MSG_VASE_REWARD_INFO);
    }

    public void VaseReward(S_MSG_VASE_REWARD data)
    {
        DropManager.ShowDrop(ItemModel.Instance.GetDropData(data.items));
        FlowerHandbookModel.Instance.UpdateVaseReward(data.vaseId, data.items);
        EventManager.Instance.DispatchEvent(FlowerHandBookEvent.VaseReward);
    }

    public void ReqVaseReward(uint vaseId)
    {
        C_MSG_VASE_REWARD c_MSG_VASE_REWARD = new C_MSG_VASE_REWARD();
        c_MSG_VASE_REWARD.vaseId = vaseId;
        //SendCmd((int)MessageCode.C_MSG_VASE_REWARD, c_MSG_VASE_REWARD);
    }

    public void VaseFlowerReward(S_MSG_VASE_FLOWER_REWARD data)
    {
        DropManager.ShowDrop(ItemModel.Instance.GetDropData(data.items));
        FlowerHandbookModel.Instance.UpdateFlowerStatus(data.vaseId, data.flowerId);
        EventManager.Instance.DispatchEvent(FlowerHandBookEvent.VaseFlowerReward);
    }

    public void ReqVaseFlowerReward(uint vaseId,uint flowerId)
    {
        C_MSG_VASE_FLOWER_REWARD c_MSG_VASE_FLOWER_REWARD = new C_MSG_VASE_FLOWER_REWARD();
        c_MSG_VASE_FLOWER_REWARD.vaseId = vaseId;
        c_MSG_VASE_FLOWER_REWARD.flowerId = flowerId;
        SendCmd((int)MessageCode.C_MSG_VASE_FLOWER_REWARD, c_MSG_VASE_FLOWER_REWARD);
    }

    public void VaseGatherReward(S_MSG_VASE_GATHER_REWARD data)
    {
        DropManager.ShowDrop(ItemModel.Instance.GetDropData(data.items));
        FlowerHandbookModel.Instance.UpdateGatherStatus(data.vaseId);
        EventManager.Instance.DispatchEvent(FlowerHandBookEvent.VaseGatherReward);
    }

    public void ReqVaseGatherReward(uint vaseId)
    {
        C_MSG_VASE_GATHER_REWARD c_MSG_VASE_GATHER_REWARD = new C_MSG_VASE_GATHER_REWARD();
        c_MSG_VASE_GATHER_REWARD.vaseId = vaseId;
        SendCmd((int)MessageCode.C_MSG_VASE_GATHER_REWARD, c_MSG_VASE_GATHER_REWARD);
    }

    public void VaseOnekeyReward(S_MSG_VASE_ONEKEY_REWARD data)
    {
        DropManager.ShowDrop(ItemModel.Instance.GetDropData(data.items));
        FlowerHandbookModel.Instance.UpdateVaseOnekeyReward(data.vaseId, data.vaseRewardInfo);
        EventManager.Instance.DispatchEvent(FlowerHandBookEvent.VaseOnekeyReward);
    }

    public void ReqVaseOnekeyReward(uint vaseId)
    {
        C_MSG_VASE_ONEKEY_REWARD c_MSG_VASE_ONEKEY_REWARD = new C_MSG_VASE_ONEKEY_REWARD();
        c_MSG_VASE_ONEKEY_REWARD.vaseId = vaseId;
        SendCmd((int)MessageCode.C_MSG_VASE_ONEKEY_REWARD, c_MSG_VASE_ONEKEY_REWARD);
    }
    //ÏÊ»¨Í»ÆÆµÈ¼¶
    public void SeedUpGradeBreakLv(S_MSG_SEED_UPGRADE_BREAKLV data)
    {
        var seed = FlowerHandbookModel.Instance.GetStaticSeedCondition((int)data.seed.flowerId);
        //var breakInfo = FLowerModel.Instance.GetFlowerBreakConfig(seed.FlowerQuality, (int)data.seed.breakLv);
        //foreach(var value in breakInfo.BreakCosts)
        //{
        //    var itemVo = ItemModel.Instance.GetItemByEntityID(value.EntityID);
        //    StorageModel.Instance.AddToStorageByItemId(itemVo.ItemDefId, -value.Value);
        //}
        StorageModel.Instance.UpBreakLv(data.seed);
        EventManager.Instance.DispatchEvent(FlowerHandBookEvent.SeedUpGradeBreakLv);
        EventManager.Instance.DispatchEvent(FlowerHandBookEvent.PlaySpine);
    }

    public void ReqSeedUpGradeBreakLv(uint flowerId)
    {
        C_MSG_SEED_UPGRADE_BREAKLV c_MSG_SEED_UPGRADE_BREAKLV = new C_MSG_SEED_UPGRADE_BREAKLV();
        c_MSG_SEED_UPGRADE_BREAKLV.flowerId = flowerId;
        SendCmd((int)MessageCode.C_MSG_SEED_UPGRADE_BREAKLV, c_MSG_SEED_UPGRADE_BREAKLV);
    }
    //ÏÊ»¨Éý½×¼¶
    public void SeedUpGradeGrade(S_MSG_SEED_UPGRADE_GRADE data)
    {
        var seed = FlowerHandbookModel.Instance.GetStaticSeedCondition((int)data.seed.flowerId);
        var gradeInfo = FLowerModel.Instance.GetFlowerGradeConfig(seed.FlowerQuality, (int)data.seed.gradeLv);
        if(data.type == 1)
        {
            StorageModel.Instance.AddToStorageByItemId(seed.ShareId, -gradeInfo.GradeCost1);
        }
        else
        {
            StorageModel.Instance.AddToStorageByItemId(GlobalModel.Instance.module_profileConfig.universalShardId, -gradeInfo.GradeCost2);
        }

        StorageModel.Instance.UpGradeLv(data.seed);
        EventManager.Instance.DispatchEvent(FlowerHandBookEvent.SeedUpGradeGrade);
        EventManager.Instance.DispatchEvent(FlowerHandBookEvent.PlaySpine);
    }

    public void ReqSeedUpGradeGrade(uint flowerId,uint type)
    {
        C_MSG_SEED_UPGRADE_GRADE c_MSG_SEED_UPGRADE_GRADE = new C_MSG_SEED_UPGRADE_GRADE();
        c_MSG_SEED_UPGRADE_GRADE.flowerId = flowerId;
        c_MSG_SEED_UPGRADE_GRADE.type = type;
        SendCmd((int)MessageCode.C_MSG_SEED_UPGRADE_GRADE, c_MSG_SEED_UPGRADE_GRADE);
    }
    //ÏÊ»¨ËéÆ¬¶Ò»»»¨¿¨
    public void ExchangeFlowerCard(S_MSG_EXCHANGE_FLOWER_CARD data)
    {
        var condition = FlowerHandbookModel.Instance.GetStaticSeedCondition((int)data.flowerId);
        StorageModel.Instance.AddToStorageByItemId(condition.ShareId, -condition.ShardNum);
        StorageModel.Instance.AddToStorageItems(data.items);

        var itemData = ItemModel.Instance.GetItemById((int)data.flowerId);
        Action callFun = () => {
            
        };
        var param = new object[] { itemData, callFun };
        UIManager.Instance.OpenWindow<NewlyGotFlowerShowWindow>(UIName.NewlyGotFlowerShowWindow, param);
        EventManager.Instance.DispatchEvent(FlowerHandBookEvent.ExchangeFlowerCard);
    }

    public void ReqExchangeFlowerCard(uint flowerId)
    {
        C_MSG_EXCHANGE_FLOWER_CARD c_MSG_EXCHANGE_FLOWER_CARD = new C_MSG_EXCHANGE_FLOWER_CARD();
        c_MSG_EXCHANGE_FLOWER_CARD.flowerId = flowerId;
        SendCmd((int)MessageCode.C_MSG_EXCHANGE_FLOWER_CARD, c_MSG_EXCHANGE_FLOWER_CARD);
    }

}
