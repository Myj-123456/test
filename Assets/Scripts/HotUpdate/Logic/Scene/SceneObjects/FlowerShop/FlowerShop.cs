
using protobuf.table;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YooAsset;
/// <summary>
/// 花店
/// </summary>
public class FlowerShop
{
    private Transform home;

    private Dictionary<string, Decoration> decorationDic = new Dictionary<string, Decoration>();
    private Dictionary<uint, FlowerStand> tableDic = new Dictionary<uint, FlowerStand>();
    private uint level = 1;//花店等级
    private const string Roof1 = "roof1";//一楼屋顶
    private const string Roof2 = "roof2";//二楼屋顶

    public FlowerShop(Transform home)
    {
        this.home = home;
        AddEvent();
    }

    public void Init()
    {
        if (MyselfModel.Instance.atHome)
        {
            UpdateFurnitures(FlowerShopModel.Instance.furnitureDataDic);
        }
        else
        {
            UpdateFurnitures(VisitFriendModel.Instance.furnitureDataDic);
        }

    }

    public void UpdateFurnitures(Dictionary<int, Dictionary<int, FurnitureData>> furnitures)
    {
        foreach (KeyValuePair<int, Dictionary<int, FurnitureData>> kv in furnitures)
        {
            foreach (KeyValuePair<int, FurnitureData> kv2 in kv.Value)
            {
                var furnitureId = kv2.Value.id;
                var furnitureConfig = FlowerShopModel.Instance.GetFurniture(furnitureId);
                if (furnitureConfig != null)
                {
                    var type = (DecorationsType)furnitureConfig.Type;
                    if (type == DecorationsType.Floor)//地板
                    {
                        InitFloor(furnitureId);
                    }
                    else if (type == DecorationsType.Wall)//墙壁
                    {
                        InitWall(furnitureId);
                    }
                    else if (type == DecorationsType.Counter)//柜台
                    {
                        InitCounter(furnitureId);
                    }
                    else if (type == DecorationsType.FlowerStand)//花台
                    {
                        InitFlowerStands(furnitureId);
                    }
                    else if (type == DecorationsType.FloorLamp)//落地灯
                    {
                        InitFloorLamp(furnitureId);
                    }
                    else if (type == DecorationsType.Sofa)//沙发
                    {
                        InitSofa(furnitureId);
                    }
                    else if (type == DecorationsType.Handrail)//栏杆
                    {
                        InitHandrail(furnitureId);
                    }
                    else if (type == DecorationsType.Box)//柜子
                    {
                        InitBox(furnitureId);
                    }
                    else if (type == DecorationsType.LoftFloor)//阁楼地板
                    {
                        InitLoftFloor(furnitureId);
                    }
                    else if (type == DecorationsType.LoftWall)//阁楼墙壁
                    {
                        InitLoftWall(furnitureId);
                    }
                }
            }
        }
    }

    /// <summary>
    /// 更新一组家具(这个接口用来更新基础套装家具)
    /// </summary>
    public void UpdateFurnitures(int[] furnitures)
    {
        foreach (var furnitureId in furnitures)
        {
            UpdateFurniture(furnitureId);
        }
    }
    /// <summary>
    /// 更新一个家具
    /// </summary>
    public void UpdateFurniture(int furnitureId)
    {
        var furnitureConfig = FlowerShopModel.Instance.GetFurniture(furnitureId);
        if (furnitureConfig != null)
        {
            var type = (DecorationsType)furnitureConfig.Type;
            if (type == DecorationsType.Floor)//地板
            {
                InitFloor(furnitureId);
            }
            else if (type == DecorationsType.Wall)//墙壁
            {
                InitWall(furnitureId);
            }
            else if (type == DecorationsType.Counter)//柜台
            {
                InitCounter(furnitureId);
            }
            else if (type == DecorationsType.FlowerStand)//花台
            {
                InitFlowerStands(furnitureId);
            }
            else if (type == DecorationsType.FloorLamp)//落地灯
            {
                InitFloorLamp(furnitureId);
            }
            else if (type == DecorationsType.Sofa)//沙发
            {
                InitSofa(furnitureId);
            }
            else if (type == DecorationsType.Handrail)//栏杆
            {
                InitHandrail(furnitureId);
            }
            else if (type == DecorationsType.Box)//柜子
            {
                InitBox(furnitureId);
            }
            else if (type == DecorationsType.LoftFloor)//阁楼地板
            {
                InitLoftFloor(furnitureId);
            }
            else if (type == DecorationsType.LoftWall)//阁楼墙壁
            {
                InitLoftWall(furnitureId);
            }
        }
    }

