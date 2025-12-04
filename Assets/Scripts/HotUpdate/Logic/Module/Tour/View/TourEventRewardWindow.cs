
//using FairyGUI;
//using System.Threading.Tasks;
//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using Elida.Config;
//using ADK;

//public class TourEventRewardWindow : BaseWindow
//{
//   private fun_Tour_Land.tour_event_reward_view view;
//    private Ft_island_eventConfig eventInfo;
//    private int tabType;
//    private int index;
//   public TourEventRewardWindow()
//    {
//        packageName = "fun_Tour_Land";
//        // 设置委托
//        BindAllDelegate = fun_Tour_Land.fun_Tour_LandBinder.BindAll;
//        CreateInstanceDelegate = fun_Tour_Land.tour_event_reward_view.CreateInstance;
//    }

//    public override void OnInit()
//    {
//         base.OnInit();
//        view = ui as fun_Tour_Land.tour_event_reward_view;
//        SetBg(view.bg, "Common/ELIDA_common_littledi01.png");
//        view.getLab.text = Lang.GetValue("Share_txt35");

//        view.list.itemRenderer = RenderList;
//        view.list.SetVirtual();

//        view.chose1.onClick.Add(() =>
//        {
//            tabType = 0;
//            view.tab.selectedIndex = tabType;
//        });
//        view.chose2.onClick.Add(() =>
//        {
//            tabType = 1;
//            view.tab.selectedIndex = tabType;
//        });

//        view.get_btn.onClick.Add(() =>
//        {
//            if(eventInfo.EventType == 1)
//            {
//                AdventureController.Instance.ReqAdventureEventReward(index, 0);
//            }
//            else
//            {
//                AdventureController.Instance.ReqAdventureEventReward(index, (uint)(tabType == 0?1:2));
//            }
//            Close();
//        });

//        AddEventListener(AdventureEvent.AdventureInfo, UpdateData);
//    }

//    public override void OnShown()
//    {
//        base.OnShown();
//        // 其他打开面板的逻辑
//        index = (int)data;
//        UpdateData();
//    }
//    private void UpdateData()
//    {
//        var id = (int)AdventureModel.Instance.events[index];
//        tabType = 0;
//        eventInfo = TourModel.Instance.GetTourEventFromId(id);
//        view.nameLab.text = Lang.GetValue(eventInfo.EventName);
//        view.decLab.text = Lang.GetValue(eventInfo.EventDesc);
//        if (eventInfo.EventType == 1)
//        {
//            view.status.selectedIndex = 1;
//            StringUtil.SetBtnTab(view.get_btn, Lang.GetValue("common_claim_button"));
//            view.list.numItems = eventInfo.EventRewards.Length;
//        }
//        else
//        {
//            view.status.selectedIndex = 0;
//            view.tab.selectedIndex = tabType;
//            var arr = eventInfo.EventChoose.Split("#");
//            StringUtil.SetBtnTab(view.chose1, Lang.GetValue(arr[0]));
//            StringUtil.SetBtnTab(view.chose2, Lang.GetValue(arr[1]));
//            StringUtil.SetBtnTab(view.get_btn, Lang.GetValue("levelup_button"));
//        }
//    }

//    private void RenderList(int index,GObject item)
//    {
//        var cell = item as fun_Tour_Land.tour_reward_item;
//        var itemData = eventInfo.EventRewards[index];
//        var itemVo = ItemModel.Instance.GetItemByEntityID(itemData.EntityID);
//        cell.icon.url = ImageDataModel.Instance.GetIconUrl(itemVo);
//        cell.numLab.text = itemData.Value.ToString();

//    }
//    public override void OnHide()
//    {
//        base.OnHide();
//        // 其他关闭面板的逻辑
//    }
//}

