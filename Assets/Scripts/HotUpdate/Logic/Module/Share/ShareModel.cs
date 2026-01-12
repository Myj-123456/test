using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using UnityEngine;

public class ShareModel : Singleton<ShareModel>
{
    private Dictionary<int, Ft_shareConfig> _shareMap;
    public Dictionary<int, Ft_shareConfig> shareMap
    {
        get
        {
            if(_shareMap == null)
            {
                var shareData = ConfigManager.Instance.GetConfig<Ft_shareConfigData>("ft_sharesConfig");
                _shareMap = shareData.DataMap;
            }
            return _shareMap;
        }
    }

    public Ft_shareConfig GetShareInfo(int id)
    {
        if (shareMap.ContainsKey(id)){
            return shareMap[id];
        }
        return null;
    }
}

