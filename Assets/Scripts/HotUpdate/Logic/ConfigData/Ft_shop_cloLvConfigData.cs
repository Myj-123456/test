using Elida.Config;


public class Ft_shop_cloLvConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_shop_cloLvConfig> _dataMap;
    private System.Collections.Generic.List<Ft_shop_cloLvConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_shop_cloLvConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_shop_cloLvConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_shop_cloLvConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_shop_cloLvConfig> DataList => _dataList;

    public Ft_shop_cloLvConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_shop_cloLvConfig this[int key] => _dataMap[key];
}