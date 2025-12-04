/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_DailyTask
{
    public partial class DailyTaskItem : GComponent
    {
        public Controller receiveStatus;
        public GImage n47;
        public GImage n54;
        public GTextField nameTxt;
        public GTextField taskTxt;
        public GRichTextField progressTxt;
        public GList list;
        public GButton getBtn;
        public GButton getBtn1;
        public const string URL = "ui://ueo46waas23e1ayr810";

        public static DailyTaskItem CreateInstance()
        {
            return (DailyTaskItem)UIPackage.CreateObject("fun_DailyTask", "DailyTaskItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            receiveStatus = GetControllerAt(0);
            n47 = (GImage)GetChildAt(0);
            n54 = (GImage)GetChildAt(1);
            nameTxt = (GTextField)GetChildAt(2);
            taskTxt = (GTextField)GetChildAt(3);
            progressTxt = (GRichTextField)GetChildAt(4);
            list = (GList)GetChildAt(5);
            getBtn = (GButton)GetChildAt(6);
            getBtn1 = (GButton)GetChildAt(7);
        }
    }
}