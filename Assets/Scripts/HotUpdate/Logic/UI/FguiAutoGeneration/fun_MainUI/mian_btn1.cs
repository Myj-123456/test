/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MainUI
{
    public partial class mian_btn1 : GButton
    {
        public Controller status;
        public GImage n5;
        public GImage n6;
        public GTextField titleLab;
        public const string URL = "ui://fa0hi8ybx92m3w";

        public static mian_btn1 CreateInstance()
        {
            return (mian_btn1)UIPackage.CreateObject("fun_MainUI", "mian_btn1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n5 = (GImage)GetChildAt(0);
            n6 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}