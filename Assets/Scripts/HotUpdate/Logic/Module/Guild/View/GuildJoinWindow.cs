
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class GuildJoinWindow : BaseWindow
{
    private fun_Guild_New.guild_join _view;

    private CountDownTimer timer;
    private bool init;

    public GuildJoinWindow()
    {
        packageName = "fun_Guild_New";
        // 设置委托
        BindAllDelegate = fun_Guild_New.fun_Guild_NewBinder.BindAll;
        CreateInstanceDelegate = fun_Guild_New.guild_join.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        _view = ui as fun_Guild_New.guild_join;
        SetBg(_view.bg, "Common/ELIDA_common_bigdi01.png");
        //_view.titleLab.text = Lang.GetValue("guild_test_4");
        _view.txt_code.text = Lang.GetValue("slang_50");//编号
        _view.txt_name.text = Lang.GetValue("slang_54") + "/" + Lang.GetValue("slang_56");//名称/等级
        _view.txt_num.text = Lang.GetValue("slang_55");//人数

        StringUtil.SetBtnTab(_view.btn_create, Lang.GetValue("guild.bt_create"));
        StringUtil.SetBtnTab(_view.btn_search, Lang.GetValue("pray_8"));

        _view.list_guild.itemRenderer = RenderList;
        _view.list_guild.SetVirtual();

        _view.btn_search.onClick.Add(() =>
        {
            if (_view.txt_input.text != "")
            {
                GuildController.Instance.ReqGuildFind(uint.Parse(_view.txt_input.text));
            }
            else
            {
                UILogicUtils.ShowNotice(Lang.GetValue("guild.join_input_request"));//请输入社区id
            }
        });
        _view.randomJoinBtn.onClick.Add(() =>
        {
            if (GuildModel.Instance.IsJoin())
            {
                GuildController.Instance.ReqGuildApply(-1);
            }
            else
            {
                UILogicUtils.ShowNotice(TimeUtil.GenerateTimeDesc1((int)GuildModel.Instance.cdTime) + Lang.GetValue("guild_8"));
            }
            
        });

        _view.btn_create.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<CreateGuildWindow>(UIName.CreateGuildWindow);
        });

        AddEventListener(GuildEvent.GuildList, UpdateList);
        AddEventListener<bool>(GuildEvent.GuildApply, UpdateData);
        AddEventListener(GuildEvent.GuildRandomJoin, UpdateRandomJoin);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        init = false;
        GuildModel.Instance.ClearGuildList();
        GuildController.Instance.ReqApplyGuildList();
    }

    private void UpdateList()
    {
        _view.list_guild.numItems = GuildModel.Instance.guildList.Count;
        if (!init)
        {
            init = true;
            ChangeRandomBtn();
        }
    }

    public void UpdateRandomJoin()
    {
        ChangeRandomBtn();
        UIManager.Instance.CloseWindow(UIName.GuildJoinWindow);
    }

    private void UpdateData(bool join)
    {
        if (join)
        {
            UIManager.Instance.CloseWindow(UIName.GuildJoinWindow);
        }
        else
        {
            _view.list_guild.RefreshVirtualList();
        }
    }

    private void ChangeRandomBtn()
    {
        var randomJoinBtn = _view.randomJoinBtn as common.blueBtn;
        if (timer != null)
        {
            timer.Clear();
        }
        int oddTime = (int)GuildModel.Instance.countdownTime - (int)ServerTime.Time;
        if (oddTime > 0)
        {
            timer = new CountDownTimer(randomJoinBtn.titleLab, oddTime);
            timer.CompleteCallBacker = ChangeRandomBtn;
            _view.randomJoinBtn.enabled = false;
        }
        else
        {
            StringUtil.SetBtnTab(_view.randomJoinBtn, Lang.GetValue("guild_4"));
            _view.randomJoinBtn.enabled = true;
        }

    }

    private void RenderList(int index, GObject item)
    {
        fun_Guild_New.guild_list_cell view = item as fun_Guild_New.guild_list_cell;
        var value = GuildModel.Instance.guildList[index];
        view.data = value;
        view.txt_id.text =  "ID:" + value.guildId.ToString();
        view.txt_name.text = value.guildName;
        view.txt_lv.text = "Lv." + value.level;
        int maxNum = GuildModel.Instance.guildLvMap[(int)value.level].JumlahOrang;
        view.txt_num.text = value.memberCnt + "/" + maxNum;
        view.power_num.text = TextUtil.ChangeCoinShow1(value.fighting);

        var iconArr = value.flagId.Split("#");
        view.guild_icon.icon.url = "Guild/" + GuildModel.Instance.GetIconImgName(int.Parse(iconArr[0])) + ".png";
        view.guild_icon.bg.url = "Guild/" + GuildModel.Instance.GetIconImgName(int.Parse(iconArr[1])) + ".png";
        //view.txt_slogan.text = value.slogan;
        if (value.memberCnt >= maxNum)
        {
            StringUtil.SetBtnTab(view.btn_operate, Lang.GetValue("guild.guild_list_full"));
            view.btn_operate.enabled = false;
        }
        else
        {
            if (GuildModel.Instance.IsApplied(value.guildId))
            {
                StringUtil.SetBtnTab(view.btn_operate, Lang.GetValue("guild.guild_list_applied"));
                view.btn_operate.enabled = false;
            }
            else
            {
                StringUtil.SetBtnTab(view.btn_operate, Lang.GetValue("guild.guild_list_apply"));
                view.btn_operate.enabled = true;
            }
        }
        GuildModel.Instance.GetGuildListNext(index);
        view.btn_operate.data = value.guildId;
        view.btn_operate.onClick.Add(OperateClick);
    }

    private void OperateClick(EventContext context)
    {
        if (GuildModel.Instance.IsJoin())
        {
            uint guildId = (uint)(context.sender as GComponent).data;
            GuildController.Instance.ReqGuildApply((int)guildId);
        }
        else
        {
            UILogicUtils.ShowNotice(TimeUtil.GenerateTimeDesc1((int)GuildModel.Instance.cdTime) + Lang.GetValue("guild_8"));
        }
        
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

