/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Player
{
    public partial class player_info_view : GComponent
    {
        public Controller tab;
        public GLoader bg;
        public GImage n7;
        public GLoader3D spine;
        public GImage n9;
        public GTextField titleLab;
        public GTextField grade_name;
        public GTextField grade_num;
        public GGroup n47;
        public GImage n10;
        public GTextField power_name;
        public GTextField power_num;
        public GGroup n49;
        public GButton close_btn;
        public GImage n24;
        public GImage n16;
        public GImage n19;
        public GImage n32;
        public GImage style_img1;
        public GImage style_img2;
        public GImage style_img3;
        public GImage style_img4;
        public GImage style_img5;
        public GImage style_img6;
        public GImage n29;
        public GTextField nature_name;
        public GTextField style_name;
        public GTextField attack_name;
        public GTextField defense_name;
        public GTextField hp_name;
        public GTextField speed_name;
        public GTextField attack_num;
        public GTextField defense_num;
        public GTextField hp_num;
        public GTextField speed_num;
        public goto_btn goLab;
        public GTextField style_name1;
        public GTextField style_name2;
        public GTextField style_name3;
        public GTextField style_name4;
        public GTextField style_name5;
        public GTextField style_name6;
        public GTextField show_nature;
        public GGroup n45;
        public grade_show_nature grade;
        public style_item style_item1;
        public style_item style_item2;
        public style_item style_item3;
        public style_item style_item4;
        public style_item style_item5;
        public style_item style_item6;
        public GGroup n57;
        public GImage n6;
        public GImage n61;
        public GButton tab1;
        public GButton tab2;
        public GGroup n63;
        public GImage n2;
        public GTextField title_txt;
        public GButton help_btn;
        public GGroup n64;
        public pro_components ink;
        public const string URL = "ui://0svwl9suoi770";

        public static player_info_view CreateInstance()
        {
            return (player_info_view)UIPackage.CreateObject("fun_Player", "player_info_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tab = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            n7 = (GImage)GetChildAt(1);
            spine = (GLoader3D)GetChildAt(2);
            n9 = (GImage)GetChildAt(3);
            titleLab = (GTextField)GetChildAt(4);
            grade_name = (GTextField)GetChildAt(5);
            grade_num = (GTextField)GetChildAt(6);
            n47 = (GGroup)GetChildAt(7);
            n10 = (GImage)GetChildAt(8);
            power_name = (GTextField)GetChildAt(9);
            power_num = (GTextField)GetChildAt(10);
            n49 = (GGroup)GetChildAt(11);
            close_btn = (GButton)GetChildAt(12);
            n24 = (GImage)GetChildAt(13);
            n16 = (GImage)GetChildAt(14);
            n19 = (GImage)GetChildAt(15);
            n32 = (GImage)GetChildAt(16);
            style_img1 = (GImage)GetChildAt(17);
            style_img2 = (GImage)GetChildAt(18);
            style_img3 = (GImage)GetChildAt(19);
            style_img4 = (GImage)GetChildAt(20);
            style_img5 = (GImage)GetChildAt(21);
            style_img6 = (GImage)GetChildAt(22);
            n29 = (GImage)GetChildAt(23);
            nature_name = (GTextField)GetChildAt(24);
            style_name = (GTextField)GetChildAt(25);
            attack_name = (GTextField)GetChildAt(26);
            defense_name = (GTextField)GetChildAt(27);
            hp_name = (GTextField)GetChildAt(28);
            speed_name = (GTextField)GetChildAt(29);
            attack_num = (GTextField)GetChildAt(30);
            defense_num = (GTextField)GetChildAt(31);
            hp_num = (GTextField)GetChildAt(32);
            speed_num = (GTextField)GetChildAt(33);
            goLab = (goto_btn)GetChildAt(34);
            style_name1 = (GTextField)GetChildAt(35);
            style_name2 = (GTextField)GetChildAt(36);
            style_name3 = (GTextField)GetChildAt(37);
            style_name4 = (GTextField)GetChildAt(38);
            style_name5 = (GTextField)GetChildAt(39);
            style_name6 = (GTextField)GetChildAt(40);
            show_nature = (GTextField)GetChildAt(41);
            n45 = (GGroup)GetChildAt(42);
            grade = (grade_show_nature)GetChildAt(43);
            style_item1 = (style_item)GetChildAt(44);
            style_item2 = (style_item)GetChildAt(45);
            style_item3 = (style_item)GetChildAt(46);
            style_item4 = (style_item)GetChildAt(47);
            style_item5 = (style_item)GetChildAt(48);
            style_item6 = (style_item)GetChildAt(49);
            n57 = (GGroup)GetChildAt(50);
            n6 = (GImage)GetChildAt(51);
            n61 = (GImage)GetChildAt(52);
            tab1 = (GButton)GetChildAt(53);
            tab2 = (GButton)GetChildAt(54);
            n63 = (GGroup)GetChildAt(55);
            n2 = (GImage)GetChildAt(56);
            title_txt = (GTextField)GetChildAt(57);
            help_btn = (GButton)GetChildAt(58);
            n64 = (GGroup)GetChildAt(59);
            ink = (pro_components)GetChildAt(60);
        }
    }
}