using UnityEngine;
using YooAsset;

/// <summary>
/// µØÍ¼·Ö¿é
/// </summary>
public class MapTrunk : MonoBehaviour
{
    [SerializeReference]
    private SpriteRenderer spriteRenderer;
    public void UpdateTrunk(int trunkId)
    {
        AssetHandle assetHandle = ResourceManager.Instance.LoadAssetSync<Sprite>(ResPath.GetMapTrunkPath("map_" + trunkId));
        if (assetHandle.AssetObject != null)
        {
            spriteRenderer.sprite = assetHandle.AssetObject as Sprite;
        }
    }
}
