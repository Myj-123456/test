

using DG.Tweening;
using FairyGUI;
using protobuf.table;
using Spine;
using Spine.Unity;
using UnityEngine;


public class TableVo
{
    public uint deskId;
    public uint itemId;
    public uint count;
    public uint harvestTime;
    public uint expBuff;
    public uint goldBuff;
    public void ParseData(I_TABLE_VO tableVo)
    {
        deskId = tableVo.gridId;
        itemId = tableVo.itemId;
        count = tableVo.count;
        harvestTime = tableVo.harvestTime;
        expBuff = tableVo.expBuff;
        goldBuff = tableVo.goldBuff;
    }
}

public class FlowerStandData : DecorationData
{
    public int deskId;
    public TableVo tableVo;
}

/// <summary>
/// 花台
/// </summary>
public class FlowerStand : Decoration
{
    [SerializeField]
    private UIPanel imgGold;
    [SerializeField]
    private UIPanel ike;
    [SerializeField]
    private GameObject imgSelect;
    [SerializeField]
    private GameObject imgJiaHua;

    public FlowerStandData flowerStandData;
    private SkeletonAnimation armatureComponen;
    private bool isUnLock = false;
    private float originalY = 0;
    private int showGoldNum = 0;


    public void UpdateSkin(FlowerStandData flowerStandData)
    {
        this.flowerStandData = flowerStandData;
        UpdateSkin(flowerStandData as DecorationData);
        UpdateUnLockStatus();
    }

    private void UpdateUnLockStatus()
    {
        ResetState();
        isUnLock = flowerStandData.tableVo != null;
        if (!isUnLock)//未解锁
        {
            if (armatureComponen == null)
            {
                AnimationHelper.CreateSpine("wudisuo", transform, "", false, "ObjectLayer", (SkeletonAnimation armatureComponent) =>
                {
                    armatureComponen = armatureComponent;
                    var renderer = armatureComponent.GetComponent<Renderer>().sortingOrder = 8;//TODO:比FlowerStand层级+1就行，暂定写死 
                    armatureComponen.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                    armatureComponen.transform.localPosition = new Vector3(-0.06f, 0.42f, 0f);
                    armatureComponent.AnimationState.SetAnimation(0, "befor", true);
                });
            }
            else
            {
                armatureComponen.AnimationState.SetAnimation(0, "befor", true);
            }
        }
        else
        {
            if (armatureComponen != null)
            {
                Destroy(armatureComponen.gameObject);
                armatureComponen = null;
            }
            UpdateFlower();
        }
    }

    /// <summary>
    /// 提供外部选择显示花接口
    /// </summary>
    /// <param name="itemId"></param>
    public void ShowSelectFlower(int itemId)
    {
        if (flowerStandData.tableVo == null || flowerStandData.tableVo.itemId > 0) return;
        var isShow = itemId > 0;
        ike.gameObject.SetActive(isShow);
        if (isShow)
        {
            var flowerTableItem = ike.ui as fun_Scene.FlowerTableItem;
            flowerTableItem.txxTime.visible = false;
            UIExt_ikeImg.LoadIkeByItemId((flowerTableItem.ike as common_New.ikeImg), itemId, false);
        }
    }

    public void Select(bool isSelect)
    {
        imgSelect.SetActive(isSelect);
    }

    public void ShowJiaHua(bool isShow)
    {
        if (FlowerSellModel.Instance.isSelectFlowerShelfing)//选花编辑时候不要操作
        {
            return;
        }
        if (!MyselfModel.Instance.atHome || !isUnLock || imgGold.gameObject.activeSelf || (flowerStandData.tableVo != null && flowerStandData.tableVo.itemId > 0))//显示金币或者未解锁
        {
            imgJiaHua.SetActive(false);
            imgJiaHua.transform.DOKill();
            return;
        }
        imgJiaHua.SetActive(isShow);
        if (isShow)
        {
            var pos = imgJiaHua.transform.localPosition;
            pos.y = 0.48f;
            imgJiaHua.transform.localPosition = pos;
            TweenUtil.FloatAnimation(imgJiaHua.transform);
        }
        else
        {
            imgJiaHua.transform.DOKill();
        }
    }


    /// <summary>
    /// 更新摆台上的花
    /// </summary>
    public void UpdateFlower()
    {
        if (flowerStandData.tableVo.itemId > 0)//插花id，表示摆台上有花
        {
            ShowJiaHua(false);
            if (ServerTime.Time >= flowerStandData.tableVo.harvestTime)//可领取奖励
            {
                ShowGold();
            }
            else
            {
                ike.gameObject.SetActive(true);
                var flowerTableItem = ike.ui as fun_Scene.FlowerTableItem;
                flowerTableItem.txxTime.visible = true;
                UIExt_ikeImg.LoadIkeByItemId((flowerTableItem.ike as common_New.ikeImg), (int)flowerStandData.tableVo.itemId, false);
                StartCountDown();
            }
        }
        else
        {
            ResetState();
            ShowJiaHua(true);
        }
    }

    private void ResetState()
    {
        if (!FlowerSellModel.Instance.isSelectFlowerShelfing)//在选花上架时候不要隐藏掉
        {
            ike.gameObject.SetActive(false);
        }
        HidewGold();
        ShowJiaHua(false);
    }

