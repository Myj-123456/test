
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class TradeSetPasswordWindow : BaseWindow
{
    private fun_FriendsTrade_New.tradeSetPassword _view;

    public TradeSetPasswordWindow()
    {
        packageName = "fun_FriendsTrade_New";
        // 设置委托
        BindAllDelegate = fun_FriendsTrade_New.fun_FriendsTrade_NewBinder.BindAll;
        CreateInstanceDelegate = fun_FriendsTrade_New.tradeSetPassword.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        _view = ui as fun_FriendsTrade_New.tradeSetPassword;
        _view.lb_title.text = Lang.GetValue("friendTrade_set_password");
        SetBg(_view.bg, "Common/ELIDA_common_littledi01.png");
        StringUtil.SetBtnTab(_view.btn_sure, Lang.GetValue("setting_txt1"));
        StringUtil.SetBtnTab(_view.btn_cancel, Lang.GetValue("gui_btn_cancel"));
        _view.costLab.text = Lang.GetValue("friendTrade_cost");
        _view.tipLab.text = Lang.GetValue("friendTrade_password_tip");
        _view.password_input.maxLength = 6;
        _view.password_input.restrict = "[0-9]*";
        _view.btn_sure.onClick.Add(() =>
        {
            if (MyselfModel.Instance.diamond < GetCostNum())
            {
                UILogicUtils.ShowNotice(Lang.GetValue("common_hint_txt3"));
                return;
            }
            string password = _view.password_input.text;
            if (!StringUtil.VerifyPassword(password))
            {
                UILogicUtils.ShowNotice(Lang.GetValue("FriendsDeal_103"));
                return;
            }
            uint[] param = data as uint[];
            TradeController.Instance.ReqTradeUpperShelf(param[0], param[1], param[2], param[3], password);
            UIManager.Instance.CloseWindow(UIName.TradeSetPasswordWindow);
            UIManager.Instance.CloseWindow(UIName.TradeSaleWindow);
        });
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑

        _view.cost.text = "x" + GetCostNum();
        _view.password_input.text = "";
    }

    private int GetCostNum()
    {
        var costs = GlobalModel.Instance.module_profileConfig.passwordCost;
        int times = (int)MyselfModel.Instance.behaviorDaily.tradePasswordCnt;
        return (costs.Count - 1) < times ? costs[costs.Count - 1] : costs[times];
    }
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

