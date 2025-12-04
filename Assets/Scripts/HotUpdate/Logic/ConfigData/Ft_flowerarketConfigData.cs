using Elida.Config;


public class Ft_flowerarketConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_flowerarketConfig> _dataMap;
    private System.Collections.Generic.List<Ft_flowerarketConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_flowerarketConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_flowerarketConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_flowerarketConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_flowerarketConfig> DataList => _dataList;

    public Ft_flowerarketConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_flowerarketConfig this[int key] => _dataMap[key];
}