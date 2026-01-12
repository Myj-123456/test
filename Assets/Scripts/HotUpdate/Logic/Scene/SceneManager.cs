using ADK;
using FairyGUI;
using PolyNav;
using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityTimer;
using YooAsset;

/// <summary>
/// <summary>
/// 场景管理器
/// </summary>
/// </summary>
public class SceneManager : MonoSingleton<SceneManager>
{
    [SerializeField]
    private Camera sceneCamera;
    [SerializeField]
    private CameraController cameraController;
    [SerializeField]
    private Transform mapLayer;
    [SerializeField]
    private Transform floorLayer;
    [SerializeField]
    private Transform LandLayer;
    [SerializeField]
    private Transform plantLayer;
    [SerializeField]
    private Transform structureLayer;
    [SerializeField]
    private Transform homeTransform;
    [SerializeField]
    private Transform npcLayer;
    [SerializeField]
    private GameObject circlePre;
    [SerializeField]
    private Transform LandArea1;
    [SerializeField]
    private Transform LandArea2;
    [SerializeField]
    private Transform LandArea3;
    [SerializeField]
    private Transform LandArea4;
    [SerializeField]
    private PolyNavMap polyNavMap;
    [SerializeField]
    public GameObject guide_ani_broom;
    [SerializeField]
    private GameObject shabbyFlowerShop;

    private Map map;
    public Lands lands;
    private FlowerShop flowerShop;
    private Structures structures;
    private SceneHeroAvatar heroAvatar;
    private SceneHeroAvatar visitFriendHeroAvatar;
    private SceneHeroAvatarController heroAvatarController;

    public bool IsDragging = false;//是否拖拽中
    public bool IsTouchOnUI = false;//是否触摸在UI上
    public bool IsTouchSceneObject = false;//是否触摸在场景物体上
    public bool IsEditing = false;//是否编辑中
    public bool isLongPress = false;//是否长按中
    public SceneObjectType sceneObjectType;//场景物体类型
    private Dictionary<string, SceneObject> sceneObjects = new Dictionary<string, SceneObject>();

    void Start()
    {
        AddEvent();
        InitMap();
        InitFlowerShop();
        InitLand();
        InitStructure();
        CheckGuide();
    }

    private void CheckGuide()
    {
        //如果是引导且当前引导步骤小于3，则显示flowerShop
        if (GuideModel.Instance.IsGuide && GuideModel.Instance.curGuideStep < 3)
        {
            ShowHideShabbyFlowerShop(true);
        }
        else
        {
            ShowHideShabbyFlowerShop(false);
        }
    }

    private void AddEvent()
    {
        EventManager.Instance.AddEventListener(SystemEvent.Reconnect, OnReconnect);
        EventManager.Instance.AddEventListener(FriendEvent.FriendVisit, OnVisitFriendRefreshScene);
        EventManager.Instance.AddEventListener(FlowerOrderEvent.UpdateFlowerOrderInfo, UpdateSceneOrderUI);
        EventManager.Instance.AddEventListener(DressEvent.ChangeSceneHeroModel, OnChangeSceneHeroModel);
        EventManager.Instance.AddEventListener<bool>(ActivityEvent.MonthDrawWhetherDisplay, OnMonthDrawWhetherDisplay);
        EventManager.Instance.AddEventListener(SystemEvent.UpdateLevel, UpLevelUpdateLands);
    }
    private void RemoveEvent()
    {
        EventManager.Instance.RemoveEventListener(SystemEvent.Reconnect, OnReconnect);
        EventManager.Instance.RemoveEventListener(FriendEvent.FriendVisit, OnVisitFriendRefreshScene);
        EventManager.Instance.RemoveEventListener(FlowerOrderEvent.UpdateFlowerOrderInfo, UpdateSceneOrderUI);
        EventManager.Instance.RemoveEventListener(DressEvent.ChangeSceneHeroModel, OnChangeSceneHeroModel);
        EventManager.Instance.RemoveEventListener<bool>(ActivityEvent.MonthDrawWhetherDisplay, OnMonthDrawWhetherDisplay);
        EventManager.Instance.RemoveEventListener(SystemEvent.UpdateLevel, UpLevelUpdateLands);
    }
    private void OnMonthDrawWhetherDisplay(bool isActive)
    {
        if (structures != null)
        {
            structures.UpdateMonthDraw();
        }
    }


