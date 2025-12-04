using Elida.Config;


public class Ft_game_banedtextConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_game_banedtextConfig> _dataMap;
    private System.Collections.Generic.List<Ft_game_banedtextConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_game_banedtextConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_game_banedtextConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Index, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_game_banedtextConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_game_banedtextConfig> DataList => _dataList;

    public Ft_game_banedtextConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_game_banedtextConfig this[int key] => _dataMap[key];
}