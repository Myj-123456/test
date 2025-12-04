using Elida.Config;


public class Ft_npc_giftConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_npc_giftConfig> _dataMap;
    private System.Collections.Generic.List<Ft_npc_giftConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_npc_giftConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_npc_giftConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_npc_giftConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_npc_giftConfig> DataList => _dataList;

    public Ft_npc_giftConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_npc_giftConfig this[int key] => _dataMap[key];
}