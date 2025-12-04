
//using FairyGUI;
//using System.Threading.Tasks;
//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using ADK;
//using Elida.Config;
//using System;

//public class TourMapView : BaseView
//{
//   private fun_Tour_Land.tour_land_map view;
//    private List<Ft_island_configConfig> curLandData;
//    private int tabType;

//    private int curIndex;
//    private CountDownTimer timer;

//    private CountDownTimer cycle;
//    private bool isOpen;
//    public TourMapView()
//    {
//        packageName = "fun_Tour_Land";
//        // 设置委托
//        BindAllDelegate = fun_Tour_Land.fun_Tour_LandBinder.BindAll;
//        CreateInstanceDelegate = fun_Tour_Land.tour_land_map.CreateInstance;
        
//    }

//    public override void OnInit()
//    {
//         base.OnInit();
//        view = ui as fun_Tour_Land.tour_land_map;
//        SetBg(view.bg, "Recharge/ELIDA_chongzhi_bg01.png");
//        view.tipLab.text = Lang.GetValue("tour_map_1");
//        view.hookLab.text = Lang.GetValue("tour_reward_2");
//        view.task_title.text = Lang.GetValue("tour_event_2");

//        StringUtil.SetBtnTab(view.go_btn, Lang.GetValue("guide_button1"));
//        StringUtil.SetBtnTab(view.tab1, Lang.GetValue("tour_map_2"));
//        StringUtil.SetBtnTab(view.tab2, Lang.GetValue("tour_map_3"));
//        StringUtil.SetBtnTab(view.reward_btn, Lang.GetValue("Act_order_txt22"));
//        view.list.itemRenderer = RenderList;
//        view.list.SetVirtual();

//        var itemVo = ItemModel.Instance.GetItemById(GlobalModel.Instance.module_profileConfig.breakItemId);
//        view.bread_img.url = ImageDataModel.Instance.GetIconUrl(itemVo);

//        view.tab1.onClick.Add(() =>
//        {
//            ChangeTab(0);
//        });

//        view.tab2.onClick.Add(() =>
//        {
//            //ChangeTab(1);
//        });

//        view.go_btn.onClick.Add(() =>
//        {
//            AdventureModel.Instance.curMapId = curLandData[curIndex].Id;
//            AdventureController.Instance.GoAdventure();
//        });
//        view.reward_btn.onClick.Add(() =>
//        {
//            UIManager.Instance.OpenWindow<TourRewardWindow>(UIName.TourRewardWindow);
//        });
//        view.event_btn.onClick.Add(() =>
//        {
//            UIManager.Instance.OpenWindow<TourEventWindow>(UIName.TourEventWindow);
//        });
//        AddEventListener<uint>(SystemEvent.UpdateProfile, UpdateProfile);
//        AddEventListener(AdventureEvent.AdventureInfo, UpdateData);
//        AddEventListener(AdventureEvent.AdventureSettleReward, UpdateSettle);
//        AddEventListener(AdventureEvent.AdventureProReward, UpdatePro);
//    }

//    public override void OnShown()
//    {
//        base.OnShown();
//        // 其他打开面板的逻辑
//        isOpen = true;
//        AdventureController.Instance.ReqAdventureInfo();
//        UpdateDiamond();
//        UpdateGold();
//        UpdateColorPower();
//    }

//    private void ChangeTab(int tab)
//    {
//        if(tabType == tab)
//        {
//            return;
//        }
//        tabType = tab;
//        UpdateList();
//        UpdateHook();
//    }

//    private void UpdateList()
//    {
//        curLandData = AdventureModel.Instance.GetLandFromType(tabType + 1);
//        view.list.numItems = curLandData.Count;
//    }

