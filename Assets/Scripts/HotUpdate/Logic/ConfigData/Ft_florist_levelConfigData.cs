using Elida.Config;


public class Ft_florist_levelConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_florist_levelConfig> _dataMap;
    private System.Collections.Generic.List<Ft_florist_levelConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_florist_levelConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_florist_levelConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_florist_levelConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_florist_levelConfig> DataList => _dataList;

    public Ft_florist_levelConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_florist_levelConfig this[int key] => _dataMap[key];
}