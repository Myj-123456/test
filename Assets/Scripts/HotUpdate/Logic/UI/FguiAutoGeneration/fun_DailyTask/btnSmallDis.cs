/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_DailyTask
{
    public partial class btnSmallDis : GButton
    {
        public GImage n3;
        public GTextField titleLab;
        public const string URL = "ui://ueo46waad1ei1ayr82p";

        public static btnSmallDis CreateInstance()
        {
            return (btnSmallDis)UIPackage.CreateObject("fun_DailyTask", "btnSmallDis");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n3 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
        }
    }
}