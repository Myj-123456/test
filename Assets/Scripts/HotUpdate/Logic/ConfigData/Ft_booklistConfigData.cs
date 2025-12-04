using Elida.Config;


public class Ft_booklistConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_booklistConfig> _dataMap;
    private System.Collections.Generic.List<Ft_booklistConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_booklistConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_booklistConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.BookId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_booklistConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_booklistConfig> DataList => _dataList;

    public Ft_booklistConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_booklistConfig this[int key] => _dataMap[key];
}