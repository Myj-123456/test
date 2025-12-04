using Elida.Config;


public class Ft_fairy_levelConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<string, Ft_fairy_levelConfig> _dataMap;
    private System.Collections.Generic.List<Ft_fairy_levelConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_fairy_levelConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<string, Ft_fairy_levelConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<string, Ft_fairy_levelConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_fairy_levelConfig> DataList => _dataList;

    public Ft_fairy_levelConfig Get(string key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_fairy_levelConfig this[string key] => _dataMap[key];
}