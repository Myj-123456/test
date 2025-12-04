using Elida.Config;


public class Ft_flower_star_refreshConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_flower_star_refreshConfig> _dataMap;
    private System.Collections.Generic.List<Ft_flower_star_refreshConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_flower_star_refreshConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_flower_star_refreshConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.RefreshStar, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_flower_star_refreshConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_flower_star_refreshConfig> DataList => _dataList;

    public Ft_flower_star_refreshConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_flower_star_refreshConfig this[int key] => _dataMap[key];
}