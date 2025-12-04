using Elida.Config;


public class Ft_contract_taskConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_contract_taskConfig> _dataMap;
    private System.Collections.Generic.List<Ft_contract_taskConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_contract_taskConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_contract_taskConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.TaskId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_contract_taskConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_contract_taskConfig> DataList => _dataList;

    public Ft_contract_taskConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_contract_taskConfig this[int key] => _dataMap[key];
}