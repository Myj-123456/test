using Elida.Config;


public class Ft_rank_waterConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_rank_waterConfig> _dataMap;
    private System.Collections.Generic.List<Ft_rank_waterConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_rank_waterConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_rank_waterConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.IndexId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_rank_waterConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_rank_waterConfig> DataList => _dataList;

    public Ft_rank_waterConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_rank_waterConfig this[int key] => _dataMap[key];
}