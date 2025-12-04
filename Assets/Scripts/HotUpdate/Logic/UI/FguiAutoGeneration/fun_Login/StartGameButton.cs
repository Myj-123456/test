/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Login
{
    public partial class StartGameButton : GButton
    {
        public Controller button;
        public GImage n4;
        public const string URL = "ui://sid64f75r9d6n";

        public static StartGameButton CreateInstance()
        {
            return (StartGameButton)UIPackage.CreateObject("fun_Login", "StartGameButton");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n4 = (GImage)GetChildAt(0);
        }
    }
}