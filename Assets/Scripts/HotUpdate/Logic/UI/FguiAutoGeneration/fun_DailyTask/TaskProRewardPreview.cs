/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_DailyTask
{
    public partial class TaskProRewardPreview : GComponent
    {
        public GLoader bg;
        public GButton close_btn;
        public GImage n15;
        public GTextField poorLab;
        public GImage n12;
        public GTextField titleLab;
        public GImage n18;
        public GList list;
        public GRichTextField tipLab;
        public const string URL = "ui://ueo46waad1ei1yjp7y9";

        public static TaskProRewardPreview CreateInstance()
        {
            return (TaskProRewardPreview)UIPackage.CreateObject("fun_DailyTask", "TaskProRewardPreview");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            close_btn = (GButton)GetChildAt(1);
            n15 = (GImage)GetChildAt(2);
            poorLab = (GTextField)GetChildAt(3);
            n12 = (GImage)GetChildAt(4);
            titleLab = (GTextField)GetChildAt(5);
            n18 = (GImage)GetChildAt(6);
            list = (GList)GetChildAt(7);
            tipLab = (GRichTextField)GetChildAt(8);
        }
    }
}