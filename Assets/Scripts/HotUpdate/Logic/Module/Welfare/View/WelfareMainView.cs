using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class WelfareMainView : BaseWindow
{
   private fun_Welfare.welfare_main_view view;
    private int tabType;
    private List<int> pageData;
    private SignView signView;
    private GrowthView growthView;
    private TurnView turnView;
    private SevenView sevenView;
    private VideoDoubleView videoDoubleView;
   public WelfareMainView()
    {
        packageName = "fun_Welfare";
        // 设置委托
        BindAllDelegate = fun_Welfare.fun_WelfareBinder.BindAll;
        CreateInstanceDelegate = fun_Welfare.welfare_main_view.CreateInstance;
        fairyBatching = false;
        FullScreen = true;
        openWithTween = false;
        IsShowOrHideMainUI = true;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Welfare.welfare_main_view;
        SetBg(view.sign_view.bg, "Welfare/ELIDA_meiriqiandao_bg.png");
        SetBg(view.turntable_view.bg, "Welfare/ELIDA_jxbk_bg.png");
        SetBg(view.growth_view.bg, "Welfare/ELIDA_xsczzl_bg01.png");
        SetBg(view.growth_view.bg1, "Welfare/ELIDA_xsczzl_bg_hua.png");
        SetBg(view.growth_view.bg2, "Welfare/ELIDA_xsczzl_bg03.png");
        SetBg(view.seven_view.bg, "Welfare/ELIDA_qrdl_qpbg.png");
        SetBg(view.video_view.bg, "Welfare/ELIDA_meiriqiandao_bg.png");
        pageData = new List<int>();
        signView = new SignView(view.sign_view);
        growthView = new GrowthView(view.growth_view);
        turnView = new TurnView(view.turntable_view);
        sevenView = new SevenView(view.seven_view);
        videoDoubleView = new VideoDoubleView(view.video_view);
        view.list.itemRenderer = RenderList;

        EventManager.Instance.AddEventListener(WelfareEvent.DailyLoginAward, UpdateTabList);
        EventManager.Instance.AddEventListener(PlayerEvent.GameCrossDay, UpdateTabList);
        EventManager.Instance.AddEventListener<uint>(RedPointEvent.RedDotChange, UpdateRedPoint);
        EventManager.Instance.AddEventListener(WelfareEvent.TurnTable, UpdateTabList);
        EventManager.Instance.AddEventListener(WelfareEvent.DailySign, UpdateTabList);
        EventManager.Instance.AddEventListener(TaskEvent.TaskProAreward, UpdateTabList);
        EventManager.Instance.AddEventListener(WelfareEvent.DailyRetroactive, UpdateTabList);
    }
    private void UpdateRedPoint(uint type)
    {
        if(type == (uint)RedPointType.Growth_Road)
        {
            UpdateTabList();
        }
    }
    public override void OnShown()
    {
        base.OnShown();
        var type = (int)data;
        InitPageData(type);
        UpdateTabList();
        // 其他打开面板的逻辑
    }

    private void ChangeTab(int type)
    {
        tabType = type;
        if(tabType == 0)
        {
            sevenView.OnShown();
        }
        else if(tabType == 1)
        {
            growthView.OnShown();
        }
        else if (tabType == 2)
        {
            turnView.OnShown();
        }
        else if (tabType == 3)
        {
            videoDoubleView.OnShown();
        }
        else
        {
            signView.OnShown();
        }
    }

    private void InitPageData(int type)
    {
        pageData = new List<int>();
        for (var i = 0;i < 5; i++)
        {
            if (i == 0 && (!GlobalModel.Instance.GetUnlocked(SysId.SeventhSign) || WelfareModel.Instance.status == 2))
            {
                continue;
            }
            if(i == 1 && (!GlobalModel.Instance.GetUnlocked(SysId.ChamberOfCommerce) || WelfareModel.Instance.IsGrowthGetted()))
            {
                continue;
            }
            if (i == 2 && !GlobalModel.Instance.GetUnlocked(SysId.TurnTable))
            {
                continue;
            }
            if (i == 3 && !GlobalModel.Instance.GetUnlocked(SysId.VideoDouble))
            {
                continue;
            }

            if (i == 4 && (!GlobalModel.Instance.GetUnlocked(SysId.Newspaper)))
            {
                continue;
            }

            pageData.Add(i);
        }
        view.list.numItems = pageData.Count;
        int index = pageData.IndexOf(type);
        if(index == -1)
        {
            index = 0;
        }
        view.list.selectedIndex = index;
        view.tab.selectedIndex = pageData[index];
        ChangeTab(pageData[index]);
    }
    public void UpdateTabList()
    {
        view.list.numItems = pageData.Count;
    }
    private void RenderList(int index,GObject item)
    {
        var cell = item as common_New.common_page2;

        var info = pageData[index];
        var str = Lang.GetValue("welfare_main_" + (info + 1));
        if(str.Length < 3)
        {
            StringUtil.SetBtnTab5(cell, str);
            cell.type.selectedIndex = 1;
        }
        else
        {
            StringUtil.SetBtnTab4(cell, str);
            cell.type.selectedIndex = 0;
        }
        if(info == 0)
        {
            if (WelfareModel.Instance.GetSevenRed())
            {
                UILogicUtils.ShowRedPoint(cell);
            }
            else
            {
                UILogicUtils.HideRedPoint(cell);
            }
        }else if(info == 1)
        {
            if (RedPointModel.Instance.IsRedPointShow(RedPointType.Growth_Road))
            {
                UILogicUtils.ShowRedPoint(cell);
            }
            else
            {
                UILogicUtils.HideRedPoint(cell);
            }
        }
        else if (info == 2)
        {
            if (WelfareModel.Instance.GetTurnRed())
            {
                UILogicUtils.ShowRedPoint(cell);
            }
            else
            {
                UILogicUtils.HideRedPoint(cell);
            }
        }
        else if (info == 3)
        {

        }
        else if (info == 4)
        {
            if (WelfareModel.Instance.GetSignRed())
            {
                UILogicUtils.ShowRedPoint(cell);
            }
            else
            {
                UILogicUtils.HideRedPoint(cell);
            }
        }
        cell.data = info;
        cell.onClick.Add(TabClick);
    }
    private void TabClick(EventContext context)
    {
        var type = (int)(context.sender as GComponent).data;
        if(tabType != type)
        {
            view.tab.selectedIndex = type;
            ChangeTab(type);
        }
    }
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
        signView.OnHide();
    }
}

