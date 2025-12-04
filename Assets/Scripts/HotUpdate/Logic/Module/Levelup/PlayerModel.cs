using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using protobuf.fight;
using protobuf.user;
using UnityEngine;

//玩家等级和品阶
public class PlayerModel : Singleton<PlayerModel>
{
    //等级表
    public Dictionary<int, Ft_player_levelConfig> _staticLevelupBonus;
    public Dictionary<int, Ft_player_levelConfig> staticLevelupBonus
    {
        get
        {
            if (_staticLevelupBonus == null)
            {
                Ft_player_levelConfigData levelupData = ConfigManager.Instance.GetConfig<Ft_player_levelConfigData>("ft_player_levelsConfig");
                _staticLevelupBonus = levelupData.DataMap;
            }
            return _staticLevelupBonus;
        }
    }

    //品阶表
    private Dictionary<int, Ft_player_gradeConfig> _playerGradeMap;

    public Dictionary<int, Ft_player_gradeConfig> playerGradeMap
    {
        get
        {
            if (_playerGradeMap == null)
            {
                Ft_player_gradeConfigData playerGradeData = ConfigManager.Instance.GetConfig<Ft_player_gradeConfigData>("ft_player_gradesConfig");
                _playerGradeMap = playerGradeData.DataMap;
            }
            return _playerGradeMap;
        }
    }
    //战斗属性表
    private Dictionary<int, Ft_player_attrsConfig> _playerArrMap;
    public Dictionary<int, Ft_player_attrsConfig> playerArrMap
    {
        get
        {
            if (_playerArrMap == null)
            {
                Ft_player_attrsConfigData playerArrData = ConfigManager.Instance.GetConfig<Ft_player_attrsConfigData>("ft_player_attrssConfig");
                _playerArrMap = playerArrData.DataMap;
            }
            return _playerArrMap;
        }
    }

    private List<Ft_player_iconConfig> _headList;
    public List<Ft_player_iconConfig> headList { get
        {
            if(_headList == null)
            {
                var headData = ConfigManager.Instance.GetConfig<Ft_player_iconConfigData>("ft_player_iconsConfig");
                _headList = headData.DataList;
            }
            return _headList;
        } }

    private List<FrameTitleConfig> _frameTitleList;
    public List<FrameTitleConfig> frameTitleList { get
        {
            if(_frameTitleList == null)
            {
                _frameTitleList = new List<FrameTitleConfig>();
                var frameTitleData = ConfigManager.Instance.GetConfig<Ft_touche_fanConfigData>("ft_touche_fansConfig");
                foreach(var value in frameTitleData.DataList)
                {
                    var frameTitle = new FrameTitleConfig(value);
                    _frameTitleList.Add(frameTitle);
                }
            }
            return _frameTitleList;
        } }

    private List<Ft_player_nameConfig> _playerNameList;
    public List<Ft_player_nameConfig> playerNameList { get
        {
            if(_playerNameList == null)
            {
                var playerNameData = ConfigManager.Instance.GetConfig<Ft_player_nameConfigData>("ft_player_namesConfig");
                _playerNameList = playerNameData.DataList;
            }
            return _playerNameList;
        } }

    public I_PEN_VO pen;
    //绘笔战斗属性
    public I_FIGHT_ATTRIBUTES_VO fightAttr;

    //获取头像信息
    public Ft_player_iconConfig GetHeadInfo(int id)
    {
        return headList.Find(value => value.Id == id);
    }
    public Ft_player_iconConfig GetHeadInfo1(int id)
    {
        return headList.Find(value => value.IconId == id);
    }
    public int GetStyleValue(uint type)
    {
        if (pen.styleValue.ContainsKey(type))
        {
            return (int)pen.styleValue[type];
        }
        return 0;
    }
    //获取玩家等级信息
    public Ft_player_levelConfig GetLevelupBonus(int level)
    {
        if (staticLevelupBonus.ContainsKey(level))
        {
            return staticLevelupBonus[level];
        }
        return null;
    }
    //根据经验获取等级
    public int GetPlayerLv(int exp)
    {
        foreach(var value in staticLevelupBonus)
        {
            if(exp < value.Value.Exp)
            {
                return value.Value.Level - 1;
            }
        }
        return staticLevelupBonus[staticLevelupBonus.Count - 1].Level;
    }
    //获取玩家品阶信息
    public Ft_player_gradeConfig GetPlayerGrade(int gradeLv)
    {
        if (playerGradeMap.ContainsKey(gradeLv))
        {
            return playerGradeMap[gradeLv];
        }
        return null;
    }

    public Ft_player_attrsConfig GetPlayerArr(int id)
    {
        if (playerArrMap.ContainsKey(id))
        {
            return playerArrMap[id];
        }
        return null;
    }

    /// <summary>
    /// 根据宠物id获取我方上阵宠物槽位
    /// </summary>
    /// <param name="petId"></param>
    /// <returns></returns>
    public int GetBattlePetPos(uint petId)
    {
        var battlePets = pen.battlePets;
        return System.Array.IndexOf(battlePets, petId);
    }

    /// <summary>
    /// 根据宠物id获取我方上阵花仙槽位
    /// </summary>
    /// <param name="petId"></param>
    /// <returns></returns>
    public int GetBattleFairyPos(uint fairyId)
    {
        var battleFairys = pen.battleFairys;
        return System.Array.IndexOf(battleFairys, fairyId);
    }
    //获取头像框列表
    public List<FrameTitleConfig> GetFrameTileList(int type)
    {
        return frameTitleList.FindAll(value => value.Type == type);
    }

    public FrameTitleConfig GetFrameTitleInfo(int id)
    {
        return frameTitleList.Find(value => value.Id == id);
    }
}

public class FrameTitleConfig
{
    public int Id;
    public int Prosperity;
    public int Type { get
        {
            var itemVo = ItemModel.Instance.GetItemById(Id);
            return itemVo.Type;
        } }
    public FrameTitleConfig(Ft_touche_fanConfig data)
    {
        Id = data.Id;
        Prosperity = data.Prosperity;
    }
}

