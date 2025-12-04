using Elida.Config;


public class Ft_tudiConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_tudiConfig> _dataMap;
    private System.Collections.Generic.List<Ft_tudiConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_tudiConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_tudiConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.GridId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_tudiConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_tudiConfig> DataList => _dataList;

    public Ft_tudiConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_tudiConfig this[int key] => _dataMap[key];
}