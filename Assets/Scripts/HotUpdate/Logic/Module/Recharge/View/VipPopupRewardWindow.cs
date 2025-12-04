
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class VipPopupRewardWindow : BaseWindow
{
   private fun_Recharge.vip_everyDay_reward view;

   public VipPopupRewardWindow()
    {
        packageName = "fun_Recharge";
        // 设置委托
        BindAllDelegate = fun_Recharge.fun_RechargeBinder.BindAll;
        CreateInstanceDelegate = fun_Recharge.vip_everyDay_reward.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Recharge.vip_everyDay_reward;
        view.get_btn.onClick.Add(() =>
        {
            RechargeController.Instance.ReqMonthCard();
            Close();
        });
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        var target = GlobalModel.Instance.module_profileConfig.everyVipReward.Values.ToList();
        view.icon.url = ImageDataModel.CASH_ICON_URL;
        view.count.text = target[0].ToString();
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

