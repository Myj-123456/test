using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class TurnView
{
   private fun_Welfare.turntable_view view;
   private CountDownTimer countDownTimer;

   public TurnView(fun_Welfare.turntable_view ui)
    {
        view = ui;
        StringUtil.SetBtnTab(view.get_btn, Lang.GetValue("wheel_buy_btn"));
        view.n12.text = Lang.GetValue("turn_02");
        InitItemShow();
        view.get_btn.onClick.Add(() =>
        {
            WelfareController.Instance.ReqTurnTable();
        });
        view.share_btn.n12.text =Lang.GetValue("turn_01");
        view.share_btn.n20.text = Lang.GetValue("text_breed36");
        view.share_btn.onClick.Add(() =>
        {
            WelfareController.Instance.ReqTurnTableByShare();
        });
        StringUtil.SetBtnTab(view.skip_btn,Lang.GetValue("draw_1"));
        view.skip_btn.onClick.Add(() =>
        {

        });
        EventManager.Instance.AddEventListener(WelfareEvent.TurnTable, UpdateData);
    }

    public void OnShown()
    {
        UpdateData();
    }
    private void UpdateData()
    {
        if (TurnBoxManager.Instance.boxNum > 0)
        {
            view.numLab.text = TurnBoxManager.Instance.boxNum + "/" + GlobalModel.Instance.module_profileConfig.keMaxNum;
            view.textColorctrl.selectedIndex = 0;
        }
        else
        {
            view.textColorctrl.selectedIndex = 1;
        }
        view.get_btn.enabled = TurnBoxManager.Instance.boxNum > 0;
        // 管理分享按钮显示和状态
        bool showShare = TurnBoxManager.Instance.boxNum == 0;
        view.share_btn.visible = showShare;
        // 今日是否已分享
        bool hasSharedToday = MyselfModel.Instance.behaviorDaily != null && MyselfModel.Instance.behaviorDaily.turntableShareCnt > 0;
        view.share_btn.enabled = showShare && !hasSharedToday;
        // 更新倒计时显示
        if (TurnBoxManager.Instance.boxNum < GlobalModel.Instance.module_profileConfig.keMaxNum && TurnBoxManager.Instance.timer != null)
        {
            if (countDownTimer != null)
            {
                countDownTimer.Clear();
                countDownTimer = null;
            }
            view.status.selectedIndex = 1;
            var endTime = GlobalModel.Instance.module_profileConfig.keHuifuCd - (int)ServerTime.Time + (int)TurnBoxManager.Instance.time;
            if(endTime > 0)
            {
                countDownTimer = new CountDownTimer(view.time_text, endTime, true, 2);
            }
            
        }
        else
        {
            view.status.selectedIndex = 0;
            if (countDownTimer != null)
            {
                countDownTimer.Clear();
                countDownTimer = null;
            }
        }
    }

    private void InitItemShow()
    {
        var index = 1;
        foreach(var value in WelfareModel.Instance.turnMap)
        {
            var cell = view.com.GetChild("item" + index) as fun_Welfare.turntable_item;
            var itemVo = ItemModel.Instance.GetItemById(value.Value.ItemId);
            cell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
            cell.numLab.text = value.Value.ItemNums[0] + "~" + value.Value.ItemNums[1];
            index++;
        }
    }

    public void OnHide()
    {
        if (countDownTimer != null)
        {
            countDownTimer.Clear();
            countDownTimer = null;
        }
    }
}