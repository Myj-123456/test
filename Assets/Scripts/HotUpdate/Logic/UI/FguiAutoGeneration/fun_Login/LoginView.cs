/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Login
{
    public partial class LoginView : GComponent
    {
        public GGraph bg;
        public LoginButton btn_login;
        public GTextField n1;
        public GImage n2;
        public GTextInput input_account;
        public GList list_server;
        public GGroup n8;
        public CheckButton btn_skipGuide;
        public const string URL = "ui://sid64f75t7qpd";

        public static LoginView CreateInstance()
        {
            return (LoginView)UIPackage.CreateObject("fun_Login", "LoginView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GGraph)GetChildAt(0);
            btn_login = (LoginButton)GetChildAt(1);
            n1 = (GTextField)GetChildAt(2);
            n2 = (GImage)GetChildAt(3);
            input_account = (GTextInput)GetChildAt(4);
            list_server = (GList)GetChildAt(5);
            n8 = (GGroup)GetChildAt(6);
            btn_skipGuide = (CheckButton)GetChildAt(7);
        }
    }
}