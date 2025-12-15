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
        StringUtil.SetBtnTab(view.get_btn, Lang.GetValue("common_button_receive"));
        InitItemShow();

        view.get_btn.onClick.Add(() =>
        {
            WelfareController.Instance.ReqTurnTable();
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
        }
        else
        {
            view.textColorctrl.selectedIndex = 1;
        }
        view.get_btn.enabled = TurnBoxManager.Instance.boxNum > 0;
        
        // 更新倒计时显示
        if (TurnBoxManager.Instance.boxNum < GlobalModel.Instance.module_profileConfig.keMaxNum && TurnBoxManager.Instance.timer != null)
        {
            // 清理旧的倒计时器
            if (countDownTimer != null)
            {
                countDownTimer.Clear();
                countDownTimer = null;
            }
            
            // 创建新的倒计时器，将time_text传递给它
            countDownTimer = new CountDownTimer(view.time_text, TurnBoxManager.Instance.timer.time,true,2);
        }
        else
        {
            // 没有倒计时时清空文本
            view.time_text.text = "00:00:00";
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
        // 隐藏时清理倒计时器
        if (countDownTimer != null)
        {
            countDownTimer.Clear();
            countDownTimer = null;
        }
    }
}

