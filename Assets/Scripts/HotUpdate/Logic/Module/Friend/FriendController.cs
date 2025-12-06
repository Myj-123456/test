using System.Collections;
using System.Collections.Generic;
using System.Linq;
using protobuf.friend;
using protobuf.messagecode;
using UnityEngine;
using UnityTimer;
using static protobuf.friend.S_MSG_CRONY_LIST;

public class FriendController : BaseController<FriendController>
{
    protected override void InitListeners()
    {
        AddNetListener<S_MSG_FRIEND_LIST>((int)MessageCode.S_MSG_FRIEND_LIST, FriendList);
        AddNetListener<S_MSG_FRIEND_APPLY>((int)MessageCode.S_MSG_FRIEND_APPLY, FriendApply);
        AddNetListener<S_MSG_FRIEND_APPLY_LIST>((int)MessageCode.S_MSG_FRIEND_APPLY_LIST, FriendApplyList);
        AddNetListener<S_MSG_FRIEND_REJECT>((int)MessageCode.S_MSG_FRIEND_REJECT, FriendReject);
        AddNetListener<S_MSG_FRIEND_AGREE>((int)MessageCode.S_MSG_FRIEND_AGREE, FriendAgree);
        AddNetListener<S_MSG_FRIEND_MARK>((int)MessageCode.S_MSG_FRIEND_MARK, FriendMark);
        AddNetListener<S_MSG_FRIEND_DEL>((int)MessageCode.S_MSG_FRIEND_DEL, FriendDel);
        AddNetListener<S_MSG_FRIEND_INSERT_BLACK>((int)MessageCode.S_MSG_FRIEND_INSERT_BLACK, FriendInsertBlack);
        AddNetListener<S_MSG_FRIEND_BLACK_LIST>((int)MessageCode.S_MSG_FRIEND_BLACK_LIST, FriendBlackList);
        AddNetListener<S_MSG_FRIEND_BLACK_DEL>((int)MessageCode.S_MSG_FRIEND_BLACK_DEL, FriendBlackDel);
        AddNetListener<S_MSG_FRIEND_RECOMMEND_LIST>((int)MessageCode.S_MSG_FRIEND_RECOMMEND_LIST, FriendRecommendList);
        AddNetListener<S_MSG_FRIEND_VISIT>((int)MessageCode.S_MSG_FRIEND_VISIT, ResFriendVisit);
        AddNetListener<S_MSG_FRIEND_STEAL>((int)MessageCode.S_MSG_FRIEND_STEAL, ResSteal);
        //密友列表
        AddNetListener<S_MSG_CRONY_LIST>((int)MessageCode.S_MSG_CRONY_LIST, CronyList);
        //申请添加密友
        AddNetListener<S_MSG_CRONY_APPLY>((int)MessageCode.S_MSG_CRONY_APPLY, CronyApply);
        //ͬ同意密友申请
        AddNetListener<S_MSG_CRONY_AGREE>((int)MessageCode.S_MSG_CRONY_AGREE, CronyAgree);
        //被申请列表
        AddNetListener<S_MSG_CRONY_BE_APPLY>((int)MessageCode.S_MSG_CRONY_BE_APPLY, CronyBeApply);
        //拒绝密友申请
        AddNetListener<S_MSG_CRONY_REJECT>((int)MessageCode.S_MSG_CRONY_REJECT, CronyReject);
        //购买密友结书
        AddNetListener<S_MSG_CRONY_BUY_BOOKITEM>((int)MessageCode.S_MSG_CRONY_BUY_BOOKITEM, CronyBookItem);
        //解除与密友的关系
        AddNetListener<S_MSG_CRONY_CANCEL>((int)MessageCode.S_MSG_CRONY_CANCEL, CronyCancel);
        //撤销解除与密友的关系
        AddNetListener<S_MSG_CRONY_BACKOUT_CANCEL>((int)MessageCode.S_MSG_CRONY_BACKOUT_CANCEL, CronyBackCancel);
        //加速解除
        AddNetListener<S_MSG_CRONY_SPEED_CANCEL>((int)MessageCode.S_MSG_CRONY_SPEED_CANCEL, CronySpeedCancel);
        //解锁密友位置响应
        AddNetListener<S_MSG_CRONY_UNLOCK_CNT>((int)MessageCode.S_MSG_CRONY_UNLOCK_CNT, CronyUnlockCt);
        //͵����Ϣ
        AddNetListener<S_MSG_FRIEND_STEAL_MESSAGE>((int)MessageCode.S_MSG_FRIEND_STEAL_MESSAGE, FriendStealMesg);

        // 初始化密友申请数据
        FriendModel.Instance.InitCronyApplyData();

        // 添加定期清理过期密友申请的定时器（每10分钟检查一次）
        Timer.RegistGlobal(600000, CleanExpiredAppliesTimer, true); // 10分钟间隔，循环执行
    }