    /// <summary>
    /// 关闭编辑模式
    /// </summary>
    public void CloseEdit(bool resetAll = false)
    {
        IsEditing = false;
        if (resetAll)
        {
            ResetAll();
        }
    }

    private void ResetAll()
    {
        FlowerShopModel.Instance.InitDecorations(FlowerShopModel.Instance.serverDecoration);//�����û�ȥ
        UpdateFurnitures(FlowerShopModel.Instance.furnitureDataDic);
    }

    public void UpdateFurnitures(int[] furnitures)
    {
        if (flowerShop != null)
        {
            flowerShop.UpdateFurnitures(furnitures);
        }
    }

    public void UpdateFurnitures(Dictionary<int, Dictionary<int, FurnitureData>> furnitures)
    {
        if (flowerShop != null)
        {
            flowerShop.UpdateFurnitures(furnitures);
        }
    }

    public void UpdateFurnitures(int furnitureId)
    {
        if (flowerShop != null)
        {
            flowerShop.UpdateFurniture(furnitureId);
        }
    }

    /// <summary>
    /// 重新连接时刷新场景
    /// </summary>
    private void OnReconnect()
    {
        if (!MyselfModel.Instance.atHome) return;//如果不在家，则不刷新场景
        InitLand();
        InitFlowerShop();
        UpdateSceneOrderUI();
        NpcManager.Instance.StartOrderNpc(false);
    }

    public void ShowHideHeroAvatar(bool show)
    {
        if (heroAvatar != null)
        {
            heroAvatar.ShowOrHide(show);
        }
    }

    private void UpdateVisitFriendHeroAvatar()
    {
        if (visitFriendHeroAvatar == null)
        {
            visitFriendHeroAvatar = new SceneHeroAvatar();
            visitFriendHeroAvatar.Init(npcLayer, new Vector3(-0.5f, 9.22f, 0));
        }
        else
        {
            visitFriendHeroAvatar.ShowOrHide(true);
        }
        visitFriendHeroAvatar.UpdateDress();
    }

    private void ShowHideVisitFriendHeroAvatar(bool show)
    {
        if (visitFriendHeroAvatar != null)
        {
            visitFriendHeroAvatar.ShowOrHide(show);
        }
    }

    /// <summary>
    /// 回家时刷新场景
    /// </summary>
    public void BackHomeRefreshScene()
    {
        InitLand();
        InitFlowerShop();
        UpdateSceneOrderUI();
        NpcManager.Instance.StartOrderNpc(false);
        NpcManager.Instance.StartNpc();
        ShowHideHeroAvatar(true);
        ShowHideVisitFriendHeroAvatar(false);
    }

    /// <summary>
    /// 刷新好友场景
    /// </summary>
    private void OnVisitFriendRefreshScene()
    {
        InitLand();
        InitFlowerShop();
        UpdateVistFriendOrderUI();
        NpcManager.Instance.ClearAllNpcs();
        ShowHideHeroAvatar(false);
        UpdateVisitFriendHeroAvatar();
    }

    public PlantHarvestUI harvestUI;
    /// <summary>
    /// 创建收获UI
    /// </summary>
    /// <param name="landData"></param>
    /// <param name="position"></param>
    public void CreateHarvest(PlantVO landData, Vector3 position)
    {
        if (harvestUI == null)
        {
            harvestUI = new PlantHarvestUI();
            harvestUI.Init();
        }
        harvestUI.SetData(landData);
        harvestUI.Show(position);
    }

