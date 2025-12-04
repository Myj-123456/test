
using System;
using System.Collections.Generic;
using System.Linq;
using protobuf.floristshop;
using protobuf.messagecode;
/// <summary>
/// 花店控制器
/// </summary>
public class FlowerShopController : BaseController<FlowerShopController>
{

    protected override void InitListeners()
    {
        //鲜花店铺领取条件奖励
        AddNetListener<S_MSG_FLORIST_CONDITIION_REWARD>((int)MessageCode.S_MSG_FLORIST_CONDITIION_REWARD, FloristReward);
        //鲜花店铺升级
        AddNetListener<S_MSG_FLORIST_UPGRADE>((int)MessageCode.S_MSG_FLORIST_UPGRADE, FloristUpgrade);
        //家具锻造
        AddNetListener<S_MSG_FLORIST_FURNITURE_FORGE>((int)MessageCode.S_MSG_FLORIST_FURNITURE_FORGE, FloristForge);
        AddNetListener<S_MSG_FLORIST_DECORATION>((int)MessageCode.S_MSG_FLORIST_DECORATION, ResFloristDecoration);
        //鲜花店铺信息
        AddNetListener<S_MSG_FLORIST_INFO>((int)MessageCode.S_MSG_FLORIST_INFO, FloristInfo);
    }
    /// <summary>
    /// 打开家具摆放界面
    /// </summary>
    /// <param name="type"></param>
    public void ShowFurnitureArrangement(int type)
    {
        FlowerShopModel.Instance.IsChangeFurniture = false;
        UIManager.Instance.OpenWindow<FurnitureArrangementWindow>(UIName.FurnitureArrangementWindow, type);
        FlowerShopModel.Instance.isEditing = true;
    }

    public void HideFurnitureArrangement()
    {
        SceneManager.Instance.CloseEdit(true);
        FlowerShopModel.Instance.isEditing = false;
    }

    /// <summary>
    /// 使用家具
    /// </summary>
    /// <param name="id"></param>
    public void ReqUseFurniture(int id)
    {
        FlowerShopModel.Instance.UpdateDecoration((uint)id);
        SceneManager.Instance.UpdateFurnitures(id);
    }

    /// <summary>
    /// 使用套装
    /// </summary>
    /// <param name="furnitures"></param>
    public void ReqUseSuitFurniture(int[] furnitures)
    {
        SceneManager.Instance.UpdateFurnitures(furnitures);
    }
    //鲜花店铺升级
    public void FloristReward(S_MSG_FLORIST_CONDITIION_REWARD data)
    {
        FlowerShopModel.Instance.rewardIds.Add(data.type);
        var dropList = ItemModel.Instance.GetDropData(data.items);
        DropManager.ShowDrop(dropList);
        DispatchEvent(FloristEvent.FloristReward);
    }

    public void ReqFloristReward(uint type)
    {
        C_MSG_FLORIST_CONDITIION_REWARD c_MSG_FLORIST_CONDITIION_REWARD = new C_MSG_FLORIST_CONDITIION_REWARD();
        c_MSG_FLORIST_CONDITIION_REWARD.type = type;
        SendCmd((int)MessageCode.C_MSG_FLORIST_CONDITIION_REWARD, c_MSG_FLORIST_CONDITIION_REWARD);
    }
    //鲜花店铺升级
    public void FloristUpgrade(S_MSG_FLORIST_UPGRADE data)
    {
        FlowerShopModel.Instance.InitData(data.floristShop);
        DispatchEvent(FloristEvent.FloristUpgrade);
    }

    public void ReqFloristUpgrade()
    {
        C_MSG_FLORIST_UPGRADE c_MSG_FLORIST_UPGRADE = new C_MSG_FLORIST_UPGRADE();
        SendCmd((int)MessageCode.C_MSG_FLORIST_UPGRADE, c_MSG_FLORIST_UPGRADE);
    }
    //家具锻造
    public void FloristForge(S_MSG_FLORIST_FURNITURE_FORGE data)
    {
        var dropList = ItemModel.Instance.GetDropData(data.items);
        DropManager.ShowDrop(dropList);
        StorageModel.Instance.OddToStorageItems(data.costItems);
        DispatchEvent(FloristEvent.FloristForge);
        BattleController.Instance.ReqModulePower(3);
    }

