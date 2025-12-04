using Elida.Config;


public class Ft_shop_clothesConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_shop_clothesConfig> _dataMap;
    private System.Collections.Generic.List<Ft_shop_clothesConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_shop_clothesConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_shop_clothesConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_shop_clothesConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_shop_clothesConfig> DataList => _dataList;

    public Ft_shop_clothesConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_shop_clothesConfig this[int key] => _dataMap[key];
}