//    private void RenderList(int index,GObject item)
//    {
//        var cell = item as fun_Tour_Land.tour_land_item;
//        cell.type.selectedIndex = index % 2;
//        var landInfo = curLandData[index];
//        cell.item.nameLab.text = Lang.GetValue(landInfo.Name);
//        if(index > AdventureModel.Instance.adventureTour.level)
//        {
//            cell.item.status.selectedIndex = 0;
//        }else if(index == AdventureModel.Instance.adventureTour.level)
//        {
//            cell.item.status.selectedIndex = 1;
//        }
//        else
//        {
//            cell.item.max_img.visible = false;
//            cell.item.status.selectedIndex = 2;
//            if(index == (AdventureModel.Instance.adventureTour.level - 1))
//            {
//                int endTime = ((int)ServerTime.Time - (int)AdventureModel.Instance.adventureTour.startTime);
//                var tourInfo = TourModel.Instance.GetTourFromId((int)AdventureModel.Instance.adventureTour.level);
//                if (endTime >= tourInfo.LimitTime)
//                {
//                    cell.item.max_img.visible = true;
//                }
//            }
//        }
        
//        cell.item.selected.selectedIndex = (index == curIndex) ? 1 : 0;
//        cell.item.data = index;
//        cell.item.onClick.Add(ClickChose);

//    }
//    private void ClickChose(EventContext context)
//    {
//        var idx = (int)(context.sender as GComponent).data;
//        if(idx == curIndex || idx > AdventureModel.Instance.adventureTour.level)
//        {
//            return;
//        }
//        curIndex = idx;
//        UpdateList();
//        UpdateHook();
//    }
//    private void UpdateProfile(uint itemId)
//    {
//        if (itemId == (uint)BaseType.CASH)
//        {
//            UpdateDiamond();
//        }
//        else if (itemId == (uint)BaseType.GOLD)
//        {
//            UpdateGold();
//        }
        
//    }
//    private void UpdateColorPower()
//    {
//        var colorPowerItemNum = StorageModel.Instance.GetItemCount((int)ADK.BaseType.ColorPower);
//        view.ink_num.text = TextUtil.ChangeCoinShow(colorPowerItemNum);
//    }
//    private void UpdateData()
//    {
//        if (isOpen)
//        {
//            curIndex = (int)AdventureModel.Instance.adventureTour.level;
//            isOpen = false;
//        }
        
//        curLandData = AdventureModel.Instance.GetLandFromType(tabType + 1);
//        view.list.numItems = curLandData.Count;
//        UpdateHook();
//        CycleInfo();
//    }

//    private void UpdateSettle()
//    {
//        view.list.numItems = curLandData.Count;
//        UpdateHook();
//    }

//    private void CycleInfo()
//    {
//        if(cycle != null)
//        {
//            cycle.Clear();
//            cycle = null;
//        }
//        var curTime = (int)ServerTime.Time - (int)AdventureModel.Instance.adventureTour.startTime;
//        var endTime = 60 -  curTime % 60;
//        Debug.Log("endTime1111111111111111111111111" + endTime);
//        cycle = new CountDownTimer(null, endTime);
//        cycle.CompleteCallBacker = () =>
//        {
//            AdventureController.Instance.ReqAdventureInfo();
//        };
//    }
//    private void UpdatePro()
//    {
//        var islandData = AdventureModel.Instance.GetIslandData((uint)curLandData[curIndex].Id);
//        var max = AdventureModel.Instance.GetTotalObject(curLandData[curIndex].Id);
//        max = max == 0 ? 999 : max;
//        var curPro = (islandData == null || islandData.clearObjectIds == null ? 0 : islandData.clearObjectIds.Length);
//        var rate = curPro * 100 / max ;
//        view.pro.pro_img.fillAmount = (float)curPro / (float)max;
//        for (int i = 0,len = curLandData[curIndex].Progresss.Length;i < len; i++)
//        {
//            var proItem = view.pro.GetChild("reward" + (i + 1)) as fun_Tour_Land.box_reward;
//            var need = curLandData[curIndex].Progresss[i];
//            if(proItem != null)
//            {
//                if(need > rate)
//                {
//                    proItem.status.selectedIndex = 0;
//                    proItem.touchable = false;
//                }
//                else
//                {
//                    if(islandData != null&& islandData.progressRewards != null && Array.IndexOf(islandData.progressRewards,i) != -1)
//                    {
//                        proItem.status.selectedIndex = 2;
//                        proItem.touchable = false;
//                    }
//                    else
//                    {
//                        proItem.status.selectedIndex = 1;
//                        proItem.touchable = true;
//                    }
//                }
//            }
//            proItem.data = i;
//            proItem.onClick.Add(GetProReward);
//        }
//    }

