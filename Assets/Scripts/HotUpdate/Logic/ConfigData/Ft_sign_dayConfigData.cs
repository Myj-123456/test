using Elida.Config;


public class Ft_sign_dayConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_sign_dayConfig> _dataMap;
    private System.Collections.Generic.List<Ft_sign_dayConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_sign_dayConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_sign_dayConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_sign_dayConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_sign_dayConfig> DataList => _dataList;

    public Ft_sign_dayConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_sign_dayConfig this[int key] => _dataMap[key];
}