    private void AddEvent()
    {
        EventManager.Instance.AddEventListener<TableVo>(FloweSellEvent.TABLE_UNLOCK, OnUnLockTable);
        EventManager.Instance.AddEventListener<uint>(FloweSellEvent.OnShelfFlower, OnShelfFlower);
        EventManager.Instance.AddEventListener<uint>(FloweSellEvent.SellFlowerReward, SellFlowerReward);
        EventManager.Instance.AddEventListener<uint, int>(FloweSellEvent.ShowStandFlower, ShowSelectFlower);
        EventManager.Instance.AddEventListener<int>(FloweSellEvent.SwitchFlowerStand, SwitchFlowerStand);
    }

    private void RemoveEvent()
    {
        EventManager.Instance.RemoveEventListener<TableVo>(FloweSellEvent.TABLE_UNLOCK, OnUnLockTable);
        EventManager.Instance.RemoveEventListener<uint>(FloweSellEvent.OnShelfFlower, OnShelfFlower);
        EventManager.Instance.RemoveEventListener<uint>(FloweSellEvent.SellFlowerReward, SellFlowerReward);
        EventManager.Instance.RemoveEventListener<uint, int>(FloweSellEvent.ShowStandFlower, ShowSelectFlower);
        EventManager.Instance.RemoveEventListener<int>(FloweSellEvent.SwitchFlowerStand, SwitchFlowerStand);
    }

    //地板
    private void InitFloor(int furnitureId)
    {
        InitDecoration(DecorationsType.Floor, furnitureId.ToString(), new Vector2(3.04f, 6.94f));
        InitStair("stair1");
    }

    //墙壁
    private void InitWall(int furnitureId)
    {
        InitDecoration(DecorationsType.Wall, furnitureId.ToString(), new Vector2(2.58f, 11.31f));
        //InitRoof(Roof1);//花店一楼屋顶
        InitLoft();
        InitHuaJia();
    }

    //初始化阁楼
    private void InitLoft()
    {
        InitDecoration(DecorationsType.Loft, "loft", new Vector2(3.02f, 14.61f));
    }

    /// <summary>
    /// 初始化花架
    /// </summary>
    private void InitHuaJia()
    {
        InitDecoration(DecorationsType.HuaJia, "huajia", new Vector2(-8.78f, 6.2f));
    }

    private void InitRoof(string roof)
    {
        InitDecoration(DecorationsType.Roof, roof, new Vector2(2.2f, 15.46f));
    }

    private void InitLoftRoof(string roof)
    {
        InitDecoration(DecorationsType.LoftRoof, roof, new Vector2(0f, 21.79f));
    }

    private void InitLoftHandrail(string loftHandrail)
    {
        InitDecoration(DecorationsType.LoftHandrail, loftHandrail, new Vector2(-4.89f, 15.14f));
        InitDecoration(DecorationsType.LoftHandrail, loftHandrail, new Vector2(-3.14f, 14.15f));

        InitDecoration(DecorationsType.LoftHandrail, loftHandrail, new Vector2(-0.79f, 13.87f), true);
        InitDecoration(DecorationsType.LoftHandrail, loftHandrail, new Vector2(1.1f, 14.88f), true);
        InitDecoration(DecorationsType.LoftHandrail, loftHandrail, new Vector2(2.96f, 15.9f), true);
        InitDecoration(DecorationsType.LoftHandrail, loftHandrail, new Vector2(5.64f, 16.34f), true);
    }

