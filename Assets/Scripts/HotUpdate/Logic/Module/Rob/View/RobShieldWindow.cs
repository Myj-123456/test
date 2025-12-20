
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using Elida.Config;

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
        //_view.txt_shieldOpen.text = Lang.GetValue("slang_43");//护盾开启
        var openStr = Lang.GetValue("UserInfoOn");//开启
        var closeStr = Lang.GetValue("slang_77");//关闭
        //(_view.btn_switch as fun_Rob.ToggleButton_1).txt_open.text = openStr;//开启
        //(_view.btn_switch as fun_Rob.ToggleButton_1).txt_close.text = closeStr;//关闭

        SetBg(_view.n26, "Common/common_big_tip_bg.png");
        _view.n27.url = "HandBookNew/rare_icon_3.png";
        _view.n28.url = "HandBookNew/name_bg_small_color_3.png";

        _view.list.itemRenderer = ItemRenderer;

        _view.close_btn.onClick.Add(CloseView);

        _view.btn_switch.onClick.Add(() =>
        {
            RobController.Instance.ReqRobSetshield((uint)(RobModel.Instance.info.openShield == 1 ? 0 : 1));
        });

        EventManager.Instance.AddEventListener(RobEvent.RobSetshield, UpdateSwitchStatus);
        EventManager.Instance.AddEventListener(RobEvent.RobBuy, UpdateShield);
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
            _view.pic.url= ImageDataModel.Instance.GetIconUrlByEntityId(RobModel.item_shield_id);
            _view.txt_desc.text = "激活空军符，可在玩家雇佣您时自动使用1张并免除雇佣";
            _view.n38.text = "空军符";
        }
        else
        {
            _view.lb_title.text = Lang.GetValue("rob_50");
            int len = RobModel.Instance.robOtherConfig.TokenNums.Length;
            _view.list.numItems = len;
            _view.pic.url= ImageDataModel.Instance.GetIconUrlByEntityId(RobModel.item_snatch_id);
            _view.txt_desc.text = "消耗一根钓鱼竿，可在锦鲤采集中雇佣一名玩家为你劳作";
            _view.n38.text = "钓鱼竿";
        }
        UpdateShield();
    }
    private void UpdateShield()
    {
        if (curPage == 0)
        {
            if (StorageModel.Instance.GetItemCount(RobModel.item_shield_id) == 0)
            {
                _view.lb_shield_count.text = "未拥有";
            }
            else
            {
                _view.lb_shield_count.text = "拥有：" + StorageModel.Instance.GetItemCount(RobModel.item_shield_id).ToString();
            }
        }
        else
        {
            if (StorageModel.Instance.GetItemCount(RobModel.item_snatch_id) == 0)
            {
                _view.lb_shield_count.text = "未拥有";
            }
            else
            {
                _view.lb_shield_count.text = "拥有：" + StorageModel.Instance.GetItemCount(RobModel.item_snatch_id).ToString();
            }
        }
    }
    private void ItemRenderer(int index, GObject item)
    {
        fun_Rob.shopCell cell = item as fun_Rob.shopCell;
        cell.btn_buy.data = index;
        cell.btn_buy2.data = index;

        // 设置三个列表项分别显示不同的status状态
        cell.status.selectedIndex = index % 3;
        if (curPage == 0)
        {
            var consts = RobModel.Instance.robOtherConfig.ShieldCosts[index];
            var shield = RobModel.Instance.robOtherConfig.ShieldNums[index];
            StringUtil.SetBtnUrl(cell.btn_buy, ImageDataModel.Instance.GetIconUrlByEntityId(consts.EntityID));
            StringUtil.SetBtnTab(cell.btn_buy, consts.Value.ToString());
            StringUtil.SetBtnUrl(cell.btn_buy1, ImageDataModel.Instance.GetIconUrlByEntityId(consts.EntityID));
            StringUtil.SetBtnTab(cell.btn_buy1, consts.Value.ToString());
            StringUtil.SetBtnUrl(cell.btn_buy2, ImageDataModel.Instance.GetIconUrlByEntityId(consts.EntityID));
            StringUtil.SetBtnTab(cell.btn_buy2, consts.Value.ToString());
            cell.img.url = ImageDataModel.Instance.GetIconUrlByEntityId(shield.EntityID);
            var shieldItem = ItemModel.Instance.GetItemByEntityID(shield.EntityID);
            cell.img_bg.url = ImageDataModel.Instance.GetItemQuality(shieldItem.Quality);
            cell.lb_count.text = shield.Value.ToString();

            if (cell.status.selectedIndex == 0)
            {
                cell.txt_name.text = "少量空军符";
                cell.txt_desc.text = "购买后获得5张空军符";
                cell.limitCtrl.selectedIndex = 1;
            }
            else if(cell.status.selectedIndex == 2)
            {
                if (!MyselfModel.Instance.IsVip())
                {
                    cell.txt_nameVip.text = "VIP专享";
                    cell.txt_vipdesc.text = "开通VIP后可以购买";
                }
                else
                {
                    cell.txt_nameVip.text = "VIP专享";
                    cell.txt_vipdesc.text = "购买后获得50张空军符";
                }
                cell.limitCtrl.selectedIndex = 1;
            }
            else
            {
                cell.txt_name.text = "大量空军符";
                cell.txt_desc.text = "购买后获得20张空军符";
            }
        }
        else
        {
            var consts = RobModel.Instance.robOtherConfig.TokenCosts[index];
            var shield = RobModel.Instance.robOtherConfig.TokenNums[index];
            StringUtil.SetBtnUrl(cell.btn_buy, ImageDataModel.Instance.GetIconUrlByEntityId(consts.EntityID));
            StringUtil.SetBtnTab(cell.btn_buy, consts.Value.ToString());
            StringUtil.SetBtnUrl(cell.btn_buy1, ImageDataModel.Instance.GetIconUrlByEntityId(consts.EntityID));
            StringUtil.SetBtnTab(cell.btn_buy1, consts.Value.ToString());
            StringUtil.SetBtnUrl(cell.btn_buy2, ImageDataModel.Instance.GetIconUrlByEntityId(consts.EntityID));
            StringUtil.SetBtnTab(cell.btn_buy2, consts.Value.ToString());
            cell.img.url = ImageDataModel.Instance.GetIconUrlByEntityId(shield.EntityID);
            var shieldItem = ItemModel.Instance.GetItemByEntityID(shield.EntityID);
            cell.img_bg.url = ImageDataModel.Instance.GetItemQuality(shieldItem.Quality);
            cell.lb_count.text = shield.Value.ToString();
            if (cell.status.selectedIndex == 0)
            {
                cell.txt_name.text = "少量钓鱼竿";
                cell.txt_desc.text = "购买后获得5根钓鱼竿";
            }
            else if(cell.status.selectedIndex == 2)
            {
                if (!MyselfModel.Instance.IsVip())
                {
                    cell.txt_nameVip.text = "VIP专享";
                    cell.txt_vipdesc.text = "开通VIP后可以购买";
                }
                else
                {
                    cell.txt_nameVip.text = "VIP专享";
                    cell.txt_vipdesc.text = "购买后获得50根钓鱼竿";
                }
            }
            else
            {
                cell.txt_name.text = "大量钓鱼竿";
                cell.txt_desc.text = "购买后获得20根钓鱼竿";
            }
        }
        cell.data = index;
        cell.btn_buy.onClick.Add(Buyhander);
        cell.btn_buy1.onClick.Add(Buyhander);
        cell.btn_buy2.onClick.Add(Buyhander);
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

