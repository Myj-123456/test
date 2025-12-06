/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_DailyTask
{
    public partial class pro_item : GComponent
    {
        public Controller status;
        public GImage n4;
        public GImage n5;
        public GTextField proLab;
        public const string URL = "ui://ueo46waaz1vi1ayr81m";

        public static pro_item CreateInstance()
        {
            return (pro_item)UIPackage.CreateObject("fun_DailyTask", "pro_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n4 = (GImage)GetChildAt(0);
            n5 = (GImage)GetChildAt(1);
            proLab = (GTextField)GetChildAt(2);
        }
    }
}