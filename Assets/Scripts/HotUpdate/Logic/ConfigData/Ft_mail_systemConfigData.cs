using Elida.Config;


public class Ft_mail_systemConfigData : BaseConfig
{
    private System.Collections.Generic.Dictionary<int, Ft_mail_systemConfig> _dataMap;
    private System.Collections.Generic.List<Ft_mail_systemConfig> _dataList;

    public void Parse(byte[] bytes)
    {
		_dataList = PbHelper.ProtoDeSerialize<System.Collections.Generic.List<Ft_mail_systemConfig>>(bytes);
        _dataMap = new System.Collections.Generic.Dictionary<int, Ft_mail_systemConfig>(_dataList.Count);

        foreach (var item in _dataList)
        {
            _dataMap.Add(item.MailId, item);
        }
    }

    public System.Collections.Generic.Dictionary<int, Ft_mail_systemConfig> DataMap => _dataMap;
    public System.Collections.Generic.List<Ft_mail_systemConfig> DataList => _dataList;

    public Ft_mail_systemConfig Get(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Ft_mail_systemConfig this[int key] => _dataMap[key];
}