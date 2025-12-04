/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Certification
{
    public partial class CertificationWindow : GComponent
    {
        public GTextField n0;
        public GImage n1;
        public GTextInput input_account;
        public GTextField n4;
        public GImage n5;
        public GTextInput input_pwd;
        public GButton btn_register;
        public GTextField n10;
        public GRichTextField lab_antiAddiction;
        public const string URL = "ui://s81ufvq1t1qr0";

        public static CertificationWindow CreateInstance()
        {
            return (CertificationWindow)UIPackage.CreateObject("fun_Certification", "CertificationWindow");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GTextField)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
            input_account = (GTextInput)GetChildAt(2);
            n4 = (GTextField)GetChildAt(3);
            n5 = (GImage)GetChildAt(4);
            input_pwd = (GTextInput)GetChildAt(5);
            btn_register = (GButton)GetChildAt(6);
            n10 = (GTextField)GetChildAt(7);
            lab_antiAddiction = (GRichTextField)GetChildAt(8);
        }
    }
}