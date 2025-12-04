/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_AntiAddiction
{
    public partial class CertificationWindow : GComponent
    {
        public GLoader bg;
        public GImage n13;
        public GImage n14;
        public GButton btn_submit;
        public GRichTextField lab_antiAddiction;
        public GTextField n16;
        public GImage n17;
        public GTextInput input_name;
        public GTextField n20;
        public GImage n21;
        public GTextInput input_identityCard;
        public GImage n24;
        public GImage n25;
        public GRichTextField txtMsg;
        public const string URL = "ui://s81ufvq1t1qr0";

        public static CertificationWindow CreateInstance()
        {
            return (CertificationWindow)UIPackage.CreateObject("fun_AntiAddiction", "CertificationWindow");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            n13 = (GImage)GetChildAt(1);
            n14 = (GImage)GetChildAt(2);
            btn_submit = (GButton)GetChildAt(3);
            lab_antiAddiction = (GRichTextField)GetChildAt(4);
            n16 = (GTextField)GetChildAt(5);
            n17 = (GImage)GetChildAt(6);
            input_name = (GTextInput)GetChildAt(7);
            n20 = (GTextField)GetChildAt(8);
            n21 = (GImage)GetChildAt(9);
            input_identityCard = (GTextInput)GetChildAt(10);
            n24 = (GImage)GetChildAt(11);
            n25 = (GImage)GetChildAt(12);
            txtMsg = (GRichTextField)GetChildAt(13);
        }
    }
}