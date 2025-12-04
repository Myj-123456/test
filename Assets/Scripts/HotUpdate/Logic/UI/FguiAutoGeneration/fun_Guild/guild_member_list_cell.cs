/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class guild_member_list_cell : GComponent
    {
        public Controller job;
        public GImage n28;
        public GImage n31;
        public GImage n29;
        public GImage n30;
        public guild_player_head head;
        public GTextField txt_name;
        public GTextField txt_position;
        public GTextField txt_money;
        public GTextField txt_loginTime;
        public const string URL = "ui://6wv667guxy3spdf";

        public static guild_member_list_cell CreateInstance()
        {
            return (guild_member_list_cell)UIPackage.CreateObject("fun_Guild", "guild_member_list_cell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            job = GetControllerAt(0);
            n28 = (GImage)GetChildAt(0);
            n31 = (GImage)GetChildAt(1);
            n29 = (GImage)GetChildAt(2);
            n30 = (GImage)GetChildAt(3);
            head = (guild_player_head)GetChildAt(4);
            txt_name = (GTextField)GetChildAt(5);
            txt_position = (GTextField)GetChildAt(6);
            txt_money = (GTextField)GetChildAt(7);
            txt_loginTime = (GTextField)GetChildAt(8);
        }
    }
}