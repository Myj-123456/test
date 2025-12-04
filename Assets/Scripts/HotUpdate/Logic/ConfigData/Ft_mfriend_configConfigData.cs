using Elida.Config;


public class Ft_mfriend_configConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_mfriend_configConfig> _dataMap;
    private System.Collections.Generic.List<Ft_mfriend_configConfig> _dataList;

    public void Parse(byte[] bytes)
    {
        _dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_mfriend_configConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_mfriend_configConfig>(_dataList.Count);
        foreach (var item in _dataList)
        {
            _dataMap[item.Id] = item;
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_mfriend_configConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_mfriend_configConfig> DataList => _dataList;

    public Ft_mfriend_configConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_mfriend_configConfig this[int key] => _dataMap[key];
    
    /// <summary>
    /// 尝试获取配置项
    /// </summary>
    /// <param name="key">等级ID</param>
    /// <param name="config">输出的配置项</param>
    /// <returns>是否成功获取</returns>
    public bool TryGetValue(int key, out Ft_mfriend_configConfig config)
    {
        return _dataMap.TryGetValue(key, out config);
    }
}