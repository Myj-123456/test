
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using protobuf.misc;

public class PlayerInfoView : BaseWindow
{
   private fun_MyInfo.player_info_view view;
    private UIHeroAvatar heroAvatar;
    private int tabType;
    private S_MSG_OTHER_USER_INFO otherData;
   public PlayerInfoView()
    {
        packageName = "fun_MyInfo";
        // 设置委托
        BindAllDelegate = fun_MyInfo.fun_MyInfoBinder.BindAll;
        CreateInstanceDelegate = fun_MyInfo.player_info_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_MyInfo.player_info_view;
        SetBg(view.bg, "Player/ELIDA_gerenxinxi_bg.png");
        StringUtil.SetBtnTab(view.set_btn, Lang.GetValue("setting_txt1"));
        StringUtil.SetBtnTab(view.change_btn, Lang.GetValue("my_info_6"));
        StringUtil.SetBtnTab(view.notice_btn, Lang.GetValue("announcement"));
        StringUtil.SetBtnTab(view.dress_btn, Lang.GetValue("adornTree_2"));
        StringUtil.SetBtnTab(view.report_btn, Lang.GetValue("chat_3"));
        StringUtil.SetBtnTab(view.back_btn, Lang.GetValue("player_info_13"));
        

        StringUtil.SetBtnTab(view.more_btn, Lang.GetValue("player_info_15"));
        StringUtil.SetBtnTab(view.visit_btn, Lang.GetValue("message_button_visit"));
        StringUtil.SetBtnTab(view.chat_btn, Lang.GetValue("player_info_16"));

        StringUtil.SetBtnTab(view.more_com.back_btn, Lang.GetValue("player_info_13"));
        StringUtil.SetBtnTab(view.more_com.report_btn, Lang.GetValue("chat_3"));
        StringUtil.SetBtnTab(view.more_com.del_btn, Lang.GetValue("mail_button_delete"));

        StringUtil.SetBtnTab(view.del_black_btn, Lang.GetValue("player_info_19"));
        view.idLab.text = "ID";
        view.guildLab.text = Lang.GetValue("guild_title");
        view.likeLab.text = Lang.GetValue("dress_13");

        view.flower.decLab.text = Lang.GetValue("player_info_8");
        view.dress.decLab.text = Lang.GetValue("player_info_9");
        view.flowerGod.decLab.text = Lang.GetValue("player_info_10");

        heroAvatar = new UIHeroAvatar();
        heroAvatar.Init(view.spine);

        view.dress_btn.onClick.Add(() =>
        {
            if (!GlobalModel.Instance.GetUnlocked(SysId.Dress, true))
            {
                return;
            }
            Close();
            UIManager.Instance.OpenPanel<DressView>(UIName.DressView, UILayer.SecondUI);
        });

        view.editBtn.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<ChangeNameWindow>(UIName.ChangeNameWindow);
        });

        view.copyBtn.onClick.Add(() =>
        {
            UnityEngine.GUIUtility.systemCopyBuffer = MyselfModel.Instance.userId.ToString();
            UILogicUtils.ShowNotice(Lang.GetValue("common_hint_copysuccess"));
        });
        view.set_btn.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<UserInfoWindow>(UIName.UserInfoWindow);
        });
        view.notice_btn.onClick.Add(() =>
        {
            if (GlobalModel.Instance.GetUnlocked(SysId.SignAndBulletin,true))
            {
                return;
            }
            UIManager.Instance.OpenWindow<GameNoticeWindow>(UIName.GameNoticeWindow);
        });
        view.change_btn.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<ChangeCodeWindow>(UIName.ChangeCodeWindow);
        });
        view.show_item1.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<LikeSelectWindow>(UIName.LikeSelectWindow,0);
        });
        view.show_item2.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<LikeSelectWindow>(UIName.LikeSelectWindow, 1);
        });
        view.show_item3.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<LikeSelectWindow>(UIName.LikeSelectWindow, 2);
        });
        view.show_item4.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<LikeSelectWindow>(UIName.LikeSelectWindow, 3);
        });
        view.visit_btn.onClick.Add(() =>
        {
            if (!GlobalModel.Instance.GetUnlocked(SysId.Friend, true))
            {
                return;
            }
            UIManager.Instance.CloseAllWindown();
            UIManager.Instance.CloseAllPannel();
            FriendController.Instance.ReqFriendVisit(otherData.userInfo.userId);
        });
        view.chat_btn.onClick.Add(() =>
        {
            if (!GlobalModel.Instance.GetUnlocked(SysId.Friend, true))
            {
                return;
            }
            Close();
            FriendChatModel.Instance.CreateFriendChat(otherData.userInfo.userId);
        });
        view.more_btn.onClick.Add(() =>
        {
            view.show.selectedIndex = view.show.selectedIndex == 0?1:0;
        });
        view.more_com.del_btn.onClick.Add(() =>
        {
            if (!GlobalModel.Instance.GetUnlocked(SysId.Friend, true))
            {
                return;
            }
            Close();
            FriendController.Instance.ReqFriendDel(otherData.userInfo.userId);
        });
        view.more_com.back_btn.onClick.Add(() =>
        {
            if (!GlobalModel.Instance.GetUnlocked(SysId.Friend, true))
            {
                return;
            }
            Close();
            FriendController.Instance.ReqFriendInsertBlack(otherData.userInfo.userId);
        });
        view.back_btn.onClick.Add(() =>
        {
            if (!GlobalModel.Instance.GetUnlocked(SysId.Friend, true))
            {
                return;
            }
            Close();
            FriendController.Instance.ReqFriendInsertBlack(otherData.userInfo.userId);
        });
        view.ope_btn.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<InfoChangeWindow>(UIName.InfoChangeWindow,0);
        });
        view.del_black_btn.onClick.Add(() =>
        {
            if (!GlobalModel.Instance.GetUnlocked(SysId.Friend, true))
            {
                return;
            }
            FriendController.Instance.ReqFriendBlackDel(otherData.userInfo.userId);
        });
        view.add_btn.onClick.Add(() =>{
            if (!GlobalModel.Instance.GetUnlocked(SysId.Friend, true))
            {
                return;
            }
            FriendController.Instance.ReqFriendApply(new uint[] { otherData.userInfo.userId });
            view.add_btn.enabled = false;
            StringUtil.SetBtnTab(view.add_btn, Lang.GetValue("guild_list_applied"));
        });
        EventManager.Instance.AddEventListener(SystemEvent.UpdateTownName, UpdateName);
        EventManager.Instance.AddEventListener(PlayerEvent.LoveFlowerArt,UpdateLike);
        EventManager.Instance.AddEventListener(PlayerEvent.SetHead, UpdateHead);
        EventManager.Instance.AddEventListener(PlayerEvent.SetAvatarFrame, UpdateFrame);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        view.show.selectedIndex = 0;
        if (data == null)
        {
            view.status.selectedIndex = 0;
            view.powerNum.text = TextUtil.ChangeCoinShow(MyselfModel.Instance.fighting);
            view.vip.visible = MyselfModel.Instance.IsVip();
            view.id.text = MyselfModel.Instance.userId.ToString();
            view.lvLab.text = "LV." + MyselfModel.Instance.level;
            view.guildName.text = (GuildModel.Instance.guildName == "" ? Lang.GetValue("player_info_11") : GuildModel.Instance.guildName);
            
            UpdateName();
            UpdateExpBar();
            UpdateTitle();
            UpdateLike();
            UpdateFrame();
            UpdateHead();
            heroAvatar.UpdateDress();
            view.flower.num.text = StorageModel.Instance.seedList.Count.ToString();
            view.dress.num.text = DressModel.Instance.GetSuitCount().ToString();
            view.flowerGod.num.text = IkeModel.Instance.vaseRewardInfo.Count.ToString();
            
            
        }
        else
        {
            otherData = data as S_MSG_OTHER_USER_INFO;
            view.status.selectedIndex = otherData.isFriend ? 1 : 2;
            var dressData = DressModel.Instance.GetDressData(otherData.dress.ware);
            heroAvatar.UpdateDress(dressData);
            view.guildName.text = otherData.guildInfo.guildName == ""? Lang.GetValue("player_info_11") : otherData.guildInfo.guildName;
            view.vip.visible = otherData.isVip;
            view.powerNum.text = TextUtil.ChangeCoinShow(otherData.userInfo.fighting);
            view.lvLab.text = "LV." + otherData.userInfo.userLevel;
            view.nameLab.text = TextUtil.GetServerName(otherData.userInfo.serverId, otherData.userInfo.townName);

            view.id.text = otherData.userInfo.userId.ToString();
            UpdateOtherLike(otherData.loveFlowerArt);
            UpdateOtherExpBar(otherData.exp);
            
            var titleId = otherData.userInfo.title;
            if (titleId == 0)
            {
                view.posLab.text = Lang.GetValue("player_info_12");
            }
            else
            {
                var titleVo = ItemModel.Instance.GetItemById((int)titleId);
                view.posLab.text = Lang.GetValue(titleVo.Name);
            }
            var frameVo = ItemModel.Instance.GetItemById((int)otherData.userInfo.headFrame);
            UILogicUtils.ShowHeadFrames(view.frame as common_New.PictureFrame, frameVo);
            var headVo = ItemModel.Instance.GetItemById(int.Parse(otherData.userInfo.headImgId));
            (view.head as common_New.MoonFestivalHead).pic.url = ImageDataModel.Instance.GetIconUrl(headVo);
            view.flower.num.text = otherData.flowerCnt.ToString();
            view.dress.num.text = otherData.suitCollectCnt.ToString();
            view.flowerGod.num.text = otherData.makeIkebanaCnt.ToString();
            if (otherData.isApply)
            {
                view.add_btn.enabled = false;
                StringUtil.SetBtnTab(view.add_btn, Lang.GetValue("guild_list_applied"));
            }
            else
            {
                view.add_btn.enabled = true;
                StringUtil.SetBtnTab(view.add_btn, Lang.GetValue("player_info_14"));
            }
            UpdateOtherInfo();
            EventManager.Instance.AddEventListener(FriendEvent.FriendBlackList, UpdateOtherInfo);
        }
    }

    private void UpdateOtherInfo()
    {
        view.isBlack.selectedIndex = FriendModel.Instance.blackUserIds.IndexOf(otherData.userInfo.userId) != -1 ? 1 : 0;
    }

    private void UpdateOtherExpBar(uint exp)
    {
        var level = PlayerModel.Instance.GetPlayerLv((int)exp);
        var currentNeedExp = level == 1 ? 0 : MyselfModel.Instance.GetLevelInfo((int)level).Exp;
        var nextLevelData = MyselfModel.Instance.GetLevelInfo(level + 1);
        if (nextLevelData != null)
        {
            var max = nextLevelData.Exp - currentNeedExp;
            var baseValue = exp;
            double e = 0;
            if ((baseValue - currentNeedExp) > max)
            {
                e = max;
            }
            else
            {
                e = (baseValue - currentNeedExp);
            }
            view.proLab.text = e + "/" + max;
            view.pro.max = max;
            view.pro.value = e;
        }
        else
        {
            view.proLab.text = exp + "/" + currentNeedExp;
            view.pro.max = 1;
            view.pro.value = 1;
        }
    }

    private void UpdateOtherLike(string loveFlowerArt)
    {
        var likeData = loveFlowerArt == "" ? new string[] { "0", "0", "0", "0" } : loveFlowerArt.Split("#");
        for (var i = 0; i < likeData.Length; i++)
        {
            var id = int.Parse(likeData[i]);
            var cell = view.GetChild("show_item" + (i + 1)) as fun_MyInfo.flower_show_item;
            if (id > 0)
            {
                cell.status.selectedIndex = 0;
                var itemVo = ItemModel.Instance.GetItemById(id);
                if (itemVo.Type == 4501)
                {
                    
                    cell.ike.visible = true;
                    cell.spine.visible = false;
                    UIExt_ikeImg.LoadIkeByItemId((cell.ike as common_New.ikeImg), itemVo.ItemDefId, false);
                }
                else
                {
                    
                    cell.ike.visible = false;
                    cell.spine.visible = true;
                    if (cell.spine.url == "" || cell.spine.url != itemVo.ItemDefId.ToString())
                    {
                        cell.spine.url = "flowers/" + itemVo.ItemDefId;
                        cell.spine.loop = true;
                        cell.spine.forcePlay = true;
                        cell.spine.animationName = "step_3_idle";
                    }
                }
            }
            else
            {
                cell.status.selectedIndex = 2;
            }
        }
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
        EventManager.Instance.RemoveEventListener(FriendEvent.FriendBlackList, UpdateOtherInfo);
    }

    private void UpdateLike()
    {
        var like = MyselfModel.Instance.GetUserInfo(UserInfoType.LIKE_SHOW);
        var likeData = like == null ? new string[] { "0", "0", "0", "0" } : like.info.Split("#");
        for(var i = 0;i < likeData.Length; i++)
        {
            var id = int.Parse(likeData[i]);
            var cell = view.GetChild("show_item" + (i + 1)) as fun_MyInfo.flower_show_item;
            if(id > 0)
            {
                cell.status.selectedIndex = 0;
                var itemVo = ItemModel.Instance.GetItemById(id);
                if(itemVo.Type == 4501)
                {
                    
                    cell.ike.visible = true;
                    cell.spine.visible = false;
                    UIExt_ikeImg.LoadIkeByItemId((cell.ike as common_New.ikeImg), itemVo.ItemDefId, false);
                }
                else
                {
                    
                    cell.ike.visible = false;
                    cell.spine.visible = true;
                    
                   if(cell.spine.url == "" || cell.spine.url != itemVo.ItemDefId.ToString())
                    {
                        cell.spine.url = "flowers/" + itemVo.ItemDefId;
                        cell.spine.loop = true;
                        cell.spine.forcePlay = true;
                        cell.spine.animationName = "step_3_idle";
                    }

                }
            }
            else
            {
                cell.status.selectedIndex = 1;
            }
        }
    }

    private void UpdateTitle()
    {
        var title = MyselfModel.Instance.GetUserInfo(UserInfoType.TITLE);
        if (title == null)
        {
            view.posLab.text = Lang.GetValue("player_info_12");
        }
        else
        {
            var titleId = int.Parse(title.info);
            var titleVo = ItemModel.Instance.GetItemById(titleId);
            view.posLab.text = Lang.GetValue(titleVo.Name);
        }
    }

    private void UpdateHead()
    {
        var head = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_AVATAR);
        var headVo = ItemModel.Instance.GetItemById(int.Parse(head.info));
        (view.head as common_New.MoonFestivalHead).pic.url = ImageDataModel.Instance.GetIconUrl(headVo);
    }
    private void UpdateFrame()
    {
        var headFrame = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_HEAD_FRAME);
        var item = ItemModel.Instance.GetItemById(int.Parse(headFrame.info));
        UILogicUtils.ShowHeadFrames(view.frame as common_New.PictureFrame, item);
    }
    private void UpdateName()
    {
        view.nameLab.text = TextUtil.GetServerName(MyselfModel.Instance.serverId, MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_NICKNAME).info);
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
            view.proLab.text = e + "/" + max;
            view.pro.max = max;
            view.pro.value = e;
        }
        else
        {
            view.proLab.text = MyselfModel.Instance.exp + "/" + currentNeedExp;
            view.pro.max = 1;
            view.pro.value = 1;
        }
    }
}

