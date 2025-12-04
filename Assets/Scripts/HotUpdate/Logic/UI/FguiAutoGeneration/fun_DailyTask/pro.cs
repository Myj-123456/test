/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_DailyTask
{
    public partial class pro : GProgressBar
    {
        public GImage n12;
        public GImage bar;
        public const string URL = "ui://ueo46waaz1vi1ayr81w";

        public static pro CreateInstance()
        {
            return (pro)UIPackage.CreateObject("fun_DailyTask", "pro");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n12 = (GImage)GetChildAt(0);
            bar = (GImage)GetChildAt(1);
        }
    }
}