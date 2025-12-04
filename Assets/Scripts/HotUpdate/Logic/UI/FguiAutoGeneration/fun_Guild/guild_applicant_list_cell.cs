/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class guild_applicant_list_cell : GComponent
    {
        public GImage n25;
        public GImage n28;
        public guild_player_head head;
        public GTextField txt_name;
        public GButton btn_refuse;
        public GButton btn_accept;
        public const string URL = "ui://6wv667guxy3spdg";

        public static guild_applicant_list_cell CreateInstance()
        {
            return (guild_applicant_list_cell)UIPackage.CreateObject("fun_Guild", "guild_applicant_list_cell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n25 = (GImage)GetChildAt(0);
            n28 = (GImage)GetChildAt(1);
            head = (guild_player_head)GetChildAt(2);
            txt_name = (GTextField)GetChildAt(3);
            btn_refuse = (GButton)GetChildAt(4);
            btn_accept = (GButton)GetChildAt(5);
        }
    }
}