    private CountDownTimer countDownTimer;
    /// <summary>
    /// 上架之后开始倒计时
    /// </summary>
    private void StartCountDown()
    {
        var leftTime = flowerStandData.tableVo.harvestTime - ServerTime.Time;
        var flowerTableItem = ike.ui as fun_Scene.FlowerTableItem;
        if (countDownTimer != null)
        {
            countDownTimer.Clear();
            countDownTimer = null;
        }
        countDownTimer = new CountDownTimer(flowerTableItem.txxTime, (int)leftTime);
        countDownTimer.CompleteCallBacker = () =>//到时间显示收获金币
        {
            ShowGold();
        };
    }
    public void UpLock(TableVo tableVo)
    {
        flowerStandData.tableVo = tableVo;
        isUnLock = true;
        ShowJiaHua(true);
        if (armatureComponen != null)
        {
            armatureComponen.AnimationState.Complete += OnAnimationEventHandler;
            armatureComponen.AnimationState.SetAnimation(0, "unlock", false);
        }
    }

    private void OnAnimationEventHandler(TrackEntry trackEntry)
    {
        if (trackEntry.Animation.Name == "unlock")
        {
            armatureComponen.AnimationState.Complete -= OnAnimationEventHandler;
            Destroy(armatureComponen.gameObject);
            armatureComponen = null;
        }
    }

    protected override void OnClick()
    {
        if (!isUnLock)
        {
            var tabelConfig = FlowerSellModel.Instance.GetTabelConfig(flowerStandData.deskId);
            if (!MyselfModel.Instance.CheckLevelMeet((uint)tabelConfig.UnlockLv, true))//等级不足
            {
                return;
            }
            UIManager.Instance.OpenWindow<UnLockWindow>("UnLockWindow", new OpenUnLockParam() { type = 1, id = flowerStandData.deskId });
        }
        else
        {
            if (flowerStandData.tableVo.itemId <= 0)//未插花
            {
                SceneManager.Instance.ShowHideHeroAvatar(false);
                //NpcManager.Instance.HideAllNpc();
                SceneManager.Instance.ShowHideAllDeskAddFlower(false);
                FlowerSellModel.Instance.isSelectFlowerShelfing = true;
                FlowerSellModel.Instance.selectDeskId = flowerStandData.deskId;
                FlowerSellModel.Instance.orthoSize = Camera.main.orthographicSize;
                FlowerSellModel.Instance.cameraPos = Camera.main.transform.position;
                UIManager.Instance.OpenPanel<FlowerSellWindow>(UIName.FlowerSellWindow, UILayer.UI, flowerStandData.tableVo.deskId);
                SelectThis();
            }
            else//已插花 
            {
                if (imgGold.gameObject.activeSelf)//领取金币
                {
                    FlowerSellController.Instance.ReqSellFlowerReward(flowerStandData.tableVo.deskId, showGoldNum);
                }
                else//显示倒计时
                {

                }
            }

        }
    }

    public void SelectThis()
    {
        if (FlowerSellModel.Instance.isSelectFlowerShelfing)
        {
            var pos = transform.position;
            pos.y -= 0.91f;//位置y坐标偏移上点
            DOTween.Kill(Camera.main);
            SceneManager.Instance.MoveToPoint(pos, 0.3f, false);
            SceneManager.Instance.TweenCameraOrthoSize(4, 0.3f, () =>
            {
                if (FlowerSellModel.Instance.isSelectFlowerShelfing)
                {
                    Select(true);
                }
            });
        }
    }
    private void ShowGold()
    {
        if (!MyselfModel.Instance.atHome)//非己方不看到金币
        {
            HidewGold();
            return;
        }
        ike.gameObject.SetActive(false);
        imgGold.gameObject.SetActive(true);
        var flowerTableIGoldItem = imgGold.ui as fun_Scene.FlowerTableIGoldItem;

        var price = IkeModel.Instance.GetFormulaPrice1((int)flowerStandData.tableVo.itemId);
        var formula = IkeModel.Instance.GetFormulaByItemId((int)flowerStandData.tableVo.itemId);

        var sunCount = Mathf.Ceil(flowerStandData.tableVo.count * formula.SellPrice);//之前旧的是向下取整，现在改为向上取整
        var rate = flowerStandData.tableVo.goldBuff / 100f + 1;//buff
        sunCount = Mathf.Ceil(sunCount * rate);
        int videoDoubleRate = MyselfModel.Instance.IsVideoDouble() ? 2 : 1;
        sunCount *= videoDoubleRate;
        showGoldNum = (int)sunCount;
        flowerTableIGoldItem.txtNum.text = sunCount.ToString();

        if (originalY == 0) originalY = imgGold.transform.localPosition.y;
        FloatAnimation();
    }


    private void FloatAnimation()
    {
        TweenUtil.FloatAnimation(imgGold.transform);
    }
    private void HidewGold()
    {
        if (imgGold.gameObject.activeSelf)
        {
            imgGold.gameObject.SetActive(false);
            imgGold.transform.DOKill();
            if (originalY != 0)
            {
                imgGold.transform.localPosition = new Vector3(imgGold.transform.localPosition.x, originalY, 0);//重置位置
            }
        }
    }
}
