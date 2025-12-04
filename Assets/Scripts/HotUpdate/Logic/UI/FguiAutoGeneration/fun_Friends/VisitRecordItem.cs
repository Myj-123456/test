/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class VisitRecordItem : GComponent
    {
        public Controller txtcontroller;
        public GImage n1;
        public GComponent heead;
        public GComponent picFrame;
        public GImage icon;
        public GTextField txt_lv;
        public GTextField txt_name;
        public GButton btn_newApply;
        public GTextField Text_time;
        public GImage n14;
        public GImage n15;
        public GTextField txt_numberVisit;
        public GTextField txt_daysVisit;
        public btn_visit n20;
        public const string URL = "ui://fteyf9nzybxr1yjp7uh";

        public static VisitRecordItem CreateInstance()
        {
            return (VisitRecordItem)UIPackage.CreateObject("fun_Friends", "VisitRecordItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            txtcontroller = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            heead = (GComponent)GetChildAt(1);
            picFrame = (GComponent)GetChildAt(2);
            icon = (GImage)GetChildAt(3);
            txt_lv = (GTextField)GetChildAt(4);
            txt_name = (GTextField)GetChildAt(5);
            btn_newApply = (GButton)GetChildAt(6);
            Text_time = (GTextField)GetChildAt(7);
            n14 = (GImage)GetChildAt(8);
            n15 = (GImage)GetChildAt(9);
            txt_numberVisit = (GTextField)GetChildAt(10);
            txt_daysVisit = (GTextField)GetChildAt(11);
            n20 = (btn_visit)GetChildAt(12);
        }
    }
}