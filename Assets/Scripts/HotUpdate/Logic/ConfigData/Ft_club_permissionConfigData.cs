using Elida.Config;


public class Ft_club_permissionConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_club_permissionConfig> _dataMap;
    private System.Collections.Generic.List<Ft_club_permissionConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_club_permissionConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_club_permissionConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.GuildPosition, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_club_permissionConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_club_permissionConfig> DataList => _dataList;

    public Ft_club_permissionConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_club_permissionConfig this[int key] => _dataMap[key];
}