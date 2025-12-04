using Elida.Config;


public class Ft_game_system_unlockConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_game_system_unlockConfig> _dataMap;
    private System.Collections.Generic.List<Ft_game_system_unlockConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_game_system_unlockConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_game_system_unlockConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.SysId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_game_system_unlockConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_game_system_unlockConfig> DataList => _dataList;

    public Ft_game_system_unlockConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_game_system_unlockConfig this[int key] => _dataMap[key];
}