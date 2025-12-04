/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Chat
{
    public partial class chatView : GComponent
    {
        public GImage n47;
        public GLoader bg;
        public GImage n50;
        public GImage n34;
        public GImage n48;
        public GImage n49;
        public GTextField title_txt;
        public GList chatList;
        public GButton btn_send;
        public GTextField tipLab;
        public GTextInput input_msg;
        public GButton close_btn;
        public Transition t_show;
        public Transition t_hide;
        public const string URL = "ui://z9jypfq8f94npgi";

        public static chatView CreateInstance()
        {
            return (chatView)UIPackage.CreateObject("fun_Chat", "chatView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n47 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n50 = (GImage)GetChildAt(2);
            n34 = (GImage)GetChildAt(3);
            n48 = (GImage)GetChildAt(4);
            n49 = (GImage)GetChildAt(5);
            title_txt = (GTextField)GetChildAt(6);
            chatList = (GList)GetChildAt(7);
            btn_send = (GButton)GetChildAt(8);
            tipLab = (GTextField)GetChildAt(9);
            input_msg = (GTextInput)GetChildAt(10);
            close_btn = (GButton)GetChildAt(11);
            t_show = GetTransitionAt(0);
            t_hide = GetTransitionAt(1);
        }
    }
}