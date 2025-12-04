
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using protobuf.friend;
using ADK;

public class TradeBuyWindow : BaseWindow
{
    private fun_FriendsTrade_New.tradeBuyView _view;
    private TradeBuyParams info;
    public TradeBuyWindow()
    {
        packageName = "fun_FriendsTrade_New";
        // 设置委托
        BindAllDelegate = fun_FriendsTrade_New.fun_FriendsTrade_NewBinder.BindAll;
        CreateInstanceDelegate = fun_FriendsTrade_New.tradeBuyView.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        _view = ui as fun_FriendsTrade_New.tradeBuyView;
        SetBg(_view.bg, "Common/ELIDA_common_littledi01.png");
        //_view.btn_sure.title = Lang.GetValue("common_button_buy");
        StringUtil.SetBtnTab(_view.btn_sure, Lang.GetValue("common_button_buy"));
        _view.password_input.maxLength = 6;
        _view.password_input.restrict = "[0-9]*";
        _view.btn_sure.onClick.Add(() =>
        {
            string password = "";
            if (info.stall.setPassword)
            {
                password = _view.password_input.text;
                if (!StringUtil.VerifyPassword(password))
                {
                    UILogicUtils.ShowNotice(Lang.GetValue("FriendsDeal_104"));
                    return;
                }
            }
            info.fun.Invoke(password);
            UIManager.Instance.CloseWindow(UIName.TradeBuyWindow);
        });

        _view.close_btn.onClick.Add(OnClose);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        info = data as TradeBuyParams;
        var item = ItemModel.Instance.GetItemById((int)info.stall.itemId);
        _view.img_item.url = ImageDataModel.Instance.GetIconUrl(item);
        _view.lb_count.text = "x" + info.stall.num;
        _view.lb_info.text = Lang.GetValue("FriendsDeal_19", (info.stall.price * info.stall.num).ToString(), Lang.GetValue(item.Name));
        if (info.stall.setPassword)
        {
            _view.status.selectedIndex = 1;
            _view.password_input.text = "";
        }
        else
        {
            _view.status.selectedIndex = 0;
        }

    }

    private void OnClose()
    {
        if (info.closeFun != null)
        {
            info.closeFun();
        }
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

