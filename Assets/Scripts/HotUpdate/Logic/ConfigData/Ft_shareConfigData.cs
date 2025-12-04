using Elida.Config;


public class Ft_shareConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_shareConfig> _dataMap;
    private System.Collections.Generic.List<Ft_shareConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_shareConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_shareConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Fx_id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_shareConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_shareConfig> DataList => _dataList;

    public Ft_shareConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_shareConfig this[int key] => _dataMap[key];
}