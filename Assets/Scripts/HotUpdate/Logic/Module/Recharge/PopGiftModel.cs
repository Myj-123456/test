using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using protobuf.recharge;
using UnityEngine;

public class PopGiftModel : Singleton<PopGiftModel>
{
    private Dictionary<int, Ft_diamond_gift_packConfig> _giftPackMap;
    public Dictionary<int, Ft_diamond_gift_packConfig> giftPackMap { get
        {
            if(_giftPackMap == null)
            {
                var giftPackData = ConfigManager.Instance.GetConfig<Ft_diamond_gift_packConfigData>("ft_diamond_gift_packsConfig");
                _giftPackMap = giftPackData.DataMap;
            }
            return _giftPackMap;
        } }

    public List<I_GIFTPACK_VO> giftPackList;//限时礼包
    public List<I_TOUR_VO> tourList;//巡回礼包
    public Ft_diamond_gift_packConfig GetGiftPackInfo(int id)
    {
        if (giftPackMap.ContainsKey(id))
        {
            return giftPackMap[id];
        }
        return null;
    }

    public I_GIFTPACK_VO GiftPackData(uint id)
    {
        return giftPackList.Find(value => value.id == id);
    }

    public int GetGiftIndex(uint id)
    {
        for(var i = 0;i < giftPackList.Count; i++)
        {
            if(giftPackList[i].id == id)
            {
                return i;
            }
        }
        return 0;
    }

    public I_GIFTPACK_VO GetMinEndTime()
    {
        I_GIFTPACK_VO giftPackData = giftPackList[0];
        foreach(var value in giftPackList)
        {
            if(value.endTime < giftPackData.endTime)
            {
                giftPackData = value;
            }
        }
        return giftPackData;
    }
    public I_TOUR_VO GetTourData(uint tourId)
    {
        return tourList.Find(value => value.tourId == tourId);
    }
    public void UpdateTourList(uint tourId,uint[] rewardIds)
    {
        var tourData = GetTourData(tourId);
        if(tourData != null)
        {
            tourData.rewardIds = rewardIds;
        }
    }
}

