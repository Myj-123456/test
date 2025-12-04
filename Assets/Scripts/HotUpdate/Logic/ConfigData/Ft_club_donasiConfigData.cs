using Elida.Config;


public class Ft_club_donasiConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_club_donasiConfig> _dataMap;
    private System.Collections.Generic.List<Ft_club_donasiConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_club_donasiConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_club_donasiConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Jenis, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_club_donasiConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_club_donasiConfig> DataList => _dataList;

    public Ft_club_donasiConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_club_donasiConfig this[int key] => _dataMap[key];
}