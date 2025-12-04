/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class guild_posName_list_cell : GComponent
    {
        public GImage n16;
        public GTextField txt_posName;
        public GButton btn_changeName;
        public GTextField txt_posNameDefault;
        public const string URL = "ui://6wv667guxy3spdj";

        public static guild_posName_list_cell CreateInstance()
        {
            return (guild_posName_list_cell)UIPackage.CreateObject("fun_Guild", "guild_posName_list_cell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n16 = (GImage)GetChildAt(0);
            txt_posName = (GTextField)GetChildAt(1);
            btn_changeName = (GButton)GetChildAt(2);
            txt_posNameDefault = (GTextField)GetChildAt(3);
        }
    }
}