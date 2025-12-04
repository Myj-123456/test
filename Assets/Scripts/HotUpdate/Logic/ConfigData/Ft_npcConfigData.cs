using Elida.Config;


public class Ft_npcConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_npcConfig> _dataMap;
    private System.Collections.Generic.List<Ft_npcConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_npcConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_npcConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_npcConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_npcConfig> DataList => _dataList;

    public Ft_npcConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_npcConfig this[int key] => _dataMap[key];
}