using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using System.Linq;
using System;

public class OrderFlowerWindow : BaseView
{
   private fun_OrderFlower.order_flower view;
    private CountDownTimer timer;
   public OrderFlowerWindow()
    {
        packageName = "fun_OrderFlower";
        // 设置委托
        BindAllDelegate = fun_OrderFlower.fun_OrderFlowerBinder.BindAll;
        CreateInstanceDelegate = fun_OrderFlower.order_flower.CreateInstance;
        //FullScreen = true;
        //showModal = false;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_OrderFlower.order_flower;
        view.tip_0.text = Lang.GetValue("MarketOrder_txt2");
        view.titleLab.text = Lang.GetValue("MarketOrder_txt1");
        view.txt_noOrder.text = Lang.GetValue("Treasure_headline4");
        StringUtil.SetBtnTab(view.btn_refresh.btn_free, Lang.GetValue("common_button_refresh"));
        //view.bg.url = "FlowerOrder/ELIDA_huashidingdan_bg.png";
        view.lb_Complate.text = Lang.GetValue("party_button_completed");
        StringUtil.SetBtnTab2(view.btn_commit, Lang.GetValue("Common_Btn_Submit"));
        //StringUtil.SetBtnCount(view.btn_refresh.btn_reflush,GlobalModel.Instance.module_profileConfig.flowerMarketRefresh.ToString());
        StringUtil.SetBtnTab(view.btn_refresh.btn_reflush, GlobalModel.Instance.module_profileConfig.flowerMarketRefresh.ToString());

        view.rewardBoard.marketRewardGoldItem.txt_name.text = Lang.GetValue("gold");
        view.rewardBoard.marketRewardExpItem.txt_name.text = Lang.GetValue("exp");

        view.rewardBoard.marketRewardGoldItem.pic.url = ImageDataModel.GOLD_ICON_URL;
        view.rewardBoard.marketRewardExpItem.pic.url = ImageDataModel.EXP_ICON_URL;

        view.spine.url = "xiaoxiongmao";
        view.spine.loop = true;
        view.spine.animationName = "idle";

       view.btn_commit.onClick.Add(() =>
        {
            FlowerOrderController.Instance.ReqFlowerOrderSubmit();
        });
        view.btn_refresh.btn_free.onClick.Add(() =>
        {
            FlowerOrderController.Instance.ReqFlowerOrderRerest();
        });
        view.btn_refresh.btn_reflush.onClick.Add(() =>
        {
            if(MyselfModel.Instance.diamond < GlobalModel.Instance.module_profileConfig.flowerMarketRefresh)
            {
                UILogicUtils.ShowNotice(Lang.GetValue("common_hint_txt3"));
                return;
            }
            FlowerOrderController.Instance.ReqFlowerOrderRerest();
        });
        view.hitArea.onClick.Add(CloseView);

        EventManager.Instance.AddEventListener(FlowerOrderEvent.FlowerOrderInfo, UpdateData);
        EventManager.Instance.AddEventListener(VideoEvent.videoDoubleEnd, UpdateData);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        FlowerOrderController.Instance.ReqFlowerOrderInfo();
        UpdateTime();
    }

