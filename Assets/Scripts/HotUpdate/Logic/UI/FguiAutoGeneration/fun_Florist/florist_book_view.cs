/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Florist
{
    public partial class florist_book_view : GComponent
    {
        public Controller showChose;
        public GList list;
        public chose_quailty_btn chose_btn;
        public GImage n2;
        public GImage n6;
        public GTextField powerName;
        public GTextField powerNum;
        public chose_qualirt chose_grp;
        public GGroup n9;
        public const string URL = "ui://nj16dzxym3gh7";

        public static florist_book_view CreateInstance()
        {
            return (florist_book_view)UIPackage.CreateObject("fun_Florist", "florist_book_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            showChose = GetControllerAt(0);
            list = (GList)GetChildAt(0);
            chose_btn = (chose_quailty_btn)GetChildAt(1);
            n2 = (GImage)GetChildAt(2);
            n6 = (GImage)GetChildAt(3);
            powerName = (GTextField)GetChildAt(4);
            powerNum = (GTextField)GetChildAt(5);
            chose_grp = (chose_qualirt)GetChildAt(6);
            n9 = (GGroup)GetChildAt(7);
        }
    }
}