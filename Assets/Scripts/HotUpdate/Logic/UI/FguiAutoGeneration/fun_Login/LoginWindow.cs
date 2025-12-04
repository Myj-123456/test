/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Login
{
    public partial class LoginWindow : GComponent
    {
        public GLoader bg;
        public GImage n18;
        public GImage n20;
        public GButton btn_login;
        public GImage n22;
        public GButton btn_register;
        public GTextField n1;
        public GImage n3;
        public GTextInput input_account;
        public GTextField n35;
        public GImage n36;
        public GTextInput input_pwd;
        public const string URL = "ui://sid64f75t1qr0";

        public static LoginWindow CreateInstance()
        {
            return (LoginWindow)UIPackage.CreateObject("fun_Login", "LoginWindow");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            n18 = (GImage)GetChildAt(1);
            n20 = (GImage)GetChildAt(2);
            btn_login = (GButton)GetChildAt(3);
            n22 = (GImage)GetChildAt(4);
            btn_register = (GButton)GetChildAt(5);
            n1 = (GTextField)GetChildAt(6);
            n3 = (GImage)GetChildAt(7);
            input_account = (GTextInput)GetChildAt(8);
            n35 = (GTextField)GetChildAt(9);
            n36 = (GImage)GetChildAt(10);
            input_pwd = (GTextInput)GetChildAt(11);
        }
    }
}