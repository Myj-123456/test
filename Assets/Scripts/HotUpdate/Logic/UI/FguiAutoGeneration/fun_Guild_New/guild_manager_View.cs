/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guild_manager_View : GComponent
    {
        public Controller tab;
        public Controller showChose;
        public Controller manager;
        public GImage n21;
        public GLoader bg;
        public GImage n31;
        public GImage n29;
        public GImage n30;
        public GTextField titleLab;
        public guild_members members;
        public guild_applicant apply;
        public GButton close_btn;
        public tabBtn btn_member;
        public tabBtn btn_apply;
        public tabBtn info_btn;
        public GImage n34;
        public GImage n20;
        public GImage n24;
        public GImage n25;
        public GImage n23;
        public guild_icon guild_icon;
        public GTextField idLab;
        public GTextField nameLab;
        public GTextField reviewLab;
        public GTextField levelLab;
        public GTextField limitLab;
        public GTextField monyLab;
        public GTextField proLab;
        public GTextField powerLab;
        public GTextInput inputLab;
        public GTextField tipLab;
        public order_progress pro;
        public GButton btn_level;
        public GButton btn_quit;
        public chose_btn chose_btn;
        public btn_common1 review_btn;
        public btn_common1 power_btn;
        public chose_com chose_grp;
        public GGroup n48;
        public const string URL = "ui://qz6135j3tewh1yjp7zs";

        public static guild_manager_View CreateInstance()
        {
            return (guild_manager_View)UIPackage.CreateObject("fun_Guild_New", "guild_manager_View");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tab = GetControllerAt(0);
            showChose = GetControllerAt(1);
            manager = GetControllerAt(2);
            n21 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n31 = (GImage)GetChildAt(2);
            n29 = (GImage)GetChildAt(3);
            n30 = (GImage)GetChildAt(4);
            titleLab = (GTextField)GetChildAt(5);
            members = (guild_members)GetChildAt(6);
            apply = (guild_applicant)GetChildAt(7);
            close_btn = (GButton)GetChildAt(8);
            btn_member = (tabBtn)GetChildAt(9);
            btn_apply = (tabBtn)GetChildAt(10);
            info_btn = (tabBtn)GetChildAt(11);
            n34 = (GImage)GetChildAt(12);
            n20 = (GImage)GetChildAt(13);
            n24 = (GImage)GetChildAt(14);
            n25 = (GImage)GetChildAt(15);
            n23 = (GImage)GetChildAt(16);
            guild_icon = (guild_icon)GetChildAt(17);
            idLab = (GTextField)GetChildAt(18);
            nameLab = (GTextField)GetChildAt(19);
            reviewLab = (GTextField)GetChildAt(20);
            levelLab = (GTextField)GetChildAt(21);
            limitLab = (GTextField)GetChildAt(22);
            monyLab = (GTextField)GetChildAt(23);
            proLab = (GTextField)GetChildAt(24);
            powerLab = (GTextField)GetChildAt(25);
            inputLab = (GTextInput)GetChildAt(26);
            tipLab = (GTextField)GetChildAt(27);
            pro = (order_progress)GetChildAt(28);
            btn_level = (GButton)GetChildAt(29);
            btn_quit = (GButton)GetChildAt(30);
            chose_btn = (chose_btn)GetChildAt(31);
            review_btn = (btn_common1)GetChildAt(32);
            power_btn = (btn_common1)GetChildAt(33);
            chose_grp = (chose_com)GetChildAt(34);
            n48 = (GGroup)GetChildAt(35);
        }
    }
}