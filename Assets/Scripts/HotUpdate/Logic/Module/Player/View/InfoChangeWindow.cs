using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class InfoChangeWindow : BaseWindow
{
   private fun_MyInfo.info_change_view view;
    private int tabType;
    private HeadView headView;
    private FrameView frameView;
    private TitleView titleView;
   public InfoChangeWindow()
    {
        packageName = "fun_MyInfo";
        // 设置委托
        BindAllDelegate = fun_MyInfo.fun_MyInfoBinder.BindAll;
        CreateInstanceDelegate = fun_MyInfo.info_change_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_MyInfo.info_change_view;
        SetBg(view.bg, "Common/ELIDA_common_bigdi01.png");
        StringUtil.SetBtnTab(view.head_btn, Lang.GetValue("Headframe_tab1"));
        StringUtil.SetBtnTab(view.head_frame_btn, Lang.GetValue("Headframe_tab2"));
        StringUtil.SetBtnTab(view.title_btn, Lang.GetValue("player_info_18"));

        headView = new HeadView(view.head_view);
        frameView = new FrameView(view.frame_view);
        titleView = new TitleView(view.title_view);
        view.head_btn.onClick.Add(() =>{
            if (tabType != 0)
            {
                ChangeTab(0);
            }
        });

        view.head_frame_btn.onClick.Add(() => {
            if (tabType != 1)
            {
                ChangeTab(1);
            }
        });

        view.title_btn.onClick.Add(() => {
            if (tabType != 2)
            {
                ChangeTab(2);
            }
        });
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        int type = (int)data;
        view.tab.selectedIndex = type;
        ChangeTab(type);
    }
    private void ChangeTab(int type)
    {
        tabType = type;
        if(tabType == 0)
        {
            headView.OnShown();
        }
        else if(tabType == 1)
        {
            frameView.OnShown();
        }
        else
        {
            titleView.OnShown();
        }
    }
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

