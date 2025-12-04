using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using protobuf.card;
using UnityEngine;

public class FairyFlowerModel : Singleton<FairyFlowerModel>
{
    public I_HELP help;//助力信息
    public List<I_DISPATCH_VO> fairyDispatchList;//派遣信息
    public List<I_FAIRY_FIGURE_VO> figureList;//花仙藏品
    public I_FAIRY_CONTRACT_VO fairContract;//合约信息
    public List<I_FAIRY_CONTRACT_TASK_VO> fairContractTaskList;//合约任务

    public List<uint> openPos;//已打开的位置

    public List<FairyFigureConfig> FairyFigureHome;
    //花仙藏品配置表
    private List<FairyFigureConfig> _fairyFigureList;
    public List<FairyFigureConfig> fairyFigureList { get
        {
            if(_fairyFigureList == null)
            {
                _fairyFigureList = new List<FairyFigureConfig>();

                var fairyFigureData = ConfigManager.Instance.GetConfig<Ft_fairy_figureConfigData>("ft_fairy_figuresConfig");
                foreach(var value in fairyFigureData.DataList)
                {
                    var fairyFigureConfig = new FairyFigureConfig(value);
                    _fairyFigureList.Add(fairyFigureConfig);
                }
            }
            return _fairyFigureList;
        } }
    //花仙派遣
    private Dictionary<int, Ft_fairy_identifyConfig> _fairyIdentMap;
    public Dictionary<int, Ft_fairy_identifyConfig> fairyIdentMap { get
        {
            if(_fairyIdentMap == null)
            {
                var fairyIdentData = ConfigManager.Instance.GetConfig<Ft_fairy_identifyConfigData>("ft_fairy_identifysConfig");
                _fairyIdentMap = fairyIdentData.DataMap;
            }
            return _fairyIdentMap;
        } }
    //双倍配置
    private Dictionary<int, Ft_fairy_doubleConfig> _fairyDouble;
    private Dictionary<int, Ft_fairy_doubleConfig> fairyDouble { get
        {
            if(_fairyDouble == null)
            {
                var fairyDoubleData = ConfigManager.Instance.GetConfig<Ft_fairy_doubleConfigData>("ft_fairy_doublesConfig");
                _fairyDouble = fairyDoubleData.DataMap;
            }
            return _fairyDouble;
        } }
    //花灵合约任务
    private Dictionary<int, Ft_contract_ftaskConfig> _contractMap;
    public Dictionary<int, Ft_contract_ftaskConfig> contractMap { get
        {
            if(_contractMap == null)
            {
                var contractData = ConfigManager.Instance.GetConfig<Ft_contract_ftaskConfigData>("ft_contract_ftasksConfig");
                _contractMap = contractData.DataMap;
            }
            return _contractMap;
        } }
    //花灵奖励
    private List<Ft_contract_frewardConfig> _contractLvList;
    public List<Ft_contract_frewardConfig> contractLvList { get
        {
            if(_contractLvList == null)
            {
                var contractLvData = ConfigManager.Instance.GetConfig<Ft_contract_frewardConfigData>("ft_contract_frewardsConfig");
                _contractLvList = contractLvData.DataList;
            }
            return _contractLvList;
        } }
    //盲盒抽卡表
    private List<Ft_fairy_boxConfig> _fairyBoxList;
    public List<Ft_fairy_boxConfig> fairyBoxList { get
        {
            if(_fairyBoxList == null)
            {
                var fairyBoxData = ConfigManager.Instance.GetConfig<Ft_fairy_boxConfigData>("ft_fairy_boxsConfig");
                _fairyBoxList = fairyBoxData.DataList;
            }
            return _fairyBoxList;
        } }
    public Ft_contract_ftaskConfig GetContractInfo(int id)
    {
        if (contractMap.ContainsKey(id))
        {
            return contractMap[id];
        }
        return null;
    }
    public Ft_fairy_doubleConfig GetfairyDoubleInfo(int id)
    {
        if (fairyDouble.ContainsKey(id))
        {
            return fairyDouble[id];
        }
        return null;
    }
    public Ft_fairy_identifyConfig GetFairyIdentInfo(int id)
    {
        if (fairyIdentMap.ContainsKey(id))
        {
            return fairyIdentMap[id];
        }
        return null;
    }
    public void UpdateContractTask(uint pos)
    {
        var task = fairContractTaskList.Find(value => value.pos == pos);
        if(task != null)
        {
            task.awardStatus = 1;
        }
        
    }

    public void UpdateFigure(I_FAIRY_FIGURE_VO data)
    {
        var figure = figureList.Find(value => value.figureId == data.figureId);
        if(figure != null)
        {
            figure.level = data.level;
        }
        
    }

    public void UpdateDispatch(I_DISPATCH_VO data)
    {
        var dispatch = fairyDispatchList.Find(value => value.pos == data.pos);
        if(dispatch != null)
        {
            dispatch.fairyId = data.fairyId;
            dispatch.harvestTime = data.harvestTime;
            dispatch.cnt = data.cnt;
        }
    }


    public void FilterBookData()
    {
        if(FairyFigureHome != null)
        {
            FairyFigureHome.Clear();
        }
        FairyFigureHome = new List<FairyFigureConfig>(fairyFigureList);
        FairyFigureHome.Sort(BookSort);
    }

    public int BookSort(FairyFigureConfig a, FairyFigureConfig b)
    {
        if (a.Unlock && !b.Unlock) return -1;
        if (!a.Unlock && b.Unlock) return 1;
        return b.Quality - a.Quality;
    }
}

public class FairyFigureConfig
{
    // 藏品id 
    public int Id;

    // 主花id 
    public int MainFlowerId;

    // 副花id
    public int ViceFlowerId;

    // 花仙id
    public int FairyId;

    // 经验的道具id
    public int ExpId;

    // 额外概率
    public int[] WeightLevels;

    // 消耗的经验道具
    public int[] CostLevelExps;

    // 消耗的金币道具
    public int[] CostLevelCoins;

    // 收获花仙+经验
    public int FairyAddExp;

    // 重复抽中转化经验
    public int DrawConvertExp;

    // 升至顶级时，重复抽中对应转化为金币
    public int TopConvertExp;

    public int Quality { get
        {
            var itemVo = ItemModel.Instance.GetItemById(Id);
            return itemVo.Quality;
        } }

    public bool Unlock { get
        {
            var figure = FairyFlowerModel.Instance.figureList.Find(value => value.figureId == Id);
            return figure != null;
        } }

    public uint Level { get
        {
            var figure = FairyFlowerModel.Instance.figureList.Find(value => value.figureId == Id);
            return figure == null ? 1 : figure.level;
        } }
    public FairyFigureConfig(Ft_fairy_figureConfig data)
    {
        Id = data.Id;
        MainFlowerId = data.MainFlowerId;
        ViceFlowerId = data.ViceFlowerId;
        FairyId = data.FairyId;
        ExpId = data.ExpId;
        WeightLevels = data.WeightLevels;
        CostLevelExps = data.CostLevelExps;
        CostLevelCoins = data.CostLevelCoins;
        FairyAddExp = data.FairyAddExp;
        DrawConvertExp = data.DrawConvertExp;
        TopConvertExp = data.TopConvertExp;
    }
}

