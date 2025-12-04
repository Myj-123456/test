using Elida.Config;


public class Ft_game_payConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<string, Ft_game_payConfig> _dataMap;
    private System.Collections.Generic.List<Ft_game_payConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_game_payConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<string, Ft_game_payConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.ProductId, item);
        }
    }

    public System.Collections.Generic.Dictionary<string, Ft_game_payConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_game_payConfig> DataList => _dataList;

    public Ft_game_payConfig Get(string key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_game_payConfig this[string key] => _dataMap[key];
}