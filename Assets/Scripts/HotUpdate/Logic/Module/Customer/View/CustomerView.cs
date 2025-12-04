using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using Elida.Config;
using UnityTimer;

public class CustomerView : BaseView
{
   private fun_Customer.customer_view view;
    private NpcConfig curNpc;
    private int tabType = 0;
    private int styleType = 0;

    private List<StorageItemVO> listData;

    private RoleListWindow roleView;

    private bool IsLongPress = false;
    private Timer timer;
    private bool isShow = false;
    public CustomerView()
    {
        packageName = "fun_Customer";
        // 设置委托
        BindAllDelegate = fun_Customer.fun_CustomerBinder.BindAll;
        CreateInstanceDelegate = fun_Customer.customer_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Customer.customer_view;
        SetBg(view.bg, "Customer/ELIDA_jumin_bg.jpg");
        SetBg(view.bg1, "Customer/ELIDA_jumin_bg_xqdi01.png");
        SetBg(view.role_view.bg, "Customer/ELIDA_jumin_liebiaodi01.png");
        roleView = new RoleListWindow(view.role_view);
        StringUtil.SetBtnTab(view.detail, Lang.GetValue("details_title"));
        StringUtil.SetBtnTab(view.role_btn, Lang.GetValue("customer_1"));
        StringUtil.SetBtnTab(view.gift_btn, Lang.GetValue("text_treasure_item9"));
        StringUtil.SetBtnTab(view.ike_btn, Lang.GetValue("warehouse_03"));
        StringUtil.SetBtnTab(view.send_btn, Lang.GetValue("Treasure_button1"));

        StringUtil.SetBtnTab3(view.gift_btn, Lang.GetValue("text_treasure_item9"));
        StringUtil.SetBtnTab3(view.ike_btn, Lang.GetValue("warehouse_03"));

        view.tipLab1.text = Lang.GetValue("customer_2");
        view.tipLab.text = Lang.GetValue("customer_3");

        view.chose_grp.chose_list.itemRenderer = RenderChoseList;

        view.style_list.itemRenderer = RenderStyleList;
        view.list.itemRenderer = RenderList;
        view.list.SetVirtual();

       

        InitChose();

        view.chose_btn.onClick.Add(() =>
        {
            view.showChose.selectedIndex = view.showChose.selectedIndex == 0 ? 1 : 0;
        });
        view.role_btn.onClick.Add(() =>
        {
            view.role_view.visible = true;
        });

        view.send_btn.onClick.Add(() =>
        {
            var times = tabType == 0 ? CustomerModel.Instance.surplusGiveGiftCnt : CustomerModel.Instance.surplusGiveIkebanaCnt;
            if (CustomerModel.Instance.GetNpcRewardInfo(curNpc.Id, (int)curNpc.Level + 1) == null)
            {
                UILogicUtils.ShowNotice(Lang.GetValue("customer_19"));
                return;
            }
            if (times <= 0)
            {
                UILogicUtils.ShowNotice(Lang.GetValue("customer_20"));
                return;
            }
            if (listData.Count <= 0)
            {
                return;
            }
            var item = listData[view.list.selectedIndex];
            CustomerController.Instance.ReqNpcGiveGift((uint)curNpc.Id, (uint)(tabType + 1), (uint)item.itemDefId, 1);
        });

        view.add_btn.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<CustomerBuyWindow>(UIName.CustomerBuyWindow, tabType);
        });
        view.pro.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<CustomerLikeWindow>(UIName.CustomerLikeWindow);
        });

        view.gift_btn.onClick.Add(() =>
        {
            if(tabType != 0)
            {
                ChangeTab(0);
            }
        });
        view.ike_btn.onClick.Add(() =>
        {
            if (tabType != 1)
            {
                ChangeTab(1);
            }
        });
        view.detail.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<RoleDetailWindow>(UIName.RoleDetailWindow, curNpc.Id);
        });
        LongPressGesture gesture = new LongPressGesture(view.send_btn);
        gesture.trigger = 0.3f;
        gesture.onAction.Add(OnGestureAction);
        gesture.onEnd.Add(OnGestureEnd);

        AddEventListener(NpcEvent.NpcGiveGift, UpdateData);
        AddEventListener(NpcEvent.NpcBuyTimes, UpdateTimes);
        EventManager.Instance.AddEventListener(NpcEvent.ChangeNpc, UpdateNpcInfo);
    }

    private void UpdateData()
    {
        UpdateNpcData();
        UpdateTimes();
        ChangeTab(tabType);
        if (!isShow)
        {
            isShow = true;
            view.chatShow.Play(UpdateTime);
        }
        else
        {
            UpdateTime();
        }
        
        if (IsLongPress)
        {
            var times = tabType == 0 ? CustomerModel.Instance.surplusGiveGiftCnt : CustomerModel.Instance.surplusGiveIkebanaCnt;
            if(CustomerModel.Instance.GetNpcRewardInfo(curNpc.Id,(int)curNpc.Level +1) == null)
            {
                UILogicUtils.ShowNotice(Lang.GetValue("customer_19"));
                return;
            }
            if(times <= 0)
            {
                UILogicUtils.ShowNotice(Lang.GetValue("customer_20"));
                return;
            }
            if (listData.Count <= 0)
            {
                return;
            }
            var item = listData[view.list.selectedIndex];
            CustomerController.Instance.ReqNpcGiveGift((uint)curNpc.Id, (uint)(tabType + 1), (uint)item.itemDefId, 1);
        }
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        CustomerModel.Instance.InitNpcBook();
        UpdateNpcInfo();
        roleView.OnShown();
    }

    private void UpdateNpcInfo()
    {
        curNpc = CustomerModel.Instance.npcHome[roleView.curIndex];
        if (Lang.GetValue(curNpc.Name) != "") Lang.GetValue(curNpc.Name);
        
        view.style_list.numItems = curNpc.LikeLabels.Length;
        view.pic.url = "npc/role/" + curNpc.Idle + ".png";
        ChangeTab(tabType);
        UpdateNpcData();
        UpdateTimes();
    }

    public void UpdateNpcData()
    {
        
        view.proLab.text = CustomerModel.Instance.totalLevel.ToString();
        var nextBuffExp = CustomerModel.Instance.GetNpcBuffInfo((int)CustomerModel.Instance.totalLevel + 1);
        if(nextBuffExp != null)
        {
            view.pro.max = nextBuffExp.Exp;
            view.pro.value = CustomerModel.Instance.totalExp;
        }
        else
        {
            view.pro.max = 1;
            view.pro.value = 1;
        }
        var nextExp = CustomerModel.Instance.GetNpcRewardInfo(curNpc.Id, (int)curNpc.Level + 1);
        
        if (nextExp != null)
        {
            view.expPro.text = curNpc.Exp + "/" + nextExp.Exp;
            var plotConfig = PlotModel.Instance.GetPlotConfig(nextExp.PoltId);
            if (plotConfig != null)
            {
                view.lvName.text = Lang.GetValue(plotConfig.PlotName);
            }
        }
        else
        {
            
            var curExp = CustomerModel.Instance.GetNpcRewardInfo(curNpc.Id, (int)curNpc.Level);
            var plotConfig = PlotModel.Instance.GetPlotConfig(curExp.PoltId);
            if (plotConfig != null)
            {
                view.lvName.text = Lang.GetValue(plotConfig.PlotName);
            }

            view.expPro.text = curNpc.Exp + "/" + curExp.Exp;
        }
        
    }

    private void UpdateTimes()
    {
        if(tabType == 0)
        {
            view.numLab.text = CustomerModel.Instance.surplusGiveGiftCnt + "/" + (GlobalModel.Instance.module_profileConfig.giftLimitCost + CustomerModel.Instance.buyGiftCnt);
        }
        else
        {
            view.numLab.text = CustomerModel.Instance.surplusGiveIkebanaCnt + "/" + (GlobalModel.Instance.module_profileConfig.ikebanaLimitCost + CustomerModel.Instance.buyIkebanaCnt);
        }
    }

    private void InitChose()
    {
        StringUtil.SetBtnTab(view.chose_btn, Lang.GetValue("guild_Match_3"));
        view.chose_grp.chose_list.numItems = 7;
        view.chose_grp.chose_list.selectedIndex = 0;
       
    }

    private void RenderChoseList(int index,GObject item)
    {
        var cell = item as fun_Customer.chose_quality_item;
        if(index == 0)
        {
            cell.titileLab.text = Lang.GetValue("guild_Match_3");
        }
        else
        {
            cell.titileLab.text = Lang.GetValue("style_" + index);
        }
        cell.data = index;
        cell.onClick.Add(FilterVase);
    }

    private void FilterVase(EventContext context)
    {
        var type = (int)(context.sender as GComponent).data;
        if(styleType == type)
        {
            return;
        }
        styleType = type;
        if (type == 0)
        {
            StringUtil.SetBtnTab(view.chose_btn, Lang.GetValue("guild_Match_3"));
        }
        else
        {
            StringUtil.SetBtnTab(view.chose_btn, Lang.GetValue("style_" + type));
        }
        ChangeTab(tabType);
    }
    private void ChangeTab(int type)
    {
        tabType = type;
        if(tabType == 0)
        {
            listData = StorageModel.Instance.GetStorageListByType_1(4115);
        }
        else
        {
            
            listData = CustomerModel.Instance.FilterVaseData(styleType);

        }
        
        view.list.numItems = listData.Count;
        view.list.selectedIndex = 0;
    }

    private void RenderStyleList(int index,GObject item)
    {
        var cell = item as fun_Customer.style_item;
        var info = curNpc.LikeLabels[index];
        cell.pic.url = "HandBookNew/style_icon_" + info + ".png";
    }

    private void RenderList(int index,GObject item)
    {
        var cell = item as fun_Customer.rewrad_item;
        var info = listData[index];
        cell.status.selectedIndex = tabType;
        cell.numLab.text = info.count.ToString();
        if (tabType == 0)
        {
            cell.pic.url = ImageDataModel.Instance.GetIconUrl(info.item);
        }
        else
        {
            UIExt_ikeImg.LoadIkeByItemId((cell.ikeImg as common_New.ikeImg), info.itemDefId, true);
        }
    }

    private void OnGestureAction(EventContext context)
    {
        IsLongPress = true;
        var times = tabType == 0 ? CustomerModel.Instance.surplusGiveGiftCnt : CustomerModel.Instance.surplusGiveIkebanaCnt;
        if (CustomerModel.Instance.GetNpcRewardInfo(curNpc.Id, (int)curNpc.Level + 1) == null)
        {
            UILogicUtils.ShowNotice(Lang.GetValue("customer_19"));
            return;
        }
        if (times <= 0)
        {
            UILogicUtils.ShowNotice(Lang.GetValue("customer_20"));
            return;
        }
        if (listData.Count <= 0)
        {
            return;
        }
        var item = listData[view.list.selectedIndex];
        CustomerController.Instance.ReqNpcGiveGift((uint)curNpc.Id, (uint)(tabType + 1), (uint)item.itemDefId, 1);
    }

    private void UpdateTime()
    {
        if(timer != null)
        {
            Timer.Cancel(timer);
            timer = null;
        }
        timer = Timer.Regist(1f, OnTimerEvent, false);
    }

    private void OnTimerEvent()
    {
        view.chatHide.Play();
        isShow = false;
    }
    private void OnGestureEnd()
    {
        IsLongPress = false;
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

