/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class guild_join : GComponent
    {
        public GImage n39;
        public GImage n42;
        public GImage n43;
        public guild_list_title guildListTitle;
        public GList list_guild;
        public GTextInput txt_input;
        public GTextField txt_input_prompt;
        public GTextField titleLab;
        public btn_search btn_search;
        public GButton btn_create;
        public GButton randomJoinBtn;
        public GButton close_btn;
        public const string URL = "ui://6wv667gulmnhpd9";

        public static guild_join CreateInstance()
        {
            return (guild_join)UIPackage.CreateObject("fun_Guild", "guild_join");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n39 = (GImage)GetChildAt(0);
            n42 = (GImage)GetChildAt(1);
            n43 = (GImage)GetChildAt(2);
            guildListTitle = (guild_list_title)GetChildAt(3);
            list_guild = (GList)GetChildAt(4);
            txt_input = (GTextInput)GetChildAt(5);
            txt_input_prompt = (GTextField)GetChildAt(6);
            titleLab = (GTextField)GetChildAt(7);
            btn_search = (btn_search)GetChildAt(8);
            btn_create = (GButton)GetChildAt(9);
            randomJoinBtn = (GButton)GetChildAt(10);
            close_btn = (GButton)GetChildAt(11);
        }
    }
}