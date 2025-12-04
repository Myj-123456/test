using Elida.Config;


public class Ft_hua_attributeConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_hua_attributeConfig> _dataMap;
    private System.Collections.Generic.List<Ft_hua_attributeConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_hua_attributeConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_hua_attributeConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.ID, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_hua_attributeConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_hua_attributeConfig> DataList => _dataList;

    public Ft_hua_attributeConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_hua_attributeConfig this[int key] => _dataMap[key];
}