    private void UpdateData()
    {
        var info = FlowerOrderModel.Instance.flowerOrder;
        var flowerId = info.needItems.Keys.ToArray()[0];
        var count = info.needItems.Values.ToArray()[0];
        var itemVo = ItemModel.Instance.GetItemById((int)flowerId);
        view.img_flower.url = ImageDataModel.Instance.GetIdentifiedFlowerUrl(itemVo);
        var haveCount = StorageModel.Instance.GetItemCount((int)flowerId);
        bool isEnabled = haveCount >= (int)count;
        view.btn_commit.enabled = isEnabled && info.status == 0;
        view.comStatus.selectedIndex = (int)info.status;
        view.txt_have.text = (isEnabled ? "<font color= '#777E70'>" : "<font color= '#fe8870'>") + haveCount + "</font>/" + count;
        view.lb_flowerName.text = Lang.GetValue("order_flower_need", Lang.GetValue(itemVo.Name), count.ToString()) ;
        var goldRate = BuffManager.Instance.GetAddRate(BuffType.Flower_Glod_Type);
        var goldNum = OrderModel.Instance.GetFlowerAdditionGold((int)flowerId) * (int)count * goldRate;
        var addExp = (MyselfModel.Instance.CurrVipExp() / 100f);
        var expRate = BuffManager.Instance.GetAddRate(BuffType.Flower_Exp_Type);
        var expNum = OrderModel.Instance.GetFlowerAdditionExp((int)flowerId) * (int)count * expRate;
        if (goldRate > 1)
        {
            view.rewardBoard.marketRewardGoldItem.type.selectedIndex = 1;
            view.rewardBoard.marketRewardGoldItem.txt_num.text = goldNum.ToString();
            view.rewardBoard.marketRewardGoldItem.txt_add.text = goldRate.ToString();

        }
        else
        {
            view.rewardBoard.marketRewardGoldItem.type.selectedIndex = 0;
            view.rewardBoard.marketRewardGoldItem.txt_num.text = goldNum.ToString();
        }
        if (expRate > 1)
        {
            view.rewardBoard.marketRewardExpItem.type.selectedIndex = 1;
            view.rewardBoard.marketRewardExpItem.txt_num.text = expNum.ToString();
            //view.rewardBoard.marketRewardExpItem.lb_value_2.text = (OrderModel.Instance.GetFlowerAdditionExp((int)flowerId) * (int)count * (1 + (float)GlobalModel.Instance.module_profileConfig.flowerMarketexperience / 100)) + "*" + ((float)info.expBuff / 100 + 1);
            view.rewardBoard.marketRewardExpItem.txt_add.text = expRate.ToString();
        }
        else
        {
            view.rewardBoard.marketRewardExpItem.type.selectedIndex = 0;
            view.rewardBoard.marketRewardExpItem.txt_num.text = expNum.ToString();
        }
        if (info.refreshTimes == 0)
        {
            view.btn_refresh.status.selectedIndex = 0;
        }
        else
        {
            view.btn_refresh.status.selectedIndex = 1;
        }

    }

    public void UpdateTime()
    {
        if(timer != null)
        {
            timer.Clear();
            timer = null;
        }
        var flushTimes = GlobalModel.Instance.module_profileConfig.flowerMarkettime;
        var DataTime = TimeUtil.GetDateTime(ServerTime.Time);
        var hours = DataTime.Hour;
        int updateHours = 0;
        bool isNextDay = false;
        for(int i = 0;i < flushTimes.Count; i++)
        {
            if(i == 0)
            {
                var t = flushTimes[i];
                if (hours < t)
                {
                    updateHours = t;
                    break;
                }
            }
            else if (i >= flushTimes.Count - 1)
            {//检测数组尾部
             //最后时间
                isNextDay = true;
                updateHours = flushTimes[0];
                break;
            }
            var t1 = flushTimes[i];
            var t2 = flushTimes[i + 1];
            if (hours >= t1 && hours < t2)
            {
                updateHours = t2;
                break;
            }
        }
        
        if (isNextDay)
        {
            DataTime = DataTime.AddDays(1);
        }
        DateTime afterDate = new DateTime(DataTime.Year, DataTime.Month, DataTime.Day, updateHours, 0, 0, 0);
        var leftTime = (int)TimeUtil.GetTimestamp(afterDate) - (int)ServerTime.Time;
        timer = new CountDownTimer(view.lb_timeDown, leftTime, false, 2);
        timer.prefixString = Lang.GetValue("MarketOrder_txt3", "");
        timer.Run();
        timer.CompleteCallBacker = () =>
        {
            FlowerOrderController.Instance.ReqFlowerOrderInfo();
            UpdateTime();
        };
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }

    private void CloseView()
    {
        HideView();
    }

    private void HideView(Action callBack = null)
    {
        UIManager.Instance.ClosePanel(UIName.OrderFlowerWindow);
        //SceneManager.Instance.ShowHideHeroAvatar(true);
        SceneManager.Instance.MoveToPoint(FlowerOrderModel.Instance.cameraPos, 0.3f);
        SceneManager.Instance.TweenCameraOrthoSize(FlowerOrderModel.Instance.orthoSize, 0.3f, callBack);
    }
}

