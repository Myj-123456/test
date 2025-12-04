/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FriendsTrade_New
{
    public partial class tradeSetPassword : GComponent
    {
        public GImage n18;
        public GLoader bg;
        public GImage n31;
        public GImage n21;
        public GImage n14;
        public GTextField lb_title;
        public GButton btn_sure;
        public GButton close_btn;
        public GRichTextField tipLab;
        public GTextInput password_input;
        public GButton btn_cancel;
        public GTextField costLab;
        public GTextField cost;
        public GLoader diamond;
        public const string URL = "ui://jugv3wv4q9bj1m";

        public static tradeSetPassword CreateInstance()
        {
            return (tradeSetPassword)UIPackage.CreateObject("fun_FriendsTrade_New", "tradeSetPassword");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n18 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n31 = (GImage)GetChildAt(2);
            n21 = (GImage)GetChildAt(3);
            n14 = (GImage)GetChildAt(4);
            lb_title = (GTextField)GetChildAt(5);
            btn_sure = (GButton)GetChildAt(6);
            close_btn = (GButton)GetChildAt(7);
            tipLab = (GRichTextField)GetChildAt(8);
            password_input = (GTextInput)GetChildAt(9);
            btn_cancel = (GButton)GetChildAt(10);
            costLab = (GTextField)GetChildAt(11);
            cost = (GTextField)GetChildAt(12);
            diamond = (GLoader)GetChildAt(13);
        }
    }
}