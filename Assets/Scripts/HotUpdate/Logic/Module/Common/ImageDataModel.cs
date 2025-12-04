using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ADK;
using Elida.Config;

public class ImageDataModel : Singleton<ImageDataModel>
{
    //经验
    public static string EXP_ICON_URL = "Item/iexp.png";
    //金币
    public static string GOLD_ICON_URL = "Item/" + "igold" + ".png";
    //钻石
    public static string CASH_ICON_URL = "Item/" + "igem" + ".png";
    //水
    public static string WATER_ICON2 = "Item/iwater2.png";
    //水
    public static string WATER_ICON_URL = "Item/" + "iwater" + ".png";

    public string GetIdentifiedFlowerUrl(Module_item_defConfig itemData)
    {
        return GetGalleryFlowerURL(itemData);
    }

    public string GetGalleryFlowerURL(Module_item_defConfig item)
    {
        return "FlowerStatus/a" + item.ResourceId + "_2" + ".png";
    }

    public string GetIconUrlByEntityId(object id)
    {
        EntityID entityID = null;
        if (id is string)
        {
            entityID = IDUtil.GetEntityId((string)id);
        }
        else if (id is long)
        {
            entityID = IDUtil.GetEntityId((long)id);
        }
        else if (id is int)
        {
            entityID = IDUtil.GetEntityId((int)id);
        }
        else if (id is uint)
        {
            entityID = IDUtil.GetEntityId((uint)id);
        }
        return GetIconUrlByItemId(entityID.value);
    }


    /// <summary>
    /// 获取花状态图片 ui和场景都会引用到
    /// </summary>
    /// <param name="flowerId"></param>
    /// <param name="status"></param>
    /// <param name="isFullPath"></param>
    /// <returns></returns>
    public string GetFlowerStatusUrl(int flowerId, int status, bool isFullPath = false)
    {
        if (!isFullPath)
        {
            return "FlowerStatus/a" + flowerId.ToString() + "_" + status.ToString() + ".png";
        }
        //全路径
        return "Assets/ResAB/DynamicUI/FlowerStatus/a" + flowerId.ToString() + "_" + status.ToString() + ".png";
    }

    /// <summary>
    /// 获取花瓶图片
    /// </summary>
    /// <param name="vaseId"></param>
    /// <returns></returns>
    public string GetVaseUrl(int vaseId)
    {
        return "Item/" + vaseId.ToString() + ".png";
    }

    public string GuildMoneyIconUrl()
    {
        return "Item/guild_coin.png";
    }

    public string GetIconUrlByItemId(long id)
    {
        switch ((BaseType)id)
        {
            case BaseType.GOLD:  
                return ImageDataModel.GOLD_ICON_URL;
            case BaseType.EXP:
                return ImageDataModel.EXP_ICON_URL;
            case BaseType.CASH:
                return ImageDataModel.CASH_ICON_URL;
            case BaseType.FST_WATER:
                return ImageDataModel.WATER_ICON_URL;
            default:
                Module_item_defConfig item = ItemModel.Instance.GetItemById((int)id);
                return GetIconUrl(item);
        }
    }

    public string GetIconUrl(Module_item_defConfig item)
    {
        if (item != null)
        {
            if(item.Type == 4105)
            {
                var flowerVo = FlowerHandbookModel.Instance.GetStaticSeedCondition1(item.ItemDefId);
                var itemVo = ItemModel.Instance.GetItemById(flowerVo.FlowerId);
                return "Item/i" + itemVo.ResourceId + ".png";
            }
            else
            {
                return "Item/i" + item.ResourceId + ".png";
            }
            
        }
        return null;
    }

    public string GetIconUrl1(Module_item_defConfig item)
    {
        if (item != null)
        {
            return "Item/i" + item.ResourceId + "_1.png";
        }
        return null;
    }

    public string GetVaseItemUrl(int resourceId)
    { 
        return "Item/" + resourceId + "fs.png"; 
    }

    public string GetFormulaUrl(int id, int vaseId)
    {

        return "Item/" + id + "_" + vaseId + ".png";
    }

    public string GetSmallVaseUrl(int vaseId)
    {
        return "smallicon/" + vaseId + "_s.png";
    }

    public string GetSmallFormulaUrl(int id, int vaseId)
    {
        return "smallicon/" + id + "_" + vaseId + "_s.png";
    }

    public string GetNatureScenePlantImage(int flowerId)
    {
        return "FlowerStatus/" + "a" + flowerId + "_2.png";
    }

    public string GetItemQuality(int quality)
    {
        return "MyInfo/show_flower_bg" + (quality == 0 ?1: quality) + ".png";
    }
    public string GetItemRareQuality(int quality)
    {
        return "HandBookNew/rare_icon_" + (quality == 0 ? 1 : quality) + ".png";
    }
}
