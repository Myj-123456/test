/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_plant
{
    public partial class btn_turn : GButton
    {
        public Controller button;
        public GImage n0;
        public const string URL = "ui://4905g7p7s23e27";

        public static btn_turn CreateInstance()
        {
            return (btn_turn)UIPackage.CreateObject("fun_plant", "btn_turn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n0 = (GImage)GetChildAt(0);
        }
    }
}