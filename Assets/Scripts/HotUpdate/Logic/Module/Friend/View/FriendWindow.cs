using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using protobuf.friend;
using ADK;
using protobuf.common;
using System;
using common;


public class FriendWindow : BaseWindow
{
    private fun_Friends.newFriends view;

    private int curTab = -1;

    private List<I_FRIEND_PROFILE> friendListData;

    private List<I_USER_PROFILE> applyListData;

    private List<I_USER_PROFILE> recommendListData;

    private List<I_FRIEND_PROFILE> bestFriendListData;

    private CountDownTimer timer;
    private CountDownTimer cronyCancelTimer;

    private I_FRIEND_PROFILE curSelectedItem;

    private int[] tweenSign;
    private Dictionary<int, UIHeroAvatar> heroAvatarMap;

    public FriendWindow()
    {
        packageName = "fun_Friends";
        // 设置委托
        BindAllDelegate = fun_Friends.fun_FriendsBinder.BindAll;
        CreateInstanceDelegate = fun_Friends.newFriends.CreateInstance;
    }

    public override void OnInit()
    {
        heroAvatarMap = new Dictionary<int, UIHeroAvatar>();
        base.OnInit();
        view = ui as fun_Friends.newFriends;
        view.list.itemRenderer = ListRendererFriend;
        view.list.SetVirtual();

        SetBg(view.bg,"Friend/ELIDA_haoyou_haoyoubg.png");

        view.recommendList.itemRenderer = ListRendererRecommend;

        view.newFriendComeList.itemRenderer = ListRendererApply;

        view.n106.itemRenderer = ListRendererBestFriend;
        view.n106.SetVirtual();
        
        // 添加密友申请同意事件监听
        EventManager.Instance.AddEventListener(FriendEvent.CronyAgree, OnCronyAgree);
        // 添加密友服装数据更新事件监听
        EventManager.Instance.AddEventListener(FlowerRankEvent.dressUserInfo, OnCronyDressUpdate);


        StringUtil.SetBtnTab(view.btn_list, Lang.GetValue("slang_2"));
        StringUtil.SetBtnTab(view.btn_app, Lang.GetValue("slang_3"));
        StringUtil.SetBtnTab(view.btn_refer, Lang.GetValue("slang_4"));
        StringUtil.SetBtnTab(view.btn_addAccount, Lang.GetValue("slang_6"));//添加账户
        StringUtil.SetBtnTab(view.btn_add, Lang.GetValue("gui_btn_sure"));
        view.txt_friend_static.text = Lang.GetValue("slang_88");//点击输入好友ID
        view.inputTipLab.text = Lang.GetValue("Friend_30");//输入ID或名字

        view.txt_tfirm.text = Lang.GetValue("slang_89");//后刷新好友推荐列表
        StringUtil.SetBtnTab(view.onekey_btn, Lang.GetValue("slang_90"));//一键申请
        StringUtil.SetBtnTab(view.btn_allno, Lang.GetValue("slang_92"));//一键拒绝
        StringUtil.SetBtnTab(view.btn_allok, Lang.GetValue("slang_91"));//一键添加

        StringUtil.SetBtnTab(view.btn_get, Lang.GetValue("handBook_14"));

        StringUtil.SetBtnTab(view.btn_sign, Lang.GetValue("Friend_14"));//标识好友
        StringUtil.SetBtnTab(view.btn_clearSign, Lang.GetValue("Friend_13"));//删除标识
        StringUtil.SetBtnTab(view.btn_del, Lang.GetValue("slang_93"));//删除好友

        StringUtil.SetBtnTab(view.btn_openBlack, Lang.GetValue("Friend_31"));//查看黑名单
        StringUtil.SetBtnTab(view.btn_addBlack, Lang.GetValue("Friend_32"));//加入黑名单

        StringUtil.SetBtnTab(view.btn_best, "密友");//密友
        StringUtil.SetBtnTab(view.btn_best_privilege, "特权");
        StringUtil.SetBtnTab(view.btn_best_apply, "申请");
        StringUtil.SetBtnTab(view.btn_best_contact, "聊天");
        StringUtil.SetBtnTab(view.btn_best_visit, "拜访");


        view.btn_list.onClick.Add(() =>
        {
            view.inputLab.text = "";
            ChangeTab(0);
        });
        
        view.btn_app.onClick.Add(() =>
        {
            ChangeTab(1);
        });
        view.btn_refer.onClick.Add(() =>
        {
            ChangeTab(2);
        });
        view.btn_best.onClick.Add(() =>
        {
            ChangeTab(3);
        });
        // 根据密友列表是否为空或是否有好友关系超过12小时的普通好友设置控制器索引和背景图片
        bool hasCronyData = FriendModel.Instance != null && FriendModel.Instance.cronyList != null && FriendModel.Instance.cronyList.Count > 0;
        // 检查是否有好友关系超过12小时的普通好友
        bool hasQualifiedFriend = false;
        if (FriendModel.Instance != null && FriendModel.Instance.friendList != null) {
            foreach (var friendData in FriendModel.Instance.friendList) {
                if (FriendModel.Instance.friendRelationTime.ContainsKey(friendData.userId)) {
                    uint relationTime = FriendModel.Instance.friendRelationTime[friendData.userId];
                    uint currentTime = MyselfModel.Instance.lastServerTime;
                    // 计算好友关系持续时间（秒）
                    uint relationDuration = currentTime - relationTime;
                    // 如果好友关系超过12小时（43200秒），则符合条件
                    if (relationDuration >= 12 * 60 * 60) {
                        hasQualifiedFriend = true;
                        break;
                    }
                }
            }
        }
    
        // 设置控制器索引：有密友数据或有符合条件的普通好友时为1，否则为0
        view.bestNullTips.selectedIndex = (hasCronyData || hasQualifiedFriend) ? 1 : 0;
        // 根据是否有密友数据设置不同的背景图片
        SetBg(view.best_bg, hasCronyData ? "Friend/ELIDA_miyou_bg01.png" : "Friend/ELIDA_miyou_bg02.png");
        view.anim.loop = true;
        view.anim.url = "haoyou";
        view.anim.animationName = "idle";

        view.bg_sign.onClick.Add(() =>
        {
            view.inputFirendID.selectedIndex = 0;
        });

        view.onekey_btn.onClick.Add(OneKeyRecommondAdd);
        view.btn_allok.onClick.Add(OneAddFriend);
        view.btn_allno.onClick.Add(OneKeyDenyFriend);
        view.btn_del.onClick.Add(OnDelFriend);

        view.btn_sign.onClick.Add(OnSignFriend);
        view.btn_addBlack.onClick.Add(OnAddBlackBtn);
        view.btn_clearSign.onClick.Add(OnClearSignFriend);
        view.btn_add.onClick.Add(AddHandle);
        
        view.btn_best_relieve.onClick.Add(()=>
        {
            if(curSelectedItem == null)
            {
                UILogicUtils.ShowNotice("请选择要解除的密友");
                return;
            }
            // 检查当前密友关系是否已经在解除中
            bool isAlreadyCancelling = FriendModel.Instance.IsCronyRelationshipCancelling(curSelectedItem.userId);
            if (!isAlreadyCancelling)
            {
                // 如果不在解除中，显示确认对话框
                view.bestTips.selectedIndex = 3;
                view.best_relievedesc.text="解除后闺蜜等级和经验将被清空，确认解除后将在24小时倒计时结束后正式解除，确定要解除与"+curSelectedItem.townName+"的密友关系吗？";
            }
            else
            {
                // 如果已经在解除中，显示立即解除的对话框
                view.bestTips.selectedIndex = 4;
                UpdateCronyCancelTimeDisplay();
            }
        });
        StringUtil.SetBtnTab(view.btn_bestrelieve, "确定");
        view.btn_bestrelieve.onClick.Add(() =>
        {
            view.bestTips.selectedIndex = 0;
            view.btn_best_relieve.textContrl.selectedIndex = 1;
            
            //发起解除密友关系请求到服务器
            FriendController.Instance.ReqCronyCancel(curSelectedItem.userId); 
            //添加事件监听
            EventManager.Instance.AddEventListener(FriendEvent.CronyCancel, OnCronyCancelCallback);
        });
        StringUtil.SetBtnTab(view.btn_bestedia, "立即解除");
        view.btn_bestedia.onClick.Add(()=>
        {
            //根据剩余倒计时计算所需玉石 - 直接计算方式
            var cronyData = FriendModel.Instance.GetCronyData(curSelectedItem.userId);
            if (cronyData == null || cronyData.cancelTime <= 0)
            {
                view.text_money.text = "0";
                return;
            }
            uint currentServerTime = ServerTime.Time;
            if (currentServerTime <= 0)
            {
                currentServerTime = MyselfModel.Instance.lastServerTime;
            }
            int remainingSeconds = Mathf.Max(0, (int)(cronyData.cancelTime - currentServerTime));
            int jadeCost = CalculateJadeCostForImmediateRemove(remainingSeconds);
            
            //检查用户是否有足够的玉石
            if (MyselfModel.Instance.diamond < jadeCost)
            {
                return;
            }
            
            view.text_money.text=jadeCost.ToString();
            view.bestTips.selectedIndex = 0;
            //确认立即解除
            FriendController.Instance.ReqCronySpeedCancel(curSelectedItem.userId);
            //添加事件监听
            EventManager.Instance.AddEventListener(FriendEvent.CronySpeedCancel, OnCronySpeedCancelCallback);
        });
        StringUtil.SetBtnTab(view.btn_best_unrelieve, "取消");
        view.btn_best_unrelieve.onClick.Add(()=>
        {
            view.bestTips.selectedIndex = 0;
        });
        StringUtil.SetBtnTab(view.btn_best_unedia, "取消解除");
        view.btn_best_unedia.onClick.Add(()=>
        {
            view.bestTips.selectedIndex = 0;
            // 取消解除密友关系请求
            FriendController.Instance.ReqCronyBackCancel(curSelectedItem.userId);
            // 添加事件监听
            EventManager.Instance.AddEventListener(FriendEvent.CronyBackCancel, OnCronyBackCancelCallback);
        });
        view.btn_bestrelieveclose.onClick.Add(()=>
        {
            view.bestTips.selectedIndex = 0;
        });
        view.btn_bestediaclose.onClick.Add(()=>
        {
            view.bestTips.selectedIndex = 0;
        });


        view.btn_openBlack.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<FriendBlackWindow>(UIName.FriendBlackWindow);
        });
        view.btn_addAccount.onClick.Add(() =>
        {
            view.inputFirendID.selectedIndex = 1;
            view.txt_friend_static.visible = true;
            view.txt_friendCode.visible = true;
            view.txt_friendCode.text = "";
        });

        view.input_close_btn.onClick.Add(() =>
        {
            view.inputFirendID.selectedIndex = 0;
        });

        view.btn_copy.onClick.Add(() =>
        {
            UnityEngine.GUIUtility.systemCopyBuffer = MyselfModel.Instance.userId.ToString();
            UILogicUtils.ShowNotice(Lang.GetValue("common_hint_copysuccess"));
        });
        
        //view.close_btn.onClick.Add(CloseView);

        view.btn_best_details.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<BestFriendDetailWindow>(UIName.BestFriendDetailWindow);
        });
        view.btn_best_apply.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<BestFriendApplyWindow>(UIName.BestFriendApplyWindow);
        });
        view.btn_best_visit.onClick.Add(() =>
        {
            //检查是否有选中的密友
            if (curSelectedItem != null)
            {
                //调用拜访方法
                FriendController.Instance.ReqFriendVisit(curSelectedItem.userId);
            }
            else
            {
                UILogicUtils.ShowNotice("请选择要拜访的密友");
            }
        });
        view.inputLab.onFocusIn.Add(OnFindTxtFocusIn);
        view.inputLab.onFocusOut.Add(OnFindTxtFocusOut);

        view.findBtn.onClick.Add(UpdataFriendList);

        EventManager.Instance.AddEventListener(FriendEvent.FriendList, UpdataFriendList);
        EventManager.Instance.AddEventListener(FriendEvent.FriendApplyList, UpdateApplyList);
        EventManager.Instance.AddEventListener(FriendEvent.FriendRecommendList, UpdateRecommendList);
        EventManager.Instance.AddEventListener(FriendEvent.CronyList, UpdateCronyList);
        EventManager.Instance.AddEventListener(FriendEvent.CronyAgree, OnCronyAgree);

        //view.txt_friendCode.characterValidation = InputField.CharacterValidation.Alphanumeric;
        view.txt_friendCode.onFocusIn.Add(OnTxtFocusIn);
        view.txt_friendCode.onFocusOut.Add(OnTxtFocusOut);
        //view.txt_friendCode.restrict = "[0-9]*";
    }

    /// <summary>
    /// 更新bestNullTips控制器状态
    /// </summary>
    private void UpdateBestNullTipsStatus()
    {
        // 检查是否有密友数据
        bool hasCronyData = (FriendModel.Instance != null && FriendModel.Instance.cronyList != null && FriendModel.Instance.cronyList.Count > 0);
        
        // 检查是否有普通好友
        bool hasFriendData = (FriendModel.Instance != null && FriendModel.Instance.friendList != null && FriendModel.Instance.friendList.Count > 0);
        
        // 设置控制器索引：有密友数据或有普通好友数据时为1，否则为0
        view.bestNullTips.selectedIndex = (hasCronyData || hasFriendData) ? 1 : 0;
        // 根据是否有密友数据设置不同的背景图片
        SetBg(view.best_bg, hasCronyData ? "Friend/ELIDA_miyou_bg01.png" : "Friend/ELIDA_miyou_bg02.png");
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        tweenSign = new int[] { 0, 0, 0 };
        view.txt_id.text = Lang.GetValue("Friend_08") + MyselfModel.Instance.userId;
        view.inputLab.text = "";
        curTab = -1;
        ChangeTab(0);
        
        // 更新bestNullTips控制器状态
        UpdateBestNullTipsStatus();
    }
    private void ChangeTab(int tab)
    {
        if (tab == curTab)
        {
            return;
        }
        curTab = tab;
        view.tab.selectedIndex = curTab;
        view.friendListEmpty.selectedIndex = 1;
        UILogicUtils.ClearTweenOfViewList(view.list);
        UILogicUtils.ClearTweenOfViewList(view.recommendList);
        UILogicUtils.ClearTweenOfViewList(view.newFriendComeList);

        //密友界面不显示动画
        if(curTab == 3)
        {
            view.anim.visible = false;
        }
        else
        {
            view.anim.visible = true;
        }

        if (curTab == 0)
        {
            FriendController.Instance.ReqFriendList();


        }
        else if (curTab == 1)
        {
            FriendController.Instance.ReqFriendApplyList();


        }
        else if(curTab == 2)
        {

            FriendController.Instance.ReqFriendRecommendList();


        }
        else
        {
            // 初始化密友列表，设置为5个位置
            view.n106.numItems = 5;
            // 请求密友列表数据
            FriendController.Instance.ReqCronyList();
        }
    }

    public void UpdateRecommendList()
    {
        if (curTab != 2)
        {
            return;
        }
        StringUtil.SetBtnTab(view.empty, Lang.GetValue("Friend_11"));

        recommendListData = FriendModel.Instance.recommendList;
        view.friendListEmpty.selectedIndex = recommendListData.Count > 0 ? 1 : 0;
        view.recommendList.numItems = recommendListData.Count;
        if (timer == null)
        {
            RunRecommandCD();
        }
        if (tweenSign[curTab] == 0)
        {
            tweenSign[curTab] = 1;
            UILogicUtils.AddTweenOfViewList(view.recommendList);
        }
    }

    public void UpdateApplyList()
    {
        if (curTab != 1)
        {
            return;
        }
        StringUtil.SetBtnTab(view.empty, Lang.GetValue("Friend_10"));

        applyListData = FriendModel.Instance.applyList;
        view.friendListEmpty.selectedIndex = applyListData.Count > 0 ? 1 : 0;
        view.newFriendComeList.numItems = applyListData.Count;
        if (tweenSign[curTab] == 0)
        {
            tweenSign[curTab] = 1;
            UILogicUtils.AddTweenOfViewList(view.newFriendComeList);
        }
    }

    public void ListRendererRecommend(int index, GObject item)
    {
        fun_Friends.newFriends_frendListItem ui_ = item as fun_Friends.newFriends_frendListItem;
        ui_.stats.selectedIndex = 2;
        var vo_ = recommendListData[index];
        ui_.max.selectedIndex = index == recommendListData.Count - 1 ? 1 : 0;
        StringUtil.SetBtnUrl(ui_.head, "Avatar/ELIDA_common_touxiangdi01.png");
        ui_.data = vo_;
        //ui_.friend_vip_icon.visible = false;
        ui_.txt_name.text = vo_.townName;
        ui_.txt_lv.text = vo_.userLevel + "";
        StringUtil.SetBtnTab(ui_.btn_add, Lang.GetValue("Friend_17"));//申请

        ui_.btn_add.onClick.Add(OnRecommondAdd);
    }

    public void ListRendererApply(int index, GObject item)
    {
        fun_Friends.newFriends_frendListItem ui_ = item as fun_Friends.newFriends_frendListItem;
        ui_.stats.selectedIndex = 1;
        var vo_ = applyListData[index];
        ui_.max.selectedIndex = index == applyListData.Count - 1 ? 1 : 0;
        //ui_.head_img.url = "Avatar/ELIDA_common_touxiangdi01.png";
        StringUtil.SetBtnUrl(ui_.head, "Avatar/ELIDA_common_touxiangdi01.png");
        ui_.data = vo_;
        //ui_.friend_vip_icon.visible = false;
        ui_.txt_name.text = vo_.townName;
        ui_.txt_lv.text = vo_.userLevel + "";
        StringUtil.SetBtnTab(ui_.btn_yes, Lang.GetValue("Friend_15"));//添加
        StringUtil.SetBtnTab(ui_.btn_no, Lang.GetValue("Friend_16"));//拒绝

        ui_.btn_yes.onClick.Add(OnAddFriend);
        ui_.btn_no.onClick.Add(OnDenyFriend);
    }

    public void UpdataFriendList()
    {
        if (curTab != 0)
        {
            return;
        }
        view.numberText.text = FriendModel.Instance.friendCount.ToString() + "/" + GlobalModel.Instance.module_profileConfig.friendCountMax;
        string str = view.inputLab.text.Trim();
        if (str != "")
        {
            var findFriendDataArr = FriendModel.Instance.FindFriendDataArr(str);
            if (findFriendDataArr.Count > 0)
            {
                friendListData = findFriendDataArr;
            }
            else
            {
                UILogicUtils.ShowNotice(Lang.GetValue("friend_not_found"));
                return;
            }
        }
        else
        {
            friendListData = FriendModel.Instance.friendList;
        }
        friendListData.Sort(FriendSort);
        view.list.numItems = friendListData.Count;
        view.friendListEmpty.selectedIndex = friendListData.Count > 0 ? 1 : 0;
        StringUtil.SetBtnTab(view.empty, Lang.GetValue("Friend_09"));
        if (tweenSign[curTab] == 0)
        {
            tweenSign[curTab] = 1;
            UILogicUtils.AddTweenOfViewList(view.list);
        }
        
        // 更新bestNullTips控制器状态
        UpdateBestNullTipsStatus();
    }

    public void ListRendererFriend(int index, GObject item)
    {
        fun_Friends.newFriends_frendListItem ui_ = item as fun_Friends.newFriends_frendListItem;
        var vo_ = friendListData[index];
        ui_.max.selectedIndex = index == friendListData.Count - 1 ? 1 : 0;
        ui_.stats.selectedIndex = 0;
        ui_.data = vo_;
        ui_.text_sign.text = Lang.GetValue("slang_94");//状态：
        ui_.offlineTxt.text = Lang.GetValue("slang_192") + TimeUtil.GenerateTimeDesc((int)vo_.lastLoginTime);
        //ui_.head.p.url = "Avatar/ELIDA_common_touxiangdi01.png";
        StringUtil.SetBtnUrl(ui_.head, "Avatar/ELIDA_common_touxiangdi01.png");
        ui_.txt_name.text = vo_.townName;
        ui_.txt_lv.text = vo_.userLevel + "";
        StringUtil.SetBtnTab(ui_.btn_visit, Lang.GetValue("Friend_12"));//拜 访
        StringUtil.SetBtnTab(ui_.btn_setting, Lang.GetValue("setting_txt1"));
        StringUtil.SetBtnTab(ui_.giftBtn, Lang.GetValue("text_treasure_item9"));

        ui_.btn_visit.onClick.Add(OnVisitFriend);
        ui_.btn_setting.onClick.Add(OnFriendSetting);

        ui_.icon_heart.visible = !vo_.isMark;
        ui_.pic_sign.visible = vo_.canSteal;
        ui_.timeStarIcon.visible = false;
        ui_.petIcon.visible = false;
        ui_.giftBtn.data = vo_.userId;
        ui_.giftBtn.onClick.Add(CreateChat);
        //ui_.friend_vip_icon.visible = false;
    }
    private void CreateChat(EventContext context)
    {
        var id = (uint)(context.sender as GComponent).data;
        UIManager.Instance.CloseWindow(UIName.FriendWindow);
        FriendChatModel.Instance.CreateFriendChat(id);
    }
    private void RunRecommandCD()
    {
        var flushTimes = GlobalModel.Instance.module_profileConfig.friendFlushTime.Split(",");
        var time = TimeUtil.GetDateTime(ServerTime.Time);
        var h = time.Hour;
        foreach (var item in flushTimes)
        {
            if (h < int.Parse(item))
            {
                int hour = int.Parse(item);
                int min = 0;
                int sec = 0;
                if (int.Parse(item) == 24)
                {
                    sec = 59;
                    min = 59;
                    hour = 23;
                }
                var lastTime = new DateTime(time.Year, time.Month, time.Day, hour, min, sec);
                var leftTime = TimeUtil.GetTimestamp(lastTime) - ServerTime.Time;
                timer = new CountDownTimer(view.txt_name, (int)leftTime, true, 2);
                timer.CompleteCallBacker = TimeCompleteCall;
                break;
            }
        }
    }
    private void TimeCompleteCall()
    {
        timer.Clear();
        //RunRecommandCD();
        FriendController.Instance.ReqFriendRecommendList();
    }

    public void OnFriendSetting(EventContext context)
    {
        var vo_ = (context.sender as GComponent).parent.data as I_FRIEND_PROFILE;
        view.btn_clearSign.visible = vo_.isMark;
        view.btn_sign.visible = !vo_.isMark;
        view.txt_lv.text = vo_.userLevel.ToString();
        view.name_txt.text = vo_.townName;
        StringUtil.SetBtnUrl(view.head, "Avatar/ELIDA_common_touxiangdi01.png");
        
        curSelectedItem = vo_;
        view.inputFirendID.selectedIndex = 2;
    }

    public void OnVisitFriend(EventContext context)
    {
        var friendData = (context.sender as GComponent).parent.data as I_FRIEND_PROFILE;
        FriendController.Instance.ReqFriendVisit(friendData.userId);
    }

    private void OnAddFriend(EventContext context)
    {
        var friendData = (context.sender as GComponent).parent.data as I_USER_PROFILE;
        FriendController.Instance.ReqFriendAgree(new uint[] { friendData.userId });
    }

    private void OnDenyFriend(EventContext context)
    {
        var friendData = (context.sender as GComponent).parent.data as I_USER_PROFILE;
        FriendController.Instance.ReqFriendReject(new uint[] { friendData.userId });
    }

    public void OneAddFriend()
    {
        List<uint> ids = new List<uint>();
        if (applyListData.Count > 0)
        {
            foreach (var friendData in applyListData)
            {
                ids.Add(friendData.userId);
            }
            FriendController.Instance.ReqFriendAgree(ids.ToArray());
        }
    }

    public void OneKeyDenyFriend()
    {
        List<uint> ids = new List<uint>();
        if (applyListData.Count > 0)
        {
            foreach (var friendData in applyListData)
            {
                ids.Add(friendData.userId);
            }
            FriendController.Instance.ReqFriendReject(ids.ToArray());
        }
    }

    public void AddHandle()
    {
        string text = view.txt_friendCode.text;
        if (text == "" || !uint.TryParse(text, out uint result))
        {
            return;
        }
        view.inputFirendID.selectedIndex = 0;
        FriendController.Instance.ReqFriendApply(new uint[] { uint.Parse(text) });
    }

    private void OnRecommondAdd(EventContext context)
    {
        var friendData = (context.sender as GComponent).parent.data as I_USER_PROFILE;
        FriendController.Instance.ReqFriendApply(new uint[] { friendData.userId });

    }

    public void OneKeyRecommondAdd()
    {
        List<uint> ids = new List<uint>();
        if (recommendListData.Count > 0)
        {
            foreach (var friendData in recommendListData)
            {
                ids.Add(friendData.userId);
            }
            FriendController.Instance.ReqFriendApply(ids.ToArray());
        }
    }

    private void OnDelFriend()
    {
        if (curSelectedItem == null)
        {
            return;
        }
        FriendController.Instance.ReqFriendDel(curSelectedItem.userId);
        view.inputFirendID.selectedIndex = 0;
    }

    public void OnSignFriend()
    {
        if (curSelectedItem == null)
        {
            return;
        }
        FriendController.Instance.ReqFriendMark(curSelectedItem.userId, true);
        view.inputFirendID.selectedIndex = 0;
    }

    private void OnAddBlackBtn()
    {
        if (curSelectedItem == null)
        {
            return;
        }
        FriendController.Instance.ReqFriendInsertBlack(curSelectedItem.userId);
        view.inputFirendID.selectedIndex = 0;
    }

    public void OnClearSignFriend()
    {
        if (curSelectedItem == null)
        {
            return;
        }
        FriendController.Instance.ReqFriendMark(curSelectedItem.userId, false);
        view.inputFirendID.selectedIndex = 0;
    }

    public int FriendSort(I_FRIEND_PROFILE a, I_FRIEND_PROFILE b)
    {

        if (!a.isMark && b.isMark)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }

    private void OnTxtFocusIn()
    {
        view.txt_friend_static.visible = false;
    }

    private void OnTxtFocusOut()
    {
        bool visual = view.txt_friendCode.text == "";
        view.txt_friend_static.visible = visual;
    }

    private void OnFindTxtFocusIn()
    {
        view.inputTipLab.visible = false;
    }

    private void OnFindTxtFocusOut()
    {
        view.inputTipLab.visible = view.inputLab.text == "";
    }

    private void CloseView()
    {
        UIManager.Instance.CloseWindow(UIName.FriendWindow);
    }

    public override void OnHide()
    {
        base.OnHide();
        //其他关闭面板的逻辑
        if (timer != null)
        {
            timer.Clear();
            timer = null;
        }
        if (cronyCancelTimer != null)
        {
            cronyCancelTimer.Clear();
            cronyCancelTimer = null;
        }
        // 重置按钮状态
        if (view != null)
        {
            view.btn_best_relieve.textContrl.selectedIndex = 0;
            view.btn_best_relieve.txt_relieveTime.text = "";
            view.text_money.text = "0";
            // 重置提示面板
            view.bestTips.selectedIndex = 0;
        }
        // 清空选中状态
        curSelectedItem = null;
        //移除事件监听器
        EventManager.Instance.RemoveEventListener(FriendEvent.CronyAgree, OnCronyAgree);
        EventManager.Instance.RemoveEventListener(FriendEvent.CronyList, UpdateCronyList);
        EventManager.Instance.RemoveEventListener(FlowerRankEvent.dressUserInfo, OnCronyDressUpdate);
    }
    
    // 密友服装数据更新后刷新界面
    private void OnCronyDressUpdate()
    {
        // 刷新密友人物服装
        if (curSelectedItem != null)
        {
            var cronyData = FriendModel.Instance.GetCronyData(curSelectedItem.userId);
            if (cronyData != null)
            {
                // 重新加载对方人物服装
                ShowCronyCharacters(null, cronyData);
            }
        }
    }
    
    //处理服务器返回的密友列表数据
    private void UpdateCronyList()
    {
        //遍历所有密友位置
        for (int i = 0; i < 5; i++)
        {
            //获取密友位置的UI元素
            GObject item = view.n106.GetChildAt(i);
            if (item != null)
            {
                fun_Friends.best_add ui_ = item as fun_Friends.best_add;
                if (ui_ != null && ui_.addController != null)
                {
                    //检查该位置是否已解锁
                    int userLevel = (int)MyselfModel.Instance.level;
                    bool canUnlock = true;
                    if (i > 1)
                    {
                        //检查前一个位置是否解锁
                        for (int j = 2; j < i; j++)
                        {
                            bool prevUnlocked = (j < FriendModel.Instance.unlockCronyCnt) || 
                                               (j == 2 && userLevel >= 30) || 
                                               (j == 3 && userLevel >= 40);
                            if (!prevUnlocked)
                            {
                                canUnlock = false;
                                break;
                            }
                        }
                    }
                    
                    bool isUnlocked = i < FriendModel.Instance.unlockCronyCnt;
                    if (!isUnlocked)
                    {
                        //如果未通过购买解锁，则根据等级和顺序判断
                        if (canUnlock)
                        {
                            if (i == 2 && userLevel >= 30)
                            {
                                isUnlocked = true;
                            }
                            else if (i == 3 && userLevel >= 40)
                            {
                                isUnlocked = true;
                            }
                            else if (i == 4 && userLevel >= 50)
                            {
                                isUnlocked = true;
                            }
                        }
                    }
                    //检查是否有对应的密友数据 - 现在我们遍历整个cronyList来找到第i个有效密友
                    bool hasCronyData = false;
                    S_MSG_CRONY_LIST.I_CRONY_VO cronyData = null;
                    
                    if (FriendModel.Instance != null && FriendModel.Instance.cronyList != null)
                    {
                        // 遍历cronyList，找到第i个有效的密友数据
                        int validIndex = 0;
                        foreach (var data in FriendModel.Instance.cronyList)
                        {
                            if (data != null && data.friendId != 0)
                            {
                                if (validIndex == i)
                                {
                                    hasCronyData = true;
                                    cronyData = data;
                                    break;
                                }
                                validIndex++;
                            }
                        }
                    }
                    
                    // 检查密友关系是否正在解除中（支持双方同时发起解除的情况）
                    bool isCanceling = FriendModel.Instance.IsCronyRelationshipCancelling(cronyData?.friendId ?? 0);
                    
                    //设置UI状态
                    if (hasCronyData)
                    {
                        //有密友数据，设置为已同意状态
                        ui_.addController.selectedIndex = 2;
                        
                        //设置n3组件下的好友信息
                        if (ui_.n3 != null)
                        {
                            //设置头像
                            if (ui_.n3.GetChild("head") is GButton headBtn)
                            {
                                StringUtil.SetBtnUrl(headBtn, "Avatar/ELIDA_common_touxiangdi01.png");
                            }
                            
                            //设置等级 - 获取好友数据来显示等级
                            if (ui_.n3.GetChild("txt_lv") is GTextField lvTxt)
                            {
                                //通过好友ID获取好友信息以显示等级
                                var friendData = FriendModel.Instance.GetFriendData(cronyData.friendId);
                                if (friendData != null)
                                {
                                    lvTxt.text = friendData.userLevel.ToString();
                                }
                            }
                            
                            //设置名字 - 获取好友数据来显示名字
                            if (ui_.n3.GetChild("txt_name") is GTextField nameTxt)
                            {
                                //通过好友ID获取好友信息以显示名字
                                var friendData = FriendModel.Instance.GetFriendData(cronyData.friendId);
                                if (friendData != null)
                                {
                                    nameTxt.text = friendData.townName;
                                }
                            }
                            
                            //设置图标
                            if (ui_.n3.GetChild("icon") is GLoader iconLoader)
                            {
                                //设置对应的图标，这里使用示例图标路径
                                iconLoader.url = "ELIDA_zhujue_icon_dengli_xiao";
                            }
                        }
                    }
                    else
                    {
                        //没有密友数据，设置解锁或未解锁状态
                        ui_.addController.selectedIndex = isUnlocked ? 0 : 1;
                    }
                    
                    //为每个密友位置重新设置正确的点击事件
                    ui_.onClick.Clear();
                    
                    // 如果是解除中的状态，设置点击事件
                    if (hasCronyData && isCanceling)
                    {
                        ui_.onClick.Add(() => {
                            if (cronyData != null)
                            {
                                // 调用ShowCronyCharacters方法来统一更新所有相关状态
                                ShowCronyCharacters(ui_, cronyData);
                            }
                        });
                    }
                    else if (hasCronyData && ui_.addController.selectedIndex == 2)
                    {
                        // 已同意状态，点击显示人物
                        ui_.onClick.Add(() => 
                        {
                            ShowCronyCharacters(ui_, cronyData);
                        });
                    }
                    else if (!isUnlocked)
                    {
                        ui_.onClick.Add(() => {
                            view.bestTips.selectedIndex = 2;
                            view.best_lockclose.onClick.Add(() => 
                            {
                                view.bestTips.selectedIndex = 0;
                            });
                            
                            if (canUnlock)
                            {
                                StringUtil.SetBtnTab(view.btn_buy_unlock,"立即购买");
                                view.btn_buy_unlock.onClick.Add(() => 
                                {
                                    //调用解锁密友位置的方法，当前已解锁数量+1表示要解锁的位置数量
                                    FriendController.Instance.ReqCronyUnlockCt((int)FriendModel.Instance.unlockCronyCnt + 1);
                                    view.bestTips.selectedIndex = 0;
                                });
                            }
                            else
                            {
                                view.bestTips.selectedIndex = 0;
                                UILogicUtils.ShowNotice("需要先解锁前面的位置");
                            }
                        });
                    }
                    else
                    {
                        ui_.onClick.Add(() => 
                        {
                            UIManager.Instance.OpenWindow<BestFriendAddWindow>(UIName.BestFriendAddWindow);
                        });
                    }
                }
            }
        }
        //更新密友数据存在状态，以便切换背景图片
        UpdateBestNullTipsStatus();
    }
    
    //处理密友申请同意事件
    private void OnCronyAgree()
    {
        //找到第一个空的、已解锁的密友位置
        int emptyIndex = FindFirstEmptyCronyPosition();
        if (emptyIndex >= 0)
        {
            //获取最后一个添加的密友数据
            GObject item = view.n106.GetChildAt(emptyIndex);
            if (item != null)
            {
                fun_Friends.best_add ui_ = item as fun_Friends.best_add;
                if (ui_ != null && ui_.addController != null)
                {
                    //设置为已同意状态
                    ui_.addController.selectedIndex = 2;
                    
                    //获取对应的密友数据（假设最后一个添加的就是刚同意的）
                    if (FriendModel.Instance != null && FriendModel.Instance.cronyList != null && FriendModel.Instance.cronyList.Count > 0)
                    {
                        //获取最新添加的密友数据
                        S_MSG_CRONY_LIST.I_CRONY_VO cronyData = null;
                        if (emptyIndex < FriendModel.Instance.cronyList.Count)
                        {
                            cronyData = FriendModel.Instance.cronyList[emptyIndex];
                        } 
                        else if (FriendModel.Instance.cronyList.Count > 0)
                        {
                            //如果索引超出范围，获取最后一个密友数据
                            cronyData = FriendModel.Instance.cronyList[FriendModel.Instance.cronyList.Count - 1];
                        }
                        
                        //设置n3组件下的好友信息
                        if (cronyData != null && ui_.n3 != null)
                        {
                            //设置头像
                            if (ui_.n3.GetChild("head") is GButton headBtn)
                            {
                                StringUtil.SetBtnUrl(headBtn, "Avatar/ELIDA_common_touxiangdi01.png");
                            }
                            
                            //设置等级 - 获取好友数据来显示等级
                            if (ui_.n3.GetChild("txt_lv") is GTextField lvTxt)
                            {
                                //通过好友ID获取好友信息以显示等级
                                var friendData = FriendModel.Instance.GetFriendData(cronyData.friendId);
                                if (friendData != null)
                                {
                                    lvTxt.text = friendData.userLevel.ToString();
                                }
                            }
                            
                            //设置名字 - 获取好友数据来显示名字
                            if (ui_.n3.GetChild("txt_name") is GTextField nameTxt)
                            {
                                //通过好友ID获取好友信息以显示名字
                                var friendData = FriendModel.Instance.GetFriendData(cronyData.friendId);
                                if (friendData != null)
                                {
                                    nameTxt.text = friendData.townName;
                                }
                            }
                            
                            //设置图标
                            if (ui_.n3.GetChild("icon") is GLoader iconLoader)
                            {
                                //设置对应的图标，这里使用示例图标路径
                                iconLoader.url = "ELIDA_zhujue_icon_dengli_xiao";
                            }
                        }
                    }
                }
            }
            //更新密友列表
            if (view.n106 != null)
            {
                view.n106.numItems = 5;
                view.n106.RefreshVirtualList();
            }
            
            // 更新密友空提示状态和背景图片
            UpdateBestNullTipsStatus();
        }
    }
    //查找第一个空的、已解锁的密友位置
    private int FindFirstEmptyCronyPosition()
    {
        int userLevel = (int)MyselfModel.Instance.level;
        
        //遍历所有可能的密友位置
        for (int i = 0; i < 5; i++)
        {
            //检查位置是否已解锁
            bool isUnlocked = false;
            //首先检查是否通过购买解锁了该位置
            if (i < FriendModel.Instance.unlockCronyCnt)
            {
                isUnlocked = true;
            }
            //如果未通过购买解锁，则根据等级和顺序判断
            else
            {
                //检查前一个位置是否解锁
                bool canUnlock = true;
                if (i > 1)
                {
                    bool previousUnlocked = false;
                    int previousIndex = i - 1;
                    //检查前一个位置是否通过购买解锁
                    if (previousIndex < FriendModel.Instance.unlockCronyCnt)
                    {
                        previousUnlocked = true;
                    }
                    //检查前一个位置是否通过等级解锁
                    else if (previousIndex == 2 && userLevel >= 30)
                    {
                        previousUnlocked = true;
                    }
                    else if (previousIndex == 3 && userLevel >= 40)
                    {
                        previousUnlocked = true;
                    }
                    canUnlock = previousUnlocked;
                }
                
                if (canUnlock)
                {
                    if (i == 2 && userLevel >= 30) {
                        isUnlocked = true;
                    } else if (i == 3 && userLevel >= 40) {
                        isUnlocked = true;
                    } else if (i == 4 && userLevel >= 50) {
                        isUnlocked = true;
                    }
                }
            }
            
            //检查该位置是否为空
            if (isUnlocked && !IsPositionOccupied(i))
            {
                return i;
            }
        }
        
        return -1;
    }
    //检查指定位置是否已被占用
    private bool IsPositionOccupied(int positionIndex)
    {
        //遍历cronyList，检查第positionIndex个位置是否有有效的密友数据
        if (FriendModel.Instance != null && FriendModel.Instance.cronyList != null)
        {
            int validIndex = 0;
            foreach (var data in FriendModel.Instance.cronyList)
            {
                if (data != null && data.friendId != 0)
                {
                    if (validIndex == positionIndex)
                    {
                        return true;
                    }
                    validIndex++;
                }
            }
        }
        return false;
    }
        // 原GetRemainingCountdownSeconds方法已简化为直接计算方式
        //计算立即解除所需的玉石数量
        private int CalculateJadeCostForImmediateRemove(int remainingSeconds)
        {
           const int totalTimeBase = 24 * 60 * 60;
            if (remainingSeconds <= 0 || totalTimeBase <= 0)
            {
                return 0;
            }
            // 计算比例：剩余时间越少，花费越多
            float ratio = Mathf.Clamp01((float)remainingSeconds / totalTimeBase);
            // 玉石消耗 = 最高200玉石 * (1 - 剩余时间比例)
            int jadeCost = Mathf.CeilToInt(200 * (1 - ratio));
            // 确保至少消耗1个玉石
            return Mathf.Max(1, jadeCost);
        }
        //解除密友关系回调
        private void OnCronyCancelCallback()
        {
            EventManager.Instance.RemoveEventListener(FriendEvent.CronyCancel, OnCronyCancelCallback);
            //开始更新倒计时显示
            UpdateCronyCancelTimeDisplay();
        }

    /// 更新解除密友倒计时显示
    /// </summary>
    private void UpdateCronyCancelTimeDisplay()
    {
        if (curSelectedItem == null)
        {
            return;
        }
        // 检查是否有正在解除中的密友关系
        var cronyData = FriendModel.Instance.GetCronyData(curSelectedItem.userId);
        if (cronyData == null || cronyData.cancelTime <= 0)
        {
            // 重置按钮状态
            view.btn_best_relieve.textContrl.selectedIndex = 0;
            view.btn_best_relieve.txt_relieveTime.text = "";
            view.text_money.text = "0";
            return;
        }
        else
        {
            //密友倒计时 - 直接使用结束时间减服务器时间，类似VideoDoubleView的实现方式
            uint currentServerTime = ServerTime.Time;
            if (currentServerTime <= 0)
            {
                // 使用本地缓存的服务器时间
                currentServerTime = MyselfModel.Instance.lastServerTime;
            }
            int remainingSeconds = Mathf.Max(0, (int)(cronyData.cancelTime - currentServerTime));
            if (cronyCancelTimer != null)
            {
                cronyCancelTimer.Clear();
                cronyCancelTimer = null;
            }
            
            if (remainingSeconds > 0)
            {
                // 只有当还有剩余时间时才创建倒计时器
                cronyCancelTimer = new CountDownTimer(view.btn_best_relieve.txt_relieveTime, remainingSeconds);
                cronyCancelTimer.hour = true; // 显示小时
                cronyCancelTimer.CompleteCallBacker = () =>
                {
                    // 倒计时结束，清除对应的密友数据
                    if (curSelectedItem != null)
                    {
                        // 清除密友数据
                        FriendModel.Instance.cronyList.RemoveAll(item => item.friendId == curSelectedItem.userId);
                        
                        // 重置按钮状态
                        view.btn_best_relieve.textContrl.selectedIndex = 0;
                        view.btn_best_relieve.txt_relieveTime.text = "";
                        view.text_money.text = "0";
                        
                        // 刷新密友列表
                        UpdateCronyList();
                    }
                };
            }
            else
            {
                // 如果剩余时间为0，直接处理解除逻辑
                if (curSelectedItem != null)
                {
                    // 清除密友数据
                    FriendModel.Instance.cronyList.RemoveAll(item => item.friendId == curSelectedItem.userId);
                    
                    // 重置按钮状态
                    view.btn_best_relieve.textContrl.selectedIndex = 0;
                    view.btn_best_relieve.txt_relieveTime.text = "";
                    view.text_money.text = "0";
                    
                    // 刷新密友列表
                    UpdateCronyList();
                }
            }
        }
    }
    /// <summary>
    /// 更新玉石数量显示
    /// </summary>
    private void UpdateJadeCostDisplay()
        {
            if (curSelectedItem == null)
            {
                view.text_money.text = "0";
                return;
            }
            
            bool isCancelling = FriendModel.Instance.IsCronyRelationshipCancelling(curSelectedItem.userId);
            if (isCancelling)
            {
                // 直接计算剩余时间，类似VideoDoubleView的实现方式
                var cronyData = FriendModel.Instance.GetCronyData(curSelectedItem.userId);
                if (cronyData == null || cronyData.cancelTime <= 0)
                {
                    view.text_money.text = "0";
                    return;
                }
                uint currentServerTime = ServerTime.Time;
                if (currentServerTime <= 0)
                {
                    currentServerTime = MyselfModel.Instance.lastServerTime;
                }
                int remainingSeconds = Mathf.Max(0, (int)(cronyData.cancelTime - currentServerTime));
                int jadeCost = CalculateJadeCostForImmediateRemove(remainingSeconds);
                view.text_money.text = jadeCost.ToString();
            }
            else
            {
                view.text_money.text = "0";
            }
        }
        
        //取消解除密友关系回调
        private void OnCronyBackCancelCallback()
        {
            EventManager.Instance.RemoveEventListener(FriendEvent.CronyBackCancel, OnCronyBackCancelCallback);
            //重置按钮状态
            StringUtil.SetBtnTab(view.btn_best_relieve, "解除密友");
            view.btn_best_relieve.textContrl.selectedIndex = 0;
            view.btn_best_relieve.txt_relieveTime.text = "";
            
            UILogicUtils.ShowNotice("已取消解除密友关系");
        }
        
        //立即解除密友关系回调
        private void OnCronySpeedCancelCallback()
        {
            EventManager.Instance.RemoveEventListener(FriendEvent.CronySpeedCancel, OnCronySpeedCancelCallback);
            
            //显示成功提示
            UILogicUtils.ShowNotice("成功立即解除密友关系");
            
            //删除当前选中密友的人物模型
            if (curSelectedItem != null)
            {
                int friendKey = (int)curSelectedItem.userId;
                if (heroAvatarMap.ContainsKey(friendKey))
                {
                    heroAvatarMap.Remove(friendKey);
                }
                //清空人物模型显示
                ShowCronyCharacters(null, null);
                 // 重置选中状态
                curSelectedItem = null;
            }
            
            //刷新密友列表
            LoadBestFriendList();
            // 重置按钮状态
            view.btn_best_relieve.textContrl.selectedIndex = 0;
            view.btn_best_relieve.txt_relieveTime.text = "";
            view.text_money.text = "0";
        }
        
        //加载密友列表
        private void LoadBestFriendList()
        {
            //重新初始化密友列表，设置为5个位置
            view.n106.numItems = 5;
            view.n106.RefreshVirtualList();
            
            // 更新bestNullTips控制器状态
            UpdateBestNullTipsStatus();
        }
        
        //组件销毁时移除所有事件监听器
        private void OnDestroy()
        {
            EventManager.Instance.RemoveEventListener(FriendEvent.CronyCancel, OnCronyCancelCallback);
            EventManager.Instance.RemoveEventListener(FriendEvent.CronyBackCancel, OnCronyBackCancelCallback);
            EventManager.Instance.RemoveEventListener(FriendEvent.CronySpeedCancel, OnCronySpeedCancelCallback);
        }
        
        // 检查指定位置是否解锁的辅助方法
        private bool IsCronyPositionUnlocked(int index)
        {
            int userLevel = (int)MyselfModel.Instance.level;
            
            // 首先检查是否通过购买解锁了该位置
            if (index < FriendModel.Instance.unlockCronyCnt)
            {
                return true;
            }
            
            // 如果未通过购买解锁，则根据等级判断
            switch (index)
            {
                case 0:
                case 1:
                    // 前两个位置默认解锁
                    return true;
                case 2:
                    return userLevel >= 30;
                case 3:
                    return userLevel >= 40;
                case 4:
                    return userLevel >= 50;
                default:
                    return false;
            }
        }
        
        public void ListRendererBestFriend(int index, GObject item)
        {
            fun_Friends.best_add ui_ = item as fun_Friends.best_add;
            if (ui_ == null) return;
            int userLevel = (int)MyselfModel.Instance.level;
            bool isUnlocked = false;
            bool canUnlock = true;
            if (index < FriendModel.Instance.unlockCronyCnt)
            {
                isUnlocked = true;
            }
            else if (index > 1)
            {
                int previousIndex = index - 1;
                bool previousUnlocked = (previousIndex < FriendModel.Instance.unlockCronyCnt) || 
                                        (previousIndex == 2 && userLevel >= 30) || 
                                        (previousIndex == 3 && userLevel >= 40);
                canUnlock = previousUnlocked;
        
                if (canUnlock)
                {
                isUnlocked = (index == 2 && userLevel >= 30) || 
                             (index == 3 && userLevel >= 40) || 
                             (index == 4 && userLevel >= 50);
                }
            }
            // 检查是否有对应的密友数据
            bool hasCronyData = (FriendModel.Instance != null && FriendModel.Instance.cronyList != null && index < FriendModel.Instance.cronyList.Count);
            S_MSG_CRONY_LIST.I_CRONY_VO cronyData = hasCronyData ? FriendModel.Instance.cronyList[index] : null;
            // 检查密友关系是否正在解除中
            bool isCanceling = (cronyData != null) && FriendModel.Instance.IsCronyRelationshipCancelling(cronyData.friendId);
            // 设置控制器索引
            ui_.addController.selectedIndex = hasCronyData ? 2 : (isUnlocked ? 0 : 1);
            ui_.onClick.Clear();
            // 设置点击事件
            if (hasCronyData && isCanceling)
            {
            ui_.onClick.Add(() => {
            // 解除中状态，点击显示倒计时信息
                if (cronyData != null)
                {
                    curSelectedItem = FriendModel.Instance.GetFriendData(cronyData.friendId);
                    // 直接显示人物信息而不是弹出控制器4
                    ShowCronyCharacters(ui_, cronyData);
                }
            });
        }
        else if (hasCronyData && ui_.addController.selectedIndex == 2)
        {
            ui_.onClick.Add(() => 
            {
                ShowCronyCharacters(ui_, cronyData);
            });
        }
        else if (!isUnlocked)
        {
            ui_.onClick.Add(() => {
                view.bestTips.selectedIndex = 2;
                view.best_lockclose.onClick.Add(() => 
                {
                    view.bestTips.selectedIndex = 0;
                });
                if (canUnlock)
                {
                    StringUtil.SetBtnTab(view.btn_buy_unlock,"立即购买");
                    view.btn_buy_unlock.onClick.Add(() => 
                    {
                        FriendController.Instance.ReqCronyUnlockCt((int)FriendModel.Instance.unlockCronyCnt + 1);
                        view.bestTips.selectedIndex = 0;
                    });
                }
                else
                {
                    view.bestTips.selectedIndex = 0;
                    UILogicUtils.ShowNotice(Lang.GetValue("Friend_需要先解锁前面的位置"));
                }
            });
        }
        else
        {
            ui_.onClick.Add(() => 
            {
                UIManager.Instance.OpenWindow<BestFriendAddWindow>(UIName.BestFriendAddWindow);
            });
        }
    }
    
    /// <summary>
    /// 显示密友界面中的人物
    /// </summary>
    /// <param name="ui_">密友项UI</param>
    /// <param name="cronyData">密友数据</param>
    private void ShowCronyCharacters(fun_Friends.best_add ui_, S_MSG_CRONY_LIST.I_CRONY_VO cronyData)
    {
        if (view == null) return;
        // 设置当前选中的密友
        if (cronyData != null)
        {
            curSelectedItem = FriendModel.Instance.GetFriendData(cronyData.friendId);
            
            // 检查当前密友是否正在解除中
            bool isCancelling = FriendModel.Instance.IsCronyRelationshipCancelling(cronyData.friendId);
            // 更新解除密友按钮状态
            if (isCancelling)
            {
                view.btn_best_relieve.textContrl.selectedIndex = 1;
                // 显示倒计时
                UpdateCronyCancelTimeDisplay();
            }
            else
            {
                view.btn_best_relieve.textContrl.selectedIndex = 0;
                view.btn_best_relieve.txt_relieveTime.text = "";
                view.text_money.text = "0";
            }
            
            // 更新玉石数量文本
            UpdateJadeCostDisplay();
        }
        // 获取我方人物3D容器
        GLoader3D myAnimContainer = view.best_anim_my as GLoader3D;
        // 获取对方人物3D容器
        GLoader3D yourAnimContainer = view.best_anim_you as GLoader3D;
        
        // 加载我方人物
        if (myAnimContainer != null)
        {
            int myKey = -1; // 我方人物的唯一标识
            if (!heroAvatarMap.ContainsKey(myKey))
            {
                UIHeroAvatar myHeroAvatar = new UIHeroAvatar();
                myHeroAvatar.Init(myAnimContainer);
                heroAvatarMap.Add(myKey, myHeroAvatar);
                myHeroAvatar.UpdateDress();
            }
            else
            {
                heroAvatarMap[myKey].UpdateDress();
            }
            // 更新我方人物服装
            var wearList = DressModel.Instance.GetClientWearList();
            var myDressData = DressModel.Instance.GetDressData(wearList);
            heroAvatarMap[myKey].UpdateDress(myDressData);
        }
        
        // 加载对方人物
        if (yourAnimContainer != null)
        {
            if (cronyData != null)
            {
                int friendKey = (int)cronyData.friendId; // 对方人物的唯一标识
                if (!heroAvatarMap.ContainsKey(friendKey))
                {
                    UIHeroAvatar friendHeroAvatar = new UIHeroAvatar();
                    friendHeroAvatar.Init(yourAnimContainer);
                    heroAvatarMap.Add(friendKey, friendHeroAvatar);
                }
                
                // 更新对方人物服装
                var friendDressInfo = FlowerRankModel.Instance.GetUserInfo(5, cronyData.friendId);
                if (friendDressInfo != null && friendDressInfo.dress != null)
                {
                    // 使用获取到的密友服装数据
                    var friendDressData = DressModel.Instance.GetDressData(friendDressInfo.dress.ware);
                    heroAvatarMap[friendKey].UpdateDress(friendDressData);
                }
                else
                {
                    // 如果没有密友服装数据，则请求获取
                    // 暂时使用默认服装
                    var friendDressData = DressModel.Instance.GetDressData(new uint[] { });
                    heroAvatarMap[friendKey].UpdateDress(friendDressData);
                    // 请求密友信息
                    MyselfController.Instance.ReqGetUserInfo(new uint[] { cronyData.friendId }, new uint[] { cronyData.friendId }, (uint)UserType.best,new List<string> {"ware"});
                }
            }
            else
            {
                // 如果没有密友数据，清空对方人物模型
                yourAnimContainer.url = null;
            }
        }
    }
}