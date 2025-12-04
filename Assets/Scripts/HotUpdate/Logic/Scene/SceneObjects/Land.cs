using DG.Tweening;
using Elida.Config;
using FairyGUI;
using Spine;
using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using YooAsset;

public enum PlantState
{
    State_null = -1,//未种植
    State_0,//幼苗种子期(未初灌)
    State_1,//1成长期
    State_2,//2成熟期(可收获)
}

/// <summary>
/// 土地数据类
/// </summary>
public class LandData
{
    public int landId;
    public int buildingDefId;
    public int cutRibbon;
    public int decorId;
    public long effectiveTime;
    public int orient;
    public int userId;
    public int state;
    public Vector3 pos;
    public int plantSeedFlowerId = 0;//拖拽种植种子id 为0表示没种植
    public PlantState plantState = PlantState.State_null;//种植状态 -1未种植 0 幼苗种子期 1成长期  2成熟期
    public int plantFlowerId = 0;//种植花id 为0表示没种植
}

/// <summary>
/// 建筑
/// </summary>
public class Land : SceneObject, IPointerEnterHandler
{
    [SerializeField]
    private UnityEngine.Transform plantContainer;
    [SerializeField]
    private UnityEngine.Transform aniContainer;
    [SerializeField]
    private SpriteRenderer plantSkin;
    [SerializeField]
    private SpriteRenderer waterSkin;

    [SerializeField]
    private UIPanel watering;
    [SerializeField]
    private UIPanel stealBubble;

    public LandData landData;
    private SkeletonAnimation armatureComponen;
    private SkeletonAnimation flowerArmatureComponen;
    [SerializeField] private float _breathInterval = 1000f;
    private float _timer = 0f;
    private float _breathCount = 0f;
    private const float UpdateInterval = 0.5f; // 500 milliseconds
    private Tweener _tween;
    private bool startTween = false;

    public PlantVO plantVO;//土地数据(为空表示未解锁)
    public int landId;//土地id
    private bool InitWatering = false;
    private Vector3 scale1 = new Vector3(0.6f, 0.6f, 0.6f);

    public void UpdateSkin(int landId, PlantVO plantVO)
    {
        ResetState();
        this.landId = landId;
        this.plantVO = plantVO;
        data = landId;
        _breathInterval = UnityEngine.Random.Range(2000f, 4000f);
        sceneObjectType = SceneObjectType.Land;
        SetObjectUid((uint)landId);

        if (armatureComponen == null)
        {
            AnimationHelper.CreateSpine("field_unlock", transform, "", false, "", (SkeletonAnimation armatureComponent) =>
            {
                armatureComponen = armatureComponent;
                armatureComponent.transform.localPosition = new Vector3(-0.05f, -0.11f, 0f);
                if (plantVO != null)//有数据表示已解锁
                {
                    armatureComponent.AnimationState.SetAnimation(0, "after", false);
                }
                else
                {
                    armatureComponent.AnimationState.SetAnimation(0, "befor", true);
                }
                UpdatePlantStatu(false);
            });
        }
        else
        {
            if (plantVO != null)//有数据表示已解锁
            {
                armatureComponen.AnimationState.SetAnimation(0, "after", false);
            }
            else
            {
                armatureComponen.AnimationState.SetAnimation(0, "befor", true);
            }
            UpdatePlantStatu(false);
        }
    }

    /// <summary>
    /// 更新种植状态
    /// </summary>
    public void UpdatePlantStatu(bool isPlayStateTransition = true, bool isClear = false)
    {
        if (plantVO != null)
        {
            waterSkin.gameObject.SetActive(false);
            if (plantVO.flowerId > 0)//已种植种子
            {
                if (plantVO.status == 0)//未浇水状态
                {
                    UpdatePlantState((int)plantVO.flowerId, PlantState.State_0, isPlayStateTransition, isClear);
                    waterSkin.gameObject.SetActive(true);//直接显示水
                }
                else//已浇水
                {
                    if (plantVO.harvestTime > 0)//已浇水有成熟时间
                    {
                        var isRipe = plantVO.harvestTime <= ServerTime.Time;//已成熟
                        if (isRipe)
                        {
                            UpdatePlantState((int)plantVO.flowerId, PlantState.State_2, isPlayStateTransition, isClear);
                        }
                        else
                        {
                            UpdatePlantState((int)plantVO.flowerId, PlantState.State_1, isPlayStateTransition, isClear);
                        }
                    }
                }
            }
            else//未种植
            {
                UpdatePlantState((int)plantVO.flowerId, PlantState.State_null, isPlayStateTransition, isClear);
            }
        }

        UpdateFriendSteal();
    }

