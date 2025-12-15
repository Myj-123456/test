/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class btn_currency : GButton
    {
        public Controller button;
        public GImage n3;
        public const string URL = "ui://fteyf9nzrw6k1yjp7ul";

        public static btn_currency CreateInstance()
        {
            return (btn_currency)UIPackage.CreateObject("fun_Friends", "btn_currency");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n3 = (GImage)GetChildAt(0);
        }
    }
}