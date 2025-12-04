using Elida.Config;


public class Ft_club_shopConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_club_shopConfig> _dataMap;
    private System.Collections.Generic.List<Ft_club_shopConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_club_shopConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_club_shopConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.IndexId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_club_shopConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_club_shopConfig> DataList => _dataList;

    public Ft_club_shopConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_club_shopConfig this[int key] => _dataMap[key];
}