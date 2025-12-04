using Elida.Config;


public class Ft_island_objectConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_island_objectConfig> _dataMap;
    private System.Collections.Generic.List<Ft_island_objectConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_island_objectConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_island_objectConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.GridId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_island_objectConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_island_objectConfig> DataList => _dataList;

    public Ft_island_objectConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_island_objectConfig this[int key] => _dataMap[key];
}