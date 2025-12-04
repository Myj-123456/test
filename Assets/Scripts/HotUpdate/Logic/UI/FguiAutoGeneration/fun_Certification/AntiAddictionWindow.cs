/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Certification
{
    public partial class AntiAddictionWindow : GComponent
    {
        public GTextField n12;
        public GTextField n13;
        public const string URL = "ui://s81ufvq1t1qr1";

        public static AntiAddictionWindow CreateInstance()
        {
            return (AntiAddictionWindow)UIPackage.CreateObject("fun_Certification", "AntiAddictionWindow");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n12 = (GTextField)GetChildAt(0);
            n13 = (GTextField)GetChildAt(1);
        }
    }
}