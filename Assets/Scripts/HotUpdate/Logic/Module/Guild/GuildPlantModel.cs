using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using protobuf.guild;
using UnityEngine;
using static protobuf.guild.S_MSG_GUILD_HOUSE_INFO;
using static protobuf.guild.S_MSG_GUILD_HOUSE_MEMBERS;

public class GuildPlantModel : Singleton<GuildPlantModel>
{
    //花盟种植表
    private Dictionary<int, Ft_club_plantConfig> _plantMap;

    public Dictionary<int, Ft_club_plantConfig> plantMap { get
        {
            if(_plantMap == null)
            {
                Ft_club_plantConfigData plantData = ConfigManager.Instance.GetConfig<Ft_club_plantConfigData>("ft_club_plantsConfig");
                _plantMap = plantData.DataMap;
            }
            return _plantMap;
        } }

    private List<Ft_club_plantConfig> _plantList;

    public List<Ft_club_plantConfig> plantList
    {
        get
        {
            if (_plantList == null)
            {
                Ft_club_plantConfigData plantData = ConfigManager.Instance.GetConfig<Ft_club_plantConfigData>("ft_club_plantsConfig");
                _plantList = plantData.DataList;
            }
            return _plantList;
        }
    }

    public List<I_HOUSE_VO> houseList;//花房信息列表

    public S_MSG_GUILD_HOUSE_DETAIL plantInfo;//当前打开花房的信息

    public int page = 0;

    public List<I_GUILD_MEMBER_PLANT_VO> memberPlantList;//当前花房其他社团成员信息

    public uint houseId;//当前花房社团成员用

    public bool end;

    //通过id获取花盟种植信息
    public Ft_club_plantConfig GetGuildPlantConfig(int id)
    {
        if (plantMap.ContainsKey(id))
        {
            return plantMap[id];
        }
        return null;
    }

    //更新花房信息列表
    public void UpdateHouseList(S_MSG_GUILD_HOUSE_ENABLE data)
    {
        foreach(var value in houseList)
        {
            if(value.id == data.houseId)
            {
                value.startTime = data.startTime;
                value.endTime = data.endTime;
                break;
            }
        }
    }

    //更新花房种植信息列表
    public void UpdatePlantList(I_GUILD_PLANT_VO data)
    {
        if(data.houseId == plantInfo.houseId)
        {
            for(int i = 0,len = plantInfo.plantList.Count;i < len; i++)
            {
                if(plantInfo.plantList[i].pos == data.pos)
                {
                    plantInfo.plantList[i] = data;
                    break;
                }
            }
            plantInfo.plantList.Add(data);
        }
    }
    //花房收获
    public void PalntHarvest(List<I_GUILD_PLANT_VO> list)
    {
        if(plantInfo != null && plantInfo.plantList != null)
        {
            plantInfo.plantList = list;
        }
    }

    //初始化花房其他社团成员信息列表
    public void ClearMembers()
    {
        if(memberPlantList == null)
        {
            memberPlantList = new List<I_GUILD_MEMBER_PLANT_VO>();
        }
        else
        {
            memberPlantList.Clear();
        }
        page = 0;
        end = false;
    }
    //花房其他社团成员信息
    public void ParseMembersList(List<I_GUILD_MEMBER_PLANT_VO> list)
    {
        memberPlantList.AddRange(list);
        end = list.Count <= 0;
        if (!end)
        {
            page += 1;
        }
    }

    public void GetMembersListNext(int index)
    {
        if (index >= memberPlantList.Count - 1)//到底了，刷新新的数据
        {
            if (!end)
            {
                GuildPlantController.Instance.ReqGuildHouseMembers(houseId, page);
            }
        }
    }

    public I_HOUSE_VO GetHouseInfo(uint id)
    {
        foreach(var value in houseList)
        {
            if(value.id == id)
            {
                return value;
            }
        }
        return null;
    }

    public I_GUILD_PLANT_VO GetPalntingInfo(uint pos)
    {
        if(plantInfo != null)
        {
            foreach(var value in plantInfo.plantList)
            {
                if(value.pos == pos)
                {
                    return value;
                }
            }
        }
        return null;
    }
}
