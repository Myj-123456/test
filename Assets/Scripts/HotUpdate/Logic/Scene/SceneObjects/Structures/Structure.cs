using DG.Tweening;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using YooAsset;

/// <summary>
/// 建筑数据类
/// </summary>
public class StructureData
{
    //public StaticStructureCusData staticStructureCusData;//静态配置 到时候直接读取配置表生成的类就行了
    public int buildingDefId;
    public int cutRibbon;
    public int decorId;
    public long effectiveTime;
    public int orient;
    public int status;
    public int userId;
    public Vector3 pos;
}

/// <summary>
/// 建筑
/// </summary>
public class Structure : SceneObject
{
    [SerializeField]
    private SpriteRenderer image;
    [SerializeField]
    private FairyGUI.UIPanel uiPanel;
    [SerializeField]
    private FairyGUI.UIPanel water_pro;

    private StructureData structureData;

    private CountDownTimer timer;
    public void UpdateSkin(StructureData structureData)
    {
        this.structureData = structureData;
        sceneObjectType = SceneObjectType.Structure;
        SetObjectUid((uint)structureData.buildingDefId);
        data = structureData;
        AssetHandle assetHandle = ResourceManager.Instance.LoadAssetAsync<Sprite>(ResPath.GetStructurePath(structureData.buildingDefId.ToString()));
        assetHandle.Completed += (AssetHandle handle) =>
        {
            image.sprite = assetHandle.AssetObject as Sprite;
            if (structureData.buildingDefId == 29000012)
            {
                image.GetComponent<BoxCollider2D>().offset = new Vector2(0f, 5);
                image.GetComponent<BoxCollider2D>().size = new Vector2(7, 7);
            }
            else if (structureData.buildingDefId == 29000002)
            {
                image.GetComponent<BoxCollider2D>().offset = new Vector2(0f, 1);
                image.GetComponent<BoxCollider2D>().size = new Vector2(5, 5);
            }
            else if (structureData.buildingDefId == 29000007)
            {
                image.GetComponent<BoxCollider2D>().offset = new Vector2(0f, 0f);
                image.GetComponent<BoxCollider2D>().size = new Vector2(5, 5);
            }
            else
            {
                image.GetComponent<BoxCollider2D>().size = image.size;//后面这个点击范围支持配置
            }
            if (structureData.buildingDefId == 29000008)
            {
                uiPanel.gameObject.SetActive(true);
                UpdateSceneOrderUI();
            }
        };

        if (structureData.buildingDefId == 29000013)
        {
            AddSpineAnimation("xiaoxiongmao", "idle", new Vector3(2.95f, -2.09f, 0), new Vector3(0.5f, 0.5f, 1));
        }
        if (structureData.buildingDefId == 29000016)
        {
            image.enabled = false;
            AddSpineAnimation("shuijin", "animation", Vector3.zero);
            BucketManager.Instance.InitBucket(transform);
            UpdateWaterPro();
        }
        if (structureData.buildingDefId == 29000009 && DrawModel.Instance.isMonth_DrawActive)//抽卡添加动画 每月都不一样 有时限限制 限制时候不可见
        {
            var activityId = DrawModel.Instance.GetActivityId(ActivityType.Month_Draw);
            var reward = DrawModel.Instance.GetBigItem(activityId);
            if (reward != null)
            {
                var itemDefId = reward.ItemDefId;
                AddSpineAnimation("flowers/40011110", "step_3_idle", new Vector3(0f, -0.29f, 0), new Vector3(0.6f, 0.6f, 1));
            }
        }
        if (structureData.buildingDefId == 29000012)//树特殊点 需要按照轴心点去排序
        {
            image.spriteSortPoint = SpriteSortPoint.Pivot;
            AddSpineAnimation("huli", "animation", new Vector3(0.47f, 2.8f, 0));
        }
        else
        {
            image.spriteSortPoint = SpriteSortPoint.Center;
        }
    }
    private void UpdateMonthDraw()
    {

    }


    /// <summary>
    /// 添加spine动画
    /// </summary>
    private void AddSpineAnimation(string aniResName, string animationName, Vector3 pos, Vector3? scale = null)
    {
        AnimationHelper.CreateSpine(aniResName, transform, animationName, true, "", (SkeletonAnimation armatureComponent) =>
        {
            armatureComponent.transform.localPosition = pos;
            armatureComponent.transform.localScale = scale == null ? Vector3.one : (Vector3)scale;
        });
    }

