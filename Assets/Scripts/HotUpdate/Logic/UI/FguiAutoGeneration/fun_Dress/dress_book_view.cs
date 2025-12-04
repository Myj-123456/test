/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Dress
{
    public partial class dress_book_view : GComponent
    {
        public Controller showChose;
        public GList list;
        public chose_quailty_btn chose_btn;
        public chose_qualirt chose_grp;
        public GImage n24;
        public GList list_filter;
        public GGroup n26;
        public const string URL = "ui://argzn455m3gh4s";

        public static dress_book_view CreateInstance()
        {
            return (dress_book_view)UIPackage.CreateObject("fun_Dress", "dress_book_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            showChose = GetControllerAt(0);
            list = (GList)GetChildAt(0);
            chose_btn = (chose_quailty_btn)GetChildAt(1);
            chose_grp = (chose_qualirt)GetChildAt(2);
            n24 = (GImage)GetChildAt(3);
            list_filter = (GList)GetChildAt(4);
            n26 = (GGroup)GetChildAt(5);
        }
    }
}