using Elida.Config;


public class Ft_game_eventConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_game_eventConfig> _dataMap;
    private System.Collections.Generic.List<Ft_game_eventConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_game_eventConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_game_eventConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.IndexId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_game_eventConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_game_eventConfig> DataList => _dataList;

    public Ft_game_eventConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_game_eventConfig this[int key] => _dataMap[key];
}