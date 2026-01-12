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
        view.best_Title.text = Lang.GetValue("best_30");
        view.n20.text = Lang.GetValue("best_31"); //今日获得
        view.n54.text = Lang.GetValue("best_34"); //友情币最多可以存储800个
        StringUtil.SetBtnTab(view.emptyTip, Lang.GetValue("best_39")); //还没有采摘记录哦!

        var itemVo = ItemModel.Instance.GetItemById(GlobalModel.Instance.module_profileConfig.FriendCoinItem);
        view.pic_img.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        view.btn_best_buyBook.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
    }
    private void FriendStealCallBack()
    {
        view.n22.text = FriendModel.Instance.friendStealMsg.fcoinDailyCnt.ToString() + "/" + GlobalModel.Instance.module_profileConfig.FriendCoinDayLimit.ToString();
        view.n25.text = StorageModel.Instance.GetItemCount(GlobalModel.Instance.module_profileConfig.FriendCoinItem).ToString();
        view.list.numItems = FriendModel.Instance.friendStealMsg.messageList?.Count??0;
        stealMesData = FriendModel.Instance.friendStealMsg.messageList??new List<I_STEAL_MESSAGE_VO>();

        view.list.RefreshVirtualList();
    }
    private void ItemRender(int index, GObject item)
    {
        fun_Friends.VisitRecordItem ui_ = item as fun_Friends.VisitRecordItem;
        view.status.selectedIndex = stealMesData.Count > 0 ? 1 : 0;
        var coinVo = ItemModel.Instance.GetItemById(GlobalModel.Instance.module_profileConfig.FriendCoinItem);
        ui_.pic.url = ImageDataModel.Instance.GetIconUrl(coinVo);
        if (index >= 0 && index < stealMesData.Count)
        {
            var stealMesItem = stealMesData[index];
            uint userId = stealMesItem.targetUserId;
            var friendData = stealMesItem.stealUserInfo;
            if (friendData != null)
            {
                ui_.txt_lv.text = friendData.userInfo.userLevel.ToString();
                ui_.txt_name.text = TextUtil.GetServerName(friendData.userInfo.serverId, friendData.userInfo.townName);
                ui_.txt_daysVisit.text = TimeUtil.GenerateTimeDesc((int)stealMesItem.reqTime)+ Lang.GetValue("best_32");
                if (stealMesItem.stealUserInfo.online)
                {
                    ui_.Text_time.text = Lang.GetValue("online_text");
                }
                else
                {
                    ui_.Text_time.text = TimeUtil.GenerateTimeDesc((int)stealMesItem.stealUserInfo.userInfo.lastLoginTime);
                }
                
                ui_.n14.visible = MyselfModel.Instance.IsVip();
                var frameVo = ItemModel.Instance.GetItemById((int)friendData.userInfo.headFrame);
                UILogicUtils.ShowHeadFrames(ui_.picFrame as common_New.PictureFrame, frameVo);
                var headVo = ItemModel.Instance.GetItemById(int.Parse(friendData.userInfo.headImgId));
                (ui_.heead as common_New.MoonFestivalHead).pic.url = ImageDataModel.Instance.GetIconUrl(headVo);
                // 统计当前好友偷完花之后返回的好友币数量
                int totalFriendCoinCount = 0;
                if (stealMesItem.items != null)
                {
                    foreach (var itemVo in stealMesItem.items)
                    {
                        int entityId = IDUtil.GetEntityValue(itemVo.itemId);
                        if (entityId == GlobalModel.Instance.module_profileConfig.FriendCoinItem)
                        {
                            totalFriendCoinCount += (int)itemVo.cnt + (int)itemVo.cronyCnt;
                        }
                    }
                }
                
                ui_.txt_numberVisit.text = "+" + totalFriendCoinCount.ToString();
                StringUtil.SetBtnTab(ui_.btn_newApply, Lang.GetValue("best_33"));
                ui_.btn_newApply.data = friendData;
                ui_.btn_newApply.onClick.Clear();
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
    }
}
