using Elida.Config;


public class Ft_suit_dRewardConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_suit_dRewardConfig> _dataMap;
    private System.Collections.Generic.List<Ft_suit_dRewardConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_suit_dRewardConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_suit_dRewardConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_suit_dRewardConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_suit_dRewardConfig> DataList => _dataList;

    public Ft_suit_dRewardConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_suit_dRewardConfig this[int key] => _dataMap[key];
}