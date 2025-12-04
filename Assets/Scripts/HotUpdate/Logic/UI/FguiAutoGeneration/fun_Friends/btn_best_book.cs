/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class btn_best_book : GButton
    {
        public Controller type;
        public GImage n14;
        public const string URL = "ui://fteyf9nzt6831yjp7ue";

        public static btn_best_book CreateInstance()
        {
            return (btn_best_book)UIPackage.CreateObject("fun_Friends", "btn_best_book");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            n14 = (GImage)GetChildAt(0);
        }
    }
}