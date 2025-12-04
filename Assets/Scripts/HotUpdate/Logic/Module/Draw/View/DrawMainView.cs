using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class DrawMainView : BaseView
{
   private fun_Draw.draw_main_view view;
    private int tabType;
    private List<int> inits;
    private MonthDrawView monthDraw;
   public DrawMainView()
    {
        packageName = "fun_Draw";
        // 设置委托
        BindAllDelegate = fun_Draw.fun_DrawBinder.BindAll;
        CreateInstanceDelegate = fun_Draw.draw_main_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Draw.draw_main_view;
        SetBg(view.flower_draw.bg, "Draw/ELIDA_chouka_yuechouka_bg01.png");
        monthDraw = new MonthDrawView(view.flower_draw);
        inits = new List<int>() { 0,0,0};

    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        int tab = (int)data;
        view.tab.selectedIndex = tab;
        ChangeTab(tab);
        UpdateBtnStatus();
    }

    private void ChangeTab(int type)
    {
        tabType = type;
        if(tabType == 0)
        {
            if(inits[tabType] == 0)
            {
                var activityId = DrawModel.Instance.GetActivityId(ActivityType.Month_Draw);
                DrawController.Instance.ReqDrawInfo((uint)activityId);
            }
            else
            {
                monthDraw.OnShown();
            }
        }else if(tabType == 1)
        {
            if (inits[tabType] == 0)
            {
                var activityId = DrawModel.Instance.GetActivityId(ActivityType.Diamond_Draw);
                DrawController.Instance.ReqDrawInfo((uint)activityId);
            }
            else
            {
                monthDraw.OnShown();
            }
        }
        else
        {
            if (inits[tabType] == 0)
            {
                var activityId = DrawModel.Instance.GetActivityId(ActivityType.Dress_Draw);
                DrawController.Instance.ReqDrawInfo((uint)activityId);
            }
            else
            {
                monthDraw.OnShown();
            }
        }
    }
    private void UpdateBtnStatus()
    {
        if(DrawModel.Instance.IsActivityOpen(ActivityType.Month_Draw) && GlobalModel.Instance.GetUnlocked(SysId.MonthDraw))
        {
            view.list._children[0].visible = true;
            var activityId = DrawModel.Instance.GetActivityId(ActivityType.Month_Draw);
            var activityInfo = DrawModel.Instance.GetGameEventInfo(activityId);
            (view.list._children[0] as fun_Draw.page_btn).titleLab.text = Lang.GetValue(activityInfo.Name);
        }
        else
        {
            view.list._children[0].visible = false;
        }
        if (DrawModel.Instance.IsActivityOpen(ActivityType.Diamond_Draw) && GlobalModel.Instance.GetUnlocked(SysId.DiamondDraw))
        {
            view.list._children[1].visible = true;
            var activityId = DrawModel.Instance.GetActivityId(ActivityType.Diamond_Draw);
            var activityInfo = DrawModel.Instance.GetGameEventInfo(activityId);
            (view.list._children[1] as fun_Draw.page_btn).titleLab.text = Lang.GetValue(activityInfo.Name);
        }
        else
        {
            view.list._children[1].visible = false;
        }
        if (DrawModel.Instance.IsActivityOpen(ActivityType.Dress_Draw) && GlobalModel.Instance.GetUnlocked(SysId.DressDraw))
        {
            view.list._children[2].visible = true;
            var activityId = DrawModel.Instance.GetActivityId(ActivityType.Dress_Draw);
            var activityInfo = DrawModel.Instance.GetGameEventInfo(activityId);
            (view.list._children[2] as fun_Draw.page_btn).titleLab.text = Lang.GetValue(activityInfo.Name);
        }
        else
        {
            view.list._children[2].visible = false;
        }
    }
    
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
        monthDraw.OnHide();
    }
}

