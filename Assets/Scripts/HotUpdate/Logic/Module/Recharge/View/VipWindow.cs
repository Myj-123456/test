using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VipWindow : BaseWindow
{
    private CountDownTimer timer;
    private fun_Recharge.vip_buy_view view;
    public VipWindow()
    {
        packageName = "fun_Recharge";
        // ÉèÖÃÎ¯ÍÐ
        BindAllDelegate = fun_Recharge.fun_RechargeBinder.BindAll;
        CreateInstanceDelegate = fun_Recharge.vip_buy_view.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        view = ui as fun_Recharge.vip_buy_view;
        view.buy_btn.onClick.Add(() =>
        {
            //var vipData = RechargeModel.Instance.vipValueList.Find(ele => ele.Type_c == (int)E_DIAMOND_VALUE_TYPE.VIP);
            //RechargeController.Instance.ReqPlaceOrder(2, (uint)vipData.IndexId);
        });
        EventManager.Instance.AddEventListener(RechargeEvent.VipPay, OnShown);
    }

    public override void OnShown()
    {
        base.OnShown();
        if(timer != null)
        {
            timer.Clear();
            timer = null;
        }
        view.vipTime.text = "";
        if (MyselfModel.Instance.vipTime > ServerTime.Time)
        {
            var leftTime = MyselfModel.Instance.vipTime - ServerTime.Time;
            timer = new CountDownTimer(view.vipTime, (int)leftTime, true);
            timer.CompleteCallBacker = () =>
            {
                view.vipTime.text = "";
            };
        }
    }
}
