using Elida.Config;


public class Ft_draw_configConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_draw_configConfig> _dataMap;
    private System.Collections.Generic.List<Ft_draw_configConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_draw_configConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_draw_configConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_draw_configConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_draw_configConfig> DataList => _dataList;

    public Ft_draw_configConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_draw_configConfig this[int key] => _dataMap[key];
}