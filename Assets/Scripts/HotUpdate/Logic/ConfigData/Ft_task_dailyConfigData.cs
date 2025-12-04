using Elida.Config;


public class Ft_task_dailyConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_task_dailyConfig> _dataMap;
    private System.Collections.Generic.List<Ft_task_dailyConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_task_dailyConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_task_dailyConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.TaskId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_task_dailyConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_task_dailyConfig> DataList => _dataList;

    public Ft_task_dailyConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_task_dailyConfig this[int key] => _dataMap[key];
}