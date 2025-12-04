using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChatFriendView
{
   private fun_Chat.friend_view view;
    private FrinedChatView chatView;
    private uint curId;
   public ChatFriendView(fun_Chat.friend_view ui)
    {
        view = ui;
        chatView = new FrinedChatView(view.chat_view);
        view.chatList.height = view.btn_send.y - view.pos.y + 55;
        view.nullLab.text = Lang.GetValue("chat_5");
        view.goto_btn.text = Lang.GetValue("chat_7");
        view.chatList.itemRenderer = RenderList;
        view.chatList.SetVirtual();
        view.close_btn.onClick.Add(() =>
        {
            UpdateData();
        });
        view.goto_btn.touchable = true;
        view.goto_rect.onClick.Add(() =>
        {
            UIManager.Instance.CloseWindow(UIName.ChatMainWindow);
            UIManager.Instance.OpenWindow<FriendWindow>(UIName.FriendWindow);
        });
        EventManager.Instance.AddEventListener(ChatEvent.FriendContact, UpdateData);
        EventManager.Instance.AddEventListener(ChatEvent.DelFriendContact, UpdateData);
    }


    public void OnShown(uint id = 0)
    {
        curId = id;
        ChatController.Instance.ReqFriendContact();
    }
    private void UpdateData()
    {
        if(curId != 0)
        {
            view.status.selectedIndex = 1;
            chatView.OnShown(curId);
            var useInfo = FriendChatModel.Instance.GetUserInfo(curId);
            view.nameLab.text = TextUtil.GetServerName(useInfo.serverId, useInfo.townName);
            curId = 0;
        }
        else
        {
            if (FriendChatModel.Instance.contractUserInfos.Count > 0)
            {
                view.status.selectedIndex = 0;
                view.chatList.numItems = FriendChatModel.Instance.contractUserInfos.Count;
            }
            else
            {
                view.status.selectedIndex = 2;
            }
        }
    }

    private void RenderList(int index,GObject item)
    {
        var cell = item as fun_Chat.friend_item;
        var userInfo = FriendChatModel.Instance.contractUserInfos[index];
        cell.txt_lv.text = userInfo.userLevel.ToString();
        cell.head.img_head.url = "Avatar/ELIDA_common_touxiangdi01.png";
        cell.nameLab.text = userInfo.townName;
        cell.rect.data = userInfo.userId;
        cell.del_btn.data = userInfo.userId;
        cell.del_btn.onClick.Add(DelFriendChat);
        cell.rect.onClick.Add(FriendChat);
    }
    private void DelFriendChat(EventContext context)
    {
        var id = (uint)(context.sender as GComponent).data;
        ChatController.Instance.ReqDelFriendContact(id);
    }
    private void FriendChat(EventContext context)
    {
        var id = (uint)(context.sender as GObject).data;
        view.status.selectedIndex = 1;
        var useInfo = FriendChatModel.Instance.GetUserInfo(id);
        view.nameLab.text = TextUtil.GetServerName(useInfo.serverId, useInfo.townName);
        chatView.OnShown(id);
    }
    public void OnHide()
    {
       
    }
}

