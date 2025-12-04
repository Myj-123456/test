/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Tour_Land
{
    public partial class into_battle : GComponent
    {
        public Controller tab;
        public Controller petSelect;
        public Controller fairySelect;
        public GLoader bg;
        public GImage n12;
        public GImage n16;
        public GButton close_btn;
        public GButton pet_btn;
        public GButton flower_god_btn;
        public GGroup n18;
        public GImage n2;
        public GTextField titleLab;
        public GButton help_btn;
        public GGroup n19;
        public GLoader3D player;
        public pet_item pet1;
        public pet_item pet2;
        public flower_god_item flower_god1;
        public flower_god_item flower_god2;
        public flower_god_item flower_god3;
        public GImage n22;
        public GTextField power_name;
        public GTextField power_num;
        public GGroup n25;
        public GImage n17;
        public GList list;
        public GButton btn;
        public GGroup n26;
        public const string URL = "ui://oo5kr0yot5nh10";

        public static into_battle CreateInstance()
        {
            return (into_battle)UIPackage.CreateObject("fun_Tour_Land", "into_battle");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tab = GetControllerAt(0);
            petSelect = GetControllerAt(1);
            fairySelect = GetControllerAt(2);
            bg = (GLoader)GetChildAt(0);
            n12 = (GImage)GetChildAt(1);
            n16 = (GImage)GetChildAt(2);
            close_btn = (GButton)GetChildAt(3);
            pet_btn = (GButton)GetChildAt(4);
            flower_god_btn = (GButton)GetChildAt(5);
            n18 = (GGroup)GetChildAt(6);
            n2 = (GImage)GetChildAt(7);
            titleLab = (GTextField)GetChildAt(8);
            help_btn = (GButton)GetChildAt(9);
            n19 = (GGroup)GetChildAt(10);
            player = (GLoader3D)GetChildAt(11);
            pet1 = (pet_item)GetChildAt(12);
            pet2 = (pet_item)GetChildAt(13);
            flower_god1 = (flower_god_item)GetChildAt(14);
            flower_god2 = (flower_god_item)GetChildAt(15);
            flower_god3 = (flower_god_item)GetChildAt(16);
            n22 = (GImage)GetChildAt(17);
            power_name = (GTextField)GetChildAt(18);
            power_num = (GTextField)GetChildAt(19);
            n25 = (GGroup)GetChildAt(20);
            n17 = (GImage)GetChildAt(21);
            list = (GList)GetChildAt(22);
            btn = (GButton)GetChildAt(23);
            n26 = (GGroup)GetChildAt(24);
        }
    }
}