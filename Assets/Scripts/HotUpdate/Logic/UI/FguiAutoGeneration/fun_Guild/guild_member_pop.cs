/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class guild_member_pop : GComponent
    {
        public GImage bg;
        public guild_member_list_cell_new member;
        public GButton btn_addFriend;
        public GButton btn_transferLeader;
        public GButton btn_promotion;
        public GButton btn_demotion;
        public GButton btn_ban;
        public GButton close_btn;
        public GTextField titleLab;
        public const string URL = "ui://6wv667guxy3spdh";

        public static guild_member_pop CreateInstance()
        {
            return (guild_member_pop)UIPackage.CreateObject("fun_Guild", "guild_member_pop");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GImage)GetChildAt(0);
            member = (guild_member_list_cell_new)GetChildAt(1);
            btn_addFriend = (GButton)GetChildAt(2);
            btn_transferLeader = (GButton)GetChildAt(3);
            btn_promotion = (GButton)GetChildAt(4);
            btn_demotion = (GButton)GetChildAt(5);
            btn_ban = (GButton)GetChildAt(6);
            close_btn = (GButton)GetChildAt(7);
            titleLab = (GTextField)GetChildAt(8);
        }
    }
}