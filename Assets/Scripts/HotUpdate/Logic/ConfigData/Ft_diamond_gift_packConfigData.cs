using Elida.Config;


public class Ft_diamond_gift_packConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_diamond_gift_packConfig> _dataMap;
    private System.Collections.Generic.List<Ft_diamond_gift_packConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_diamond_gift_packConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_diamond_gift_packConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.GiftPackageId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_diamond_gift_packConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_diamond_gift_packConfig> DataList => _dataList;

    public Ft_diamond_gift_packConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_diamond_gift_packConfig this[int key] => _dataMap[key];
}