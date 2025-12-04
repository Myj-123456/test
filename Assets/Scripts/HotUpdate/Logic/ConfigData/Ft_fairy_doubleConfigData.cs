using Elida.Config;


public class Ft_fairy_doubleConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_fairy_doubleConfig> _dataMap;
    private System.Collections.Generic.List<Ft_fairy_doubleConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_fairy_doubleConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_fairy_doubleConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_fairy_doubleConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_fairy_doubleConfig> DataList => _dataList;

    public Ft_fairy_doubleConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_fairy_doubleConfig this[int key] => _dataMap[key];
}