using Elida.Config;


public class Ft_island_tourConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_island_tourConfig> _dataMap;
    private System.Collections.Generic.List<Ft_island_tourConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_island_tourConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_island_tourConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_island_tourConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_island_tourConfig> DataList => _dataList;

    public Ft_island_tourConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_island_tourConfig this[int key] => _dataMap[key];
}