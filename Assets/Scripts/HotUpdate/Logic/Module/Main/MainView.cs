


using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using ADK;
using System.Collections.Generic;
using System;
using System.Collections;
using YooAsset;
using UnityEngine.SceneManagement;

public class MainView : BaseView
{
    private fun_MainUI.fun_MainView viewSkin;

    private bool isShowMore = false;
    private float leftBtnsOriginalX = 0;
    private float rightBtnsOriginalX = 0;
    private float topBtnsOriginalY = 0;
    private float bottomBtnsOriginalY = 0;
    private float ui_chooseFlowerY = 0;
    private float powerOriginalX = 0;
    private float taskOriginalX = 0;
    private Vector2 tweenScale = new Vector2(1.02f, 1.02f);
    private ChooseFlowerUI chooseFlowerUI;

    private CountDownTimer _videoCountDown;
    private CountDownTimer _vipCountDown;

    private TaskManger taskMain;

    private MatchBtn matchBtn;
    private DrawBtn drawBtn;
    private GiftPackBtn giftPackBtn;
    private WelfareBtn welfareBtn;
    private FirstRechargeBtn firstBtn;
    public MainView()
    {
        packageName = "fun_MainUI";
        // 设置委托
        BindAllDelegate = fun_MainUI.fun_MainUIBinder.BindAll;
        CreateInstanceDelegate = fun_MainUI.fun_MainView.CreateInstance;
        IsShowOrHideMainUI = false;
        IsAddShowNum = false;
        fairyBatching = false;
    }

