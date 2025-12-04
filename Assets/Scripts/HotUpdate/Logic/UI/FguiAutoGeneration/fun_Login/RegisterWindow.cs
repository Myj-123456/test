/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Login
{
    public partial class RegisterWindow : GComponent
    {
        public GLoader bg;
        public GImage n17;
        public GImage n18;
        public GButton btn_cancel;
        public GImage n20;
        public GButton btn_confirm;
        public GTextField n22;
        public GImage n23;
        public GTextInput input_account;
        public GTextField n26;
        public GImage n27;
        public GTextInput input_pwd;
        public GTextField n30;
        public GImage n31;
        public GTextInput input_confirmPwd;
        public const string URL = "ui://sid64f75t1qr1";

        public static RegisterWindow CreateInstance()
        {
            return (RegisterWindow)UIPackage.CreateObject("fun_Login", "RegisterWindow");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            n17 = (GImage)GetChildAt(1);
            n18 = (GImage)GetChildAt(2);
            btn_cancel = (GButton)GetChildAt(3);
            n20 = (GImage)GetChildAt(4);
            btn_confirm = (GButton)GetChildAt(5);
            n22 = (GTextField)GetChildAt(6);
            n23 = (GImage)GetChildAt(7);
            input_account = (GTextInput)GetChildAt(8);
            n26 = (GTextField)GetChildAt(9);
            n27 = (GImage)GetChildAt(10);
            input_pwd = (GTextInput)GetChildAt(11);
            n30 = (GTextField)GetChildAt(12);
            n31 = (GImage)GetChildAt(13);
            input_confirmPwd = (GTextInput)GetChildAt(14);
        }
    }
}