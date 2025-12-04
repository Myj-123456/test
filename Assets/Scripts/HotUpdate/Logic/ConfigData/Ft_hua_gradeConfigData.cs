using Elida.Config;


public class Ft_hua_gradeConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<string, Ft_hua_gradeConfig> _dataMap;
    private System.Collections.Generic.List<Ft_hua_gradeConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_hua_gradeConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<string, Ft_hua_gradeConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.ID, item);
        }
    }

    public System.Collections.Generic.Dictionary<string, Ft_hua_gradeConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_hua_gradeConfig> DataList => _dataList;

    public Ft_hua_gradeConfig Get(string key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_hua_gradeConfig this[string key] => _dataMap[key];
}