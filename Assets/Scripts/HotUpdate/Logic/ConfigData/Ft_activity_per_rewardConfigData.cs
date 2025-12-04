using Elida.Config;


public class Ft_activity_per_rewardConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_activity_per_rewardConfig> _dataMap;
    private System.Collections.Generic.List<Ft_activity_per_rewardConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_activity_per_rewardConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_activity_per_rewardConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_activity_per_rewardConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_activity_per_rewardConfig> DataList => _dataList;

    public Ft_activity_per_rewardConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_activity_per_rewardConfig this[int key] => _dataMap[key];
}