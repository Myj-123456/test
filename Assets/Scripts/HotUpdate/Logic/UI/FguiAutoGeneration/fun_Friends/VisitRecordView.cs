/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class VisitRecordView : GComponent
    {
        public Controller status;
        public GImage n2;
        public GLoader bg;
        public GTextField titleLab;
        public GButton close_btn;
        public GList list;
        public GComponent nullTip;
        public GTextField n20;
        public GImage n21;
        public GTextField n22;
        public GImage n23;
        public btn_best_book btn_best_buyBook;
        public GTextField n25;
        public GTextField n54;
        public const string URL = "ui://fteyf9nzybxr1yjp7ug";

        public static VisitRecordView CreateInstance()
        {
            return (VisitRecordView)UIPackage.CreateObject("fun_Friends", "VisitRecordView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n2 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
            close_btn = (GButton)GetChildAt(3);
            list = (GList)GetChildAt(4);
            nullTip = (GComponent)GetChildAt(5);
            n20 = (GTextField)GetChildAt(6);
            n21 = (GImage)GetChildAt(7);
            n22 = (GTextField)GetChildAt(8);
            n23 = (GImage)GetChildAt(9);
            btn_best_buyBook = (btn_best_book)GetChildAt(10);
            n25 = (GTextField)GetChildAt(11);
            n54 = (GTextField)GetChildAt(12);
        }
    }
}