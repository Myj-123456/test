
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class RobShieldWindow : BaseWindow
{
    private fun_Rob.robShop _view;
    private int curPage = 0;

    public RobShieldWindow()
    {
        packageName = "fun_Rob";
        // 设置委托
        BindAllDelegate = fun_Rob.fun_RobBinder.BindAll;
        CreateInstanceDelegate = fun_Rob.robShop.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        _view = ui as fun_Rob.robShop;
        _view.txt_shieldOpen.text = Lang.GetValue("slang_43");//护盾开启
        var openStr = Lang.GetValue("UserInfoOn");//开启
        var closeStr = Lang.GetValue("slang_77");//关闭
        //(_view.btn_switch as fun_Rob.ToggleButton_1).txt_open.text = openStr;//开启
        //(_view.btn_switch as fun_Rob.ToggleButton_1).txt_close.text = closeStr;//关闭

        _view.list.itemRenderer = ItemRenderer;

        _view.close_btn.onClick.Add(CloseView);

        _view.btn_switch.onClick.Add(() =>
        {
            RobController.Instance.ReqRobSetshield((uint)(RobModel.Instance.info.openShield == 1 ? 0 : 1));
        });

        EventManager.Instance.AddEventListener(RobEvent.RobSetshield, UpdateSwitchStatus);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        curPage = (int)data;
        _view.page.selectedIndex = curPage;
        if (curPage == 0)
        {
            UpdateSwitchStatus();
            _view.lb_title.text = Lang.GetValue("rob_23");
            int len = RobModel.Instance.robOtherConfig.ShieldCosts.Length;
            _view.list.numItems = len;
        }
        else
        {
            _view.lb_title.text = Lang.GetValue("rob_50");
            int len = RobModel.Instance.robOtherConfig.TokenNums.Length;
            _view.list.numItems = len;
        }

    }

    private void ItemRenderer(int index, GObject item)
    {
        fun_Rob.shopCell cell = item as fun_Rob.shopCell;

        if (curPage == 0)
        {
            var consts = RobModel.Instance.robOtherConfig.ShieldCosts[index];
            var shield = RobModel.Instance.robOtherConfig.ShieldNums[index];
            StringUtil.SetBtnUrl(cell.btn_buy, ImageDataModel.Instance.GetIconUrlByEntityId(consts.EntityID));
            StringUtil.SetBtnTab(cell.btn_buy, consts.Value.ToString());
            cell.img_shield.url = ImageDataModel.Instance.GetIconUrlByEntityId(shield.EntityID);
            cell.lb_count.text = shield.Value.ToString();
        }
        else
        {
            var consts = RobModel.Instance.robOtherConfig.TokenCosts[index];
            var shield = RobModel.Instance.robOtherConfig.TokenNums[index];
            StringUtil.SetBtnUrl(cell.btn_buy, ImageDataModel.Instance.GetIconUrlByEntityId(consts.EntityID));
            StringUtil.SetBtnTab(cell.btn_buy, consts.Value.ToString());
            cell.img_shield.url = ImageDataModel.Instance.GetIconUrlByEntityId(shield.EntityID);
            cell.lb_count.text = shield.Value.ToString();
        }
        cell.data = index;
        cell.btn_buy.onClick.Add(Buyhander);
        cell.isLastStatus.selectedIndex = (index == _view.list.numItems - 1) ? 0 : 1;
    }

    private void Buyhander(EventContext context)
    {
        int index = (int)(context.sender as GComponent).parent.data;
        int costValue = 0;
        if (curPage == 0)
        {
            var consts = RobModel.Instance.robOtherConfig.ShieldCosts[index];
            var shield = RobModel.Instance.robOtherConfig.ShieldNums[index];
            costValue = consts.Value;
        }
        else
        {
            var consts = RobModel.Instance.robOtherConfig.TokenCosts[index];
            var shield = RobModel.Instance.robOtherConfig.TokenNums[index];
            costValue = consts.Value;
        }
        if (MyselfModel.Instance.diamond < costValue)
        {
            UILogicUtils.ShowNotice(Lang.GetValue("common_hint_txt3"));
            return;
        }
        RobController.Instance.ReqRobBuy((uint)(curPage + 1), (uint)index);
    }

    private void UpdateSwitchStatus()
    {
        (_view.btn_switch as fun_Rob.ToggleButton_1).select.selectedIndex = (int)RobModel.Instance.info.openShield == 0 ? 1 : 0;
    }

    private void CloseView()
    {
        UIManager.Instance.CloseWindow(UIName.RobShieldWindow);
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

