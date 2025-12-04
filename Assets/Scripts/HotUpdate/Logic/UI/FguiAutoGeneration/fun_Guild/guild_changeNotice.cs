/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class guild_changeNotice : GComponent
    {
        public GImage n9;
        public GImage n22;
        public GTextInput txt_input;
        public GButton close_btn;
        public GButton btn_sure;
        public const string URL = "ui://6wv667gumxcypfu";

        public static guild_changeNotice CreateInstance()
        {
            return (guild_changeNotice)UIPackage.CreateObject("fun_Guild", "guild_changeNotice");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n9 = (GImage)GetChildAt(0);
            n22 = (GImage)GetChildAt(1);
            txt_input = (GTextInput)GetChildAt(2);
            close_btn = (GButton)GetChildAt(3);
            btn_sure = (GButton)GetChildAt(4);
        }
    }
}