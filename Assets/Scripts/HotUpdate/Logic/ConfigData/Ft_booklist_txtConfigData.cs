using Elida.Config;


public class Ft_booklist_txtConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_booklist_txtConfig> _dataMap;
    private System.Collections.Generic.List<Ft_booklist_txtConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_booklist_txtConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_booklist_txtConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.BookId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_booklist_txtConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_booklist_txtConfig> DataList => _dataList;

    public Ft_booklist_txtConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_booklist_txtConfig this[int key] => _dataMap[key];
}