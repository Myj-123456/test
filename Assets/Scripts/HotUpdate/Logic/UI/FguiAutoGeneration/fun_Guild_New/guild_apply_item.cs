/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guild_apply_item : GComponent
    {
        public Controller job;
        public GImage n28;
        public guild_player_head head;
        public GTextField txt_name;
        public GTextField power_title;
        public GTextField power_num;
        public GButton btn_accept;
        public GButton btn_refuse;
        public const string URL = "ui://qz6135j3tewh1yjp7zv";

        public static guild_apply_item CreateInstance()
        {
            return (guild_apply_item)UIPackage.CreateObject("fun_Guild_New", "guild_apply_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            job = GetControllerAt(0);
            n28 = (GImage)GetChildAt(0);
            head = (guild_player_head)GetChildAt(1);
            txt_name = (GTextField)GetChildAt(2);
            power_title = (GTextField)GetChildAt(3);
            power_num = (GTextField)GetChildAt(4);
            btn_accept = (GButton)GetChildAt(5);
            btn_refuse = (GButton)GetChildAt(6);
        }
    }
}