using Elida.Config;


public class Ft_npcorder_walkConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_npcorder_walkConfig> _dataMap;
    private System.Collections.Generic.List<Ft_npcorder_walkConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_npcorder_walkConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_npcorder_walkConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.IndexId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_npcorder_walkConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_npcorder_walkConfig> DataList => _dataList;

    public Ft_npcorder_walkConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_npcorder_walkConfig this[int key] => _dataMap[key];
}