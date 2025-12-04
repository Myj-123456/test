/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Customer
{
    public partial class detail_btn : GButton
    {
        public GImage n1;
        public GImage n2;
        public GTextField titleLab;
        public const string URL = "ui://pcr735xhcs1mb";

        public static detail_btn CreateInstance()
        {
            return (detail_btn)UIPackage.CreateObject("fun_Customer", "detail_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}