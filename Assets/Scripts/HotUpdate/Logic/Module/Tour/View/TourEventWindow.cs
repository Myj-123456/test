
//using FairyGUI;
//using System.Threading.Tasks;
//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;

//public class TourEventWindow : BaseWindow
//{
//   private fun_Tour_Land.tour_event_view view;
//    private List<uint> listData;
//   public TourEventWindow()
//    {
//        packageName = "fun_Tour_Land";
//        // 设置委托
//        BindAllDelegate = fun_Tour_Land.fun_Tour_LandBinder.BindAll;
//        CreateInstanceDelegate = fun_Tour_Land.tour_event_view.CreateInstance;
//    }

//    public override void OnInit()
//    {
//         base.OnInit();
//        view = ui as fun_Tour_Land.tour_event_view;
//        SetBg(view.bg, "Common/ELIDA_common_bigdi01.png");
//        view.list.itemRenderer = RenderList;
//        view.list.SetVirtual();

//        AddEventListener(AdventureEvent.AdventureEventReward, UpdateData);
//    }

//    public override void OnShown()
//    {
//        base.OnShown();
//        // 其他打开面板的逻辑
//        UpdateData();
//    }

//    private void UpdateData()
//    {
//        listData = AdventureModel.Instance.events;
//        view.tipLab.text = Lang.GetValue("tour_event_7") + listData.Count;
//        view.list.numItems = listData.Count;
//    }

//    private void RenderList(int index,GObject item)
//    {
//        var cell = item as fun_Tour_Land.tour_event_item;
//        var eventInfo = TourModel.Instance.GetTourEventFromId((int)listData[index]);
//        cell.nameLab.text = Lang.GetValue(eventInfo.EventName);
//        cell.data = index;
//        cell.onClick.Add(ClickEvent);
//    }

//    private void ClickEvent(EventContext context)
//    {
//        var id = (int)(context.sender as GComponent).data;
//        UIManager.Instance.OpenWindow<TourEventRewardWindow>(UIName.TourEventRewardWindow, id);
//    }

//    public override void OnHide()
//    {
//        base.OnHide();
//        // 其他关闭面板的逻辑
//    }
//}