    /// <summary>
    /// 清理过期密友申请的定时器回调
    /// </summary>
    private void CleanExpiredAppliesTimer()
    {
        FriendModel.Instance.CleanExpiredApplies();
    }

    public void FriendList(S_MSG_FRIEND_LIST data)
    {
        FriendModel.Instance.friendCount = data.count;
        FriendModel.Instance.friendList = data.friendList;

        // 确保每个好友都有对应的关系时间记录
        foreach (var friendData in data.friendList)
        {
            // 如果好友关系时间不存在，则使用当前服务器时间作为关系建立时间
            if (!FriendModel.Instance.friendRelationTime.ContainsKey(friendData.userId))
            {
                FriendModel.Instance.friendRelationTime[friendData.userId] = MyselfModel.Instance.lastServerTime;
            }
        }

        EventManager.Instance.DispatchEvent(FriendEvent.FriendList);
    }

    public void ReqFriendList()
    {
        C_MSG_FRIEND_LIST c_MSG_FRIEND_LIST = new C_MSG_FRIEND_LIST();
        c_MSG_FRIEND_LIST.start = 1;
        c_MSG_FRIEND_LIST.end = 300;
        SendCmd((int)MessageCode.C_MSG_FRIEND_LIST, c_MSG_FRIEND_LIST, 0.1f);
    }

    public void FriendApply(S_MSG_FRIEND_APPLY data)
    {
        if (data.effectFriendIds == null)
        {
            return;
        }
        FriendModel.Instance.RemoveRecommendList(data.effectFriendIds);
        EventManager.Instance.DispatchEvent(FriendEvent.FriendRecommendList);
    }

    public void ReqFriendApply(uint[] friendIds)
    {
        C_MSG_FRIEND_APPLY c_MSG_FRIEND_APPLY = new C_MSG_FRIEND_APPLY();
        c_MSG_FRIEND_APPLY.friendIds = friendIds;
        SendCmd((int)MessageCode.C_MSG_FRIEND_APPLY, c_MSG_FRIEND_APPLY, 0.1f);
    }

    public void FriendApplyList(S_MSG_FRIEND_APPLY_LIST data)
    {
        FriendModel.Instance.applyList = data.applyList;
        EventManager.Instance.DispatchEvent(FriendEvent.FriendApplyList);
    }

    public void ReqFriendApplyList()
    {
        C_MSG_FRIEND_APPLY_LIST c_MSG_FRIEND_APPLY_LIST = new C_MSG_FRIEND_APPLY_LIST();
        SendCmd((int)MessageCode.C_MSG_FRIEND_APPLY_LIST, c_MSG_FRIEND_APPLY_LIST, 0.1f);
    }

    public void FriendReject(S_MSG_FRIEND_REJECT data)
    {
        FriendModel.Instance.RemoveApplyList(data.friendIds);
        EventManager.Instance.DispatchEvent(FriendEvent.FriendApplyList);
    }

    public void ReqFriendReject(uint[] friendIds)
    {
        C_MSG_FRIEND_REJECT c_MSG_FRIEND_REJECT = new C_MSG_FRIEND_REJECT();
        c_MSG_FRIEND_REJECT.friendIds = friendIds;
        SendCmd((int)MessageCode.C_MSG_FRIEND_REJECT, c_MSG_FRIEND_REJECT);
    }

