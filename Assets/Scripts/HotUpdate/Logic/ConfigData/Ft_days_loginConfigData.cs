using Elida.Config;


public class Ft_days_loginConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_days_loginConfig> _dataMap;
    private System.Collections.Generic.List<Ft_days_loginConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_days_loginConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_days_loginConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.IndexId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_days_loginConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_days_loginConfig> DataList => _dataList;

    public Ft_days_loginConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_days_loginConfig this[int key] => _dataMap[key];
}