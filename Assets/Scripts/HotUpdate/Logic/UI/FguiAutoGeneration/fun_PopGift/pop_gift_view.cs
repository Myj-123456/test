/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_PopGift
{
    public partial class pop_gift_view : GComponent
    {
        public GLoader bg;
        public GLoader bg2;
        public GLoader flower_img;
        public GLoader title_img;
        public GLoader3D spine;
        public GLoader icon;
        public GImage n6;
        public GImage n4;
        public GButton close_btn;
        public GTextField titleLab;
        public GTextField timeLab;
        public GTextField timeLab1;
        public GTextField tipLab;
        public GList list;
        public buy_btn buy_btn;
        public GImage n10;
        public GTextField numLab;
        public GTextField lab;
        public GList page_list;
        public btn1 tip;
        public GButton right_btn;
        public GButton left_btn;
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
            bg2 = (GLoader)GetChildAt(1);
            flower_img = (GLoader)GetChildAt(2);
            title_img = (GLoader)GetChildAt(3);
            spine = (GLoader3D)GetChildAt(4);
            icon = (GLoader)GetChildAt(5);
            n6 = (GImage)GetChildAt(6);
            n4 = (GImage)GetChildAt(7);
            close_btn = (GButton)GetChildAt(8);
            titleLab = (GTextField)GetChildAt(9);
            timeLab = (GTextField)GetChildAt(10);
            timeLab1 = (GTextField)GetChildAt(11);
            tipLab = (GTextField)GetChildAt(12);
            list = (GList)GetChildAt(13);
            buy_btn = (buy_btn)GetChildAt(14);
            n10 = (GImage)GetChildAt(15);
            numLab = (GTextField)GetChildAt(16);
            lab = (GTextField)GetChildAt(17);
            page_list = (GList)GetChildAt(18);
            tip = (btn1)GetChildAt(19);
            right_btn = (GButton)GetChildAt(20);
            left_btn = (GButton)GetChildAt(21);
            n28 = (GImage)GetChildAt(22);
            n29 = (GImage)GetChildAt(23);
            gold_img = (GLoader)GetChildAt(24);
            cash_img = (GLoader)GetChildAt(25);
            gold_lab = (GTextField)GetChildAt(26);
            cash_lab = (GTextField)GetChildAt(27);
            flower_grp = (GGroup)GetChildAt(28);
        }
    }
}