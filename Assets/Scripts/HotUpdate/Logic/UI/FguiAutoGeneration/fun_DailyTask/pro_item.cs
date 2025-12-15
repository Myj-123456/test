/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_DailyTask
{
    public partial class pro_item : GComponent
    {
        public Controller status;
        public GImage n4;
        public GImage n8;
        public GImage n5;
        public GImage n9;
        public GImage n10;
        public GTextField proLab;
        public GImage n11;
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
            n8 = (GImage)GetChildAt(1);
            n5 = (GImage)GetChildAt(2);
            n9 = (GImage)GetChildAt(3);
            n10 = (GImage)GetChildAt(4);
            proLab = (GTextField)GetChildAt(5);
            n11 = (GImage)GetChildAt(6);
        }
    }
}