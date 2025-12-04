/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_PopGift
{
    public partial class pop_gift_view : GComponent
    {
        public GLoader bg;
        public GLoader title_img;
        public GLoader3D spine;
        public GLoader icon;
        public GLoader flower_img;
        public GImage n6;
        public GImage n4;
        public GButton close_btn;
        public GTextField titleLab;
        public GTextField timeLab;
        public GTextField tipLab;
        public GList list;
        public buy_btn buy_btn;
        public GImage n10;
        public GTextField numLab;
        public GTextField lab;
        public GList page_list;
        public btn1 tip;
        public btn2 right_btn;
        public btn2 left_btn;
        public GImage n28;
        public GImage n29;
        public GLoader gold_img;
        public GLoader cash_img;
        public GTextField gold_lab;
        public GTextField cash_lab;
        public GGroup flower_grp;
        public const string URL = "ui://ah12m40ag0s00";

        public static pop_gift_view CreateInstance()
        {
            return (pop_gift_view)UIPackage.CreateObject("fun_PopGift", "pop_gift_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            title_img = (GLoader)GetChildAt(1);
            spine = (GLoader3D)GetChildAt(2);
            icon = (GLoader)GetChildAt(3);
            flower_img = (GLoader)GetChildAt(4);
            n6 = (GImage)GetChildAt(5);
            n4 = (GImage)GetChildAt(6);
            close_btn = (GButton)GetChildAt(7);
            titleLab = (GTextField)GetChildAt(8);
            timeLab = (GTextField)GetChildAt(9);
            tipLab = (GTextField)GetChildAt(10);
            list = (GList)GetChildAt(11);
            buy_btn = (buy_btn)GetChildAt(12);
            n10 = (GImage)GetChildAt(13);
            numLab = (GTextField)GetChildAt(14);
            lab = (GTextField)GetChildAt(15);
            page_list = (GList)GetChildAt(16);
            tip = (btn1)GetChildAt(17);
            right_btn = (btn2)GetChildAt(18);
            left_btn = (btn2)GetChildAt(19);
            n28 = (GImage)GetChildAt(20);
            n29 = (GImage)GetChildAt(21);
            gold_img = (GLoader)GetChildAt(22);
            cash_img = (GLoader)GetChildAt(23);
            gold_lab = (GTextField)GetChildAt(24);
            cash_lab = (GTextField)GetChildAt(25);
            flower_grp = (GGroup)GetChildAt(26);
        }
    }
}