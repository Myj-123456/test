using Elida.Config;


public class Ft_plot_chapterConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_plot_chapterConfig> _dataMap;
    private System.Collections.Generic.List<Ft_plot_chapterConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_plot_chapterConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_plot_chapterConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_plot_chapterConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_plot_chapterConfig> DataList => _dataList;

    public Ft_plot_chapterConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_plot_chapterConfig this[int key] => _dataMap[key];
}