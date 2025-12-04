using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using Elida.Config;
using ADK;

public class RechargeGiftView
{
    private CountDownTimer timer;
    private fun_Recharge.gift_view view;
    private List<Ft_diamond_valueConfig> listData;
    // Start is called before the first frame update
    public RechargeGiftView(fun_Recharge.gift_view ui)
    {
        view = ui;
        
        view.list.height = view.height / 2 + 163;
        view.list.itemRenderer = RenderList;
        EventManager.Instance.AddEventListener(RechargeEvent.Normal, UpdateList);
        EventManager.Instance.AddEventListener(RechargeEvent.RechargeInfo, UpdateList);
        EventManager.Instance.AddEventListener(PlayerEvent.GameCrossDay, UpdateList);
    }

    public void OnShown()
    {
        UpdateList();
    }
    private void UpdateList()
    {
        listData = RechargeModel.Instance.GetGiftList();
        view.list.numItems = listData.Count;
    }
    private void RenderList(int index,GObject item)
    {
        var cell = item as fun_Recharge.gift_item;
        var info = listData[index];
        cell.nameLab.text = Lang.GetValue(info.Title);
        cell.buy_btn.data = index;
        if(info.LimitConfigs[0] != 0)
        {
            cell.limit.selectedIndex = 1;
            var count = RechargeModel.Instance.haveDiamondValue.ContainsKey((uint)info.IndexId) ? info.LimitConfigs[1] - RechargeModel.Instance.haveDiamondValue[(uint)info.IndexId] : info.LimitConfigs[1];
            
            if(info.LimitConfigs[0] == 1)
            {
                cell.limitLab.text = Lang.GetValue("recharge_main_25", count + "/" + info.LimitConfigs[1]);
            }
            else if(info.LimitConfigs[0] == 2)
            {
                cell.limitLab.text = Lang.GetValue("recharge_main_26", count + "/" + info.LimitConfigs[1]);
            }
            else if (info.LimitConfigs[0] == 3)
            {
                cell.limitLab.text = Lang.GetValue("recharge_main_28", count + "/" + info.LimitConfigs[1]);
            }
            
            cell.buy_btn.enabled = count > 0;
        }
        else
        {
            cell.limit.selectedIndex = 0;
            cell.buy_btn.enabled = true;
        }
        if(info.Type == (int)E_DIAMOND_VALUE_TYPE.DAILY)
        {
            StringUtil.SetBtnTab(cell.buy_btn, Lang.GetValue("text_breed38"));
            if (timer != null)
            {
                timer.Clear();
                timer = null;
            }
            if (RechargeModel.Instance.haveDiamondValue.ContainsKey((uint)info.IndexId) && RechargeModel.Instance.haveDiamondValue[(uint)info.IndexId] >= info.LimitConfigs[1])
            {
                var endTime = GetNextDayTime();
                if(endTime > 0)
                {
                    timer = new CountDownTimer(cell.timeLab, endTime);
                    timer.CompleteCallBacker = () =>
                    {

                    };
                    cell.buy_btn.visible = false;
                }
                else
                {
                    cell.buy_btn.visible = true;
                }
                
            }
            else
            {
                cell.buy_btn.enabled = true; 
            }
        }
        else
        {
            var rate = Mathf.Floor((info.OriginalPrice * 100f) / info.Price);
            cell.rareNum.text = rate + "%";
            StringUtil.SetBtnTab(cell.buy_btn, Lang.GetValue("recharge_main_18", (info.Price / 10).ToString()));
        }
        cell.itemStatus.selectedIndex = info.Items.Length - 1;
        for(int i = 0;i < info.Items.Length; i++)
        {
            var reward = cell.GetChild("item" + i) as fun_Recharge.reward_item1;
            var rewardInfo = info.Items[i];
            var itemVo = ItemModel.Instance.GetItemByEntityID(rewardInfo.EntityID);
            reward.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
            reward.countLab.text = TextUtil.ChangeCoinShow(rewardInfo.Value);
            UILogicUtils.SetItemShow(reward, itemVo.ItemDefId);
        }
        cell.rare.selectedIndex = info.OriginalPrice != info.Price ? 1 : 0;
        
        cell.buy_btn.onClick.Add(OnClick);

    }
    private void OnClick(EventContext context)
    {
        var index = (int)(context.sender as GComponent).data;
        var info = listData[index];
        if (info.Type == (int)E_DIAMOND_VALUE_TYPE.DAILY)
        {
            if (RechargeModel.Instance.haveDiamondValue.ContainsKey((uint)info.IndexId) && RechargeModel.Instance.haveDiamondValue[(uint)info.IndexId] > 0)
            {

            }
            else
            {
                RechargeController.Instance.ReqRechargeFree(2, (uint)info.IndexId);
            }
        }
        else
        {
            RechargeController.Instance.ReqPlaceOrder(2, (uint)info.IndexId);
        }
    }
    private int GetNextDayTime()
    {
        var now = TimeUtil.GetDateTime(ServerTime.Time);
        var next = now.Date.AddDays(1);
        var timeUntilNextDay = next - now;
        return (int)timeUntilNextDay.TotalSeconds;
    }

    public void OnHide() 
    {
        if (timer != null)
        {
            timer.Clear();
            timer = null;
        }
    }
}
