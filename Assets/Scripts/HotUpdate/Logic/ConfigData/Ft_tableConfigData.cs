using Elida.Config;


public class Ft_tableConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_tableConfig> _dataMap;
    private System.Collections.Generic.List<Ft_tableConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_tableConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_tableConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.GridId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_tableConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_tableConfig> DataList => _dataList;

    public Ft_tableConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_tableConfig this[int key] => _dataMap[key];
}