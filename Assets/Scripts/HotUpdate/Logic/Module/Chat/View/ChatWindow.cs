using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using System;
using protobuf.guild;
using static protobuf.guild.I_SEND_CHAT_VO;

public class ChatWindow : BaseWindow
{
   private fun_Chat.chatView _view;
    private float messageMaxWidth;
    private float defaultHeight;
    public ChatWindow()
    {
        packageName = "fun_Chat";
        // 设置委托
        BindAllDelegate = fun_Chat.fun_ChatBinder.BindAll;
        CreateInstanceDelegate = fun_Chat.chatView.CreateInstance;
    }

    public override void OnInit()
    {
    
        base.OnInit();
        _view = ui as fun_Chat.chatView;
        SetBg(_view.bg,"Common/ELIDA_common_bigdi01.png");
        //_view.mc_reConnect.visible = false;
        _view.title_txt.text = Lang.GetValue("fun_Chat_1");
        //_view.mc_reConnect.lb_info.text = Lang.GetValue("guild_planting_012");
        StringUtil.SetBtnTab(_view.btn_send, Lang.GetValue("guild_planting_011"));

        //_view.btn_newMessage.onClick.Add(() =>
        //{
        //    _view.btn_newMessage.visible = false;
        //    _view.chatList.ScrollToView(ChatModel.Instance.chatHistory.Count - 1, true);
        //});

        _view.input_msg.maxLength = GlobalModel.Instance.module_profileConfig.persekutuanCharacter;

        _view.chatList.itemRenderer = ChatItemRenderer;

        _view.chatList.scrollPane.onScrollEnd.Add(() =>
        {
            if(_view.chatList.scrollPane.percY >= 1)
            {
                //_view.btn_newMessage.visible = false;
            }
        });
        _view.btn_send.onClick.Add(() =>{
            var msg = _view.input_msg.text.Trim();
            if (msg == "") return;
            var chatContent = new I_SEND_CHAT_VO();
            chatContent.contentType = 1;
            chatContent.content = msg;
            var rederer = new REFERER_CHAT_VO();
            chatContent.referer = rederer;
            ChatController.Instance.ReqGuildChat(chatContent);
            _view.input_msg.text = "";
            OnFindTxtFocusOut();
        });

        var temp = fun_Chat.chatItemRenderer.CreateInstance();
        messageMaxWidth = _view.chatList.width - temp.lb_info.x - 135;
        defaultHeight = temp.height - 30;
        temp = null;
        _view.input_msg.emojies = Emojies.Instance.emojies;
        _view.input_msg.onFocusIn.Add(OnFindTxtFocusIn);
        _view.input_msg.onFocusOut.Add(OnFindTxtFocusOut);
        EventManager.Instance.AddEventListener(ChatEvent.GuildChat, ReflushMessage);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        int len = ChatModel.Instance.chatHistory.Count;
        _view.chatList.numItems = len;
        if(len > 0)
        {
            _view.chatList.ScrollToView(len - 1,false);
        }
    }

    private void ChatItemRenderer(int index,GObject item)
    {
        var cell = item as fun_Chat.chatItemRenderer;
        cell.lb_info.emojies = Emojies.Instance.emojies;
        cell.lb_info2.emojies = Emojies.Instance.emojies;
        var msg = ChatModel.Instance.chatHistory[index];
        var pos = GuildModel.Instance.GetUserData(msg.userInfo.userId);
        if (MyselfModel.Instance.userId == msg.userInfo.userId)
        {
            cell.chatType.selectedIndex = 1;
            AutuAize(cell.lb_info2, msg.chatContent.content, 1, cell);
            cell.head2.img_head.url = "Avatar/ELIDA_common_touxiangdi01.png";
            cell.lb_userName2.text = msg.userInfo.townName;
            cell.txt_lv2.text = msg.userInfo.userLevel.ToString();
            if (pos != 0)
            {
                cell.pos2.visible = true;
                cell.pos2.type.selectedIndex = pos < 3 ? (int)pos - 1 : 2;
                cell.pos2.txt_position.text = GuildModel.Instance.GetPositionName(pos);
            }
            else
            {
                cell.pos2.visible = false;
            }
        }
        else
        {
            cell.chatType.selectedIndex = 0;
            AutuAize(cell.lb_info, msg.chatContent.content, 0, cell);
            cell.head.img_head.url = "Avatar/ELIDA_common_touxiangdi01.png";
            cell.lb_userName.text = msg.userInfo.townName;
            cell.txt_lv.text = msg.userInfo.userLevel.ToString();
            if (pos != 0)
            {
                cell.pos.visible = true;
                cell.pos.type.selectedIndex = pos < 3 ? (int)pos - 1 : 2;
                cell.pos.txt_position.text = GuildModel.Instance.GetPositionName(pos);
            }
            else
            {
                cell.pos.visible = false;
            }
        }

        
        

    }

    private void ReflushMessage()
    {
        var queue = ChatModel.Instance.chatHistory;
        var posY = _view.chatList.scrollPane.posY;
        var contentHeight = _view.chatList.scrollPane.contentHeight;
        var viewHeight = _view.chatList.scrollPane.viewHeight;
        _view.chatList.numItems = queue.Count;
        if (contentHeight > viewHeight)
        {
            if (contentHeight - posY > (viewHeight + 5))
            {//5像素误差
                //_view.btn_newMessage.visible = true;
            }
            else
            {
                //_view.btn_newMessage.visible = false;
                _view.chatList.ScrollToView(queue.Count - 1, true);
            }
        }
        else
        {
            if (contentHeight + defaultHeight > viewHeight)
            {
                _view.chatList.ScrollToView(queue.Count - 1, true);
            }
        }
    }

    private void AutuAize(GRichTextField lable,string text,int type, fun_Chat.chatItemRenderer cell)
    {
        lable.autoSize = AutoSizeType.Both;
        if(type == 1)
        {
            lable.align = AlignType.Right;
        }
        lable.text = text;
        float offsetHeight = lable.height;
        if(lable.width > messageMaxWidth)
        {
            lable.align = AlignType.Left;
            if (type == 1)
            {
                lable.align = AlignType.Left;
            }
            float preHeight = lable.height;
            lable.autoSize = AutoSizeType.Height;
            lable.width = messageMaxWidth;
            offsetHeight = lable.height;
        }
        cell.height = defaultHeight + offsetHeight;
    }


    private void OnFindTxtFocusIn()
    {
        _view.tipLab.visible = false;
    }

    private void OnFindTxtFocusOut()
    {
        _view.tipLab.visible = _view.input_msg.text == "";
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
        _view.chatList.numItems = 0;
    }
}

