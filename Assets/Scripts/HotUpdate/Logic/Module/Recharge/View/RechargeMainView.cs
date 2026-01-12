
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class RechargeMainView : BaseWindow
{
   private fun_Recharge.recharge_main_view view;
    private CardView cardView;
    private RechargeView rechargeView;
    private RechargeGiftView rechargeGiftView;
    private CumulativeView cumulativeView;
    //private TourGiftView tourGiftView;
    private ContractView contractView;
    private FundView fundView;
    private int tabType = 0;

    private List<int> pageData;
    public RechargeMainView()
    {
        packageName = "fun_Recharge";
        // 设置委托
        BindAllDelegate = fun_Recharge.fun_RechargeBinder.BindAll;
        CreateInstanceDelegate = fun_Recharge.recharge_main_view.CreateInstance;
        FullScreen = true;
        openWithTween = false;
        IsShowOrHideMainUI = true;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Recharge.recharge_main_view;
        
        SetBg(view.card_view.bg, "Recharge/ELIDA_quanyika_beijing.png");
        //SetBg(view.card_view.bg1, "Recharge/ELIDA_syh_qyk_fyqj02.png");
       // SetBg(view.card_view.bg2, "Recharge/baidi.png");

        SetBg(view.card_view.item1.bg, "Recharge/ELIDA_quanyika_yueka02.png");
        SetBg(view.card_view.item2.bg, "Recharge/ELIDA_quanyika_yueka01.png");

        SetBg(view.recharge_view.bg, "Recharge/ELIDA_syh_czlb_bg0.png");
        //SetBg(view.recharge_view.bg1, "Recharge/ELIDA_chongzhi_bg02.png");
        //SetBg(view.recharge_view.bg2, "Recharge/ELIDA_chongzhi_bg06.png");
        //SetBg(view.recharge_view.bg3, "Recharge/ELIDA_chongzhi_bg07.png");

        SetBg(view.gift_view.bg, "Recharge/ELIDA_syh_czlb_bg0.png");
        SetBg(view.gift_view.bg1, "Recharge/ELIDA_syh_czlb_renwu.png");
        SetBg(view.gift_view.bg2, "Recharge/ELIDA_syh_czlb_bg02.png");
        SetBg(view.cumulative_view.bg, "Recharge/ELIDA_lejichongzhi_beijing.png");

        SetBg(view.contract_view.bg, "Recharge/ELIDA_heyue_beijing.png");
        SetBg(view.contract_view.huadianBg, "Recharge/ELIDA_heyue_di011.png");
        //SetBg(view.tour_gift_view.bg, "Recharge/ELIDA_syh_czlb_bg0.png");

        SetBg(view.fund_view.bg, "Recharge/ELIDA_jijin_bg.png");

        cardView = new CardView(view.card_view);
        rechargeView = new RechargeView(view.recharge_view);
        rechargeGiftView = new RechargeGiftView(view.gift_view);
        cumulativeView = new CumulativeView(view.cumulative_view);
        contractView = new ContractView(view.contract_view);
        fundView = new FundView(view.fund_view);
        view.list.itemRenderer = RenderList;

        view.cumulative_view.goto_btn.onClick.Add(() =>
        {
            view.tab.selectedIndex = 4;
            view.list.selectedIndex = 4;
            ChangeTab(4);
        });
        EventManager.Instance.AddEventListener(RechargeEvent.Normal,UpdateTabList);
        EventManager.Instance.AddEventListener(RechargeEvent.VipPay, UpdateTabList);
        EventManager.Instance.AddEventListener(RechargeEvent.MonthCard, UpdateTabList);
        EventManager.Instance.AddEventListener(RechargeEvent.AccRecharge, UpdateTabList);
        EventManager.Instance.AddEventListener(PlayerEvent.GameCrossDay, UpdateTabList);
        EventManager.Instance.AddEventListener(RedPointEvent.UpdateTodayFirstLogin, UpdateTabList);
        EventManager.Instance.AddEventListener<uint>(RedPointEvent.RedDotChange, UpdateContractRed);
        EventManager.Instance.AddEventListener(FundEvent.FundReward, UpdateTabList);
    }
    private void UpdateContractRed(uint type)
    {
        if(type == (uint)RedPointType.Task_Contract)
        {
            UpdateTabList();
        }
    }
    private void RenderList(int index,GObject item)
    {
        var cell = item as common_New.common_page2;
        cell.data = pageData[index];
        var str = "";
        //cell.status.selectedIndex = index;
        if (pageData[index] == 0)
        {
            if (RechargeModel.Instance.GetRechargeGiftRed())
            {
                UILogicUtils.ShowRedPoint(cell);
            }
            else
            {
                UILogicUtils.HideRedPoint(cell);
            }

            str = Lang.GetValue("Grade_pack_10003");
        }
        else if (pageData[index] == 1)
        {
            if (FundModel.Instance.GetFundRed())
            {
                UILogicUtils.ShowRedPoint(cell);
            }
            else
            {
                UILogicUtils.HideRedPoint(cell);
            }

            str = Lang.GetValue("fund_8");
        }
        else if(pageData[index] == 2)
        {
            if (MyselfModel.Instance.GetVipRed())
            {
                UILogicUtils.ShowRedPoint(cell);
            }
            else
            {
                UILogicUtils.HideRedPoint(cell);
            }
            str = Lang.GetValue("recharge_main_1");
        }
        else if (pageData[index] == 3)
        {
            if (RechargeModel.Instance.GetCumulativeRed())
            {
                UILogicUtils.ShowRedPoint(cell);
            }
            else
            {
                UILogicUtils.HideRedPoint(cell);
            }
            str = Lang.GetValue("recharge_main_2");
        }
        else if (pageData[index] == 4)
        {
            if (RedPointModel.Instance.GetTodayFirstLogin(TodayFirstLogin.Recharge))
            {
                UILogicUtils.ShowRedPoint(cell);
            }
            else
            {
                UILogicUtils.HideRedPoint(cell);
            }
            str = Lang.GetValue("recharge_main_3");
        }
        else
        {
            if (RedPointModel.Instance.IsRedPointShow(RedPointType.Task_Contract))
            {
                UILogicUtils.ShowRedPoint(cell);
            }
            else
            {
                UILogicUtils.HideRedPoint(cell);
            }
            str = Lang.GetValue("recharge_main_32");
        }
        if(str.Length < 4)
        {
            StringUtil.SetBtnTab5(cell, str);
            cell.type.selectedIndex = 1;
        }
        else
        {
            cell.type.selectedIndex = 0;
            StringUtil.SetBtnTab4(cell, str);
        }

        cell.onClick.Add(TabClick);
    }
    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        var type = (int)data;
        view.tab.selectedIndex = type;
        ChangeTab(type);
        InitPageData(type);
    }
    private void ChangeTab(int type)
    {
        tabType = type;
        if(tabType == 0)
        {
            rechargeGiftView.OnShown();
        }
        else if(tabType == 1)
        {
            fundView.OnShown();
        }
        else if(tabType == 2)
        {
            cardView.OnShown();
        }
        else if (tabType == 3)
        {
            cumulativeView.OnShown();
        }
        else if (tabType == 4)
        {
            
            rechargeView.OnShown();
        }
        else
        {
            contractView.OnShown();
        }
    }

    private void InitPageData(int type)
    {
        pageData = new List<int>();
        for (var i = 0; i < 6; i++)
        {
            if (i == 2 && !GlobalModel.Instance.GetUnlocked(SysId.VipPopup))
            {
                continue;
            }
            if (i == 3 && !GlobalModel.Instance.GetUnlocked(SysId.Fuben))
            {
                continue;
            }

            pageData.Add(i);
        }
        view.list.numItems = pageData.Count;
        int index = pageData.IndexOf(type);
        if (index == -1)
        {
            index = 0;
        }
        view.list.selectedIndex = index;
        view.tab.selectedIndex = pageData[index];
        ChangeTab(pageData[index]);
    }
    public void UpdateTabList()
    {
        view.list.numItems = pageData.Count;
    }
    private void TabClick(EventContext context)
    {
        var type = (int)(context.sender as GComponent).data;
        if (tabType != type)
        {
            view.tab.selectedIndex = type;
            ChangeTab(type);
        }
    }
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
        cardView.OnHide();
        rechargeGiftView.OnHide();
        contractView.OnHide();
    }
}

