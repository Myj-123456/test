using System;
using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using protobuf.common;
using protobuf.guild;
using UnityEngine;
using static protobuf.guild.S_MSG_GUILD_KAN_DETAIL;
using static protobuf.guild.S_MSG_GUILD_KAN_NOT;
using static protobuf.guild.S_MSG_GUILD_MONEY;

public class GuildModel : Singleton<GuildModel>
{
    public Dictionary<int, Ft_club_levelConfig> _guildLvMap;
    public Dictionary<int, Ft_club_levelConfig> guildLvMap { get
        {
            if (_guildLvMap == null)
            {
                Ft_club_levelConfigData levelConfigData = ConfigManager.Instance.GetConfig<Ft_club_levelConfigData>("ft_club_levelsConfig");
                _guildLvMap = levelConfigData.DataMap;
            }
            return _guildLvMap;
        } }

    private Dictionary<int, Ft_club_permissionConfig> _positionNameMap;
    public Dictionary<int, Ft_club_permissionConfig> positionNameMap { get {

            if (_positionNameMap == null)
            {
                Ft_club_permissionConfigData permissionConfigData = ConfigManager.Instance.GetConfig<Ft_club_permissionConfigData>("ft_club_permissionsConfig");
                _positionNameMap = permissionConfigData.DataMap;
            }
            return _positionNameMap;
        } }

    private List<Ft_club_donasiConfig> _donateList;
    public List<Ft_club_donasiConfig> donateList { get {
            if (_donateList == null)
            {
                Ft_club_donasiConfigData donasiConfigData = ConfigManager.Instance.GetConfig<Ft_club_donasiConfigData>("ft_club_donasisConfig");
                _donateList = donasiConfigData.DataList;
            }
            return _donateList;
        } }


    private Dictionary<int, Ft_club_iconConfig> _clubIconMap;
    public Dictionary<int, Ft_club_iconConfig> clubIconMap { get
        {
            if(_clubIconMap == null)
            {
                Ft_club_iconConfigData clubIconData = ConfigManager.Instance.GetConfig<Ft_club_iconConfigData>("ft_club_iconsConfig");
                _clubIconMap = clubIconData.DataMap;
            }
            return _clubIconMap;
        } }

    private Ft_club_othersConfig _othersConfig;
    public Ft_club_othersConfig othersConfig { get
        {
            if(_othersConfig == null)
            {
                Ft_club_othersConfigData othersData = ConfigManager.Instance.GetConfig<Ft_club_othersConfigData>("ft_club_otherssConfig");
                _othersConfig = othersData.DataList[0];
            }
            return _othersConfig;
        } }

    private Dictionary<int, Ft_club_kanConfig> _kanMap;
    public Dictionary<int, Ft_club_kanConfig> kanMap { get
        {
            if(_kanMap == null)
            {
                Ft_club_kanConfigData kanData = ConfigManager.Instance.GetConfig<Ft_club_kanConfigData>("ft_club_kansConfig");
                _kanMap = kanData.DataMap;
            }
            return _kanMap;
        } }

    private Ft_club_jrewardConfigData _jrewardData;
    public Ft_club_jrewardConfigData jrewardData { get
        {
            if (_jrewardData == null)
            {
                _jrewardData = ConfigManager.Instance.GetConfig<Ft_club_jrewardConfigData>("ft_club_jrewardsConfig");
            }
            return _jrewardData;
        } }
    //商店配置
    private List<Ft_club_shopConfig> _shopConfig;
    public List<Ft_club_shopConfig> shopConfig { get
        {
            if(_shopConfig == null)
            {
                var shopData = ConfigManager.Instance.GetConfig<Ft_club_shopConfigData>("ft_club_shopsConfig");
                _shopConfig = shopData.DataList;
            }
            return _shopConfig;
        } }

    public Dictionary<uint, uint> buyCntStat;//限购的配置，已经购买了多少次

    public List<I_GUILD_LIST_VO> guildList;

    public I_GUILD_VO guild;//社团信息

    //public List<I_POSITION_VO> positionNames;//职位信息

    public uint approval;//审批方式 1：自动审核 2：手动审核

    public uint memberLimitLevel;//用户等级

    public float memberLimitFighting;//用户战力

    public I_GUILD_ME_VO guildMember;//我在社团中的成员信息

    public I_PRESIDENT_VO presidentInfo;//社团会长

    //public I_PRESIDENT_VO presiddnt

    public List<I_MEMBER_VO> memberList;//成员列表

    public List<I_USER_PROFILE> applyList;//申请用户列表

    public List<I_FLOWERPOT_VO> flowerpot;//解锁的花盆信息

    public string guildName;//社团名称

    public List<S_MESSAGE> messageList;// 社团资金使用明细
    public List<protobuf.common.I_USER_PROFILE> userInfos;

