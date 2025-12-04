using Elida.Config;


public class Ft_breedshop_itemConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_breedshop_itemConfig> _dataMap;
    private System.Collections.Generic.List<Ft_breedshop_itemConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_breedshop_itemConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_breedshop_itemConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_breedshop_itemConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_breedshop_itemConfig> DataList => _dataList;

    public Ft_breedshop_itemConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_breedshop_itemConfig this[int key] => _dataMap[key];
}