using Elida.Config;


public class Ft_diamond_valueConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_diamond_valueConfig> _dataMap;
    private System.Collections.Generic.List<Ft_diamond_valueConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_diamond_valueConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_diamond_valueConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.IndexId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_diamond_valueConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_diamond_valueConfig> DataList => _dataList;

    public Ft_diamond_valueConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_diamond_valueConfig this[int key] => _dataMap[key];
}