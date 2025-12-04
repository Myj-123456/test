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
/// 场景管理器
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

    public bool IsDragging = false;//是否拖动中
    public bool IsTouchOnUI = false;//点击ui
    public bool IsTouchSceneObject = false;//点击场景物
    public bool IsEditing = false;//是否编辑中
    public bool isLongPress = false;//是否触发长按了
    public SceneObjectType sceneObjectType;//点击场景物类型
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
        //引导中未引导点击清扫操作，都会显示破旧花店
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

    }
    private void RemoveEvent()
    {
        EventManager.Instance.RemoveEventListener(SystemEvent.Reconnect, OnReconnect);
        EventManager.Instance.RemoveEventListener(FriendEvent.FriendVisit, OnVisitFriendRefreshScene);
        EventManager.Instance.RemoveEventListener(FlowerOrderEvent.UpdateFlowerOrderInfo, UpdateSceneOrderUI);
        EventManager.Instance.RemoveEventListener(DressEvent.ChangeSceneHeroModel, OnChangeSceneHeroModel);
        EventManager.Instance.RemoveEventListener<bool>(ActivityEvent.MonthDrawWhetherDisplay, OnMonthDrawWhetherDisplay);

    }
    private void OnMonthDrawWhetherDisplay(bool isActive)
    {
        if (structures != null)
        {
            structures.UpdateMonthDraw(isActive);
        }
    }


    /// <summary>
    /// 关闭编辑
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
        FlowerShopModel.Instance.InitDecorations(FlowerShopModel.Instance.serverDecoration);//再重置回去
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
    /// 重连刷新自己场景
    /// </summary>
    private void OnReconnect()
    {
        if (!MyselfModel.Instance.atHome) return;//不在自己家里，重连了不刷新 等返回家里自己再刷新一次
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
    /// 回家刷新自己场景
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
    //收获
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
    /// 是否拖拽花篮中
    /// </summary>
    /// <returns></returns>
    public bool IsDragHarvest()
    {
        return harvestUI != null && harvestUI.dragObject != null;
    }

    /// <summary>
    /// 是否拖拽浇水中
    /// </summary>
    /// <returns></returns>
    public bool IsDragWatering()
    {
        return plantWateringUI != null && plantWateringUI.dragObject != null && plantWateringUI.dragObject.name == "wateringDrag";
    }

    private PlantHandleUI plantHandleUi;
    public PlantWateringUI plantWateringUI;

    /// <summary>
    /// 成长期操作面板
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

    /// 成长期操作面板
    /// </summary>
    /// <param name="data"></param>
    /// <param name="position"></param>
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
        Application.targetFrameRate = 30;//进入游戏之后 设置为30 降低消耗
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
    ///  获取一个已解锁空土地
    /// </summary>
    /// <returns></returns>
    public Land GetUnLockEmptyLand()
    {
        if (lands != null)
        {
            return lands.GetUnLockEmptyLand();
        }
        return null;
    }

    /// <summary>
    ///  根据花id优先获取一个已经种植的土地
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
    ///  获取可以浇水的土地
    /// </summary>
    /// <returns></returns>
    public Land GetWaterLand()
    {
        if (lands != null)
        {
            return lands.GetWaterLand();
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
    ///  获取一个未解锁的土地
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
    /// 获取已解锁空花台
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
    /// 获取一个未解锁的花台
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
    /// 添加场景对象
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
    /// 根据家具类型获取一个家具
    /// </summary>
    /// <param name="decorationsType"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public Decoration GetDecoration(DecorationsType decorationsType, int id = -1)
    {
        var key = decorationsType.ToString() + "_" + "False" + 0;//采取家具类型和是否翻转拼接做唯一key
        if (flowerShop != null)
        {
            return flowerShop.GetDecoration(key);
        }
        return null;
    }

    /// <summary>
    /// 根据家具id获取一个家具
    /// </summary>
    /// <param name="decorationid"></param>
    /// <returns></returns>
    public Decoration GetDecorationById(int decorationid)
    {
        var florist_furnitureConfig = FlowerShopModel.Instance.GetFurniture(decorationid);
        if (florist_furnitureConfig == null) return null;
        var key = ((DecorationsType)florist_furnitureConfig.Type).ToString() + "_" + "False" + 0;//采取家具类型和是否翻转拼接做唯一key
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
        var isNeedPrequelPlotGuide = GuideModel.Instance.IsGuide && GuideModel.Instance.curGuideStep == 1;//是否需要前置引导
        //预加载换装主骨架文件
        var assetHandle = ResourceManager.Instance.LoadAssetAsync<SkeletonDataAsset>(ResPath.GetDressPartSpinePath("body", 0));
        assetHandle.Completed += (AssetHandle assetHandle) =>
        {
            heroAvatar = new SceneHeroAvatar();
            if (!isNeedPrequelPlotGuide)//未前置引导
            {
                heroAvatar.Init(npcLayer, new Vector3(0f, 8f, 0));
            }
            else//前置引导主角需要走过去才触发引导
            {
                GuideModel.Instance.IsPrequelPlotGuiding = true;
                heroAvatar.Init(npcLayer, new Vector3(18.72f, -2.71f, 0));
                //先移动镜头过去再开始走
                StartCoroutine(WaitForDone());
            }
            heroAvatarController = heroAvatar.AddComponent<SceneHeroAvatarController>();
            heroAvatarController.InitPolyNavMap(polyNavMap);
            heroAvatarController.heroAvatar = heroAvatar;
            heroAvatar.UpdateDress();
            if (!isNeedPrequelPlotGuide)//不需要前置引导立即检测引导
            {
                StartGuide();
            }
        };
    }

    private IEnumerator WaitForDone()
    {
        yield return new WaitForSeconds(0.5f);
        var camerePos = new Vector3(9f, 3.084523f, -10f);
        MoveToPoint(camerePos, 0.5f, true, () =>
        {
            HeroWalkToFlowerShop();
        });
    }

    /// <summary>
    /// 主角走向花店
    /// </summary>
    private void HeroWalkToFlowerShop()
    {
        heroAvatar.WalkToPoint(new Vector2(12.78f, 1.54f), StartGuide);
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
        //StartCoroutine(AddNpc());
        //return;
        NpcManager.Instance.StartCreatNpc(npcLayer);
    }

    private IEnumerator AddNpc()
    {
        NpcManager.Instance.CreatNpc(npcLayer, 1, 0);
        //NpcManager.Instance.CreatNpc(npcLayer, 1, 1);
        //NpcManager.Instance.CreatNpc(npcLayer, 2, 2);
        //NpcManager.Instance.CreatNpc(npcLayer, 3, 3);

        yield return new WaitForSeconds(5f);

        //NpcManager.Instance.CreatNpc(npcLayer, 4, 0);
        //NpcManager.Instance.CreatNpc(npcLayer, 5, 1);
        //NpcManager.Instance.CreatNpc(npcLayer, 6, 2);
        //NpcManager.Instance.CreatNpc(npcLayer, 3, 3);
    }

    /// <summary>
    /// 镜头移到培育屋
    /// </summary>
    /// <param name="endMoveCallBack"></param>
    public void MoveToCultivateHourse(UnityEngine.Events.UnityAction endMoveCallBack = null)
    {
        MoveToStructure(29000002, 0, endMoveCallBack);
    }

    /// <summary>
    /// 镜头移到插花
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
        var land = GetLand(1);//移到第一个土地
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
    /// 打开/关闭场景层(全屏界面可调用)
    /// </summary>
    public void ShowHideSceneLayer(bool active)
    {
        gameObject.SetActive(active);
    }

    /// <summary>
    /// 打开/关闭npc层
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
    /// 第二步引导开始前先调用这个显示下
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
}