    public void UpdateFriendSteal()
    {
        var checkStealEnable = CheckStealEnable();
        if (checkStealEnable)
        {
            ShowStealBubble();
        }
        else
        {
            HideStealBubble();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!SceneManager.Instance.IsDragging || plantVO == null) return;
        var dragFlowerId = PlantModel.Instance.dragFlowerId;
        if (plantVO.plantState == PlantState.State_null)
        {
            //拖拽种植
            if (dragFlowerId > 0)
            {
                Plant(dragFlowerId);//前端先表现
                PlantModel.Instance.dragPlantLandIds.Add((uint)landId);//先存起来 等拖拽完毕再发送给服务器
            }
        }
        //拖拽浇水
        else if (plantVO.plantState == PlantState.State_0)
        {
            if (SceneManager.Instance.IsDragWatering())
            {
                if (MyselfModel.Instance.WaterCur < 1)//水滴不足
                {
                    ADK.UILogicUtils.ShowNotice(Lang.GetValue("SucculentPlant_tips1"));
                    return;
                }
                //前端先表现浇水
                Water();
                PlantModel.Instance.dragWateingLandIds.Add((uint)landId);//先存起来 等拖拽完毕再发送给服务器
                MyselfModel.Instance.SubWater(1);
            }
        }
        //拖拽收花
        else if (plantVO.plantState == PlantState.State_2)
        {
            if (SceneManager.Instance.IsDragHarvest())
            {
                plantVO.surplus -= 1;
                if (plantVO.surplus > 0)//如果有收获次数，切换为生长阶段
                {
                    startTween = false;
                    ClearTween();
                    var condition = FlowerHandbookModel.Instance.GetStaticSeedCondition((int)plantVO.flowerId);
                    var ft_plant_cropConfig = PlantModel.Instance.GetPlantCropConfigData(condition.LevelMould + "#" + plantVO.level);
                    if (ft_plant_cropConfig != null)
                    {
                        var time = ft_plant_cropConfig.Interval;
                        plantVO.harvestTime = ServerTime.Time + (uint)time;
                        UpdatePlantStatu(false);
                    }
                }
                else
                {
                    Clear();
                }
                PlantModel.Instance.dragHarvestLandIds.Add((uint)landId);//先存起来 等拖拽完毕再发送给服务器
            }
        }


    }

    /// <summary>
    /// 播放花种植动画
    /// </summary>
    private void PlayPlantAni(int plantSeedFlowerId, bool isPlayStateTransition)
    {
        if (plantVO == null || plantVO.plantState == PlantState.State_null)
        {
            return;
        }
        var aniName = GetAniNameByPlantState();

        if (flowerArmatureComponen != null)
        {
            var animationState = flowerArmatureComponen.AnimationState;
            if (animationState == null) return;
            if (isPlayStateTransition)//播放状态转场
            {
                var t = animationState.SetAnimation(0, aniName + "_grow", false);
                t.TrackTime = 0;
                t.MixDuration = 0;
                animationState.AddAnimation(0, aniName + "_idle", true, 0);
            }
            else
            {
                var t = animationState.SetAnimation(0, aniName + "_idle", true);
                t.TrackTime = 0;
                t.MixDuration = 0;
            }
        }
        else
        {
            AnimationHelper.CreateSpine($"flowers/{plantSeedFlowerId}", aniContainer, "", false, "", (SkeletonAnimation armatureComponent) =>
            {
                armatureComponent.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
                flowerArmatureComponen = armatureComponent;
                var animationState = flowerArmatureComponen.AnimationState;
                if (animationState == null) return;
                if (isPlayStateTransition)//播放状态转场
                {
                    var t = animationState.SetAnimation(0, aniName + "_grow", false);
                    t.TrackTime = 0;
                    t.MixDuration = 0;
                    animationState.AddAnimation(0, aniName + "_idle", true, 0);
                }
                else
                {
                    var t = animationState.SetAnimation(0, aniName + "_idle", true);
                    t.TrackTime = 0;
                    t.MixDuration = 0;
                }
            });
        }
    }

