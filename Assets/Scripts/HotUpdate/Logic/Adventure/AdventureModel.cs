using Elida.Config;
using protobuf.adventure;
using System.Collections.Generic;

public class MapConfigData
{
    public TransformVector2 mapSize;
    public List<TransformVector4> unWalkGridPosList;
    public List<ObstacleData> obstacleDatas;
    public List<FogData> fogDatas;
}

public class AdventureModel : Singleton<AdventureModel>
{
    private Dictionary<int, Obstacle> obstacleDic = new Dictionary<int, Obstacle>();
    private List<protobuf.item.I_ITEM_VO> _crystalnItemList;//玲珑球可领取的道具
    public Obstacle curObstacle;

    public List<I_ADVENTURE_ISLAND_VO> adventureIsland;//探险花屿
    public I_ADVENTURE_TOUR_VO adventureTour;//探险巡游
    public List<uint> events;//事件
    public int curMapId;



    private List<Ft_island_configConfig> _isLandList;
    public List<Ft_island_configConfig> isLandList
    {
        get
        {
            if (_isLandList == null)
            {
                var isLandData = ConfigManager.Instance.GetConfig<Ft_island_configConfigData>("ft_island_configsConfig");
                _isLandList = isLandData.DataList;
            }
            return _isLandList;
        }
    }
    //public void InitData(List<protobuf.item.I_ITEM_VO> crystalnItems, List<protobuf.adventure.I_ADVENTURE_GRID_VO> adventureGrids)
    //{
    //    _crystalnItemList = crystalnItems;
    //    gridDic = new Dictionary<int, bool>();
    //    foreach (var adventureGrid in adventureGrids)
    //    {
    //        gridDic.Add((int)adventureGrid.gridId, adventureGrid.unlock);
    //    }
    //}

    public List<protobuf.item.I_ITEM_VO> crystalnItemList
    {
        get { return _crystalnItemList; }
    }

    public void AddCrystalnItem(Dictionary<ulong, ulong> crystalnItems)
    {
        if (crystalnItems.Count > 0)
        {
            foreach (var crystalnItem in crystalnItems)
            {
                bool isExsit = false;
                foreach (var crystaItem in _crystalnItemList)
                {
                    if (crystaItem.itemDefId == (uint)crystalnItem.Key)
                    {
                        isExsit = true;
                        crystaItem.count += (uint)crystalnItem.Value;//存在则改变已有数量
                        break;
                    }
                }
                if (!isExsit)//不存在则创建对象
                {
                    protobuf.item.I_ITEM_VO item = new protobuf.item.I_ITEM_VO();
                    item.itemDefId = (uint)crystalnItem.Key;
                    item.count = (uint)crystalnItem.Value;
                    _crystalnItemList.Add(item);
                }
            }
            EventManager.Instance.DispatchEvent(AdventureEvent.UpdateCrystalnItem);
        }
    }
    public void ClearCrystalnItemList()
    {
        _crystalnItemList.Clear();
    }

    /// <summary>
    /// 某个格子是否解锁
    /// </summary>
    /// <param name="gridId"></param>
    /// <returns></returns>
    public bool GetGridIsUnLock(int gridId)
    {
        var gridConfig = GetGridConfig(gridId);
        if (gridConfig != null)
        {
            var mapData = GetIslandData((uint)gridConfig.MapId);
            if (mapData != null)
            {
                var clearObjectIds = mapData.clearObjectIds;
                if (clearObjectIds == null)
                {
                    return false;
                }
                return System.Array.Exists(clearObjectIds, id => id == gridId);
            }
        }
        return false;
    }

    /// <summary>
    /// 每次重建格子都先清空
    /// </summary>
    public void ClearObstacleDic()
    {
        obstacleDic.Clear();
    }

    public void AddObstacle(Obstacle obstacle)
    {
        obstacleDic.Add(obstacle.gridId, obstacle);
    }

    public Obstacle GetObstacle(int gridId)
    {
        if (obstacleDic.TryGetValue(gridId, out Obstacle obstacle))
        {
            return obstacle;
        }
        return null;
    }

    public Ft_island_objectConfig GetGridConfig(int id)
    {
        var ft_adventure_gridConfigData = ConfigManager.Instance.GetConfig<Ft_island_objectConfigData>("ft_island_objectsConfig");
        return ft_adventure_gridConfigData.DataMap[id];
    }

