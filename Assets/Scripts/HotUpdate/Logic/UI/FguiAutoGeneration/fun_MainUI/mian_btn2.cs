/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MainUI
{
    public partial class mian_btn2 : GButton
    {
        public Controller status;
        public GImage n20;
        public GImage n21;
        public GImage n22;
        public GImage n23;
        public GImage n24;
        public GImage n25;
        public GImage n26;
        public GImage red_point;
        public GTextField titleLab;
        public const string URL = "ui://fa0hi8ybx92m3z";

        public static mian_btn2 CreateInstance()
        {
            return (mian_btn2)UIPackage.CreateObject("fun_MainUI", "mian_btn2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n20 = (GImage)GetChildAt(0);
            n21 = (GImage)GetChildAt(1);
            n22 = (GImage)GetChildAt(2);
            n23 = (GImage)GetChildAt(3);
            n24 = (GImage)GetChildAt(4);
            n25 = (GImage)GetChildAt(5);
            n26 = (GImage)GetChildAt(6);
            red_point = (GImage)GetChildAt(7);
            titleLab = (GTextField)GetChildAt(8);
        }
    }
}