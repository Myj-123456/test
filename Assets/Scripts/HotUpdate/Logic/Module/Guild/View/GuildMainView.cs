
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using DG.Tweening;

public class GuildMainView : BaseView
{
    private fun_Guild_New.guild view;
    private fun_Guild_New.guildContent _view;
    private UIHeroAvatar heroAvatar;
    private float maxSacle = 1.5f;
    private float minScale;
    private bool isOpen;

    public BarginEnterManager barginEnter;
    public GuildMainView()
    {
        packageName = "fun_Guild_New";
        // 设置委托
        BindAllDelegate = fun_Guild_New.fun_Guild_NewBinder.BindAll;
        CreateInstanceDelegate = fun_Guild_New.guild.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        view = ui as fun_Guild_New.guild;
        _view = view.main.content;
        SetBg(_view.bg, "Guild/ELIDA_huameng_zhudi.jpg");
        view.title_txt.text = Lang.GetValue("guild_title");
        view.info.txt_code.text = Lang.GetValue("slang_50") + "：";
        barginEnter = new BarginEnterManager(_view.btn_bargin);

        StringUtil.SetBtnTab(_view.btn_shop, Lang.GetValue("guild_main_3"));
        StringUtil.SetBtnTab(_view.btn_match, Lang.GetValue("guild_main_4"));
        StringUtil.SetBtnTab(_view.btn_plant, Lang.GetValue("guild_main_5"));
        
        StringUtil.SetBtnTab(view.btn_manger,Lang.GetValue("guild_main_1"));
        StringUtil.SetBtnTab(view.btn_donate, Lang.GetValue("slang_47"));
        StringUtil.SetBtnTab(view.btn_home, Lang.GetValue("guild_main_2"));

        view.info.txt_title_coin.text = Lang.GetValue("guild_test_3");
        view.info.txt_money_title.text = Lang.GetValue("guild_test_2");//资金
        view.info.txt_num_desc.text = Lang.GetValue("guild_test_1");//人数
        view.info.txt_lv_desc.text = Lang.GetValue("slang_27");//等级
        view.info.txt_notice_title.text = Lang.GetValue("slang_52");//公告

        minScale = GRoot.inst.width / _view.width;
        var minScaleY = (GRoot.inst.height / _view.height);
        minScale = minScaleY > minScale ? minScaleY : minScale;
        isOpen = true;

        view.ui_chat.chatLab.emojies = Emojies.Instance.emojies;

        heroAvatar = new UIHeroAvatar();
        heroAvatar.Init(_view.anim);

        view.main.scrollPane.posX = (_view.width - view.main.width) / 2;
        view.main.scrollPane.posY = (_view.height - view.main.height) / 2;


        view.btn_home.onClick.Add(() =>
        {
            UILogicUtils.ShowNotice(Lang.GetValue("text_book39"));
            //if (GuildModel.Instance.guildMember.powerId == 1)
            //{
            //    if (GuildModel.Instance.guild.memberCnt == 1)
            //    {
            //        UILogicUtils.ShowConfirm(Lang.GetValue("guild.freeGuild"), () =>
            //        {
            //            GuildController.Instance.ReqGuildDissolve();
            //        });
            //    }
            //    else
            //    {
            //        UILogicUtils.ShowNotice(Lang.GetValue("guild.transferFirst"));//请先转让会长
            //    }
            //}
            //else
            //{
            //    UILogicUtils.ShowConfirm(Lang.GetValue("levelup_button") + Lang.GetValue("guild_go_out"), () =>
            //    {
            //        GuildController.Instance.ReqGuildQuit();
            //    });
            //}
        });
        view.ui_chat.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<ChatWindow>(UIName.ChatWindow);
        });

        view.btn_donate.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<GuildDonateWindow>(UIName.GuildDonateWindow);
        });

        _view.btn_match.onClick.Add(() =>
        {
            UIManager.Instance.OpenPanel<GuildMatchView>(UIName.GuildMatchView);
        });

        _view.shop_img.onClick.Add(() =>
        {
            //UIManager.Instance.OpenWindow<GuildMembersWindow>(UIName.GuildMembersWindow);
            UIManager.Instance.OpenWindow<GuildShopWindow>(UIName.GuildShopWindow);
        });

        _view.btn_shop.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<GuildShopWindow>(UIName.GuildShopWindow);
        });

        _view.plant_img.onClick.Add(() =>
        {
            UIManager.Instance.OpenPanel<GuildPlantView>(UIName.GuildPlantView);
        });

        _view.btn_plant.onClick.Add(() =>
        {
            UIManager.Instance.OpenPanel<GuildPlantView>(UIName.GuildPlantView);
        });

        view.help_btn.onClick.Add(() =>
        {
            var param = new string[] { Lang.GetValue("guild.help_title"), Lang.GetValue("guild_planting_025") };
            UIManager.Instance.OpenWindow<HelpWindow>(UIName.HelpWindow, param);
        });

        view.btn_manger.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<GuildManageView>(UIName.GuildManageView);
        });

        view.info.btn_edit.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<GuildChangeNoticeWindow>(UIName.GuildChangeNoticeWindow, (uint)2);
        });

        _view.btn_gift.onClick.Add(() =>
        {
            UIManager.Instance.OpenPanel<GuildGiftView>(UIName.GuildGiftView);
        });

        _view.btn_bargin.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<GuildBargainWindow>(UIName.GuildBargainWindow);
        });

        PinchGesture gesture = new PinchGesture(view.main .content);
        //gesture.onBegin.Add(OnGestureStart);
        //gesture.onAction.Add(OnGestureAction);
        //gesture.onEnd.Add(OnGestureEnd);
        view.displayObject.onMouseWheel.Add(OnMouseWheel);

        view.main.content.onTouchBegin.Add(OnTouchBegin);
        view.main.content.onTouchMove.Add(OnTouchBegin);
        view.main.content.onTouchEnd.Add(OnTouchBegin);
        view.btn_turn.onClick.Add(InfoShowAndHide);

        view.main.content.spine.url = "shetuan";
        view.main.content.spine.loop = true;
        view.main.content.spine.animationName = "animation";
        EventManager.Instance.AddEventListener(GuildEvent.GuildInfo, UpdateGuildInfo);
        EventManager.Instance.AddEventListener(GuildEvent.GuildChangeTxt, UpdateGuildInfoContent);
        EventManager.Instance.AddEventListener(GuildEvent.GuildUpgrade, UpdateGuildInfoContent);
        EventManager.Instance.AddEventListener(ChatEvent.GuildChat, UpdateChatContext);
        EventManager.Instance.AddEventListener(GuildEvent.GuildQuit, CloseView);
    }

    private void OnMouseWheel(EventContext context)
    {
        // 获取滚轮增量值（向上滚动为正，向下为负）
        float delta = context.inputEvent.mouseWheelDelta;

        // 示例：通过滚轮控制缩放
        float scaleFactor = view.main.content.scaleX - delta * 0.01f; // 调整灵敏度
        UpdateScale(scaleFactor);

        // 阻止事件冒泡（可选）
        context.StopPropagation();

    }

    private void UpdateScale(float scaleFactor)
    {
        if (scaleFactor < minScale)
        {
            scaleFactor = minScale;
        }

        if (scaleFactor > maxSacle)
        {
            scaleFactor = maxSacle;
        }
        var oldScale = view.main.content.scaleX;

        // 计算视口中心点在内容坐标系中的位置（缩放前）
        Vector2 viewportCenter = new Vector2(
            view.main.scrollPane.posX + view.main.scrollPane.viewWidth / 2,
            view.main.scrollPane.posY + view.main.scrollPane.viewHeight / 2
        );

        view.main.content.SetScale(scaleFactor, scaleFactor);
        view.main.scrollPane.SetContentSize(_view.width * scaleFactor, _view.height * scaleFactor);

        Vector2 contentCenter = new Vector2(
        (viewportCenter.x / oldScale) * scaleFactor,
        (viewportCenter.y / oldScale) * scaleFactor
        );

        // 计算新的滚动位置
        float newPosX = contentCenter.x - view.main.scrollPane.viewWidth / 2;
        float newPosY = contentCenter.y - view.main.scrollPane.viewHeight / 2;

        // 应用滚动位置并确保边界有效
        view.main.scrollPane.posX = newPosX;
        view.main.scrollPane.posY = newPosY;
    }

    private void OnTouchBegin(EventContext context)
    {
        int touchCount = Stage.inst.touchCount;
        if(touchCount > 1)
        {
            view.main.scrollPane.touchEffect = false;
        }
        Debug.Log($"手指触摸数量:{touchCount}");
    }

    private void OnGestureStart(EventContext context)
    {
        if (view.main.scrollPane.touchEffect)
        {
            view.main.scrollPane.touchEffect = false;
            Debug.Log("触发手势设置不能触摸");
        }
    }


    private void OnGestureAction(EventContext context)
    {
        PinchGesture gesture = (PinchGesture)context.sender;
        // gesture.scaleFactor 是两指缩放的增量比例（相对于上一帧）
        // 直接应用到目标的缩放值
        var targetScale = gesture.delta;
        if (targetScale < 0)
        {
            targetScale = -0.03f;
        }
        else
        {
            targetScale = 0.03f;
        }

        float scaleFactor = view.main.content.scaleX + targetScale; // 调整灵敏度
        Debug.Log($"两指缩放:{gesture.delta},是两指缩放的增量比例:{gesture.scale}");
        UpdateScale(scaleFactor);
        context.StopPropagation();
    }

    private void OnGestureEnd()
    {
        if (!view.main.scrollPane.touchEffect)
        {
            view.main.scrollPane.touchEffect = true;
            Debug.Log("触发手势设置不能触摸结束");
        }
    }

    public override void OnShown()
    {
        base.OnShown();
        //        if (!Stage.touchScreen)
        //        {
        //#if (!UNITY_EDITOR)
        //            Stage.touchScreen = true;
        //#endif

        //        }
        barginEnter.InitSpine();
        GuildController.Instance.ReqGuildInfo();
        // 其他打开面板的逻辑
        UpdateChatContext();
        heroAvatar.UpdateDress();
    }

    private void UpdateGuildInfo()
    {
        UpdateName();
        view.info.txt_id.text = GuildModel.Instance.guild.guildId.ToString();
        UpdateGuildInfoContent();
    }

    public void UpdateGuildInfoContent()
    {
        var data = GuildModel.Instance.guild;
        view.info.txt_lv.text = data.level.ToString();
        view.info.txt_money_content.text = TextUtil.ChangeCoinShow(data.gold);
        //view.txt_slogan.text = data.slogan;
        view.info.txt_notice.txt_notice.text = data.notice;
        view.info.txt_coin.text = TextUtil.ChangeCoinShow(StorageModel.Instance.GetItemCount(GuildModel.guildCoinId));
        int maxNum = GuildModel.Instance.guildLvMap[(int)data.level].JumlahOrang;
        view.info.txt_num.text = data.memberCnt + "/" + maxNum;

        view.info.txt_power_num.text = TextUtil.ChangeCoinShow1(data.memberLimitFighting);
        var name = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_NICKNAME);
        _view.txt_leaderName.text = name != null ? name.info : "";



        view.info.btn_edit.visible = GuildModel.Instance.CanChangeNotice((int)GuildModel.Instance.guildMember.powerId);
    }

    private void UpdateName()
    {
        if (GuildModel.Instance.guild != null)
        {
            view.info.txt_name.text = GuildModel.Instance.guild.guildName;
            //view.setPassBtn.visible = (GuildModel.Instance.guildMember.position == 1 || GuildModel.Instance.guildMember.position == 2);
            //view.btn_changeName.visible = GuildModel.Instance.guildMember.position == 1;
        }
        else
        {
            view.info.txt_name.text = "";
            //view.setPassBtn.visible = false;
            //view.btn_changeName.visible = false;
        }
    }

    private void UpdateChatContext()
    {
        var len = ChatModel.Instance.chatHistory.Count;
        if (len > 0)
        {
            var chat = ChatModel.Instance.chatHistory[len - 1];
            if (chat.chatContent.contentType == 1)
            {
                view.ui_chat.chatLab.text = chat.userInfo.townName + ":" + chat.chatContent.content;
            }
            else
            {
                var id = int.Parse(chat.chatContent.content);
                var info = FriendChatModel.Instance.GetEmojieInfo(id);
                view.ui_chat.chatLab.text = chat.userInfo.townName + ":" + Lang.GetValue(info.Name);
            }
        }
        else
        {
            view.ui_chat.chatLab.text = "";
        }
    }

    private void CloseView()
    {
        UIManager.Instance.ClosePanel(UIName.GuildMainView);
    }

    private void InfoShowAndHide()
    {
        var sequence = DOTween.Sequence();
        if (isOpen)
        {
            view.btn_turn.scaleY = 1;
            sequence.Append(DOTween.To(() => view.info.height, x => view.info.height = x, 100f, 0.2f)).OnComplete(()=> {
                view.info.bg.visible = false;
            }).Play();
        }
        else
        {
            view.info.bg.visible = true;
            view.btn_turn.scaleY = -1;
            sequence.Append(DOTween.To(() => view.info.height, x => view.info.height = x, 429f, 0.2f)).Play();
        }
        isOpen = !isOpen;
    }



    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
        //Stage.touchScreen = MyselfModel.Instance.touchScreen;
        barginEnter.ClearTime();
    }
}

