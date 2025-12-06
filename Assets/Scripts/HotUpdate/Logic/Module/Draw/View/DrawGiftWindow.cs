using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using ADK;

public class DrawGiftWindow : BaseWindow
{
   private fun_Draw.flower_draw_gift_view view;
    private List<Ft_mallConfig> listData;
   public DrawGiftWindow()
    {
        packageName = "fun_Draw";
        // 设置委托
        BindAllDelegate = fun_Draw.fun_DrawBinder.BindAll;
        CreateInstanceDelegate = fun_Draw.flower_draw_gift_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Draw.flower_draw_gift_view;
        SetBg(view.bg, "Draw/ELIDA_chouka_tmhd_tcdi.png");

        view.list.itemRenderer = RenderList;
        view.list.SetVirtual();
        AddEventListener(RechargeEvent.RechargeInfo, UpdateList);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        var eventId = (int)data;
        listData = DrawModel.Instance.GetMallList(eventId);
        UpdateList();
    }
    private void UpdateList()
    {
        view.list.numItems = listData.Count;
    }
    private void RenderList(int index,GObject item)
    {
        var cell = item as fun_Draw.flower_draw_gift_item;
        var info = listData[index];
        StringUtil.SetBtnTab(cell.buy_btn, Lang.GetValue("recharge_main_18",(info.Price / 10).ToString()));
        var buyCount = RechargeModel.Instance.haveMall.ContainsKey((uint)info.Id) ? RechargeModel.Instance.haveMall[(uint)info.Id] : 0;
        if (info.LimitType == 1)
        {
            var times = info.LimitTimes - buyCount;
            cell.limitLab.text = Lang.GetValue("recharge_main_25", times + "/" + info.LimitTimes);
            cell.buy_btn.enabled = times > 0;
        }
        else if(info.LimitType == 2)
        {
            var times = info.LimitTimes - buyCount;
            cell.limitLab.text = Lang.GetValue("recharge_main_26", times + "/" + info.LimitTimes);
            cell.buy_btn.enabled = times > 0;
        }
        else if(info.LimitType == 3)
        {
            var times = info.LimitTimes - buyCount;
            cell.limitLab.text = Lang.GetValue("recharge_main_28", times + "/" + info.LimitTimes);
            cell.buy_btn.enabled = times > 0;
        }
        else
        {
            cell.buy_btn.enabled = true;
            cell.limitLab.text = "";
        }
        cell.nameLab.text = Lang.GetValue(info.PackName);
        cell.status.selectedIndex = info.RewardPropss.Length - 1;
        for(int i = 0;i < info.RewardPropss.Length; i++)
        {
            var reward = cell.GetChild("item" + (i + 1)) as fun_Draw.reward_item;
            var rewardInfo = info.RewardPropss[i];
            var itemVo = ItemModel.Instance.GetItemByEntityID(rewardInfo.EntityID);
            reward.bg.url = ImageDataModel.Instance.GetItemQuality(itemVo.Quality);
            reward.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
            reward.numLab.text = rewardInfo.Value.ToString();
            UILogicUtils.SetItemShow(reward, itemVo.ItemDefId);
        }
        cell.buy_btn.data = info.Id;
        cell.buy_btn.onClick.Add(BuyGiftBtn);
    }
    private void BuyGiftBtn(EventContext context)
    {
        var id = (int)(context.sender as GComponent).data;
        RechargeController.Instance.ReqPlaceOrder(4, (uint)id);
    }
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

