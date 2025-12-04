using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YooAsset;

public interface BaseConfig
{
    public void Parse(byte[] bytes);
}
/// <summary>
/// 配置管理器
/// </summary>
public class ConfigManager : Singleton<ConfigManager>
{
    private Dictionary<string, BaseConfig> configDic = new Dictionary<string, BaseConfig>();

    /// <summary>
    /// 获取一个配置
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="configName"></param>
    /// <returns></returns>
    public T GetConfig<T>(string configName) where T : BaseConfig, new()
    {
        if (configDic.TryGetValue(configName, out BaseConfig value))
        {
            return (T)value;
        }
        else
        {
            AssetHandle assetHandle = ResourceManager.Instance.LoadAssetSync<TextAsset>(ResPath.GetConfigByName(configName));
            TextAsset textAsset = assetHandle.AssetObject as TextAsset;
            if (textAsset != null)
            {
                T cfgData = new T();
                cfgData.Parse(textAsset.bytes);
                configDic.Add(configName, cfgData);
                return cfgData;
            }
        }
        return default;
    }

    /// <summary>
    /// 进入游戏前需要预解析的配置文件
    /// </summary>
    public IEnumerator PreParseConfig()
    {
        PreLoadManager.Instance.ShowLoadingDes("开始解析配置");
        GetConfig<Module_item_defConfigData>("module_item_defsConfig");//物品表
        yield return null;
        GetConfig<Ft_zhcnConfigData>("ft_zhcnsConfig");//多语言
        yield return null;
        GetConfig<Module_profileConfigData>("module_profilesConfig");//通用配置
        yield return null;
        GetConfig<Ft_game_system_unlockConfigData>("ft_game_system_unlocksConfig");//功能开启表
        yield return null;
        GetConfig<Ft_ikebana_vaseConfigData>("ft_ikebana_vasesConfig");//花瓶表
        yield return null;
        GetConfig<Ft_ikebana_flowerConfigData>("ft_ikebana_flowersConfig");//鲜花表
        yield return null;
        GetConfig<Ft_ikebana_artConfigData>("ft_ikebana_artsConfig");//鲜花组合表
        
    }

    public IEnumerator PreParseAuditVersionConfig()
    {
        GetConfig<Ft_zhcnConfigData>("ft_zhcnsConfig");//多语言
        yield return null;
    }
}

