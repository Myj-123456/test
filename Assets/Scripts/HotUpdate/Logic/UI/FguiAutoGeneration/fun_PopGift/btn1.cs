/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_PopGift
{
    public partial class btn1 : GComponent
    {
        public Controller type;
        public GImage n6;
        public GImage n7;
        public const string URL = "ui://ah12m40ag0s0d";

        public static btn1 CreateInstance()
        {
            return (btn1)UIPackage.CreateObject("fun_PopGift", "btn1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            n6 = (GImage)GetChildAt(0);
            n7 = (GImage)GetChildAt(1);
        }
    }
}