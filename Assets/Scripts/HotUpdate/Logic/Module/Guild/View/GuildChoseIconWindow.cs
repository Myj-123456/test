
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using Elida.Config;

public class GuildChoseIconWindow : BaseWindow
{
   private fun_Guild_New.guild_edit_icon view;

    private IconData curIconData;

    private List<Ft_club_iconConfig> iconData;

    private List<Ft_club_iconConfig> bgData;

    private int maxPage;
    private int curPage;

    private int bgCount;

   public GuildChoseIconWindow()
    {
        packageName = "fun_Guild_New";
        // 设置委托
        BindAllDelegate = fun_Guild_New.fun_Guild_NewBinder.BindAll;
        CreateInstanceDelegate = fun_Guild_New.guild_edit_icon.CreateInstance;

        
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Guild_New.guild_edit_icon;
        SetBg(view.bg, "Common/ELIDA_common_bigdi01.png");
        view.icon_list.itemRenderer = RenderIconList;
        StringUtil.SetBtnTab(view.btn_sure, Lang.GetValue("levelup_button"));
        view.bg_list.itemRenderer = RenderBgList;
        view.bg_list.SetVirtual();
        curPage = 1;
        view.btn_sure.onClick.Add(() =>
        {
            if (curIconData.BgId == 0 || curIconData.IconId == 0)
            {
                UILogicUtils.ShowNotice("请选择图标");
                return;
            }
            EventManager.Instance.DispatchEvent(GuildEvent.ChoseIcon, curIconData);
            Close();
        });
        view.btn_left.onClick.Add(() =>
        {
            if(curPage > 1)
            {
                curPage--;
                view.bg_list.scrollPane.SetCurrentPageX(view.bg_list.scrollPane.currentPageX - 1, true);
            }
            LeftRightBtn();
        });

        view.btn_right.onClick.Add(() =>
        {
            if (curPage < maxPage)
            {
                curPage++;
                view.bg_list.scrollPane.SetCurrentPageX(view.bg_list.scrollPane.currentPageX + 1, true);
            }
            LeftRightBtn();
        });
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        curIconData = data as IconData;

        iconData = GuildModel.Instance.GetIconList(2);

        bgData = GuildModel.Instance.GetIconList(1);

        view.icon_list.numItems = iconData.Count;
        int select = 0;
        if(curIconData.IconId <= 0)
        {
            curIconData.BgId = bgData[0].Id;
            curIconData.IconId = iconData[0].Id;
        }
        else
        {
            for(int i = 0,len = iconData.Count;i < len;i++)
            {
                if(iconData[i].Id == curIconData.IconId)
                {
                    select = i;
                    break;
                }
            }
        }
        
        view.icon_list.selectedIndex = select;
        
        bgCount = bgData.Count;
        view.bg_list.numItems = bgCount;
        maxPage = (int)Mathf.Ceil((float)bgCount / 8);
        LeftRightBtn();
        ShowIcon();
    }

    private void LeftRightBtn()
    {
        view.btn_left.enabled = curPage > 1;
        view.btn_right.enabled = curPage < maxPage;
    }

    private void ShowIcon()
    {
        if (curIconData.BgId != 0)
        {
            view.guild_icon.bg.url = "Guild/" + GuildModel.Instance.GetIconImgName(curIconData.BgId) +".png";
        }
        else
        {
            view.guild_icon.bg.url = "";
        }

        if (curIconData.IconId != 0)
        {
            view.guild_icon.icon.url = "Guild/" + GuildModel.Instance.GetIconImgName(curIconData.IconId) + ".png";
        }
        else
        {
         view.guild_icon.icon.url = "";
        }
    }

    private void RenderIconList(int index,GObject item)
    {
        var cell = item as fun_Guild_New.btn_icon_tab;

        var iconInfo = iconData[index];

        cell.icon.url = "Guild/" + GuildModel.Instance.GetIconImgName(iconInfo.Id) + ".png";
        cell.titleLab.text = Lang.GetValue("create_guild_3");
        cell.icon.data = iconInfo.Id;
        cell.icon.onClick.Add(SelectIcon);
    }

    private void SelectIcon(EventContext context)
    {
        var id = (int)(context.sender as GObject).data;
        curIconData.IconId = id;
        ShowIcon();
    }

    private void RenderBgList(int index, GObject item)
    {
        var cell = item as fun_Guild_New.btn_bg;

        var bgInfo = bgData[index];

        cell.icon.url = "Guild/" + GuildModel.Instance.GetIconImgName(bgInfo.Id) + ".png";
        cell.data = bgInfo.Id;
        cell.onClick.Add(SelectBg);
    }

    private void SelectBg(EventContext context)
    {
        var id = (int)(context.sender as GComponent).data;
        curIconData.BgId = id;
        ShowIcon();
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

