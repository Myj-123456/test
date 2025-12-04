
using Elida.Config;
using System;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// 种植数据 自己封装一层 方便拓展
/// </summary>
public class PlantVO
{
    public uint landId;//地块id
    public uint flowerId;//花id
    public uint harvestTime;//成熟时间，没有浇水时为0
    public uint status;//0：未浇水 大于0的值，表示已收获次数
    public uint harvestCount;//表示成熟后可以收获的花数量
    public uint level;//花的种子等级
    public uint surplus;//能收获次数
    public PlantState plantState = PlantState.State_null;//种植状态 -1未种植 0 幼苗种子期(未初灌) 1成长期  2成熟期可收获

    public Dictionary<uint, uint> stealInfo;//偷花信息


    /// <summary>
    /// 更新数据
    /// </summary>
    /// <param name="iplantVo"></param>
    public void UpdateData(protobuf.plant.I_PLANT_STEAL_VO iplantVo)
    {
        landId = iplantVo.decorId;
        flowerId = iplantVo.flowerId;
        harvestTime = iplantVo.harvestTime;
        status = iplantVo.status;
        harvestCount = iplantVo.harvestCount;
        level = iplantVo.level;
        stealInfo = iplantVo.stealInfo;
        if (flowerId > 0 && status > 0)//已种植并且已初灌
        {
            surplus = PlantModel.Instance.GetHavestTimes(flowerId, level) + 1 - status;//lv+2-(data as PlantData).status;//还可以收割的次数
            Debug.Log("可以收获次数:" + surplus);
        }
    }

    public void UpdateData(protobuf.plant.I_PLANT_VO iplantVo)
    {
        landId = iplantVo.decorId;
        flowerId = iplantVo.flowerId;
        harvestTime = iplantVo.harvestTime;
        status = iplantVo.status;
        harvestCount = iplantVo.harvestCount;
        level = iplantVo.level;
        if (flowerId > 0 && status > 0)//已种植并且已初灌
        {
            Debug.Log("status:" + status);
            Debug.Log("HavestTimes:" + PlantModel.Instance.GetHavestTimes(flowerId, level));
            surplus = PlantModel.Instance.GetHavestTimes(flowerId, level) + 1 - status;//lv+2-(data as PlantData).status;//还可以收割的次数
            Debug.Log("可以收获次数:" + surplus);
        }
    }
}


/// <summary>
/// 种植控制器
/// </summary>
public class PlantModel : Singleton<PlantModel>
{
    public int dragFlowerId = 0;//拖拽花id(为0表示没有拖拽花id)
    public List<uint> dragPlantLandIds = new List<uint>();//拖拽需要种植的花种子id列表
    public List<uint> dragHarvestLandIds = new List<uint>();//拖拽需要收获的花id列表
    public List<uint> dragWateingLandIds = new List<uint>();//拖拽需要浇水的土地id列表
    public static float GROWTH_SCALE = 1.6f;

    private Ft_hua_levelConfigData plant_CropConfigData;
    //private Ft_plant_parameterConfigData plant_ParameterConfigData;
    private Ft_tudiConfigData landConfigData;
    private Dictionary<uint, PlantVO> plantDic;//只有已解锁的土地信息才在这个列表

    //public Ft_plant_parameterConfigData parameterConfigData;
    public bool isShowPlantUI = false;//主界面是否显示种植ui
    public PlantVO plantVO;//当前土地数据
    public int harvestPlantCount = 0;//收获数量

    public int unlockLand
    {
        get
        {
            if (plantDic != null)
            {
                return plantDic.Count;
            }
            return 0;
        }
    }
    /// <summary>
    /// 初始化土地信息
    /// </summary>
    public void InitPlantList(List<protobuf.plant.I_PLANT_VO> plantList)
    {
        plantDic = new Dictionary<uint, PlantVO>();
        landConfigData = ConfigManager.Instance.GetConfig<Ft_tudiConfigData>("ft_tudisConfig");
        foreach (var plantVo in plantList)
        {
            AddPlantVO(plantVo);
        }
    }

    public PlantVO AddPlantVO(protobuf.plant.I_PLANT_VO iplantVo)
    {
        var plantVo = new PlantVO();
        plantVo.UpdateData(iplantVo);
        plantDic.Add(plantVo.landId, plantVo);
        return plantVo;
    }

    public void UpdatePlantVO(protobuf.plant.I_PLANT_VO iplantVo)
    {
        var plantVO = GetPlantVo(iplantVo.decorId);
        if (plantVO != null)
        {
            plantVO.UpdateData(iplantVo);
        }
    }

    /// <summary>
    /// 获取一个种植数据
    /// </summary>
    /// <param name="landId"></param>
    /// <returns></returns>
    public PlantVO GetPlantVo(uint landId)
    {
        if (plantDic.TryGetValue(landId, out PlantVO plantVO))
        {
            return plantVO;
        }
        return null;
    }


