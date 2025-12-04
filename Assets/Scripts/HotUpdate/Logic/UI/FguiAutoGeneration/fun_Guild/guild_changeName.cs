/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class guild_changeName : GComponent
    {
        public GImage n9;
        public GImage n14;
        public GTextInput txt_input;
        public GTextField tip;
        public GButton btn_sure;
        public GButton btn_cancel;
        public const string URL = "ui://6wv667gumxcypft";

        public static guild_changeName CreateInstance()
        {
            return (guild_changeName)UIPackage.CreateObject("fun_Guild", "guild_changeName");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n9 = (GImage)GetChildAt(0);
            n14 = (GImage)GetChildAt(1);
            txt_input = (GTextInput)GetChildAt(2);
            tip = (GTextField)GetChildAt(3);
            btn_sure = (GButton)GetChildAt(4);
            btn_cancel = (GButton)GetChildAt(5);
        }
    }
}