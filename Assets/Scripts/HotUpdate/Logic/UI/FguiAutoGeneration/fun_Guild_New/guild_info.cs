/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guild_info : GComponent
    {
        public GImage bg;
        public GImage n56;
        public GImage n42;
        public GImage n49;
        public GImage n50;
        public GImage n57;
        public GImage n51;
        public GImage n45;
        public GImage n46;
        public GImage n47;
        public GImage n48;
        public GTextField txt_code;
        public notice_txt txt_notice;
        public GTextField txt_id;
        public GTextField txt_lv_desc;
        public GTextField txt_lv;
        public GTextField txt_num_desc;
        public GTextField txt_money_title;
        public GTextField txt_title_coin;
        public GTextField txt_power;
        public GTextField txt_power_num;
        public GTextField txt_num;
        public GTextField txt_money_content;
        public GTextField txt_coin;
        public GTextField txt_notice_title;
        public GTextField txt_name;
        public btn_edit btn_edit;
        public const string URL = "ui://qz6135j3s62s1yjp7z3";

        public static guild_info CreateInstance()
        {
            return (guild_info)UIPackage.CreateObject("fun_Guild_New", "guild_info");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GImage)GetChildAt(0);
            n56 = (GImage)GetChildAt(1);
            n42 = (GImage)GetChildAt(2);
            n49 = (GImage)GetChildAt(3);
            n50 = (GImage)GetChildAt(4);
            n57 = (GImage)GetChildAt(5);
            n51 = (GImage)GetChildAt(6);
            n45 = (GImage)GetChildAt(7);
            n46 = (GImage)GetChildAt(8);
            n47 = (GImage)GetChildAt(9);
            n48 = (GImage)GetChildAt(10);
            txt_code = (GTextField)GetChildAt(11);
            txt_notice = (notice_txt)GetChildAt(12);
            txt_id = (GTextField)GetChildAt(13);
            txt_lv_desc = (GTextField)GetChildAt(14);
            txt_lv = (GTextField)GetChildAt(15);
            txt_num_desc = (GTextField)GetChildAt(16);
            txt_money_title = (GTextField)GetChildAt(17);
            txt_title_coin = (GTextField)GetChildAt(18);
            txt_power = (GTextField)GetChildAt(19);
            txt_power_num = (GTextField)GetChildAt(20);
            txt_num = (GTextField)GetChildAt(21);
            txt_money_content = (GTextField)GetChildAt(22);
            txt_coin = (GTextField)GetChildAt(23);
            txt_notice_title = (GTextField)GetChildAt(24);
            txt_name = (GTextField)GetChildAt(25);
            btn_edit = (btn_edit)GetChildAt(26);
        }
    }
}