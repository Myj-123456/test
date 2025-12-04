using Elida.Config;


public class Ft_loli_collectionConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_loli_collectionConfig> _dataMap;
    private System.Collections.Generic.List<Ft_loli_collectionConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_loli_collectionConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_loli_collectionConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_loli_collectionConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_loli_collectionConfig> DataList => _dataList;

    public Ft_loli_collectionConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_loli_collectionConfig this[int key] => _dataMap[key];
}