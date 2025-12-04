using Elida.Config;


public class Ft_suit_skillConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_suit_skillConfig> _dataMap;
    private System.Collections.Generic.List<Ft_suit_skillConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_suit_skillConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_suit_skillConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_suit_skillConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_suit_skillConfig> DataList => _dataList;

    public Ft_suit_skillConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_suit_skillConfig this[int key] => _dataMap[key];
}