    public int GetTotalObject(int mapId)
    {

        var ft_adventure_gridConfigData = ConfigManager.Instance.GetConfig<Ft_island_objectConfigData>("ft_island_objectsConfig");
        var objectList = new List<Ft_island_objectConfig>();
        foreach (var value in ft_adventure_gridConfigData.DataMap)
        {
            if (value.Value.MapId == mapId)
            {
                objectList.Add(value.Value);
            }
        }
        return objectList.Count;
    }

    /// <summary>
    /// 花屿关卡表
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Ft_island_stageConfig GetIslandStageConfig(int id)
    {
        var ft_island_stageConfigData = ConfigManager.Instance.GetConfig<Ft_island_stageConfigData>("ft_island_stagesConfig");
        return ft_island_stageConfigData.DataMap[id];
    }

    public Ft_enemy_configConfig GetEnemyConfig(int id)
    {
        var ft_enemyConfigData = ConfigManager.Instance.GetConfig<Ft_enemy_configConfigData>("ft_enemy_configsConfig");
        return ft_enemyConfigData.DataMap[id];
    }

    public Ft_enemy_attConfig GetEnemyAtt(int id)
    {
        var ft_enemy_attConfigData = ConfigManager.Instance.GetConfig<Ft_enemy_attConfigData>("ft_enemy_attsConfig");
        return ft_enemy_attConfigData.DataMap[id];
    }

    public List<Ft_island_configConfig> GetLandFromType(int type)
    {
        return isLandList.FindAll(value => value.Type == type);
    }

    public Ft_island_configConfig GetLandFromId(int id)
    {
        return isLandList.Find(value => value.Id == id);
    }

    public I_ADVENTURE_ISLAND_VO GetIslandData(uint id)
    {
        return adventureIsland.Find(value => value.mapId == id);
    }

    public void UpdateIslandData(I_ADVENTURE_ISLAND_VO islandData)
    {
        int index = adventureIsland.FindIndex(value => value.mapId == islandData.mapId);
        if (index != -1)
        {
            adventureIsland[index] = islandData;
        }
        else
        {
            adventureIsland.Add(islandData);
        }
    }

    public void ClearObstacleUdpdateData(S_MSG_ADVENTURE_CLEAR_OBSTACLE data)
    {
        adventureTour = data.adventureTour;//探险巡游
        UpdateIslandData(data.adventureIsland);//花屿
    }


    public List<StorageItemVO> GetPackReward(uint mapId)
    {
        var mapData = GetIslandData(mapId);
        var packMap = new Dictionary<int, StorageItemVO>();
        var packList = new List<StorageItemVO>();
        if (mapData != null && mapData.clearObjectIds != null)
        {
            foreach (var value in mapData.clearObjectIds)
            {
                var objectInfo = GetGridConfig((int)value);
                if (objectInfo.ObjectType == 4)
                {
                    var monstrInfo = GetIslandStageConfig(int.Parse(objectInfo.ClearReward));
                    foreach (var item in monstrInfo.StageRewards)
                    {
                        var pack = new StorageItemVO();
                        var itemVo = ItemModel.Instance.GetItemByEntityID(item.EntityID);
                        pack.item = itemVo;
                        pack.count = item.Value;
                        pack.itemDefId = itemVo.ItemDefId;
                        if (packMap.ContainsKey(pack.itemDefId))
                        {
                            packMap[pack.itemDefId].count += pack.count;
                        }
                        else
                        {
                            packMap.Add(pack.itemDefId, pack);
                        }
                    }
                }
                else
                {
                    var arr = objectInfo.ClearReward.Split(",");
                    foreach (var item in arr)
                    {
                        var itemArr = item.Split(":");
                        var pack = new StorageItemVO();
                        var itemVo = ItemModel.Instance.GetItemByEntityID(itemArr[0]);
                        pack.item = itemVo;
                        pack.count = int.Parse(itemArr[1]);
                        pack.itemDefId = itemVo.ItemDefId;
                        //packList.Add(pack);
                        if (packMap.ContainsKey(pack.itemDefId))
                        {
                            packMap[pack.itemDefId].count += pack.count;
                        }
                        else
                        {
                            packMap.Add(pack.itemDefId, pack);
                        }
                    }
                }
            }

        }
        foreach(var value in packMap)
        {
            packList.Add(value.Value);
        }
        return packList;
    }
}
