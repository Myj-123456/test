using Elida.Config;


public class Ft_suit_backConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_suit_backConfig> _dataMap;
    private System.Collections.Generic.List<Ft_suit_backConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_suit_backConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_suit_backConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_suit_backConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_suit_backConfig> DataList => _dataList;

    public Ft_suit_backConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_suit_backConfig this[int key] => _dataMap[key];
}