    public void HideHarvest()
    {
        if (harvestUI != null)
        {
            harvestUI.Hide();
        }
    }

    public void HideOneKeyWatering()
    {
        if (plantWateringUI != null)
        {
            plantWateringUI.Hide();
        }
    }

    /// <summary>
    /// 是否正在拖动收获UI
    /// </summary>
    /// <returns></returns>
    public bool IsDragHarvest()
    {
        return harvestUI != null && harvestUI.dragObject != null;
    }

    /// <summary>
    /// 是否正在拖动浇水UI
    /// </summary>
    /// <returns></returns>
    public bool IsDragWatering()
    {
        return plantWateringUI != null && plantWateringUI.dragObject != null && plantWateringUI.dragObject.name == "wateringDrag";
    }

    private PlantHandleUI plantHandleUi;
    public PlantWateringUI plantWateringUI;

    /// <summary>
    /// 创建种植处理UI
    /// </summary>
    /// <param name="data"></param>
    /// <param name="position"></param>
    public void CreatePlantHandle(PlantVO data, Vector3 position)
    {
        if (plantHandleUi == null)
        {
            plantHandleUi = new PlantHandleUI();
            plantHandleUi.Init();
        }
        plantHandleUi.SetData(data);
        plantHandleUi.Show(position);
    }

    /// <summary>
    /// 创建种植浇水UI
    /// </summary>
    /// <param name="position"></param>
    /// <param name="plantVO"></param>
    public void CreatePlantWatering(Vector3 position, PlantVO plantVO)
    {
        if (plantWateringUI == null)
        {
            plantWateringUI = new PlantWateringUI();
            plantWateringUI.Init();
        }
        plantWateringUI.Show(position, plantVO);
    }

    private void InitMap()
    {
        map = new Map();
        map.InitMap(mapLayer);
        cameraController.SetMap(map.mapSize);
    }

    public void TweenCameraOrthoSize(float targetSize)
    {
        cameraController.TweenCameraOrthoSize(targetSize, () =>
        {
            if (GuideModel.Instance.IsGuide)
            {
                if (GuideModel.Instance.curGuideStep > 2)
                {
                    UIManager.Instance.ShowOrHideMainUI(true, true, false);
                }
            }
            else
            {
                UIManager.Instance.ShowOrHideMainUI(true, true, false);
            }
            TweenCameraOrthoSizeCall();
            EventManager.Instance.DispatchEvent(SystemEvent.CameraOrthoSizeFinish);
        });
    }

    private void TweenCameraOrthoSizeCall()
    {
        Application.targetFrameRate = 30;//进入游戏之后 帧率设为30 节省性能
        InitHero();
        InitNpc();
    }

    private void InitFlowerShop()
    {
        if (flowerShop == null)
        {
            flowerShop = new FlowerShop(homeTransform);
        }
        flowerShop.Init();
    }

    private void InitStructure()
    {
        structures = new Structures();
        structures.InitStructures(structureLayer);
    }
    private void UpdateSceneOrderUI()
    {
        if (structures == null) return;
        structures.UpdateSceneOrderUI();
    }
    private void UpdateWaterBucket()
    {
        if (structures == null) return;
        structures.UpdateWaterBucket();
    }
    private void UpdateVistFriendOrderUI()
    {
        if (structures == null) return;
        structures.UpdateVistFriendOrderUI();
    }

    private void OnChangeSceneHeroModel()
    {
        if (heroAvatar != null)
        {
            heroAvatar.UpdateDress();
        }
    }

    private void InitLand()
    {
        if (lands == null)
        {
            lands = new Lands();
        }
        lands.InitLands(LandArea1, LandArea2, LandArea3, LandArea4);
    }

    public Land GetLand(int landId)
    {
        if (lands != null)
        {
            return lands.GetLand(landId);
        }
        return null;
    }

    public void HideAllLandSteal()
    {
        if (lands != null)
        {
            lands.HideAllLandSteal();
        }
    }

