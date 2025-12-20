using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
public class ShopMainView : BaseWindow
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
        FullScreen = true;
        openWithTween = false;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_VipShop.shop_main_view;
        SetBg(view.bg, "Recharge/ELIDA_shangpu_bg.png");

        StringUtil.SetBtnTab4(view.seed_btn, Lang.GetValue("cultivate_shop_04"));
        StringUtil.SetBtnTab4(view.other_btn, Lang.GetValue("shop_main_1"));
        StringUtil.SetBtnTab4(view.vip_btn, Lang.GetValue("shop_main_2"));

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
        EventManager.Instance.AddEventListener(RedPointEvent.UpdateTodayFirstLogin, UpdateRedPoint);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        var index = (int)data;
        view.tab.selectedIndex = index;
        ChangeTab(index);
        UnlockBtn();
        UpdateRedPoint();
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
        view.other_btn.visible = false;
        view.vip_btn.visible = GlobalModel.Instance.GetUnlocked(SysId.VipPopup);
    }
    private void UpdateRedPoint()
    {
        if (RedPointModel.Instance.GetTodayFirstLogin(TodayFirstLogin.Vip_Shop))
        {
            UILogicUtils.ShowRedPoint(view.vip_btn);
        }
        else
        {
            UILogicUtils.HideRedPoint(view.vip_btn);
        }
        
    }
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
        cultivationShop.OnHide();
        vipShop.OnHide();
    }
}

