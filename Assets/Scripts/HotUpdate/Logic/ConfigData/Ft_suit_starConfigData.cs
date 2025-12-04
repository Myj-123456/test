using Elida.Config;


public class Ft_suit_starConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<string, Ft_suit_starConfig> _dataMap;
    private System.Collections.Generic.List<Ft_suit_starConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_suit_starConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<string, Ft_suit_starConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<string, Ft_suit_starConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_suit_starConfig> DataList => _dataList;

    public Ft_suit_starConfig Get(string key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_suit_starConfig this[string key] => _dataMap[key];
}