    public void FriendAgree(S_MSG_FRIEND_AGREE data)
    {
        FriendModel.Instance.AddApplyListToFriendList(data.effectFriendIds);
        EventManager.Instance.DispatchEvent(FriendEvent.FriendApplyList);
        EventManager.Instance.DispatchEvent(TaskEvent.MainTaskCount, 17);

    }

    public void ReqFriendAgree(uint[] friendIds)
    {
        C_MSG_FRIEND_AGREE c_MSG_FRIEND_AGREE = new C_MSG_FRIEND_AGREE();
        c_MSG_FRIEND_AGREE.friendIds = friendIds;
        SendCmd((int)MessageCode.C_MSG_FRIEND_AGREE, c_MSG_FRIEND_AGREE);
    }

    public void FriendMark(S_MSG_FRIEND_MARK data)
    {
        FriendModel.Instance.UpdateFriendMark(data.friendId, data.mark);
        EventManager.Instance.DispatchEvent(FriendEvent.FriendList);
    }

    public void ReqFriendMark(uint friendId, bool mark)
    {
        C_MSG_FRIEND_MARK c_MSG_FRIEND_MARK = new C_MSG_FRIEND_MARK();
        c_MSG_FRIEND_MARK.friendId = friendId;
        c_MSG_FRIEND_MARK.mark = mark;
        SendCmd((int)MessageCode.C_MSG_FRIEND_MARK, c_MSG_FRIEND_MARK);
    }

    public void FriendDel(S_MSG_FRIEND_DEL data)
    {
        FriendModel.Instance.RemoveFriend(data.friendId);
        EventManager.Instance.DispatchEvent(FriendEvent.FriendList);
        EventManager.Instance.DispatchEvent(TaskEvent.MainTaskCount, 17);

    }

    public void ReqFriendDel(uint friendId)
    {
        C_MSG_FRIEND_DEL c_MSG_FRIEND_DEL = new C_MSG_FRIEND_DEL();
        c_MSG_FRIEND_DEL.friendId = friendId;
        SendCmd((int)MessageCode.C_MSG_FRIEND_DEL, c_MSG_FRIEND_DEL);
    }

    public void FriendInsertBlack(S_MSG_FRIEND_INSERT_BLACK data)
    {
        FriendModel.Instance.RemoveFriend(data.friendId);
        FriendModel.Instance.AddBlackId(data.friendId);
        EventManager.Instance.DispatchEvent(FriendEvent.FriendList);
        EventManager.Instance.DispatchEvent(TaskEvent.MainTaskCount, 17);

    }

    public void ReqFriendInsertBlack(uint friendId)
    {
        C_MSG_FRIEND_INSERT_BLACK c_MSG_FRIEND_INSERT_BLACK = new C_MSG_FRIEND_INSERT_BLACK();
        c_MSG_FRIEND_INSERT_BLACK.friendId = friendId;
        SendCmd((int)MessageCode.C_MSG_FRIEND_INSERT_BLACK, c_MSG_FRIEND_INSERT_BLACK);
    }

    public void FriendBlackList(S_MSG_FRIEND_BLACK_LIST data)
    {
        FriendModel.Instance.blackList = data.blackList;
        EventManager.Instance.DispatchEvent(FriendEvent.FriendBlackList);
    }

    public void ReqFriendBlackList()
    {
        C_MSG_FRIEND_BLACK_LIST c_MSG_FRIEND_BLACK_LIST = new C_MSG_FRIEND_BLACK_LIST();
        SendCmd((int)MessageCode.C_MSG_FRIEND_BLACK_LIST, c_MSG_FRIEND_BLACK_LIST);
    }

    public void FriendBlackDel(S_MSG_FRIEND_BLACK_DEL data)
    {
        FriendModel.Instance.RemoveBlackList(data.friendId);
        FriendModel.Instance.RemoveBlackId(data.friendId);
        EventManager.Instance.DispatchEvent(FriendEvent.FriendBlackList);
    }

