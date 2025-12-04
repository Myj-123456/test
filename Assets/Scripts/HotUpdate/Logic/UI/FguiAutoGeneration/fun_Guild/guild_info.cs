/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class guild_info : GComponent
    {
        public GImage n68;
        public GTextField txt_leaderName;
        public GTextField leaderName;
        public GTextField txt_num_desc;
        public GTextField txt_num;
        public GTextField txt_lv_desc;
        public GTextField txt_lv;
        public GTextField txt_money_title;
        public GTextField txt_money_content;
        public GTextField txt_coin;
        public GTextField txt_title_coin;
        public GTextField txt_notice_title;
        public GTextField txt_title_slogan;
        public GTextField txt_slogan;
        public GTextField txt_notice;
        public GButton btn_manage;
        public GImage n32;
        public GButton btn_quit;
        public writeBtn btn_changeSlogan;
        public writeBtn btn_changeNotice;
        public guild_player_head head;
        public writeBtn btn_log_money;
        public const string URL = "ui://6wv667gulmnhpdb";

        public static guild_info CreateInstance()
        {
            return (guild_info)UIPackage.CreateObject("fun_Guild", "guild_info");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n68 = (GImage)GetChildAt(0);
            txt_leaderName = (GTextField)GetChildAt(1);
            leaderName = (GTextField)GetChildAt(2);
            txt_num_desc = (GTextField)GetChildAt(3);
            txt_num = (GTextField)GetChildAt(4);
            txt_lv_desc = (GTextField)GetChildAt(5);
            txt_lv = (GTextField)GetChildAt(6);
            txt_money_title = (GTextField)GetChildAt(7);
            txt_money_content = (GTextField)GetChildAt(8);
            txt_coin = (GTextField)GetChildAt(9);
            txt_title_coin = (GTextField)GetChildAt(10);
            txt_notice_title = (GTextField)GetChildAt(11);
            txt_title_slogan = (GTextField)GetChildAt(12);
            txt_slogan = (GTextField)GetChildAt(13);
            txt_notice = (GTextField)GetChildAt(14);
            btn_manage = (GButton)GetChildAt(15);
            n32 = (GImage)GetChildAt(16);
            btn_quit = (GButton)GetChildAt(17);
            btn_changeSlogan = (writeBtn)GetChildAt(18);
            btn_changeNotice = (writeBtn)GetChildAt(19);
            head = (guild_player_head)GetChildAt(20);
            btn_log_money = (writeBtn)GetChildAt(21);
        }
    }
}