    /// <summary>
    /// 升级接口
    /// </summary>
    /// <param name="level"></param>
    public void ChangeLevel(uint level)
    {
        this.level = level;
        Init();
    }

    //台阶 需要跟随地板换 一个地板对应一个台阶 到时候需要做一个映射关系 单独是前端的配置 key(地板id=>楼梯id) 让策划去配置下
    private void InitStair(string stair)
    {
        ////左台阶
        //InitDecoration(DecorationsType.Stair, stair, new Vector2(-3.66f, 4.03f), false);
        //右台阶
        InitDecoration(DecorationsType.Stair, stair, new Vector2(9.63f, 4.3f), true);
    }


    //栏杆
    private void InitHandrail(int furnitureId)
    {
        //左上
        InitDecoration(DecorationsType.Handrail, furnitureId.ToString(), new Vector2(-1.424f, 2.543f));
        //右下
        InitDecoration(DecorationsType.Handrail, furnitureId.ToString(), new Vector2(4.89f, 2.54f), true);
        //右下2
        InitDecoration(DecorationsType.Handrail, furnitureId.ToString(), new Vector2(13.451f, 7.181f), true, 1);
    }

    private void InitCounter(int furnitureId)
    {
        InitDecoration(DecorationsType.Counter, furnitureId.ToString(), new Vector2(-5.32f, 7.11f));
    }

    private void InitFlowerStands(int furnitureId)
    {
        InitInsideFlowerStands(furnitureId);
        InitOutsideFlowerStands(furnitureId);
    }

    //初始化左边三个花台
    private void InitInsideFlowerStands(int furnitureId)
    {
        InitFlowerStand(DecorationsType.FlowerStand, furnitureId.ToString(), new Vector2(2.56f, 7.24f), 1);
        InitFlowerStand(DecorationsType.FlowerStand, furnitureId.ToString(), new Vector2(1.04f, 6.44f), 2);
        InitFlowerStand(DecorationsType.FlowerStand, furnitureId.ToString(), new Vector2(-0.41f, 5.690001f), 3);
    }

    //初始化右边三个花台
    private void InitOutsideFlowerStands(int furnitureId)
    {
        InitFlowerStand(DecorationsType.FlowerStand, furnitureId.ToString(), new Vector2(4.14f, 6.28f), 4);
        InitFlowerStand(DecorationsType.FlowerStand, furnitureId.ToString(), new Vector2(2.7f, 5.47f), 5);
        InitFlowerStand(DecorationsType.FlowerStand, furnitureId.ToString(), new Vector2(1.25f, 4.83f), 6);
    }

    //百宝格
    private void InitBox(int furnitureId)
    {
        InitDecoration(DecorationsType.Box, furnitureId.ToString(), new Vector2(4.91f, 12.766f));
    }
    //沙发
    private void InitSofa(int furnitureId)
    {
        InitDecoration(DecorationsType.Sofa, furnitureId.ToString(), new Vector2(7.97f, 9.635f));
    }


    /// <summary>
    /// 初始化落地灯
    /// </summary>
    private void InitFloorLamp(int furnitureId)
    {
        InitDecoration(DecorationsType.FloorLamp, furnitureId.ToString(), new Vector2(12.276f, 7.897f));
    }

    /// <summary>
    /// 阁楼地板
    /// </summary>
    /// <param name="furnitureId"></param>
    private void InitLoftFloor(int furnitureId)
    {
        InitDecoration(DecorationsType.LoftFloor, furnitureId.ToString(), new Vector2(0f, 16.05f));
    }

    /// <summary>
    /// 阁楼地板
    /// </summary>
    /// <param name="furnitureId"></param>
    private void InitLoftWall(int furnitureId)
    {
        InitDecoration(DecorationsType.LoftWall, furnitureId.ToString(), new Vector2(0.28f, 19.09f));
        InitLoftRoof(Roof2);//花店一楼屋顶
        InitLoftHandrail("langan");
    }


