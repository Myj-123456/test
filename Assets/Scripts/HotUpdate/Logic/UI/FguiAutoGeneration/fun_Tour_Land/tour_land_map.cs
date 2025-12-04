/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Tour_Land
{
    public partial class tour_land_map : GComponent
    {
        public Controller tab;
        public Controller status;
        public GLoader bg;
        public GImage n20;
        public GImage n23;
        public GTextField nameLab;
        public tabBtn tab1;
        public tabBtn tab2;
        public proComonent pro;
        public GImage n37;
        public GImage n38;
        public GImage n39;
        public GTextField task_title;
        public GTextField task_num;
        public GTextField tour_title;
        public GTextField timeLab;
        public GGraph event_btn;
        public GGroup n46;
        public GGroup n48;
        public GImage n1;
        public GImage n11;
        public GImage n14;
        public GImage n17;
        public GLoader ink_img;
        public GLoader gold_img;
        public GLoader diamond_img;
        public GTextField diamond_num;
        public GTextField titleLab;
        public GTextField ink_num;
        public GTextField gold_num;
        public GButton help_btn;
        public GGroup n27;
        public GImage n30;
        public GLoader bread_img;
        public GLoader gold_Img;
        public GTextField hookLab;
        public GTextField expLab;
        public GTextField goldLab;
        public btn reward_btn;
        public GGroup n36;
        public GButton close_btn;
        public GList list;
        public GTextField tipLab;
        public GButton go_btn;
        public GGroup n28;
        public const string URL = "ui://oo5kr0yot5nh0";

        public static tour_land_map CreateInstance()
        {
            return (tour_land_map)UIPackage.CreateObject("fun_Tour_Land", "tour_land_map");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tab = GetControllerAt(0);
            status = GetControllerAt(1);
            bg = (GLoader)GetChildAt(0);
            n20 = (GImage)GetChildAt(1);
            n23 = (GImage)GetChildAt(2);
            nameLab = (GTextField)GetChildAt(3);
            tab1 = (tabBtn)GetChildAt(4);
            tab2 = (tabBtn)GetChildAt(5);
            pro = (proComonent)GetChildAt(6);
            n37 = (GImage)GetChildAt(7);
            n38 = (GImage)GetChildAt(8);
            n39 = (GImage)GetChildAt(9);
            task_title = (GTextField)GetChildAt(10);
            task_num = (GTextField)GetChildAt(11);
            tour_title = (GTextField)GetChildAt(12);
            timeLab = (GTextField)GetChildAt(13);
            event_btn = (GGraph)GetChildAt(14);
            n46 = (GGroup)GetChildAt(15);
            n48 = (GGroup)GetChildAt(16);
            n1 = (GImage)GetChildAt(17);
            n11 = (GImage)GetChildAt(18);
            n14 = (GImage)GetChildAt(19);
            n17 = (GImage)GetChildAt(20);
            ink_img = (GLoader)GetChildAt(21);
            gold_img = (GLoader)GetChildAt(22);
            diamond_img = (GLoader)GetChildAt(23);
            diamond_num = (GTextField)GetChildAt(24);
            titleLab = (GTextField)GetChildAt(25);
            ink_num = (GTextField)GetChildAt(26);
            gold_num = (GTextField)GetChildAt(27);
            help_btn = (GButton)GetChildAt(28);
            n27 = (GGroup)GetChildAt(29);
            n30 = (GImage)GetChildAt(30);
            bread_img = (GLoader)GetChildAt(31);
            gold_Img = (GLoader)GetChildAt(32);
            hookLab = (GTextField)GetChildAt(33);
            expLab = (GTextField)GetChildAt(34);
            goldLab = (GTextField)GetChildAt(35);
            reward_btn = (btn)GetChildAt(36);
            n36 = (GGroup)GetChildAt(37);
            close_btn = (GButton)GetChildAt(38);
            list = (GList)GetChildAt(39);
            tipLab = (GTextField)GetChildAt(40);
            go_btn = (GButton)GetChildAt(41);
            n28 = (GGroup)GetChildAt(42);
        }
    }
}