/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guild_join : GComponent
    {
        public GImage n48;
        public GLoader bg;
        public GImage n47;
        public GImage n43;
        public GImage n53;
        public GList list_guild;
        public GTextInput txt_input;
        public GTextField txt_input_prompt;
        public GTextField txt_code;
        public GTextField txt_name;
        public GTextField txt_num;
        public GButton btn_search;
        public GButton btn_create;
        public GButton randomJoinBtn;
        public GButton close_btn;
        public const string URL = "ui://qz6135j3r9vt1ayr89b";

        public static guild_join CreateInstance()
        {
            return (guild_join)UIPackage.CreateObject("fun_Guild_New", "guild_join");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n48 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n47 = (GImage)GetChildAt(2);
            n43 = (GImage)GetChildAt(3);
            n53 = (GImage)GetChildAt(4);
            list_guild = (GList)GetChildAt(5);
            txt_input = (GTextInput)GetChildAt(6);
            txt_input_prompt = (GTextField)GetChildAt(7);
            txt_code = (GTextField)GetChildAt(8);
            txt_name = (GTextField)GetChildAt(9);
            txt_num = (GTextField)GetChildAt(10);
            btn_search = (GButton)GetChildAt(11);
            btn_create = (GButton)GetChildAt(12);
            randomJoinBtn = (GButton)GetChildAt(13);
            close_btn = (GButton)GetChildAt(14);
        }
    }
}