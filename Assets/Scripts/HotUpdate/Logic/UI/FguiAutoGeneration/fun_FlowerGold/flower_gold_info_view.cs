/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerGold
{
    public partial class flower_gold_info_view : GComponent
    {
        public Controller into;
        public Controller tab;
        public Controller max;
        public GLoader bg;
        public GLoader bg1;
        public GLoader icon;
        public GImage n12;
        public GImage n13;
        public GTextField intoLab;
        public GButton left_btn;
        public GButton right_btn;
        public btn into_btn;
        public GGroup n54;
        public GImage n11;
        public GTextField titileLab;
        public GButton help_btn;
        public GGroup n55;
        public GImage n22;
        public GImage n20;
        public GLoader rare_img;
        public GTextField nameLab;
        public GTextField lvLab;
        public GImage n33;
        public GImage n23;
        public GImage n27;
        public GTextField skill_title;
        public GTextField skillLab;
        public GTextField nature_title;
        public GList list;
        public GButton detail_btn;
        public GGroup n38;
        public GImage n39;
        public GList level_list;
        public star_cost_item needItem;
        public probar1 pro;
        public GButton levelUp_btn;
        public GTextField level_nature;
        public GTextField haveLab;
        public GTextField proLab;
        public GGroup n45;
        public GImage n46;
        public GImage n48;
        public GTextField love_add;
        public GTextField love_flower;
        public GTextField styleLab;
        public GTextField orderLab;
        public GList love_list;
        public GGroup n53;
        public page_btn info_btn;
        public page_btn level_btn;
        public page_btn love_btn;
        public GGroup n56;
        public GButton close_btn;
        public const string URL = "ui://44kfvb3rx92m2";

        public static flower_gold_info_view CreateInstance()
        {
            return (flower_gold_info_view)UIPackage.CreateObject("fun_FlowerGold", "flower_gold_info_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            into = GetControllerAt(0);
            tab = GetControllerAt(1);
            max = GetControllerAt(2);
            bg = (GLoader)GetChildAt(0);
            bg1 = (GLoader)GetChildAt(1);
            icon = (GLoader)GetChildAt(2);
            n12 = (GImage)GetChildAt(3);
            n13 = (GImage)GetChildAt(4);
            intoLab = (GTextField)GetChildAt(5);
            left_btn = (GButton)GetChildAt(6);
            right_btn = (GButton)GetChildAt(7);
            into_btn = (btn)GetChildAt(8);
            n54 = (GGroup)GetChildAt(9);
            n11 = (GImage)GetChildAt(10);
            titileLab = (GTextField)GetChildAt(11);
            help_btn = (GButton)GetChildAt(12);
            n55 = (GGroup)GetChildAt(13);
            n22 = (GImage)GetChildAt(14);
            n20 = (GImage)GetChildAt(15);
            rare_img = (GLoader)GetChildAt(16);
            nameLab = (GTextField)GetChildAt(17);
            lvLab = (GTextField)GetChildAt(18);
            n33 = (GImage)GetChildAt(19);
            n23 = (GImage)GetChildAt(20);
            n27 = (GImage)GetChildAt(21);
            skill_title = (GTextField)GetChildAt(22);
            skillLab = (GTextField)GetChildAt(23);
            nature_title = (GTextField)GetChildAt(24);
            list = (GList)GetChildAt(25);
            detail_btn = (GButton)GetChildAt(26);
            n38 = (GGroup)GetChildAt(27);
            n39 = (GImage)GetChildAt(28);
            level_list = (GList)GetChildAt(29);
            needItem = (star_cost_item)GetChildAt(30);
            pro = (probar1)GetChildAt(31);
            levelUp_btn = (GButton)GetChildAt(32);
            level_nature = (GTextField)GetChildAt(33);
            haveLab = (GTextField)GetChildAt(34);
            proLab = (GTextField)GetChildAt(35);
            n45 = (GGroup)GetChildAt(36);
            n46 = (GImage)GetChildAt(37);
            n48 = (GImage)GetChildAt(38);
            love_add = (GTextField)GetChildAt(39);
            love_flower = (GTextField)GetChildAt(40);
            styleLab = (GTextField)GetChildAt(41);
            orderLab = (GTextField)GetChildAt(42);
            love_list = (GList)GetChildAt(43);
            n53 = (GGroup)GetChildAt(44);
            info_btn = (page_btn)GetChildAt(45);
            level_btn = (page_btn)GetChildAt(46);
            love_btn = (page_btn)GetChildAt(47);
            n56 = (GGroup)GetChildAt(48);
            close_btn = (GButton)GetChildAt(49);
        }
    }
}