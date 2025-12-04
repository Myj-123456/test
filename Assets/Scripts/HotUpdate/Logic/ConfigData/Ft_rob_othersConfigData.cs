using Elida.Config;


public class Ft_rob_othersConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_rob_othersConfig> _dataMap;
    private System.Collections.Generic.List<Ft_rob_othersConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_rob_othersConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_rob_othersConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.IndexId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_rob_othersConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_rob_othersConfig> DataList => _dataList;

    public Ft_rob_othersConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_rob_othersConfig this[int key] => _dataMap[key];
}