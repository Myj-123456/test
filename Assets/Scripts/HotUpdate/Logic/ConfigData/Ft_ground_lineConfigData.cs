using Elida.Config;


public class Ft_ground_lineConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_ground_lineConfig> _dataMap;
    private System.Collections.Generic.List<Ft_ground_lineConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_ground_lineConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_ground_lineConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.LineId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_ground_lineConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_ground_lineConfig> DataList => _dataList;

    public Ft_ground_lineConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_ground_lineConfig this[int key] => _dataMap[key];
}