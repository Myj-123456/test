/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class guild_upgrade_confirm_list_cell : GComponent
    {
        public GImage n15;
        public GRichTextField txt_desc;
        public const string URL = "ui://6wv667guqs0npfm";

        public static guild_upgrade_confirm_list_cell CreateInstance()
        {
            return (guild_upgrade_confirm_list_cell)UIPackage.CreateObject("fun_Guild", "guild_upgrade_confirm_list_cell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n15 = (GImage)GetChildAt(0);
            txt_desc = (GRichTextField)GetChildAt(1);
        }
    }
}