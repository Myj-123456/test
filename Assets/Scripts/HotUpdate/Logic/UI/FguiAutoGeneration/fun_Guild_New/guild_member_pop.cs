/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guild_member_pop : GComponent
    {
        public Controller type;
        public GLoader bg;
        public GImage n44;
        public GImage n38;
        public GImage n41;
        public GTextField txt_position;
        public GTextField txt_name;
        public GTextField txt_money;
        public guild_player_head head;
        public GTextField txt_loginTime;
        public GButton btn_addFriend;
        public GButton close_btn;
        public GButton btn_transferLeader;
        public GButton btn_promotion;
        public GButton btn_demotion;
        public GButton btn_ban;
        public GImage n45;
        public GTextField txt_Title;
        public const string URL = "ui://qz6135j3r9vt1ayr89i";

        public static guild_member_pop CreateInstance()
        {
            return (guild_member_pop)UIPackage.CreateObject("fun_Guild_New", "guild_member_pop");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            n44 = (GImage)GetChildAt(1);
            n38 = (GImage)GetChildAt(2);
            n41 = (GImage)GetChildAt(3);
            txt_position = (GTextField)GetChildAt(4);
            txt_name = (GTextField)GetChildAt(5);
            txt_money = (GTextField)GetChildAt(6);
            head = (guild_player_head)GetChildAt(7);
            txt_loginTime = (GTextField)GetChildAt(8);
            btn_addFriend = (GButton)GetChildAt(9);
            close_btn = (GButton)GetChildAt(10);
            btn_transferLeader = (GButton)GetChildAt(11);
            btn_promotion = (GButton)GetChildAt(12);
            btn_demotion = (GButton)GetChildAt(13);
            btn_ban = (GButton)GetChildAt(14);
            n45 = (GImage)GetChildAt(15);
            txt_Title = (GTextField)GetChildAt(16);
        }
    }
}