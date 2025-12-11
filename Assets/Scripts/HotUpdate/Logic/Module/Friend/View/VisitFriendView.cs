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
    private int Number=1;
    private int _friendCoinCount = 0;
    private I_FRIEND_PROFILE _curfriendData;//当前访问朋友信息
    private int curConverFriendConitCount = 1;//当前准备兑换好友币数
    private const int FriendCoinExchangeLimit = 8;//每个好友每日好友币兑换摸花上限
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

        EventManager.Instance.AddEventListener(FriendEvent.FriendCoinExchange, FriendCoinCallBack);
        AddEvent();
        view.ui_friendList.one_key_btn.onClick.Add(() =>
        {
            PlantController.Instance.ReqBatchSteal(MyselfModel.Instance.friendId);
        });
        view.n33.onClick.Add(() => {
            HandleIntroduceBtnClick();
        });
        view.n41.onClick.Add(() => {
            HandleConverBtnClick();
        });
        UpdateFriendCoinCount();
        UpdateConverUI();

        view.NumAddBtn.onClick.Add(() => { ChangeCurrentConverFriendConitCount(1); });
        view.LessenBtn.onClick.Add(() => { ChangeCurrentConverFriendConitCount(-1); });
        view.CloseBtn.onClick.Add(() => { view.popUpTap.selectedIndex = 0; });
        StringUtil.SetBtnTab(view.EnterBtn, "确定");
        view.EnterBtn.onClick.Add(() => { ConverEnterClick(); });
        StringUtil.SetBtnTab(view.CancelBtn, "取消");
        view.CancelBtn.onClick.Add(() => { view.popUpTap.selectedIndex = 0; });
    }
    private void FriendCoinCallBack()
    {
        UpdateFriendCoinCount();
        UpdateInteractionTimes();

    }
/// <summary>
/// 更新好友币
/// </summary>
private void UpdateFriendCoinCount()
    {
        try
        {
            const int FriendCoinItemId = 41013044;
            _friendCoinCount = StorageModel.Instance.GetItemCount(FriendCoinItemId);
            view.FriendCoinNum.text = _friendCoinCount.ToString();
            
        }
        catch (System.Exception ex)
        {
            Debug.LogError("获取好友币失败: " + ex.Message);
            // 异常时不修改_cronyBookCount，保持原有值不变
            view.FriendCoinNum.text = _friendCoinCount.ToString();
        }
    }
    /// <summary>
    /// 更新兑换界面UI
    /// </summary>
    void UpdateConverUI()
    {
        view.n68.text = curConverFriendConitCount.ToString();
        view.n86.text = curConverFriendConitCount.ToString();
        int surplusExchangeCount = FriendCoinExchangeLimit - (int)FriendModel.Instance.FriendCoinExchangeCnt;
        view.n91.text = surplusExchangeCount + "/"+FriendCoinExchangeLimit.ToString();
        view.n90.text = string.Format("(单次最多只能购买{0}次!)", FriendCoinExchangeLimit);


        
    }
    /// <summary>
    /// 改变当前兑换数
    /// </summary>
    void ChangeCurrentConverFriendConitCount(int num)
    {
        if (MathF.Abs(num) > FriendCoinExchangeLimit || MathF.Abs(num) == 0) return;
        curConverFriendConitCount = Mathf.Clamp(curConverFriendConitCount + num, 1, FriendCoinExchangeLimit);
        view.NumAddBtn.visible = !(curConverFriendConitCount >= FriendCoinExchangeLimit);
        view.LessenBtn.visible = !(curConverFriendConitCount <= 1); 
        view.n68.text = curConverFriendConitCount.ToString();
        view.n86.text = curConverFriendConitCount.ToString();
    }
    /// <summary>
    /// 确定兑换
    /// </summary>
    private void ConverEnterClick()
    {
        var umberOfMutualaid = GlobalModel.Instance.module_profileConfig.umberOfMutualaid;
        var surplusTimes = umberOfMutualaid - MyselfModel.Instance.interactionCnt;
        view.n91.text = FriendModel.Instance.FriendCoinExchangeCnt + "/" + FriendCoinExchangeLimit.ToString();
        //if ((surplusTimes + curConverFriendConitCount) > FriendCoinExchangeLimit)
        //{
        //    ADK.UILogicUtils.ShowNotice("可兑换已达上限！");
        //    return;
        //}
        FriendController.Instance.ReqFriendCoinExchange(MyselfModel.Instance.friendId, (uint)curConverFriendConitCount);
    }
    /// <summary>
    /// 处理详情点击按钮
    /// </summary>
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
        //UIManager.Instance.OpenWindow<VisitRecordView>(UIName.VisitRecordView);
    }
    /// <summary>
    /// 处理兑换点击按钮
    /// </summary>
    private void HandleConverBtnClick()
    {
        if (view.popUpTap.selectedIndex != 2)
        {
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
        _curfriendData=vo_ ;
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
        var umberOfMutualaid = GlobalModel.Instance.module_profileConfig.umberOfMutualaid +FriendModel.Instance.FriendCoinExchangeCnt;
        //var umberOfMutualaid = GlobalModel.Instance.module_profileConfig.umberOfMutualaid;
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
    public override void OnHide()
    {
        base.OnHide();
        EventManager.Instance.RemoveEventListener(FriendEvent.FriendCoinExchange, UpdateFriendCoinCount);
    }
}

