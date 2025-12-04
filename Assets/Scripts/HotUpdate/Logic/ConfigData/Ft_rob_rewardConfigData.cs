using Elida.Config;


public class Ft_rob_rewardConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_rob_rewardConfig> _dataMap;
    private System.Collections.Generic.List<Ft_rob_rewardConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_rob_rewardConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_rob_rewardConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.IndexId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_rob_rewardConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_rob_rewardConfig> DataList => _dataList;

    public Ft_rob_rewardConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_rob_rewardConfig this[int key] => _dataMap[key];
}