    /// <summary>
    /// 更新所有土地的偷花小手显示
    /// </summary>
    public void UpdateAllLandSteal()
    {
        if (lands != null)
        {
            lands.UpdateAllLandSteal();
        }
    }

    /// <summary>
    /// 获取一个已解锁空土地
    /// </summary>
    /// <returns></returns>
    public Land GetUnLockEmptyLand(bool isDefault = true)
    {
        if (lands != null)
        {
            return lands.GetUnLockEmptyLand(isDefault);
        }
        return null;
    }

    /// <summary>
    /// 获取一个已解锁空土地 并种植指定花
    /// </summary>
    /// <returns></returns>
    public Land GetUnLockEmptyLandByFlowerId(int flowerId)
    {
        if (lands != null)
        {
            return lands.GetUnLockEmptyLandByFlowerId(flowerId);
        }
        return null;
    }

    /// <summary>
    /// 获取一个可以浇水的土地
    /// </summary>
    /// <returns></returns>
    public Land GetWaterLand(bool isDefault = true)
    {
        if (lands != null)
        {
            return lands.GetWaterLand(isDefault);
        }
        return null;
    }

    public Land GetHarvestLand()
    {
        if (lands != null)
        {
            return lands.GetHarvestLand();
        }
        return null;
    }

    /// <summary>
    /// 获取一个已解锁空土地 并种植指定花
    /// </summary>
    /// <returns></returns>
    public Land GetLockLand()
    {
        if (lands != null)
        {
            return lands.GetLockLand();
        }
        return null;
    }

    /// <summary>
    /// 获取一个已解锁空花站
    /// </summary>
    /// <returns></returns>
    public FlowerStand GetUnLockEmptyFlowerStand()
    {
        if (flowerShop != null)
        {
            return flowerShop.GetUnLockEmptyFlowerStand();
        }
        return null;
    }

    /// <summary>
    /// 获取一个已解锁空花站 并种植指定花
    /// </summary>
    /// <returns></returns>
    public FlowerStand GetLockFlowerStand()
    {
        if (flowerShop != null)
        {
            return flowerShop.GetLockFlowerStand();
        }
        return null;
    }


    /// <summary>
    /// 添加一个场景对象
    /// </summary>
    /// <param name="sceneObject"></param>
    public void AddSceneObject(SceneObject sceneObject)
    {
        if (!sceneObjects.ContainsKey(sceneObject.objectUid))
        {
            sceneObjects.Add(sceneObject.objectUid, sceneObject);
        }
    }

    /// <summary>
    /// 获取一个场景对象
    /// </summary>
    /// <param name="objectUid"></param>
    /// <returns></returns>
    public SceneObject GetSceneObject(string objectUid)
    {
        if (sceneObjects.TryGetValue(objectUid, out SceneObject sceneObject))
        {
            return sceneObject;
        }
        return null;
    }

    /// <summary>
    /// 获取一个建筑
    /// </summary>
    /// <param name="structureId"></param>
    /// <returns></returns>
    public Structure GetStructure(int structureId)
    {
        if (structures != null)
        {
            return structures.GetStructure(structureId);
        }
        return null;
    }

    public FlowerStand GetFlowerStand(uint deskId)
    {
        if (flowerShop != null)
        {
            return flowerShop.GetFlowerStand(deskId);
        }
        return null;
    }

    /// <summary>
    /// 根据装饰类型获取一个装饰
    /// </summary>
    /// <param name="decorationsType"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public Decoration GetDecoration(DecorationsType decorationsType, int id = -1)
    {
        var key = decorationsType.ToString() + "_" + "False" + 0;//获取装饰类型和是否翻转作为唯一key
        if (flowerShop != null)
        {
            return flowerShop.GetDecoration(key);
        }
        return null;
    }



