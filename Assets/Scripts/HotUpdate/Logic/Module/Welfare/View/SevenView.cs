using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class SevenView
{
   private fun_Welfare.seventh_sign_view view;
    private int tabType;

   public SevenView(fun_Welfare.seventh_sign_view ui)
    {
        view = ui;
        InitDayItem();
        view.list.itemRenderer = RenderList;
        view.getBtn.onClick.Add(() =>
        {
            WelfareController.Instance.ReqDailyLoginAward();
        });
        EventManager.Instance.AddEventListener(WelfareEvent.DailyLoginAward, UpdateData);
        EventManager.Instance.AddEventListener(PlayerEvent.GameCrossDay, UpdateData);
    }

    private void InitDayItem()
    {
        for(int i = 0;i < SeventhSignModel.Instance.sevenList.Count; i++)
        {
            var cell = view.GetChild("item" + (i + 1)) as fun_Welfare.seventh_sign_item;
            cell.dayLab.text = Lang.GetValue("activity_days", TextUtil.ToChineseNumber((i + 1)));
            cell.data = i;
            cell.onClick.Add(ChangeTab);
        }
    }
    private void ChangeTab(EventContext context)
    {
        var idx = (int)(context.sender as GComponent).data;
        if(idx != tabType)
        {
            tabType = idx;
            UpdateData();
        }
    }
    public void OnShown()
    {
        tabType = (int)WelfareModel.Instance.currentDay - 1;
        UpdateData();
    }
    private void UpdateData()
    {
        if(tabType == (int)WelfareModel.Instance.currentDay - 1 && !WelfareModel.Instance.todayHaveDraw)
        {
            view.getBtn.enabled = true;
            StringUtil.SetBtnTab(view.getBtn, Lang.GetValue("common_claim_button"));
        }else if(tabType < (int)WelfareModel.Instance.currentDay - 1 || (tabType == (int)WelfareModel.Instance.currentDay - 1 && WelfareModel.Instance.todayHaveDraw))
        {
            view.getBtn.enabled = false;
            StringUtil.SetBtnTab(view.getBtn, Lang.GetValue("invite_friends_11"));
        }
        else if(tabType == (int)WelfareModel.Instance.currentDay)
        {
            view.getBtn.enabled = false;
            StringUtil.SetBtnTab(view.getBtn, "明日可领取");
        }
        else
        {
            view.getBtn.enabled = false;
            StringUtil.SetBtnTab(view.getBtn, "等待中");
        }
        view.list.numItems = SeventhSignModel.Instance.sevenList[tabType].Awards.Length;
        UpdateDayItem();
    }
    private void UpdateDayItem()
    {
        for (int i = 0; i < SeventhSignModel.Instance.sevenList.Count; i++)
        {
            var cell = view.GetChild("item" + (i + 1)) as fun_Welfare.seventh_sign_item;
            if(WelfareModel.Instance.currentDay > (i + 1) || (WelfareModel.Instance.currentDay == (i + 1) && WelfareModel.Instance.todayHaveDraw))
            {
                cell.status.selectedIndex = 1;
            }
            else
            {
                cell.status.selectedIndex = 0;
            }

        }
    }
    private void RenderList(int index,GObject item)
    {
        var cell = item as fun_Welfare.reward_item;
        var info = SeventhSignModel.Instance.sevenList[tabType].Awards[index];
        var itemVo = ItemModel.Instance.GetItemByEntityID(info.EntityID);
        cell.bg.url = ImageDataModel.Instance.GetItemQuality(itemVo.Quality);
        cell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        cell.numLab.text = info.Value.ToString();
        UILogicUtils.SetItemShow(cell, itemVo.ItemDefId);
    }
    public void OnHide()
    {
        
    }
}

