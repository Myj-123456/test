using Elida.Config;


public class Ft_island_eventConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_island_eventConfig> _dataMap;
    private System.Collections.Generic.List<Ft_island_eventConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_island_eventConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_island_eventConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_island_eventConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_island_eventConfig> DataList => _dataList;

    public Ft_island_eventConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_island_eventConfig this[int key] => _dataMap[key];
}