using Elida.Config;


public class Ft_enemy_attConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_enemy_attConfig> _dataMap;
    private System.Collections.Generic.List<Ft_enemy_attConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_enemy_attConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_enemy_attConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_enemy_attConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_enemy_attConfig> DataList => _dataList;

    public Ft_enemy_attConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_enemy_attConfig this[int key] => _dataMap[key];
}