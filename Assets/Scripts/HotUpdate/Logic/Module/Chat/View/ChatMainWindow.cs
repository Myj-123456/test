using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class ChatMainWindow : BaseWindow
{
   private fun_Chat.chat_main_view view;
    private int tabType = 0;
    private ChatWorldView chatWorldView;
    private ChatGuildView chatGuildView;
    private ChatFriendView chatFriendView;
   public ChatMainWindow()
    {
        packageName = "fun_Chat";
        // 设置委托
        BindAllDelegate = fun_Chat.fun_ChatBinder.BindAll;
        CreateInstanceDelegate = fun_Chat.chat_main_view.CreateInstance;
        FullScreen = true;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Chat.chat_main_view;
        SetBg(view.bg, "Chat/yyq_chat_bg.png");
        chatWorldView = new ChatWorldView(view.world_view);
        chatGuildView = new ChatGuildView(view.guild_view);
        chatFriendView = new ChatFriendView(view.friend_view);
        StringUtil.SetBtnTab(view.world_btn, Lang.GetValue("chat_4"));
        StringUtil.SetBtnTab3(view.world_btn, Lang.GetValue("chat_4"));
        StringUtil.SetBtnTab(view.guild_btn, Lang.GetValue("guild_title"));
        StringUtil.SetBtnTab3(view.guild_btn, Lang.GetValue("guild_title"));
        StringUtil.SetBtnTab(view.friend_btn, Lang.GetValue("Friend_tag_friend"));
        StringUtil.SetBtnTab3(view.friend_btn, Lang.GetValue("Friend_tag_friend"));

        view.world_btn.onClick.Add(() =>
        {
            if(tabType != 0)
            {
                ChangeTab(0);
            }
        });
        view.guild_btn.onClick.Add(() =>
        {
            if (!GlobalModel.Instance.GetUnlocked(SysId.Guild,true))
            {
                view.tab.selectedIndex = tabType;
                return;
            }
            if (tabType != 1)
            {
                ChangeTab(1);
            }
        });
        view.friend_btn.onClick.Add(() =>
        {
            if (!GlobalModel.Instance.GetUnlocked(SysId.Friend, true))
            {
                view.tab.selectedIndex = tabType;
                return;
            }
            if (tabType != 2)
            {
                ChangeTab(2);
            }
        });
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        var index = (int)data;
        if(index < 2)
        {
            ChangeTab(index);
            view.tab.selectedIndex = index;
        }
        else
        {
            tabType = 2;
            view.tab.selectedIndex = 2;
            chatFriendView.OnShown((uint)index);
        }
        
    }
    private void ChangeTab(int type)
    {
        tabType = type;
        if(tabType == 0)
        {
            chatWorldView.OnShown();
        }
        else if(tabType == 1)
        {
            chatGuildView.OnShown();
        }
        else
        {
            chatFriendView.OnShown();
        }
    }
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

