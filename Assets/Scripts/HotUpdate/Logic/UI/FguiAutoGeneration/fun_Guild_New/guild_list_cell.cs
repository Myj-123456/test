/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guild_list_cell : GComponent
    {
        public GImage n22;
        public GImage n24;
        public guild_icon guild_icon;
        public GImage n25;
        public GImage n27;
        public GTextField txt_id;
        public GTextField power_title;
        public GTextField txt_name;
        public GTextField txt_lv;
        public GTextField txt_num;
        public GButton btn_operate;
        public GTextField power_num;
        public const string URL = "ui://qz6135j3r9vt1ayr89d";

        public static guild_list_cell CreateInstance()
        {
            return (guild_list_cell)UIPackage.CreateObject("fun_Guild_New", "guild_list_cell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n22 = (GImage)GetChildAt(0);
            n24 = (GImage)GetChildAt(1);
            guild_icon = (guild_icon)GetChildAt(2);
            n25 = (GImage)GetChildAt(3);
            n27 = (GImage)GetChildAt(4);
            txt_id = (GTextField)GetChildAt(5);
            power_title = (GTextField)GetChildAt(6);
            txt_name = (GTextField)GetChildAt(7);
            txt_lv = (GTextField)GetChildAt(8);
            txt_num = (GTextField)GetChildAt(9);
            btn_operate = (GButton)GetChildAt(10);
            power_num = (GTextField)GetChildAt(11);
        }
    }
}