    /// <summary>
    /// 获取所有已种植的土地数据
    /// </summary>
    /// <returns></returns>
    public List<PlantVO> GetPlantedLands()
    {
        List<PlantVO> list = new List<PlantVO>();
        foreach (var plant in plantDic)
        {
            if (plant.Value.flowerId > 0)
            {
                list.Add(plant.Value);
            }
        }
        return list;
    }

    /// <summary>
    /// 获取已种植的土地id列表
    /// </summary>
    /// <returns></returns>
    public List<uint> GetPlantedLandIds()
    {
        List<uint> lands = new List<uint>();
        foreach (var plant in plantDic)
        {
            if (plant.Value.flowerId > 0)
            {
                lands.Add(plant.Value.landId);
            }
        }
        return lands;
    }

    /// <summary>
    /// 获取一个土地配置
    /// </summary>
    /// <param name="landId"></param>
    /// <returns></returns>
    public Ft_tudiConfig GetTudiConfig(int landId)
    {
        if (landConfigData != null)
        {
            if (landConfigData.DataMap.TryGetValue(landId, out Ft_tudiConfig tudi_ConfigConfig))
            {
                return tudi_ConfigConfig;
            }
            return null;
        }
        return null;
    }

    /// <summary>
    /// 获取一个种植生产配置
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Ft_hua_levelConfig GetPlantCropConfigData(string id)
    {
        if (plant_CropConfigData == null) plant_CropConfigData = ConfigManager.Instance.GetConfig<Ft_hua_levelConfigData>("ft_hua_levelsConfig");
        return plant_CropConfigData.Get(id);
    }

    public List<Ft_hua_levelConfig> GetPlantCropConfigList(int mouldId)
    {
        if (plant_CropConfigData == null) plant_CropConfigData = ConfigManager.Instance.GetConfig<Ft_hua_levelConfigData>("ft_hua_levelsConfig");

        return plant_CropConfigData.DataList.FindAll(value => value.MouldId == mouldId);
    }

    //判断是否是最高等级
    public bool GetPlantCropMax(string id)
    {
        if (plant_CropConfigData == null) plant_CropConfigData = ConfigManager.Instance.GetConfig<Ft_hua_levelConfigData>("ft_hua_levelsConfig");
        var plantCrop = plant_CropConfigData.Get(id);
        return plantCrop == null;
    }

    //public Ft_plant_parameterConfig GetPlantCropParameterData(int id)
    //{
    //    if (parameterConfigData == null) parameterConfigData = ConfigManager.Instance.GetConfig<Ft_plant_parameterConfigData>("ft_plant_parametersConfig");
    //    return parameterConfigData.Get(id);
    //}

    public int GetStealCount(int id, int lv)
    {

        return 1;
    }

    public int GetPlantBaodi(int id, int lv)
    {
        var cropConfig = GetPlantCropConfigData(id + "#" + lv);
        if (cropConfig == null) return 0;
        var count = cropConfig.Baodi;
        return count;
    }

    /// <summary>
    /// 获取收获次数
    /// </summary>
    /// <param name="flowerId">花id</param>
    /// <param name="level">花等级</param>
    /// <returns></returns>
    public uint GetHavestTimes(uint flowerId, uint level)
    {
        var condition = FlowerHandbookModel.Instance.GetStaticSeedCondition((int)flowerId);
        var plant_cropConfig = GetPlantCropConfigData(condition.LevelMould + "#" + level);
        if (plant_cropConfig != null)
        {

            return (uint)plant_cropConfig.Frequency;

        }
        return 0;
    }

    /// <summary>
    /// 获取收获时间低于1分钟的花
    /// </summary>
    public List<uint> GetHarvestTimeLowerOneMinutePlants()
    {
        List<uint> lands = new List<uint>();
        foreach (var plant in plantDic)
        {
            if (plant.Value.flowerId > 0 && (plant.Value.harvestTime > 0 && plant.Value.harvestTime - ServerTime.Time <= 60))
            {
                lands.Add(plant.Value.landId);
            }
        }
        return lands;
    }

    /// <summary>
    /// 获取生长中的花
    /// </summary>
    public List<uint> GetHarvestGrowUpPlants()
    {
        List<uint> lands = new List<uint>();
        foreach (var plant in plantDic)
        {
            if (plant.Value.flowerId > 0 && (plant.Value.harvestTime > 0 && plant.Value.harvestTime > ServerTime.Time))
            {
                lands.Add(plant.Value.landId);
            }
        }
        return lands;
    }

    /// <summary>
    /// 获取可种植的土地
    /// </summary>
    /// <returns></returns>
    public List<uint> GetCanPlantLands()
    {
        List<uint> lands = new List<uint>();
        foreach (var plant in plantDic)
        {
            if (plant.Value.flowerId <= 0)
            {
                lands.Add(plant.Value.landId);
            }
        }
        return lands;
    }

    /// <summary>
    /// 获取可灌溉的土地
    /// </summary>
    /// <returns></returns>
    public List<uint> GetUnWateringLands()
    {
        List<uint> lands = new List<uint>();
        foreach (var plant in plantDic)
        {
            if (plant.Value.flowerId > 0 && plant.Value.status <= 0)
            {
                lands.Add(plant.Value.landId);
            }
        }
        return lands;
    }
}

