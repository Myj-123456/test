/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_DailyTask
{
    public partial class btn : GButton
    {
        public GImage n1;
        public GTextField titleLab;
        public const string URL = "ui://ueo46waakelj1ayr82g";

        public static btn CreateInstance()
        {
            return (btn)UIPackage.CreateObject("fun_DailyTask", "btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
        }
    }
}