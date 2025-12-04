using Elida.Config;


public class Ft_ikebana_flowerConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_ikebana_flowerConfig> _dataMap;
    private System.Collections.Generic.List<Ft_ikebana_flowerConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_ikebana_flowerConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_ikebana_flowerConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.FlowersDI, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_ikebana_flowerConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_ikebana_flowerConfig> DataList => _dataList;

    public Ft_ikebana_flowerConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_ikebana_flowerConfig this[int key] => _dataMap[key];
}