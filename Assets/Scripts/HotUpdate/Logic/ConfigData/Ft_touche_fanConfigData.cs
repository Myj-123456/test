using Elida.Config;


public class Ft_touche_fanConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_touche_fanConfig> _dataMap;
    private System.Collections.Generic.List<Ft_touche_fanConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_touche_fanConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_touche_fanConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_touche_fanConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_touche_fanConfig> DataList => _dataList;

    public Ft_touche_fanConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_touche_fanConfig this[int key] => _dataMap[key];
}