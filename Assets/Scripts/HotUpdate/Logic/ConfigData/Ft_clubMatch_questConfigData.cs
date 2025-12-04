using Elida.Config;


public class Ft_clubMatch_questConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_clubMatch_questConfig> _dataMap;
    private System.Collections.Generic.List<Ft_clubMatch_questConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_clubMatch_questConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_clubMatch_questConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_clubMatch_questConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_clubMatch_questConfig> DataList => _dataList;

    public Ft_clubMatch_questConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_clubMatch_questConfig this[int key] => _dataMap[key];
}