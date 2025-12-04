using Elida.Config;


public class Ft_suit_advanceConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<string, Ft_suit_advanceConfig> _dataMap;
    private System.Collections.Generic.List<Ft_suit_advanceConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_suit_advanceConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<string, Ft_suit_advanceConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<string, Ft_suit_advanceConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_suit_advanceConfig> DataList => _dataList;

    public Ft_suit_advanceConfig Get(string key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_suit_advanceConfig this[string key] => _dataMap[key];
}