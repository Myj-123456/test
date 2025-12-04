using Elida.Config;


public class Ft_club_othersConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_club_othersConfig> _dataMap;
    private System.Collections.Generic.List<Ft_club_othersConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_club_othersConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_club_othersConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.IndexId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_club_othersConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_club_othersConfig> DataList => _dataList;

    public Ft_club_othersConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_club_othersConfig this[int key] => _dataMap[key];
}