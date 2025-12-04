/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerGold
{
    public partial class flower_gold_book_view : GComponent
    {
        public Controller showChose;
        public GLoader bg;
        public GImage n2;
        public GTextField titleLab;
        public GButton help_btn;
        public GGroup n5;
        public GImage n9;
        public GButton close_btn;
        public GList list;
        public GImage n13;
        public GImage n6;
        public chose_quailty_btn chose_btn;
        public GButton detail_btn;
        public chose_qualirt chose_grp;
        public GTextField numLab;
        public GTextField addLab;
        public GTextField attackLab;
        public GTextField hpLab;
        public GTextField denfenLab;
        public GTextField speedLab;
        public GGroup n21;
        public const string URL = "ui://44kfvb3rx92m2y";

        public static flower_gold_book_view CreateInstance()
        {
            return (flower_gold_book_view)UIPackage.CreateObject("fun_FlowerGold", "flower_gold_book_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            showChose = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
            help_btn = (GButton)GetChildAt(3);
            n5 = (GGroup)GetChildAt(4);
            n9 = (GImage)GetChildAt(5);
            close_btn = (GButton)GetChildAt(6);
            list = (GList)GetChildAt(7);
            n13 = (GImage)GetChildAt(8);
            n6 = (GImage)GetChildAt(9);
            chose_btn = (chose_quailty_btn)GetChildAt(10);
            detail_btn = (GButton)GetChildAt(11);
            chose_grp = (chose_qualirt)GetChildAt(12);
            numLab = (GTextField)GetChildAt(13);
            addLab = (GTextField)GetChildAt(14);
            attackLab = (GTextField)GetChildAt(15);
            hpLab = (GTextField)GetChildAt(16);
            denfenLab = (GTextField)GetChildAt(17);
            speedLab = (GTextField)GetChildAt(18);
            n21 = (GGroup)GetChildAt(19);
        }
    }
}