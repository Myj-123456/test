using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using protobuf.friend;
using ADK;
using protobuf.common;
using System;

public class VisitFriendView : BaseView
{
    private fun_Friends.VisitFriendView view;
    private int curPage = 1;
    private int spotMaxPage = 0;
    private int SPOT_PER_PAGE = 5;
    private int lastSpotPage = 0;
    private float playerInfoY = 0;
    private float ui_friendListY = 0;
    private Color originColor;

    public VisitFriendView()
    {
        packageName = "fun_Friends";
        // 设置委托
        BindAllDelegate = fun_Friends.fun_FriendsBinder.BindAll;
        CreateInstanceDelegate = fun_Friends.VisitFriendView.CreateInstance;
        IsShowOrHideMainUI = false;
        IsAddShowNum = false;
    }

    public override void OnInit()
    {
        base.OnInit();
        view = ui as fun_Friends.VisitFriendView;
        StringUtil.SetBtnTab(view.ui_friendList.one_key_btn, "一键偷花");
        view.ui_friendList.txt_noFriendPrompt.text = Lang.GetValue("new_friend_1");
        playerInfoY = view.playerInfo.y;
        ui_friendListY = view.ui_friendList.y;
        originColor = view.txt_interactionTimes.color;
        view.ui_friendList.list_visitFriend.SetVirtual();
        view.ui_friendList.list_visitFriend.itemRenderer = ItemRender;
        view.ui_friendList.list_visitFriend.onClickItem.Add(OnItemClick);
        view.ui_friendList.list_visitFriend.scrollPane.onScroll.Add(OnScroll);
        AddEvent();
        view.ui_friendList.one_key_btn.onClick.Add(() =>
        {
            PlantController.Instance.ReqBatchSteal(MyselfModel.Instance.friendId);
        });
    }

    private void OnScroll()
    {
        if (lastSpotPage != view.ui_friendList.list_visitFriend.scrollPane.currentPageX)
        {
            lastSpotPage = view.ui_friendList.list_visitFriend.scrollPane.currentPageX;
            curPage = lastSpotPage + 1;
            UpdatePageInfo();
        }
    }

    public override void OnShown()
    {
        base.OnShown();
        view.ui_friendList.one_key_btn.visible = MyselfModel.Instance.IsVip();
        curPage = 1;
        ShowHideUI(true);
        friendListfilter = FriendModel.Instance.GetFriendListfilter(MyselfModel.Instance.friendId);
        UpdatePlayInfo();
        UpdateInteractionTimes();
        UpdateVisitFriendList();
        spotMaxPage = (int)Mathf.Ceil(friendListfilter.Count / (float)SPOT_PER_PAGE);
        UpdatePageInfo();
    }

    private void ShowHideUI(bool isShow)
    {
        GTween.Kill(view.playerInfo);
        GTween.Kill(view.ui_friendList);
        var animTime = 0.5f;
        if (isShow)
        {
            view.playerInfo.y = -view.playerInfo.height;
            view.playerInfo.TweenMoveY(playerInfoY, animTime).SetEase(EaseType.BackOut);

            view.ui_friendList.y = GRoot.inst.height;
            view.ui_friendList.TweenMoveY(ui_friendListY, animTime).SetEase(EaseType.BackOut);
        }
        else
        {

        }
    }


    private void UpdatePlayInfo()
    {
        protobuf.friend.I_FRIEND_PROFILE vo_ = FriendModel.Instance.GetFriendData(MyselfModel.Instance.friendId);
        if (vo_ != null)
        {
            StringUtil.SetBtnUrl(view.head, "Avatar/ELIDA_common_touxiangdi01.png");
            view.txt_name.text = vo_.townName;
            view.txt_lv.text = vo_.userLevel.ToString();
        }
    }

    private List<I_FRIEND_PROFILE> friendListfilter;
    private void UpdateVisitFriendList()
    {
        var count = friendListfilter.Count;
        view.ui_friendList.list_visitFriend.numItems = count;
        view.ui_friendList.txt_noFriendPrompt.visible = count <= 0;
    }

    private void ItemRender(int index, GObject item)
    {
        fun_Friends.VisitFriendItem ui = item as fun_Friends.VisitFriendItem;
        var vo = friendListfilter[index];
        ui.data = vo;
        StringUtil.SetBtnUrl(ui.head, "Avatar/ELIDA_common_touxiangdi01.png");
        ui.txt_name.text = vo.townName;
        ui.txt_lv.text = vo.userLevel.ToString();
    }

    private void OnItemClick(EventContext context)
    {
        var vo = (context.data as GComponent).data as I_FRIEND_PROFILE;
        FriendController.Instance.ReqFriendVisit(vo.userId);
    }

    private void UpdateInteractionTimes()
    {
        var umberOfMutualaid = GlobalModel.Instance.module_profileConfig.umberOfMutualaid;
        var surplusTimes = umberOfMutualaid - MyselfModel.Instance.interactionCnt;
        view.txt_interactionTimes.color = surplusTimes > 0 ? originColor : Color.red;
        view.txt_interactionTimes.text = $"{surplusTimes}/{umberOfMutualaid}";
    }

    private void AddEvent()
    {
        view.ui_friendList.btn_home.onClick.Add(() =>
        {
            MyselfModel.Instance.atHome = true;
            UIManager.Instance.ClosePanel(UIName.VisitFriendView);
            UIManager.Instance.OpenPanel<MainView>(UIName.MainView,UILayer.MainUI);
            SceneManager.Instance.BackHomeRefreshScene();
        });
        AddEventListener(FriendEvent.FriendSteal, OnFriendSteal);
        view.ui_friendList.btn_left.onClick.Add(OnLeft);
        view.ui_friendList.btn_right.onClick.Add(OnRight);
    }

    private void OnFriendSteal()
    {
        UpdateInteractionTimes();
    }

    private void OnLeft()
    {
        if (curPage <= 1) return;
        curPage -= 1;
        view.ui_friendList.list_visitFriend.scrollPane.SetCurrentPageX(curPage - 1, true);
    }

    private void OnRight()
    {
        if (curPage >= spotMaxPage) return;
        curPage += 1;
        view.ui_friendList.list_visitFriend.scrollPane.SetCurrentPageX(curPage - 1, true);
    }

    private void UpdatePageInfo()
    {
        view.ui_friendList.txt_pageNum.text = curPage + "/" + spotMaxPage;
    }

}