    /// <summary>
    /// 根据装饰id获取一个装饰
    /// </summary>
    /// <param name="decorationid"></param>
    /// <returns></returns>
    public Decoration GetDecorationById(int decorationid)
    {
        var florist_furnitureConfig = FlowerShopModel.Instance.GetFurniture(decorationid);
        if (florist_furnitureConfig == null) return null;
        var key = ((DecorationsType)florist_furnitureConfig.Type).ToString() + "_" + "False" + 0;//获取装饰类型和是否翻转作为唯一key
        if (flowerShop != null)
        {
            return flowerShop.GetDecoration(key);
        }
        return null;
    }

    public List<uint> GetHarvestLandIds()
    {
        if (lands != null)
        {
            return lands.GetHarvestLandIds();
        }
        return null;
    }

    private void InitHero()
    {
        var isNeedPrequelPlotGuide = GuideModel.Instance.IsGuide && GuideModel.Instance.curGuideStep == 1;//是否需要前序剧情引导
        //提前加载好英雄的模型资源
        var assetHandle = ResourceManager.Instance.LoadAssetAsync<SkeletonDataAsset>(ResPath.GetDressPartSpinePath("body", 0));
        assetHandle.Completed += (AssetHandle assetHandle) =>
        {
            heroAvatar = new SceneHeroAvatar();
            if (!isNeedPrequelPlotGuide)//不需要前序剧情引导
            {
                heroAvatar.Init(npcLayer, new Vector3(1f, 9f, 0));
            }
            else//需要前序剧情引导，需要等待引导完成后再初始化英雄
            {
                GuideModel.Instance.IsPrequelPlotGuiding = true;
                heroAvatar.Init(npcLayer, new Vector3(20.25f, -1.39f, 0));
                //等待引导完成后，英雄移动到指定位置
                StartCoroutine(WaitForDone());
            }
            heroAvatarController = heroAvatar.AddComponent<SceneHeroAvatarController>();
            heroAvatarController.InitPolyNavMap(polyNavMap);
            heroAvatarController.heroAvatar = heroAvatar;
            heroAvatar.UpdateDress();
            if (!isNeedPrequelPlotGuide)//不需要前序剧情引导，直接开始引导
            {
                StartGuide();
            }
        };
    }

    private IEnumerator WaitForDone()
    {
        yield return new WaitForSeconds(0.5f);
        var camerePos = new Vector3(9f, 3.084523f, -10f);
        MoveToPoint(camerePos, 0.3f, true, () =>
        {
            HeroWalkToFlowerShop();
        });
    }

    /// <summary>
    /// 英雄移动到花商位置
    /// </summary>
    private void HeroWalkToFlowerShop()
    {
        heroAvatar.WalkToPoint(new Vector2(14.98f, 1.58f), StartGuide);
    }

    private void StartGuide()
    {
        GuideModel.Instance.IsPrequelPlotGuiding = false;
        GuideController.Instance.ShowGuide(true);
    }

    private Vector3 standOffset = new Vector3(0.90f, 0.57f, 0f);

    public void PlayHeroPlantAni(Land land, string aniName)
    {
        ShowNavPointMark(Vector3.zero, false);
        if (heroAvatar != null)
        {
            heroAvatar.SetScale(Vector3.one);
            heroAvatar.SetPos(land.transform.position + standOffset);
            heroAvatarController.StopWalking();
            heroAvatarController.isPlanting = true;
            heroAvatar.PlayAnimation(aniName, false, () =>
            {
                heroAvatar.PlayAnimation("idle", true);
                heroAvatarController.isPlanting = false;
            });
        }
    }

    private void InitNpc()
    {
        //NpcManager.Instance.ShowDebugNpcLine(circlePre, npcLayer);
        NpcManager.Instance.StartCreatNpc(npcLayer);
    }

    /// <summary>
    /// 英雄移动到 CultivateHourse 位置
    /// </summary>
    /// <param name="endMoveCallBack"></param>
    public void MoveToCultivateHourse(UnityEngine.Events.UnityAction endMoveCallBack = null)
    {
        MoveToStructure(29000002, 0, endMoveCallBack);
    }

