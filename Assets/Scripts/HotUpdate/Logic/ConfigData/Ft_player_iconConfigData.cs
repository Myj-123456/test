using Elida.Config;


public class Ft_player_iconConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_player_iconConfig> _dataMap;
    private System.Collections.Generic.List<Ft_player_iconConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_player_iconConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_player_iconConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_player_iconConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_player_iconConfig> DataList => _dataList;

    public Ft_player_iconConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_player_iconConfig this[int key] => _dataMap[key];
}