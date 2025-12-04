using Elida.Config;


public class Ft_gift_pack2ConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_gift_pack2Config> _dataMap;
    private System.Collections.Generic.List<Ft_gift_pack2Config> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_gift_pack2Config>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_gift_pack2Config>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.GiftId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_gift_pack2Config> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_gift_pack2Config> DataList => _dataList;

    public Ft_gift_pack2Config Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_gift_pack2Config this[int key] => _dataMap[key];
}