    /// <summary>
    /// 更新自己小黑板订单
    /// </summary>
    public void UpdateSceneOrderUI()
    {
        if (!uiPanel.gameObject.activeSelf) return;
        var orderUI = uiPanel.ui as fun_Scene.SceneOrderUI;
        var count = orderUI.numChildren;
        for (var i = 1; i <= count; i++)
        {
            var orderVo = FlowerOrderModel.Instance.GetOrderVo((uint)i);
            UpdateOderItemState(orderUI.GetChildAt(i - 1) as fun_Scene.SceneOrderItem, orderVo);
        }
    }

    /// <summary>
    /// 更新访问好友的小黑板订单(好友显示默认状态 不可提交)
    /// </summary>
    public void UpdateVistFriendOrderUI()
    {
        if (!uiPanel.gameObject.activeSelf) return;
        var orderUI = uiPanel.ui as fun_Scene.SceneOrderUI;
        var count = orderUI.numChildren;
        for (var i = 1; i <= count; i++)
        {
            var item = orderUI.GetChildAt(i - 1) as fun_Scene.SceneOrderItem;
            item.visible = true;
            item.c1.selectedIndex = 0;
        }
    }

    private void UpdateOderItemState(fun_Scene.SceneOrderItem item, protobuf.order.I_ORDER_VO orderVo)
    {
        item.visible = orderVo != null;
        if (item.visible)
        {
            if (orderVo.cdTime > ServerTime.Time)//cd中
            {
                item.c1.selectedIndex = 2;
            }
            else
            {
                var enough = FlowerOrderModel.Instance.GetIsEnoughByPosition(orderVo.position);
                if (enough)//可提交
                {
                    item.c1.selectedIndex = 1;
                }//不可提交
                else
                {
                    item.c1.selectedIndex = 0;
                }
            }
        }
    }


