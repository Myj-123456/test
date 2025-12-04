using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using static protobuf.guild.I_SEND_CHAT_VO;
using protobuf.guild;
using static protobuf.guild.S_MSG_FRIEND_CHAT_HISTORY;

public class FrinedChatView
{
   private fun_Chat.friend_chat_view view;
    private float messageMaxWidth;
    private float defaultHeight;
    private int msgNum;
    private float subMaxWidth = 364;
    private REFERER_CHAT_VO rederer;
    private I_FRIEND_CHAT_HISTORY selectChat;
    private FriendChatData curChatData;
    private uint curId;
    public FrinedChatView(fun_Chat.friend_chat_view ui)
    {
        view = ui;
        view.input_msg.emojies = Emojies.Instance.emojies;
        view.input_msg.onFocusIn.Add(OnFindTxtFocusIn);
        view.input_msg.onFocusOut.Add(OnFindTxtFocusOut);
        view.chatList.height = view.btn_send.y - view.pos.y - 76;
        StringUtil.SetBtnTab(view.btn_send, Lang.GetValue("guild_planting_011"));
        StringUtil.SetBtnTab(view.ope_chat.ope.quote_btn, Lang.GetValue("chat_2"));
        StringUtil.SetBtnTab(view.ope_chat.ope.copy_btn, Lang.GetValue("common_hint_copy"));
        StringUtil.SetBtnTab(view.ope_chat.ope.report_btn, Lang.GetValue("chat_3"));

        view.chatList.itemRenderer = ChatItemRenderer;
        view.chatList.SetVirtual();
        view.emojie_view.emojie_list.itemRenderer = EmojiRenderList;
        var temp = fun_Chat.chatItemRenderer1.CreateInstance();
        messageMaxWidth = view.chatList.width - temp.lb_info.x - 200;
        defaultHeight = temp.height - 33;
        temp = null;
        view.ope_chat.rect.onClick.Add(() =>
        {
            view.ope_chat.visible = false;
        });
        view.ope_chat.ope.quote_btn.onClick.Add(() =>
        {
            view.ope_chat.visible = false;
            rederer = new REFERER_CHAT_VO();
            if (selectChat.isSelf)
            {
                rederer.nickName = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_NICKNAME).info;
            }
            else
            {
                var userInfo = FriendChatModel.Instance.GetUserInfo(curId);
                rederer.nickName = userInfo.townName;
            }
            if (selectChat.chatContent.contentType == 1)
            {
                rederer.content = selectChat.chatContent.content;
            }
            else
            {
                var id = int.Parse(selectChat.chatContent.content);
                var info = FriendChatModel.Instance.GetEmojieInfo(id);
                rederer.content = Lang.GetValue(info.Name);
            }
            view.refer_com.visible = true;
            view.refer_com.lab.text = rederer.nickName + "：" + rederer.content;
        });
        view.refer_com.close_btn.onClick.Add(() =>
        {
            view.refer_com.visible = false;
        });
        view.new_msg.onClick.Add(() =>
        {
            msgNum = 0;
            view.new_msg.visible = false;
            view.chatList.scrollPane.ScrollBottom(true);
        });
        view.btn_send.onClick.Add(() => {
            
            var msg = view.input_msg.text.Trim();
            if (msg == "") return;
            var chatContent = new I_SEND_CHAT_VO();
            chatContent.contentType = 1;
            chatContent.content = msg;
            if (view.refer_com.visible)
            {
                chatContent.referer = rederer;
            }
            ChatController.Instance.ReqFriendChat(curId,chatContent);
            view.input_msg.text = "";
            OnFindTxtFocusOut();
        });
        view.emo_btn.onClick.Add(() =>
        {
            view.type.selectedIndex = view.type.selectedIndex == 0 ? 1 : 0;
        });
        view.emojie_view.emojie_list.numItems = FriendChatModel.Instance.emojieList.Count;
        EventManager.Instance.AddEventListener(ChatEvent.FriendChat, ReflushMessage);
        EventManager.Instance.AddEventListener<uint>(ChatEvent.FriendReceiveChat, UpdateChatData);
        EventManager.Instance.AddEventListener(ChatEvent.FriendChatHisTory, OpenInit);
    }

    private void UpdateChatData(uint friendId)
    {
        if(friendId == curChatData.userInfo.userId)
        {
            ReflushMessage();
        }
    }
    

    public  void OnShown(uint friendId)
    {
        msgNum = 0;
        view.ope_chat.visible = false;
        view.new_msg.visible = false;
        view.refer_com.visible = false;
        view.type.selectedIndex = 0;
        curId = friendId;
        ChatController.Instance.ReqFriendChatHisTory(friendId);
        //curChatData = FriendChatModel.Instance.GetFriendChatHistory(friendId);
        //curId = friendId;
        //if (curChatData != null)
        //{

        //}
        //int len = curChatData.chatHistory.Count;
        //view.chatList.numItems = len;
        //msgNum = 0;
        //view.ope_chat.visible = false;
        //view.new_msg.visible = false;
        //view.refer_com.visible = false;
        //if (len > 0)
        //{
        //    view.chatList.ScrollToView(len - 1, false);
        //}
    }

    private void OpenInit()
    {
        curChatData = FriendChatModel.Instance.GetFriendChatHistory(curId);
        int len = curChatData.chatHistory.Count;
        view.chatList.numItems = len;
        if (len > 0)
        {
            view.chatList.ScrollToView(len - 1, false);
        }
    }

    private void ChatItemRenderer(int index, GObject item)
    {
        var cell = item as fun_Chat.chatItemRenderer1;
        cell.lb_info.emojies = Emojies.Instance.emojies;
        cell.lb_info2.emojies = Emojies.Instance.emojies;
        var msg = curChatData.chatHistory[index];
        //var pos = GuildModel.Instance.GetUserData(msg.userInfo.userId);
        if (msg.isSelf)
        {
            cell.chatType.selectedIndex = 1;
            AutuAize(cell.lb_info2, msg, 1, cell);
            cell.head2.img_head.url = "Avatar/ELIDA_common_touxiangdi01.png";
            cell.lb_userName2.text = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_NICKNAME).info;
            cell.txt_lv2.text = MyselfModel.Instance.level.ToString();
        }
        else
        {
            cell.chatType.selectedIndex = 0;
            AutuAize(cell.lb_info, msg, 0, cell);
            cell.head.img_head.url = "Avatar/ELIDA_common_touxiangdi01.png";
            cell.lb_userName.text = curChatData.userInfo.townName;
            cell.txt_lv.text = curChatData.userInfo.userLevel.ToString();
        }
        cell.lb_info.data = msg;
        cell.lb_info.onClick.Add(TextClick);
        cell.lb_info2.data = msg;
        cell.lb_info2.onClick.Add(TextClick);
        cell.pic.data = cell.pic2.data = msg;
        cell.pic.onClick.Add(TextClick);
        cell.pic2.onClick.Add(TextClick);
    }
    private void TextClick(EventContext context)
    {
        view.ope_chat.visible = true;
        var target = context.sender as GObject;
        var msg = target.data as I_FRIEND_CHAT_HISTORY;
        selectChat = msg;
        var p = target.parent.container.LocalToGlobal(target.position);//转为全局坐标
        var p2 = view.ope_chat.GlobalToLocal(p);//再转为引导界面的本地坐标
        view.ope_chat.ope.position = p2;
        if (msg.isSelf)
        {
            view.ope_chat.ope.pivotX = 1;
            view.ope_chat.ope.x = view.ope_chat.ope.x + 20;
        }
        else
        {
            view.ope_chat.ope.pivotX = 0;
            view.ope_chat.ope.x = view.ope_chat.ope.x - 20;
        }


        view.ope_chat.ope.y = view.ope_chat.ope.y - 5;
    }
    private void ReflushMessage()
    {
        if (view.refer_com.visible)
        {
            view.refer_com.visible = false;
        }
        var queue = curChatData.chatHistory;
        //var posY = view.chatList.scrollPane.posY;
        //var contentHeight = view.chatList.scrollPane.contentHeight;
        //var viewHeight = view.chatList.scrollPane.viewHeight;
        var bol = (view.chatList.scrollPane.contentHeight - view.chatList.scrollPane.posY) > 50;
        view.chatList.numItems = queue.Count;
        var contentHeight = view.chatList.scrollPane.contentHeight;
        var viewHeight = view.chatList.scrollPane.viewHeight;
        if (bol)
        {
            if (contentHeight > viewHeight)
            {
                view.chatList.ScrollToView(queue.Count - 1, true);
            }
        }
        else
        {
            var msg = curChatData.chatHistory[queue.Count - 1];
            if (msg.isSelf)
            {
                if (contentHeight > viewHeight)
                {
                    view.chatList.ScrollToView(queue.Count - 1, true);
                }
            }
            else
            {
                view.new_msg.visible = true;
                msgNum++;
                view.new_msg.nsgNum.text = Lang.GetValue("chat_1", msgNum.ToString());
            }

        }
    }

    private void AutuAize(GRichTextField lable, I_FRIEND_CHAT_HISTORY msg, int type, fun_Chat.chatItemRenderer1 cell)
    {
        if(msg.chatContent.contentType == 1)
        {
            cell.emojie.selectedIndex = 0;
            lable.autoSize = AutoSizeType.Both;
            //if (type == 1)
            //{
            //    lable.align = AlignType.Right;
            //}
            lable.text = msg.chatContent.content;
            float offsetHeight = lable.height;
            if (lable.width > messageMaxWidth)
            {
                //lable.align = AlignType.Left;
                //if (type == 1)
                //{
                //    lable.align = AlignType.Left;
                //}
                lable.autoSize = AutoSizeType.Height;
                lable.width = messageMaxWidth;
                offsetHeight = lable.height;
            }
            float refererHeight = 0;
            if (msg.chatContent.referer != null)
            {
                cell.referer.selectedIndex = 1;
                var ref_lab = msg.isSelf ? cell.ref_lab2 : cell.ref_lab;

                ref_lab.autoSize = AutoSizeType.Both;
                ref_lab.text = msg.chatContent.referer.nickName + "：" + msg.chatContent.referer.content;
                if (ref_lab.width > subMaxWidth)
                {
                    ref_lab.autoSize = AutoSizeType.Height;
                    ref_lab.width = subMaxWidth;
                }
                refererHeight = ref_lab.height + 7;
            }
            else
            {
                cell.referer.selectedIndex = 0;
            }
            cell.height = defaultHeight + offsetHeight + refererHeight;
        }
        else
        {
            lable.autoSize = AutoSizeType.Both;
            lable.text = "1";
            cell.referer.selectedIndex = 0;
            cell.height = defaultHeight + 110;
            cell.emojie.selectedIndex = 1;
            var img = msg.isSelf ? cell.pic2 : cell.pic;
            var id = int.Parse(msg.chatContent.content);
            var info = FriendChatModel.Instance.GetEmojieInfo(id);
            img.url = "Chat/" + info.Icon + ".png";
        }
        
    }
    private void EmojiRenderList(int index, GObject item)
    {
        var cell = item as fun_Chat.emojie_item;
        var info = FriendChatModel.Instance.emojieList[index];
        cell.pic.url = "Chat/" + info.Icon + ".png";
        cell.data = info.Id;
        cell.onClick.Add(ChatEmojie);
    }
    private void ChatEmojie(EventContext context)
    {
        var id = (int)(context.sender as GComponent).data;
        var chatContent = new I_SEND_CHAT_VO();
        chatContent.contentType = 2;
        view.type.selectedIndex = 0;
        chatContent.content = id.ToString();
        ChatController.Instance.ReqFriendChat(curId,chatContent);
    }

    private void OnFindTxtFocusIn()
    {
        view.tipLab.visible = false;
    }

    private void OnFindTxtFocusOut()
    {
        view.tipLab.visible = view.input_msg.text == "";

    }

    public  void OnHide()
    {
        
    }
}

