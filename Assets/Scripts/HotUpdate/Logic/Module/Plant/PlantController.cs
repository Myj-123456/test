
using FairyGUI;
using protobuf.friend;
using protobuf.messagecode;
using protobuf.plant;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 种植控制器
/// </summary>
public class PlantController : BaseController<PlantController>
{
    protected override void InitListeners()
    {
        AddNetListener<S_MSG_PLANT_UNLOCK>((int)MessageCode.S_MSG_PLANT_UNLOCK, ResUnLockLand);
        AddNetListener<S_MSG_PLANT_PLANT>((int)MessageCode.S_MSG_PLANT_PLANT, ResPlantLand);
        AddNetListener<S_MSG_PLANT_WATER>((int)MessageCode.S_MSG_PLANT_WATER, ResWater);
        AddNetListener<S_MSG_PLANT_HARVEST>((int)MessageCode.S_MSG_PLANT_HARVEST, ResHarvest);
        AddNetListener<S_MSG_PLANT_SPEED>((int)MessageCode.S_MSG_PLANT_SPEED, ResPlantSpeed);
        AddNetListener<S_MSG_PLANT_MOVE>((int)MessageCode.S_MSG_PLANT_MOVE, ResPlantMove);
        AddNetListener<S_MSG_PLANT_FREE_SPEEDUP>((int)MessageCode.S_MSG_PLANT_FREE_SPEEDUP, ResPlantFreeSpeedUp);
        //一键偷花
        AddNetListener<S_MSG_FRIEND_BATCH_STEAL>((int)MessageCode.S_MSG_FRIEND_BATCH_STEAL, BatchSteal);
    }

    public void ReqUnLockLand(int landId)
    {
        C_MSG_PLANT_UNLOCK c_MSG_PLANT_UNLOCK = new C_MSG_PLANT_UNLOCK();
        c_MSG_PLANT_UNLOCK.decorIds = (uint)landId;
        SendCmd((int)MessageCode.C_MSG_PLANT_UNLOCK, c_MSG_PLANT_UNLOCK);
    }

    private void ResUnLockLand(S_MSG_PLANT_UNLOCK s_MSG_PLANT_UNLOCK)
    {
        var plantVo = PlantModel.Instance.AddPlantVO(s_MSG_PLANT_UNLOCK.plant);
        var land = SceneManager.Instance.GetLand((int)s_MSG_PLANT_UNLOCK.plant.decorId);
        if (land != null)
        {
            land.UpLock(plantVo);
        }
        EventManager.Instance.DispatchEvent(TaskEvent.MainTaskCount, 19);
    }

    public void ReqPlantLand(uint[] landIds, int flowerSeedId)
    {
        C_MSG_PLANT_PLANT c_MSG_PLANT_PLANT = new C_MSG_PLANT_PLANT();
        c_MSG_PLANT_PLANT.decorIds = landIds;
        c_MSG_PLANT_PLANT.flowerId = (uint)flowerSeedId;
        SendCmd((int)MessageCode.C_MSG_PLANT_PLANT, c_MSG_PLANT_PLANT);
    }

    private void ResPlantLand(S_MSG_PLANT_PLANT data)
    {
        if (data.plantList.Count <= 0)
        {
            return;
        }
        var land = SceneManager.Instance.GetLand((int)data.plantList[data.plantList.Count - 1].decorId);
        if (land != null)
        {
            SceneManager.Instance.PlayHeroPlantAni(land, "plant");
        }
        foreach (var plant in data.plantList)
        {
            PlantModel.Instance.UpdatePlantVO(plant);
            land = SceneManager.Instance.GetLand((int)plant.decorId);
            if (land != null)
            {
                land.Plant((int)plant.flowerId);
            }
        }

        //if (GuideModel.Instance.IsGuide && GuideModel.Instance.curGuideStep == 19)//引导的是种植
        //{
        //    GuideController.Instance.NextGuide();
        //}
    }


    private bool showWatering = false;
    /// <summary>
    /// 先判断水够不够 不够先提示下
    /// </summary>
    /// <param name="landId"></param>
    public void ReqWater(uint[] landIds, bool showWatering = true, bool checkWater = true)
    {
        if (checkWater && MyselfModel.Instance.WaterCur < landIds.Length)//水不足
        {
            ADK.UILogicUtils.ShowNotice(Lang.GetValue("SucculentPlant_tips1"));
            return;
        }
        this.showWatering = showWatering;
        C_MSG_PLANT_WATER c_MSG_PLANT_WATER = new C_MSG_PLANT_WATER();
        c_MSG_PLANT_WATER.decorIds = landIds;
        SendCmd((int)MessageCode.C_MSG_PLANT_WATER, c_MSG_PLANT_WATER);
    }

