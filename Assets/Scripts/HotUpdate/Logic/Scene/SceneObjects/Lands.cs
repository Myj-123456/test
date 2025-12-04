using ADK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YooAsset;

/// <summary>
///地块
/// </summary>
public class Lands
{
    private int startLandId = 0;
    private Dictionary<int, Land> LandDic = new Dictionary<int, Land>();
    private uint[] unLockLandIdMap = new uint[60]//土地解锁顺序映射新的
    {
        1, 2, 3, 16, 17, 18,
        4, 5, 6, 19, 20, 21,
        7, 8, 9, 22, 23, 24,
        10, 11, 12, 25, 26, 27,
        13, 14, 15, 28, 29, 30,
        31, 32, 33, 46, 47, 48,
        34, 35, 36, 49, 50, 51,
        37, 38, 39, 52, 53, 54,
        40, 41, 42, 55, 56, 57,
        43, 44, 45, 58, 59, 60
    };
    public void InitLands(Transform LandArea1, Transform LandArea2, Transform LandArea3, Transform LandArea4)
    {
        startLandId = 0;
        AddAreaLand(LandArea1);
        AddAreaLand(LandArea2);
        AddAreaLand(LandArea3);
        AddAreaLand(LandArea4);
    }



    /// <summary>
    /// 添加一个区域土地
    /// </summary>
    /// <param name="structureData"></param>
    private void AddAreaLand(Transform transform)
    {
        var gadRatio = 1f;//间隔比率
        var lineGadRatio = 0.3f;//行间隔比率(控制行间隔)
        var halfLandWidth = 0.7f;
        halfLandWidth += halfLandWidth * gadRatio;
        var halfLandHeight = 0.395f;
        halfLandHeight += halfLandHeight * gadRatio;
        float waitCreateTime = 0f;
        var row = 5;
        var col = 3;
        var offX = 0f;
        var offY = 0f;
        const float waitCreateTimeGap = 0.033f;//大概一帧一个

        for (var i = 0; i < row; i++)//先排列再排行
        {
            for (var j = 0; j < col; j++)
            {
                waitCreateTime = waitCreateTimeGap * startLandId;
                startLandId += 1;

                //下面是为了适配新地图做的偏移
                if (i * col + j < 6)//前6个
                {
                    offX = 0.78f;
                    offY = 0.61f;
                }
                else//后9个
                {
                    offX = -0.48f;
                    offY = -0.282f;
                }
                Vector3 pos = new Vector3(j * halfLandWidth - i * halfLandWidth - (i * lineGadRatio * halfLandWidth) + offX, -i * halfLandHeight - j * halfLandHeight - (i * lineGadRatio * halfLandHeight) + offY);
                //Coroutiner.StartCoroutine(AddLand(startLandId, pos, transform, waitCreateTime));
                AddLand(startLandId, pos, transform);
            }
        }
    }

    private void AddLand(int landId, Vector3 pos, Transform landAreaTransform)
    {
        Land land = GetLand(landId);
        if (land != null)
        {
            PlantVO plantVO = null;
            if (MyselfModel.Instance.atHome)
            {
                plantVO = PlantModel.Instance.GetPlantVo((uint)landId);
            }
            else
            {
                plantVO = VisitFriendModel.Instance.GetPlantVo((uint)landId);
            }
            land.UpdateSkin(landId, plantVO);
            return;
        }
        //yield return new WaitForSeconds(waitCreateTime);
        var assetHandle = ResourceManager.Instance.LoadAssetAsync<GameObject>(ResPath.GetPrefabPath("Land/Land"));
        assetHandle.Completed += (AssetHandle assetHandle) =>
        {
            var landGameObject = assetHandle.InstantiateSync();
            Land land = landGameObject.GetComponent<Land>();
            if (land != null)
            {
                PlantVO plantVO = null;
                if (MyselfModel.Instance.atHome)
                {
                    plantVO = PlantModel.Instance.GetPlantVo((uint)landId);
                }
                else
                {
                    plantVO = VisitFriendModel.Instance.GetPlantVo((uint)landId);
                }
                land.UpdateSkin(landId, plantVO);
            }
            landGameObject.transform.SetParent(landAreaTransform, false);
            landGameObject.transform.localPosition = pos;
            LandDic.Add(landId, land);
            SceneManager.Instance.AddSceneObject(land);
        };
    }


