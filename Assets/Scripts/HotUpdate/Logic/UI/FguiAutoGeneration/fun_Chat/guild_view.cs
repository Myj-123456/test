/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Chat
{
    public partial class guild_view : GComponent
    {
        public Controller status;
        public Controller type;
        public GGraph pos;
        public GList chatList;
        public GImage n59;
        public GImage n60;
        public GImage n61;
        public GTextField nullLab;
        public GTextField goto_btn;
        public GGraph goto_rect;
        public GGroup n64;
        public emojie_view emojie_view;
        public GImage n34;
        public GLoader emo_btn;
        public clickBtn btn_send;
        public GTextField tipLab;
        public GTextInput input_msg;
        public new_mes new_msg;
        public refer_com refer_com;
        public GGroup n56;
        public GGraph rect;
        public ope_chat ope_chat;
        public Transition t_show;
        public Transition t_hide;
        public const string URL = "ui://z9jypfq811rnu1yjp7xp";

        public static guild_view CreateInstance()
        {
            return (guild_view)UIPackage.CreateObject("fun_Chat", "guild_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            type = GetControllerAt(1);
            pos = (GGraph)GetChildAt(0);
            chatList = (GList)GetChildAt(1);
            n59 = (GImage)GetChildAt(2);
            n60 = (GImage)GetChildAt(3);
            n61 = (GImage)GetChildAt(4);
            nullLab = (GTextField)GetChildAt(5);
            goto_btn = (GTextField)GetChildAt(6);
            goto_rect = (GGraph)GetChildAt(7);
            n64 = (GGroup)GetChildAt(8);
            emojie_view = (emojie_view)GetChildAt(9);
            n34 = (GImage)GetChildAt(10);
            emo_btn = (GLoader)GetChildAt(11);
            btn_send = (clickBtn)GetChildAt(12);
            tipLab = (GTextField)GetChildAt(13);
            input_msg = (GTextInput)GetChildAt(14);
            new_msg = (new_mes)GetChildAt(15);
            refer_com = (refer_com)GetChildAt(16);
            n56 = (GGroup)GetChildAt(17);
            rect = (GGraph)GetChildAt(18);
            ope_chat = (ope_chat)GetChildAt(19);
            t_show = GetTransitionAt(0);
            t_hide = GetTransitionAt(1);
        }
    }
}