    public List<I_BRIEF_MEMBER_VO> guildMembers;//社团成员信息，社团聊天记录要显示职位

    public uint guildDonate; //社团捐献进度

    public List<uint> haveDrawDonateIds; //已领取的社团捐献进度奖励id

    public static int guildCoinId = 19000005;

    private List<M_GuildFunc> funcBtn;

    public uint[] applyGuilds;
    public uint countdownTime;

    public bool _end = false;

    public int page = 0;

    public bool _notEnd = false;

    public int notPage = 0;

    public S_MSG_GUILD_KAN_INFO kanInfo;
    public List<I_KAN_VO> kanList;//砍价用户列表
    public List<I_NOT_KAN_VO> notKan;//社团未砍价用户列表

    public List<uint> guildIds; //我已经申请加入的社团id列表
    public uint cdTime;//加入cd时间，大于0，不能再次申请加入社团


    //通过id获取捐献进度配置
    public Ft_club_jrewardConfig GetJrewardInfo(int id)
    {
        if (jrewardData.DataMap.ContainsKey(id))
        {
            return jrewardData.DataMap[id];
        }
        return null;
    }

    public Ft_club_kanConfig GetKanConfig(int id)
    {
        if (kanMap.ContainsKey(id))
        {
            return kanMap[id];
        }
        return null;
    }

    public void GetGuildListNext(int index)
    {
        if(index == guildList.Count - 1)//到底了，刷新新的数据
        {
            if (!_end)
            {
                GuildController.Instance.ReqGuildList(page);
            }
        }
    }



    public void ParseGuildList(S_MSG_GUILD_LIST data)
    {
        guildList.AddRange(data.list);
        _end = data.list.Count <= 0;
        if (!_end)
        {
            page += 1;
        }
    }

    public void GetMemberListNext(int index)
    {
        if (index == memberList.Count - 1)//到底了，刷新新的数据
        {
            if (!_end)
            {
                
                GuildController.Instance.ReqGuildMemberList(page);
            }
        }
    }

    public void ParseMemberList(S_MSG_GUILD_MEMBERLIST data)
    {
        
        memberList.AddRange(data.memberList);
        _end = data.memberList.Count <= 0;
        if (!_end)
        {
            page += 1;
        }
    }

    public void GetApplyListNext(int index)
    {
        if (index == applyList.Count - 1)//到底了，刷新新的数据
        {
            if (!_end)
            {
                GuildController.Instance.ReqGuildApplyList(page);
            }
        }
    }

    public void ParseApplyList(S_MSG_GUILD_APPLY_LIST data)
    {
        applyList.AddRange(data.list);
        _end = data.list.Count <= 0;
        if (!_end)
        {
            page += 1;
        }
    }

    public void ParseKanList(S_MSG_GUILD_KAN_DETAIL data)
    {
        kanList.AddRange(data.kanList);
        _end = data.kanList.Count <= 0;
        if (!_end)
        {
            page += 1;
        }
    }

    public void GetKanListNext(int index)
    {
        if (index == kanList.Count - 1)//到底了，刷新新的数据
        {
            if (!_end)
            {
                
                GuildController.Instance.ReqGuildKanDetail(page);
            }
        }
    }

    public void ClearKanList()
    {
        if(kanList == null)
        {
            kanList = new List<I_KAN_VO>();
        }
        else
        {
            kanList.Clear();
        }
        page = 0;
        _end = false;
    }

    public void ParseNotKanList(S_MSG_GUILD_KAN_NOT data)
    {
        
        notKan.AddRange(data.notKan);
        _notEnd = data.notKan.Count <= 0;
        if (!_notEnd)
        {
            notPage += 1;
        }
    }

    public void GetNotKanListNext(int index)
    {
        if (index == notKan.Count - 1)//到底了，刷新新的数据
        {
            if (!_notEnd)
            {
                GuildController.Instance.ReqGuildKanDetail(notPage);
            }
        }
    }

    public void ClearNotKanList()
    {
        if (notKan == null)
        {
            notKan = new List<I_NOT_KAN_VO>();
        }
        else
        {
            notKan.Clear();
        }
        notPage = 0;
        _notEnd = false;
    }

    public void UpdateGuildTransfer(uint targetUserId,uint powerId)
    {
        foreach(var userData in memberList)
        {
            if(userData.userId == targetUserId)
            {
                userData.powerId = powerId;
            }
        }
    }

    public void RemoveMemberList(uint targetUserId)
    {
        int index = -1;
        for(int i = 0;i < memberList.Count; i++)
        {
            if(memberList[i].userId == targetUserId)
            {
                index = i;
                break;
            }
        }
        if(index != -1)
        {
            memberList.RemoveAt(index);
        }
    }

