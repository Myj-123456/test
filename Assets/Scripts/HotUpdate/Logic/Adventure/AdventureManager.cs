using Elida.Config;
using PolyNav;
using protobuf.adventure;
using protobuf.messagecode;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using YooAsset;
public class AdventureManager : MonoBehaviour
{
    [SerializeField]
    private AdventureCameraController cameraController;
    [SerializeField]
    private Transform mapTransform;
    private Transform unWalksTransform;
    [SerializeField]
    private Transform avatarTransform;
    [SerializeField]
    private Transform dynamicObstaclesTransform;
    [SerializeField]
    private Transform fogsTransform;
    [SerializeField]
    public Transform navMapTransform;
    private PolyNavMap navMap;

    private Dictionary<int, Fog> fogDic = new Dictionary<int, Fog>();

    private MapConfigData mapConfigData;
    private SceneHeroAvatar heroAvatar;

    IEnumerator Start()
    {
        ShowAdventureView();
        yield return LoadMapConfig();
        yield return InitMap();
        InitCameraController();
        InitNoWalkGrids();
        //InitFog();
        InitDynamicObstacles();
        InitHero();
    }

    private void ShowAdventureView()
    {
        UIManager.Instance.OpenPanel<AdventureView>(UIName.AdventureView);
    }
    private void InitCameraController()
    {
        cameraController.SetMap(transform, mapConfigData.mapSize);
    }

    private IEnumerator LoadMapConfig()
    {
        var handle = ResourceManager.Instance.LoadAssetAsync<TextAsset>(ResPath.GetAdventureRes($"Config/MapConfig{AdventureModel.Instance.curMapId}.json"));
        yield return handle;
        mapConfigData = ADK.StringUtil.DeserializeObject<MapConfigData>((handle.AssetObject as TextAsset).text);
        Debug.Log("地图宽，x:" + mapConfigData.mapSize.x + " y:" + mapConfigData.mapSize.y);
    }

    /// <summary>
    /// 加载地图
    /// </summary>
    private IEnumerator InitMap()
    {
        var handle = ResourceManager.Instance.LoadAssetAsync<GameObject>(ResPath.GetAdventureRes($"MapConfig/MapConfig{AdventureModel.Instance.curMapId}_Map.prefab"));
        yield return handle;
        var mapGameObject = handle.AssetObject as GameObject;
        var map = Instantiate(mapGameObject, mapTransform, false);
        unWalksTransform = map.transform.Find("unWalks");
        navMap = map.transform.Find("PolyNavMap").GetComponent<PolyNavMap>();
    }

    /// <summary>
    /// 刷不可走格子
    /// </summary>
    private void InitNoWalkGrids()
    {
        //获取所有有图块的位置
        foreach (var pos in mapConfigData.unWalkGridPosList)
        {
            AddNoWalkGrid(pos);
        }
    }

    private void AddNoWalkGrid(TransformVector4 transformVector4)
    {
        var assetHandle = ResourceManager.Instance.LoadAssetAsync<GameObject>(ResPath.GetAdventureRes("Prefabs/noWalkMark.prefab"));
        assetHandle.Completed += (AssetHandle handle) =>
        {
            var noWalkMark = assetHandle.InstantiateSync(unWalksTransform, false);
            Vector2[] points = new Vector2[4];
            points[0] = new Vector2() { x = transformVector4.left.x, y = transformVector4.left.y };
            points[1] = new Vector2() { x = transformVector4.up.x, y = transformVector4.up.y };
            points[2] = new Vector2() { x = transformVector4.right.x, y = transformVector4.right.y };
            points[3] = new Vector2() { x = transformVector4.down.x, y = transformVector4.down.y };
            noWalkMark.GetComponent<PolygonCollider2D>().points = points;
        };
    }


    /// <summary>
    /// 加载不可走格子会导致卡顿 目前采取分帧加载
    /// </summary>
    /// <returns></returns>
    //private IEnumerator InitNoWalkGridsCoroutine()
    //{
    //    // 每帧最多加载的不可走格子数量（可调整）
    //    int gridsPerFrame = 50;
    //    int count = 0;

