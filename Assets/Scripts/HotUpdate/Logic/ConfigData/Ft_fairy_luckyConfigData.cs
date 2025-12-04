using Elida.Config;


public class Ft_fairy_luckyConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_fairy_luckyConfig> _dataMap;
    private System.Collections.Generic.List<Ft_fairy_luckyConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_fairy_luckyConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_fairy_luckyConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_fairy_luckyConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_fairy_luckyConfig> DataList => _dataList;

    public Ft_fairy_luckyConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_fairy_luckyConfig this[int key] => _dataMap[key];
}