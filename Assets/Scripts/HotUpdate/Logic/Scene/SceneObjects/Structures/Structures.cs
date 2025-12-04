using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YooAsset;

/// <summary>
///建筑
/// </summary>
public class Structures
{
    private Transform structureLayer;
    private Dictionary<int, Structure> structureDic = new Dictionary<int, Structure>();
    private float waitCreateTime = 0f;
    private const float waitCreateTimeGap = 0.033f;//大概一帧一个
    private int startLandId = 0;

    public void InitStructures(Transform structureLayer)
    {
        this.structureLayer = structureLayer;
        startLandId = 0;
        waitCreateTime = 0;
        AddEvent();
        AddStructure(new StructureData() { buildingDefId = 29000005, pos = new Vector3() { x = -20.8f, y = -10.72f } });//好友
        AddStructure(new StructureData() { buildingDefId = 29000007, pos = new Vector3() { x = 19.56f, y = -9.3f } });//仓库
        AddStructure(new StructureData() { buildingDefId = 29000002, pos = new Vector3() { x = 20.68f, y = 1.83f } });//培育花房
        AddStructure(new StructureData() { buildingDefId = 29000008, pos = new Vector3() { x = 2.81f, y = -1.58f } });//订单小黑板
        AddStructure(new StructureData() { buildingDefId = 29000010, pos = new Vector3() { x = 15.37f, y = 15.11f } });//热气球(寻花建筑)
        AddStructure(new StructureData() { buildingDefId = 29000011, pos = new Vector3() { x = -11.14f, y = 4.58f } });//邮件/消息
        AddStructure(new StructureData() { buildingDefId = 29000012, pos = new Vector3() { x = 10.16f, y = -8.46f } });//小萝莉换花+经验树
        AddStructure(new StructureData() { buildingDefId = 29000013, pos = new Vector3() { x = -22.97f, y = -19.92f } });//船
        AddStructure(new StructureData() { buildingDefId = 29000014, pos = new Vector3() { x = -13.07f, y = 12.35f } });//宠物
        AddStructure(new StructureData() { buildingDefId = 29000015, pos = new Vector3() { x = -19.54f, y = 8.26f } });//公会
        AddStructure(new StructureData() { buildingDefId = 29000016, pos = new Vector3() { x = -12.17f, y = -15.79f } });//水井
        AddStructure(new StructureData() { buildingDefId = 29000017, pos = new Vector3() { x = -24.47f, y = -0.04f } });//钓鱼台
    }
    private void AddEvent()
    {
        EventManager.Instance.AddEventListener(FlowerOrderEvent.ResOrderSubmit, OnResOrderSubmit);
        EventManager.Instance.AddEventListener(FlowerOrderEvent.UpdateFlowerOrderCd, OnResOrderSubmit);
        EventManager.Instance.AddEventListener(PlayerEvent.ChangeWaterBucket, UpdateWaterBucket);
        EventManager.Instance.AddEventListener(PlayerEvent.WaterBucketAward, UpdateWaterBucket);
    }
    private void RemoveEvent()
    {
        EventManager.Instance.RemoveEventListener(FlowerOrderEvent.ResOrderSubmit, OnResOrderSubmit);
        EventManager.Instance.RemoveEventListener(FlowerOrderEvent.UpdateFlowerOrderCd, OnResOrderSubmit);
        EventManager.Instance.RemoveEventListener(PlayerEvent.ChangeWaterBucket, UpdateWaterBucket);
        EventManager.Instance.RemoveEventListener(PlayerEvent.WaterBucketAward, UpdateWaterBucket);
    }

    private void OnResOrderSubmit()
    {
        UpdateSceneOrderUI();
    }

    public void UpdateSceneOrderUI()
    {
        var structure = GetStructure(29000008);
        if (structure != null)
        {
            structure.UpdateSceneOrderUI();
        }
    }

    public void UpdateVistFriendOrderUI()
    {
        var structure = GetStructure(29000008);
        if (structure != null)
        {
            structure.UpdateVistFriendOrderUI();
        }
    }

    public void UpdateWaterBucket()
    {
        var structure = GetStructure(29000016);
        if (structure != null)
        {
            structure.UpdateWaterPro();
        }
    }

    /// <summary>
    /// 每月抽卡
    /// </summary>
    public void UpdateMonthDraw(bool isActive)
    {
        AddStructure(new StructureData() { buildingDefId = 29000009, pos = new Vector3() { x = 8.61f, y = -18.12f } });//抽卡
    }

    /// <summary>
    /// 添加一个建筑
    /// </summary>
    /// <param name="structureData"></param>
    public void AddStructure(StructureData structureData)
    {
        waitCreateTime = waitCreateTimeGap * startLandId;
        startLandId += 1;
        ADK.Coroutiner.StartCoroutine(CoroutineAddStructure(structureData, waitCreateTime));
    }

    public IEnumerator CoroutineAddStructure(StructureData structureData, float waitCreateTime)
    {
        yield return new WaitForSeconds(waitCreateTime);
        var assetHandle = ResourceManager.Instance.LoadAssetAsync<GameObject>(ResPath.GetPrefabPath("Structure/Structure"));
        assetHandle.Completed += (AssetHandle assetHandle) =>
        {
            GameObject structureGameObject = assetHandle.InstantiateSync();
            Structure structure = structureGameObject.GetComponent<Structure>();
            if (structure != null)
            {
                structure.UpdateSkin(structureData);
            }
            structureGameObject.transform.SetParent(structureLayer, false);
            structureGameObject.transform.localPosition = structureData.pos;
            if (!structureDic.ContainsKey(structureData.buildingDefId))
            {
                structureDic.Add(structureData.buildingDefId, structure);
            }
            SceneManager.Instance.AddSceneObject(structure);
        };
    }

    /// <summary>
    /// 移除一个建筑
    /// </summary>
    /// <param name="structureId"></param>
    public void RemoveStructure(int structureId)
    {
        Structure structure;
        if (structureDic.TryGetValue(structureId, out structure))
        {
            GameObject.Destroy(structure.gameObject);
            structureDic.Remove(structureId);
        }
    }

    /// <summary>
    /// 获取一个建筑
    /// </summary>
    /// <param name="structureId"></param>
    /// <returns></returns>
    public Structure GetStructure(int structureId)
    {
        if (structureDic.TryGetValue(structureId, out Structure structure))
        {
            return structure;
        }
        return null;
    }

    public void Clear()
    {
        RemoveEvent();
    }
}
