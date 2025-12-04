using Elida.Config;


public class Ft_videoConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_videoConfig> _dataMap;
    private System.Collections.Generic.List<Ft_videoConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_videoConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_videoConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Sp_id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_videoConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_videoConfig> DataList => _dataList;

    public Ft_videoConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_videoConfig this[int key] => _dataMap[key];
}