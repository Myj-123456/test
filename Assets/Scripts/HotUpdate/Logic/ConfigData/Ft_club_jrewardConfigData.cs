using Elida.Config;


public class Ft_club_jrewardConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_club_jrewardConfig> _dataMap;
    private System.Collections.Generic.List<Ft_club_jrewardConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_club_jrewardConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_club_jrewardConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_club_jrewardConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_club_jrewardConfig> DataList => _dataList;

    public Ft_club_jrewardConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_club_jrewardConfig this[int key] => _dataMap[key];
}