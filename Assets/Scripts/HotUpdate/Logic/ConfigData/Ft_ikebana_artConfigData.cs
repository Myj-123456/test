using Elida.Config;


public class Ft_ikebana_artConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_ikebana_artConfig> _dataMap;
    private System.Collections.Generic.List<Ft_ikebana_artConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_ikebana_artConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_ikebana_artConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.CombinationId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_ikebana_artConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_ikebana_artConfig> DataList => _dataList;

    public Ft_ikebana_artConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_ikebana_artConfig this[int key] => _dataMap[key];
}