using Elida.Config;


public class Ft_game_banedtext_nameConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_game_banedtext_nameConfig> _dataMap;
    private System.Collections.Generic.List<Ft_game_banedtext_nameConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_game_banedtext_nameConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_game_banedtext_nameConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Index, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_game_banedtext_nameConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_game_banedtext_nameConfig> DataList => _dataList;

    public Ft_game_banedtext_nameConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_game_banedtext_nameConfig this[int key] => _dataMap[key];
}