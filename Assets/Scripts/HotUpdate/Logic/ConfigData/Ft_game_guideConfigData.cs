using Elida.Config;


public class Ft_game_guideConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_game_guideConfig> _dataMap;
    private System.Collections.Generic.List<Ft_game_guideConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_game_guideConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_game_guideConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.IndexId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_game_guideConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_game_guideConfig> DataList => _dataList;

    public Ft_game_guideConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_game_guideConfig this[int key] => _dataMap[key];
}