using Elida.Config;


public class Ft_ikebana_vaseConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_ikebana_vaseConfig> _dataMap;
    private System.Collections.Generic.List<Ft_ikebana_vaseConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_ikebana_vaseConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_ikebana_vaseConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.VaseId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_ikebana_vaseConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_ikebana_vaseConfig> DataList => _dataList;

    public Ft_ikebana_vaseConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_ikebana_vaseConfig this[int key] => _dataMap[key];
}