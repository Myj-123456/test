using Elida.Config;


public class Ft_florist_suitConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_florist_suitConfig> _dataMap;
    private System.Collections.Generic.List<Ft_florist_suitConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_florist_suitConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_florist_suitConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_florist_suitConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_florist_suitConfig> DataList => _dataList;

    public Ft_florist_suitConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_florist_suitConfig this[int key] => _dataMap[key];
}