//    private void GetProReward(EventContext context)
//    {
//        var index = (int)(context.sender as GComponent).data;
//        AdventureController.Instance.ReqAdventureProReward((uint)curLandData[curIndex].Id, index);
//    }

//   private void UpdateHook()
//    {
       
//        if (curIndex == AdventureModel.Instance.adventureTour.level)
//        {
//            view.status.selectedIndex = 0;
//        }
//        else
//        {
//            if(timer != null)
//            {
//                timer.Clear();
//                timer = null;
//            }
//            var tourInfo = TourModel.Instance.GetTourFromId((int)AdventureModel.Instance.adventureTour.level);
//            view.goldLab.text = tourInfo.GoldProduce + "/" + Lang.GetValue("time.min");
//            view.expLab.text = tourInfo.BreakProduce + "/" + Lang.GetValue("time.min");
//            view.status.selectedIndex = 1;

//            view.task_num.text = (AdventureModel.Instance.adventureTour.events == null ? 0 : AdventureModel.Instance.adventureTour.events.Length).ToString();
//            int endTime = ((int)ServerTime.Time - (int)AdventureModel.Instance.adventureTour.startTime);
//            endTime = endTime < tourInfo.LimitTime ? tourInfo.LimitTime - endTime: endTime;
//            if (endTime > 0 && endTime < tourInfo.LimitTime)
//            { 
//                UpdateTime();
//                timer = new CountDownTimer(null, endTime);
//                timer.UpdateCallBacker = () =>
//                {
//                    UpdateTime();
//                };
//                timer.CompleteCallBacker = () =>{
//                    UpdateHook();
//                };
//                view.tour_title.text = Lang.GetValue("tour_event_4");
//            }
//            else
//            {
//                UpdateTime();
//                view.tour_title.text = Lang.GetValue("tour_event_3");
//            }
//        }
//        view.tipLab.visible = AdventureModel.Instance.adventureTour.level < 1;
//        var landInfo = curLandData[curIndex];
//        view.nameLab.text = Lang.GetValue(landInfo.Name);
//        UpdatePro();
//    }
//    private void UpdateTime()
//    {
//        var showtime = (int)ServerTime.Time - (int)AdventureModel.Instance.adventureTour.startTime;
//        var tourInfo = TourModel.Instance.GetTourFromId((int)AdventureModel.Instance.adventureTour.level);
//        showtime = showtime > tourInfo.LimitTime ? tourInfo.LimitTime : showtime;
//        view.timeLab.text = Lang.GetValue("tour_event_5") + TimeUtil.SecondTimeString(showtime);
//    }
//    private void UpdateGold()
//    {
//        view.gold_num.text = TextUtil.ChangeCoinShow(MyselfModel.Instance.gold);
//    }
//    private void UpdateDiamond()
//    {
//        view.diamond_num.text = TextUtil.ChangeCoinShow(MyselfModel.Instance.diamond);
//    }
//    public override void OnHide()
//    {
//        base.OnHide();
//        // 其他关闭面板的逻辑
//        if(timer != null)
//        {
//            timer.Clear();
//            timer = null;
//        }
//        if (cycle != null)
//        {
//            cycle.Clear();
//            cycle = null;
//        }
//    }
//}
                                                    
