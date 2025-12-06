using ADK;
using DG.Tweening;
using Elida.Config;
using FairyGUI;
using fun_FlowerOrder;
using protobuf.order;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTimer;
using static protobuf.order.I_ORDER_VO;

public class FlowerOrderWindow : BaseWindow
{
    private fun_FlowerOrder.order viewSkin;
    private Dictionary<uint, orderNpc> orderNpcDic = new Dictionary<uint, orderNpc>();
    private EventCallback1 callback;

    private Dictionary<uint, CountDownTimer> timerMap;

    private CountDownTimer timer;
    public FlowerOrderWindow()
    {
        packageName = "fun_FlowerOrder";
        // 设置委托
        BindAllDelegate = fun_FlowerOrder.fun_FlowerOrderBinder.BindAll;
        CreateInstanceDelegate = fun_FlowerOrder.order.CreateInstance;
    }
    public override void OnInit()
    {
        base.OnInit();
        viewSkin = ui as fun_FlowerOrder.order;
        AddEvent();
        SetBg(viewSkin.ornBg, "FlowerOrder/FlowerOrderBg.png");
        viewSkin.timeTipLab.text = Lang.GetValue("flower_order_02");

        viewSkin.doubledOrderRewardTxt.text = Lang.GetValue("video_revenue_13");
        orderNpcDic.Add(1, viewSkin.npc4);
        orderNpcDic.Add(2, viewSkin.npc3);
        orderNpcDic.Add(3, viewSkin.npc1);
        orderNpcDic.Add(4, viewSkin.npc2);
        orderNpcDic.Add(5, viewSkin.npc5);
        orderNpcDic.Add(6, viewSkin.npc6);
        orderNpcDic.Add(7, viewSkin.npc7);
        callback = EventCallback;
        timerMap = new Dictionary<uint, CountDownTimer>();
        viewSkin.need_list.itemRenderer = this.OnitemRenderer;
        viewSkin.need_list.SetVirtual();
        var itemVo = ItemModel.Instance.GetItemById(GlobalModel.Instance.module_profileConfig.chouItemId);
        viewSkin.dress_com.show.visible = false;
        viewSkin.dress_com.grp.visible = false;
        viewSkin.dress_com.img.url = ImageDataModel.Instance.GetIconUrl(itemVo);



        viewSkin.exp_com.img.url = ImageDataModel.EXP_ICON_URL;
        viewSkin.gold_com.img.url = ImageDataModel.GOLD_ICON_URL;
        viewSkin.cash_com.img.url = ImageDataModel.CASH_ICON_URL;
        viewSkin.cash_com.show.visible = false;
        viewSkin.cash_com.grp.visible = false;
    }

