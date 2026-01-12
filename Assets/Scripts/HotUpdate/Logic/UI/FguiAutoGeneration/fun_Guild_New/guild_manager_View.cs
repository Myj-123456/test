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
        public GLoader bg;
        public GTextField titleLab;
        public GImage n51;
        public guild_members members;
        public guild_applicant apply;
        public GButton close_btn;
        public GButton btn_member;
        public GButton btn_apply;
        public GButton info_btn;
        public GImage n52;
        public GImage n53;
        public GImage n54;
        public GImage n55;
        public GImage n34;
        public GImage n20;
        public guild_icon guild_icon;
        public GTextField idLab;
        public GTextField nameLab;
        public GTextField reviewLab;
        public GTextField txt_addtitle;
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
            bg = (GLoader)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
            n51 = (GImage)GetChildAt(2);
            members = (guild_members)GetChildAt(3);
            apply = (guild_applicant)GetChildAt(4);
            close_btn = (GButton)GetChildAt(5);
            btn_member = (GButton)GetChildAt(6);
            btn_apply = (GButton)GetChildAt(7);
            info_btn = (GButton)GetChildAt(8);
            n52 = (GImage)GetChildAt(9);
            n53 = (GImage)GetChildAt(10);
            n54 = (GImage)GetChildAt(11);
            n55 = (GImage)GetChildAt(12);
            n34 = (GImage)GetChildAt(13);
            n20 = (GImage)GetChildAt(14);
            guild_icon = (guild_icon)GetChildAt(15);
            idLab = (GTextField)GetChildAt(16);
            nameLab = (GTextField)GetChildAt(17);
            reviewLab = (GTextField)GetChildAt(18);
            txt_addtitle = (GTextField)GetChildAt(19);
            levelLab = (GTextField)GetChildAt(20);
            limitLab = (GTextField)GetChildAt(21);
            monyLab = (GTextField)GetChildAt(22);
            proLab = (GTextField)GetChildAt(23);
            powerLab = (GTextField)GetChildAt(24);
            inputLab = (GTextInput)GetChildAt(25);
            tipLab = (GTextField)GetChildAt(26);
            pro = (order_progress)GetChildAt(27);
            btn_level = (GButton)GetChildAt(28);
            btn_quit = (GButton)GetChildAt(29);
            chose_btn = (chose_btn)GetChildAt(30);
            review_btn = (btn_common1)GetChildAt(31);
            power_btn = (btn_common1)GetChildAt(32);
            chose_grp = (chose_com)GetChildAt(33);
            n48 = (GGroup)GetChildAt(34);
        }
    }
}