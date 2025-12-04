using Elida.Config;


public class Module_profileConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<string, Module_profileConfig> _dataMap;
    private System.Collections.Generic.List<Module_profileConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Module_profileConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<string, Module_profileConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Key, item);
        }
    }

    public System.Collections.Generic.Dictionary<string, Module_profileConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Module_profileConfig> DataList => _dataList;

    public Module_profileConfig Get(string key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Module_profileConfig this[string key] => _dataMap[key];
}