using Elida.Config;


public class Ft_player_gradeConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_player_gradeConfig> _dataMap;
    private System.Collections.Generic.List<Ft_player_gradeConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_player_gradeConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_player_gradeConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Grade, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_player_gradeConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_player_gradeConfig> DataList => _dataList;

    public Ft_player_gradeConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_player_gradeConfig this[int key] => _dataMap[key];
}