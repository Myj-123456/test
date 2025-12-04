using Elida.Config;


public class Ft_club_kanConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_club_kanConfig> _dataMap;
    private System.Collections.Generic.List<Ft_club_kanConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_club_kanConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_club_kanConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_club_kanConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_club_kanConfig> DataList => _dataList;

    public Ft_club_kanConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_club_kanConfig this[int key] => _dataMap[key];
}