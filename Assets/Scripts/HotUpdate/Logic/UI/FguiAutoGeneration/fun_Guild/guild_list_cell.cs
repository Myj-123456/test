/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class guild_list_cell : GComponent
    {
        public GImage n22;
        public GImage n24;
        public GImage n25;
        public GImage n26;
        public GTextField txt_id;
        public GTextField txt_name;
        public GTextField txt_slogan;
        public GTextField txt_lv;
        public GTextField txt_num;
        public GButton btn_operate;
        public const string URL = "ui://6wv667gulmnhpd8";

        public static guild_list_cell CreateInstance()
        {
            return (guild_list_cell)UIPackage.CreateObject("fun_Guild", "guild_list_cell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n22 = (GImage)GetChildAt(0);
            n24 = (GImage)GetChildAt(1);
            n25 = (GImage)GetChildAt(2);
            n26 = (GImage)GetChildAt(3);
            txt_id = (GTextField)GetChildAt(4);
            txt_name = (GTextField)GetChildAt(5);
            txt_slogan = (GTextField)GetChildAt(6);
            txt_lv = (GTextField)GetChildAt(7);
            txt_num = (GTextField)GetChildAt(8);
            btn_operate = (GButton)GetChildAt(9);
        }
    }
}