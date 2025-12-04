using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WelfareMainView : BaseView
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
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Welfare.welfare_main_view;
        SetBg(view.sign_view.bg, "Welfare/ELIDA_meiriqiandao_bg.png");
        SetBg(view.turntable_view.bg, "Welfare/ELIDA_meiriqiandao_bg.png");
        SetBg(view.growth_view.bg, "Welfare/ELIDA_xsczzl_bg01.png");
        SetBg(view.growth_view.bg1, "Welfare/ELIDA_xsczzl_bg_hua.png");
        SetBg(view.growth_view.bg2, "Welfare/ELIDA_xsczzl_bg03.png");
        SetBg(view.seven_view.bg, "Welfare/ELIDA_meiriqiandao_bg.png");
        SetBg(view.video_view.bg, "Welfare/ELIDA_meiriqiandao_bg.png");
        pageData = new List<int>();
        signView = new SignView(view.sign_view);
        growthView = new GrowthView(view.growth_view);
        turnView = new TurnView(view.turntable_view);
        sevenView = new SevenView(view.seven_view);
        videoDoubleView = new VideoDoubleView(view.video_view);
        view.page_list.itemRenderer = RenderList;
    }

    public override void OnShown()
    {
        base.OnShown();
        var type = (int)data;
        InitPageData(type);
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
            if(i == 1 && !GlobalModel.Instance.GetUnlocked(SysId.ChamberOfCommerce))
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
            if (i == 4 && (!GlobalModel.Instance.GetUnlocked(SysId.Newspaper) || WelfareModel.Instance.IsGrowthGetted()))
            {
                continue;
            }

            pageData.Add(i);
        }
        view.page_list.numItems = pageData.Count;
        int index = pageData.IndexOf(type);
        if(index == -1)
        {
            index = 0;
        }
        view.page_list.selectedIndex = index;
        view.tab.selectedIndex = pageData[index];
        ChangeTab(pageData[index]);
    }
    private void RenderList(int index,GObject item)
    {
        var cell = item as fun_Welfare.page_btn;
        var info = pageData[index];
        cell.titleLab.text = Lang.GetValue("welfare_main_" + (info + 1));
        cell.status.selectedIndex = info;
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

