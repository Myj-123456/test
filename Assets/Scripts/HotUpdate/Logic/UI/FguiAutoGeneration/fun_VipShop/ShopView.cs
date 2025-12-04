/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_VipShop
{
    public partial class ShopView : GComponent
    {
        public GLoader bg;
        public GImage n116;
        public GImage n127;
        public GImage n128;
        public GImage n129;
        public GGroup n130;
        public GList list;
        public GImage n117;
        public GTextField titleLab;
        public GButton n119;
        public GImage n120;
        public GLoader pic;
        public GTextField txt_gold;
        public GGroup n124;
        public GImage n115;
        public GTextField time_txt;
        public GTextField refreshLab;
        public GButton refresh_btn;
        public GButton pay_btn;
        public GGroup n125;
        public const string URL = "ui://wm7arakybwsw1ayr7s6";

        public static ShopView CreateInstance()
        {
            return (ShopView)UIPackage.CreateObject("fun_VipShop", "ShopView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            n116 = (GImage)GetChildAt(1);
            n127 = (GImage)GetChildAt(2);
            n128 = (GImage)GetChildAt(3);
            n129 = (GImage)GetChildAt(4);
            n130 = (GGroup)GetChildAt(5);
            list = (GList)GetChildAt(6);
            n117 = (GImage)GetChildAt(7);
            titleLab = (GTextField)GetChildAt(8);
            n119 = (GButton)GetChildAt(9);
            n120 = (GImage)GetChildAt(10);
            pic = (GLoader)GetChildAt(11);
            txt_gold = (GTextField)GetChildAt(12);
            n124 = (GGroup)GetChildAt(13);
            n115 = (GImage)GetChildAt(14);
            time_txt = (GTextField)GetChildAt(15);
            refreshLab = (GTextField)GetChildAt(16);
            refresh_btn = (GButton)GetChildAt(17);
            pay_btn = (GButton)GetChildAt(18);
            n125 = (GGroup)GetChildAt(19);
        }
    }
}