    //    foreach (var pos in mapConfigData.unWalkGridPosList)
    //    {
    //        // 异步加载 noWalkMark
    //        var assetHandle = ResourceManager.Instance.LoadAssetAsync<GameObject>(ResPath.GetAdventureRes("Prefabs/noWalkMark.prefab"));
    //        yield return assetHandle; // 等待加载完成

    //        if (assetHandle.IsValid && assetHandle.AssetObject != null)
    //        {
    //            var noWalkMark = assetHandle.InstantiateSync(unWalksTransform, false);
    //            noWalkMark.transform.localPosition = new Vector3(pos.x, pos.y, pos.z);
    //        }

    //        count++;
    //        if (count >= gridsPerFrame)
    //        {
    //            count = 0;
    //            yield return null; // 等待下一帧
    //        }
    //    }
    //}



    private void InitFog()
    {
        foreach (var fog in mapConfigData.fogDatas)
        {
            var handle = ResourceManager.Instance.LoadAssetAsync<GameObject>(ResPath.GetAdventureRes("Prefabs/Fog.prefab"));
            handle.Completed += (AssetHandle assetHandle) =>
            {
                var fogPre = assetHandle.AssetObject as GameObject;
                var fogObject = Instantiate(fogPre, fogsTransform, false);
                SetFogSkin(fogObject.transform, fog.objectShow);
                var polyNavObstacle = fogObject.GetComponent<PolyNav.PolyNavObstacle>();
                if (polyNavObstacle != null)//迷雾默认为阻挡
                {
                    polyNavObstacle.isBlock = true;
                    polyNavObstacle.blockType = 2;
                }
                fogObject.transform.localPosition = new Vector3(fog.position.x, fog.position.y, fog.position.z);
                fogObject.transform.localEulerAngles = new Vector3(fog.rotation.x, fog.rotation.y, fog.rotation.z);
                fogObject.transform.localScale = new Vector3(fog.scale.x, fog.scale.y, fog.scale.z);
                fogObject.SetActive(false);//默认创建了先隐藏

                Fog fogComponent = fogObject.GetComponent<Fog>();
                if (fogComponent != null)
                {
                    fogComponent.id = fog.id;
                    fogDic.Add(fog.id, fogComponent);
                }
            };
        }
    }

    private Fog GetFog(int id)
    {
        if (fogDic.TryGetValue(id, out Fog fog))
        {
            return fog;
        }
        return null;
    }

    private void InitDynamicObstacles()
    {
        AdventureModel.Instance.ClearObstacleDic();
        foreach (var obstacle in mapConfigData.obstacleDatas)
        {
            if (AdventureModel.Instance.GetGridIsUnLock(obstacle.gridId))//已解锁
            {
                continue;
            }
            var handle = ResourceManager.Instance.LoadAssetAsync<GameObject>(ResPath.GetAdventureRes("Prefabs/Object.prefab"));
            handle.Completed += (AssetHandle assetHandle) =>
            {
                var obstaclePre = assetHandle.AssetObject as GameObject;
                var obstacleObject = Instantiate(obstaclePre, dynamicObstaclesTransform, false);
                var gridConfig = AdventureModel.Instance.GetGridConfig(obstacle.gridId);
                if (gridConfig != null)
                {
                    Transform obstacleTransform = null;
                    if (gridConfig.ObjectType == 4)//怪物
                    {
                        obstacleTransform = obstacleObject.transform.Find("spine");
                    }
                    else//其他
                    {
                        obstacleTransform = obstacleObject.transform.Find("obstacle");
                    }

                    obstacleObject.transform.localPosition = new Vector3(obstacle.position.x, obstacle.position.y, obstacle.position.z);
                    obstacleTransform.localEulerAngles = new Vector3(obstacle.rotation.x, obstacle.rotation.y, obstacle.rotation.z);
                    obstacleTransform.localScale = new Vector3(obstacle.scale.x, obstacle.scale.y, obstacle.scale.z);
                    Obstacle obstacleComponent = obstacleTransform.GetComponent<Obstacle>();
                    if (obstacleComponent != null)
                    {
                        SetObstacleSkin(obstacleTransform, obstacleComponent, gridConfig, obstacle);
                        obstacleComponent.ShowHideBubble(false);
                        obstacleComponent.gridId = obstacle.gridId;
                        obstacleComponent.objectShow = obstacle.objectShow;
                        AdventureModel.Instance.AddObstacle(obstacleComponent);
                        foreach (var fog in obstacle.fogs)
                        {
                            var f = GetFog(fog.id);
                            if (f != null)
                            {
                                f.gameObject.SetActive(true);
                                obstacleComponent.fogs.Add(f);
                            }
                        }
                    }
                }
            };
        }
    }