    private void ResWater(S_MSG_PLANT_WATER data)
    {
        if (data.plantList.Count <= 0)
        {
            return;
        }
        var land = SceneManager.Instance.GetLand((int)data.plantList[data.plantList.Count - 1].decorId);
        if (land != null && showWatering)
        {
            SceneManager.Instance.PlayHeroPlantAni(land, "watering");
        }
        foreach (var plant in data.plantList)
        {
            PlantModel.Instance.UpdatePlantVO(plant);
            if (showWatering)
            {
                land = SceneManager.Instance.GetLand((int)plant.decorId);
                if (land != null)
                {
                    land.Water();
                }
            }
        }
        showWatering = false;
        //if (GuideModel.Instance.IsGuide && GuideModel.Instance.curGuideStep == 23)//引导的是种植
        //{
        //    GuideController.Instance.NextGuide();
        //}
    }

    public void ReqHarvest(uint[] landIds)
    {
        if (landIds == null || landIds.Length <= 0) return;
        var land = SceneManager.Instance.GetLand((int)landIds[landIds.Length - 1]);
        if (land != null)
        {
            SceneManager.Instance.PlayHeroPlantAni(land, "explore");
        }
        ADK.Coroutiner.StartCoroutine(DelaySendReqHarvest(landIds));
    }

    /// <summary>
    /// 主角收获动画卡点之后再请求服务器
    /// </summary>
    /// <param name="landIds"></param>
    /// <returns></returns>
    private IEnumerator DelaySendReqHarvest(uint[] landIds)
    {
        yield return new WaitForSeconds(1.2f);
        C_MSG_PLANT_HARVEST c_MSG_PLANT_HARVEST = new C_MSG_PLANT_HARVEST();
        c_MSG_PLANT_HARVEST.decorIds = landIds;
        SendCmd((int)MessageCode.C_MSG_PLANT_HARVEST, c_MSG_PLANT_HARVEST);
    }

    private void ResHarvest(S_MSG_PLANT_HARVEST data)
    {
        PlantModel.Instance.harvestPlantCount = data.plantList.Count;
        foreach (var plant in data.plantList)
        {
            var plantVO = PlantModel.Instance.GetPlantVo(plant.decorId);
            var condition = FlowerHandbookModel.Instance.GetStaticSeedCondition((int)plantVO.flowerId);
            if (plantVO != null && plantVO.flowerId > 0)
            {
                var ft_plant_cropConfig = PlantModel.Instance.GetPlantCropConfigData(condition.LevelMould + "#" + plantVO.level);
                if (ft_plant_cropConfig != null)
                {
                    if (plantVO.level > 0)
                    {
                        ADK.Coroutiner.StartCoroutine(StartFloatProp(plantVO, plant, ft_plant_cropConfig));
                    }
                }
            }

            PlantModel.Instance.UpdatePlantVO(plant);
            var land = SceneManager.Instance.GetLand((int)plant.decorId);
            if (land != null)
            {
                land.UpdatePlantStatu(false);
            }
            else
            {
                Debug.LogError("找不到对应土地：" + plant.decorId);
            }
        }
        //飘除花外的奖励，屏幕中央飘就行了
        DropManager.ShowDrop(ItemModel.Instance.GetDropData(data.items, true), false);
        //进仓库
        StorageModel.Instance.AddToStorage(data.items);
        //检测一次小黑板订单信息
        FlowerOrderController.Instance.ReqOderInfo();
        EventManager.Instance.DispatchEvent(SceneEvent.FlowerHarvest);
        //if (GuideModel.Instance.IsGuide)//引导的是种植
        //{
        //    if (GuideModel.Instance.curGuideStep == 26)
        //    {
        //        if (data.plantList.Count >= 4)//如果收获了4朵花会触发升级获得新花弹框，那么切换下一步
        //        {
        //            GuideController.Instance.NextGuide();
        //        }
        //        else//不够升级弹出获得新花弹框，直接跳到28
        //        {
        //            GuideController.Instance.GuideStep(28);
        //        }
        //    }
        //}
    }

    /// <summary>
    /// 飘道具
    /// </summary>
    /// <returns></returns>
    private IEnumerator StartFloatProp(PlantVO plantVO, I_PLANT_VO plant, Elida.Config.Ft_hua_levelConfig ft_plant_cropConfig)
    {
        var level = plantVO.level;
        var itemId = plantVO.flowerId;
        //飘经验
        var exp = ft_plant_cropConfig.Experience;
        var curLand = SceneManager.Instance.GetLand((int)plant.decorId);
        Vector2 pt = ADK.UILogicUtils.TransformPos(curLand.transform.position);
        //DropManager.ShowDropItem((int)ADK.BaseType.EXP, exp, false, pt - new Vector2(10,0));
        yield return null;
        //飘收获的花

        var cropCount = ft_plant_cropConfig.CropCount;
        DropManager.ShowDropItem((int)itemId, cropCount, false, pt + new Vector2(10, 0));

    }

    //种植加速(加速券加速)
    public void ReqPlantSpeed(uint[] landIds)
    {
        C_MSG_PLANT_SPEED c_MSG_PLANT_SPEED = new C_MSG_PLANT_SPEED();
        c_MSG_PLANT_SPEED.decorIds = landIds;
        SendCmd((int)MessageCode.C_MSG_PLANT_SPEED, c_MSG_PLANT_SPEED);
    }

