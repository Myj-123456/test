using Elida.Config;


public class Ft_emojiConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_emojiConfig> _dataMap;
    private System.Collections.Generic.List<Ft_emojiConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_emojiConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_emojiConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_emojiConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_emojiConfig> DataList => _dataList;

    public Ft_emojiConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_emojiConfig this[int key] => _dataMap[key];
}