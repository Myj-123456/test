using Elida.Config;


public class Ft_plot_configConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_plot_configConfig> _dataMap;
    private System.Collections.Generic.List<Ft_plot_configConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_plot_configConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_plot_configConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_plot_configConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_plot_configConfig> DataList => _dataList;

    public Ft_plot_configConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_plot_configConfig this[int key] => _dataMap[key];
}