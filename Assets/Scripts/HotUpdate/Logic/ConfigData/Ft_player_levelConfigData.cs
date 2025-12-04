using Elida.Config;


public class Ft_player_levelConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_player_levelConfig> _dataMap;
    private System.Collections.Generic.List<Ft_player_levelConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_player_levelConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_player_levelConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Level, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_player_levelConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_player_levelConfig> DataList => _dataList;

    public Ft_player_levelConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_player_levelConfig this[int key] => _dataMap[key];
}