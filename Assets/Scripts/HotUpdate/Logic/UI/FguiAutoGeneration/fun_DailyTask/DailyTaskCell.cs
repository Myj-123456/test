/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_DailyTask
{
    public partial class DailyTaskCell : GComponent
    {
        public GLoader bg;
        public GLoader img;
        public GTextField count;
        public const string URL = "ui://ueo46waas23el";

        public static DailyTaskCell CreateInstance()
        {
            return (DailyTaskCell)UIPackage.CreateObject("fun_DailyTask", "DailyTaskCell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            img = (GLoader)GetChildAt(1);
            count = (GTextField)GetChildAt(2);
        }
    }
}