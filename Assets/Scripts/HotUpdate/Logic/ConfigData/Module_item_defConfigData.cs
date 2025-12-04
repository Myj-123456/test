using Elida.Config;


public class Module_item_defConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Module_item_defConfig> _dataMap;
    private System.Collections.Generic.List<Module_item_defConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Module_item_defConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Module_item_defConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.ItemDefId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Module_item_defConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Module_item_defConfig> DataList => _dataList;

    public Module_item_defConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Module_item_defConfig this[int key] => _dataMap[key];
}