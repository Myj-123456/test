/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guild_member_pop : GComponent
    {
        public Controller type;
        public GImage n34;
        public GLoader bg;
        public GImage n43;
        public GImage n35;
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
        public const string URL = "ui://qz6135j3r9vt1ayr89i";

        public static guild_member_pop CreateInstance()
        {
            return (guild_member_pop)UIPackage.CreateObject("fun_Guild_New", "guild_member_pop");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            n34 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n43 = (GImage)GetChildAt(2);
            n35 = (GImage)GetChildAt(3);
            n38 = (GImage)GetChildAt(4);
            n41 = (GImage)GetChildAt(5);
            txt_position = (GTextField)GetChildAt(6);
            txt_name = (GTextField)GetChildAt(7);
            txt_money = (GTextField)GetChildAt(8);
            head = (guild_player_head)GetChildAt(9);
            txt_loginTime = (GTextField)GetChildAt(10);
            btn_addFriend = (GButton)GetChildAt(11);
            close_btn = (GButton)GetChildAt(12);
            btn_transferLeader = (GButton)GetChildAt(13);
            btn_promotion = (GButton)GetChildAt(14);
            btn_demotion = (GButton)GetChildAt(15);
            btn_ban = (GButton)GetChildAt(16);
        }
    }
}