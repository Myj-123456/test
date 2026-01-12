/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class VisitRecordView : GComponent
    {
        public Controller status;
        public GLoader bg;
        public GTextField best_Title;
        public GImage n56;
        public GButton close_btn;
        public GList list;
        public GTextField n20;
        public GLoader pic_img;
        public GTextField n22;
        public GImage n23;
        public btn_best_book btn_best_buyBook;
        public GTextField n25;
        public GTextField n54;
        public GComponent emptyTip;
        public const string URL = "ui://fteyf9nzybxr1yjp7ug";

        public static VisitRecordView CreateInstance()
        {
            return (VisitRecordView)UIPackage.CreateObject("fun_Friends", "VisitRecordView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            best_Title = (GTextField)GetChildAt(1);
            n56 = (GImage)GetChildAt(2);
            close_btn = (GButton)GetChildAt(3);
            list = (GList)GetChildAt(4);
            n20 = (GTextField)GetChildAt(5);
            pic_img = (GLoader)GetChildAt(6);
            n22 = (GTextField)GetChildAt(7);
            n23 = (GImage)GetChildAt(8);
            btn_best_buyBook = (btn_best_book)GetChildAt(9);
            n25 = (GTextField)GetChildAt(10);
            n54 = (GTextField)GetChildAt(11);
            emptyTip = (GComponent)GetChildAt(12);
        }
    }
}