using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using Elida.Config;
using System;

public class CumulativeView
{
   private fun_Recharge.cumulative_view view;
    private List<Ft_recharge_giftConfig> listData;
    private RewardObject[] rewards;
    private int curIndex = 0;
    private string[] txtColorArr = new string[] { "#209323", "#2c93e5", "#f45bfc", "#fb6eaa", "#f5b535", "#b579f5" };
    public CumulativeView(fun_Recharge.cumulative_view ui)
    {
        view = ui;
        StringUtil.SetBtnTab(view.goto_btn, Lang.GetValue("title_recharge"));
        StringUtil.SetBtnTab(view.get_btn, Lang.GetValue("common_claim_button"));
        view.tipLab.text = Lang.GetValue("cumulative_1");
        view.rewardLab.text = Lang.GetValue("cumulative_2");
        view.list.itemRenderer = ListRender;
        view.page_list.itemRenderer = RenderPageList;
        //view.page_list.SetVirtual();
        listData = RechargeModel.Instance.rechargeGiftList;
        view.page_list.numItems = listData.Count;
        view.spine.loop = true;
        view.spine.forcePlay = true;
        view.left_btn.onClick.Add(() =>
        {
            curIndex--;
            UpdateData();
            view.page_list.selectedIndex = curIndex;
            view.page_list.ScrollToView(curIndex);
        });
        view.right_btn.onClick.Add(() =>
        {
            curIndex++;
            UpdateData();
            view.page_list.selectedIndex = curIndex;
            view.page_list.ScrollToView(curIndex);
            //UpdateTestData();
            //view.page_list.scrollPane.posY = (view.page_list.scrollPane.contentHeight - dis2);
        });
        view.get_btn.onClick.Add(() =>
        {
            var info = listData[curIndex];
            RechargeController.Instance.ReqAccRecharge((uint)info.Id);
        });
        EventManager.Instance.AddEventListener(RechargeEvent.AccRecharge, UpdateData);
    }

    //private void UpdateTestData()
    //{
    //    var star = testData[0];
    //    var add = new List<int>();
    //    if(star != 0)
    //    {
    //        for (int i = star - 100;i< star - 1; i++)
    //        {
    //            add.Add(i);
    //        }
    //        add.AddRange(testData);
    //        testData = add;
    //        UpdateTestList();
    //    }
        
    //}

    //private void UpdateTestList()
    //{
    //    view.page_list.numItems = testData.Count;
    //}
    public void OnShown()
    {
        curIndex = GetCurIndex();
        UpdateData();
        view.page_list.ScrollToView(curIndex);
        view.page_list.selectedIndex = curIndex;
    }
    private void UpdateData()
    {
        var info = listData[curIndex];
        view.pro.max = info.AccumulatedRecharge;
        rewards = info.Rewards;
        var flowerVo = GetIsFlower(rewards);
        if(flowerVo != null)
        {
            view.type.selectedIndex = 1;
            
            var flowerInfo = FlowerHandbookModel.Instance.GetStaticSeedCondition1(flowerVo.ItemDefId);
            if (view.spine.url == "" || view.spine.url != flowerInfo.FlowerId.ToString())
            {
                view.spine.url = "flowers/" + flowerInfo.FlowerId;
                view.spine.animationName = "step_" + 3 + "_idle";
            }
            view.nameLab.text = Lang.GetValue(flowerVo.Name);
            var condition = FlowerHandbookModel.Instance.GetStaticSeedCondition1(flowerVo.ItemDefId);
            view.nameLab.strokeColor = StringUtil.HexToColor(txtColorArr[condition.FlowerQuality - 1]);
            view.name_bg.url = "HandBookNew/name_bg_color_" + condition.FlowerQuality + ".png";
            view.rare_img.url = "HandBookNew/rare_icon_" + condition.FlowerQuality + ".png";
        }
        else
        {
            //view.icon.url = info.sho
            view.type.selectedIndex = 0;
        }
        view.pro.value = RechargeModel.Instance.rechargeAmount;
        view.numLab.text = Lang.GetValue("cumulative_3") + RechargeModel.Instance.rechargeAmount;
        view.goto_btn.visible = RechargeModel.Instance.rechargeAmount < info.AccumulatedRecharge;

        view.proLab.text = (RechargeModel.Instance.rechargeAmount > info.AccumulatedRecharge? info.AccumulatedRecharge: RechargeModel.Instance.rechargeAmount) + "/" + info.AccumulatedRecharge;
        view.list.numItems = rewards.Length;
        view.get_btn.visible = RechargeModel.Instance.rechargeAmount >= info.AccumulatedRecharge;
        view.get_btn.enabled = RechargeModel.Instance.rechargeAmount >= info.AccumulatedRecharge ? RechargeModel.Instance.rechargeRewards == null || Array.IndexOf(RechargeModel.Instance.rechargeRewards,(uint)info.Id) == -1: false;
        UpdateBtnStatus();
    }
    private void UpdateBtnStatus()
    {
        if(curIndex <= 0)
        {
            view.left_btn.enabled = false;
        }
        else
        {
            view.left_btn.enabled = true;
        }

        if (curIndex >= (listData.Count - 1))
        {
            view.right_btn.enabled = false;
        }
        else
        {
            view.right_btn.enabled = true;
        }
    }
    private void ListRender(int index,GObject item)
    {
        var cell = item as fun_Recharge.reward_item2;
        var rewardInfo = rewards[index];
        var itemVo = ItemModel.Instance.GetItemByEntityID(rewardInfo.EntityID);
        if(itemVo!= null)
        {
            cell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
            cell.countLab.text = rewardInfo.Value.ToString();
            UILogicUtils.SetItemShow(cell, itemVo.ItemDefId);
        }
        
        cell.bg.url = ImageDataModel.Instance.GetItemQuality(listData[curIndex].Qualitys[index]);
    }

    private void RenderPageList(int index,GObject item)
    {
        var cell = item as fun_Recharge.page_btn1;
        var info = listData[index];
        cell.titleLab.text = Lang.GetValue("recharge_main_18", info.AccumulatedRecharge.ToString());
        cell.data = index;
        cell.onClick.Add(SelectBtn);
    }
    private void SelectBtn(EventContext context)
    {
        var index = (int)(context.sender as GComponent).data;
        if(curIndex != index)
        {
            curIndex = index;
            UpdateData();
        }
    }
    private int GetCurIndex()
    {
        var index = 0;
        for(var i = 0;i < listData.Count; i++)
        {
            if(listData[i].AccumulatedRecharge > RechargeModel.Instance.rechargeAmount)
            {
                index = i;
                break;
            }
        }
        if(index == 0)
        {
            return 0;
        }
        else
        {
            var info = listData[index - 1];
            if(RechargeModel.Instance.rechargeRewards == null || Array.IndexOf(RechargeModel.Instance.rechargeRewards, (uint)info.Id) == -1)
            {
                return index - 1;
            }
            else
            {
                return index;
            }
        }
    }
    private Module_item_defConfig GetIsFlower(RewardObject[] RewardPropss)
    {
        foreach (var value in RewardPropss)
        {
            var itemVo = ItemModel.Instance.GetItemByEntityID(value.EntityID);
            if (itemVo != null && itemVo.Type == 4105)
            {
                return itemVo;
            }
        }
        return null;
    }
    public void OnHide()
    {
        
    }
}