    public void ReqFriendBlackDel(uint friendId)
    {
        C_MSG_FRIEND_BLACK_DEL c_MSG_FRIEND_BLACK_DEL = new C_MSG_FRIEND_BLACK_DEL();
        c_MSG_FRIEND_BLACK_DEL.friendId = friendId;
        SendCmd((int)MessageCode.C_MSG_FRIEND_BLACK_DEL, c_MSG_FRIEND_BLACK_DEL);
    }

    public void FriendRecommendList(S_MSG_FRIEND_RECOMMEND_LIST data)
    {
        FriendModel.Instance.recommendList = data.recommendList;
        EventManager.Instance.DispatchEvent(FriendEvent.FriendRecommendList);
    }

    public void ReqFriendRecommendList()
    {
        C_MSG_FRIEND_RECOMMEND_LIST c_MSG_FRIEND_RECOMMEND_LIST = new C_MSG_FRIEND_RECOMMEND_LIST();
        SendCmd((int)MessageCode.C_MSG_FRIEND_RECOMMEND_LIST, c_MSG_FRIEND_RECOMMEND_LIST);
    }

    public void ReqFriendVisit(uint friendId)
    {
        C_MSG_FRIEND_VISIT c_MSG_FRIEND_VISIT = new C_MSG_FRIEND_VISIT();
        c_MSG_FRIEND_VISIT.friendId = friendId;
        SendCmd((int)MessageCode.C_MSG_FRIEND_VISIT, c_MSG_FRIEND_VISIT);
    }

    private void ResFriendVisit(S_MSG_FRIEND_VISIT s_MSG_FRIEND_VISIT)
    {
        MyselfModel.Instance.atHome = false;
        VisitFriendModel.Instance.InitPlantList(s_MSG_FRIEND_VISIT.plantList);
        VisitFriendModel.Instance.InitTables(s_MSG_FRIEND_VISIT.tableList);
        VisitFriendModel.Instance.UpdateDressData(s_MSG_FRIEND_VISIT.dress.ware);
        VisitFriendModel.Instance.InitFloristShop(s_MSG_FRIEND_VISIT.floristShop);
        MyselfModel.Instance.interactionCnt = s_MSG_FRIEND_VISIT.interactionCnt;
        MyselfModel.Instance.friendId = s_MSG_FRIEND_VISIT.friendId;
        UIManager.Instance.CloseWindow(UIName.FriendWindow, true);
        UIManager.Instance.ClosePanel(UIName.MainView);
        var visitFriendView = UIManager.Instance.GetView(UIName.VisitFriendView);
        if (visitFriendView != null && visitFriendView.Visible)
        {
            visitFriendView.OnShown();
        }
        else
        {
            UIManager.Instance.OpenPanel<VisitFriendView>(UIName.VisitFriendView);
        }
        EventManager.Instance.DispatchEvent(FriendEvent.FriendVisit);
    }

    public void ReqSteal(uint friendId, uint decorId)
    {
        C_MSG_FRIEND_STEAL c_MSG_FRIEND_STEAL = new C_MSG_FRIEND_STEAL();
        c_MSG_FRIEND_STEAL.friendId = friendId;
        c_MSG_FRIEND_STEAL.decorId = decorId;
        SendCmd((int)MessageCode.C_MSG_FRIEND_STEAL, c_MSG_FRIEND_STEAL);
    }

    private void ResSteal(S_MSG_FRIEND_STEAL s_MSG_FRIEND_STEAL)
    {
        MyselfModel.Instance.interactionCnt = s_MSG_FRIEND_STEAL.interactionCnt;
        var plantVo = VisitFriendModel.Instance.GetPlantVo(s_MSG_FRIEND_STEAL.decorId);
        if (plantVo != null)
        {
            plantVo.stealInfo.Add(MyselfModel.Instance.userId, 1);
            var items = s_MSG_FRIEND_STEAL.items;
            //items.Add(plantVo.flowerId, s_MSG_FRIEND_STEAL.count);
            var land = SceneManager.Instance.GetLand((int)s_MSG_FRIEND_STEAL.decorId);
            if (land != null)
            {
                Vector2 pt = ADK.UILogicUtils.TransformPos(land.transform.position);
                DropManager.ShowDropFromPoint(ItemModel.Instance.GetDropData(items), pt);
            }
            // 偷取成功提示
            if (MyselfModel.Instance.interactionCnt >= GlobalModel.Instance.module_profileConfig.umberOfMutualaid)
            {
                SceneManager.Instance.HideAllLandSteal();
            }
            else
            {
                if (land != null)
                {
                    land.UpdateFriendSteal();
                }
            }
            EventManager.Instance.DispatchEvent(FriendEvent.FriendSteal);
        }
    }

