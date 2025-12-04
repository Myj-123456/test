/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Login
{
    public partial class LoginButton : GButton
    {
        public Controller button;
        public GGraph n0;
        public GGraph n1;
        public GGraph n2;
        public GTextField title;
        public const string URL = "ui://sid64f75t7qpj";

        public static LoginButton CreateInstance()
        {
            return (LoginButton)UIPackage.CreateObject("fun_Login", "LoginButton");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n0 = (GGraph)GetChildAt(0);
            n1 = (GGraph)GetChildAt(1);
            n2 = (GGraph)GetChildAt(2);
            title = (GTextField)GetChildAt(3);
        }
    }
}