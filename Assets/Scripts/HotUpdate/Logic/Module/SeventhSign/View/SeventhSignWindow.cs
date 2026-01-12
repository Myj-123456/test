
using FairyGUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using ADK;
using Elida.Config;

public class SeventhSignWindow : BaseWindow
{
    private fun_Welfare.SeventhSign view;
    private int tabType;
    public SeventhSignWindow()
    {
        packageName = "fun_Welfare";
        // 设置委托
        BindAllDelegate = fun_Welfare.fun_WelfareBinder.BindAll;
        CreateInstanceDelegate = fun_Welfare.SeventhSign.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        view = ui as fun_Welfare.SeventhSign;
        SetBg(view.bg, "Welfare/ELIDA_qrdl_tcbg.png");

        InitDayItem();
        view.list.itemRenderer = RenderList;
        view.getBtn.onClick.Add(() =>
        {
            WelfareController.Instance.ReqDailyLoginAward();
        });
        var flowerVo = GetFlowerItem();
        if (flowerVo != null)
        {
            var flowerInfo = FlowerHandbookModel.Instance.GetStaticSeedCondition1(flowerVo.ItemDefId);
            if (view.spine.url == "" || view.spine.url != flowerInfo.FlowerId.ToString())
            {
                //view.spine.url = "flowers/" + flowerInfo.FlowerId;
                view.spine.url = "flowers/" + 40011145;
                view.spine.loop = true;
                view.spine.animationName = "step_" + 3 + "_idle";
            }
            view.nameLab.text = Lang.GetValue(flowerVo.Name);
            var condition = FlowerHandbookModel.Instance.GetStaticSeedCondition1(flowerVo.ItemDefId);

            view.name_bg.url = "HandBookNew/name_bg_small_color_" + condition.FlowerQuality + ".png";
            view.rare_img.url = "HandBookNew/rare_icon_" + condition.FlowerQuality + ".png";
        }
        EventManager.Instance.AddEventListener(WelfareEvent.DailyLoginAward, UpdateData);
        EventManager.Instance.AddEventListener(PlayerEvent.GameCrossDay, UpdateData);
    }



    private void InitDayItem()
    {
        for (int i = 0; i < SeventhSignModel.Instance.sevenList.Count; i++)
        {
            var cell = view.GetChild("item" + (i + 1)) as fun_Welfare.seventh_sign_item;
            cell.dayLab.text = Lang.GetValue("activity_days", (i + 1).ToString());
            if (i == 6)
            {
                cell.dayLab1.text = Lang.GetValue("activity_days", (i + 1).ToString());
                var flowerVo = GetFlowerItem();
                if (flowerVo != null)
                {
                    var flowerInfo = FlowerHandbookModel.Instance.GetStaticSeedCondition1(flowerVo.ItemDefId);
                    var flowerItem = ItemModel.Instance.GetItemById(flowerInfo.FlowerId);
                    if (flowerItem != null)
                    {

                        cell.pic.url = ImageDataModel.Instance.GetIdentifiedFlowerUrl(flowerItem);
                    }
                    cell.nameLab.text = Lang.GetValue(flowerVo.Name);
                }

            }
            cell.data = i;
            cell.onClick.Add(ChangeTab);
        }
    }
    private void ChangeTab(EventContext context)
    {
        var idx = (int)(context.sender as GComponent).data;
        if (idx != tabType)
        {
            tabType = idx;
            UpdateData();
        }
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        tabType = (int)WelfareModel.Instance.currentDay - 1;
        UpdateData();

    }
    private void UpdateData()
    {
        if (WelfareModel.Instance.status == 2)
        {
            Close();
            return;
        }
        if (tabType == (int)WelfareModel.Instance.currentDay - 1 && !WelfareModel.Instance.todayHaveDraw)
        {
            view.getBtn.enabled = true;
            StringUtil.SetBtnTab(view.getBtn, Lang.GetValue("common_claim_button"));
        }
        else if (tabType < (int)WelfareModel.Instance.currentDay - 1 || (tabType == (int)WelfareModel.Instance.currentDay - 1 && WelfareModel.Instance.todayHaveDraw))
        {
            view.getBtn.enabled = false;
            StringUtil.SetBtnTab(view.getBtn, Lang.GetValue("invite_friends_11"));
        }
        else if (tabType == (int)WelfareModel.Instance.currentDay)
        {
            view.getBtn.enabled = false;
            StringUtil.SetBtnTab(view.getBtn, Lang.GetValue("tomorrowcanclaim_txt"));
        }
        else
        {
            view.getBtn.enabled = false;
            StringUtil.SetBtnTab(view.getBtn, Lang.GetValue("waiting_txt"));
        }
        view.sub_title.text = Lang.GetValue("seventh_sign_3", TextUtil.ToChineseNumber(tabType + 1));
        view.list.numItems = SeventhSignModel.Instance.sevenList[tabType].Awards.Length;
        UpdateDayItem();
    }
    private void UpdateDayItem()
    {
        for (int i = 0; i < SeventhSignModel.Instance.sevenList.Count; i++)
        {
            var cell = view.GetChild("item" + (i + 1)) as fun_Welfare.seventh_sign_item;
            if (WelfareModel.Instance.currentDay > (i + 1) || (WelfareModel.Instance.currentDay == (i + 1) && WelfareModel.Instance.todayHaveDraw))
            {
                cell.status.selectedIndex = 1;
            }
            else
            {
                cell.status.selectedIndex = 0;
            }

        }
    }
    private void RenderList(int index, GObject item)
    {
        var cell = item as fun_Welfare.reward_item1;
        var info = SeventhSignModel.Instance.sevenList[tabType].Awards[index];
        var itemVo = ItemModel.Instance.GetItemByEntityID(info.EntityID);
        cell.bg.url = ImageDataModel.Instance.GetItemQuality(itemVo.Quality);
        cell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        cell.numLab.text = info.Value.ToString();
        UILogicUtils.SetItemShow(cell, itemVo.ItemDefId);
    }
    private Module_item_defConfig GetFlowerItem()
    {
        var rewards = SeventhSignModel.Instance.sevenList[6].Awards;
        foreach (var value in rewards)
        {
            var item = ItemModel.Instance.GetItemByEntityID(value.EntityID);
            if (item.Type == 4105)
            {
                return item;
            }
        }
        return null;
    }
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

