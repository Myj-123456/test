using Elida.Config;


public class Ft_rank_bookConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_rank_bookConfig> _dataMap;
    private System.Collections.Generic.List<Ft_rank_bookConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_rank_bookConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_rank_bookConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.IndexId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_rank_bookConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_rank_bookConfig> DataList => _dataList;

    public Ft_rank_bookConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_rank_bookConfig this[int key] => _dataMap[key];
}