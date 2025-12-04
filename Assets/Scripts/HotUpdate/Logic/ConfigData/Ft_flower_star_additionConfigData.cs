using Elida.Config;


public class Ft_flower_star_additionConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_flower_star_additionConfig> _dataMap;
    private System.Collections.Generic.List<Ft_flower_star_additionConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_flower_star_additionConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_flower_star_additionConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.ID, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_flower_star_additionConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_flower_star_additionConfig> DataList => _dataList;

    public Ft_flower_star_additionConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_flower_star_additionConfig this[int key] => _dataMap[key];
}