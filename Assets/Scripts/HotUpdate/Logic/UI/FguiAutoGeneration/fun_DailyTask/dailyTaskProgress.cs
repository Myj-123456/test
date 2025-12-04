/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_DailyTask
{
    public partial class dailyTaskProgress : GProgressBar
    {
        public GImage bg;
        public GImage bar;
        public const string URL = "ui://ueo46waas23ed";

        public static dailyTaskProgress CreateInstance()
        {
            return (dailyTaskProgress)UIPackage.CreateObject("fun_DailyTask", "dailyTaskProgress");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GImage)GetChildAt(0);
            bar = (GImage)GetChildAt(1);
        }
    }
}