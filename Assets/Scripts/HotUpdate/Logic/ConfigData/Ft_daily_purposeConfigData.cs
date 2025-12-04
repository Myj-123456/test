using Elida.Config;


public class Ft_daily_purposeConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_daily_purposeConfig> _dataMap;
    private System.Collections.Generic.List<Ft_daily_purposeConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_daily_purposeConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_daily_purposeConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.PurposeId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_daily_purposeConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_daily_purposeConfig> DataList => _dataList;

    public Ft_daily_purposeConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_daily_purposeConfig this[int key] => _dataMap[key];
}