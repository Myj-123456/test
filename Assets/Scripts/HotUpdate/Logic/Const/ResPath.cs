
public class ResPath
{
    public static string GetConfigByName(string fileName)
    {
        return $"Assets/ResAB/Config/{fileName}.bytes";
    }

    public static string GetAudioPath(string fileName)
    {
        return $"Assets/ResAB/Sound/{fileName}.mp3";
    }

    public static string GetDbSkeJsonPath(string fileName)
    {
        return $"Assets/ResAB/Animation/Db/{fileName}/{fileName}_ske.json";
    }

    public static string GetDbTexJsonPath(string fileName)
    {
        return $"Assets/ResAB/Animation/Db/{fileName}/{fileName}_tex.json";
    }

    public static string GetDbTexPngPath(string fileName)
    {
        return $"Assets/ResAB/Animation/Db/{fileName}/{fileName}_tex.png";
    }
    public static string GetSpinePath(string fileName)
    {
        var spiSymbolIndex = fileName.IndexOf("/");
        if (spiSymbolIndex != -1)//文件目录拆分
        {
            var parentDir = fileName.Substring(0, spiSymbolIndex);
            var newFileName = fileName.Substring(spiSymbolIndex + 1);
            return $"Assets/ResAB/Animation/Spine/{parentDir}/{newFileName}/{newFileName}_SkeletonData.asset";
        }
        return $"Assets/ResAB/Animation/Spine/{fileName}/{fileName}_SkeletonData.asset";
    }
    public static string GetMcPath(string fileName)
    {
        return $"Assets/ResAB/Animation/Mc/{fileName}/{fileName}.prefab";
    }

    public static string GetParticlePath(string fileName)
    {
        return $"Assets/ResAB/Animation/Particle/{fileName}/{fileName}.prefab";
    }

    public static string GetPrefabPath(string prefabName)
    {
        return $"Assets/ResAB/Prefabs/{prefabName}.prefab";
    }

    public static string GetScenePath(string sceneName)
    {
        return $"Assets/ResAB/Scene/{sceneName}";
    }

    public static string GetFuiPng(string packageName)
    {
        return ($"Assets/ResAB/FguiAutoGeneration/{packageName}/{packageName}_atlas0.png");
    }

    public static string GetFuiBytes(string packageName)
    {
        return ($"Assets/ResAB/FguiAutoGeneration/{packageName}/{packageName}_fui.bytes");
    }

    public static string GetMapTrunkImagePath(string trunkId)
    {
        return $"Assets/ResAB/Map/{trunkId}.jpg";
    }

    public static string GetStructurePath(string structureName)
    {
        return $"Assets/ResAB/SceneRes/Structure/{structureName}.png";
    }

    public static string GetMapTrunkPath(string mapTrunk)
    {
        return $"Assets/ResAB/Map/{mapTrunk}.jpg";
    }

    public static string GetLandPath(string landName)
    {
        return $"Assets/ResAB/SceneRes/Land/{landName}.png";
    }

    public static string GetPlantFlowerPath(int plantFlowerId, int state)
    {
        return $"Assets/ResAB/SceneRes/PlantFlower/a{plantFlowerId}_{state}.png";
    }

    public static string GetHomeDecorationPath(string decorationId)
    {
        return $"Assets/ResAB/SceneRes/HomeDecoration/{decorationId}.png";
    }

    public static string GetNpcPath(string imageName)
    {
        return $"Assets/ResAB/SceneRes/Npc/{imageName}.png";
    }

    public static string GetDynamicUIPath(string dynamicUI)
    {
        return $"Assets/ResAB/DynamicUI/{dynamicUI}";
    }

    public static string GetBuffIconPath(string buff)
    {
        return $"BuffIcon/{buff}.png";
    }
    public static string GetFlowerFairiesIconPath(string id)
    {
        return $"FlowerFairiesIcon/{id}.png";
    }

    public static string GetSeedIconPath(string seedIcon)
    {
        return $"Icon/SeedIcon/i{seedIcon}.png";
    }

    public static string GetAdventureRes(string urlPath)
    {
        return $"Assets/ResAB/Adventure/{urlPath}";
    }

    /// <summary>
    /// 获取换装部位spine动画
    /// </summary>
    /// <param name="partName"></param>
    /// <param name="partId">0为默认的</param>
    /// <returns></returns>
    public static string GetDressPartSpinePath(string partName, int partId)
    {
        if (partName == "body")//body都是通用的 不分partId
        {
            return $"Assets/ResAB/Animation/Spine/dress/{partName}/{partName}_SkeletonData.asset";
        }
        return $"Assets/ResAB/Animation/Spine/dress/{partName}/{partId}/{partName}_SkeletonData.asset";
    }
    public static string GetBattleRes(string urlPath)
    {
        return $"Assets/ResAB/Battle/{urlPath}";
    }
}

