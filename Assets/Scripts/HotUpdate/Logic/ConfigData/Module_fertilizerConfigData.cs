using Elida.Config;


public class Module_fertilizerConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Module_fertilizerConfig> _dataMap;
    private System.Collections.Generic.List<Module_fertilizerConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Module_fertilizerConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Module_fertilizerConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.ItemId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Module_fertilizerConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Module_fertilizerConfig> DataList => _dataList;

    public Module_fertilizerConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Module_fertilizerConfig this[int key] => _dataMap[key];
}