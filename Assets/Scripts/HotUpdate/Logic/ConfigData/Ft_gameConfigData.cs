using Elida.Config;


public class Ft_gameConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<string, Ft_gameConfig> _dataMap;
    private System.Collections.Generic.List<Ft_gameConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_gameConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<string, Ft_gameConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.IndexId, item);
        }
    }

    public System.Collections.Generic.Dictionary<string, Ft_gameConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_gameConfig> DataList => _dataList;

    public Ft_gameConfig Get(string key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_gameConfig this[string key] => _dataMap[key];
}