    //密友列表
    public void CronyList(S_MSG_CRONY_LIST data)
    {
        List<I_CRONY_VO> filteredCronyList = new List<I_CRONY_VO>();

        if (data?.cronyList != null)
        {
            uint currentServerTime = ServerTime.Time;
            if (currentServerTime <= 0)
            {
                currentServerTime = MyselfModel.Instance.lastServerTime;
            }

            // 使用LINQ过滤掉已过期的密友关系
            filteredCronyList = data.cronyList
                .Where(cronyData =>
                    // 没有设置解除时间的密友关系正常保留
                    cronyData.cancelTime == 0 ||
                    // 有解除时间但当前服务器时间未到解除时间的保留
                    (currentServerTime > 0 && cronyData.cancelTime > currentServerTime)
                )
                .ToList();
        }
        // 更新已解锁的密友位数量
        if (data != null)
        {
            FriendModel.Instance.UpdateUnlockCronyCntFromServer(data.unlockCronyCnt);
        }

        FriendModel.Instance.cronyList = filteredCronyList;
        EventManager.Instance.DispatchEvent(FriendEvent.CronyList);
    }

    public void ReqCronyList()
    {
        C_MSG_CRONY_LIST c_MSG_CRONY_LIST = new C_MSG_CRONY_LIST();
        SendCmd((int)MessageCode.C_MSG_CRONY_LIST, c_MSG_CRONY_LIST);
    }
    // 同意密友申请
    public void CronyApply(S_MSG_CRONY_APPLY data)
    {
        // 根据服务器返回的friendId，清除申请标记
        FriendModel.Instance.ClearApplyingFlag(data.friendId);
    }
    public void ReqCronyApply()
    {
        C_MSG_CRONY_APPLY c_MSG_CRONY_APPLY = new C_MSG_CRONY_APPLY();
        SendCmd((int)MessageCode.C_MSG_CRONY_APPLY, c_MSG_CRONY_APPLY);
    }

