
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
    private int tabType = 0;
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

        cardView = new CardView(view.card_view);
        rechargeView = new RechargeView(view.recharge_view);
        rechargeGiftView = new RechargeGiftView(view.gift_view);
        cumulativeView = new CumulativeView(view.cumulative_view);
        contractView = new ContractView(view.contract_view);
        view.list.itemRenderer = RenderList;
        

        view.cumulative_view.goto_btn.onClick.Add(() =>
        {
            view.tab.selectedIndex = 3;
            ChangeTab(3);
        });
        EventManager.Instance.AddEventListener(RechargeEvent.Normal,UpdateTabList);
        EventManager.Instance.AddEventListener(RechargeEvent.VipPay, UpdateTabList);
        EventManager.Instance.AddEventListener(RechargeEvent.MonthCard, UpdateTabList);
        EventManager.Instance.AddEventListener(RechargeEvent.AccRecharge, UpdateTabList);
        EventManager.Instance.AddEventListener(PlayerEvent.GameCrossDay, UpdateTabList);
        EventManager.Instance.AddEventListener(RedPointEvent.UpdateTodayFirstLogin, UpdateTabList);
        EventManager.Instance.AddEventListener<uint>(RedPointEvent.RedDotChange, UpdateContractRed);
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
        var cell = item as fun_Recharge.page_btn;
        cell.data = index;
        cell.status.selectedIndex = index;
        if (index == 0)
        {
            if (RechargeModel.Instance.GetRechargeGiftRed())
            {
                UILogicUtils.ShowRedPoint(cell);
            }
            else
            {
                UILogicUtils.HideRedPoint(cell);
            }
            cell.titleLab.text = Lang.GetValue("Grade_pack_10001");
        }
        else if(index == 1)
        {
            if (MyselfModel.Instance.GetVipRed())
            {
                UILogicUtils.ShowRedPoint(cell);
            }
            else
            {
                UILogicUtils.HideRedPoint(cell);
            }
            cell.titleLab.text = Lang.GetValue("recharge_main_1");
        }
        else if (index == 2)
        {
            if (RechargeModel.Instance.GetCumulativeRed())
            {
                UILogicUtils.ShowRedPoint(cell);
            }
            else
            {
                UILogicUtils.HideRedPoint(cell);
            }
            cell.titleLab.text = Lang.GetValue("recharge_main_2");
        }
        else if (index == 3)
        {
            if (RedPointModel.Instance.GetTodayFirstLogin(TodayFirstLogin.Recharge))
            {
                UILogicUtils.ShowRedPoint(cell);
            }
            else
            {
                UILogicUtils.HideRedPoint(cell);
            }
            cell.titleLab.text = Lang.GetValue("recharge_main_3");
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
            cell.titleLab.text = Lang.GetValue("recharge_main_32");
        }
        cell.onClick.Add(OnTabClick);
    }

    private void OnTabClick(EventContext context)
    {
        var index = (int)(context.sender as GComponent).data;
        if(tabType != index)
        {
            ChangeTab(index);
        }
    }
    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        var type = (int)data;
        view.tab.selectedIndex = type;
        ChangeTab(type);
        UpdateTabList();
    }
    private void UpdateTabList()
    {
        view.list.numItems = 5;
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
            cardView.OnShown();
        }
        else if (tabType == 2)
        {
            cumulativeView.OnShown();
        }
        else if (tabType == 3)
        {
            
            rechargeView.OnShown();
        }
        else
        {
            contractView.OnShown();
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

