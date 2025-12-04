using Elida.Config;


public class Ft_draw_poolConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_draw_poolConfig> _dataMap;
    private System.Collections.Generic.List<Ft_draw_poolConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_draw_poolConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_draw_poolConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_draw_poolConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_draw_poolConfig> DataList => _dataList;

    public Ft_draw_poolConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_draw_poolConfig this[int key] => _dataMap[key];
}