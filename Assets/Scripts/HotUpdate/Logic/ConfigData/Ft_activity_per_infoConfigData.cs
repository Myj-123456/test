using Elida.Config;


public class Ft_activity_per_infoConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_activity_per_infoConfig> _dataMap;
    private System.Collections.Generic.List<Ft_activity_per_infoConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_activity_per_infoConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_activity_per_infoConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_activity_per_infoConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_activity_per_infoConfig> DataList => _dataList;

    public Ft_activity_per_infoConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_activity_per_infoConfig this[int key] => _dataMap[key];
}