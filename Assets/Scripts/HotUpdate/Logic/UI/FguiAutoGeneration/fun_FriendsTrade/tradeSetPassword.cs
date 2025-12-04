/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FriendsTrade
{
    public partial class tradeSetPassword : GComponent
    {
        public GImage n10;
        public GRichTextField lb_title;
        public GImage n14;
        public GTextInput password_input;
        public GButton btn_cancel;
        public GButton close_btn;
        public GButton btn_sure;
        public GLoader diamond;
        public GTextField cost;
        public GTextField n22;
        public const string URL = "ui://tx86642vlaxb1ayr7r8";

        public static tradeSetPassword CreateInstance()
        {
            return (tradeSetPassword)UIPackage.CreateObject("fun_FriendsTrade", "tradeSetPassword");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n10 = (GImage)GetChildAt(0);
            lb_title = (GRichTextField)GetChildAt(1);
            n14 = (GImage)GetChildAt(2);
            password_input = (GTextInput)GetChildAt(3);
            btn_cancel = (GButton)GetChildAt(4);
            close_btn = (GButton)GetChildAt(5);
            btn_sure = (GButton)GetChildAt(6);
            diamond = (GLoader)GetChildAt(7);
            cost = (GTextField)GetChildAt(8);
            n22 = (GTextField)GetChildAt(9);
        }
    }
}