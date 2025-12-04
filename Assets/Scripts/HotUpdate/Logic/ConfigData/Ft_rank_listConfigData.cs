using Elida.Config;


public class Ft_rank_listConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_rank_listConfig> _dataMap;
    private System.Collections.Generic.List<Ft_rank_listConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_rank_listConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_rank_listConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.IndexId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_rank_listConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_rank_listConfig> DataList => _dataList;

    public Ft_rank_listConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_rank_listConfig this[int key] => _dataMap[key];
}