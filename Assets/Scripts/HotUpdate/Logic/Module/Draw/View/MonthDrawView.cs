using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using ADK;

public class MonthDrawView
{
   private fun_Draw.flower_draw_view view;
    private int activityId;
    private CountDownTimer timer;
    private bool skip;
   public MonthDrawView(fun_Draw.flower_draw_view ui)
    {
        view = ui;
        StringUtil.SetBtnTab(view.detail_btn, Lang.GetValue("details_title"));
        StringUtil.SetBtnTab(view.change_btn, Lang.GetValue("Target_txt6"));
        view.skipLab.text = Lang.GetValue("draw_1");
        
        skip = false;
        view.one_btn.onClick.Add(() =>
        {
            var drawInfo = DrawModel.Instance.GetDrawInfo(activityId);
            var itemVo = ItemModel.Instance.GetItemByEntityID(drawInfo.DrawItems[0].EntityID);
            var count = StorageModel.Instance.GetItemCount(drawInfo.DrawItems[0].EntityID);
            if(count < 1)
            {
                UILogicUtils.ItemUnder(itemVo.ItemDefId);
                return;
            }
            DrawController.Instance.ReqDrawCard((uint)activityId, 1);
        });
        view.ten_btn.onClick.Add(() =>
        {
            var drawInfo = DrawModel.Instance.GetDrawInfo(activityId);
            var itemVo = ItemModel.Instance.GetItemByEntityID(drawInfo.DrawItems[0].EntityID);
            var count = StorageModel.Instance.GetItemCount(drawInfo.DrawItems[0].EntityID);
            if (count < 10)
            {
                UILogicUtils.ItemUnder(itemVo.ItemDefId);
                return;
            }
            DrawController.Instance.ReqDrawCard((uint)activityId, 10);
        });

        view.skip_btn.onClick.Add(() =>
        {
            view.skip_btn.status.selectedIndex = view.skip_btn.status.selectedIndex == 0 ? 1 : 0;
            skip = view.skip_btn.status.selectedIndex == 1;
        });
        view.add_btn.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<DrawGiftWindow>(UIName.DrawGiftWindow, activityId);
        });
        view.gift_btn.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<DrawGiftWindow>(UIName.DrawGiftWindow, activityId);
        });
        view.spine.url = "flowers/40011110";
        //view.spine.url = "flowers/" + reward.ItemDefId;
        view.spine.forcePlay = true;
        view.spine.loop = true;
        view.spine.animationName = "step_" + 3 + "_idle";

        view.spine1.url = "choukbj";
        view.spine1.forcePlay = true;
        view.spine1.loop = true;
        view.spine1.animationName = "idle";

        view.one_btn.spine.url = "choukann";
        view.one_btn.spine.loop = true;
        view.one_btn.spine.animationName = "idle2";

        view.ten_btn.spine.url = "choukann";
        view.ten_btn.spine.loop = true;
        view.ten_btn.spine.animationName = "idle1";

        EventManager.Instance.AddEventListener(ActivityEvent.MonthDraw, OnShown);
        EventManager.Instance.AddEventListener(RechargeEvent.DrawGift, OnShown);
    }

    public void OnShown()
    {
        UpdateData();
        UpdateTime();
    }

    private void UpdateData()
    {
        activityId = DrawModel.Instance.GetActivityId(ActivityType.Month_Draw);
        var activityInfo = DrawModel.Instance.GetGameEventInfo(activityId);
        StringUtil.SetBtnTab(view.gift_btn, Lang.GetValue("Draw_Gift_" + activityId));
        var drawInfo = DrawModel.Instance.GetDrawInfo(activityId);
        var itemVo = ItemModel.Instance.GetItemByEntityID(drawInfo.DrawItems[0].EntityID);
        view.one_btn.cost_img.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        view.ten_btn.cost_img.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        view.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);

        var count = StorageModel.Instance.GetItemCount(itemVo.ItemDefId);
        view.numLab.text = count.ToString();

        view.one_btn.numLab.text = "x1";
        view.ten_btn.numLab.text = "x10";
        var num = drawInfo.MustGetTime - DrawModel.Instance.monthDrawData.drawInfo.luckyValue;
        view.tipLab.text = Lang.GetValue("draw_2",num.ToString());
        
        var reward = DrawModel.Instance.GetBigItem(activityId);
        if (reward != null)
        {
            view.nameLab.text = Lang.GetValue(reward.Name);
            if (view.spine.url != reward.ItemDefId.ToString())
            {
                view.spine.url = "flowers/" + reward.ItemDefId;
                view.spine.forcePlay = true;
                view.spine.loop = true;
                view.spine.animationName = "step_" + 3 + "_idle";
            }
        }
    }

    private void UpdateTime()
    {
        if(timer != null)
        {
            timer.Clear();
            timer = null;
        }
        var activityId = DrawModel.Instance.GetActivityId(ActivityType.Month_Draw);
        var activityInfo = DrawModel.Instance.GetGameEventInfo(activityId);
        var endTime = TimeUtil.GetNumericTime(activityInfo.WeixinEndTime) - ServerTime.Time;
        timer = new CountDownTimer(view.timeLab, (int)endTime,false);
        timer.prefixString = Lang.GetValue("text_card4");
        timer.Run();
        timer.CompleteCallBacker = () =>
        {
            UIManager.Instance.ClosePanel(UIName.DrawMainView);
        };
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

