using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using ADK;
using protobuf.recharge;

public class PopGiftWindow : BaseWindow
{
   private fun_PopGift.pop_gift_view view;
    private int curIndex;
    private I_GIFTPACK_VO giftData;
    private uint curId;
    RewardPropsObject[] rewardData;
    private CountDownTimer timer;
    private Dictionary<int, CountDownTimer> timerMap;
   public PopGiftWindow()
    {
        packageName = "fun_PopGift";
        // 设置委托
        BindAllDelegate = fun_PopGift.fun_PopGiftBinder.BindAll;
        CreateInstanceDelegate = fun_PopGift.pop_gift_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_PopGift.pop_gift_view;
        SetBg(view.bg, "Recharge/ELIDA_syh_tcslb_bg.png");
        view.tipLab.text = Lang.GetValue("pop_gift_1");
        timerMap = new Dictionary<int, CountDownTimer>();
        view.list.itemRenderer = RenderList;
        view.page_list.itemRenderer = RenderPageItem;
        view.left_btn.onClick.Add(() =>
        {
            curIndex--;
            UpdateInfo();
            UpdateBtnStatus();
            view.page_list.selectedIndex = curIndex;
        });
        view.right_btn.onClick.Add(() =>
        {
            curIndex++;
            UpdateInfo();
            UpdateBtnStatus();
            view.page_list.selectedIndex = curIndex;
        });
        view.buy_btn.onClick.Add(() =>
        {
            RechargeController.Instance.ReqPlaceOrder(1, giftData.id);
        });
        view.tip.onClick.Add(() =>
        {
            view.tip.type.selectedIndex = view.tip.type.selectedIndex == 0 ? 1 : 0;
            Saver.SaveAsString<int>("GiftPackTip" + MyselfModel.Instance.userId, view.tip.type.selectedIndex);
            if(view.tip.type.selectedIndex == 1)
            {
                Saver.SaveAsString<int>("GiftPackTipTime" + MyselfModel.Instance.userId, (int)ServerTime.Time);
            }
        });
    }
    private void UpdatePageList()
    {
        view.page_list.numItems = PopGiftModel.Instance.giftPackList.Count;
        view.page_list.selectedIndex = curIndex;
    }
    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        UpdateData();
        var bol = Saver.GetInt("GiftPackTip" + MyselfModel.Instance.userId);
        var time = Saver.GetInt("GiftPackTipTime" + MyselfModel.Instance.userId);
        view.tip.type.selectedIndex = bol == 0 || (time == 0 || !TimeUtil.IsSameDayInt(time))?0:1;
        EventManager.Instance.AddEventListener(RechargeEvent.GiftPackInfo, UpdateData);
    }
    private void UpdateData()
    {
        if(PopGiftModel.Instance.giftPackList.Count <= 0)
        {
            Close();
            return;
        }
        curIndex = PopGiftModel.Instance.GetGiftIndex(curId);
        UpdateInfo();
        UpdateBtnStatus();
        UpdatePageList();
    }
    private void UpdateInfo()
    {
        giftData = PopGiftModel.Instance.giftPackList[curIndex];
        curId = giftData.id;
        var giftInfo = PopGiftModel.Instance.GetGiftPackInfo((int)giftData.id);
        var flowerVo = GetIsFlower(giftInfo.RewardPropss);
        SetBg(view.bg, "GiftPack/gift_bg/" + giftInfo.UiContent + "png");
        StringUtil.SetBtnTab(view.buy_btn, Lang.GetValue("recharge_main_18", (giftInfo.Price / 10).ToString()));
        StringUtil.SetBtnTab3(view.buy_btn, Lang.GetValue("recharge_main_18", giftInfo.OriginalPrice));
        var discount = ((giftInfo.Price / 10) / float.Parse(giftInfo.OriginalPrice))*10;
        view.numLab.text = discount.ToString();
        rewardData = giftInfo.RewardPropss;
        view.list.numItems = rewardData.Length;
        
        if (flowerVo != null)
        {
            view.flower_img.visible = true;
            view.spine.visible = true;
            view.icon.visible = false;
            view.title_img.url = "GiftPack/ELIDA_syh_tcslb_zi.png";
            view.flower_img.url = ImageDataModel.Instance.GetIdentifiedFlowerUrl(flowerVo);
            view.titleLab.text = Lang.GetValue(flowerVo.Name);
            view.flower_grp.visible = true;
            SeedCropVO exp = FlowerHandbookModel.Instance.GetCropVoByBook(flowerVo.ItemDefId);
            var seedCondition = FlowerHandbookModel.Instance.GetStaticSeedCondition1(flowerVo.ItemDefId);
            var orderVo = OrderModel.Instance.GetOrderInfo(seedCondition.FlowerId);
            view.gold_lab.text = Lang.GetValue("pop_gift_3") + orderVo.Gold;
            view.cash_lab.text = Lang.GetValue("pop_gift_4") + orderVo.Experience;
        }
        else
        {
            view.flower_img.visible = false;
            view.spine.visible = false;
            view.icon.visible = true;
            view.flower_grp.visible = false;
            view.titleLab.text = Lang.GetValue(giftInfo.Name);

            view.title_img.url = "GiftPack/ELIDA_syh_tcslb_djlbzi.png";
            view.icon.url = "GiftPack/gift_icon/ELIDA_syh_tcslb_daojuhe01.png";
        }
        if(timer != null)
        {
            timer.Clear();
            timer = null;
        }
        int endTime = (int)giftData.endTime - (int)ServerTime.Time;
        if(endTime > 0)
        {
            timer = new CountDownTimer(view.timeLab, endTime, false);
            timer.prefixString = Lang.GetValue("pop_gift_2");
            timer.Run();
        }

        
        
    }

    private void UpdateBtnStatus()
    {
        view.left_btn.visible = curIndex > 0;
        view.right_btn.visible = curIndex < (PopGiftModel.Instance.giftPackList.Count - 1);
    }
    private Module_item_defConfig GetIsFlower(RewardPropsObject[] RewardPropss)
    {
        foreach(var value in RewardPropss)
        {
            var itemVo = ItemModel.Instance.GetItemByEntityID(value.EntityID);
            if(itemVo.Type == 4105)
            {
                return itemVo;
            }
        }
        return null;
    }
    private void RenderList(int index,GObject item)
    {
        var cell = item as fun_PopGift.reward_item;
        var info = rewardData[index];
        var itemVo = ItemModel.Instance.GetItemByEntityID(info.EntityID);
        cell.bg.url = ImageDataModel.Instance.GetItemQuality(itemVo.Quality);
        cell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        cell.countLab.text = info.Value.ToString();
        UILogicUtils.SetItemShow(cell, itemVo.ItemDefId);
    }

    private void RenderPageItem(int index,GObject item)
    {
        var cell = item as fun_PopGift.btn;
        var info = PopGiftModel.Instance.giftPackList[index];
        if (timerMap.ContainsKey(index))
        {
            if(timerMap[index] != null)
            {
                timerMap[index].Clear();
                timerMap[index] = null;
            }
            
        }
        else
        {
            timerMap.Add(index, null);
        }
        int endTime = (int)info.endTime - (int)ServerTime.Time;
        var itemTime = new CountDownTimer(cell.timeLab, endTime);
        timerMap[index] = itemTime;
        cell.data = index;
        cell.onClick.Add(SelectGift);
    }

    private void SelectGift(EventContext context)
    {
        var index = (int)(context.sender as GComponent).data;
        if(curIndex != index)
        {
            curIndex = index;
            UpdateInfo();
            UpdateBtnStatus();
        }
    }
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
        if (timer != null)
        {
            timer.Clear();
            timer = null;
        }
        foreach (var time in timerMap.Values)
        {
            time.Clear();
        }
        EventManager.Instance.RemoveEventListener(RechargeEvent.GiftPackInfo, UpdateData);
    }
}