    public override void OnInit()
    {
        base.OnInit();
        viewSkin = ui as fun_MainUI.fun_MainView;
        Emojies.Instance.Init();
        PowerNotice.Instance.Init();
        TaskNotice.Instance.Init();
        MarqueeNotice.Instance.Init();
        MainShowManger.Instance.Init(viewSkin.leftBtns, viewSkin.rightBtns);
        InitSpine();
        taskMain = new TaskManger(viewSkin.task_btn);
        matchBtn = new MatchBtn(viewSkin.leftBtns.btn.scroll.btn_match);
        drawBtn = new DrawBtn(viewSkin.leftBtns.btn.scroll.btn_draw);
        giftPackBtn = new GiftPackBtn(viewSkin.leftBtns.btn.scroll.btn_gift);
        welfareBtn = new WelfareBtn(viewSkin.rightBtns.btn_com.scroll.btn_welfare);
        firstBtn = new FirstRechargeBtn(viewSkin.leftBtns.btn.scroll.btn_first_recharge);


        viewSkin.bottomBtns.ui_chat.chatLab.emojies = Emojies.Instance.emojies;
        DropManager.AddMainFlyPos((int)BaseType.GOLD, viewSkin.topBtns.goldBar.gold_icon.LocalToRoot(new Vector2(-20, -30), GRoot.inst));
        DropManager.AddMainFlyPos((int)BaseType.CASH, viewSkin.topBtns.diamandBar.cash_icon.LocalToRoot(new Vector2(-20, -30), GRoot.inst));
        DropManager.AddMainFlyPos((int)BaseType.FST_WATER, viewSkin.topBtns.waterBar.n33.LocalToRoot(new Vector2(-20, -30), GRoot.inst));
        DropManager.AddMainFlyPos((int)BaseType.EXP, viewSkin.topBtns.levelBar.n33.LocalToRoot(new Vector2(-20, -30), GRoot.inst));
        DropManager.seedPos = viewSkin.bottomBtns.btn_baihualu.LocalToRoot(new Vector2(viewSkin.bottomBtns.btn_baihualu.width / 2 - 40, viewSkin.bottomBtns.btn_baihualu.height / 2 - 50), GRoot.inst);

        powerOriginalX = viewSkin.power.x;
        taskOriginalX = viewSkin.task_btn.x;
        bottomBtnsOriginalY = viewSkin.bottomBtns.y;
        leftBtnsOriginalX = viewSkin.leftBtns.x;
        rightBtnsOriginalX = viewSkin.rightBtns.x;
        topBtnsOriginalY = viewSkin.topBtns.y;
        viewSkin.topBtns.y = -viewSkin.topBtns.height;
        viewSkin.leftBtns.x = -viewSkin.leftBtns.width;
        viewSkin.power.x = -viewSkin.power.width;
        viewSkin.task_btn.x = -viewSkin.task_btn.width;
        viewSkin.rightBtns.x = GRoot.inst.width;
        viewSkin.bottomBtns.y = GRoot.inst.height - 290;
        viewSkin.ui_chooseFlower.visible = false;
        ui_chooseFlowerY = viewSkin.ui_chooseFlower.y;
        viewSkin.ui_chooseFlower.y = GRoot.inst.height;
        chooseFlowerUI = new ChooseFlowerUI();
        chooseFlowerUI.Init(viewSkin.ui_chooseFlower as fun_Scene.ChooseFlowerUI);
        AddEvent();
        StringUtil.SetBtnTab(viewSkin.bottomBtns.ui_moreFun.btn_achieve, Lang.GetValue("building_achievement"));
        StringUtil.SetBtnTab(viewSkin.bottomBtns.ui_moreFun.btn_rank, Lang.GetValue("trophy_title"));
        StringUtil.SetBtnTab(viewSkin.bottomBtns.ui_moreFun.btn_dailyTask, Lang.GetValue("COC_Tab_Task"));
        StringUtil.SetBtnTab(viewSkin.bottomBtns.ui_moreFun.btn_storage, Lang.GetValue("name_depot_1"));
        StringUtil.SetBtnTab(viewSkin.bottomBtns.ui_moreFun.btn_role, Lang.GetValue("role_title"));
        StringUtil.SetBtnTab(viewSkin.bottomBtns.ui_moreFun.btn_dress, Lang.GetValue("dress_title1"));
        StringUtil.SetBtnTab(viewSkin.bottomBtns.ui_moreFun.btn_room, Lang.GetValue("flower_shop_title"));
        StringUtil.SetBtnTab(viewSkin.bottomBtns.ui_moreFun.btn_flower_gold, Lang.GetValue("into_battle_3"));
        StringUtil.SetBtnTab(viewSkin.bottomBtns.ui_moreFun.btn_pet, Lang.GetValue("pet_5"));
        StringUtil.SetBtnTab(viewSkin.bottomBtns.ui_moreFun.btn_book, Lang.GetValue("plot_title"));
        StringUtil.SetBtnTab(viewSkin.bottomBtns.ui_moreFun.btn_mail, Lang.GetValue("message_button_mail"));
        StringUtil.SetBtnTab(viewSkin.bottomBtns.ui_moreFun.btn_notice, Lang.GetValue("slang_52"));
        StringUtil.SetBtnTab(viewSkin.bottomBtns.ui_moreFun.btn_store, Lang.GetValue("storeEarningTitle"));
        StringUtil.SetBtnTab(viewSkin.bottomBtns.ui_moreFun.btn_photo, Lang.GetValue("photo_titile"));
        (viewSkin.rightBtns.btn_com.scroll.btn_videoRevenue.GetChild("txtFunName") as GTextField).text = Lang.GetValue("video_popup_title");
        //DropManager.flyPos.Add((int)BaseType.GOLD, GRoot.inst.root.LocalToGlobal(viewSkin.topBtns.goldBar.gold_icon.position));
        //DropManager.flyPos.Add((int)BaseType.CASH, GRoot.inst.root.LocalToGlobal(viewSkin.topBtns.diamandBar.cash_icon.position));
        //DropManager.flyPos.Add((int)BaseType.FST_WATER, GRoot.inst.root.LocalToGlobal(viewSkin.topBtns.waterBar.n33.position));
        //DropManager.flyPos.Add((int)BaseType.EXP, GRoot.inst.root.LocalToGlobal(viewSkin.topBtns.levelBar.n33.position));

        //DropManager.flyPos.Add((int)BaseType.GOLD, viewSkin.topBtns.goldBar.gold_icon.TransformPoint(Vector2.zero, GRoot.inst));
        //DropManager.flyPos.Add((int)BaseType.CASH, viewSkin.topBtns.diamandBar.cash_icon.TransformPoint(Vector2.zero, GRoot.inst));
        //DropManager.flyPos.Add((int)BaseType.FST_WATER, viewSkin.topBtns.waterBar.n33.TransformPoint(Vector2.zero, GRoot.inst));
        //DropManager.flyPos.Add((int)BaseType.EXP, viewSkin.topBtns.levelBar.n33.TransformPoint(Vector2.zero, GRoot.inst));
    }

    private void AddEvent()
    {
        AddEventListener<bool, bool, bool>(SystemEvent.ShowOrHideMainUI, ShowHideUI);
        AddEventListener(SystemEvent.HidePlantUI, HideUiChooseFlower);
        AddEventListener<uint>(SystemEvent.UpdateProfile, UpdateProfile);
        AddEventListener(SystemEvent.UpdateWater, UpdateWater);
        AddEventListener(SystemEvent.StageTouchBegin, OnStageTouchBegin);

        var guild = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_GUILD_ID);
        WorldChatController.Instance.ReqWorldChatHistory(1);
        if (GlobalModel.Instance.GetUnlocked(SysId.Guild) && !(guild == null || guild.info == "" || guild.info == "0"))
        {
            ChatController.Instance.ReqGuildChatHistory();
        }