    // 带好友ID参数的密友申请方法
    public void ReqCronyApply(uint friendId)
    {
        // 防止无效ID
        if (friendId == 0)
        {
            return;
        }

        // 检查该用户是否已经是密友，如果是则不重复发送请求
        if (FriendModel.Instance.GetCronyData(friendId) != null)
        {
            return;
        }

        // 再次检查本地列表，确保没有重复
        foreach (var crony in FriendModel.Instance.cronyList)
        {
            if (crony.friendId == friendId)
            {
                return;
            }
        }

        C_MSG_CRONY_APPLY c_MSG_CRONY_APPLY = new C_MSG_CRONY_APPLY();
        c_MSG_CRONY_APPLY.friendId = friendId;
        SendCmd((int)MessageCode.C_MSG_CRONY_APPLY, c_MSG_CRONY_APPLY);
    }
    // 被申请列表
    public void CronyBeApply(S_MSG_CRONY_BE_APPLY data)
    {
        if (data.applyUserIds != null)
        {
            FriendModel.Instance.applyUserIds = data.applyUserIds.ToList();
        }
        else
        {
            FriendModel.Instance.applyUserIds = new List<uint>();
        }
        EventManager.Instance.DispatchEvent(FriendEvent.CronyBeApply);
    }
    public void ReqCronyBeApply()
    {
        // 先刷新密友列表，确保本地数据与服务器一致
        ReqCronyList();

        C_MSG_CRONY_BE_APPLY c_MSG_CRONY_BE_APPLY = new C_MSG_CRONY_BE_APPLY();
        SendCmd((int)MessageCode.C_MSG_CRONY_BE_APPLY, c_MSG_CRONY_BE_APPLY);
    }
    //同意密友申请
    public void CronyAgree(S_MSG_CRONY_AGREE data)
    {
        if (data.status == 0)
        {
            // 检查本地是否已经存在该密友关系，避免重复添加
            if (FriendModel.Instance.GetCronyData(data.friendId) == null)
            {
                // 双重检查：确保列表中不存在任何具有相同friendId的密友
                bool exists = false;
                foreach (var crony in FriendModel.Instance.cronyList)
                {
                    if (crony.friendId == data.friendId)
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    var cronyVo = new I_CRONY_VO();
                    cronyVo.friendId = data.friendId;
                    FriendModel.Instance.cronyList.Add(cronyVo);
                }
            }
            FriendModel.Instance.applyUserIds.Remove(data.friendId);
            EventManager.Instance.DispatchEvent(FriendEvent.CronyAgree);
        }
        else
        {
            // 如果服务器返回错误，可能是因为该用户已经是密友，刷新密友列表
            ReqCronyList();
            // 从申请列表中移除该用户，避免重复申请
            FriendModel.Instance.applyUserIds.Remove(data.friendId);
            EventManager.Instance.DispatchEvent(FriendEvent.CronyBeApply);
            // 派发密友列表更新事件，确保UI正确刷新
            EventManager.Instance.DispatchEvent(FriendEvent.CronyList);
        }
    }

    public void ReqCronyAgree(uint friendId)
    {
        // 先刷新密友列表，确保本地数据与服务器一致
        ReqCronyList();
        // 检查该用户是否已经是密友，如果是则不重复发送请求
        if (FriendModel.Instance.GetCronyData(friendId) != null)
        {
            return;
        }

        // 再次检查本地列表，确保没有重复
        foreach (var crony in FriendModel.Instance.cronyList)
        {
            if (crony.friendId == friendId)
            {
                return;
            }
        }

        C_MSG_CRONY_AGREE c_MSG_CRONY_AGREE = new C_MSG_CRONY_AGREE();
        c_MSG_CRONY_AGREE.friendId = friendId;
        SendCmd((int)MessageCode.C_MSG_CRONY_AGREE, c_MSG_CRONY_AGREE);
    }
    //�ܾ�
    //密友拒绝
    public void CronyReject(S_MSG_CRONY_REJECT data)
    {
        FriendModel.Instance.applyUserIds.Remove(data.friendId);
        // 发送邮件退还结书
        FriendModel.Instance.SendReturnCronyBookMail(data.friendId, false);
        EventManager.Instance.DispatchEvent(FriendEvent.CronyReject);
    }
    public void ReqCronyReject(uint friendId)
    {
        C_MSG_CRONY_REJECT c_MSG_CRONY_REJECT = new C_MSG_CRONY_REJECT();
        c_MSG_CRONY_REJECT.friendId = friendId;
        SendCmd((int)MessageCode.C_MSG_CRONY_REJECT, c_MSG_CRONY_REJECT);
    }
    //密友结书
    public void CronyBookItem(S_MSG_CRONY_BUY_BOOKITEM data)
    {
        // 更新StorageModel中的结书数量
        const int cronyBookItemId = 41013043;
        StorageModel.Instance.AddToStorageByItemId(cronyBookItemId, 1);

        // 触发购买成功事件
        EventManager.Instance.DispatchEvent(FriendEvent.CronyBookBuySuccess);
    }
    public void ReqCronyBookItem()
    {
        C_MSG_CRONY_BUY_BOOKITEM c_MSG_CRONY_BUY_BOOKITEM = new C_MSG_CRONY_BUY_BOOKITEM();
        SendCmd((int)MessageCode.C_MSG_CRONY_BUY_BOOKITEM, c_MSG_CRONY_BUY_BOOKITEM);
    }

