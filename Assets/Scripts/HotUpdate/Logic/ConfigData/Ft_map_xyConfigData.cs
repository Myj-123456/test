using Elida.Config;


public class Ft_map_xyConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_map_xyConfig> _dataMap;
    private System.Collections.Generic.List<Ft_map_xyConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_map_xyConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_map_xyConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_map_xyConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_map_xyConfig> DataList => _dataList;

    public Ft_map_xyConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_map_xyConfig this[int key] => _dataMap[key];
}