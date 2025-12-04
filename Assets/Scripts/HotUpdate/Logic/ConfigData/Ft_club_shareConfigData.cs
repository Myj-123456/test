using Elida.Config;


public class Ft_club_shareConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_club_shareConfig> _dataMap;
    private System.Collections.Generic.List<Ft_club_shareConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_club_shareConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_club_shareConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_club_shareConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_club_shareConfig> DataList => _dataList;

    public Ft_club_shareConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_club_shareConfig this[int key] => _dataMap[key];
}