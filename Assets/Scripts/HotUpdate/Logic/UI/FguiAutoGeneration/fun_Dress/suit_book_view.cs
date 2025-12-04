/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Dress
{
    public partial class suit_book_view : GComponent
    {
        public Controller showChose;
        public GList list;
        public chose_quailty_btn chose_btn;
        public chose_qualirt chose_grp;
        public GGroup n24;
        public const string URL = "ui://argzn455hstt1yjp830";

        public static suit_book_view CreateInstance()
        {
            return (suit_book_view)UIPackage.CreateObject("fun_Dress", "suit_book_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            showChose = GetControllerAt(0);
            list = (GList)GetChildAt(0);
            chose_btn = (chose_quailty_btn)GetChildAt(1);
            chose_grp = (chose_qualirt)GetChildAt(2);
            n24 = (GGroup)GetChildAt(3);
        }
    }
}