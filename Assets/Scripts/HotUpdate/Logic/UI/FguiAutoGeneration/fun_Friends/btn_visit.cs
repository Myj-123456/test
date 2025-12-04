/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class btn_visit : GButton
    {
        public Controller button;
        public GImage n1;
        public const string URL = "ui://fteyf9nzybxr1yjp7ui";

        public static btn_visit CreateInstance()
        {
            return (btn_visit)UIPackage.CreateObject("fun_Friends", "btn_visit");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
        }
    }
}