    public Land GetLand(int landId)
    {
        if (LandDic.TryGetValue(landId, out Land value))
        {
            return value;
        }
        return null;
    }

    public void HideAllLandSteal()
    {
        foreach (var k in LandDic)
        {
            k.Value.HideStealBubble();
        }
    }

    /// <summary>
    /// 获取可收获的土地id列表
    /// </summary>
    /// <returns></returns>
    public List<uint> GetHarvestLandIds()
    {
        var landIds = new List<uint>();
        foreach (KeyValuePair<int, Land> keyValuePair in LandDic)
        {
            if (keyValuePair.Value.plantVO != null && keyValuePair.Value.plantVO.plantState == PlantState.State_2)
            {
                landIds.Add((uint)keyValuePair.Value.plantVO.landId);
            }
        }
        return landIds;
    }

    /// <summary>
    /// 获取一个已解锁空土地
    /// </summary>
    /// <returns></returns>
    public Land GetUnLockEmptyLand()
    {
        foreach (var land in LandDic)
        {
            if (land.Value.plantVO != null && land.Value.plantVO.flowerId <= 0)//已解锁未种植
            {
                return land.Value;
            }
        }
        return GetLand(1);
    }

    /// <summary>
    /// 获取一个已经种植指定花的土地
    /// </summary>
    /// <param name="flowerId"></param>
    /// <returns></returns>
    public Land GetPlantLandByFlowerId(int flowerId)
    {
        foreach (var land in LandDic)
        {
            if (land.Value.plantVO != null && land.Value.plantVO.flowerId == flowerId)
            {
                return land.Value;
            }
        }
        return null;
    }

    /// <summary>
    /// 获取一个已经种植的土地
    /// </summary>
    /// <param name="flowerId"></param>
    /// <returns></returns>
    public Land GetPlantLand()
    {
        foreach (var land in LandDic)
        {
            if (land.Value.plantVO != null && land.Value.plantVO.flowerId > 0)
            {
                return land.Value;
            }
        }
        return null;
    }

    /// <summary>
    /// 获取可以浇水的土地
    /// </summary>
    /// <returns></returns>
    public Land GetWaterLand()
    {
        var land = GetPlantLand();
        if (land != null) return land;
        return GetUnLockEmptyLand();
    }

    /// <summary>
    /// 获取可以收获的土地
    /// </summary>
    /// <returns></returns>
    public Land GetHarvestLand()
    {
        foreach (KeyValuePair<int, Land> keyValuePair in LandDic)
        {
            if (keyValuePair.Value.plantVO != null && keyValuePair.Value.plantVO.plantState == PlantState.State_2)
            {
                return keyValuePair.Value;
            }
        }
        return null;
    }

    /// <summary>
    /// 根据花id优先获取一个已经种植的土地
    /// 没有获取一个空土地
    /// 最后默认
    /// </summary>
    /// <param name="flowerId"></param>
    /// <returns></returns>
    public Land GetUnLockEmptyLandByFlowerId(int flowerId)
    {
        Land land = null;
        if (flowerId > 0)//获取一个指定已种植的土地
        {
            land = GetPlantLandByFlowerId(flowerId);
            if (land != null) return land;
        }
        return GetWaterLand();//已经种植的土地，没有获取一块空土地
    }

    /// <summary>
    /// 获取一个未解锁的土地
    /// </summary>
    /// <returns></returns>
    public Land GetLockLand()
    {
        foreach (var landId in unLockLandIdMap)
        {
            var land = GetLand((int)landId);
            if (land != null && land.plantVO == null)//未解锁
            {
                return land;
            }
        }
        return null;
    }
}
