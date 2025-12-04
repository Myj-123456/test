using Elida.Config;


public class Ft_hua_levelConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<string, Ft_hua_levelConfig> _dataMap;
    private System.Collections.Generic.List<Ft_hua_levelConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_hua_levelConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<string, Ft_hua_levelConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.ID, item);
        }
    }

    public System.Collections.Generic.Dictionary<string, Ft_hua_levelConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_hua_levelConfig> DataList => _dataList;

    public Ft_hua_levelConfig Get(string key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_hua_levelConfig this[string key] => _dataMap[key];
}