    /// <summary>
    /// 初始化一个装饰
    /// </summary>
    /// <param name="id"></param>
    /// <param name="pos"></param>
    private void InitDecoration(DecorationsType decorationsType, string id, Vector2 pos, bool isFlipX = false, uint ind = 0)
    {
        CoroutineInitDecoration(decorationsType, id, pos, isFlipX, ind);
    }

    private void CoroutineInitDecoration(DecorationsType decorationsType, string id, Vector2 pos, bool isFlipX = false, uint ind = 0)
    {
        var key = decorationsType.ToString() + "_" + isFlipX.ToString() + ind;//采取家具类型和是否翻转拼接做唯一key;
        var decoration = GetDecoration(key);
        if (decoration != null)
        {
            if (decoration.decorationData != null)
            {
                decoration.decorationData.id = id;
                decoration.UpdateSkin(decoration.decorationData);
                decoration.gameObject.SetActive(true);
                decoration.transform.localPosition = pos;
            }
            return;
        }
        DecorationData decorationData = new DecorationData();
        decorationData.decorationsType = decorationsType;
        decorationData.id = id;
        var assetHandle = ResourceManager.Instance.LoadAssetAsync<GameObject>(ResPath.GetPrefabPath("HomeDecoration/Furniture"));
        assetHandle.Completed += (AssetHandle handle) =>
        {
            GameObject furnitureGameObject = assetHandle.InstantiateSync();
            var decoration = furnitureGameObject.GetComponent<Decoration>();
            decoration.UpdateSkin(decorationData);
            furnitureGameObject.transform.SetParent(home, false);
            furnitureGameObject.transform.localPosition = pos;
            if (isFlipX)
            {
                furnitureGameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            if (!decorationDic.ContainsKey(key))
            {
                decorationDic.Add(key, decoration);
            }
            SceneManager.Instance.AddSceneObject(decoration);
        };
    }
    /// <summary>
    /// 初始化一个装饰
    /// </summary>
    /// <param name="id"></param>
    /// <param name="pos"></param>
    private void InitFlowerStand(DecorationsType decorationsType, string id, Vector2 pos, int deskId)
    {
        CoroutineInitFlowerStand(decorationsType, id, pos, deskId);
    }

    private void CoroutineInitFlowerStand(DecorationsType decorationsType, string id, Vector2 pos, int deskId)
    {
        var flowerStand = GetFlowerStand((uint)deskId);
        if (flowerStand != null)
        {
            if (flowerStand.flowerStandData != null)
            {
                flowerStand.flowerStandData.id = id;
                if (MyselfModel.Instance.atHome)
                {
                    flowerStand.flowerStandData.tableVo = FlowerSellModel.Instance.GetTableVo((uint)deskId);
                }
                else
                {
                    flowerStand.flowerStandData.tableVo = VisitFriendModel.Instance.GetTableVo((uint)deskId);
                }
                flowerStand.UpdateSkin(flowerStand.flowerStandData);
            }
            return;
        }

        FlowerStandData flowerStandData = new FlowerStandData();
        flowerStandData.decorationsType = decorationsType;
        flowerStandData.id = id;
        flowerStandData.deskId = deskId;
        if (MyselfModel.Instance.atHome)
        {
            flowerStandData.tableVo = FlowerSellModel.Instance.GetTableVo((uint)deskId);
        }
        else
        {
            flowerStandData.tableVo = VisitFriendModel.Instance.GetTableVo((uint)deskId);
        }

        var assetHandle = ResourceManager.Instance.LoadAssetAsync<GameObject>(ResPath.GetPrefabPath("HomeDecoration/FlowerStand"));
        assetHandle.Completed += (AssetHandle handle) =>
        {
            GameObject furnitureGameObject = assetHandle.InstantiateSync();
            var flowerStand = furnitureGameObject.GetComponent<FlowerStand>();
            furnitureGameObject.GetComponent<FlowerStand>().UpdateSkin(flowerStandData);
            furnitureGameObject.transform.SetParent(home, false);
            furnitureGameObject.transform.localPosition = pos;
            tableDic.Add((uint)deskId, flowerStand);
            SceneManager.Instance.AddSceneObject(flowerStand);
        };
    }

    private void OnUnLockTable(TableVo tableVo)
    {
        var flowerStand = GetFlowerStand(tableVo.deskId);
        if (flowerStand != null)
        {
            flowerStand.UpLock(tableVo);
        }
    }

    private void OnShelfFlower(uint deskId)
    {
        var flowerStand = GetFlowerStand(deskId);
        if (flowerStand != null)
        {
            flowerStand.UpdateFlower();
        }
    }

    private void ShowSelectFlower(uint deskId, int itemId)
    {
        var flowerStand = GetFlowerStand(deskId);
        if (flowerStand != null)
        {
            flowerStand.ShowSelectFlower(itemId);
        }
    }
    private void SwitchFlowerStand(int type)
    {
        var selectDeskId = FlowerSellModel.Instance.selectDeskId;
        if (selectDeskId > 0)
        {
            List<int> unlockDeskIds = new List<int>();//已解锁桌子列表
            foreach (var table in tableDic)
            {
                if (table.Value.flowerStandData.tableVo != null && table.Value.flowerStandData.tableVo.itemId <= 0)
                {
                    unlockDeskIds.Add(table.Value.flowerStandData.deskId);
                }
            }
            var selectIndex = unlockDeskIds.IndexOf(selectDeskId);
            selectIndex += type;
            if (selectIndex < 0) selectIndex = unlockDeskIds.Count - 1;
            if (selectIndex >= unlockDeskIds.Count) selectIndex = 0;
            var deskId = unlockDeskIds[selectIndex];
            FlowerSellModel.Instance.selectDeskId = deskId;
            SelectThis((uint)deskId);
        }
    }

    public void HideAllDeskSelect()
    {
        foreach (var table in tableDic)
        {
            table.Value.Select(false);
        }
    }

    public void ShowHideAllDeskAddFlowerMark(bool show)
    {
        foreach (var table in tableDic)
        {
            table.Value.ShowJiaHua(show);
        }
    }

    public void HideAllDeskSelectFlower()
    {
        foreach (var table in tableDic)
        {
            table.Value.ShowSelectFlower(0);
        }
    }
    public Decoration GetDecoration(string key)
    {
        if (decorationDic.TryGetValue(key, out Decoration decoration))
        {
            return decoration;
        }
        return null;
    }

    public FlowerStand GetFlowerStand(uint deskId)
    {
        if (tableDic.TryGetValue(deskId, out FlowerStand flowerStand))
        {
            return flowerStand;
        }
        return null;
    }

    private void SellFlowerReward(uint deskId)
    {
        var flowerStand = GetFlowerStand(deskId);
        if (flowerStand != null)
        {
            flowerStand.UpdateFlower();
        }
    }

    private void SelectThis(uint deskId)
    {
        HideAllDeskSelect();
        HideAllDeskSelectFlower();
        var flowerStand = GetFlowerStand(deskId);
        if (flowerStand != null)
        {
            flowerStand.SelectThis();
        }
    }

    public void Clear()
    {
        RemoveEvent();
    }

    /// <summary>
    /// 获取已解锁空花台
    /// </summary>
    /// <returns></returns>
    public FlowerStand GetUnLockEmptyFlowerStand()
    {
        foreach (var table in tableDic)
        {
            if (table.Value.flowerStandData.tableVo != null && table.Value.flowerStandData.tableVo.itemId <= 0)
            {
                return table.Value;
            }
        }
        return null;
    }

    /// <summary>
    /// 获取已解锁花台
    /// </summary>
    /// <returns></returns>
    public FlowerStand GetUnLockFlowerStand()
    {
        foreach (var table in tableDic)
        {
            if (table.Value.flowerStandData.tableVo != null)
            {
                return table.Value;
            }
        }
        return null;
    }

    /// <summary>
    /// 获取未解锁花台
    /// </summary>
    /// <returns></returns>
    public FlowerStand GetLockFlowerStand()
    {
        foreach (var table in tableDic)
        {
            if (table.Value.flowerStandData.tableVo == null)
            {
                return table.Value;
            }
        }
        return null;
    }
}
