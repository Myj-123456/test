
//using FairyGUI;
//using System.Threading.Tasks;
//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using ADK;

//public class TourRewardWindow : BaseWindow
//{
//   private fun_Tour_Land.tour_reward_view view;
//    private CountDownTimer timer;

//    private List<StorageItemVO> listData;

//    public TourRewardWindow()
//    {
//        packageName = "fun_Tour_Land";
//        // 设置委托
//        BindAllDelegate = fun_Tour_Land.fun_Tour_LandBinder.BindAll;
//        CreateInstanceDelegate = fun_Tour_Land.tour_reward_view.CreateInstance;
//    }

//    public override void OnInit()
//    {
//         base.OnInit();
//        view = ui as fun_Tour_Land.tour_reward_view;
//        SetBg(view.bg, "Common/ELIDA_common_bigdi01.png");
//        view.titileLab.text = Lang.GetValue("tour_reward_1");
//        view.hookLab.text = Lang.GetValue("tour_reward_2");
//        view.hook_time_txt.text = Lang.GetValue("tour_reward_3");
//        view.gettedLab.text = Lang.GetValue("tour_reward_4");
//        StringUtil.SetBtnTab(view.show_btn, Lang.GetValue("title_activity_3"));
//        StringUtil.SetBtnTab(view.get_btn, Lang.GetValue("common_claim_button"));
//        view.list.itemRenderer = RenderList;
//        view.list.SetVirtual();
//        var itemVo = ItemModel.Instance.GetItemById(GlobalModel.Instance.module_profileConfig.breakItemId);
//        view.break_img.url = ImageDataModel.Instance.GetIconUrl(itemVo);

//        view.get_btn.onClick.Add(() =>
//        {
//            var showtime = (int)ServerTime.Time - (int)AdventureModel.Instance.adventureTour.startTime;
//            if(showtime < 60)
//            {
//                UILogicUtils.ShowNotice(Lang.GetValue("tour_event_9"));
//                return;
//            }
//            if(AdventureModel.Instance.events.Count > 0)
//            {
//                UILogicUtils.ShowNotice(Lang.GetValue("tour_event_8"));
//                return;
//            }
//            AdventureController.Instance.ReqAdventureSettleReward();
//        });
//        view.show_btn.onClick.Add(() =>
//        {
//            UIManager.Instance.OpenWindow<PreRewardWindow>(UIName.PreRewardWindow);
//        });

//        AddEventListener(AdventureEvent.AdventureSettleReward, UpdateData);
//        AddEventListener(AdventureEvent.AdventureInfo, UpdateData);
//    }

//    public override void OnShown()
//    {
//        base.OnShown();
//        // 其他打开面板的逻辑
//        UpdateData();
//    }
//    private void UpdateData()
//    {
//        if (timer != null)
//        {
//            timer.Clear();
//            timer = null;
//        }
//        var tourInfo = TourModel.Instance.GetTourFromId((int)AdventureModel.Instance.adventureTour.level);
//        view.gold_num.text = tourInfo.GoldProduce + "/" + Lang.GetValue("time.min");
//        view.break_num.text = tourInfo.BreakProduce + "/" + Lang.GetValue("time.min");

//        view.timeLimitLab.text = Lang.GetValue("tour_event_6") + TimeUtil.SecondTimeString(tourInfo.LimitTime);
//        int endTime = ((int)ServerTime.Time - (int)AdventureModel.Instance.adventureTour.startTime);
//        endTime = endTime < tourInfo.LimitTime ? tourInfo.LimitTime - endTime : endTime;
//        UpdateTime();
//        if (AdventureModel.Instance.adventureTour.waitSettleRewards == null)
//        {
//            view.list.numItems = 0;
//        }
//        else
//        {
//            listData = ItemModel.Instance.GetDropData(AdventureModel.Instance.adventureTour.waitSettleRewards);
//            view.list.numItems = listData.Count;
//        }
//        if (endTime > 0 && endTime < tourInfo.LimitTime)
//        {
//            UpdateTime();
//            timer = new CountDownTimer(null, endTime);
//            timer.UpdateCallBacker = () =>
//            {
//                UpdateTime();
//            };
//            timer.CompleteCallBacker = () => {
//                UpdateData();
//            };

//        }
//    }
//    private void UpdateTime()
//    {
//        var showtime = (int)ServerTime.Time - (int)AdventureModel.Instance.adventureTour.startTime;
//        var tourInfo = TourModel.Instance.GetTourFromId((int)AdventureModel.Instance.adventureTour.level);
//        showtime = showtime > tourInfo.LimitTime ? tourInfo.LimitTime : showtime;
//        view.timeLab.text = TimeUtil.SecondTimeString(showtime);
//    }

//    private void RenderList(int index,GObject item)
//    {
//        var cell = item as fun_Tour_Land.tour_reward_item;
//        var itemInfo = listData[index];
//        var itemVo = ItemModel.Instance.GetItemById(itemInfo.itemDefId);
//        cell.icon.url = ImageDataModel.Instance.GetIconUrl(itemVo);
//        cell.numLab.text = TextUtil.ChangeCoinShow(itemInfo.count);
//    }

//    public override void OnHide()
//    {
//        base.OnHide();
//        // 其他关闭面板的逻辑
//        if (timer != null)
//        {
//            timer.Clear();
//            timer = null;
//        }
//    }
//}

