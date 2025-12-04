using Elida.Config;


public class Ft_order_npcConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_order_npcConfig> _dataMap;
    private System.Collections.Generic.List<Ft_order_npcConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_order_npcConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_order_npcConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Npcid, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_order_npcConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_order_npcConfig> DataList => _dataList;

    public Ft_order_npcConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_order_npcConfig this[int key] => _dataMap[key];
}