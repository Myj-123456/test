using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomerLikeWindow : BaseWindow
{
   private fun_Customer.like_level_view view;

   public CustomerLikeWindow()
    {
        packageName = "fun_Customer";
        // 设置委托
        BindAllDelegate = fun_Customer.fun_CustomerBinder.BindAll;
        CreateInstanceDelegate = fun_Customer.like_level_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Customer.like_level_view;
        SetBg(view.bg, "Common/ELIDA_common_littledi01.png");
        view.curAddLab.text = Lang.GetValue("customer_7");
        view.nextAddLab.text = Lang.GetValue("customer_8");
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        view.curProLab.text = CustomerModel.Instance.totalLevel.ToString();
        view.nextPro.value = 0;
        var curInfo = CustomerModel.Instance.GetNpcBuffInfo((int)CustomerModel.Instance.totalLevel);
        var nextInfo = CustomerModel.Instance.GetNpcBuffInfo((int)CustomerModel.Instance.totalLevel + 1);
        if (CustomerModel.Instance.totalLevel == 0)
        {
            view.curAdd.text = Lang.GetValue("customer_9", "0%") + "<br>" + Lang.GetValue("customer_10", "0%");
        }
        else
        {
            var buff1 = (float)curInfo.BuffParams[0] / 10f;
            var buff2 = (float)curInfo.BuffParams[1] / 10f;
            view.curAdd.text = Lang.GetValue("customer_9", buff1 + "%") + "<br>" + Lang.GetValue("customer_10", buff2 + "0%");
        }
        
        if(nextInfo != null)
        {
            view.curPro.max = nextInfo.Exp;
            view.curPro.value = CustomerModel.Instance.totalExp;
            view.max.selectedIndex = 0;
            var buff1 = (float)nextInfo.BuffParams[0] / 10f;
            var buff2 = (float)nextInfo.BuffParams[1] / 10f;
            view.nextAdd.text = Lang.GetValue("customer_9", buff1 + "%") + "<br>" + Lang.GetValue("customer_10", buff2 + "%");
            view.nextProLab.text = ((int)CustomerModel.Instance.totalLevel + 1).ToString();
        }
        else
        {
            view.curPro.max = 1;
            view.curPro.value = 1;
            view.max.selectedIndex = 1;
        }
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

