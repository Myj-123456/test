using Elida.Config;


public class Ft_hua_breakConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<string, Ft_hua_breakConfig> _dataMap;
    private System.Collections.Generic.List<Ft_hua_breakConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_hua_breakConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<string, Ft_hua_breakConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.ID, item);
        }
    }

    public System.Collections.Generic.Dictionary<string, Ft_hua_breakConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_hua_breakConfig> DataList => _dataList;

    public Ft_hua_breakConfig Get(string key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_hua_breakConfig this[string key] => _dataMap[key];
}