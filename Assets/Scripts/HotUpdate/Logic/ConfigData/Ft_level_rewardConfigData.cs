using Elida.Config;


public class Ft_level_rewardConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_level_rewardConfig> _dataMap;
    private System.Collections.Generic.List<Ft_level_rewardConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_level_rewardConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_level_rewardConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_level_rewardConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_level_rewardConfig> DataList => _dataList;

    public Ft_level_rewardConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_level_rewardConfig this[int key] => _dataMap[key];
}