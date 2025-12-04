using System.Collections;
using System.Collections.Generic;
using protobuf.guild;
using protobuf.messagecode;
using UnityEngine;

public class GuildPlantController : BaseController<GuildPlantController>
{
    protected override void InitListeners()
    {
        //花房信息
        AddNetListener<S_MSG_GUILD_HOUSE_INFO>((int)MessageCode.S_MSG_GUILD_HOUSE_INFO, GuildHouseInfo);
        //花房启用
        AddNetListener<S_MSG_GUILD_HOUSE_ENABLE>((int)MessageCode.S_MSG_GUILD_HOUSE_ENABLE, GuildHouseEnable);
        //花房种植
        AddNetListener<S_MSG_GUILD_HOUSE_PLANT>((int)MessageCode.S_MSG_GUILD_HOUSE_PLANT, GuildHousePlant);
        //花房详情
        AddNetListener<S_MSG_GUILD_HOUSE_DETAIL>((int)MessageCode.S_MSG_GUILD_HOUSE_DETAIL, GuildHouseDetail);
        //花房收获
        AddNetListener<S_MSG_GUILD_HOUSE_HARVEST>((int)MessageCode.S_MSG_GUILD_HOUSE_HARVEST, GuildHouseHarvest);
        //花房其他社团成员信息
        AddNetListener<S_MSG_GUILD_HOUSE_MEMBERS>((int)MessageCode.S_MSG_GUILD_HOUSE_MEMBERS, GuildHouseMembers);
    }
    //花房信息
    public void GuildHouseInfo(S_MSG_GUILD_HOUSE_INFO data)
    {
        GuildPlantModel.Instance.houseList = data.houseList;
        EventManager.Instance.DispatchEvent(GuildPlantEvent.GuildHouseInfo);
    }

    public void ReqGuildHouseInfo()
    {
        C_MSG_GUILD_HOUSE_INFO c_MSG_GUILD_HOUSE_INFO = new C_MSG_GUILD_HOUSE_INFO();
        SendCmd((int)MessageCode.C_MSG_GUILD_HOUSE_INFO, c_MSG_GUILD_HOUSE_INFO);
    }
    //花房启用
    public void GuildHouseEnable(S_MSG_GUILD_HOUSE_ENABLE data)
    {
        GuildPlantModel.Instance.UpdateHouseList(data);
        if(data.type == 1)
        {
            var plantInfo = GuildPlantModel.Instance.GetGuildPlantConfig((int)data.houseId);
            GuildModel.Instance.guild.gold -= (uint)plantInfo.ClubOpenCost;
            EventManager.Instance.DispatchEvent(GuildEvent.GuildInfo);
        }
        ReqGuildHouseInfo();
        //EventManager.Instance.DispatchEvent(GuildPlantEvent.GuildHouseEnable);
    }

    public void ReqGuildHouseEnable(uint houseId,uint type)
    {
        C_MSG_GUILD_HOUSE_ENABLE c_MSG_GUILD_HOUSE_ENABLE = new C_MSG_GUILD_HOUSE_ENABLE();
        c_MSG_GUILD_HOUSE_ENABLE.houseId = houseId;
        c_MSG_GUILD_HOUSE_ENABLE.type = type;
        SendCmd((int)MessageCode.C_MSG_GUILD_HOUSE_ENABLE, c_MSG_GUILD_HOUSE_ENABLE);
    }
    //花房种植
    public void GuildHousePlant(S_MSG_GUILD_HOUSE_PLANT data)
    {
        GuildPlantModel.Instance.UpdatePlantList(data.plant);
        EventManager.Instance.DispatchEvent(GuildPlantEvent.GuildHousePlant);
    }

    public void ReqGuildHousePlant( uint houseId,uint flowerId,uint pos)
    {
        C_MSG_GUILD_HOUSE_PLANT c_MSG_GUILD_HOUSE_PLANT = new C_MSG_GUILD_HOUSE_PLANT();
        c_MSG_GUILD_HOUSE_PLANT.houseId = houseId;
        c_MSG_GUILD_HOUSE_PLANT.flowerId = flowerId;
        c_MSG_GUILD_HOUSE_PLANT.pos = pos;
        SendCmd((int)MessageCode.C_MSG_GUILD_HOUSE_PLANT, c_MSG_GUILD_HOUSE_PLANT);
    }
    //花房详情
    public void GuildHouseDetail(S_MSG_GUILD_HOUSE_DETAIL data)
    {
        GuildPlantModel.Instance.plantInfo = data;
        EventManager.Instance.DispatchEvent(GuildPlantEvent.GuildHouseDetail);
    }

    public void ReqGuildHouseDetail(uint houseId)
    {
        C_MSG_GUILD_HOUSE_DETAIL c_MSG_GUILD_HOUSE_DETAIL = new C_MSG_GUILD_HOUSE_DETAIL();
        c_MSG_GUILD_HOUSE_DETAIL.houseId = houseId;
        SendCmd((int)MessageCode.C_MSG_GUILD_HOUSE_DETAIL, c_MSG_GUILD_HOUSE_DETAIL);
    }
    //花房收获
    public void GuildHouseHarvest(S_MSG_GUILD_HOUSE_HARVEST data)
    {
        var dropList = ItemModel.Instance.GetDropData(data.items);
        DropManager.ShowDrop(dropList);
        GuildPlantModel.Instance.PalntHarvest(data.plantList);
        ReqGuildHouseInfo();
        EventManager.Instance.DispatchEvent(GuildPlantEvent.GuildHouseHarvest);
    }

    public void ReqGuildHouseHarvest(uint houseId)
    {
        C_MSG_GUILD_HOUSE_HARVEST c_MSG_GUILD_HOUSE_HARVEST = new C_MSG_GUILD_HOUSE_HARVEST();
        c_MSG_GUILD_HOUSE_HARVEST.houseId = houseId;
        SendCmd((int)MessageCode.C_MSG_GUILD_HOUSE_HARVEST, c_MSG_GUILD_HOUSE_HARVEST);
    }

    //花房其他社团成员信息
    public void GuildHouseMembers(S_MSG_GUILD_HOUSE_MEMBERS data)
    {
        GuildPlantModel.Instance.ParseMembersList(data.memberPlantList);
        GuildPlantModel.Instance.houseId = data.houseId;
        EventManager.Instance.DispatchEvent(GuildPlantEvent.GuildHouseMembers);
    }

    public void ReqGuildHouseMembers(uint houseId,int page)
    {
        C_MSG_GUILD_HOUSE_MEMBERS c_MSG_GUILD_HOUSE_MEMBERS = new C_MSG_GUILD_HOUSE_MEMBERS();
        c_MSG_GUILD_HOUSE_MEMBERS.houseId = houseId;
        c_MSG_GUILD_HOUSE_MEMBERS.page = page;
        SendCmd((int)MessageCode.C_MSG_GUILD_HOUSE_MEMBERS, c_MSG_GUILD_HOUSE_MEMBERS,0);
    }
}
