using Elida.Config;


public class Ft_task_levelConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_task_levelConfig> _dataMap;
    private System.Collections.Generic.List<Ft_task_levelConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_task_levelConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_task_levelConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Level, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_task_levelConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_task_levelConfig> DataList => _dataList;

    public Ft_task_levelConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_task_levelConfig this[int key] => _dataMap[key];
}