    public void ChangePosition(uint targetUserId,uint position)
    {
        foreach(var userInfo in memberList)
        {
            if(userInfo.userId == targetUserId)
            {
                userInfo.powerId = position;
                break;
            }
        }
    }

    public void UpdateApplyList(uint targetUserId)
    {
        int index = -1;
        for (int i = 0; i < applyList.Count; i++)
        {
            if (applyList[i].userId == targetUserId)
            {
                index = i;
                break;
            }
        }
        if (index != -1)
        {
            applyList.RemoveAt(index);
        }
    }

    public void UpdateFlowerPot(I_FLOWERPOT_VO potData)
    {
        int index = GetFlowerPotIndex(potData.position);
        if(index == -1)
        {
            flowerpot.Add(potData);
        }
        else
        {
            flowerpot[index] = potData;
        }
    }

    public void UpdateFlowerPots(List<I_FLOWERPOT_VO> list)
    {
        foreach(var value in list)
        {
            UpdateFlowerPot(value);
        }
    }

    public int GetFlowerPotIndex(uint position)
    {
        for(int i = 0;i < flowerpot.Count; i++)
        {
            if(flowerpot[i].position == position)
            {
                return i;
            }
        }
        return -1;
    }

    public void ClearGuildList()
    {
        if(guildList == null)
        {
            guildList = new List<I_GUILD_LIST_VO>();
        }
        else
        {
            guildList.Clear();
        }
        page = 0;
        _end = false;

    }
    public void ClearMemberList()
    {
        if (memberList == null)
        {
            memberList = new List<I_MEMBER_VO>();
        }
        else
        {
            memberList.Clear();
        }
        page = 0;
        _end = false;
    }

    public void ClearApplyList()
    {
        if (applyList == null)
        {
            applyList = new List<I_USER_PROFILE>();
        }
        else
        {
            applyList.Clear();
        }
        page = 0;
        _end = false;
    }


    public bool IsApplied(uint id)
    {
        if(guildIds == null || guildIds.Count == 0)
        {
            return false;
        }
        return guildIds.IndexOf(id) != -1;
    }

    public bool IsJoin()
    {
        return cdTime <= 0;
    }

    public string GetPositionName(uint id)
    {
       
        if(positionNameMap.ContainsKey((int)id))
        {
            return Lang.GetValue(positionNameMap[(int)id].Name);
        }
        return "";
    }

    public Ft_club_permissionConfig GetPositionInfo(int id)
    {

        if (positionNameMap.ContainsKey(id))
        {
            return positionNameMap[id];
        }
        return null;
    }

    public uint GetUserData(uint id)
    {
        if(memberList != null)
        {
            var userData = memberList.Find(value => value.userId == id);
            if (userData == null) return 0;
            return userData.powerId;
        }

        if (guildMembers != null)
        {
           var userData = guildMembers.Find(value => value.userId == id);
            if (userData == null) return 0;
            return userData.powerId;
        }

        return 0;
    }

    public bool CanChangeNotice(int positionId)
    {
        if (positionNameMap.ContainsKey(positionId))
        {
            return positionNameMap[positionId].Announcement == 1;
        }
        return false;
    }

    public bool CanBan(uint pos)
    {
        if (positionNameMap.ContainsKey((int)guildMember.powerId))
        {
            return positionNameMap[(int)guildMember.powerId].KickingPeople == 1 && guildMember.powerId < pos;
        }
        return false;
    }

    public bool CanPromotion(uint pos)
    {
        if (positionNameMap.ContainsKey((int)guildMember.powerId))
        {
            return  guildMember.powerId < pos - 1;
        }
        return false;
    }

    public bool CanDemotion(uint pos)
    {
        if (positionNameMap.ContainsKey((int)guildMember.powerId))
        {
            return guildMember.powerId < pos && pos < 4;
        }
        return false;
    }

    public bool CanTransfer(uint pos)
    {
        
        return guildMember.powerId == 1 && pos != 1;
    }

    public bool CanAcept()
    {
        if (positionNameMap.ContainsKey((int)guildMember.powerId))
        {
            return positionNameMap[(int)guildMember.powerId].Application == 1;
        }
        return false;
    }

    public bool CanCondition()
    {
        if (positionNameMap.ContainsKey((int)guildMember.powerId))
        {
            return positionNameMap[(int)guildMember.powerId].JoinCondition == 1;
        }
        return false;
    }

    public List<I_MEMBER_VO> GetMemberList()
    {
        //memberList.Sort((a, b) => (int)a.position - (int)b.position);
        return memberList;
    }

    public protobuf.common.I_USER_PROFILE GetMember(uint userId)
    {
        return userInfos.Find((value) => value.userId == userId);
    }