        viewSkin.bottomBtns.btn_moreFun.onClick.Add(OnMoreFun);
        viewSkin.bottomBtns.btn_baihualu.onClick.Add(OnBaihuaLu);
        viewSkin.bottomBtns.btn_friend.onClick.Add(OnFriend);
        viewSkin.bottomBtns.btn_shop.onClick.Add(OnShop);
        //viewSkin.bottomBtns.btn_drawCard.onClick.Add(OnFunUnOpen);
        viewSkin.bottomBtns.btn_guild.onClick.Add(OnGuild);
        viewSkin.bottomBtns.btn_gm.onClick.Add(OnGM);
        viewSkin.bottomBtns.ui_chat.onClick.Add(OnChat);


        viewSkin.leftBtns.btn.scroll.btn_vip.onClick.Add(OnVipOpen);
        viewSkin.leftBtns.btn.scroll.btn_gift.onClick.Add(OnFunUnOpen);
        //viewSkin.leftBtns.btn_draw.onClick.Add(OnDrawOpen);
        viewSkin.leftBtns.btn.scroll.btn_match.onClick.Add(OnMatchOpen);
        viewSkin.leftBtns.btn.scroll.btn_active.onClick.Add(OnFunUnOpen);

        viewSkin.rightBtns.btn_com.scroll.btn_welfare.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<WelfareMainView>(UIName.WelfareMainView, 0);
        });
        viewSkin.rightBtns.btn_com.scroll.btn_inviteGift.onClick.Add(OnQdhn);
        viewSkin.rightBtns.btn_com.scroll.btn_videoRevenue.onClick.Add(OnVideo);
        viewSkin.rightBtns.btn_com.scroll.btn_dailyActivities.onClick.Add(OnFunUnOpen);

        viewSkin.bottomBtns.ui_moreFun.btn_role.onClick.Add(OnRole);
        viewSkin.bottomBtns.ui_moreFun.btn_storage.onClick.Add(OnStorage);
        viewSkin.bottomBtns.ui_moreFun.btn_rank.onClick.Add(OnRank);
        viewSkin.bottomBtns.ui_moreFun.btn_dailyTask.onClick.Add(OnDailyTask);
        viewSkin.bottomBtns.ui_moreFun.btn_achieve.onClick.Add(OnAchieveTask);
        //viewSkin.bottomBtns.ui_moreFun.btn_loginGift.onClick.Add(OnLoginGift);
        //viewSkin.bottomBtns.ui_moreFun.btn_cultivateShop.onClick.Add(OnCultivateShop);
        //viewSkin.bottomBtns.ui_moreFun.btn_qdhn.onClick.Add(OnQdhn);
        //viewSkin.bottomBtns.ui_moreFun.btn_vipShop.onClick.Add(OnVipShop);
        //viewSkin.bottomBtns.ui_moreFun.btn_turntable.onClick.Add(OnFunUnOpen);
        //viewSkin.bottomBtns.ui_moreFun.btn_comingSoon.onClick.Add(OnFunUnOpen);
        //viewSkin.bottomBtns.ui_moreFun.btn_newHandBook.onClick.Add(OnFunUnOpen);
        viewSkin.topBtns.frame.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<PlayerInfoView>(UIName.PlayerInfoView);
        });
        viewSkin.topBtns.diamandBar.btn_recharge.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<RechargeMainView>(UIName.RechargeMainView, 3);
        });
        //viewSkin.bottomBtns.ui_moreFun.btn_hb.onClick.Add(() =>
        //{
        //    if (!GlobalModel.Instance.GetUnlocked(SysId.PlayerInfo, true))
        //    {
        //        return;
        //    }
        //    HideMoreFunUI();
        //    UIManager.Instance.OpenPanel<PlayerInfoView>(UIName.PlayerInfoView);
        //});
        //viewSkin.bottomBtns.ui_moreFun.btn_jx.onClick.Add(() =>
        //{
        //    if (!GlobalModel.Instance.GetUnlocked(SysId.PvpMatch, true))
        //    {
        //        return;
        //    }
        //    HideMoreFunUI();
        //    UIManager.Instance.OpenPanel<ArenaRankView>(UIName.ArenaRankView);
        //});
        viewSkin.bottomBtns.ui_moreFun.btn_dress.onClick.Add(() =>
        {
            if (!GlobalModel.Instance.GetUnlocked(SysId.Dress, true))
            {
                return;
            }
            HideMoreFunUI();
            UIManager.Instance.OpenPanel<DressView>(UIName.DressView);
        });
        viewSkin.bottomBtns.ui_moreFun.btn_room.onClick.Add(() =>
        {
            if (!GlobalModel.Instance.GetUnlocked(SysId.FlowerGold, true))
            {
                return;
            }
            HideMoreFunUI();
            UIManager.Instance.OpenPanel<FloristView>(UIName.FloristView);
        });
        viewSkin.bottomBtns.ui_moreFun.btn_flower_gold.onClick.Add(() =>
        {
            if (!GlobalModel.Instance.GetUnlocked(SysId.FlowerGold, true))
            {
                return;
            }
            HideMoreFunUI();
            UIManager.Instance.OpenPanel<FlowerGoldView>(UIName.FlowerGoldView);
        });
        viewSkin.bottomBtns.ui_moreFun.btn_book.onClick.Add(() =>
        {
            if (!GlobalModel.Instance.GetUnlocked(SysId.Adventure, true))
            {
                return;
            }
            HideMoreFunUI();
            UIManager.Instance.OpenWindow<PlotMainWindow>(UIName.PlotMainWindow);
        });
        viewSkin.bottomBtns.ui_moreFun.btn_mail.onClick.Add(() =>
        {
            if (!GlobalModel.Instance.GetUnlocked(SysId.Mail, true))
            {
                return;
            }
            UIManager.Instance.OpenWindow<MailWindow>(UIName.MailWindow);
        });
        viewSkin.bottomBtns.ui_moreFun.btn_notice.onClick.Add(() =>
        {

            UIManager.Instance.OpenWindow<GameNoticeWindow>(UIName.GameNoticeWindow);
        });
        viewSkin.bottomBtns.ui_moreFun.btn_store.onClick.Add(() =>
        {

            UIManager.Instance.OpenWindow<StoreEarningWindow>(UIName.StoreEarningWindow);
        });
        viewSkin.bottomBtns.ui_moreFun.btn_photo.onClick.Add(() =>
        {
            UILogicUtils.ShowNotice(Lang.GetValue("text_book39"));
            
        });
        viewSkin.bottomBtns.ui_moreFun.btn_pet.onClick.Add(() =>
        {
            if (!GlobalModel.Instance.GetUnlocked(SysId.Pet, true))
            {
                return;
            }
            HideMoreFunUI();
            //UIManager.Instance.OpenPanel<PetView>(UIName.PetView);
        });
        CheckChatBtnShow();
        CheckBtnShow();
        UpdateVideoView();
        UpdateVipTime();
        UpdatePower();
        UpdateHead();
        UpdateFrame();
        EventManager.Instance.AddEventListener(ChatEvent.WorldChatHistory, UpdateChatContext);
        EventManager.Instance.AddEventListener(ChatEvent.WorldReceiveChat, UpdateChatContext);

        EventManager.Instance.AddEventListener(SystemEvent.Reconnect, GameReconnect);

        EventManager.Instance.AddEventListener(SystemEvent.UpdateLevel, GameUpdateLevel);
        EventManager.Instance.AddEventListener(VideoEvent.videoDoubleTime, UpdateVideoView);
        EventManager.Instance.AddEventListener(RechargeEvent.VipPay, UpdateVipTime);
        EventManager.Instance.AddEventListener(SystemEvent.UpdateFighting, UpdatePower);
        EventManager.Instance.AddEventListener(RechargeEvent.VideoPay, UpdateVideoView);
        EventManager.Instance.AddEventListener(PlayerEvent.SetHead, UpdateHead);
        EventManager.Instance.AddEventListener(PlayerEvent.SetAvatarFrame, UpdateFrame);
    }

    private void CheckBtnShow()
    {
        var video = VideoModel.Instance.GetVideo((int)VideoSeeType.common_video_id);
        viewSkin.rightBtns.btn_com.scroll.btn_videoRevenue.visible = MyselfModel.Instance.level >= video.Sp_lv;
    }
    private void ShowHideUI(bool isShow, bool isTween, bool isPlant)
    {
        if (isPlant)
        {
            HideMoreFunUI();
        }
        var animTime = 0.3f;
        if (isShow)
        {
            if (PlantModel.Instance.isShowPlantUI)//如果有打开种植ui 那么先关闭
            {
                HideUiChooseFlower();
            }

            if (isTween)
            {
                viewSkin.topBtns.TweenMoveY(topBtnsOriginalY, animTime).SetEase(EaseType.BackOut);
                viewSkin.leftBtns.TweenMoveX(leftBtnsOriginalX, animTime).SetEase(EaseType.BackOut);
                viewSkin.rightBtns.TweenMoveX(rightBtnsOriginalX, animTime).SetEase(EaseType.BackOut);
                viewSkin.bottomBtns.TweenMoveY(bottomBtnsOriginalY, animTime).SetEase(EaseType.BackOut);
                viewSkin.power.TweenMoveX(powerOriginalX, animTime).SetEase(EaseType.BackOut);
                viewSkin.task_btn.TweenMoveX(taskOriginalX, animTime).SetEase(EaseType.BackOut);
            }
            else
            {
                viewSkin.topBtns.y = topBtnsOriginalY;
                viewSkin.leftBtns.x = leftBtnsOriginalX;
                viewSkin.rightBtns.x = rightBtnsOriginalX;
                viewSkin.bottomBtns.y = bottomBtnsOriginalY;
                viewSkin.power.x = powerOriginalX;
                viewSkin.task_btn.x = taskOriginalX;
            }
        }
        else
        {
            if (isTween)
            {
                viewSkin.topBtns.TweenMoveY(-viewSkin.topBtns.height, animTime).SetEase(EaseType.CubicOut);
                viewSkin.leftBtns.TweenMoveX(-viewSkin.leftBtns.width, animTime).SetEase(EaseType.CubicOut);
                viewSkin.rightBtns.TweenMoveX(GRoot.inst.width, animTime).SetEase(EaseType.CubicOut);
                viewSkin.power.TweenMoveX(-viewSkin.power.width, animTime).SetEase(EaseType.CubicOut);
                viewSkin.task_btn.TweenMoveX(-viewSkin.task_btn.width, animTime).SetEase(EaseType.CubicOut);
                viewSkin.bottomBtns.TweenMoveY(GRoot.inst.height - 336, animTime).SetEase(EaseType.CubicOut).OnComplete(() =>
                {
                    if (isPlant)
                    {
                        ShowPlantChooseFlowerUI(true);
                    }
                });
            }
            else
            {
                viewSkin.topBtns.y = -viewSkin.topBtns.height;
                viewSkin.leftBtns.x = -viewSkin.leftBtns.width;
                viewSkin.rightBtns.x = GRoot.inst.width;
                viewSkin.bottomBtns.y = GRoot.inst.height - 290;
                viewSkin.power.x = -viewSkin.power.width;
                viewSkin.task_btn.x = -viewSkin.task_btn.width;
            }
        }
    }

    private void ShowPlantChooseFlowerUI(bool isShow, Action action = null)
    {
        var animTime = 0.3f;
        if (isShow)
        {
            if (viewSkin.ui_chooseFlower.visible) return;
            viewSkin.ui_chooseFlower.visible = true;
            chooseFlowerUI.Update();
            viewSkin.ui_chooseFlower.TweenMoveY(ui_chooseFlowerY, animTime).SetEase(EaseType.BackOut).OnComplete(chooseFlowerUI.OnShowTweenCom);
            PlantModel.Instance.isShowPlantUI = true;
        }
        else
        {
            if (!viewSkin.ui_chooseFlower.visible) return;
            viewSkin.ui_chooseFlower.TweenMoveY(GRoot.inst.height, animTime).SetEase(EaseType.CubicOut).OnComplete(() =>
            {
                viewSkin.ui_chooseFlower.visible = false;
                PlantModel.Instance.isShowPlantUI = false;
                action?.Invoke();
            });
        }
    }

    private void HideUiChooseFlower()
    {
        viewSkin.ui_chooseFlower.y = GRoot.inst.height;
        viewSkin.ui_chooseFlower.visible = false;
        PlantModel.Instance.isShowPlantUI = false;
    }

    private void OnBaihuaLu()
    {
        UIManager.Instance.OpenPanel<FlowerHandbookView>(UIName.FlowerHandbookView);
    }

    private void OnFriend()
    {
        if (!GlobalModel.Instance.GetUnlocked(SysId.Friend, true))
        {
            return;
        }
        UIManager.Instance.OpenWindow<FriendWindow>(UIName.FriendWindow);
    }

    private void OnShop()
    {
        int type = -1;
        if (GlobalModel.Instance.GetUnlocked(SysId.RandomShop))
        {
            type = 0;
        }else if (GlobalModel.Instance.GetUnlocked(SysId.VipPopup))
        {
            type = 2;
        }
        else if (GlobalModel.Instance.GetUnlocked(SysId.Furniture_Shop))
        {
            type = 1;
        }
        if (type != -1)
        {
            UIManager.Instance.OpenPanel<ShopMainView>(UIName.ShopMainView, UILayer.UI, type);
        }
        
    }

    private void OnVipShop()
    {
        if (!GlobalModel.Instance.GetUnlocked(SysId.VipShop, true))
        {
            return;
        }
        UIManager.Instance.OpenPanel<ShopMainView>(UIName.ShopMainView, UILayer.UI, 2);
    }

    private void OnGuild()
    {
        if (!GlobalModel.Instance.GetUnlocked(SysId.Guild, true))
        {
            return;
        }
        var guild = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_GUILD_ID);
        if (guild == null || guild.info == "" || guild.info == "0")
        {
            UIManager.Instance.OpenPanel<GuildEnterView>(UIName.GuildEnterView);
            
        }
        else
        {
            UIManager.Instance.OpenPanel<GuildMainView>(UIName.GuildMainView);
        }
    }
    private void OnGM()
    {
        UIManager.Instance.OpenWindow<DebugWindow>(UIName.DebugWindow);
    }

    private void OnChat()
    {
        UIManager.Instance.OpenWindow<ChatMainWindow>(UIName.ChatMainWindow, 0);//报错先关闭
    }

    private void CheckChatBtnShow()
    {
        //var guild = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_GUILD_ID);
        //if (guild == null || guild.info == "" || guild.info == "0")
        //{
        //    viewSkin.bottomBtns.ui_chat.visible = false;
        //}
        //else
        //{
        //    viewSkin.bottomBtns.ui_chat.visible = true;
        //}

    }

    private void OnStorage()
    {
        //if (!GlobalModel.Instance.GetUnlocked(SysId., true))
        //{
        //    return;
        //}
        HideMoreFunUI();
        UIManager.Instance.OpenPanel<StorageWindow>(UIName.StorageWindow);
    }

    private void OnRole()
    {
        if (!GlobalModel.Instance.GetUnlocked(SysId.Customer, true))
        {
            return;
        }
        HideMoreFunUI();
        UIManager.Instance.OpenPanel<CustomerView>(UIName.CustomerView);
    }

    private void OnVipOpen()
    {
        UIManager.Instance.OpenWindow<RechargeMainView>(UIName.RechargeMainView, 1);
    }
    private void OnMatchOpen()
    {
        UIManager.Instance.OpenPanel<GuildMatchView>(UIName.GuildMatchView);
    }
    public void OnFunUnOpen()
    {
        //UIManager.Instance.OpenWindow<FirstRechargeWindow>(UIName.FirstRechargeWindow);
    }

    public void OnDrawOpen()
    {
        UIManager.Instance.OpenPanel<DrawMainView>(UIName.DrawMainView, UILayer.UI, 0);
    }

    private void OnRank()
    {
        if (!GlobalModel.Instance.GetUnlocked(SysId.Viballs, true))
        {
            return;
        }
        HideMoreFunUI();
        UIManager.Instance.OpenPanel<FlowerRankView>(UIName.FlowerRankView);
    }

    private void OnDailyTask()
    {
        if (!GlobalModel.Instance.GetUnlocked(SysId.DailyTask, true))
        {
            return;
        }
        HideMoreFunUI();
        UIManager.Instance.OpenPanel<DailyTaskWindow>(UIName.DailyTaskWindow, UILayer.UI, 0);
    }
    private void OnAchieveTask()
    {
        if (!GlobalModel.Instance.GetUnlocked(SysId.DailyTask, true))
        {
            return;
        }
        HideMoreFunUI();
        UIManager.Instance.OpenPanel<AchievTaskView>(UIName.AchievTaskView);
    }
    private void OnVideo()
    {
        //if (MyselfModel.Instance.IsVideoDouble())
        //{
        //    return;
        //}
        UIManager.Instance.OpenWindow<VideoDoubleWindow>(UIName.VideoDoubleWindow);
    }

    private void OnLoginGift()
    {
        if (!GlobalModel.Instance.GetUnlocked(SysId.SeventhSign, true))
        {
            return;
        }
        HideMoreFunUI();
        if (SeventhSignModel.Instance.signDay == 0)
        {
            LoginController.Instance.ReqGameMisc();
            SeventhSignModel.Instance.isOpenView = true;
            return;
        }
        UIManager.Instance.OpenWindow<SeventhSignWindow>(UIName.SeventhSignWindow);
    }

    private void OnCultivateShop()
    {
        if (!GlobalModel.Instance.GetUnlocked(SysId.RandomShop, true))
        {
            return;
        }
        HideMoreFunUI();
        UIManager.Instance.OpenPanel<ShopMainView>(UIName.ShopMainView, UILayer.UI, 0);
    }

    private void OnQdhn()
    {
        //if (!GlobalModel.Instance.GetUnlocked(SysId.FirstRecharge, true))
        //{
        //    return;
        //}
        //HideMoreFunUI();
        //UIManager.Instance.OpenPanel<ContractView>(UIName.ContractView);
        //UIManager.Instance.OpenWindow<FirstRechargeWindow>(UIName.FirstRechargeWindow);
        UILogicUtils.ShowNotice(Lang.GetValue("text_book39"));
    }

    private void HideMoreFunUI()
    {
        viewSkin.bottomBtns.ui_moreFun.scale = Vector2.zero;
        viewSkin.bottomBtns.btn_moreFun.img_arrows.rotation = 180;
        viewSkin.bottomBtns.show_grp.visible = true;
        viewSkin.task_btn.visible = TaskModel.Instance.mainTask.mainTaskId != 0;
        isShowMore = false;
    }

    private void OnMoreFun()
    {
        var ui_moreFun = viewSkin.bottomBtns.ui_moreFun;
        isShowMore = !isShowMore;
        TweenBtnMore();
        GTween.Kill(ui_moreFun);
        if (!isShowMore)
        {
            ui_moreFun.TweenScale(Vector2.zero, 0.25f).SetEase(EaseType.CircOut).OnComplete(() =>
            {
                viewSkin.bottomBtns.show_grp.visible = true;
                viewSkin.task_btn.visible = TaskModel.Instance.mainTask.mainTaskId != 0;
            }); ;
        }
        else
        {
            viewSkin.bottomBtns.show_grp.visible = false;
            viewSkin.task_btn.visible = false;
            ui_moreFun.TweenScale(tweenScale, 0.25f).SetEase(EaseType.CircIn).OnComplete(() =>
            {
                ui_moreFun.TweenScale(Vector2.one, 0.25f);
            });
        }
    }

    private void TweenBtnMore()
    {
        viewSkin.bottomBtns.btn_moreFun.img_arrows.TweenRotate(isShowMore ? 0 : 180, 0.3f);
    }

    public override void OnShown()
    {
        base.OnShown();
        viewSkin.bottomBtns.ui_moreFun.scale = Vector2.zero;
        isShowMore = false;

        UpdatePlayerInfo();
    }

    private void UpdatePlayerInfo()
    {
        UpdateLevelAndExp();
        UpdateGold();
        UpdateDiamond();
        UpdateWater();
    }

    private void UpdateProfile(uint itemId)
    {
        if (itemId == (uint)BaseType.CASH)
        {
            UpdateDiamond();
        }
        else if (itemId == (uint)BaseType.GOLD)
        {
            UpdateGold();
        }
        else if (itemId == (uint)BaseType.EXP)
        {
            UpdateLevelAndExp();
        }
    }

    private void UpdateLevelAndExp()
    {
        viewSkin.topBtns.levelBar.txtLevel.text = MyselfModel.Instance.level.ToString();
        UpdateExpBar();
    }

    private void UpdateExpBar()
    {
        var level = MyselfModel.Instance.level;
        var currentNeedExp = level == 1 ? 0 : MyselfModel.Instance.GetLevelInfo((int)level).Exp;
        var nextLevelData = MyselfModel.Instance.GetLevelInfo((int)(level + 1));
        if (nextLevelData != null)
        {
            var max = nextLevelData.Exp - currentNeedExp;
            var baseValue = MyselfModel.Instance.exp;
            double e = 0;
            if ((baseValue - currentNeedExp) > max)
            {
                e = max;
            }
            else
            {
                e = (baseValue - currentNeedExp);
            }
            viewSkin.topBtns.levelBar.txtNum.text = e.ToString();
        }
    }

    private void UpdateGold()
    {
        viewSkin.topBtns.goldBar.txtNum.text = TextUtil.ChangeCoinShow(MyselfModel.Instance.gold);
    }
    private void UpdateDiamond()
    {
        viewSkin.topBtns.diamandBar.txtNum.text = TextUtil.ChangeCoinShow(MyselfModel.Instance.diamond);
    }

    private void UpdateWater()
    {
        viewSkin.topBtns.waterBar.txtNum.text = MyselfModel.Instance.WaterCur + "/" + MyselfModel.Instance.WaterMax;
    }

    private void UpdateVipTime()
    {

        if (_vipCountDown != null)
        {
            _vipCountDown.Clear();
            _vipCountDown = null;
        }
        if (MyselfModel.Instance.vipTime > ServerTime.Time)
        {
            MyselfModel.Instance.WaterMax = GlobalModel.Instance.module_profileConfig.waterLimitVip;
            UpdateWater();
            var endTime = MyselfModel.Instance.vipTime - ServerTime.Time;
            _vipCountDown = new CountDownTimer(null, (int)endTime);
            _vipCountDown.CompleteCallBacker = () =>
            {
                MyselfModel.Instance.WaterMax = GlobalModel.Instance.module_profileConfig.waterLimit;
                UpdateWater();
            };
        }
    }
    private void OnStageTouchBegin()
    {
        if (viewSkin.ui_chooseFlower.visible)
        {
            if (SceneManager.Instance.sceneObjectType == SceneObjectType.Land)//点到土地return掉
            {
                return;
            }
            GObject obj = GRoot.inst.touchTarget;
            if (obj == null)
            {
                ShowPlantChooseFlowerUI(false, () =>
                {
                    ShowHideUI(true, true, false);
                });
            }
        }
    }
    //升级
    public void GameUpdateLevel()
    {
        if (MyselfModel.Instance.level == GlobalModel.Instance.GetUnlockLevel(SysId.FlowerRank))
        {
            if (GlobalModel.Instance.GetUnlocked(SysId.FlowerRank))
            {
                //FlowerRankController.Instance.ResRankInfo();
            }
        }
        if (MyselfModel.Instance.level == GlobalModel.Instance.GetUnlockLevel(SysId.FlowerStar))
        {
            //ScientificPlantingContorller.Instance.ReqCultivationResearchInfo();
        }
        CheckBtnShow();
    }

    private void UpdateChatContext()
    {
        var len = WorldChatModel.Instance.chatHistory.Count;
        if (len > 0)
        {
            var chat = WorldChatModel.Instance.chatHistory[len - 1];
            if (chat.chatContent.contentType == 1)
            {
                viewSkin.bottomBtns.ui_chat.chatLab.text = chat.userInfo.townName + ":" + chat.chatContent.content;
            }
            else
            {
                var id = int.Parse(chat.chatContent.content);
                var info = FriendChatModel.Instance.GetEmojieInfo(id);
                viewSkin.bottomBtns.ui_chat.chatLab.text = chat.userInfo.townName + ":" + Lang.GetValue(info.Name);
            }

        }
        else
        {
            viewSkin.bottomBtns.ui_chat.chatLab.text = "";
        }
    }

    private void UpdateVideoView()
    {
        var videoDouble = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_VIDEO_BUFF);
        var card = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_SKIP_VIDEO_CARD);
        if (videoDouble == null && card == null)
        {
            return;
        }
        var endTime1 = videoDouble == null ? 0 : int.Parse(videoDouble.info);
        var endTime2 = card == null ? 0 : int.Parse(card.info);
        var endTime = endTime1 > endTime2 ? endTime1 : endTime2;
        var time = endTime - (int)ServerTime.Time;
        if (time > 0)
        {
            viewSkin.rightBtns.btn_com.scroll.btn_videoRevenue.status.selectedIndex = 1;
            if (_videoCountDown != null)
            {
                _videoCountDown.Clear();
            }
            _videoCountDown = new CountDownTimer(viewSkin.rightBtns.btn_com.scroll.btn_videoRevenue.GetChild("timeLab") as GTextField, time);
            //_videoCountDown.CompleteCallBacker = UpdateVideoView;
            _videoCountDown.CompleteCallBacker = () =>
            {
                viewSkin.rightBtns.btn_com.scroll.btn_videoRevenue.status.selectedIndex = 0;
                //(viewSkin.rightBtns.btn_videoRevenue.GetChild("txtFunName") as GTextField).text = Lang.GetValue("video_popup_title");
                EventManager.Instance.DispatchEvent(VideoEvent.videoDoubleEnd);
            };
        }
        else
        {
            viewSkin.rightBtns.btn_com.scroll.btn_videoRevenue.status.selectedIndex = 0;


        }
    }

    private void UpdatePower()
    {
        viewSkin.power.powerNum.text = MyselfModel.Instance.fighting.ToString();
    }

    private void GameReconnect()
    {
        var guild = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_GUILD_ID);
        if (guild != null && guild.info != "" && guild.info != "0")
        {
            ChatController.Instance.ReqGuildChatHistory();
        }
        UpdateVideoView();
    }

    private void UpdateHead()
    {
        var head = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_AVATAR);
        var headVo = ItemModel.Instance.GetItemById(int.Parse(head.info));
        viewSkin.topBtns.loader_headIcon.url = ImageDataModel.Instance.GetIconUrl(headVo);
    }

    private void UpdateFrame()
    {
        var headFrame = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_HEAD_FRAME);
        var item = ItemModel.Instance.GetItemById(int.Parse(headFrame.info));
        UILogicUtils.ShowHeadFrames(viewSkin.topBtns.frame as common_New.PictureFrame, item);
    }

    private void InitSpine()
    {
        //viewSkin.bottomBtns.btn_baihualu.spine.url = "baihuace";
        //viewSkin.bottomBtns.btn_baihualu.spine.loop = true;
        //viewSkin.bottomBtns.btn_baihualu.spine.animationName = "animation";
    }
}
