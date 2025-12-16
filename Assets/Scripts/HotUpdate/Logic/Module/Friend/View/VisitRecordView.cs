using ADK;
using FairyGUI;
using protobuf.common;
using protobuf.friend;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static protobuf.friend.I_STEAL_MESSAGE_VO;

public class VisitRecordView : BaseWindow
{
    private fun_Friends.VisitRecordView view;
    private List<I_STEAL_MESSAGE_VO> stealMesData = new List<I_STEAL_MESSAGE_VO>();
    public VisitRecordView()
    {
        packageName = "fun_Friends";
        // 委托绑定
        BindAllDelegate = fun_Friends.fun_FriendsBinder.BindAll;
        CreateInstanceDelegate = fun_Friends.VisitRecordView.CreateInstance;
    }
    public override void OnInit()
    {
        base.OnInit();
        view = ui as fun_Friends.VisitRecordView;
        SetBg(view.bg, "Common/common_big_tip_bg.png");
        EventManager.Instance.AddEventListener(FriendEvent.FriendStealMesg, FriendStealCallBack);
        view.list.SetVirtual();
        view.list.itemRenderer = ItemRender;
    }
    private void FriendStealCallBack()
    {
        view.n22.text = FriendModel.Instance.friendStealMsg.fcoinDailyCnt.ToString()+"/"+350;
        const int FriendCoinItemId = 41013044;
        view.n25.text= StorageModel.Instance.GetItemCount(FriendCoinItemId).ToString();
        view.list.numItems = FriendModel.Instance.friendStealMsg.messageList?.Count??0;
        stealMesData = FriendModel.Instance.friendStealMsg.messageList??new List<I_STEAL_MESSAGE_VO>();

        view.list.RefreshVirtualList();
    }
    private void ItemRender(int index, GObject item)
    {
        fun_Friends.VisitRecordItem ui_ = item as fun_Friends.VisitRecordItem;
        view.status.selectedIndex = stealMesData.Count > 0 ? 1 : 0;
        if (index >= 0 && index < stealMesData.Count)
        {
            var stealMesItem = stealMesData[index];
            uint userId = stealMesItem.targetUserId;
            var friendData = stealMesItem.stealUserInfo;
            if (friendData != null)
            {
                ui_.txt_lv.text = friendData.userInfo.userLevel.ToString();
                ui_.txt_name.text = friendData.userInfo.townName;
                ui_.txt_daysVisit.text = TimeUtil.GenerateTimeDesc((int)stealMesItem.reqTime)+"摘取了";
                ui_.Text_time.text = TimeUtil.GenerateTimeDesc((int)stealMesItem.stealUserInfo.userInfo.lastLoginTime);
                ui_.n14.visible = MyselfModel.Instance.IsVip();

                // 统计当前好友偷完花之后返回的好友币数量
                int totalFriendCoinCount = 0;
                if (stealMesItem.items != null)
                {
                    foreach (var itemVo in stealMesItem.items)
                    {
                        // 直接使用IDUtil.GetEntityValue的ulong重载方法
                        int entityId = IDUtil.GetEntityValue(itemVo.itemId);
                        
                        // 使用确认的花ID范围进行统计（41013034-41013045）
                        if (entityId >= 41013034 && entityId <= 41013045)
                        {
                            // 累加cnt和cronyCnt
                            totalFriendCoinCount += (int)itemVo.cnt + (int)itemVo.cronyCnt;
                        }
                    }
                }
                
                ui_.txt_numberVisit.text = "+" + totalFriendCoinCount.ToString();
                StringUtil.SetBtnTab(ui_.btn_newApply, "回访");
                ui_.btn_newApply.data = friendData;
                ui_.btn_newApply.onClick.Add(OnVisitFriend);
                ui_.n20.visible = friendData.canSteal;
            }
        }
    }
    public void OnVisitFriend(EventContext context)
    {
        var btn = context.sender as GButton;
        if (btn != null && btn.data != null)
        {
            var friendData = btn.data as I_STEAL_PROFILE_VO;
            if (friendData != null)
            {
                FriendController.Instance.ReqFriendVisit(friendData.userInfo.userId);
                UIManager.Instance.CloseWindow(UIName.VisitRecordView);
            }
        }
    }
    public override void OnShown()
    {
        base.OnShown();
        FriendController.Instance.ReqFriendStealMesg();
    }
    public override void OnHide()
    {
        base.OnHide();
        EventManager.Instance.RemoveEventListener(FriendEvent.FriendStealMesg, FriendStealCallBack);
    }
}
