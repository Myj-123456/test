using Elida.Config;


public class Ft_zhcnConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<string, Ft_zhcnConfig> _dataMap;
    private System.Collections.Generic.List<Ft_zhcnConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_zhcnConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<string, Ft_zhcnConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.TxtId, item);
        }
    }

    public System.Collections.Generic.Dictionary<string, Ft_zhcnConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_zhcnConfig> DataList => _dataList;

    public Ft_zhcnConfig Get(string key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_zhcnConfig this[string key] => _dataMap[key];
}