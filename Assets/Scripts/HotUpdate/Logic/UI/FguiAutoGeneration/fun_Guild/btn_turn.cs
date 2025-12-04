/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class btn_turn : GButton
    {
        public Controller button;
        public GImage n0;
        public const string URL = "ui://6wv667gus23e27";

        public static btn_turn CreateInstance()
        {
            return (btn_turn)UIPackage.CreateObject("fun_Guild", "btn_turn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n0 = (GImage)GetChildAt(0);
        }
    }
}