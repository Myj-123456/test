/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationShop
{
    public partial class ShopView : GComponent
    {
        public GLoader bg;
        public GImage n110;
        public GImage n111;
        public GImage n107;
        public GTextField title_txt;
        public GImage n109;
        public GTextField time_txt;
        public GTextField refreshLab;
        public GButton refresh_btn;
        public GButton pay_btn;
        public GGroup n113;
        public GList list;
        public GButton close_btn;
        public const string URL = "ui://zussolhpefh1obh";

        public static ShopView CreateInstance()
        {
            return (ShopView)UIPackage.CreateObject("fun_CultivationShop", "ShopView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            n110 = (GImage)GetChildAt(1);
            n111 = (GImage)GetChildAt(2);
            n107 = (GImage)GetChildAt(3);
            title_txt = (GTextField)GetChildAt(4);
            n109 = (GImage)GetChildAt(5);
            time_txt = (GTextField)GetChildAt(6);
            refreshLab = (GTextField)GetChildAt(7);
            refresh_btn = (GButton)GetChildAt(8);
            pay_btn = (GButton)GetChildAt(9);
            n113 = (GGroup)GetChildAt(10);
            list = (GList)GetChildAt(11);
            close_btn = (GButton)GetChildAt(12);
        }
    }
}