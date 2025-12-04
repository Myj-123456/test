using Elida.Config;


public class Ft_mallConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_mallConfig> _dataMap;
    private System.Collections.Generic.List<Ft_mallConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_mallConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_mallConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_mallConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_mallConfig> DataList => _dataList;

    public Ft_mallConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_mallConfig this[int key] => _dataMap[key];
}