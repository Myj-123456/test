using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class DiamondDrawView
{
   private fun_Draw.daimond_draw_view view;
    private int activityId;
    private CountDownTimer timer;
    private bool skip;
    public DiamondDrawView(fun_Draw.daimond_draw_view ui)
    {
        view = ui;
        StringUtil.SetBtnTab(view.detail_btn, Lang.GetValue("details_title"));
        StringUtil.SetBtnTab(view.exchange_btn, Lang.GetValue("Target_txt6"));

        StringUtil.SetBtnTab(view.one_com.one_btn, Lang.GetValue("diamond_draw_1"));
        StringUtil.SetBtnTab(view.ten_com.ten_btn, Lang.GetValue("diamond_draw_2"));

        view.one_com.one_btn.onClick.Add(() =>
        {
            var drawInfo = DrawModel.Instance.GetDrawInfo(activityId);
            var itemVo = ItemModel.Instance.GetItemByEntityID(drawInfo.DrawItems[0].EntityID);
            var count = StorageModel.Instance.GetItemCount(drawInfo.DrawItems[0].EntityID);
            if (count < 1)
            {
                UILogicUtils.ItemUnder(itemVo.ItemDefId);
                return;
            }
            DrawController.Instance.ReqDrawCard((uint)activityId, 1);
        });

        view.ten_com.ten_btn.onClick.Add(() =>
        {
            var drawInfo = DrawModel.Instance.GetDrawInfo(activityId);
            var itemVo = ItemModel.Instance.GetItemByEntityID(drawInfo.DrawItems[0].EntityID);
            var count = StorageModel.Instance.GetItemCount(drawInfo.DrawItems[0].EntityID);
            if (count < 1)
            {
                UILogicUtils.ItemUnder(itemVo.ItemDefId);
                return;
            }
            DrawController.Instance.ReqDrawCard((uint)activityId, 10);
        });
        view.skin_btn.onClick.Add(() =>
        {
            view.skin_btn.status.selectedIndex = view.skin_btn.status.selectedIndex == 0 ? 1 : 0;
            skip = view.skin_btn.status.selectedIndex == 1;
        });
        view.add_btn.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<RechargeMainView>(UIName.RechargeMainView, 3);
        });

        view.spine.url = "flowers/40011110";
        //view.spine.url = "flowers/" + reward.ItemDefId;
        view.spine.forcePlay = true;
        view.spine.loop = true;
        view.spine.animationName = "step_" + 3 + "_idle";


        EventManager.Instance.AddEventListener(ActivityEvent.DiamondDraw, OnShown);
        EventManager.Instance.AddEventListener(RechargeEvent.DrawGift, OnShown);
        EventManager.Instance.AddEventListener<uint>(SystemEvent.UpdateProfile, UpdateCurrency);
    }

    public void OnShown()
    {
        UpdateData();
    }
    private void UpdateData()
    {
        activityId = DrawModel.Instance.GetActivityId(ActivityType.Diamond_Draw);
        var activityInfo = DrawModel.Instance.GetGameEventInfo(activityId);
        
        var drawInfo = DrawModel.Instance.GetDrawInfo(activityId);
        var itemVo = ItemModel.Instance.GetItemByEntityID(drawInfo.DrawItems[0].EntityID);
        view.one_com.cost_img.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        view.ten_com.cost_img.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        view.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);

        var count = StorageModel.Instance.GetItemCount(itemVo.ItemDefId);
        UpdateCurrency((uint)itemVo.ItemDefId);
        view.one_com.numLab.text = "x1";
        view.ten_com.numLab.text = "x10";
        var num = drawInfo.MustGetTime - DrawModel.Instance.diamondDrawData.drawInfo.luckyValue;
        view.times_Lab.text = num + Lang.GetValue("fun_boon_4");
        var reward = DrawModel.Instance.GetBigItem(activityId);
        view.nameLab.text = Lang.GetValue(reward.Name);
        if (view.spine.url != reward.ItemDefId.ToString())
        {
            //view.spine.url = "flowers/" + reward.ItemDefId;
            //view.spine.forcePlay = true;
            //view.spine.loop = true;
            //view.spine.animationName = "step_" + 3 + "_idle";

        }

    }
    private void UpdateCurrency(uint itemId)
    {
        if (itemId == (uint)BaseType.CASH)
        {
            var count = StorageModel.Instance.GetItemCount((int)itemId);
            view.numLab.text = count.ToString();
        }
           
    }
    public void OnHide()
    {
        
    }
}

