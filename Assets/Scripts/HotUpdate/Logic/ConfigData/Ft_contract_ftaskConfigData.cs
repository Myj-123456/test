using Elida.Config;


public class Ft_contract_ftaskConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_contract_ftaskConfig> _dataMap;
    private System.Collections.Generic.List<Ft_contract_ftaskConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_contract_ftaskConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_contract_ftaskConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.TaskId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_contract_ftaskConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_contract_ftaskConfig> DataList => _dataList;

    public Ft_contract_ftaskConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_contract_ftaskConfig this[int key] => _dataMap[key];
}