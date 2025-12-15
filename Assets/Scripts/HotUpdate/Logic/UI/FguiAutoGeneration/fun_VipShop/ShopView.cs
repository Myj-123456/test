/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_VipShop
{
    public partial class ShopView : GComponent
    {
        public GImage n116;
        public GImage n139;
        public GList list;
        public GImage n132;
        public GImage n133;
        public GLoader pic;
        public GTextField titleLab;
        public GTextField txt_gold;
        public GButton help_btn;
        public GGroup n134;
        public GImage n136;
        public GTextField time_txt;
        public GTextField refreshLab;
        public btn2 refresh_btn;
        public greenPicBtn pay_btn;
        public GGroup n137;
        public const string URL = "ui://wm7arakybwsw1ayr7s6";

        public static ShopView CreateInstance()
        {
            return (ShopView)UIPackage.CreateObject("fun_VipShop", "ShopView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n116 = (GImage)GetChildAt(0);
            n139 = (GImage)GetChildAt(1);
            list = (GList)GetChildAt(2);
            n132 = (GImage)GetChildAt(3);
            n133 = (GImage)GetChildAt(4);
            pic = (GLoader)GetChildAt(5);
            titleLab = (GTextField)GetChildAt(6);
            txt_gold = (GTextField)GetChildAt(7);
            help_btn = (GButton)GetChildAt(8);
            n134 = (GGroup)GetChildAt(9);
            n136 = (GImage)GetChildAt(10);
            time_txt = (GTextField)GetChildAt(11);
            refreshLab = (GTextField)GetChildAt(12);
            refresh_btn = (btn2)GetChildAt(13);
            pay_btn = (greenPicBtn)GetChildAt(14);
            n137 = (GGroup)GetChildAt(15);
        }
    }
}