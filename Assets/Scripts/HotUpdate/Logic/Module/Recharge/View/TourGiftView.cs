using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using ADK;
using System;

public class TourGiftView
{
   private fun_Recharge.tour_gift_view view;
    private List<Ft_tour_giftConfig> listData;
   public TourGiftView(fun_Recharge.tour_gift_view ui)
    {
        view = ui;
        view.list_com.list.itemRenderer = RenderList;
        view.list_com.list.SetVirtual();

        view.list_com.list.scrollPane.onScrollEnd.Add(UpdateLeftRight);

        listData = RechargeModel.Instance.GetTourList();

        view.left_btn.onClick.Add(() =>
        {
            if(view.list_com.list.scrollPane.currentPageX <=0)
            {
                return;
            }
            view.list_com.list.scrollPane.SetCurrentPageX(view.list_com.list.scrollPane.currentPageX - 1, true);
        });
        view.right_btn.onClick.Add(() =>
        {
            if (view.list_com.list.scrollPane.currentPageX >= listData.Count - 1)
            {
                return;
            }
            view.list_com.list.scrollPane.SetCurrentPageX(view.list_com.list.scrollPane.currentPageX + 1, true);
        });
    }

    

    public void OnShown()
    {
        EventManager.Instance.AddEventListener(RechargeEvent.GiftPackInfo, UpdateList);
        UpdateList();
    }
    private void UpdateList()
    {
        view.list_com.list.numItems = listData.Count;
    }

    public void RenderList(int index,GObject item)
    {
        var cell = item as fun_Recharge.tour_gift_item;
        var info = listData[index];
        var tourData = PopGiftModel.Instance.GetTourData((uint)info.Id);
        for (int i = 0;i < info.FlowerIds.Length; i++)
        {
            var item_cell = cell.GetChild("item" + (i + 1)) as fun_Recharge.tour_gift_cell;
            var itemVo = ItemModel.Instance.GetItemById(info.FlowerIds[i]);
            var giftVo = PopGiftModel.Instance.GetGiftPackInfo(info.GiftIds[i]);
            
            item_cell.nameLab.text = Lang.GetValue(itemVo.Name);
            var flowerInfo = FlowerHandbookModel.Instance.GetStaticSeedCondition1(itemVo.ItemDefId);
            if (item_cell.spine.url == null || item_cell.spine.url == "" || item_cell.spine.url != flowerInfo.FlowerId.ToString())
            {
                item_cell.spine.loop = true;
                item_cell.spine.forcePlay = true;
                item_cell.spine.url = "flowers/" + flowerInfo.FlowerId;
                item_cell.spine.animationName = "step_" + 3 + "_idle";
            }
            var rewards = GetReward(giftVo.RewardPropss, info.FlowerIds[i]);
            item_cell.list.itemRenderer = (int idx, GObject rewardItem) =>
            {
                var rewardCell = rewardItem as fun_Recharge.reward_item;
                var rewardInfo = rewards[idx];
                var rewardVo = ItemModel.Instance.GetItemByEntityID(rewardInfo.EntityID);
                rewardCell.bg.url = ImageDataModel.Instance.GetItemQuality(rewardVo.Quality);
                rewardCell.pic.url = ImageDataModel.Instance.GetIconUrl(rewardVo);
                rewardCell.countLab.text = rewardInfo.Value.ToString();
                UILogicUtils.SetItemShow(rewardCell, rewardVo.ItemDefId);
            };
            item_cell.list.numItems = rewards.Count;
            if(tourData != null && tourData.rewardIds != null && Array.IndexOf(tourData.rewardIds,(uint)info.GiftIds[i]) != -1)
            {
                item_cell.buy_btn.enabled = false;
                StringUtil.SetBtnTab(item_cell.buy_btn, Lang.GetValue("Target_txt7"));
            }
            else
            {
                item_cell.buy_btn.enabled = true;
                item_cell.buy_btn.data = giftVo.GiftPackageId;
                StringUtil.SetBtnTab(item_cell.buy_btn, Lang.GetValue("recharge_main_18", (giftVo.Price / 10).ToString()));
            }
            item_cell.buy_btn.onClick.Add(BuyGift);
        }
    }
    private void BuyGift(EventContext context)
    {
        var id = (int)(context.sender as GComponent).data;
        RechargeController.Instance.ReqPlaceOrder(2, (uint)id);
    }
    private List<RewardPropsObject> GetReward(RewardPropsObject[] items,int flowerId)
    {
        var rewards = new List<RewardPropsObject>();
        foreach (var value in items)
        {
            if(IDUtil.GetEntityValue(value.EntityID) != flowerId)
            {
                rewards.Add(value);
            }
        }
        return rewards;
    }
    private void UpdateLeftRight()
    {
        view.left_btn.enabled = view.list_com.list.scrollPane.currentPageX > 0;
        view.right_btn.enabled = view.list_com.list.scrollPane.currentPageX < listData.Count - 1;
        view.pageLab.text = (view.list_com.list.scrollPane.currentPageX + 1) + "/" + listData.Count;
    }
    public void OnHide()
    {
        EventManager.Instance.RemoveEventListener(RechargeEvent.GiftPackInfo, UpdateList);
    }
}

