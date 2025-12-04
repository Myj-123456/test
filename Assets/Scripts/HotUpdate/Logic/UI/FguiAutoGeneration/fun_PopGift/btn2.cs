/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_PopGift
{
    public partial class btn2 : GButton
    {
        public Controller type;
        public GImage n7;
        public const string URL = "ui://ah12m40ag0s0f";

        public static btn2 CreateInstance()
        {
            return (btn2)UIPackage.CreateObject("fun_PopGift", "btn2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            n7 = (GImage)GetChildAt(0);
        }
    }
}