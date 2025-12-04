/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class guild_list_title : GComponent
    {
        public GTextField txt_code;
        public GTextField txt_name;
        public GTextField txt_num;
        public const string URL = "ui://6wv667gux3ggpfx";

        public static guild_list_title CreateInstance()
        {
            return (guild_list_title)UIPackage.CreateObject("fun_Guild", "guild_list_title");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            txt_code = (GTextField)GetChildAt(0);
            txt_name = (GTextField)GetChildAt(1);
            txt_num = (GTextField)GetChildAt(2);
        }
    }
}