using Elida.Config;


public class Ft_club_giftdaConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_club_giftdaConfig> _dataMap;
    private System.Collections.Generic.List<Ft_club_giftdaConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_club_giftdaConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_club_giftdaConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_club_giftdaConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_club_giftdaConfig> DataList => _dataList;

    public Ft_club_giftdaConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_club_giftdaConfig this[int key] => _dataMap[key];
}