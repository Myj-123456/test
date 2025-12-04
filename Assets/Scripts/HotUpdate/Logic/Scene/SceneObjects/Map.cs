using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YooAsset;

/// <summary>
///地图
/// </summary>
public class Map
{
    private const int Row = 5;
    private const int Col = 5;
    public const float MapWidth = 58.34f;
    public const float MapHeight = 55.54f;
    public Vector2 mapSize = new Vector2(MapWidth, MapHeight);

    public void InitMap(Transform transform)
    {
        var trunkWidth = 11.66f;//地图块半宽
        var trunkHeight = 11.10f;//地图块半高
        for (var i = 0; i < Row; i++)
        {
            for (var j = 0; j < Col; j++)
            {
                var trunkId = i * 5 + j;
                var posX = j * trunkWidth;
                var posY = trunkHeight * (Row - 1) - i * trunkHeight;//y坐标取反
                var assetHandle = ResourceManager.Instance.LoadAssetSync<GameObject>("Assets/ResAB/Map/MapTrunk.prefab");
                var trunkObject = assetHandle.InstantiateSync();
                trunkObject.transform.SetParent(transform, false);
                trunkObject.transform.localPosition = new Vector3(posX, posY);
                trunkObject.GetComponent<MapTrunk>().UpdateTrunk(trunkId);
            }
        }
    }
}
