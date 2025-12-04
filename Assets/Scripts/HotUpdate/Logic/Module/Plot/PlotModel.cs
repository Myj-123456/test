using Elida.Config;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 剧情配置
/// </summary>
public class PoltDialogueConfig
{
    public int id;
    public int type;
    public string icon;
    public int leftRight;
    public string dialogue;
    public string name;
}


public class PlotModel : Singleton<PlotModel>
{
    public Dictionary<int, List<PoltDialogueConfig>> plotDic = new Dictionary<int, List<PoltDialogueConfig>>();

    private Dictionary<int, Ft_plot_chapterConfig> _plotChapterMap;
    public Dictionary<int, Ft_plot_chapterConfig> plotChapterMap { get
        {
            if(_plotChapterMap == null)
            {
                var plotChapterData = ConfigManager.Instance.GetConfig<Ft_plot_chapterConfigData>("ft_plot_chaptersConfig");
                _plotChapterMap = plotChapterData.DataMap;
            }
            return _plotChapterMap;
        } }

    private Dictionary<int, Ft_plot_configConfig> _plotMap;
    public Dictionary<int, Ft_plot_configConfig> plotMap { get
        {
            if(_plotMap == null)
            {
                var plotData = ConfigManager.Instance.GetConfig<Ft_plot_configConfigData>("ft_plot_configsConfig");
                _plotMap = plotData.DataMap;
            }
            return _plotMap;
        } }
    /// <summary>
    /// 根据剧情id获取一组剧情配置
    /// </summary>
    /// <param name="plotId"></param>
    /// <returns></returns>
    public List<PoltDialogueConfig> GetPlotDialogueConfigs(int plotId)
    {
        List<PoltDialogueConfig> plotDialogueConfigs;
        if (!plotDic.TryGetValue(plotId, out plotDialogueConfigs))
        {
            plotDialogueConfigs = new List<PoltDialogueConfig>();
            var ft_plot_configConfig = GetPlotConfig(plotId);
            if (ft_plot_configConfig != null)
            {
                foreach (var dialogueId in ft_plot_configConfig.Types)
                {
                    var ft_plot_dialogueConfig = GetFtPlotDialogueConfig(dialogueId);
                    if (ft_plot_dialogueConfig != null)
                    {
                        PoltDialogueConfig poltDialogueConfig = new PoltDialogueConfig();
                        poltDialogueConfig.id = ft_plot_dialogueConfig.Id;
                        poltDialogueConfig.type = ft_plot_dialogueConfig.Type;
                        poltDialogueConfig.icon = ft_plot_dialogueConfig.Icon;
                        poltDialogueConfig.leftRight = ft_plot_dialogueConfig.LeftRight;
                        poltDialogueConfig.dialogue = ft_plot_dialogueConfig.Dialogue;
                        poltDialogueConfig.name = ft_plot_dialogueConfig.Name;
                        plotDialogueConfigs.Add(poltDialogueConfig);
                    }
                }
            }
        }
        return plotDialogueConfigs;
    }

    /// <summary>
    /// 获取一个剧情
    /// </summary>
    /// <param name="plotId"></param>
    /// <returns></returns>
    public Ft_plot_configConfig GetPlotConfig(int plotId)
    {
        return ConfigManager.Instance.GetConfig<Ft_plot_configConfigData>("ft_plot_configsConfig").Get(plotId);
    }

    /// <summary>
    /// 获取一个剧情里面的对话配置
    /// </summary>
    /// <param name="dialogue"></param>
    /// <returns></returns>
    public Ft_plot_dialogueConfig GetFtPlotDialogueConfig(int dialogue)
    {
        return ConfigManager.Instance.GetConfig<Ft_plot_dialogueConfigData>("ft_plot_dialoguesConfig").Get(dialogue);
    }

    public Ft_plot_chapterConfig GetPlotChapterInfo(int id)
    {
        if (plotChapterMap.ContainsKey(id))
        {
            return plotChapterMap[id];
        }
        return null;
    }

    public Ft_plot_configConfig GetPlotInfo(int id)
    {
        if (plotMap.ContainsKey(id))
        {
            return plotMap[id];
        }
        return null;
    }
    private void InitPlotConfig()
    {

    }
}
