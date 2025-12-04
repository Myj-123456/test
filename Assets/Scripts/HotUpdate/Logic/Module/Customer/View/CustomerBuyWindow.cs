using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class CustomerBuyWindow : BaseWindow
{
   private fun_Customer.customer_add_view view;
    private float max;
    private int type;
    private int curNum;
   public CustomerBuyWindow()
    {
        packageName = "fun_Customer";
        // 设置委托
        BindAllDelegate = fun_Customer.fun_CustomerBinder.BindAll;
        CreateInstanceDelegate = fun_Customer.customer_add_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Customer.customer_add_view;
        SetBg(view.bg, "Common/ELIDA_common_littledi01.png");
        view.tipLab.text = Lang.GetValue("customer_6");
        view.pic.url = ImageDataModel.CASH_ICON_URL;
        StringUtil.SetBtnTab(view.minBtn, Lang.GetValue("FriendsDeal_15"));
        StringUtil.SetBtnTab(view.maxBtn, Lang.GetValue("FriendsDeal_16"));
        StringUtil.SetBtnTab(view.quitBtn, Lang.GetValue("StarPremise_button6"));
        StringUtil.SetBtnTab(view.sureBtn, Lang.GetValue("levelup_button"));

        view.inputLab.onFocusOut.Add(() =>
        {
            var num = int.Parse(view.inputLab.text);
            if(num > max)
            {
                num = (int)max;
            }
            view.showLab.text = num.ToString();
            view.inputLab.text = "";
            UpdateCost();
        });
        view.quitBtn.onClick.Add(() =>
        {
            Close();
        });
        view.addBtn.onClick.Add(() =>
        {
            var num = uint.Parse(view.showLab.text);
            if (num < max)
            {
                num++;
                view.showLab.text = num.ToString();
                UpdateCost();
            }
        });
        view.oddBtn.onClick.Add(() =>
        {
            var num = uint.Parse(view.showLab.text);
            if (num > 1)
            {
                num--;
                view.showLab.text = num.ToString();
                UpdateCost();
            }
        });

        view.minBtn.onClick.Add(() =>
        {
            var num = uint.Parse(view.showLab.text);
            if (num != 1)
            {
                num = 1;
                view.showLab.text = num.ToString();
                UpdateCost();
            }
        });
        view.maxBtn.onClick.Add(() =>
        {
            var num = uint.Parse(view.showLab.text);
            if (num != max)
            {
                num = (uint)max;
                view.showLab.text = num.ToString();
                UpdateCost();
            }
        });

        view.sureBtn.onClick.Add(() =>
        {
            if(max > 0)
            {
                var buyNum = type == 0 ? CustomerModel.Instance.buyGiftCnt : CustomerModel.Instance.buyIkebanaCnt;
                var times = type == 0 ? CustomerModel.Instance.surplusGiveGiftCnt : CustomerModel.Instance.surplusGiveIkebanaCnt;
                if(times <= 0 || buyNum > 0)
                {
                    var num = uint.Parse(view.showLab.text);
                    CustomerController.Instance.ReqNpcBuyTimes((uint)(type + 1), num);
                    Close();
                }
                else
                {
                    UILogicUtils.ShowNotice("无免费次数可购买！");
                }
                
            }
            
        });
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        type = (int)data;
        max = Mathf.Floor((float)MyselfModel.Instance.diamond / GlobalModel.Instance.module_profileConfig.buyLimitCost);
        view.showLab.text = "1";
        view.inputLab.text = "";
        UpdateCost();
    }

    private void UpdateCost()
    {
        var num = int.Parse(view.showLab.text) * GlobalModel.Instance.module_profileConfig.buyLimitCost;
        view.numLab.text = num.ToString();
    }
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

