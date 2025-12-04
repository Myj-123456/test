
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class GuildManageView : BaseWindow
{
    private fun_Guild_New.guild_manager_View _view;
    private uint reviewType;
    private uint memberLimitFighting;
    private int tabType = 0;

    private GuildMembersWindow members;
    private GuildApplyWindow apply;

    private int approval;
    public GuildManageView()
    {
        packageName = "fun_Guild_New";
        // 设置委托
        BindAllDelegate = fun_Guild_New.fun_Guild_NewBinder.BindAll;
        CreateInstanceDelegate = fun_Guild_New.guild_manager_View.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        _view = ui as fun_Guild_New.guild_manager_View;
        SetBg(_view.bg, "Common/ELIDA_common_bigdi01.png");
        _view.titleLab.text = Lang.GetValue("guild_main_1");
        members = new GuildMembersWindow(_view.members);
        apply = new GuildApplyWindow(_view.apply);
        _view.reviewLab.text = Lang.GetValue("guild_manager_4");
        _view.limitLab.text = Lang.GetValue("guild_manager_5");
        _view.tipLab.text = Lang.GetValue("guild_manager_6");
        _view.monyLab.text = Lang.GetValue("guild.tt_money");
        StringUtil.SetBtnTab(_view.btn_quit, Lang.GetValue("travel_button_quit"));
        StringUtil.SetBtnTab(_view.btn_level, Lang.GetValue("guild.bt_manage_upgrade"));
        StringUtil.SetBtnTab(_view.info_btn, Lang.GetValue("guild.tab_title_guild"));
        StringUtil.SetBtnTab(_view.btn_member, Lang.GetValue("guild.tab_title_member"));
        StringUtil.SetBtnTab(_view.btn_apply, Lang.GetValue("guild.tab_title_applicant"));
        StringUtil.SetBtnTab3(_view.info_btn, Lang.GetValue("guild.tab_title_guild"));
        StringUtil.SetBtnTab3(_view.btn_member, Lang.GetValue("guild.tab_title_member"));
        StringUtil.SetBtnTab3(_view.btn_apply, Lang.GetValue("guild.tab_title_applicant"));

        StringUtil.SetBtnTab3(_view.review_btn, Lang.GetValue("levelup_button"));
        StringUtil.SetBtnTab3(_view.power_btn, Lang.GetValue("levelup_button"));
        _view.chose_grp.list.itemRenderer = RenderReviewList;
        _view.btn_quit.onClick.Add(() =>
        {
            if (GuildModel.Instance.guildMember.powerId == 1)
            {
                if (GuildModel.Instance.guild.memberCnt == 1)
                {
                    UILogicUtils.ShowConfirm(Lang.GetValue("guild.freeGuild"), () =>
                    {
                        GuildController.Instance.ReqGuildDissolve();
                    });
                }
                else
                {
                    UILogicUtils.ShowNotice(Lang.GetValue("guild.transferFirst"));//请先转让会长
                }
            }
            else
            {
                UILogicUtils.ShowConfirm(Lang.GetValue("levelup_button") + Lang.GetValue("guild_go_out"), () =>
                {
                    GuildController.Instance.ReqGuildQuit();
                });
            }
        });

        //_view.btn_sure.onClick.Add(() =>
        //{
        //    GuildController.Instance.ReqGuildEditApproval(reviewType,1, memberLimitFighting);
        //});

        _view.btn_level.onClick.Add(() =>
        {
            if (!GuildModel.Instance.CanCondition())
            {
                UILogicUtils.ShowNotice(Lang.GetValue("Share_code_1007"));
                return;
            }
            GuildController.Instance.ReqGuildUpgrade();
        });
        _view.info_btn.onClick.Add(() =>
        {
            if(tabType != 0)
            {
                ChangeTab(0);
            }
        });

        _view.btn_member.onClick.Add(() =>
        {
            if (tabType != 1)
            {
                ChangeTab(1);
            }
        });

        _view.btn_apply.onClick.Add(() =>
        {
            if (GuildModel.Instance.CanAcept())
            {
                if (tabType != 2)
                {
                    ChangeTab(2);
                }
            }
            else
            {
                UILogicUtils.ShowNotice(Lang.GetValue("Share_code_1007"));
                _view.tab.selectedIndex = tabType;
                return;
            }
            
        });
        //_view.btn_apply.onClick.Add(() =>
        //{
        //    UIManager.Instance.OpenWindow<GuildApplyWindow>(UIName.GuildApplyWindow);
        //});
        _view.chose_btn.onClick.Add(() =>
        {
            if (_view.showChose.selectedIndex == 1)
            {
                _view.showChose.selectedIndex = 0;
                //_view.chose_btn.select.selectedIndex = 0;
            }
            else
            {
                _view.showChose.selectedIndex = 1;
                //_view.chose_btn.select.selectedIndex = 1;
            }

        });

        _view.inputLab.onFocusIn.Add(() =>
        {
            _view.powerLab.text = "";
        });

        _view.review_btn.onClick.Add(() =>
        {
            approval = 1;
            GuildController.Instance.ReqGuildEditApproval(reviewType, 1, GuildModel.Instance.guild.memberLimitFighting);
        });

        _view.power_btn.onClick.Add(() =>
        {
            if(_view.inputLab.text == "")
            {
                return;
            }
            approval = 2;
            memberLimitFighting = uint.Parse(_view.inputLab.text);
            GuildController.Instance.ReqGuildEditApproval(GuildModel.Instance.guild.reviewType, 1, memberLimitFighting);
        });

        EventManager.Instance.AddEventListener(GuildEvent.GuildUpgrade,UpdateLevel);
        EventManager.Instance.AddEventListener(GuildEvent.GuildQuit, Close);
        EventManager.Instance.AddEventListener(GuildEvent.GuildEditApproval, UpdateApproval);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        _view.tab.selectedIndex = 0;
        ChangeTab(0);
    }

    private void ChangeTab(int type)
    {
        tabType = type;
        if(tabType == 0)
        {
            UpdateManger();
        }
        else if(tabType == 1)
        {
            members.OnShow();
        }
        else
        {
            apply.OnShow();
        }
    }

    private void UpdateManger()
    {
        _view.showChose.selectedIndex = 0;
        reviewType = GuildModel.Instance.guild.reviewType;
        memberLimitFighting = GuildModel.Instance.guild.memberLimitFighting;
        
        InitUI();
        UpdateInfo();
        UpdateLevel();
        UpdatePowerLimit();
    }

    private void UpdateApproval()
    {
        if(approval == 1)
        {
            UpdateInfo();
        }
        else if(approval == 2)
        {
            UpdatePowerLimit();
        }
    }

    private void UpdateInfo()
    {
        if (reviewType == 2)
        {
            _view.chose_btn.titleLab.text = Lang.GetValue("guild_manager_1");
        }
        else if(reviewType == 1)
        {
            _view.chose_btn.titleLab.text = Lang.GetValue("guild_manager_2");
        }
        
    }

    private void UpdatePowerLimit()
    {
        _view.inputLab.text = "";
        _view.powerLab.text = memberLimitFighting == 0 ? Lang.GetValue("guild_manager_3") : memberLimitFighting.ToString();
    }

    private void UpdateLevel()
    {
        var curLv = GuildModel.Instance.guildLvMap[(int)GuildModel.Instance.guild.level];
        _view.levelLab.text = Lang.GetValue("guild.manager_lv", GuildModel.Instance.guild.level.ToString());
        if (GuildModel.Instance.guildLvMap.ContainsKey((int)GuildModel.Instance.guild.level + 1))
        {
            var nextLv = GuildModel.Instance.guildLvMap[(int)GuildModel.Instance.guild.level + 1];
            _view.proLab.text = Lang.GetValue("guild.manager_money", GuildModel.Instance.guild.gold + "/" + curLv.Peraga);
            if(GuildModel.Instance.guild.gold < curLv.Peraga)
            {
                _view.pro.max = curLv.Peraga;
                _view.pro.value = GuildModel.Instance.guild.gold;
                _view.btn_level.enabled = false;
            }
            else
            {
                _view.pro.max = 1;
                _view.pro.value = 1;
                _view.btn_level.enabled = true;
            }
            //StringUtil.SetBtnTab(_view.btn_level, "Lv" + nextLv.Level);
        }
        else
        {
            _view.pro.max = 1;
            _view.pro.value = 1;
            _view.btn_level.enabled = false;
        }
            
    }

    private void InitUI()
    {
        _view.manager.selectedIndex = GuildModel.Instance.CanCondition() ? 1 : 0;
        _view.chose_btn.show.selectedIndex = GuildModel.Instance.CanCondition() ? 1 : 0;
        var iconArr = GuildModel.Instance.guild.flagId.Split("#");
        _view.guild_icon.bg.url = "Guild/" + GuildModel.Instance.GetIconImgName(int.Parse(iconArr[1])) + ".png";
        _view.guild_icon.icon.url = "Guild/" + GuildModel.Instance.GetIconImgName(int.Parse(iconArr[0])) + ".png";
        _view.idLab.text = "ID:" + GuildModel.Instance.guild.guildId;
        _view.nameLab.text = GuildModel.Instance.guild.guildName;

        var type = reviewType == 2 ? 0 : 1;
        _view.chose_grp.list.selectedIndex = type;
        _view.chose_grp.list.numItems = 2;
    }

    private void RenderReviewList(int index,GObject item)
    {
        var cell = item as fun_Guild_New.chose_com_item;
        if(index == 0)
        {
            cell.titleLab.text = Lang.GetValue("guild_manager_1");
        }
        else
        {
            cell.titleLab.text = Lang.GetValue("guild_manager_2");
        }
        cell.data = index;
        cell.onClick.Add(ChoseReview);
    }
    private void ChoseReview(EventContext context)
    {
        var index = (int)(context.sender as GComponent).data;
        var type = (uint)(index == 0 ? 2 : 1);
        if(reviewType != type)
        {
            reviewType = type;
            _view.chose_btn.titleLab.text = reviewType == 2 ? Lang.GetValue("guild_manager_1") : Lang.GetValue("guild_manager_2");
            _view.showChose.selectedIndex = 0;
        }
        
    }
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