    /// <summary>
    /// 英雄移动到 ArrangementFlower 位置
    /// </summary>
    /// <param name="endMoveCallBack"></param>
    public void MoveToArrangementFlower(UnityEngine.Events.UnityAction endMoveCallBack = null)
    {
        MoveToDecoration(DecorationsType.Counter, 0, endMoveCallBack);
    }

    public void MoveToStructure(int structureId, float duration = 0f, UnityEngine.Events.UnityAction endMoveCallBack = null)
    {
        var structure = GetStructure(structureId);
        if (structure != null)
        {
            cameraController.MoveToPoint(structure.transform.position, duration, true, endMoveCallBack);
        }
    }
    public void MoveToDecoration(DecorationsType decorationsType, float duration = 0f, UnityEngine.Events.UnityAction endMoveCallBack = null)
    {
        var decoration = GetDecoration(decorationsType);
        if (decoration != null)
        {
            cameraController.MoveToPoint(decoration.transform.position, duration, true, endMoveCallBack);
        }
    }

    public void MoveToPantFlower(UnityEngine.Events.UnityAction action = null)
    {
        var land = GetLand(1);//获取第一个土地
        MoveToPoint(land.transform.position, 0, true, action);
    }

    public void MoveToPoint(Vector3 pos, float time = 0f, bool isLimitboundary = true, UnityEngine.Events.UnityAction action = null)
    {
        cameraController.MoveToPoint(pos, time, isLimitboundary, action);
    }

    public void TweenCameraOrthoSize(float targetSize, float time = 0.4f, Action action = null)
    {
        cameraController.TweenCameraOrthoSize(targetSize, time, action);
    }

    public void HideAllDeskSelect()
    {
        flowerShop.HideAllDeskSelect();
    }
    public void ShowHideAllDeskAddFlower(bool show)
    {
        flowerShop.ShowHideAllDeskAddFlowerMark(show);
    }

    public void SwitchSceneClearAll()
    {
        RemoveEvent();
        flowerShop.Clear();
        structures.Clear();
    }

    /// <summary>
    /// 显示/隐藏场景层(包含所有物体)
    /// </summary>
    public void ShowHideSceneLayer(bool active)
    {
        gameObject.SetActive(active);
    }

    /// <summary>
    /// 显示/隐藏npc层
    /// </summary>
    public void ShowHideNpcLayer(bool active)
    {
        npcLayer.gameObject.SetActive(active);
    }


    private GameObject navPointMark;
    public void ShowNavPointMark(Vector3 pos, bool isShow)
    {
        if (isShow)
        {
            if (navPointMark == null)
            {
                var assetHandle = ResourceManager.Instance.LoadAssetAsync<GameObject>(ResPath.GetPrefabPath("NavPointMark"));
                assetHandle.Completed += (AssetHandle handle) =>
                {
                    navPointMark = assetHandle.InstantiateSync(npcLayer, false);
                    navPointMark.transform.localPosition = pos;
                    navPointMark.transform.localScale = new Vector3(2.2f, 2.2f, 1);
                    TweenUtil.FloatAnimation(navPointMark.transform);
                };
            }
            else
            {
                navPointMark.SetActive(true);
                navPointMark.transform.localPosition = pos;
                TweenUtil.FloatAnimation(navPointMark.transform);
            }
        }
        else
        {
            if (navPointMark != null)
            {
                navPointMark.SetActive(false);
                TweenUtil.HideTween(navPointMark.transform);
            }
        }
    }

    /// <summary>
    /// 显示/隐藏引导扫帚
    /// </summary>
    public void ShowGuideBroom()
    {
        guide_ani_broom.SetActive(true);
    }

    public void ShowHideShabbyFlowerShop(bool isShow)
    {
        shabbyFlowerShop.SetActive(isShow);
        homeTransform.gameObject.SetActive(!isShow);
    }
    private void UpLevelUpdateLands()
    {
        if (lands != null)
        {
            lands.UpLevelUpdateLands();
        }
    }
}
