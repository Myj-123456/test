using Elida.Config;


public class Ft_hua_breedConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_hua_breedConfig> _dataMap;
    private System.Collections.Generic.List<Ft_hua_breedConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_hua_breedConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_hua_breedConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.FlowerId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_hua_breedConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_hua_breedConfig> DataList => _dataList;

    public Ft_hua_breedConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_hua_breedConfig this[int key] => _dataMap[key];
}