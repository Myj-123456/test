using Elida.Config;


public class Ft_friends_deal_itemsConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_friends_deal_itemsConfig> _dataMap;
    private System.Collections.Generic.List<Ft_friends_deal_itemsConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_friends_deal_itemsConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_friends_deal_itemsConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.IndexId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_friends_deal_itemsConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_friends_deal_itemsConfig> DataList => _dataList;

    public Ft_friends_deal_itemsConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_friends_deal_itemsConfig this[int key] => _dataMap[key];
}