
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using protobuf.friend;
using ADK;

public class RecycleWindow : BaseWindow
{
    private fun_FriendsTrade_New.recycleView view;
    private I_GRID_VO stall;

    public RecycleWindow()
    {
        packageName = "fun_FriendsTrade_New";
        // 设置委托
        BindAllDelegate = fun_FriendsTrade_New.fun_FriendsTrade_NewBinder.BindAll;
        CreateInstanceDelegate = fun_FriendsTrade_New.recycleView.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        view = ui as fun_FriendsTrade_New.recycleView;
        SetBg(view.bg, "Common/ELIDA_common_littledi01.png");

        view.tipLab.text = Lang.GetValue("trade_3");
        StringUtil.SetBtnTab(view.cancel_btn, Lang.GetValue("common_button_cancel"));
        StringUtil.SetBtnTab(view.btn_sure, Lang.GetValue("general_purpose_02"));

        view.cancel_btn.onClick.Add(() =>
        {
            UIManager.Instance.CloseWindow(UIName.RecycleWindow);
        });

        view.btn_sure.onClick.Add(() =>
        {
            TradeController.Instance.ReqTradeDownShelf(stall.position);
            UIManager.Instance.CloseWindow(UIName.RecycleWindow);
        });
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        stall = data as I_GRID_VO;

        view.lb_count.text = stall.num.ToString();
        view.lb_price.text = (stall.price * stall.num).ToString();
        view.img_item.url = ImageDataModel.Instance.GetIconUrlByEntityId((long)stall.itemId);
        var item = ItemModel.Instance.GetItemById((int)stall.itemId);
        view.lb_info.text = Lang.GetValue("trade_4", Lang.GetValue(item.Name));
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

