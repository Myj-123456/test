using Elida.Config;


public class Ft_npc_buffConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_npc_buffConfig> _dataMap;
    private System.Collections.Generic.List<Ft_npc_buffConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_npc_buffConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_npc_buffConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_npc_buffConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_npc_buffConfig> DataList => _dataList;

    public Ft_npc_buffConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_npc_buffConfig this[int key] => _dataMap[key];
}