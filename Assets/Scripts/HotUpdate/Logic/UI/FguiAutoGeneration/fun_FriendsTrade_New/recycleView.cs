/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FriendsTrade_New
{
    public partial class recycleView : GComponent
    {
        public GImage n18;
        public GLoader bg;
        public GLoader img_item;
        public GImage n21;
        public GImage n19;
        public GImage n20;
        public GImage n14;
        public GButton btn_sure;
        public GButton close_btn;
        public GTextField lb_count;
        public GRichTextField lb_info;
        public GTextField lb_price;
        public GButton cancel_btn;
        public GTextField tipLab;
        public const string URL = "ui://jugv3wv4q9bjx";

        public static recycleView CreateInstance()
        {
            return (recycleView)UIPackage.CreateObject("fun_FriendsTrade_New", "recycleView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n18 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            img_item = (GLoader)GetChildAt(2);
            n21 = (GImage)GetChildAt(3);
            n19 = (GImage)GetChildAt(4);
            n20 = (GImage)GetChildAt(5);
            n14 = (GImage)GetChildAt(6);
            btn_sure = (GButton)GetChildAt(7);
            close_btn = (GButton)GetChildAt(8);
            lb_count = (GTextField)GetChildAt(9);
            lb_info = (GRichTextField)GetChildAt(10);
            lb_price = (GTextField)GetChildAt(11);
            cancel_btn = (GButton)GetChildAt(12);
            tipLab = (GTextField)GetChildAt(13);
        }
    }
}