/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MainUI
{
    public partial class mian_btn4 : GButton
    {
        public Controller status;
        public GImage n19;
        public GImage n21;
        public GImage n20;
        public GImage red_point;
        public const string URL = "ui://fa0hi8ybx92m4a";

        public static mian_btn4 CreateInstance()
        {
            return (mian_btn4)UIPackage.CreateObject("fun_MainUI", "mian_btn4");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n19 = (GImage)GetChildAt(0);
            n21 = (GImage)GetChildAt(1);
            n20 = (GImage)GetChildAt(2);
            red_point = (GImage)GetChildAt(3);
        }
    }
}