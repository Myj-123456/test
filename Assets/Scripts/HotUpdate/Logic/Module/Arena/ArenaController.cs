//using System.Collections;
//using System.Collections.Generic;
//using protobuf.arena;
//using protobuf.messagecode;
//using UnityEngine;

//public class ArenaController : BaseController<ArenaController>
//{
//    // Start is called before the first frame update
//    public int tatol = -1;
//    public List<uint> userIds = new List<uint>();
//    protected override void InitListeners()
//    {
//        //排行
//        AddNetListener<S_MSG_ARENA_RANK_INFO>((int)MessageCode.S_MSG_ARENA_RANK_INFO, ArenaRankInfo);
//        //获取挑战对手信息
//        AddNetListener<S_MSG_ARENA_RIVAL>((int)MessageCode.S_MSG_ARENA_RIVAL, ArenaRankRival);
//        //刷新对手
//        AddNetListener<S_MSG_ARENA_REFRESH_RIVAL>((int)MessageCode.S_MSG_ARENA_REFRESH_RIVAL, ArenaRefreshRival);

//        AddNetListener<S_MSG_ARENA_FIGHT>((int)MessageCode.S_MSG_ARENA_FIGHT, ResArenaFight);

//    }

//    public void ArenaRankInfo(S_MSG_ARENA_RANK_INFO data)
//    {
//        ArenaModel.Instance.rankList = data.rankList;
//        ArenaModel.Instance.myRank = data.myRank;
//        DispatchEvent(ArenaEvent.ArenaRankInfo);
//    }

//    public void ReqArenaRankInfo()
//    {
//        C_MSG_ARENA_RANK_INFO c_MSG_ARENA_RANK_INFO = new C_MSG_ARENA_RANK_INFO();
//        SendCmd((int)MessageCode.C_MSG_ARENA_RANK_INFO, c_MSG_ARENA_RANK_INFO);
//    }
//    //获取挑战对手信息
//    public void ArenaRankRival(S_MSG_ARENA_RIVAL data)
//    {
//        ArenaModel.Instance.rivalUserInfos = data.rivalUserInfos;
//        DispatchEvent(ArenaEvent.ArenaRankRival);
//    }

//    public void ReqArenaRankRival()
//    {
//        C_MSG_ARENA_RIVAL c_MSG_ARENA_RIVAL = new C_MSG_ARENA_RIVAL();
//        SendCmd((int)MessageCode.C_MSG_ARENA_RIVAL, c_MSG_ARENA_RIVAL);
//    }
//    //刷新对手
//    public void ArenaRefreshRival(S_MSG_ARENA_REFRESH_RIVAL data)
//    {
//        ArenaModel.Instance.arenaRefreshCnt = data.arenaRefreshCnt;
//        StorageModel.Instance.OddToStorageItems(data.costItems);
//        ArenaModel.Instance.rivalUserInfos = data.rivalUserInfos;
//        DispatchEvent(ArenaEvent.ArenaRefreshRival);
//    }

//    public void ReqArenaRefreshRival()
//    {
//        C_MSG_ARENA_REFRESH_RIVAL c_MSG_ARENA_REFRESH_RIVAL = new C_MSG_ARENA_REFRESH_RIVAL();
//        SendCmd((int)MessageCode.C_MSG_ARENA_REFRESH_RIVAL, c_MSG_ARENA_REFRESH_RIVAL);
//    }

//    public void ReqUserInfo(int index, uint id)
//    {
//        if (userIds.IndexOf(id) == -1 && ArenaModel.Instance.rankList[index].role != 2)
//        {
//            var ids = new List<uint>();
//            var dress = new List<uint>();
//            var count = 0;
//            while (count == 50 || ArenaModel.Instance.arenaList.Count == index)
//            {
//                var userId = ArenaModel.Instance.rankList[index].targetId;
//                if (userIds.IndexOf(id) == -1 && ArenaModel.Instance.rankList[index].role != 2)
//                {
//                    ids.Add(userId);
//                    if (index < 4)
//                    {
//                        dress.Add(userId);
//                    }
//                }
//                count++;
//                index++;
//            }
//            //MyselfController.Instance.ReqGetUserInfo(ids.ToArray(), dress.ToArray());
//        }
//    }

//    public void ClearUserInfo()
//    {
//        userIds.Clear();
//        ArenaModel.Instance.userList.Clear();
//    }

//    /// <summary>
//    /// 挑战对手
//    /// </summary>
//    /// <param name="rivalIndex"></param>
//    public void ReqArenaFight(uint rivalIndex)
//    {
//        BattleModel.Instance.rivalIndex = rivalIndex;
//        C_MSG_ARENA_FIGHT c_MSG_ARENA_FIGHT = new C_MSG_ARENA_FIGHT();
//        c_MSG_ARENA_FIGHT.rivalIndex = rivalIndex;
//        SendCmd((int)MessageCode.C_MSG_ARENA_FIGHT, c_MSG_ARENA_FIGHT);
//    }

//    private void ResArenaFight(S_MSG_ARENA_FIGHT s_MSG_ARENA_FIGHT)
//    {
//        BattleController.Instance.EnterPvpBattle(s_MSG_ARENA_FIGHT);
//    }
//}