    public void ReqFloristForge(ulong furnitureId)
    {
        C_MSG_FLORIST_FURNITURE_FORGE c_MSG_FLORIST_FURNITURE_FORGE = new C_MSG_FLORIST_FURNITURE_FORGE();
        c_MSG_FLORIST_FURNITURE_FORGE.furnitureId = furnitureId;
        SendCmd((int)MessageCode.C_MSG_FLORIST_FURNITURE_FORGE, c_MSG_FLORIST_FURNITURE_FORGE);
    }
    //鲜花店铺信息
    public void FloristInfo(S_MSG_FLORIST_INFO data)
    {
        FlowerShopModel.Instance.floristDrawingPower = data.floristDrawingPower;
        DispatchEvent(FloristEvent.FloristInfo);
    }

    public void ReqFloristInfo()
    {
        C_MSG_FLORIST_INFO c_MSG_FLORIST_INFO = new C_MSG_FLORIST_INFO();
        SendCmd((int)MessageCode.C_MSG_FLORIST_INFO, c_MSG_FLORIST_INFO);
    }


    private List<I_FURNITURE_VO> clientDecoration;
    /// <summary>
    /// 店铺装修
    /// </summary>
    /// <param name="decoration"></param>
    public void ReqFloristDecoration()
    {
        if (!FlowerShopModel.Instance.IsChangeFurniture) return;
        clientDecoration = FlowerShopModel.Instance.GetClientDecoration();
        //bool isEqual = FurnitureVOComparer.AreListsEqual(clientDecoration, serverDecoration, false);
        //if (isEqual) return;//没变更，不需要发送服务器
        C_MSG_FLORIST_DECORATION c_MSG_FLORIST_DECORATION = new C_MSG_FLORIST_DECORATION();
        c_MSG_FLORIST_DECORATION.decoration = clientDecoration;
        SendCmd((int)MessageCode.C_MSG_FLORIST_DECORATION, c_MSG_FLORIST_DECORATION);
    }

    private void ResFloristDecoration(S_MSG_FLORIST_DECORATION s_MSG_FLORIST_DECORATION)
    {
        if (clientDecoration != null)
        {
            FlowerShopModel.Instance.InitDecorations(clientDecoration);
            SceneManager.Instance.UpdateFurnitures(FlowerShopModel.Instance.furnitureDataDic);
        }
    }
}

public static class FurnitureVOComparer
{
    public static bool AreListsEqual(List<I_FURNITURE_VO> list1, List<I_FURNITURE_VO> list2, bool checkOrder = true)
    {
        // 处理null情况
        if (list1 == null && list2 == null) return true;
        if (list1 == null || list2 == null) return false;
        if (list1.Count != list2.Count) return false;

        if (checkOrder)
        {
            // 顺序敏感的比较
            for (int i = 0; i < list1.Count; i++)
            {
                if (!AreItemsEqual(list1[i], list2[i]))
                    return false;
            }
            return true;
        }
        else
        {
            // 顺序不敏感的比较
            var set1 = new HashSet<I_FURNITURE_VO>(list1, new FurnitureVOEqualityComparer());
            var set2 = new HashSet<I_FURNITURE_VO>(list2, new FurnitureVOEqualityComparer());
            return set1.SetEquals(set2);
        }
    }

    public static bool AreItemsEqual(I_FURNITURE_VO item1, I_FURNITURE_VO item2)
    {
        if (ReferenceEquals(item1, item2)) return true;
        if (item1 is null || item2 is null) return false;

        return item1.itemId == item2.itemId &&
               item1.floor == item2.floor &&
               item1.x == item2.x &&
               item1.y == item2.y;
    }
}

public class FurnitureVOEqualityComparer : IEqualityComparer<I_FURNITURE_VO>
{
    public bool Equals(I_FURNITURE_VO x, I_FURNITURE_VO y)
    {
        return FurnitureVOComparer.AreItemsEqual(x, y);
    }

    public int GetHashCode(I_FURNITURE_VO obj)
    {
        if (obj is null) return 0;
        return HashCode.Combine(obj.itemId, obj.floor, obj.x, obj.y);
    }
}
