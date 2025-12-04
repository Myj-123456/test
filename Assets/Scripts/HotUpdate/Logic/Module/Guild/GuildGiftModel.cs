using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using protobuf.guild;
using UnityEngine;
using static protobuf.guild.S_MSG_GUILD_GIFT_INFO;
using static protobuf.guild.S_MSG_GUILD_GIFT_LIST;

public class GuildGiftModel : Singleton<GuildGiftModel>
{
    private Dictionary<int, Ft_club_giftdaConfig> _giftBigMap;
    public Dictionary<int, Ft_club_giftdaConfig> giftBigMap { get
        {
            if(_giftBigMap == null)
            {
                Ft_club_giftdaConfigData giftBigData = ConfigManager.Instance.GetConfig<Ft_club_giftdaConfigData>("ft_club_giftdasConfig");
                _giftBigMap = giftBigData.DataMap;
            }
            return _giftBigMap;
        } }

    private Dictionary<int, Ft_club_giftxiaoConfig> _giftSmallMap;
    public Dictionary<int, Ft_club_giftxiaoConfig> giftSmallMap
    {
        get
        {
            if (_giftSmallMap == null)
            {
                Ft_club_giftxiaoConfigData giftBigData = ConfigManager.Instance.GetConfig<Ft_club_giftxiaoConfigData>("ft_club_giftxiaosConfig");
                _giftSmallMap = giftBigData.DataMap;
            }
            return _giftSmallMap;
        }
    }

    public List<I_GIFT_VO> giftList;//礼物列表

    public List<GiftSmallData> nomalGiftList;//普通礼物列表

    public List<GiftSmallData> rareGiftList;//稀有礼物列表

    public Dictionary<uint,GiftSmallData> nomalGiftMap;

    public Dictionary<uint, GiftSmallData> rareGiftMap;

    public uint gradientCnt;//大宝箱已领取次数

    //根据id获取大礼物配置
    public Ft_club_giftdaConfig GetGiftBigConfig(int id)
    {
        if (giftBigMap.ContainsKey(id))
        {
            return giftBigMap[id];
        }
        return null;
    }

    //根据id获取小礼物配置
    public Ft_club_giftxiaoConfig GetGiftSmallConfig(int id)
    {
        if (giftSmallMap.ContainsKey(id))
        {
            return giftSmallMap[id];
        }
        return null;
    }

    public I_GIFT_VO GetGiftInfo(uint id)
    {
        foreach(var value in giftList)
        {
            if(id == value.id)
            {
                return value;
            }
        }
        return null;
    }
    //初始化礼物列表
    public void InfoGiftList()
    {
        if(nomalGiftList == null)
        {
            nomalGiftList = new List<GiftSmallData>();
            nomalGiftMap = new Dictionary<uint, GiftSmallData>();
        }
        else
        {
            nomalGiftList.Clear();
            nomalGiftMap.Clear();
        }

        if(rareGiftList == null)
        {
            rareGiftList = new List<GiftSmallData>();
            rareGiftMap = new Dictionary<uint, GiftSmallData>();
        }
        else
        {
            rareGiftList.Clear();
            rareGiftMap.Clear();
        }

        foreach(var value in giftList)
        {
            var giftInfo = GetGiftSmallConfig((int)value.itemId);
            var giftData = new GiftSmallData();
            giftData.gifoVo = value;
            giftData.giftConfig = giftInfo;

            if (giftInfo.Type == 1)
            {
                nomalGiftList.Add(giftData);
                nomalGiftMap.Add(value.id, giftData);
            }
            else
            {
                rareGiftList.Add(giftData);
                rareGiftMap.Add(value.id, giftData);
            }
        }
    }

    //更新列表信息
    public void ParseGiftInfo(List<I_GIFT_INFO_VO> data)
    {
        foreach(var value in data)
        {
            if (nomalGiftMap.ContainsKey(value.id))
            {
                nomalGiftMap[value.id].giftInfo = value;
            }

            if (rareGiftMap.ContainsKey(value.id))
            {
                rareGiftMap[value.id].giftInfo = value;
            }
        }
    }
    //领取更新
    public void UpdateGiftInfo(S_MSG_GUILD_GIFT_DRAW data)
    {
        if (rareGiftMap.ContainsKey(data.giftId))
        {
            var giftData = rareGiftMap[data.giftId];
            giftData.giftInfo.drawCnt = data.drawCnt;
            giftData.gifoVo.draw = true;
        }else if (nomalGiftMap.ContainsKey(data.giftId))
        {
            var giftData = nomalGiftMap[data.giftId];
            giftData.giftInfo.drawCnt = data.drawCnt;
            giftData.gifoVo.draw = true;
        }
        
    }
    
}

public class GiftSmallData
{
    public I_GIFT_VO gifoVo;
    public Ft_club_giftxiaoConfig giftConfig;
    public I_GIFT_INFO_VO giftInfo;
}

