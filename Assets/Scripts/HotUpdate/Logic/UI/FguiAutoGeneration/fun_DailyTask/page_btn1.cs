/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_DailyTask
{
    public partial class page_btn1 : GButton
    {
        public Controller button;
        public GImage n0;
        public GImage n1;
        public GTextField titleLab;
        public GTextField titleLab1;
        public const string URL = "ui://ueo46waaz1vi1ayr81p";

        public static page_btn1 CreateInstance()
        {
            return (page_btn1)UIPackage.CreateObject("fun_DailyTask", "page_btn1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n0 = (GImage)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
            titleLab1 = (GTextField)GetChildAt(3);
        }
    }
}