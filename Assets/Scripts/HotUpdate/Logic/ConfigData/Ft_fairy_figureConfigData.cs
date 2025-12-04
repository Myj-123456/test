using Elida.Config;


public class Ft_fairy_figureConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_fairy_figureConfig> _dataMap;
    private System.Collections.Generic.List<Ft_fairy_figureConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_fairy_figureConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_fairy_figureConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_fairy_figureConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_fairy_figureConfig> DataList => _dataList;

    public Ft_fairy_figureConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_fairy_figureConfig this[int key] => _dataMap[key];
}