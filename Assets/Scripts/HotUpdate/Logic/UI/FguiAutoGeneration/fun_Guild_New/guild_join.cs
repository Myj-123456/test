/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guild_join : GComponent
    {
        public GLoader bg;
        public GTextField txt_Title;
        public GImage n56;
        public GImage n54;
        public GList list_guild;
        public GImage n43;
        public GTextField txt_input_prompt;
        public GTextInput txt_input;
        public GButton btn_search;
        public GTextField txt_code;
        public GTextField txt_num;
        public GTextField txt_name;
        public GButton close_btn;
        public GButton btn_create;
        public GButton randomJoinBtn;
        public const string URL = "ui://qz6135j3r9vt1ayr89b";

        public static guild_join CreateInstance()
        {
            return (guild_join)UIPackage.CreateObject("fun_Guild_New", "guild_join");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            txt_Title = (GTextField)GetChildAt(1);
            n56 = (GImage)GetChildAt(2);
            n54 = (GImage)GetChildAt(3);
            list_guild = (GList)GetChildAt(4);
            n43 = (GImage)GetChildAt(5);
            txt_input_prompt = (GTextField)GetChildAt(6);
            txt_input = (GTextInput)GetChildAt(7);
            btn_search = (GButton)GetChildAt(8);
            txt_code = (GTextField)GetChildAt(9);
            txt_num = (GTextField)GetChildAt(10);
            txt_name = (GTextField)GetChildAt(11);
            close_btn = (GButton)GetChildAt(12);
            btn_create = (GButton)GetChildAt(13);
            randomJoinBtn = (GButton)GetChildAt(14);
        }
    }
}