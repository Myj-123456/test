
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using protobuf.friend;
using ADK;

public class TradeMessageWindow : BaseWindow
{
    private fun_FriendsTrade_New.tradeMessage _view;
    private List<I_MESSAGE_LOG> listData;

    public TradeMessageWindow()
    {
        packageName = "fun_FriendsTrade";
        // 设置委托
        BindAllDelegate = fun_FriendsTrade_New.fun_FriendsTrade_NewBinder.BindAll;
        CreateInstanceDelegate = fun_FriendsTrade_New.tradeMessage.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        _view = ui as fun_FriendsTrade_New.tradeMessage;
        SetBg(_view.bg, "Common/ELIDA_common_bigdi01.png");
        //_view.lb_title.text = Lang.GetValue("FriendsDeal_11");
        _view.lb_tip.text = Lang.GetValue("text_message1");

        StringUtil.SetBtnTab(_view.tip, "暂无交易信息");
        _view.ls_message.itemRenderer = MessageRenderer;
        _view.ls_message.SetVirtual();

        EventManager.Instance.AddEventListener(TradeEvent.Message, UpdateList);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        TradeController.Instance.ReqMessage();
    }

    private void UpdateList()
    {
        listData = TradeModel.Instance.messageList;
        _view.ls_message.numItems = listData.Count;
        _view.ls_message.scrollPane.ScrollTop();
        _view.tip.visible = listData.Count <= 0;
    }

    private void MessageRenderer(int index, GObject item)
    {
        fun_FriendsTrade_New.tradeMessageCell cell = item as fun_FriendsTrade_New.tradeMessageCell;
        var head = cell.head as common_New.MoonFestivalHead;
        var message = listData[index];
        cell.txt_userName.text = message.userInfo.townName;
        cell.txt_lv.text = message.userInfo.userLevel.ToString();
        head.pic.url = "Avatar/ELIDA_common_touxiangdi01.png";
        cell.txt_date.text = TimeUtil.GenerateTimeDesc((int)message.operateTime);
        var itemInfo = ItemModel.Instance.GetItemById((int)message.itemId);
        cell.txt_info_0.text = Lang.GetValue("FriendsDeal_10", message.num.ToString(), Lang.GetValue(itemInfo.Name), (message.price * message.num).ToString());
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