    private void AddEvent()
    {
        viewSkin.add_btn.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<AddPreWindow>(UIName.AddPreWindow, 0);
        });
        viewSkin.submit_btn.onClick.Add(OnSubmitOrder);
        AddEventListener(FlowerOrderEvent.ResOrderSubmit, OnResOrderSubmit);
        AddEventListener(FlowerOrderEvent.ResDailyMissionReward, OnResDailyMissionReward);

        AddEventListener(PlayerEvent.GameCrossDay, OnResDailyMissionReward);
        //AddEventListener(FlowerOrderEvent.UpdateFlowerOrderCd, ShowOderNpc);
        AddEventListener(VideoEvent.videoDoubleEnd, UpdateVideoDouble);

        EventManager.Instance.AddEventListener(RechargeEvent.VideoPay, UpdateVideoDouble);
        EventManager.Instance.AddEventListener(RechargeEvent.RechargeInfo, UpdateVideoDouble);
        EventManager.Instance.AddEventListener(VideoEvent.videoDoubleTime, UpdateVideoDouble);
    }

    public override void OnShown()
    {
        base.OnShown();
        foreach (var order in orderNpcDic)
        {
            var orderNpc = order.Value;
            orderNpc.alpha = 0;
            viewSkin.touchable = false;
        }
        viewSkin.open.Play(() =>
        {
            foreach (var order in orderNpcDic)
            {
                var orderNpc = order.Value;
                DOTween.Sequence().Append(DOTween.To(() => orderNpc.alpha, x => orderNpc.alpha = x, 1f, 0.25f).SetEase(Ease.OutCubic)).Play();
                viewSkin.touchable = true;
            }
        });
        ShowOderNpc();
        UpdateRewardBox();
    }

    private protobuf.order.I_ORDER_VO selectOrderVo;//选择一个可设置
    private void ShowOderNpc()
    {
        foreach (var order in orderNpcDic)
        {
            var position = order.Key;
            var orderNpc = order.Value;
            var orderVo = FlowerOrderModel.Instance.GetOrderVo(position);
            if (orderVo != null)
            {
                orderNpc.visible = true;
                var npcIndex = int.Parse(orderNpc.name.Replace("npc", ""));
                orderNpc.data = orderVo;
                orderNpc.npc.selectedIndex = npcIndex;
                UpdateNpcStatus(orderNpc);
            }
            else//没有数据隐藏npc
            {
                orderNpc.visible = false;
            }
            orderNpc.onClick.Add(EventCallback);
        }
        selectOrderVo = FlowerOrderModel.Instance.GetCanSubmitOrderVo();//先选中可以提交的订单
        if (selectOrderVo == null) selectOrderVo = FlowerOrderModel.Instance.GetOrderVo(1);//拿第一个
        UpdateSubmitBtn(selectOrderVo);
        UpdateOrder(selectOrderVo);
    }

    public void UpdateAnim(protobuf.order.I_ORDER_VO orderVo)
    {
        if (orderVo == null) return;
        if (orderVo.position == 1 || orderVo.position == 6)
        {
            viewSkin.anim.url = "kongque";
            viewSkin.anim.loop = true;
            viewSkin.anim.animationName = "idle";
        }
        else if (orderVo.position == 2)
        {
            viewSkin.anim.url = "lu";
            viewSkin.anim.loop = true;
            viewSkin.anim.animationName = "idle";
        }
        else if (orderVo.position == 3 || orderVo.position == 7)
        {
            viewSkin.anim.url = "yang";
            viewSkin.anim.loop = true;
            viewSkin.anim.animationName = "idle";
        }
        else if (orderVo.position == 4 || orderVo.position == 5)
        {
            viewSkin.anim.url = "laoshu";
            viewSkin.anim.loop = true;
            viewSkin.anim.animationName = "idle";
        }
    }

    private void EventCallback(EventContext context)
    {
        var orderNpc = context.sender as orderNpc;
        selectOrderVo = orderNpc.data as protobuf.order.I_ORDER_VO;
        UpdateSubmitBtn(selectOrderVo);
        UpdateOrder(selectOrderVo);
    }

    private void UpdateVideoDouble()
    {
        UpdateOrder(selectOrderVo);
    }

    private void UpdateNpcStatus(orderNpc npc)
    {
        var order = npc.data as protobuf.order.I_ORDER_VO;
        if (order.cdTime > ServerTime.Time)//cd中
        {
            npc.npcOrderStatus.selectedIndex = 2;
            CountDownTimer timeDown;
            if (timerMap.ContainsKey(order.position))
            {
                timeDown = timerMap[order.position];
                timeDown.Clear();
                timeDown = null;
                timerMap.Remove(order.position);
            }

            int endTime = (int)order.cdTime - (int)ServerTime.Time;
            npc.timeLab.text = TimeUtil.SecondTimeString1(endTime); ;
            timeDown = new CountDownTimer(null, endTime, true, 2);
            timerMap.Add(order.position, timeDown);
            timeDown.UpdateCallBacker = () =>
            {
                npc.timeLab.text = TimeUtil.SecondTimeString1((int)order.cdTime - (int)ServerTime.Time);
            };
            timeDown.CompleteCallBacker = () =>
            {
                timeDown.Clear();
                timeDown = null;
                timerMap.Remove(order.position);
                ShowOderNpc();
            };
        }
        else
        {
            if (order.orderType == 2)
            {
                npc.npcOrderStatus.selectedIndex = 3;
            }
            else
            {
                var enough = FlowerOrderModel.Instance.GetIsEnoughByPosition(order.position);
                if (enough)
                {
                    npc.npcOrderStatus.selectedIndex = 1;
                }
                else
                {
                    npc.npcOrderStatus.selectedIndex = 0;
                }
            }

        }
    }

    private void UpdateOrder(protobuf.order.I_ORDER_VO orderVo)
    {
        UpdateNeedItems(orderVo);
        UpdateReward(orderVo);
        UpdateAnim(orderVo);
        UpdateChoseOrder(orderVo);
    }

    private void UpdateChoseOrder(protobuf.order.I_ORDER_VO orderVo)
    {
        foreach (var order in orderNpcDic)
        {
            if (order.Key == orderVo.position)
            {
                order.Value.type.selectedIndex = 1;
            }
            else
            {
                order.Value.type.selectedIndex = 0;
            }
        }
    }
    private void UpdateSubmitBtn(I_ORDER_VO vo)
    {
        if (vo == null)
        {
            viewSkin.submit_btn.enabled = false;
        }
        else
        {
            viewSkin.submit_btn.enabled = FlowerOrderModel.Instance.CheckCanSubmit(vo);
        }

        if (timer != null)
        {
            timer.Clear();
            timer = null;
        }
        int endTime = (int)vo.cdTime - (int)ServerTime.Time;
        if (endTime > 0)
        {
            timer = new CountDownTimer(viewSkin.timeLab, endTime, false, 2);
            timer.suffixString = " 后到达";
            timer.Run();
            viewSkin.timeShow.visible = true;
            viewSkin.submit_btn.visible = false;
        }
        else
        {
            viewSkin.timeShow.visible = false;
            viewSkin.submit_btn.visible = true;
        }
    }

    private void OnSubmitOrder()
    {
        if (selectOrderVo != null)
        {
            if (selectOrderVo.orderType == 2 && selectOrderVo.status == 0)
            {
                FlowerOrderController.Instance.ReqOrderVideo(selectOrderVo.position);
            }
            else
            {
                FlowerOrderController.Instance.ReqOrderSubmit(selectOrderVo);
            }

        }
    }

    private void OnResOrderSubmit()
    {
        ShowOderNpc();
        UpdateRewardBox();
    }

    private void OnResDailyMissionReward()
    {
        UpdateRewardBox();
    }

    private void UpdateReward(protobuf.order.I_ORDER_VO orderVo)
    {
        if (orderVo == null)
        {

            return;
        }

        var exp = BuffManager.Instance.GetAddCount(BuffType.Order_Exp_Type, orderVo.needItems);
        var gold = BuffManager.Instance.GetAddCount(BuffType.Order_Glod_Type, orderVo.needItems);
        //foreach (var needItem in needItems)
        //{
        //    var flowerId = needItem.Key;
        //    var flowerNum = needItem.Value;
        //    var configExp = OrderModel.Instance.GetFlowerAdditionExp((int)flowerId);
        //    var configGold = OrderModel.Instance.GetFlowerAdditionGold((int)flowerId);
        //    exp += configExp * (int)flowerNum;
        //    gold += configGold * (int)flowerNum;
        //}
        var expBuffRate = BuffManager.Instance.GetAddRate(BuffType.Order_Exp_Type, (float)orderVo.isDouble);
        var goldBuffBuffRate = BuffManager.Instance.GetAddRate(BuffType.Order_Glod_Type, (float)orderVo.isDouble);

        //var expBuffValue = Mathf.Ceil(exp * expBuffRate);
        //var goldBuffValue = Mathf.Ceil(gold * goldBuffBuffRate);
        //viewSkin.doubledTab.selectedIndex = (int)orderVo.isDouble;
        //viewSkin.exp_txt.text = expBuffValue.ToString();
        //viewSkin.gold_txt.text = goldBuffValue.ToString();

        viewSkin.exp_com.show.visible = expBuffRate > 1 || orderVo.isExpAddtion;
        viewSkin.gold_com.show.visible = goldBuffBuffRate > 1 || orderVo.isGoldAddtion;

        viewSkin.exp_com.grp.visible = expBuffRate > 1;
        viewSkin.gold_com.grp.visible = goldBuffBuffRate > 1;
        viewSkin.exp_com.exp_txt_1.text = "x" + expBuffRate;
        viewSkin.gold_com.exp_txt_1.text = "x" + goldBuffBuffRate;

        var reward = ItemModel.Instance.GetDropData(orderVo.reward);
        foreach (var value in reward)
        {
            if (value.itemDefId == (int)BaseType.EXP)
            {
                viewSkin.exp_com.numLab.text = Mathf.Ceil(value.count * expBuffRate).ToString();
            }
            if (value.itemDefId == (int)BaseType.GOLD)
            {
                viewSkin.gold_com.numLab.text = Mathf.Ceil(value.count * goldBuffBuffRate).ToString();
            }
            if (value.itemDefId == (int)BaseType.CASH)
            {
                viewSkin.cash_com.numLab.text = value.count.ToString();
            }
            if (value.itemDefId == GlobalModel.Instance.module_profileConfig.chouItemId)
            {
                viewSkin.dress_com.numLab.text = value.count.ToString();
            }

        }

        //viewSkin.exp_grp.visible = expBuffRate > 1;
        //viewSkin.gold_grp.visible = goldBuffBuffRate > 1;
        //viewSkin.exp_txt_1.text = "x" + expBuffRate;
        //viewSkin.gold_txt_1.text = "x" + goldBuffBuffRate;
        if (orderVo.orderType == 2)
        {
            viewSkin.type.selectedIndex = 1;
            //foreach (var reward in orderVo.reward)
            //{
            //    viewSkin.cashImg.url = ImageDataModel.Instance.GetIconUrlByEntityId((long)reward.Key);
            //    viewSkin.cash_txt.text = reward.Value.ToString();
            //    viewSkin.cash_com.numLab.text = reward.Value.ToString();
            //}
            if(orderVo.status == 0)
            {
                StringUtil.SetBtnTab2(viewSkin.submit_btn, Lang.GetValue("flower_order_05"));// 观看
            }
            else
            {
                StringUtil.SetBtnTab2(viewSkin.submit_btn, Lang.GetValue("flower_order_03"));// 提交
            }
        }
        else if (orderVo.orderType == 3)
        {
            viewSkin.type.selectedIndex = 2;
            StringUtil.SetBtnTab2(viewSkin.submit_btn, Lang.GetValue("flower_order_03"));// 提交
        }
        else
        {
            viewSkin.type.selectedIndex = 0;
            StringUtil.SetBtnTab2(viewSkin.submit_btn, Lang.GetValue("flower_order_03"));// 提交
        }


    }

    private void UpdateRewardBox()
    {
        var level = MyselfModel.Instance.level;
        var id1 = 1 * 10000 + level;
        var id2 = 2 * 10000 + level;
        var id3 = 3 * 10000 + level;
        var vo1_ = FlowerOrderModel.Instance.GetDailyPurposeConfig((int)id1);
        var vo2_ = FlowerOrderModel.Instance.GetDailyPurposeConfig((int)id2);
        var vo3_ = FlowerOrderModel.Instance.GetDailyPurposeConfig((int)id3);

        UpdateGift(viewSkin.btn_smallGift, vo1_);
        UpdateGift(viewSkin.btn_middleGift, vo2_);
        UpdateGift(viewSkin.btn_bigGift, vo3_);

        var curNum = MyselfModel.Instance.behaviorDaily.orderCnt;//小黑板订单次数
        var isCom1 = curNum >= vo1_.Goals;
        var isCom2 = curNum >= vo2_.Goals;
        var isCom3 = curNum >= vo3_.Goals;

        viewSkin.progress_completed.max = vo3_.Goals;
        viewSkin.progress_completed.value = curNum > vo3_.Goals ? vo3_.Goals : curNum;
        viewSkin.progress_completed.proImg.x = 415f * (float)viewSkin.progress_completed.value / (float)viewSkin.progress_completed.max;

        uint have = isCom1 ? (uint)vo1_.Goals : curNum;
        have = isCom1 ? (uint)vo1_.Goals : curNum;
        viewSkin.txt_smallGift.numLab.text = have + "/" + vo1_.Goals;

        viewSkin.txt_middleGift.visible = isCom2 ? true : false;
        have = isCom2 ? (uint)vo2_.Goals : curNum;
        viewSkin.txt_middleGift.numLab.text = have + "/" + vo2_.Goals;

        viewSkin.txt_bigGift.visible = isCom3 ? true : false;
        have = isCom3 ? (uint)vo3_.Goals : curNum;
        viewSkin.txt_bigGift.numLab.text = have + "/" + vo3_.Goals;
    }

    private void UpdateGift(GButton btn_, Ft_daily_purposeConfig vo)
    {
        var curNum = MyselfModel.Instance.behaviorDaily.orderCnt;//小黑板订单次数
        var orderStageAward = MyselfModel.Instance.behaviorDaily.orderStageAward;//小黑板订单完成次数进度奖励
        btn_.data = vo;
        if (orderStageAward.IndexOf(vo.TreasureChest.ToString()) != -1)//已领取
        {
            btn_.enabled = false;
            btn_.GetController("open").selectedIndex = 1;
        }
        else//未领取
        {
            btn_.GetController("open").selectedIndex = 0;
            if (curNum < vo.Goals)//未达到
            {
                btn_.enabled = false;
            }
            else//已达到目标
            {
                btn_.enabled = true;
                btn_.onClick.Add(OnReqDailyMissionReward);
            }
        }
    }

    private void OnReqDailyMissionReward(EventContext context)
    {
        var vo = (context.sender as GComponent).data as Ft_daily_purposeConfig;
        FlowerOrderController.Instance.ReqDailyMissionReward((uint)vo.TreasureChest);
    }

    private protobuf.order.I_ORDER_VO curOrderVo;
    private void UpdateNeedItems(protobuf.order.I_ORDER_VO orderVo)
    {
        if (orderVo == null) return;
        curOrderVo = orderVo;

        viewSkin.need_list.numItems = orderVo.needItems.Count;
    }

    private void OnitemRenderer(int index, GObject cell)
    {
        fun_FlowerOrder.need_list_cell item = cell as fun_FlowerOrder.need_list_cell;
        if (curOrderVo != null)
        {
            var needItems = curOrderVo.needItems;
            List<ulong> keys = new List<ulong>(needItems.Keys);
            var target_key = keys[index];
            var target_val = needItems[target_key];
            item.flower.url = ImageDataModel.Instance.GetIconUrlByEntityId(target_key.ToString());
            var have_count = StorageModel.Instance.GetItemCount((int)target_key);
            var isCom = ((ulong)have_count >= target_val);
            item.numLab.text = Lang.GetValue("common_desc_3", isCom ? "#48EF5C" : "#FFA574", have_count.ToString(), target_val.ToString());
            var nameId = ItemModel.Instance.GetItemById((int)target_key).Name;
            var flowerName = Lang.GetValue(nameId);
            item.name_txt.text = flowerName;
        }
    }

    public override void OnHide()
    {
        base.OnHide();
        foreach (var time in timerMap.Values)
        {
            time.Clear();
        }

        if (timer != null)
        {
            timer.Clear();
        }
    }
}
