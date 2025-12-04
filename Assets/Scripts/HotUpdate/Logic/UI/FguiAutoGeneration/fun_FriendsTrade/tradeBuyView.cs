/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FriendsTrade
{
    public partial class tradeBuyView : GComponent
    {
        public Controller status;
        public GImage n10;
        public GLoader img_item;
        public GButton btn_sure;
        public GImage n12;
        public GTextField lb_count;
        public GRichTextField lb_info;
        public GButton close_btn;
        public GImage n14;
        public GTextInput password_input;
        public const string URL = "ui://tx86642vszkgtwpyh";

        public static tradeBuyView CreateInstance()
        {
            return (tradeBuyView)UIPackage.CreateObject("fun_FriendsTrade", "tradeBuyView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n10 = (GImage)GetChildAt(0);
            img_item = (GLoader)GetChildAt(1);
            btn_sure = (GButton)GetChildAt(2);
            n12 = (GImage)GetChildAt(3);
            lb_count = (GTextField)GetChildAt(4);
            lb_info = (GRichTextField)GetChildAt(5);
            close_btn = (GButton)GetChildAt(6);
            n14 = (GImage)GetChildAt(7);
            password_input = (GTextInput)GetChildAt(8);
        }
    }
}