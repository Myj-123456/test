using Elida.Config;


public class Ft_friends_deal_gridConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_friends_deal_gridConfig> _dataMap;
    private System.Collections.Generic.List<Ft_friends_deal_gridConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_friends_deal_gridConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_friends_deal_gridConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.IndexId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_friends_deal_gridConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_friends_deal_gridConfig> DataList => _dataList;

    public Ft_friends_deal_gridConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_friends_deal_gridConfig this[int key] => _dataMap[key];
}