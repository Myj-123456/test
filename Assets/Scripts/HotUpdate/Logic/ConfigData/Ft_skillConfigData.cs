using Elida.Config;


public class Ft_skillConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<long, Ft_skillConfig> _dataMap;
    private System.Collections.Generic.List<Ft_skillConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_skillConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<long, Ft_skillConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.ID, item);
        }
    }

    public System.Collections.Generic.Dictionary<long, Ft_skillConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_skillConfig> DataList => _dataList;

    public Ft_skillConfig Get(long key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_skillConfig this[long key] => _dataMap[key];
}