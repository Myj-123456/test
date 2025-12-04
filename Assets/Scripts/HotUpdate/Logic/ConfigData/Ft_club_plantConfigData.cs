using Elida.Config;


public class Ft_club_plantConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_club_plantConfig> _dataMap;
    private System.Collections.Generic.List<Ft_club_plantConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_club_plantConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_club_plantConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_club_plantConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_club_plantConfig> DataList => _dataList;

    public Ft_club_plantConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_club_plantConfig this[int key] => _dataMap[key];
}