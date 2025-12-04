/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class btn_lookup : GButton
    {
        public Controller button;
        public GImage n0;
        public const string URL = "ui://fteyf9nzg3sj1yjp7tn";

        public static btn_lookup CreateInstance()
        {
            return (btn_lookup)UIPackage.CreateObject("fun_Friends", "btn_lookup");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n0 = (GImage)GetChildAt(0);
        }
    }
}