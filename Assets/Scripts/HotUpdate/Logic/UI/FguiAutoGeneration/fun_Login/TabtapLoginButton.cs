/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Login
{
    public partial class TabtapLoginButton : GButton
    {
        public Controller button;
        public GImage n4;
        public const string URL = "ui://sid64f75r9d6m";

        public static TabtapLoginButton CreateInstance()
        {
            return (TabtapLoginButton)UIPackage.CreateObject("fun_Login", "TabtapLoginButton");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n4 = (GImage)GetChildAt(0);
        }
    }
}