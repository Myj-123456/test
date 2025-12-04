using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
public class ShopMainView : BaseView
{
   private fun_VipShop.shop_main_view view;
    private int tabType;
    private CultivationShopWindow cultivationShop;
    private VipShopWindow vipShop;
    private OtherShopView otherShop;
   public ShopMainView()
    {
        packageName = "fun_VipShop";
        // 设置委托
        BindAllDelegate = fun_VipShop.fun_VipShopBinder.BindAll;
        CreateInstanceDelegate = fun_VipShop.shop_main_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_VipShop.shop_main_view;
        SetBg(view.cultivation_view.bg, "VipShop/ELIDA_shangpu_zs_bg.jpg");

        SetBg(view.vip_shop.bg, "VipShop/ELIDA_shangpu_jxsp_bg01.png");
        SetBg(view.vip_shop.bg1, "VipShop/ELIDA_shangpu_jxsp_bg02.png");

        SetBg(view.other_view.bg, "Cultivation/ELIDA_peiyu_peiyushangdiandi.jpg");

        StringUtil.SetBtnTab(view.seed_btn, Lang.GetValue("cultivate_shop_04"));
        StringUtil.SetBtnTab(view.other_btn, Lang.GetValue("shop_main_1"));
        StringUtil.SetBtnTab(view.vip_btn, Lang.GetValue("shop_main_2"));

        cultivationShop = new CultivationShopWindow(view.cultivation_view);
        vipShop = new VipShopWindow(view.vip_shop);
        otherShop = new OtherShopView(view.other_view);
        tabType = 0;

        view.seed_btn.onClick.Add(() =>
        {
            if(tabType != 0)
            {
                ChangeTab(0);
            }
        });
        view.other_btn.onClick.Add(() =>
        {
            if (tabType != 1)
            {
                ChangeTab(1);
            }
        });
        view.vip_btn.onClick.Add(() =>
        {
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
        var index = (int)data;
        view.tab.selectedIndex = index;
        ChangeTab(index);
        UnlockBtn();
    }
    private void ChangeTab(int type)
    {
        tabType = type;
        if(tabType == 0)
        {
            cultivationShop.OnShown();
        }
        else if(tabType == 1)
        {
            otherShop.OnShown();
        }
        else
        {
            vipShop.OnShown();
        }
    }
    private void UnlockBtn()
    {
        view.seed_btn.visible = GlobalModel.Instance.GetUnlocked(SysId.RandomShop);
        view.other_btn.visible = GlobalModel.Instance.GetUnlocked(SysId.Furniture_Shop);
        view.vip_btn.visible = GlobalModel.Instance.GetUnlocked(SysId.VipPopup);
    }
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
        cultivationShop.OnHide();
        vipShop.OnHide();
    }
}

