/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class Num_lessen : GButton
    {
        public Controller button;
        public GImage n1;
        public const string URL = "ui://fteyf9nzoanl1yjp7uq";

        public static Num_lessen CreateInstance()
        {
            return (Num_lessen)UIPackage.CreateObject("fun_Friends", "Num_lessen");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
        }
    }
}