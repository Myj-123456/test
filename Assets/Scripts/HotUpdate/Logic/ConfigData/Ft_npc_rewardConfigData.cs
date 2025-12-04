using Elida.Config;


public class Ft_npc_rewardConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<string, Ft_npc_rewardConfig> _dataMap;
    private System.Collections.Generic.List<Ft_npc_rewardConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_npc_rewardConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<string, Ft_npc_rewardConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<string, Ft_npc_rewardConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_npc_rewardConfig> DataList => _dataList;

    public Ft_npc_rewardConfig Get(string key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_npc_rewardConfig this[string key] => _dataMap[key];
}