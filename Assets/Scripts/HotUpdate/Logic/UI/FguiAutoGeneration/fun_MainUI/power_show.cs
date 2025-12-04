/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MainUI
{
    public partial class power_show : GComponent
    {
        public GImage n5;
        public GTextField powerNum;
        public const string URL = "ui://fa0hi8ybx92m4i";

        public static power_show CreateInstance()
        {
            return (power_show)UIPackage.CreateObject("fun_MainUI", "power_show");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n5 = (GImage)GetChildAt(0);
            powerNum = (GTextField)GetChildAt(1);
        }
    }
}