
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ADK;

public class CreateGuildWindow : BaseWindow
{
   private fun_Guild_New.guild_input view;

    private IconData curIconData;

   public CreateGuildWindow()
    {
        packageName = "fun_Guild_New";
        // 设置委托
        BindAllDelegate = fun_Guild_New.fun_Guild_NewBinder.BindAll;
        CreateInstanceDelegate = fun_Guild_New.guild_input.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Guild_New.guild_input;
        SetBg(view.bg, "Guild/ELIDA_huameng_cjhm.png");
        StringUtil.SetBtnTab(view.btn_sure, Lang.GetValue("levelup_button"));
        view.txt_input.maxLength = 7;
        view.title.text = Lang.GetValue("create_guild_2");//请输入社团名称，最多{0}个字符

        view.tip.text = Lang.GetValue("create_guild_1");

        var item = ItemModel.Instance.GetItemByEntityID(GuildModel.Instance.othersConfig.PersekutuanBuats[0].EntityID);
        view.cost_img.url = ImageDataModel.Instance.GetIconUrl(item);
        
        
        curIconData = new IconData();
        view.btn_add.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<GuildChoseIconWindow>(UIName.GuildChoseIconWindow, curIconData);
        });

        view.btn_change.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<GuildChoseIconWindow>(UIName.GuildChoseIconWindow, curIconData);
        });

        view.btn_sure.onClick.Add(() =>
        {
            if (view.txt_input.text.Trim() == "")
            {
                UILogicUtils.ShowNotice(Lang.GetValue("guild.name_can_not_empty"));
                return;
            }
            //if(data != null)
            //{
            //    uint pos = (uint)data;
            //    GuildController.Instance.ReqGuildPositionName(pos, view.txt_input.text);
            //    return;
            //}
            var guildName = view.txt_input.text.Trim();
            

            var item = ItemModel.Instance.GetItemByEntityID(GuildModel.Instance.othersConfig.PersekutuanBuats[0].EntityID);
            string str = GuildModel.Instance.othersConfig.PersekutuanBuats[0].Value + Lang.GetValue(item.Name);
            if (MyselfModel.Instance.gold < GuildModel.Instance.othersConfig.PersekutuanBuats[0].Value)
            {
                UILogicUtils.ShowNotice(Lang.GetValue("guild.needCost", str));
                return;
            }
            
            GuildController.Instance.ReqGuildFound(guildName,curIconData.IconId + "#" + curIconData.BgId);
        });
        EventManager.Instance.AddEventListener(GuildEvent.GuildFound, UpdateData);
        EventManager.Instance.AddEventListener(GuildEvent.GuildPositionName, CloseView);
        EventManager.Instance.AddEventListener<IconData>(GuildEvent.ChoseIcon, ShowIcon);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        view.txt_input.text = "";
        view.type.selectedIndex = 0;
        var num = GuildModel.Instance.othersConfig.PersekutuanBuats[0].Value;
        view.cost_num.text = num + "/" + TextUtil.ChangeCoinShow(MyselfModel.Instance.gold);
    }

    private void ShowIcon(IconData iconData)
    {
        view.type.selectedIndex = 1;
        curIconData = iconData;
        view.guild_icon.bg.url = "Guild/" + GuildModel.Instance.GetIconImgName(curIconData.BgId)+ ".png"; ;
        view.guild_icon.icon.url = "Guild/" + GuildModel.Instance.GetIconImgName(curIconData.IconId) + ".png";
    }

    private void UpdateData()
    {
        UIManager.Instance.CloseWindow(UIName.CreateGuildWindow);
        UIManager.Instance.CloseWindow(UIName.GuildJoinWindow);
    }
    private void CloseView()
    {
        UIManager.Instance.CloseWindow(UIName.CreateGuildWindow);
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