    //解锁密友位置响应处理
    public void CronyUnlockCt(S_MSG_CRONY_UNLOCK_CNT data)
    {
        // 根据服务器协议数据更新已解锁的密友位数量
        FriendModel.Instance.UpdateUnlockCronyCntFromServer(data.unlockCronyCnt);
        // 触发解锁成功事件
        EventManager.Instance.DispatchEvent(FriendEvent.CronyUnlockSuccess); 
        // 更新密友列表
        ReqCronyList();
    }

    //解锁密友位置
    public void ReqCronyUnlockCt()
    {
        C_MSG_CRONY_UNLOCK_CNT c_MSG_CRONY_UNLOCK_CNT = new C_MSG_CRONY_UNLOCK_CNT();
        SendCmd((int)MessageCode.C_MSG_CRONY_UNLOCK_CNT, c_MSG_CRONY_UNLOCK_CNT);
    }
    //密友关系
    public void CronyCancel(S_MSG_CRONY_CANCEL data)
    {
        if (data == null)
        {
            return;
        }
        var cronyData = FriendModel.Instance.GetCronyData(data.friendId);
        if (cronyData != null)
        {
            // 总是使用服务器返回的最新解除时间
            cronyData.cancelTime = data.cancelTime;
            EventManager.Instance.DispatchEvent(FriendEvent.CronyCancel);
        }
    }

    public void ReqCronyCancel(uint friendId)
    {
        C_MSG_CRONY_CANCEL c_MSG_CRONY_CANCEL = new C_MSG_CRONY_CANCEL();
        c_MSG_CRONY_CANCEL.friendId = friendId;
        SendCmd((int)MessageCode.C_MSG_CRONY_CANCEL, c_MSG_CRONY_CANCEL);
    }
    //撤销解除密友的关系
    public void CronyBackCancel(S_MSG_CRONY_BACKOUT_CANCEL data)
    {
        var cronyData = FriendModel.Instance.GetCronyData(data.friendId);
        if (cronyData != null)
        {
            cronyData.cancelTime = 0;
            EventManager.Instance.DispatchEvent(FriendEvent.CronyBackCancel);
        }
    }
    public void ReqCronyBackCancel(uint friendId)
    {
        C_MSG_CRONY_BACKOUT_CANCEL c_MSG_CRONY_BACKOUT_CANCEL = new C_MSG_CRONY_BACKOUT_CANCEL();
        c_MSG_CRONY_BACKOUT_CANCEL.friendId = friendId;
        SendCmd((int)MessageCode.C_MSG_CRONY_BACKOUT_CANCEL, c_MSG_CRONY_BACKOUT_CANCEL);
    }
    // 加速解除
    public void CronySpeedCancel(S_MSG_CRONY_SPEED_CANCEL data)
    {
        if (data != null)
        {
            // 从cronyList中移除对应的密友数据
            FriendModel.Instance.cronyList.RemoveAll(item => item.friendId == data.friendId);
            EventManager.Instance.DispatchEvent(FriendEvent.CronySpeedCancel);
        }
    }
    public void ReqCronySpeedCancel(uint friendId)
    {
        C_MSG_CRONY_SPEED_CANCEL c_MSG_CRONY_SPEED_CANCEL = new C_MSG_CRONY_SPEED_CANCEL();
        c_MSG_CRONY_SPEED_CANCEL.friendId = friendId;
        SendCmd((int)MessageCode.C_MSG_CRONY_SPEED_CANCEL, c_MSG_CRONY_SPEED_CANCEL);
    }
    // 偷取信息
    public void FriendStealMesg(S_MSG_FRIEND_STEAL_MESSAGE data)
    {
        FriendModel.Instance.friendStealMsg = data;
        EventManager.Instance.DispatchEvent(FriendEvent.FriendStealMesg);
    }

    public void ReqFriendStealMesg()
    {
        C_MSG_FRIEND_STEAL_MESSAGE c_MSG_FRIEND_STEAL_MESSAGE = new C_MSG_FRIEND_STEAL_MESSAGE();
        SendCmd((int)MessageCode.C_MSG_FRIEND_STEAL_MESSAGE, c_MSG_FRIEND_STEAL_MESSAGE);
    }

}
