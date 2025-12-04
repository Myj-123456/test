using Elida.Config;


public class Ft_player_attrsConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_player_attrsConfig> _dataMap;
    private System.Collections.Generic.List<Ft_player_attrsConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_player_attrsConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_player_attrsConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.ID, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_player_attrsConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_player_attrsConfig> DataList => _dataList;

    public Ft_player_attrsConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_player_attrsConfig this[int key] => _dataMap[key];
}