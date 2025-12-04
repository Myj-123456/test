using Elida.Config;


public class Ft_fairy_identifyConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_fairy_identifyConfig> _dataMap;
    private System.Collections.Generic.List<Ft_fairy_identifyConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_fairy_identifyConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_fairy_identifyConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_fairy_identifyConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_fairy_identifyConfig> DataList => _dataList;

    public Ft_fairy_identifyConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_fairy_identifyConfig this[int key] => _dataMap[key];
}