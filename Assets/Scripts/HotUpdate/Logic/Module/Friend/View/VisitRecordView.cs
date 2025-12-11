using ADK;
using FairyGUI;
using protobuf.common;
using protobuf.friend;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitRecordView : BaseWindow
{
    private fun_Friends.VisitRecordView view;
    private List<I_STEAL_MESSAGE_VO> stealMesData;
    public VisitRecordView() {
        packageName = "fun_Friends";
        // ÉèÖÃÎ¯ÍÐ
        BindAllDelegate = fun_Friends.fun_FriendsBinder.BindAll;
        CreateInstanceDelegate = fun_Friends.VisitRecordView.CreateInstance;
   }
    public override void OnInit()
    {
        base.OnInit();
        view = ui as fun_Friends.VisitRecordView;
        SetBg(view.bg, "Friend/ELIDA_haoyou_haoyoubg.png");
        EventManager.Instance.AddEventListener(FriendEvent.FriendStealMesg, FriendStealCallBack);
        view.list.SetVirtual();
        view.list.itemRenderer = ItemRender;
    }
    private void FriendStealCallBack()
    {
        view.n22.text= FriendModel.Instance.friendStealMsg.fcoinDailyCnt.ToString();
        view.list.numItems = FriendModel.Instance.friendStealMsg.messageList.Count;
        stealMesData = FriendModel.Instance.friendStealMsg.messageList;
    }
    private void ItemRender(int index, GObject item) {
        fun_Friends.VisitRecordItem ui_ = item as fun_Friends.VisitRecordItem;
        view.status.selectedIndex = stealMesData.Count > 0 ? 0 : 1;
        if (index >= 0 && index < stealMesData.Count)
        {
            var stealMesItem= stealMesData[index];
            uint userId = stealMesItem.targetUserId;
            var friendData = stealMesItem.userInfo;
            if(friendData!=null)
            {
                //StringUtil.SetBtnUrl(ui_.picFrame, "Avatar/ELIDA_common_touxiangdi01.png");
                ui_.txt_lv.text = friendData.userLevel.ToString();
                ui_.txt_name.text = friendData.townName;
                ui_.txt_daysVisit.text= stealMesItem.reqTime.ToString();
                StringUtil.SetBtnUrl(ui_.btn_newApply, "»Ø·Ã");
                ui_.btn_newApply.onClick.Add(OnVisitFriend);
                ui_.n20.visible= friendData.canSteal;
            }
        }
    }
    public void OnVisitFriend(EventContext context)
    {
        var friendData = (context.sender as GComponent).parent.data as I_FRIEND_PROFILE;
        FriendController.Instance.ReqFriendVisit(friendData.userId);
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