    private string GetAniNameByPlantState()
    {
        if (plantVO == null) return "";
        switch (plantVO.plantState)
        {
            case PlantState.State_0: return "step_1";
            case PlantState.State_1: return "step_2";
            case PlantState.State_2: return "step_3";
        }
        return "";
    }

    private void FixedUpdate()
    {
        if (plantVO == null) return;
        _timer += Time.fixedDeltaTime;

        if (_timer >= UpdateInterval)
        {
            _timer = 0f;
            OnTickExcute();
        }
    }


    //每0.5s执行一次
    private void OnTickExcute()
    {
        CheckPlantIsRipe();
        UpdateBreath();
    }
    public void Harvest()
    {
        SceneManager.Instance.CreateHarvest(plantVO, transform.position);
        RollOver();
        //if (GuideModel.Instance.IsGuiding)
        //{
        //    GuideController.Instance.NextGuide();
        //}
    }

    public void PlantHander()
    {
        SceneManager.Instance.CreatePlantHandle(plantVO, transform.position);
    }
    public void PlantOneKeyWatering(PlantVO plantVO)
    {
        SceneManager.Instance.CreatePlantWatering(transform.position, plantVO);
    }

    private void RollOver()
    {
        if (plantContainer != null)
        {
            ClearTween();
            plantContainer.localScale = new Vector3(1, 1, 1);
            _tween = plantContainer.DOScaleY(0.7f, 0.1f).SetEase(Ease.OutCirc).OnComplete(() => plantContainer.DOScaleY(1f, 0.4f).SetEase(Ease.OutBack));
        }
        else
        {

        }
    }

    //只有成熟状态才可以播放呼吸动画
    private void UpdateBreath()
    {
        if (!startTween || plantVO.plantState != PlantState.State_2) return;
        _breathCount += 500;
        if (_breathCount >= _breathInterval)
        {
            _breathCount = 0;
            ClearTween();
            float tScale = 1.1f;
            _tween = plantContainer.DOScaleY(tScale, _breathInterval / 2000f)
                .OnComplete(() => plantContainer.DOScaleY(1f, _breathInterval / 2000f));
        }
    }

    private void ClearTween()
    {
        if (_tween != null)
        {
            _tween.Kill();
            _tween = null;
        }
    }

    /// <summary>
    /// 检测植物是否成熟了
    /// </summary>
    private void CheckPlantIsRipe()
    {
        if (plantVO.plantState == PlantState.State_1)
        {
            var isRipe = plantVO.harvestTime <= ServerTime.Time;//已成熟
            if (isRipe)
            {
                UpdatePlantState((int)plantVO.flowerId, PlantState.State_2);
            }
        }
    }

    /// <summary>
    /// </summary>
    /// <param name="plantSeedFlowerId"></param>
    public void Plant(int plantSeedFlowerId)
    {
        if (plantVO.plantState == PlantState.State_null)
        {
            UpdatePlantState(plantSeedFlowerId, PlantState.State_0);
            DropWater();
            //Guide();
        }
    }

    /// <summary>
    /// 种植完毕引导浇水
    /// </summary>
    private void Guide()
    {
        if (GuideModel.Instance.IsGuiding)
        {
            GuideController.Instance.NextGuide();
        }

    }

    public void Water()
    {
        if (plantVO.plantState == PlantState.State_0)
        {
            Watering();
        }
    }

    //浇水
    private void Watering()
    {
        StartCoroutine(WaterGrowing());
        fun_Scene.watering waterUi = (fun_Scene.watering)watering.ui;
        if (!InitWatering)
        {
            watering.gameObject.transform.localScale *= 1.5f;//暂时放到1.5倍
            InitWatering = true;
        }
        watering.gameObject.SetActive(true);
        waterUi.value = 1;
        waterUi.max = 100;

        if (GuideModel.Instance.IsGuiding)
        {
            EventManager.Instance.DispatchEvent(GuideEvent.HideGuideUI);
        }

        waterUi.TweenValue(100, 1).OnComplete((GTweener tweener) =>
        {
            watering.gameObject.SetActive(false);
            if (plantVO.flowerId > 0)
            {
                waterSkin.gameObject.SetActive(false);
                //Guide();//引导收花
            }
        });

    }

