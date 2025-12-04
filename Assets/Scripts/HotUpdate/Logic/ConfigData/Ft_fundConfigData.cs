using Elida.Config;


public class Ft_fundConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_fundConfig> _dataMap;
    private System.Collections.Generic.List<Ft_fundConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_fundConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_fundConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_fundConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_fundConfig> DataList => _dataList;

    public Ft_fundConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_fundConfig this[int key] => _dataMap[key];
}