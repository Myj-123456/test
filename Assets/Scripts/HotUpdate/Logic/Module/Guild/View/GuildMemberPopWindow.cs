
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using protobuf.guild;
using ADK;

public class GuildMemberPopWindow : BaseWindow
{
    private fun_Guild_New.guild_member_pop _view;
    private I_MEMBER_VO userInfo;
    public GuildMemberPopWindow()
    {
        packageName = "fun_Guild_New";
        // 设置委托
        BindAllDelegate = fun_Guild_New.fun_Guild_NewBinder.BindAll;
        CreateInstanceDelegate = fun_Guild_New.guild_member_pop.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        _view = ui as fun_Guild_New.guild_member_pop;
        SetBg(_view.bg, "Common/ELIDA_common_littledi01.png");
        //_view.titleLab.text = Lang.GetValue("guild_test_5");
        StringUtil.SetBtnTab(_view.btn_transferLeader, Lang.GetValue("guild.bt_pop_transfer"));
        StringUtil.SetBtnTab(_view.btn_demotion, Lang.GetValue("guild.bt_pop_demotion"));
        StringUtil.SetBtnTab(_view.btn_promotion, Lang.GetValue("guild.bt_pop_promotion"));
        StringUtil.SetBtnTab(_view.btn_addFriend, Lang.GetValue("guild.bt_pop_addFriend"));
        StringUtil.SetBtnTab(_view.btn_ban, Lang.GetValue("guild.bt_pop_ban"));
        _view.btn_addFriend.onClick.Add(() =>
        {
            FriendController.Instance.ReqFriendApply(new uint[] { userInfo.userId });
            _view.btn_addFriend.visible = false;
            PlayerPositionChange();
        });

        _view.btn_transferLeader.onClick.Add(() =>
        {
            string str = "<font color='#b25847'>" + Lang.GetValue("guild.trasnferConfirm", userInfo.townName) + "</font>";
            UILogicUtils.ShowConfirm(str, () =>
            {
                GuildController.Instance.ReqGuildPromotion(userInfo.userId,1);
            });

        });

        _view.btn_ban.onClick.Add(() =>
        {
            string str = "<font color='#b25847'>" + Lang.GetValue("guild.banConfirm", userInfo.townName) + "</font>";
            UILogicUtils.ShowConfirm(str, () =>
            {
                GuildController.Instance.ReqGuildKick(userInfo.userId);
            });

        });

        _view.btn_promotion.onClick.Add(() =>
        {
            if (userInfo.powerId == 1) return;
            GuildController.Instance.ReqGuildPromotion(userInfo.userId, userInfo.powerId - 1);
        });

        _view.btn_demotion.onClick.Add(() =>
        {
            if (userInfo.powerId == 4) return;
            GuildController.Instance.ReqGuildPromotion(userInfo.userId, userInfo.powerId + 1);
        });

        EventManager.Instance.AddEventListener(GuildEvent.GuildTransfer, PlayerPositionChange);
        EventManager.Instance.AddEventListener(GuildEvent.GuildKick, CloseView);
        EventManager.Instance.AddEventListener(GuildEvent.GuildPromotion, UpdateData);
        EventManager.Instance.AddEventListener(GuildEvent.LeaveGuild, Close);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        userInfo = data as I_MEMBER_VO;
        //_view.btn_addFriend.visible = !userInfo.isFriend;
        _view.btn_addFriend.visible = false;
        PlayerPositionChange();
        SetUserInfo();
    }

    private void UpdateData()
    {
        PlayerPositionChange();
        SetUserInfo();
    }

    private void PlayerPositionChange()
    {
        _view.btn_ban.visible = GuildModel.Instance.CanBan(userInfo.powerId);
        _view.btn_promotion.visible = GuildModel.Instance.CanPromotion(userInfo.powerId);
        _view.btn_demotion.visible = GuildModel.Instance.CanDemotion(userInfo.powerId);
        _view.btn_transferLeader.visible = GuildModel.Instance.CanTransfer(userInfo.powerId);
        Locate();
    }

    private int GetShowLen()
    {
        int len = 0;
        len += _view.btn_ban.visible ? 1 : 0;
        len += _view.btn_promotion.visible ? 1 : 0;
        len += _view.btn_demotion.visible ? 1 : 0;
        len += _view.btn_transferLeader.visible ? 1 : 0;
        len += _view.btn_addFriend.visible ? 1 : 0;
        return len;
    }

    private void Locate()
    {
        int len = GetShowLen();
        if (len == 5)
        {
            _view.type.selectedIndex = 2;
            _view.btn_demotion.SetPosition(156, 682, 0);
            _view.btn_promotion.SetPosition(386, 682, 0);
            _view.btn_ban.SetPosition(156, 747, 0);
            _view.btn_transferLeader.SetPosition(386, 747, 0);
            _view.btn_addFriend.SetPosition(386, 807, 0);
        }
        else
        {
            _view.type.selectedIndex = len >= 1 ? 0 : 1;
            float y = len < 3 ? 763 : 726;
            float gap = 70;
            float x = len < 2 ? 269 : 156;
            float gap1 = 230;
            float index = 1;
            //if (_view.btn_addFriend.visible)
            //{
            //    _view.btn_addFriend.y = y;
            //    y += gap;
            //}
            if (_view.btn_demotion.visible)
            {

                _view.btn_demotion.y = y + gap * (index > 2 ? 1 : 0);
                _view.btn_demotion.x = x + gap1 * (index % 2 == 0 ? 1 : 0);
                //y += gap * (index > 1 ? 1 : 0);
                //x += gap1 * (index % 2 == 0?0:1);
                index++;
            }

            if (_view.btn_promotion.visible)
            {
                _view.btn_promotion.y = y + gap * (index > 2 ? 1 : 0);
                _view.btn_promotion.x = x + gap1 * (index % 2 == 0 ? 1 : 0);
                //y += gap * (index > 1 ? 1 : 0);
                //x += gap1 * (index % 2);
                index++;
            }

            if (_view.btn_ban.visible)
            {
                _view.btn_ban.y = y + gap * (index > 2 ? 1 : 0);
                _view.btn_ban.x = x + gap1 * (index % 2 == 0 ? 1 : 0);
                //y += gap * (index > 1 ? 1 : 0);
                //x += gap1 * (index % 2);
                index++;
            }

            if (_view.btn_transferLeader.visible)
            {
                _view.btn_transferLeader.y = y + gap * (index > 2 ? 1 : 0);
                _view.btn_transferLeader.x = x + gap1 * (index % 2 == 0 ? 1 : 0);
                index++;
            }

            if (_view.btn_addFriend.visible)
            {
                _view.btn_addFriend.y = y + gap * (index > 2 ? 1 : 0);
                _view.btn_addFriend.x = x + gap1 * (index % 2 == 0 ? 1 : 0);
                index++;
            }
        }

    }

    private void SetUserInfo()
    {
        var view = _view;
        view.txt_name.text = userInfo.townName;
        view.txt_position.text = GuildModel.Instance.GetPositionName(userInfo.powerId);
        view.head.imgLoader.url = "Avatar/ELIDA_common_touxiangdi01.png";
        
        view.head.txt_lv.text = userInfo.userLevel.ToString();
        view.txt_money.text = Lang.GetValue("guild.tt_donate", userInfo.money.ToString());//贡献：{0}
        view.txt_loginTime.text = Lang.GetValue("guild.tt_loginTime", TimeUtil.GenerateTimeDesc((int)userInfo.lastLoginTime));//最后登录：{0}
    }

    private void CloseView()
    {
        UIManager.Instance.CloseWindow(UIName.GuildMemberPopWindow);
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

