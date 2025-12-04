/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerGold
{
    public partial class flower_gold_view : GComponent
    {
        public GLoader bg;
        public GLoader bg3;
        public GLoader3D spine;
        public GLoader bg2;
        public GLoader bg4;
        public GLoader bg1;
        public GImage n23;
        public GImage n0;
        public GImage n34;
        public GImage n5;
        public GButton help_btn;
        public GLoader sum_img;
        public GLoader cash_img;
        public GTextField sumLab;
        public GTextField titleLab;
        public GTextField cashLab;
        public GGroup n37;
        public GButton close_btn;
        public btn book_btn;
        public btn fetters_btn;
        public GTextField timeLab;
        public GImage n39;
        public probar pro;
        public GImage n40;
        public flower_gold_item item1;
        public flower_gold_item item2;
        public flower_gold_item item3;
        public GTextField proLab;
        public GTextField qualiyLab;
        public GGroup n43;
        public picBtn call_btn;
        public btn1 muli_btn;
        public btn2 refesh_btn;
        public GGroup n44;
        public const string URL = "ui://44kfvb3rx92m0";

        public static flower_gold_view CreateInstance()
        {
            return (flower_gold_view)UIPackage.CreateObject("fun_FlowerGold", "flower_gold_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            bg3 = (GLoader)GetChildAt(1);
            spine = (GLoader3D)GetChildAt(2);
            bg2 = (GLoader)GetChildAt(3);
            bg4 = (GLoader)GetChildAt(4);
            bg1 = (GLoader)GetChildAt(5);
            n23 = (GImage)GetChildAt(6);
            n0 = (GImage)GetChildAt(7);
            n34 = (GImage)GetChildAt(8);
            n5 = (GImage)GetChildAt(9);
            help_btn = (GButton)GetChildAt(10);
            sum_img = (GLoader)GetChildAt(11);
            cash_img = (GLoader)GetChildAt(12);
            sumLab = (GTextField)GetChildAt(13);
            titleLab = (GTextField)GetChildAt(14);
            cashLab = (GTextField)GetChildAt(15);
            n37 = (GGroup)GetChildAt(16);
            close_btn = (GButton)GetChildAt(17);
            book_btn = (btn)GetChildAt(18);
            fetters_btn = (btn)GetChildAt(19);
            timeLab = (GTextField)GetChildAt(20);
            n39 = (GImage)GetChildAt(21);
            pro = (probar)GetChildAt(22);
            n40 = (GImage)GetChildAt(23);
            item1 = (flower_gold_item)GetChildAt(24);
            item2 = (flower_gold_item)GetChildAt(25);
            item3 = (flower_gold_item)GetChildAt(26);
            proLab = (GTextField)GetChildAt(27);
            qualiyLab = (GTextField)GetChildAt(28);
            n43 = (GGroup)GetChildAt(29);
            call_btn = (picBtn)GetChildAt(30);
            muli_btn = (btn1)GetChildAt(31);
            refesh_btn = (btn2)GetChildAt(32);
            n44 = (GGroup)GetChildAt(33);
        }
    }
}