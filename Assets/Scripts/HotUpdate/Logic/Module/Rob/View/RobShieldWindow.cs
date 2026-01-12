
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
    private int type = 1;
    private List<Ft_rob_buyConfig> listData;

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

        SetBg(_view.bg, "Common/common_big_tip_bg.png");
        _view.bg_small.url = "HandBookNew/rare_icon_3.png";
        _view.bg_rare.url = "HandBookNew/name_bg_small_color_3.png";

        _view.n34.text = Lang.GetValue("recharge_main_29"); //获取途径

        _view.list.itemRenderer = ItemRenderer;

        _view.btn_switch.n24.text= Lang.GetValue("jinli_02"); //开启空军符
        _view.btn_switch.onClick.Add(() =>
        {
            RobController.Instance.ReqRobSetshield((uint)(RobModel.Instance.info.openShield == 1 ? 0 : 1));
        });

        EventManager.Instance.AddEventListener(RobEvent.RobSetshield, UpdateSwitchStatus);
        EventManager.Instance.AddEventListener(RobEvent.RobShopBuy, UpdateData);
        EventManager.Instance.AddEventListener(RechargeEvent.RechargeInfo, UpdateData);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        type = (int)data;
        _view.page.selectedIndex = type - 1;
        listData = RobModel.Instance.GetRobShopList(type);
        UpdateData();
        
    }
    private void UpdateList()
    {
        _view.list.numItems = listData.Count;
    }
    private void ItemRenderer(int index, GObject item)
    {
        fun_Rob.shopCell cell = item as fun_Rob.shopCell;
        var info = listData[index];
        cell.isVip.selectedIndex = info.IsVip;
        cell.limit.selectedIndex = info.LimitConfigs[0] > 0 ? 1 : 0;
        cell.discoubt.selectedIndex = info.OriginalPrice == 0 ? 0 : 1;

        var itemVo = ItemModel.Instance.GetItemByEntityID(info.ItemNums[0].EntityID);
        cell.img_bg.url = ImageDataModel.Instance.GetItemQuality(itemVo.Quality);
        cell.lb_count.text = info.ItemNums[0].Value.ToString();
        if (info.IsVip != 0)
        {
            if (MyselfModel.Instance.IsVip())
            {
                cell.txt_desc.text = Lang.GetValue("rob_shop_1", info.ItemNums[0].Value.ToString());
            }
            else
            {
                cell.txt_desc.text = Lang.GetValue("rob_shop_2");
            }
        }
        else
        {
            cell.txt_desc.text = Lang.GetValue("rob_shop_1", info.ItemNums[0].Value.ToString());
        }
        cell.img.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        if (info.LimitConfigs[0] > 0)
        {
            var count = 0;
            if (info.BuyType == 1)
            {
                count = RobModel.Instance.GetExchangeTimes(info.IndexId);
            }
            else
            {
                var recharge = RechargeModel.Instance.GetDiamondVo1(info.BuyConifg);
                if (RechargeModel.Instance.haveDiamondValue.ContainsKey((uint)recharge.IndexId))
                {
                    count = (int)RechargeModel.Instance.haveDiamondValue[(uint)recharge.IndexId];
                }
                else
                {
                    count = 0;
                }
                
            }
            
            cell.btn.enabled = count < info.LimitConfigs[1];
            var str = "";
            if(info.LimitConfigs[0] == 1)
            {
                str = Lang.GetValue("Treasure_headline10") + "：";
            }
            else if(info.LimitConfigs[0] == 2)
            {
                str = Lang.GetValue("draw_limit_buy_1") + "：";
            }
            else if (info.LimitConfigs[0] == 3)
            {
                str = Lang.GetValue("fund_5") + "：";
            }
            var num = info.LimitConfigs[1] - count;
            cell.txt_limit.text = str + num + "/" + info.LimitConfigs[1];
        }
        else
        {
            cell.btn.enabled = true;
        }
        if (info.OriginalPrice != 0)
        {
            
            if (info.BuyType == 1)
            {
                cell.btn.status.selectedIndex = 2;
                StringUtil.SetBtnTab(cell.btn.btn_buy2, info.BuyConifg.ToString());
                StringUtil.SetBtnTab3(cell.btn.btn_buy2, info.OriginalPrice.ToString());
                StringUtil.SetBtnUrl(cell.btn.btn_buy2, ImageDataModel.CASH_ICON_URL);
                double result = (double)(info.BuyConifg * 10) / info.OriginalPrice;
                string formatted = result.ToString("F1");  // F2 表示保留两位小数
                cell.rareNum.text = formatted;
            }
            else
            {
                var recharge = RechargeModel.Instance.GetDiamondVo1(info.BuyConifg);
                StringUtil.SetBtnTab(cell.btn.btn_buy1,Lang.GetValue("recharge_main_18", (recharge.Price / 10).ToString()) );
                StringUtil.SetBtnTab3(cell.btn.btn_buy1, Lang.GetValue("recharge_main_18", (recharge.OriginalPrice / 10).ToString()));
                cell.btn.status.selectedIndex = 1;
                double result = (double)(recharge.Price * 10) / recharge.OriginalPrice;
                string formatted = result.ToString("F1");  // F2 表示保留两位小数
                cell.rareNum.text = formatted;
            }
        }
        else
        {
            if (info.BuyType == 1)
            {
                StringUtil.SetBtnTab(cell.btn.btn_buy, info.BuyConifg.ToString());
                StringUtil.SetBtnUrl(cell.btn.btn_buy, ImageDataModel.CASH_ICON_URL);
                cell.btn.status.selectedIndex = 0;
            }
            else
            {
                var recharge = RechargeModel.Instance.GetDiamondVo1(info.BuyConifg);
                cell.btn.status.selectedIndex = 3;
                StringUtil.SetBtnTab(cell.btn.btn_buy1, Lang.GetValue("recharge_main_18", (recharge.Price / 10).ToString()));
            }
        }
        cell.btn.data = info;
        cell.btn.onClick.Add(Buyhander);
    }

    private void Buyhander(EventContext context)
    {
        var info = (context.sender as GComponent).data as Ft_rob_buyConfig;
        if(info.BuyType == 1)
        {
            if(info.BuyConifg > MyselfModel.Instance.diamond)
            {
                UILogicUtils.ShowNotice(Lang.GetValue("common_hint_txt3"));
                return;
            }
            RobController.Instance.ReqRobShopBuy((uint)info.IndexId);
        }
        else
        {
            var recharge = RechargeModel.Instance.GetDiamondVo1(info.BuyConifg);
            RechargeController.Instance.ReqPlaceOrder(2,(uint)recharge.IndexId);
        }

    }

    private void UpdateSwitchStatus()
    {
        (_view.btn_switch as fun_Rob.ToggleButton_1).select.selectedIndex = (int)RobModel.Instance.info.openShield == 0 ? 1 : 0;
    }
    private void UpdateData()
    {
        
        var itemVo = RobModel.Instance.GetItem(type);
        var count = StorageModel.Instance.GetItemCount(itemVo.ItemDefId);
        _view.lb_shield_count.text = Lang.GetValue("handBook_1") + "：" + TextUtil.ChangeCoinShow(count); //拥有
        _view.bg_small.url = ImageDataModel.Instance.GetItemRareQuality(itemVo.Quality);
        _view.bg_rare.url = ImageDataModel.Instance.GetItemNameQuality(itemVo.Quality);
        _view.nameLab.text = Lang.GetValue(itemVo.Name);
        _view.lb_title.text = Lang.GetValue(itemVo.Name);
        _view.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        _view.txt_desc.text = Lang.GetValue(itemVo.Description);
        UpdateList();
        UpdateSwitchStatus();
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

