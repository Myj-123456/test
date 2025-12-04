using DG.Tweening;
using FairyGUI;
using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using YooAsset;


/// <summary>
/// 饰品类型枚举
/// </summary>
public enum DecorationsType
{
    Null,//留空
    Floor,//地板
    Wall,//墙壁
    Counter,//收银柜台
    FlowerStand,//花台
    Sofa,//沙发
    Box,//柜子
    Handrail,//栏杆
    FloorLamp,//落地灯,
    LoftFloor,//阁楼地板
    LoftWall,//阁楼墙壁
    Stair = 98,//楼梯(前端自己使用)
    Roof = 99,//一楼屋顶(前端自己使用)
    LoftRoof = 100,//阁楼屋顶(前端自己使用)
    LoftHandrail = 101,//阁楼栏杆(前端自己使用)
    Loft = 102,//阁楼(前端自己使用)
    HuaJia = 103//花架(前端自己使用)
}

public class DecorationData
{
    public DecorationsType decorationsType;
    public string id;
}




/// <summary>
/// 装饰物
/// </summary>
public class Decoration : SceneObject
{
    [SerializeField]
    private SpriteRenderer skin;
    public DecorationsType decorationsType;
    public DecorationData decorationData;
    private bool isAddAnimation = false;

    public void UpdateSkin(DecorationData decorationData)
    {
        this.decorationData = decorationData;
        data = decorationData;
        sceneObjectType = SceneObjectType.Decoration;
        uint uintId;
        if (uint.TryParse(decorationData.id, out uintId))
        {
            SetObjectUid(uintId);
        }
        this.decorationsType = decorationData.decorationsType;
        UpdateSortingOrder();

        if (decorationsType == DecorationsType.Wall || decorationsType == DecorationsType.LoftWall)//墙壁采用多边形碰撞器
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            if ((uint)decorationsType >= 98)
            {
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }

        UpdateSprite(decorationData.id);

        if (decorationsType == DecorationsType.Counter)//柜台添加老板娘spine
        {
            if (!isAddAnimation)//避免重复添加动画
            {
                AddSpineAnimation("laobannian", "animation", new Vector3(-0.5f, -0.22f, 0), new Vector3(0.9f, 0.9f, 0.9f));
                isAddAnimation = true;
            }
        }
    }

    /// <summary>
    /// 添加spine动画
    /// </summary>
    private void AddSpineAnimation(string aniResName, string animationName, Vector3 pos, Vector3 scale)
    {
        AnimationHelper.CreateSpine(aniResName, transform, animationName, true, "ObjectLayer", (SkeletonAnimation armatureComponent) =>
        {
            armatureComponent.transform.localPosition = pos;
            if (scale != null)
            {
                armatureComponent.transform.localScale = scale;
            }
        });
    }

    private void UpdateSprite(string id)
    {
        var assetHandle = ResourceManager.Instance.LoadAssetAsync<Sprite>(ResPath.GetHomeDecorationPath(id));
        assetHandle.Completed += (AssetHandle handle) =>
        {
            skin.sprite = handle.AssetObject as Sprite;
            if (decorationsType == DecorationsType.Counter)
            {
                skin.GetComponent<BoxCollider2D>().offset = new Vector2(-0.1092081f, 0.1581929f);
                skin.GetComponent<BoxCollider2D>().size = new Vector2(3.361584f, 1.627143f);
            }
            else
            {
                if (decorationsType == DecorationsType.Wall || decorationsType == DecorationsType.LoftWall)//墙壁采取多边形碰撞器
                {
                    skin.gameObject.AddComponent<PolygonCollider2D>();
                }
                else
                {
                    if (decorationsType == DecorationsType.Floor || decorationsType == DecorationsType.LoftFloor)//地板尺寸调小点
                    {
                        var size = skin.size;
                        size.x -= 5;
                        size.y -= 2;
                        skin.GetComponent<BoxCollider2D>().size = size;
                    }
                    else
                    {
                        skin.GetComponent<BoxCollider2D>().size = skin.size;
                    }
                }
            }
        };
    }

    /// <summary>
    /// 层级控制
    /// </summary>
    private void UpdateSortingOrder()
    {
        var order = 0;
        var sortingLayerName = "ObjectLayer";
        switch (decorationsType)
        {
            case DecorationsType.Floor:
                sortingLayerName = "Default";
                order = -1;
                break;
            case DecorationsType.Wall:
                sortingLayerName = "Default";
                order = 1;
                break;
            case DecorationsType.Roof:
                sortingLayerName = "Default";
                order = 2;
                break;
            case DecorationsType.LoftFloor:
                sortingLayerName = "Default";
                order = 3;
                break;
            case DecorationsType.LoftWall:
                sortingLayerName = "Default";
                order = 4;
                break;
            case DecorationsType.LoftRoof:
                sortingLayerName = "Default";
                order = 5;
                break;
            case DecorationsType.FlowerStand:
                sortingLayerName = "Default";
                break;
        }
        skin.sortingLayerName = sortingLayerName;
        skin.sortingOrder = order;
    }

    protected override void OnClick()
    {
        if (decorationsType == DecorationsType.Counter)
        {
            if (!GuideModel.Instance.IsCancelGuide)
            {
                var taskData = TaskModel.Instance.mainTask;
                if (taskData != null)//如果当前有主线任务
                {
                    var taskInfo = TaskModel.Instance.GetTaskMainInfo((int)taskData.mainTaskId);
                    if (taskInfo != null && taskInfo.TaskType == 2)//如果是类型2 制作XXX花瓶的插花X个
                    {
                        //携带参数去打开
                        if (taskInfo.TypeParam > 0)//跳转指定花瓶插花
                        {
                            OpenIkeParam openIkeParam = new OpenIkeParam() { vaseId = taskInfo.TypeParam };
                            UIManager.Instance.OpenPanel<IkeView>(UIName.IkeView, UILayer.UI, openIkeParam);
                        }
                        else
                        {
                            UIManager.Instance.OpenPanel<IkeView>(UIName.IkeView);
                        }
                        return;
                    }
                }
            }
            UIManager.Instance.OpenPanel<IkeView>(UIName.IkeView);
        }
    }

    protected override void OnLongPress()
    {
        if (!MyselfModel.Instance.atHome) return;
        Debug.Log("家具长按");
        var type = (int)decorationsType;
        FlowerShopModel.Instance.floor = (uint)(type >= 9 ? 1 : 0);
        FlowerShopController.Instance.ShowFurnitureArrangement(type);
    }
}
