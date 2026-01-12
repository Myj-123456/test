using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using protobuf.friend;
using ADK;
using protobuf.common;
using System;
using static protobuf.friend.S_MSG_FRIEND_LIST;

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
    private int Number = 1;
    private int _friendCoinCount = 0;
    private I_FRIEND_PROFILE_VO _curfriendData;//当前访问朋友信息
    private int curConverFriendConitCount = 1;//当前准备兑换好友币数
    private int FriendCoinExchangeLimit;//每个好友每日好友币兑换摸花上限
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
        StringUtil.SetBtnTab(view.ui_friendList.one_key_btn, Lang.GetValue("recharge_main_16")); //一键偷花
        view.ui_friendList.txt_noFriendPrompt.text = Lang.GetValue("new_friend_1");
        playerInfoY = view.playerInfo.y;
        ui_friendListY = view.ui_friendList.y;
        originColor = view.txt_interactionTimes.color;
        view.ui_friendList.list_visitFriend.SetVirtual();
        view.ui_friendList.list_visitFriend.itemRenderer = ItemRender;
        view.ui_friendList.list_visitFriend.onClickItem.Add(OnItemClick);
        view.ui_friendList.list_visitFriend.scrollPane.onScroll.Add(OnScroll);

        EventManager.Instance.AddEventListener(FriendEvent.FriendCoinExchange, FriendCoinCallBack);
        AddEvent();
        view.ui_friendList.one_key_btn.onClick.Add(() =>
        {
            PlantController.Instance.ReqBatchSteal(MyselfModel.Instance.friendId);
        });
        view.btn_visitdetails.onClick.Add(() =>
        {
            HandleIntroduceBtnClick();
        });
        view.btn_currency.onClick.Add(() =>
        {
            HandleConverBtnClick();
        });
        FriendCoinExchangeLimit = GlobalModel.Instance.module_profileConfig.FriendCoinExchange;

        view.btn_addNum.onClick.Add(() => { ChangeCurrentConverFriendConitCount(1); });
        view.btn_lessen.onClick.Add(() => { ChangeCurrentConverFriendConitCount(-1); });
        view.bg_sign.onClick.Add(() => { view.popUpTap.selectedIndex = 0; });
        StringUtil.SetBtnTab(view.EnterBtn, Lang.GetValue("common_button_ok"));
        view.EnterBtn.onClick.Add(() => { ConverEnterClick(); });
        StringUtil.SetBtnTab(view.CancelBtn, Lang.GetValue("common_button_cancel"));
        view.CancelBtn.onClick.Add(() => { view.popUpTap.selectedIndex = 0; });
        view.n27.text = Lang.GetValue("best_35");
    }
    private void FriendCoinCallBack()
    {
        UpdateFriendCoinCount();
        UpdateInteractionTimes();
        // 更新兑换相关UI显示
        UpdateConverUI();
        // 更新所有土地的偷花小手显示
        SceneManager.Instance.UpdateAllLandSteal();
    }

    // 更新好友币
    private void UpdateFriendCoinCount()
    {

        _friendCoinCount = StorageModel.Instance.GetItemCount(GlobalModel.Instance.module_profileConfig.FriendCoinItem);
        view.FriendCoinNum.text = _friendCoinCount.ToString();


    }

    // 更新兑换界面UI
    void UpdateConverUI()
    {
        I_FRIEND_PROFILE_VO vo_ = FriendModel.Instance.GetFriendData(MyselfModel.Instance.friendId);
        _curfriendData = vo_;
        if (vo_ != null && vo_.userInfo != null)
        {
            view.txt_1.text = Lang.GetValue("best_28", TextUtil.GetServerName(vo_.userInfo.serverId, vo_.userInfo.townName));
        }
        else
        {
            view.txt_1.text = Lang.GetValue("best_28", "");
        }
        view.text_count.text = curConverFriendConitCount.ToString();
        view.text_consume.text = curConverFriendConitCount.ToString();
        int surplusExchangeCount = FriendCoinExchangeLimit - (int)FriendModel.Instance.FriendCoinExchangeCnt;
        view.text_visitCount.text = surplusExchangeCount + "/" + FriendCoinExchangeLimit.ToString();
        view.txt_Buyname.text = Lang.GetValue("best_29", FriendCoinExchangeLimit.ToString());
    }

    // 改变当前兑换数
    void ChangeCurrentConverFriendConitCount(int num)
    {
        if (MathF.Abs(num) > FriendCoinExchangeLimit || MathF.Abs(num) == 0) return;
        curConverFriendConitCount = Mathf.Clamp(curConverFriendConitCount + num, 1, FriendCoinExchangeLimit);
        view.btn_addNum.visible = !(curConverFriendConitCount >= FriendCoinExchangeLimit);
        view.btn_lessen.visible = !(curConverFriendConitCount <= 1);
        view.text_count.text = curConverFriendConitCount.ToString();
        view.text_consume.text = curConverFriendConitCount.ToString();
    }

    // 确定兑换
    private void ConverEnterClick()
    {
        var umberOfMutualaid = GlobalModel.Instance.module_profileConfig.umberOfMutualaid;
        var surplusTimes = umberOfMutualaid - MyselfModel.Instance.interactionCnt;
        // 计算并显示剩余数量
        int surplusExchangeCount = FriendCoinExchangeLimit - (int)FriendModel.Instance.FriendCoinExchangeCnt;
        view.text_visitCount.text = surplusExchangeCount + "/" + FriendCoinExchangeLimit.ToString();
        FriendController.Instance.ReqFriendCoinExchange(MyselfModel.Instance.friendId, (uint)curConverFriendConitCount);
    }

    // 处理详情点击按钮
    private void HandleIntroduceBtnClick()
    {
        if (view.popUpTap.selectedIndex != 1)
        {
            view.popUpTap.selectedIndex = 1;
        }
        else
        {
            view.popUpTap.selectedIndex = 0;
        }
    }

    // 处理兑换点击按钮
    private void HandleConverBtnClick()
    {
        if (view.popUpTap.selectedIndex != 2)
        {
            SetBg(view.n46, "Common/common_three_tip_bg.png");
            view.popUpTap.selectedIndex = 2;
        }
        else
        {
            view.popUpTap.selectedIndex = 0;
        }
        UpdateConverUI();
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
        UpdateFriendCoinCount();
        UpdateConverUI();
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
        I_FRIEND_PROFILE_VO vo_ = FriendModel.Instance.GetFriendData(MyselfModel.Instance.friendId);
        _curfriendData = vo_;
        if (vo_ != null && vo_.userInfo != null)
        {
            StringUtil.SetBtnUrl(view.head, "Avatar/ELIDA_common_touxiangdi01.png");
            view.txt_name.text = TextUtil.GetServerName(vo_.userInfo.serverId, vo_.userInfo.townName);
            view.txt_lv.text = vo_.userInfo.userLevel.ToString();
        }
    }

    private List<I_FRIEND_PROFILE_VO> friendListfilter;
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
        ui.txt_name.text = vo.userInfo.townName;
        ui.txt_lv.text = vo.userInfo.userLevel.ToString();
    }

    private void OnItemClick(EventContext context)
    {
        var vo = (context.data as GComponent).data as I_FRIEND_PROFILE_VO;
        FriendController.Instance.ReqFriendVisit(vo.userInfo.userId);
    }

    private void UpdateInteractionTimes()
    {
        var umberOfMutualaid = GlobalModel.Instance.module_profileConfig.umberOfMutualaid + FriendModel.Instance.FriendCoinExchangeCnt;
        //var umberOfMutualaid = GlobalModel.Instance.module_profileConfig.umberOfMutualaid;
        var surplusTimes = umberOfMutualaid - MyselfModel.Instance.interactionCnt;
        view.txt_interactionTimes.color = surplusTimes > 0 ? originColor : Color.red;
        view.txt_interactionTimes.text = $"{surplusTimes}/{umberOfMutualaid}";
    }

    private void AddEvent()
    {
        view.ui_friendList.btn_home.onClick.Clear();
        view.ui_friendList.btn_home.onClick.Add(() =>
        {
            MyselfModel.Instance.atHome = true;
            UIManager.Instance.ClosePanel(UIName.VisitFriendView);
            UIManager.Instance.OpenPanel<MainView>(UIName.MainView, UILayer.MainUI);
            SceneManager.Instance.BackHomeRefreshScene();
        });
        AddEventListener(FriendEvent.FriendSteal, OnFriendSteal);
        view.ui_friendList.btn_left.onClick.Clear();
        view.ui_friendList.btn_left.onClick.Add(OnLeft);
        view.ui_friendList.btn_right.onClick.Clear();
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
    public override void OnHide()
    {
        base.OnHide();
        EventManager.Instance.RemoveEventListener(FriendEvent.FriendCoinExchange, UpdateFriendCoinCount);
    }
}

