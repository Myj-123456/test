using Elida.Config;


public class Ft_suit_dressConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_suit_dressConfig> _dataMap;
    private System.Collections.Generic.List<Ft_suit_dressConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_suit_dressConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_suit_dressConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.ClothesId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_suit_dressConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_suit_dressConfig> DataList => _dataList;

    public Ft_suit_dressConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_suit_dressConfig this[int key] => _dataMap[key];
}