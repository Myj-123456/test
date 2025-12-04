using Elida.Config;


public class Ft_club_iconConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_club_iconConfig> _dataMap;
    private System.Collections.Generic.List<Ft_club_iconConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_club_iconConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_club_iconConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_club_iconConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_club_iconConfig> DataList => _dataList;

    public Ft_club_iconConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_club_iconConfig this[int key] => _dataMap[key];
}