    protected override void OnClick()
    {
        if (structureData.buildingDefId == 29000007)//服装
        {
            if (!GlobalModel.Instance.GetUnlocked(SysId.DressShop, true))
            {
                return;
            }
            UIManager.Instance.OpenPanel<DressShopView>(UIName.DressShopView);
        }
        else if (structureData.buildingDefId == 29000008)//订单小黑板
        {
            FlowerOrderController.Instance.ShowView();
        }
        else if (structureData.buildingDefId == 29000002)//培育花房
        {
            UIManager.Instance.OpenPanel<CultivationView>(UIName.CultivationView);
        }
        else if (structureData.buildingDefId == 29000005)//好友交易
        {
            if (!GlobalModel.Instance.GetUnlocked(SysId.FriendTrade, true))
            {
                return;
            }
            UIManager.Instance.OpenPanel<TradeWindow>(UIName.TradeWindow);
        }
        else if (structureData.buildingDefId == 29000009)//玲珑球
        {
            if (DrawModel.Instance.isMonth_DrawActive)
            {
                if (GlobalModel.Instance.GetUnlocked(SysId.MonthDraw, true))
                {
                    UIManager.Instance.OpenPanel<DrawMainView>(UIName.DrawMainView, UILayer.UI, 0);
                }
            }
        }
        else if (structureData.buildingDefId == 29000011)//邮件
        {
            if (!GlobalModel.Instance.GetUnlocked(SysId.Mail, true))
            {
                return;
            }
            UIManager.Instance.OpenWindow<MailWindow>(UIName.MailWindow);
        }
        else if (structureData.buildingDefId == 29000012)//小萝莉npc收集
        {
            if (!GlobalModel.Instance.GetUnlocked(SysId.NpcCollect, true))
            {
                return;
            }
            UIManager.Instance.OpenWindow<NpcCollectWindow>(UIName.NpcCollectWindow);
        }
        else if (structureData.buildingDefId == 29000013)//花市订单
        {
            if (!GlobalModel.Instance.GetUnlocked(SysId.BigOrder))
            {
                ADK.UILogicUtils.ShowNotice(Lang.GetValue("MarketOrder_txt6"));
                return;
            }
            FlowerOrderModel.Instance.orthoSize = Camera.main.orthographicSize;
            FlowerOrderModel.Instance.cameraPos = Camera.main.transform.position;
            UIManager.Instance.OpenPanel<OrderFlowerWindow>(UIName.OrderFlowerWindow);
            SelectThis();
        }
        else if (structureData.buildingDefId == 29000010)//热气球
        {
            if (!GlobalModel.Instance.GetUnlocked(SysId.Adventure, true))
            {
                return;
            }
            //AdventureController.Instance.GoAdventure();
            //UIManager.Instance.OpenPanel<TourMapView>(UIName.TourMapView);
        }
        else if (structureData.buildingDefId == 29000015)//公会
        {
            if (!GlobalModel.Instance.GetUnlocked(SysId.Guild, true))
            {
                return;
            }
            var guild = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_GUILD_ID);
            if (guild == null || guild.info == "" || guild.info == "0")
            {
                UIManager.Instance.OpenWindow<GuildJoinWindow>(UIName.GuildJoinWindow);
            }
            else
            {
                UIManager.Instance.OpenPanel<GuildMainView>(UIName.GuildMainView);
            }
        }
        else if (structureData.buildingDefId == 29000016)//水井
        {
            UIManager.Instance.OpenWindow<DianWaterWindow>(UIName.DianWaterWindow);
        }
        else if (structureData.buildingDefId == 29000017)//钓鱼台
        {
            if (!GlobalModel.Instance.GetUnlocked(SysId.Rob, true))
            {
                return;
            }
            UIManager.Instance.OpenWindow<RobWindow>(UIName.RobWindow);
        }
    }
    public void UpdateWaterPro()
    {
        if (structureData.buildingDefId == 29000016 && MyselfModel.Instance.welfareInfo.waterBucketTime != 0 && (MyselfModel.Instance.behaviorDaily.waterBucketCnt + GetHaveBucket()) < GlobalModel.Instance.module_profileConfig.bucketMaxDay)
        {
            var isMax = true;
            var endTime = GetEndTime();
            BucketManager.Instance.UpdateBucket();
            foreach (var value in MyselfModel.Instance.waterBucketSeries)
            {
                if(value == 0)
                {
                    isMax = false;
                    break;
                }
            }
            if (!isMax)
            {
                water_pro.gameObject.SetActive(true);
                (water_pro.ui as fun_Scene.water_pro1).max = GlobalModel.Instance.module_profileConfig.bucketRecoverCD;
                (water_pro.ui as fun_Scene.water_pro1).value = GlobalModel.Instance.module_profileConfig.bucketRecoverCD - endTime;
                (water_pro.ui as fun_Scene.water_pro1).TweenValue(GlobalModel.Instance.module_profileConfig.bucketRecoverCD, endTime).SetEase(FairyGUI.EaseType.Linear).OnComplete(()=> {
                    UpdateWaterPro();
                    Debug.Log("生成了水桶：" + ServerTime.Time);
                });
                
            }
            else
            {
                water_pro.gameObject.SetActive(false);

            }
        }
        else
        {
            water_pro.gameObject.SetActive(false);
        }
    }

    private int GetEndTime()
    {
        var endTime = ServerTime.Time - MyselfModel.Instance.welfareInfo.waterBucketTime;
        if (endTime >= GlobalModel.Instance.module_profileConfig.bucketRecoverCD)
        {
            var num = endTime / GlobalModel.Instance.module_profileConfig.bucketRecoverCD;
            for(int i = 0;i < MyselfModel.Instance.waterBucketSeries.Count; i++)
            {
                if(MyselfModel.Instance.waterBucketSeries[i] == 0)
                {
                    MyselfModel.Instance.waterBucketSeries[i] = 1;
                    num--;
                }
                if(num <= 0)
                {
                    break;
                }
            }
            var time = (int)endTime % GlobalModel.Instance.module_profileConfig.bucketRecoverCD;
            MyselfModel.Instance.welfareInfo.waterBucketTime = ServerTime.Time - (uint)time;
            return GlobalModel.Instance.module_profileConfig.bucketRecoverCD - time;
        }
        else
        {
            return GlobalModel.Instance.module_profileConfig.bucketRecoverCD - (int)endTime;
        }

    }

    public int GetHaveBucket()
    {
        var num = 0;
        for (int i = 0; i < MyselfModel.Instance.waterBucketSeries.Count; i++)
        {
            if (MyselfModel.Instance.waterBucketSeries[i] == 1)
            {
                num++;
            }
            
        }
        return num;
    }
    public void SelectThis()
    {
        var pos = transform.position;
        pos.y += 4.97f;
        DOTween.Kill(Camera.main);
        SceneManager.Instance.MoveToPoint(pos, 0.3f, false);
        SceneManager.Instance.TweenCameraOrthoSize(11f, 0.3f, () =>
        {

        });
    }

}
