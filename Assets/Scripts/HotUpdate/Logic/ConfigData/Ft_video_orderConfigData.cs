using Elida.Config;


public class Ft_video_orderConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_video_orderConfig> _dataMap;
    private System.Collections.Generic.List<Ft_video_orderConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_video_orderConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_video_orderConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_video_orderConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_video_orderConfig> DataList => _dataList;

    public Ft_video_orderConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_video_orderConfig this[int key] => _dataMap[key];
}