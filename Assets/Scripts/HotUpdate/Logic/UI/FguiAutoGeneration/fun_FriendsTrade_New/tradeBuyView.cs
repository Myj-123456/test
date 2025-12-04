/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FriendsTrade_New
{
    public partial class tradeBuyView : GComponent
    {
        public Controller status;
        public GImage n18;
        public GLoader bg;
        public GImage n21;
        public GImage n19;
        public GImage n14;
        public GButton btn_sure;
        public GButton close_btn;
        public GRichTextField lb_info;
        public GTextInput password_input;
        public GLoader img_item;
        public GImage n20;
        public GTextField lb_count;
        public GGroup n24;
        public const string URL = "ui://jugv3wv4q9bj1ayr7ta";

        public static tradeBuyView CreateInstance()
        {
            return (tradeBuyView)UIPackage.CreateObject("fun_FriendsTrade_New", "tradeBuyView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n18 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n21 = (GImage)GetChildAt(2);
            n19 = (GImage)GetChildAt(3);
            n14 = (GImage)GetChildAt(4);
            btn_sure = (GButton)GetChildAt(5);
            close_btn = (GButton)GetChildAt(6);
            lb_info = (GRichTextField)GetChildAt(7);
            password_input = (GTextInput)GetChildAt(8);
            img_item = (GLoader)GetChildAt(9);
            n20 = (GImage)GetChildAt(10);
            lb_count = (GTextField)GetChildAt(11);
            n24 = (GGroup)GetChildAt(12);
        }
    }
}