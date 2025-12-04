using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using UnityEngine;

public enum GuideType
{
    GUIDE_SPACE = 0,//正常显示不加指引性的引导
    NPC_DIALOGUE_Full,//npc全屏对话框 配置npc对话
    NPC_DIALOGUE,//npc非全屏对话框+手指引导 配置对话内容和指引对象
    SCENE_OBJ,//场景物引导 需配置场景物id
    PANEL_UI,//界面UI引导 需配置界面ui控制名字
    SHOW_VIDEO//显示引导视频 需配置引导视频
}

public class GuideModel : Singleton<GuideModel>
{
    public uint maxGuideStep = 34;
    private uint _curGuideStep = 1;//当前引导步骤
    public bool IsGuiding = false;//是否引导中
    public FairyGUI.GObject guildTarget;//引导对象
    public bool IsNeedGuide = false;//是否需要引导
    public Land guideWaterLand;//引导浇水的地
    public bool IsWeakGuiding = false;//是否弱引导中
    public bool IsCancelGuide = false;//是否取消引导
    public SceneObject curStrongGuideSceneObject;//当前强引导的场景对象
    public SceneObject curGuideSceneObject;//当前弱引导的场景对象
    public FairyGUI.GObject curGuideUI;//当前弱引导的ui对象
    public int curWeakGuideStep = 0;//当前弱引导步骤
    public WeakGuideGroupConfig weakGuideGroupConfig;

    public bool IsPrequelPlotGuiding = false;//是否前置剧情引导中


    public uint nextGuideStep = 0;
    private Dictionary<int, Ft_game_guideConfig> _guidesConfig;
    public Dictionary<int, Ft_game_guideConfig> guidesConfig
    {
        get
        {
            if (_guidesConfig == null)
            {
                Ft_game_guideConfigData guideConfigData = ConfigManager.Instance.GetConfig<Ft_game_guideConfigData>("ft_game_guidesConfig");
                _guidesConfig = guideConfigData.DataMap;
            }
            return _guidesConfig;
        }
    }

    public Ft_game_guideConfig curConfigData;


    /// <summary>
    /// 是否需要引导
    /// </summary>
    public bool IsGuide
    {
        get { if (!IsNeedGuide) return false; return curConfigData != null && curConfigData.SkipStep != 0; }
    }

    public Ft_game_guideConfig GetGuideData(int step)
    {
        if (guidesConfig.ContainsKey(step))
        {
            return guidesConfig[step];
        }
        return null;
    }

    /// <summary>
    /// 外部设置引导步骤
    /// </summary>
    /// <param name="curGuideStep"></param>
    public void SetGuideStep(uint curGuideStep)
    {
        _curGuideStep = curGuideStep;
        curConfigData = GetGuideData((int)_curGuideStep);
    }

    public uint curGuideStep
    {
        get { return _curGuideStep; }
        set
        {
            if (_curGuideStep == value) return;
            _curGuideStep = value;
            curConfigData = GetGuideData((int)_curGuideStep);
            SaveGuideStep();
        }
    }

    //保存引导步骤
    private void SaveGuideStep()
    {
        SaveGuide(_curGuideStep);
    }

    private void SaveGuide(uint guideStep)
    {
        if (curConfigData != null)
        {
            GuideController.Instance.SaveGuide(guideStep, curConfigData.SkipStep == 0);
        }
    }

    /// <summary>
    /// 获取当前弱引导组的长度
    /// </summary>
    /// <returns></returns>
    public int GetCurWeakGuideGroupCount()
    {
        if (weakGuideGroupConfig != null)
        {
            return weakGuideGroupConfig.weakGuideStepConfigs.Count;
        }
        return 0;
    }


    /// <summary>
    /// 是否是强引导步骤
    /// </summary>
    /// <returns></returns>
    public bool IsStrongGuide()
    {
        if (IsNeedGuide)
        {
            return curGuideStep < 100;
        }
        return false;
    }
}

/// <summary>
/// 一组弱引导配置
/// </summary>
public class WeakGuideGroupConfig
{
    public int groupId;
    public List<WeakGuideStepConfig> weakGuideStepConfigs;//该组对应的引导步骤
}

/// <summary>
/// 一个弱引导配置
/// </summary>
public class WeakGuideStepConfig
{
    public int id;//步骤引导id
    public int GuideType;//引导类型 1：引导界面UI 2：引导场景对象
    public int SceneObjType; //如果GuideType是2 需要填写场景物类型 1：花台 2：建筑物  3:家具 4:种植地块 5:npc 6:场景水桶 否则不填写
    public string Param;//引导参数 如果是ui：需要打开的界面 场景对象：花台填下标[1-6] 建筑物填id 家具填家具类型 种植地块填下标[1-60]
    public string TargetPath;//界面ui组件目标 控件shop_btn 支持路径搜索:ui_chooseFlower/list_flower  如果是控件类型是列表 那么需要填写下标 如ui_chooseFlower/list_flower#0
    public float Delay = 0f;//延迟多久执行此引导
    public Vector2 PosOffset = Vector2.zero;
}


public class Ft_guideConfig
{
    public int IndexId;
    public int GuideGroup;
    public int GuideType;
    public int SkipStep;
    public string GuideStr;
    public int NpcSpineType;
    public int StructureId;
    public float Delay;
    public string OpenView;
    public string TargetPath;
    public int Index;
    public int PanelType;
    public string GuideImage;
    public float GuideOffsetX;
    public float GuideOffsetY;
    public string GuideObject;
    public Ft_guideConfig(int indexId, int guideGroup, int guideType, int skipStep, string guideStr, int npcSpineType, int structureId, float delay, string openView, string targetPath, int index, int panelType, string guideImage = "", float guideOffsetX = 0, float guideOffsetY = 0, string guideObject = "")
    {
        IndexId = indexId;
        GuideGroup = guideGroup;
        GuideType = guideType;
        SkipStep = skipStep;
        GuideStr = guideStr;
        NpcSpineType = npcSpineType;
        StructureId = structureId;
        Delay = delay;
        OpenView = openView;
        TargetPath = targetPath;
        Index = index;
        PanelType = panelType;
        GuideImage = guideImage;
        GuideOffsetX = guideOffsetX;
        GuideOffsetY = guideOffsetY;
        GuideObject = guideObject;
    }
}

