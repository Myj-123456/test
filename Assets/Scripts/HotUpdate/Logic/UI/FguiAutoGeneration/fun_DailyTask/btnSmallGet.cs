/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_DailyTask
{
    public partial class btnSmallGet : GButton
    {
        public GImage n0;
        public GTextField titleLab;
        public const string URL = "ui://ueo46waad1ei1ayr82t";

        public static btnSmallGet CreateInstance()
        {
            return (btnSmallGet)UIPackage.CreateObject("fun_DailyTask", "btnSmallGet");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
        }
    }
}