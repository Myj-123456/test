using Elida.Config;


public class Ft_task_mainConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_task_mainConfig> _dataMap;
    private System.Collections.Generic.List<Ft_task_mainConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_task_mainConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_task_mainConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_task_mainConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_task_mainConfig> DataList => _dataList;

    public Ft_task_mainConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_task_mainConfig this[int key] => _dataMap[key];
}