/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Chat
{
    public partial class friend_view : GComponent
    {
        public Controller status;
        public GGraph pos;
        public friend_chat_view chat_view;
        public GList chatList;
        public GImage n59;
        public GImage n60;
        public GImage n61;
        public GTextField nullLab;
        public GTextField goto_btn;
        public GGraph goto_rect;
        public GGroup n64;
        public GImage n34;
        public GLoader emo_btn;
        public clickBtn btn_send;
        public GTextField tipLab;
        public GTextInput input_msg;
        public new_mes new_msg;
        public refer_com refer_com;
        public GGroup n56;
        public GGraph rect;
        public GImage n72;
        public GImage n73;
        public btn4 close_btn;
        public GTextField nameLab;
        public GGroup n74;
        public Transition t_show;
        public Transition t_hide;
        public const string URL = "ui://z9jypfq811rnu1yjp7xt";

        public static friend_view CreateInstance()
        {
            return (friend_view)UIPackage.CreateObject("fun_Chat", "friend_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            pos = (GGraph)GetChildAt(0);
            chat_view = (friend_chat_view)GetChildAt(1);
            chatList = (GList)GetChildAt(2);
            n59 = (GImage)GetChildAt(3);
            n60 = (GImage)GetChildAt(4);
            n61 = (GImage)GetChildAt(5);
            nullLab = (GTextField)GetChildAt(6);
            goto_btn = (GTextField)GetChildAt(7);
            goto_rect = (GGraph)GetChildAt(8);
            n64 = (GGroup)GetChildAt(9);
            n34 = (GImage)GetChildAt(10);
            emo_btn = (GLoader)GetChildAt(11);
            btn_send = (clickBtn)GetChildAt(12);
            tipLab = (GTextField)GetChildAt(13);
            input_msg = (GTextInput)GetChildAt(14);
            new_msg = (new_mes)GetChildAt(15);
            refer_com = (refer_com)GetChildAt(16);
            n56 = (GGroup)GetChildAt(17);
            rect = (GGraph)GetChildAt(18);
            n72 = (GImage)GetChildAt(19);
            n73 = (GImage)GetChildAt(20);
            close_btn = (btn4)GetChildAt(21);
            nameLab = (GTextField)GetChildAt(22);
            n74 = (GGroup)GetChildAt(23);
            t_show = GetTransitionAt(0);
            t_hide = GetTransitionAt(1);
        }
    }
}