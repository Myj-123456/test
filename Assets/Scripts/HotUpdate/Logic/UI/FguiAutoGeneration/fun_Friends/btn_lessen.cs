/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class btn_lessen : GButton
    {
        public Controller button;
        public GImage n3;
        public const string URL = "ui://fteyf9nzrw6k1yjp7um";

        public static btn_lessen CreateInstance()
        {
            return (btn_lessen)UIPackage.CreateObject("fun_Friends", "btn_lessen");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n3 = (GImage)GetChildAt(0);
        }
    }
}