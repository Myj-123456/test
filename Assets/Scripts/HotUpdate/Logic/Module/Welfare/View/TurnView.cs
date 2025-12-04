using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class TurnView
{
   private fun_Welfare.turntable_view view;

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
        view.numLab.text = TurnBoxManager.Instance.boxNum + "/" + GlobalModel.Instance.module_profileConfig.keMaxNum;
        view.get_btn.enabled = TurnBoxManager.Instance.boxNum > 0;
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
        
    }
}

