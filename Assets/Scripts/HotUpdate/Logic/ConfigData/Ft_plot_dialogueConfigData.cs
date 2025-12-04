using Elida.Config;


public class Ft_plot_dialogueConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_plot_dialogueConfig> _dataMap;
    private System.Collections.Generic.List<Ft_plot_dialogueConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_plot_dialogueConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_plot_dialogueConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_plot_dialogueConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_plot_dialogueConfig> DataList => _dataList;

    public Ft_plot_dialogueConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_plot_dialogueConfig this[int key] => _dataMap[key];
}