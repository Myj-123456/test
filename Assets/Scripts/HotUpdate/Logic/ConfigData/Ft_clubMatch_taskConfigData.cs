using Elida.Config;


public class Ft_clubMatch_taskConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_clubMatch_taskConfig> _dataMap;
    private System.Collections.Generic.List<Ft_clubMatch_taskConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_clubMatch_taskConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_clubMatch_taskConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.IndexId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_clubMatch_taskConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_clubMatch_taskConfig> DataList => _dataList;

    public Ft_clubMatch_taskConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_clubMatch_taskConfig this[int key] => _dataMap[key];
}