    ///// <summary>
    ///// 0.5s表现成长过程
    ///// </summary>
    ///// <returns></returns>
    private IEnumerator WaterGrowing()
    {
        //yield return new WaitForSeconds(0.5f);
        yield return new WaitForSeconds(0f);
        waterSkin.gameObject.SetActive(false);
        //首次灌溉其实默认是马上成熟的 这里是前端做了延迟
        //UpdatePlantState((int)plantVO.flowerId, PlantState.State_1);
        //yield return new WaitForSeconds(0.5f);
        UpdatePlantState((int)plantVO.flowerId, PlantState.State_2);
    }

    private void ShowStealBubble()
    {
        stealBubble.gameObject.SetActive(true);
        common_New.bubble bubble = (common_New.bubble)stealBubble.ui;
        bubble.img_loaderOld.url = "Item/isteal.png";
        stealBubble.ui.onClick.Add(() =>
        {
            FriendController.Instance.ReqSteal(MyselfModel.Instance.friendId, (uint)plantVO.landId);
        });
        BubbleAnimation();
    }

    private float originalY = 0;
    private bool isFloating = false;
    private float floatAmount = 0.25f; // 漂浮的高度
    private float duration = 1f; // 漂浮的时间
    private void BubbleAnimation()
    {
        if (isFloating) return;
        isFloating = true;

        if (originalY == 0)
        {
            originalY = stealBubble.transform.localPosition.y;
        }
        //重置位置
        stealBubble.transform.localPosition = new Vector3(stealBubble.transform.localPosition.x, originalY);
        stealBubble.transform.DOLocalMoveY(stealBubble.transform.localPosition.y + floatAmount, duration)
           .SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    public void HideStealBubble()
    {
        if (stealBubble.gameObject.activeSelf)
        {
            stealBubble.gameObject.SetActive(false);
            stealBubble.transform.DOKill();
            isFloating = false;
        }
    }

    public void UpdatePlantState(int plantSeedFlowerId, PlantState state, bool isPlayStateTransition = true, bool isClear = false)
    {
        if (isClear)//在动画和图片切换时候清空下
        {
            Clear();
        }
        plantVO.plantState = state;
        startTween = false;
        if (state == PlantState.State_null)//未种植
        {
            Clear();
            return;
        }
        if (MyselfModel.Instance.plantTween)
        {
            PlayPlantAni(plantSeedFlowerId, isPlayStateTransition);
        }
        else
        {
            if (state == PlantState.State_2)//成熟状态缩放0.6
            {
                plantSkin.transform.localScale = scale1;
            }
            else//其他状态缩放1
            {
                plantSkin.transform.localScale = Vector3.one;
            }
            plantSkin.SetTexture(ImageDataModel.Instance.GetFlowerStatusUrl(plantSeedFlowerId, (int)state, true), () =>
            {
                UpdatePos(plantSkin, state);
                if (state == PlantState.State_2)
                {
                    startTween = true;
                }
            });
        }
    }

    public void UpLock(PlantVO plantVO)
    {
        this.plantVO = plantVO;
        if (armatureComponen != null)
        {
            armatureComponen.AnimationState.Complete += OnAnimationEventHandler;
            armatureComponen.AnimationState.SetAnimation(0, "unlock", false);
        }
    }

    private void DropWater()
    {
        if (!waterSkin.gameObject.activeSelf) waterSkin.gameObject.SetActive(true);
        waterSkin.transform.DOLocalMoveY(0, 0.3f).From(0.4f).SetEase(Ease.InCubic);
    }

    private void OnAnimationEventHandler(TrackEntry trackEntry)
    {
        if (trackEntry.Animation.Name == "unlock")
        {
            armatureComponen.AnimationState.Complete -= OnAnimationEventHandler;
            armatureComponen.AnimationState.SetAnimation(0, "after", false);
        }
    }

    private void UpdatePos(SpriteRenderer spriteRenderer, PlantState state)
    {
        Vector2 spriteSize = spriteRenderer.bounds.size;
        if (state == PlantState.State_2)
        {
            spriteRenderer.transform.localPosition = new Vector3(0, 1.30f);
        }
        else
        {
            spriteRenderer.transform.localPosition = new Vector3(0, 1.19f);
        }
        //spriteRenderer.transform.localPosition = new Vector3(0, spriteSize.y / 2);
        //plantContainer.localPosition = new Vector3(-0.06f, (-spriteSize.y / 2) + 0.633f + 0.1f);
    }

    protected override void OnClick()
    {
        if (landId > 0)
        {
            var plantVO = PlantModel.Instance.GetPlantVo((uint)landId);
            if (plantVO != null)//已解锁
            {
                OnHandler();
            }
            else//未解锁
            {
                var tudi_configConfig = PlantModel.Instance.GetTudiConfig(landId);
                if (tudi_configConfig != null)
                {
                    if (!MyselfModel.Instance.CheckLevelMeet((uint)tudi_configConfig.UnlockLv, true))//等级不足
                    {
                        return;
                    }

                    UIManager.Instance.OpenWindow<UnLockWindow>("UnLockWindow", new OpenUnLockParam() { type = 0, id = landId });
                }
            }
        }
    }
    private void OnHandler()
    {
        if (plantVO.plantState == PlantState.State_null)//未种植
        {
            PlantModel.Instance.plantVO = plantVO;
            if (!PlantModel.Instance.isShowPlantUI)
            {
                if (GuideModel.Instance.IsGuiding && GuideModel.Instance.curConfigData.IndexId == 17)//如果当前引导的是种植，不要触发选花界面
                {
                    Debug.Log(2222);
                }
                else
                {
                    UIManager.Instance.ShowOrHideMainUI(false, true, true);
                }
                //if (GuideModel.Instance.IsGuiding)
                //{
                //    GuideController.Instance.NextGuide();
                //}
            }
            else//切换选择土地对象
            {

            }
        }
        else if (plantVO.plantState == PlantState.State_0)//幼苗种子期(未初灌)
        {
            PlantModel.Instance.plantVO = plantVO;
            if (GuideModel.Instance.IsGuiding && GuideModel.Instance.curConfigData.IndexId == 21)//如果当前引导的是浇水，不要触发浇水面板
            {
                //GuideController.Instance.NextGuide();
            }
            else
            {
                PlantOneKeyWatering(plantVO);
            }
        }
        else if (plantVO.plantState == PlantState.State_1)////成长中（加速/铲除）
        {
            if (watering.gameObject.activeSelf || plantVO.status <= 1) return;//浇水中不允许操作/首次不允许弹出操作面板
            PlantHander();
        }
        else if (plantVO.plantState == PlantState.State_2)
        {
            Harvest();
        }
    }

    /// <summary>
    /// 检测是否可偷花
    /// </summary>
    /// <returns></returns>
    public bool CheckStealEnable()
    {
        if (MyselfModel.Instance.atHome || plantVO == null || plantVO.plantState != PlantState.State_2) return false;
        if (plantVO.stealInfo.ContainsKey(MyselfModel.Instance.userId))//这块土地的花被自己偷过了不能再偷
        {
            return false;
        }
        var condition = FlowerHandbookModel.Instance.GetStaticSeedCondition((int)plantVO.flowerId);
        var canStealNum = PlantModel.Instance.GetStealCount((int)plantVO.flowerId, (int)plantVO.level);
        var baodi = PlantModel.Instance.GetPlantBaodi(condition.LevelMould, (int)plantVO.level);
        if (plantVO.harvestCount - canStealNum >= baodi && MyselfModel.Instance.CheckInterAction())
        {
            return true;
        }
        return false;
    }


    /// <summary>
    /// 土地清空
    /// </summary>
    public void Clear()
    {
        startTween = false;
        ClearTween();
        plantVO.plantState = PlantState.State_null;
        plantSkin.sprite = null;
        if (flowerArmatureComponen != null)
        {
            flowerArmatureComponen.gameObject.SetActive(false);
            flowerArmatureComponen = null;
        }
    }

    private void ResetState()
    {
        plantSkin.sprite = null;
        waterSkin.gameObject.SetActive(false);
        watering.gameObject.SetActive(false);
        stealBubble.gameObject.SetActive(false);
    }

    //protected override void OnLongPress()
    //{
    //    if (plantVO == null) return;
    //    if (plantVO.plantState == PlantState.State_0)
    //    {
    //        PlantOneKeyWatering();
    //    }
    //}
}
