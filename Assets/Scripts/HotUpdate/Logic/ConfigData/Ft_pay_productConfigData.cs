using Elida.Config;


public class Ft_pay_productConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_pay_productConfig> _dataMap;
    private System.Collections.Generic.List<Ft_pay_productConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_pay_productConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_pay_productConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.PriceId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_pay_productConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_pay_productConfig> DataList => _dataList;

    public Ft_pay_productConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_pay_productConfig this[int key] => _dataMap[key];
}