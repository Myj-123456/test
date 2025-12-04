/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class guild : GComponent
    {
        public Controller tab;
        public GImage n45;
        public GTextField title_txt;
        public GTextField txt_code;
        public GTextField txt_name;
        public GTextField txt_id;
        public guild_tab_btn btn_info;
        public guild_tab_btn btn_member;
        public guild_tab_btn btn_func;
        public guild_tab_btn btn_applicant;
        public GButton close_btn;
        public GButton help_btn;
        public writeBtn btn_changeName;
        public btn_set_pass setPassBtn;
        public guild_info content_info;
        public guild_members content_member;
        public guild_func content_func;
        public guild_applicant content_applicant;
        public const string URL = "ui://6wv667gulmnhpda";

        public static guild CreateInstance()
        {
            return (guild)UIPackage.CreateObject("fun_Guild", "guild");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tab = GetControllerAt(0);
            n45 = (GImage)GetChildAt(0);
            title_txt = (GTextField)GetChildAt(1);
            txt_code = (GTextField)GetChildAt(2);
            txt_name = (GTextField)GetChildAt(3);
            txt_id = (GTextField)GetChildAt(4);
            btn_info = (guild_tab_btn)GetChildAt(5);
            btn_member = (guild_tab_btn)GetChildAt(6);
            btn_func = (guild_tab_btn)GetChildAt(7);
            btn_applicant = (guild_tab_btn)GetChildAt(8);
            close_btn = (GButton)GetChildAt(9);
            help_btn = (GButton)GetChildAt(10);
            btn_changeName = (writeBtn)GetChildAt(11);
            setPassBtn = (btn_set_pass)GetChildAt(12);
            content_info = (guild_info)GetChildAt(13);
            content_member = (guild_members)GetChildAt(14);
            content_func = (guild_func)GetChildAt(15);
            content_applicant = (guild_applicant)GetChildAt(16);
        }
    }
}