    private void ResPlantSpeed(S_MSG_PLANT_SPEED s_MSG_PLANT_SPEED)
    {
        foreach (var plant in s_MSG_PLANT_SPEED.plantList)
        {
            PlantModel.Instance.UpdatePlantVO(plant);
            var land = SceneManager.Instance.GetLand((int)plant.decorId);
            if (land != null)
            {
                land.UpdatePlantStatu();
            }
        }
    }

    public void ReqPlantMove(uint[] landIds)
    {
        C_MSG_PLANT_MOVE c_MSG_PLANT_MOVE = new C_MSG_PLANT_MOVE();
        c_MSG_PLANT_MOVE.decorIds = landIds;
        SendCmd((int)MessageCode.C_MSG_PLANT_MOVE, c_MSG_PLANT_MOVE);
    }

    private void ResPlantMove(S_MSG_PLANT_MOVE s_MSG_PLANT_MOVE)
    {
        foreach (var plant in s_MSG_PLANT_MOVE.plantList)
        {
            PlantModel.Instance.UpdatePlantVO(plant);
            var land = SceneManager.Instance.GetLand((int)plant.decorId);
            if (land != null)
            {
                land.UpdatePlantStatu();
            }
        }
    }

    /// <summary>
    /// 成熟时间小于1分钟免费加速
    /// </summary>
    /// <param name="landIds"></param>
    public void ReqPlantFreeSpeedUp(uint[] landIds)
    {
        C_MSG_PLANT_FREE_SPEEDUP c_MSG_PLANT_FREE_SPEEDUP = new C_MSG_PLANT_FREE_SPEEDUP();
        c_MSG_PLANT_FREE_SPEEDUP.decorIds = landIds;
        SendCmd((int)MessageCode.C_MSG_PLANT_FREE_SPEEDUP, c_MSG_PLANT_FREE_SPEEDUP);
    }

    private void ResPlantFreeSpeedUp(S_MSG_PLANT_FREE_SPEEDUP s_MSG_PLANT_FREE_SPEEDUP)
    {
        foreach (var plant in s_MSG_PLANT_FREE_SPEEDUP.plantList)
        {
            PlantModel.Instance.UpdatePlantVO(plant);
            var land = SceneManager.Instance.GetLand((int)plant.decorId);
            if (land != null)
            {
                land.UpdatePlantStatu();
            }
        }
    }

    /// <summary>
    /// 切换种植动画
    /// </summary>
    public void UpdatePlantAni()
    {
        var list = PlantModel.Instance.GetPlantedLands();
        foreach (var vo in list)
        {
            var land = SceneManager.Instance.GetLand((int)vo.landId);
            if (land != null)
            {
                land.UpdatePlantStatu(false, true);
            }
        }
    }
    //一键偷花
    public void BatchSteal(S_MSG_FRIEND_BATCH_STEAL data)
    {
        MyselfModel.Instance.interactionCnt = data.interactionCnt;
        foreach(var value in data.decorIds)
        {
            var plantVo = VisitFriendModel.Instance.GetPlantVo(value);
            if(plantVo != null)
            {
                plantVo.stealInfo.Add(MyselfModel.Instance.userId, 1);
                var land = SceneManager.Instance.GetLand((int)value);
                if (land != null)
                {
                    land.UpdateFriendSteal();
                }
            }
        }
        
        var dropList = ItemModel.Instance.GetDropData(data.items);
        DropManager.ShowDrop(dropList);
        if (MyselfModel.Instance.interactionCnt >= GlobalModel.Instance.module_profileConfig.umberOfMutualaid)
        {
            SceneManager.Instance.HideAllLandSteal();
        }
        EventManager.Instance.DispatchEvent(FriendEvent.FriendSteal);
    }

    public void ReqBatchSteal(uint friendId)
    {
        var decorIds = new List<uint>();
        var count = MyselfModel.Instance.interactionCnt;
        for (var i = 1;i < 61;i++)
        {
            var land = SceneManager.Instance.GetLand(i);
          
            if (land.CheckStealEnable())
            {
                count++;
                decorIds.Add((uint)i);
            }
            if(count >= GlobalModel.Instance.module_profileConfig.umberOfMutualaid)
            {
                break;
            }
        }
        if(decorIds.Count > 0)
        {
            C_MSG_FRIEND_BATCH_STEAL c_MSG_FRIEND_BATCH_STEAL = new C_MSG_FRIEND_BATCH_STEAL();
            c_MSG_FRIEND_BATCH_STEAL.friendId = friendId;
            c_MSG_FRIEND_BATCH_STEAL.decorIds = decorIds.ToArray();
            SendCmd((int)MessageCode.C_MSG_FRIEND_BATCH_STEAL, c_MSG_FRIEND_BATCH_STEAL);
        }
        
    }
}

