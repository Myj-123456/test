/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class guild_member_list_cell_new : GComponent
    {
        public Controller job;
        public GImage n33;
        public GImage n31;
        public GImage n29;
        public guild_player_head head;
        public GTextField txt_name;
        public GTextField txt_position;
        public GTextField txt_money;
        public GTextField txt_loginTime;
        public const string URL = "ui://6wv667gus7ir1ayr810";

        public static guild_member_list_cell_new CreateInstance()
        {
            return (guild_member_list_cell_new)UIPackage.CreateObject("fun_Guild", "guild_member_list_cell_new");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            job = GetControllerAt(0);
            n33 = (GImage)GetChildAt(0);
            n31 = (GImage)GetChildAt(1);
            n29 = (GImage)GetChildAt(2);
            head = (guild_player_head)GetChildAt(3);
            txt_name = (GTextField)GetChildAt(4);
            txt_position = (GTextField)GetChildAt(5);
            txt_money = (GTextField)GetChildAt(6);
            txt_loginTime = (GTextField)GetChildAt(7);
        }
    }
}