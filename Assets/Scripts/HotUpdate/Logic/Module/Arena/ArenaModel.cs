//using System.Collections;
//using System.Collections.Generic;
//using Elida.Config;
//using protobuf.arena;
//using protobuf.misc;
//using UnityEngine;
//using static protobuf.arena.S_MSG_ARENA_RANK_INFO;

//public class ArenaModel : Singleton<ArenaModel>
//{
//    //竞技场排名表  
//    private List<Ft_arena_rankConfig> _arenaList;

//    public List<Ft_arena_rankConfig> arenaList { get
//        {
//            if(_arenaList == null)
//            {
//                var arenaData = ConfigManager.Instance.GetConfig<Ft_arena_rankConfigData>("ft_arena_ranksConfig");
//                _arenaList = arenaData.DataList;
//            }
//            return _arenaList;
//        } }
//    //竞技场机器人表  
//    private Dictionary<int, Ft_arena_robotConfig> _arenaRobotMap;
//    public Dictionary<int, Ft_arena_robotConfig> arenaRobotMap { get
//        {
//            if(_arenaRobotMap == null)
//            {
//                var arenaData = ConfigManager.Instance.GetConfig<Ft_arena_robotConfigData>("ft_arena_robotsConfig");
//                _arenaRobotMap = arenaData.DataMap;
//            }
//            return _arenaRobotMap;
//        } }

//    public List<I_RANK_VO> rankList; //排名 
//    public I_MY_RANK myRank;//我的排名和积分 
//    public List<I_RIVAL_VO> rivalUserInfos;//挑战对手信息

//    public uint arenaRefreshCnt;// 竞技场今日刷新次数

//    public List<I_USER_INFO_DRESS_GUILD> userList = new List<I_USER_INFO_DRESS_GUILD>();//用户信息


//    //获取用户信息
//    public I_USER_INFO_DRESS_GUILD GetUserInfo(uint userId)
//    {
//        if(userList != null)
//        {
//            return userList.Find(vaule => vaule.userInfo.userId == userId);
//        }
//        return null;
//    }
//    //获取排名信息
//    public Ft_arena_rankConfig GetArenaInfo(int id)
//    {
//        return arenaList.Find(value => value.Id == id);
//    }
//    //获取竞技场机器人信息
//    public Ft_arena_robotConfig GetArenaRobot(int id)
//    {
//        if (arenaRobotMap.ContainsKey(id))
//        {
//            return arenaRobotMap[id];
//        }
//        return null;
//    }
//}

