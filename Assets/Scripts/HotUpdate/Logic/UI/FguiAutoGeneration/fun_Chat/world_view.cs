/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Chat
{
    public partial class world_view : GComponent
    {
        public Controller type;
        public GGraph pos;
        public GList chatList;
        public emojie_view emojie_view;
        public GImage n34;
        public GLoader emo_btn;
        public clickBtn btn_send;
        public GTextField tipLab;
        public GTextInput input_msg;
        public new_mes new_msg;
        public refer_com refer_com;
        public GGroup n56;
        public ope_chat ope_chat;
        public Transition t_show;
        public Transition t_hide;
        public const string URL = "ui://z9jypfq8didl1yjp7wn";

        public static world_view CreateInstance()
        {
            return (world_view)UIPackage.CreateObject("fun_Chat", "world_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            pos = (GGraph)GetChildAt(0);
            chatList = (GList)GetChildAt(1);
            emojie_view = (emojie_view)GetChildAt(2);
            n34 = (GImage)GetChildAt(3);
            emo_btn = (GLoader)GetChildAt(4);
            btn_send = (clickBtn)GetChildAt(5);
            tipLab = (GTextField)GetChildAt(6);
            input_msg = (GTextInput)GetChildAt(7);
            new_msg = (new_mes)GetChildAt(8);
            refer_com = (refer_com)GetChildAt(9);
            n56 = (GGroup)GetChildAt(10);
            ope_chat = (ope_chat)GetChildAt(11);
            t_show = GetTransitionAt(0);
            t_hide = GetTransitionAt(1);
        }
    }
}