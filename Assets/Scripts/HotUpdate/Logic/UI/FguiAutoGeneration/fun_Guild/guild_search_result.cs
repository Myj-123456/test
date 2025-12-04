/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class guild_search_result : GComponent
    {
        public GImage n31;
        public guild_list_title guildListTitle;
        public guild_list_cell guild_list_cell;
        public GTextField txt_title;
        public GButton close_btn;
        public const string URL = "ui://6wv667guxy3spdm";

        public static guild_search_result CreateInstance()
        {
            return (guild_search_result)UIPackage.CreateObject("fun_Guild", "guild_search_result");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n31 = (GImage)GetChildAt(0);
            guildListTitle = (guild_list_title)GetChildAt(1);
            guild_list_cell = (guild_list_cell)GetChildAt(2);
            txt_title = (GTextField)GetChildAt(3);
            close_btn = (GButton)GetChildAt(4);
        }
    }
}