    public List<M_GuildFunc> GetFuncBtnList()
    {
        if(funcBtn == null)
        {
            funcBtn = new List<M_GuildFunc>();
            funcBtn.Add(new M_GuildFunc(AssociationFunType.GuildDonate));
            funcBtn.Add(new M_GuildFunc(AssociationFunType.GuildPlanting));
            funcBtn.Add(new M_GuildFunc(AssociationFunType.FlowerShare));
        }
        return funcBtn;
    }

    //根据type获取icon列表
    public List<Ft_club_iconConfig> GetIconList(int type)
    {
        var iconList = new List<Ft_club_iconConfig>();
        foreach(var iconData in clubIconMap)
        {
            if(iconData.Value.Type == type)
            {
                iconList.Add(iconData.Value);
            }
        }
        return iconList;
    }

    //通过id获取配置信息
    public Ft_club_iconConfig GetIconInfo(int Id)
    {
        if (clubIconMap.ContainsKey(Id))
        {
            return clubIconMap[Id];
        }
        return null;
    }
    //通过id获取icon图片名字
    public string GetIconImgName(int Id)
    {
        var info = GetIconInfo(Id);
        return info == null ? "" : info.Icon;
    }

    public I_FLOWERPOT_VO GetFlowerPotData(uint position)
    {
        return flowerpot.Find((value) => value.position == position);
    }

    public Ft_club_donasiConfig GetDonasiData(int id)
    {
        return donateList.Find((value) => value.Jenis == id);
    }

    public Ft_club_levelConfig GetLevelData(int lv)
    {
        if (guildLvMap.ContainsKey(lv))
        {
            return guildLvMap[lv];
        }
        else
        {
            Ft_club_levelConfigData levelConfigData = ConfigManager.Instance.GetConfig<Ft_club_levelConfigData>("ft_club_levelsConfig");
            return levelConfigData.DataList[levelConfigData.DataList.Count - 1];
        }
    }

    //商店更新
    public void UpdateShop(uint id,uint buyCnt)
    {
        if (buyCntStat.ContainsKey(id))
        {
            buyCntStat[id] = buyCnt;
        }
        else
        {
            buyCntStat.Add(id, buyCnt);
        }
    }
    
}

public class M_GuildFunc
{
    public AssociationFunType _func;
    public string name { get
        {
            switch (_func)
            {
                case AssociationFunType.GuildDonate:
                    return Lang.GetValue("guild.funcName_donate");//社团捐献;
                case AssociationFunType.GuildPlanting:
                    return Lang.GetValue("guild_planting_001");//公会种植
                case AssociationFunType.FlowerShare:
                    return Lang.GetValue("Share_txt1");//鲜花分享
                case AssociationFunType.GuildMatch:
                    return Lang.GetValue("guildMatch_38");//社团竞赛
                case AssociationFunType.GuildStoreSkill:
                    return Lang.GetValue("guildStore_30");//社团商店
                case AssociationFunType.GuildPocket:
                    return Lang.GetValue("guildPocket_1");//社团红包
                case AssociationFunType.GuildStarfish:
                    return Lang.GetValue("starfish_32");//海滩之星
                case AssociationFunType.GuildLeague:
                    return Lang.GetValue("guild_league_1");//竞赛赛季
            }
            return "";
        } }

    public string icon { get{
            switch (_func)
            {
                case AssociationFunType.GuildDonate:
                    return "funcIcon/guild_donate.png";
                case AssociationFunType.GuildPlanting:
                    return "funcIcon/guild_planting.png";
                case AssociationFunType.FlowerShare:
                    return "funcIcon/guild_share.png";
                case AssociationFunType.GuildMatch:
                    return "funcIcon/guild_match.png";
                case AssociationFunType.GuildStoreSkill:
                    return "funcIcon/funcIcon/guild_store.png";
                case AssociationFunType.GuildPocket:
                    return "funcIcon/funcIcon/guild_pocket.png";
                case AssociationFunType.GuildStarfish:
                    return "funcIcon/funcIcon/guild_starfish.png";
                case AssociationFunType.GuildLeague:
                    return "funcIcon/funcIcon/guild_league.png";
            }
            return "";
        } }

    public M_GuildFunc(AssociationFunType type)
    {
        _func = type;
    }
}

public enum AssociationFunType
{
    GuildDonate,        //社团捐献
    GuildStoreSkill,    //社团商店  
    GuildPlanting,      //社团种植
    FlowerShare,        //鲜花分享
    GuildMatch,         //社团竞赛
                        // GuildChallenge,    //社团挑战赛
    GuildPocket,         //社团红包
    GuildStarfish,         //海滩之星
    GuildLeague         //社团联赛(竞赛赛季)
}

public class IconData
{
    public int BgId;
    public int IconId;
}

