using Elida.Config;


public class Ft_contract_frewardConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_contract_frewardConfig> _dataMap;
    private System.Collections.Generic.List<Ft_contract_frewardConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_contract_frewardConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_contract_frewardConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.Id, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_contract_frewardConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_contract_frewardConfig> DataList => _dataList;

    public Ft_contract_frewardConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_contract_frewardConfig this[int key] => _dataMap[key];
}