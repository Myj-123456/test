using Elida.Config;


public class Ft_turntableConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_turntableConfig> _dataMap;
    private System.Collections.Generic.List<Ft_turntableConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_turntableConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_turntableConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_turntableConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_turntableConfig> DataList => _dataList;

    public Ft_turntableConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_turntableConfig this[int key] => _dataMap[key];
}