    private void SetObstacleSkin(Transform obstacleObject, Obstacle obstacleComponent, Ft_island_objectConfig gridConfig, ObstacleData obstacleData)
    {
        obstacleObject.GetComponent<BoxCollider2D>().enabled = true;
        if (gridConfig.ObjectType == 4)//敌人用spine
        {
            var skeletonAnimation = obstacleObject.GetComponent<SkeletonAnimation>();
            var ft_island_stageConfig = AdventureModel.Instance.GetIslandStageConfig(int.Parse(gridConfig.ClearReward));
            if (ft_island_stageConfig != null)
            {
                var enemyId = ft_island_stageConfig.EnemyGroups[0];
                obstacleComponent.enemyId = enemyId;
                var enemyConfig = AdventureModel.Instance.GetEnemyConfig(enemyId);
                if (enemyConfig != null)
                {
                    var assetHandle = ResourceManager.Instance.LoadAssetAsync<SkeletonDataAsset>(ResPath.GetSpinePath("enemy/" + enemyConfig.SpineName));
                    assetHandle.Completed += (AssetHandle assetHandle) =>
                    {
                        skeletonAnimation.skeletonDataAsset = assetHandle.AssetObject as SkeletonDataAsset;
                        skeletonAnimation.AnimationState.SetAnimation(0, "idle", true);
                    };
                }
            }
        }
        else//其他用图片
        {
            var spriteRenderer = obstacleObject.GetComponent<SpriteRenderer>();
            var assetHandle = ResourceManager.Instance.LoadAssetAsync<Sprite>(ResPath.GetAdventureRes("Res/Objects/" + obstacleData.objectShow + ".png"));
            assetHandle.Completed += (AssetHandle assetHandle) =>
            {
                spriteRenderer.sprite = assetHandle.AssetObject as Sprite;
                string pattern = @"^shu\d$";
                bool isMatch = Regex.IsMatch(obstacleData.objectShow, pattern);
                if (isMatch)//如果树 需要改为锚点排序
                {
                    spriteRenderer.spriteSortPoint = SpriteSortPoint.Pivot;
                    obstacleObject.GetComponent<BoxCollider2D>().offset = new Vector2(0f, spriteRenderer.size.y / 2);
                }
                obstacleObject.GetComponent<BoxCollider2D>().size = spriteRenderer.size;
            };
        }


    }

    private void SetFogSkin(Transform obstacleObject, string objectShow)
    {
        var spriteRenderer = obstacleObject.GetComponent<SpriteRenderer>();
        var assetHandle = ResourceManager.Instance.LoadAssetAsync<Sprite>(ResPath.GetAdventureRes("Res/fog/" + objectShow + ".png"));
        assetHandle.Completed += (AssetHandle assetHandle) =>
        {
            spriteRenderer.sprite = assetHandle.AssetObject as Sprite;
            obstacleObject.GetComponent<BoxCollider2D>().size = spriteRenderer.size;
        };
    }
    private void InitHero()
    {
        heroAvatar = new SceneHeroAvatar();
        heroAvatar.Init(avatarTransform, new Vector3(1f, -12f), 0.3f);
        heroAvatar.SetScale(new Vector3(-1, 1, 1));
        heroAvatar.UpdateDress();
        heroAvatar.AddHuibi();

        var playerController = heroAvatar.AddComponent<PlayerController>();
        playerController.map = navMap;
    }

}
