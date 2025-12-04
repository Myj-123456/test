using Elida.Config;


public class Ft_shop_storeConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_shop_storeConfig> _dataMap;
    private System.Collections.Generic.List<Ft_shop_storeConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_shop_storeConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_shop_storeConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_shop_storeConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_shop_storeConfig> DataList => _dataList;

    public Ft_shop_storeConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_shop_storeConfig this[int key] => _dataMap[key];
}