using Elida.Config;


public class Ft_recharge_giftConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_recharge_giftConfig> _dataMap;
    private System.Collections.Generic.List<Ft_recharge_giftConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_recharge_giftConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_recharge_giftConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_recharge_giftConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_recharge_giftConfig> DataList => _dataList;

    public Ft_recharge_giftConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_recharge_giftConfig this[int key] => _dataMap[key];
}