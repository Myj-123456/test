/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_AntiAddiction
{
    public partial class AntiAddictionWindow : GComponent
    {
        public GLoader bg;
        public GImage n13;
        public GImage n14;
        public GButton close_btn;
        public GImage n26;
        public GRichTextField txtMsg;
        public const string URL = "ui://s81ufvq1nwmn7";

        public static AntiAddictionWindow CreateInstance()
        {
            return (AntiAddictionWindow)UIPackage.CreateObject("fun_AntiAddiction", "AntiAddictionWindow");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            n13 = (GImage)GetChildAt(1);
            n14 = (GImage)GetChildAt(2);
            close_btn = (GButton)GetChildAt(3);
            n26 = (GImage)GetChildAt(4);
            txtMsg = (GRichTextField)GetChildAt(5);
        }
    }
}