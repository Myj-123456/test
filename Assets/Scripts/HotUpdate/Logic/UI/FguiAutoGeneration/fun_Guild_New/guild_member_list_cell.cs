/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guild_member_list_cell : GComponent
    {
        public Controller job;
        public GImage n28;
        public GImage n33;
        public guild_player_head head;
        public GTextField txt_name;
        public ui_postion txt_position;
        public GTextField txt_money;
        public GTextField txt_loginTime;
        public GTextField power_title;
        public GTextField power_num;
        public const string URL = "ui://qz6135j3eqnf1ayr89b";

        public static guild_member_list_cell CreateInstance()
        {
            return (guild_member_list_cell)UIPackage.CreateObject("fun_Guild_New", "guild_member_list_cell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            job = GetControllerAt(0);
            n28 = (GImage)GetChildAt(0);
            n33 = (GImage)GetChildAt(1);
            head = (guild_player_head)GetChildAt(2);
            txt_name = (GTextField)GetChildAt(3);
            txt_position = (ui_postion)GetChildAt(4);
            txt_money = (GTextField)GetChildAt(5);
            txt_loginTime = (GTextField)GetChildAt(6);
            power_title = (GTextField)GetChildAt(7);
            power_num = (GTextField)GetChildAt(8);
        }
    }
}