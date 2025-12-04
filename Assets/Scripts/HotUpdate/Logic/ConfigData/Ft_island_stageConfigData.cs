using Elida.Config;


public class Ft_island_stageConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_island_stageConfig> _dataMap;
    private System.Collections.Generic.List<Ft_island_stageConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_island_stageConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_island_stageConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_island_stageConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_island_stageConfig> DataList => _dataList;

    public Ft_island_stageConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_island_stageConfig this[int key] => _dataMap[key];
}