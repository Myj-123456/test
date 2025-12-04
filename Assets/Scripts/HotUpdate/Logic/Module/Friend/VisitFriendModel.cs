
using Elida.Config;
using protobuf.floristshop;
using protobuf.table;
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 访问好友存储的数据
/// </summary>
public class VisitFriendModel : Singleton<VisitFriendModel>
{
    public int dragFlowerId = 0;//拖拽花id(为0表示没有拖拽花id)
    public List<uint> dragPlantLandIds = new List<uint>();//拖拽需要种植的花种子id列表
    public List<uint> dragHarvestLandIds = new List<uint>();//拖拽需要收获的花id列表
    public static float GROWTH_SCALE = 1.6f;
    private Dictionary<uint, PlantVO> plantDic;//只有已解锁的土地信息才在这个列表

    public bool isShowPlantUI = false;//主界面是否显示种植ui
    public PlantVO plantVO;//当前土地数据

    private Dictionary<int, DressData> serverWearDic;//后端穿戴列表
    public Dictionary<int, Dictionary<int, FurnitureData>> furnitureDataDic = new Dictionary<int, Dictionary<int, FurnitureData>>();//外层key=>type 内层value=>id

    /// <summary>
    /// 初始化土地信息
    /// </summary>
    public void InitPlantList(List<protobuf.plant.I_PLANT_STEAL_VO> plantList)
    {
        plantDic = new Dictionary<uint, PlantVO>();
        foreach (var plantVo in plantList)
        {
            AddPlantVO(plantVo);
        }
    }

    public PlantVO AddPlantVO(protobuf.plant.I_PLANT_STEAL_VO iplantVo)
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


    private Dictionary<uint, TableVo> tableDic;

    public void InitTables(List<I_TABLE_VO> tableList)
    {
        tableDic = new Dictionary<uint, TableVo>();
        foreach (var table in tableList)
        {
            TableVo tableVo = new TableVo();
            tableVo.ParseData(table);
            tableDic.Add(tableVo.deskId, tableVo);
        }
    }

    public TableVo GetTableVo(uint tableId)
    {
        if (tableDic.TryGetValue(tableId, out TableVo flowerStandData))
        {
            return flowerStandData;
        }
        return null;
    }

    public TableVo UpdateTable(I_TABLE_VO i_TABLE_VO)
    {
        var tableVo = GetTableVo(i_TABLE_VO.gridId);
        if (tableVo != null)
        {
            tableVo.ParseData(i_TABLE_VO);
        }
        else
        {
            tableVo = new TableVo();
            tableVo.ParseData(i_TABLE_VO);
            tableDic.Add(i_TABLE_VO.gridId, tableVo);
        }
        return tableVo;
    }

    /// <summary>
    /// 更新换装穿戴列表
    /// </summary>
    /// <param name="dressList"></param>
    public void UpdateDressData(uint[] dressList)
    {
        serverWearDic = new Dictionary<int, DressData>();
        foreach (var dressId in dressList)
        {
            var dressData = new DressData();
            dressData.clothesId = (int)dressId;
            var ft_dress_config = DressModel.Instance.GetDressConfig(dressData.clothesId);
            if (ft_dress_config != null)
            {
                dressData.ft_Dress_Config = ft_dress_config;
                serverWearDic.Add(dressData.ft_Dress_Config.Type, dressData);
            }
        }
    }

    /// <summary>
    /// 获取该部位穿戴的id 0表示没穿戴
    /// </summary>
    /// <param name="part"></param>
    /// <returns></returns>
    public int GetWearPartId(int part)
    {
        if (serverWearDic.TryGetValue(part, out DressData dressData))
        {
            return dressData.clothesId;
        }
        return 0;
    }


    public void InitFloristShop(I_FLORIST_SHOP_VO floristShop)
    {
        InitDecorations(floristShop.decoration);
    }

    public void InitDecorations(List<I_FURNITURE_VO> decoration)
    {
        furnitureDataDic.Clear();
        foreach (var furniture in decoration)
        {
            var decoraFurnitureConfig = GetFurniture((int)furniture.itemId);
            if (decoraFurnitureConfig != null)
            {
                FurnitureData furnitureData = new FurnitureData();
                furnitureData.id = (int)furniture.itemId;
                furnitureData.floor = furniture.floor;
                furnitureData.x = furniture.x;
                furnitureData.y = furniture.y;
                AddFurnitureData(decoraFurnitureConfig.Type, furnitureData);
            }
        }
    }
    private Ft_florist_furnitureConfig GetFurniture(int id)
    {
        var furnitureData = ConfigManager.Instance.GetConfig<Ft_florist_furnitureConfigData>("ft_florist_furnituresConfig");
        return furnitureData.DataMap[id];
    }

    /// <summary>
    /// 添加一个使用中家具信息
    /// </summary>
    /// <param name="type"></param>
    /// <param name="furniture"></param>
    private void AddFurnitureData(int type, FurnitureData furnitureData)
    {
        Dictionary<int, FurnitureData> dicIds = null;
        if (!furnitureDataDic.TryGetValue(type, out dicIds))
        {
            dicIds = new Dictionary<int, FurnitureData>();
            furnitureDataDic.Add(type, dicIds);
        }
        dicIds.Add(furnitureData.id, furnitureData);
    }
}

