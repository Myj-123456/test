using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class FairyIntoWindow : BaseWindow
{
   private fun_FlowerGold.flower_gold_into_view view;
    private int pos;
    private int fairyId;
    public FairyIntoWindow()
    {
        packageName = "fun_FlowerGold";
        // 设置委托
        BindAllDelegate = fun_FlowerGold.fun_FlowerGoldBinder.BindAll;
        CreateInstanceDelegate = fun_FlowerGold.flower_gold_into_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_FlowerGold.flower_gold_into_view;
        SetBg(view.bg, "Common/ELIDA_common_littledi01.png");
        StringUtil.SetBtnTab(view.sure_btn, Lang.GetValue("levelup_button"));
        view.tipLab.text = Lang.GetValue("pet_22");
        view.item1.onClick.Add(() =>
        {
            if (pos != 0)
            {
                pos = 0;
            }
        });
        view.item2.onClick.Add(() =>
        {
            if (pos != 1)
            {
                pos = 1;
            }
        });
        view.item3.onClick.Add(() =>
        {
            if (pos != 2)
            {
                pos = 2;
            }
        });
        view.sure_btn.onClick.Add(() =>
        {
            FlowerGoldController.Instance.ReqBattleFairy((uint)pos, (uint)fairyId);
            Close();
        });
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        fairyId = (int)data;
        pos = 0;
        view.select.selectedIndex = 0;
        var itemVo = ItemModel.Instance.GetItemById(fairyId);
        //for(int i = 0;i < 3; i++)
        //{
        //    var cell = view.GetChild("item" + (i + 1)) as fun_FlowerGold.flower_gold_into_item;
        //    if(PlayerModel.Instance.pen != null && PlayerModel.Instance.pen.battleFairys != null)
        //    {
        //        if(i < PlayerModel.Instance.pen.battleFairys.Length && PlayerModel.Instance.pen.battleFairys[i] != 0)
        //        {
        //            var fairyVo = ItemModel.Instance.GetItemById((int)PlayerModel.Instance.pen.battleFairys[i]);
        //            cell.icon1.url = ImageDataModel.Instance.GetIconUrl(fairyVo);
        //        }
        //        else
        //        {
        //            cell.icon1.url = "";
        //        }
        //    }
        //    else
        //    {
        //        cell.icon1.url = "";
        //    }
        //}
        view.item1.icon1.url = view.item2.icon1.url = view.item3.icon1.url = "";
        view.item1.icon.url = view.item2.icon.url = view.item3.icon.url = ImageDataModel.Instance.GetIconUrl(itemVo);
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

