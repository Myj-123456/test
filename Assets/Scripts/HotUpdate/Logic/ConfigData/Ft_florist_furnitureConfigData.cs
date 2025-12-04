using Elida.Config;


public class Ft_florist_furnitureConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_florist_furnitureConfig> _dataMap;
    private System.Collections.Generic.List<Ft_florist_furnitureConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_florist_furnitureConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_florist_furnitureConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_florist_furnitureConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_florist_furnitureConfig> DataList => _dataList;

    public Ft_florist_furnitureConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_florist_furnitureConfig this[int key] => _dataMap[key];
}