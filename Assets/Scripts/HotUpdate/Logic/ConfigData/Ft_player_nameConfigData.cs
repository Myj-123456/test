using Elida.Config;


public class Ft_player_nameConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_player_nameConfig> _dataMap;
    private System.Collections.Generic.List<Ft_player_nameConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_player_nameConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_player_nameConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_player_nameConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_player_nameConfig> DataList => _dataList;

    public Ft_player_nameConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_player_nameConfig this[int key] => _dataMap[key];
}