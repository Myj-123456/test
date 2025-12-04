/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class btnHome : GButton
    {
        public Controller button;
        public GImage n6;
        public GImage n7;
        public GTextField n8;
        public const string URL = "ui://fteyf9nzivvl1yjp7tj";

        public static btnHome CreateInstance()
        {
            return (btnHome)UIPackage.CreateObject("fun_Friends", "btnHome");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n6 = (GImage)GetChildAt(0);
            n7 = (GImage)GetChildAt(1);
            n8 = (GTextField)GetChildAt(2);
        }
    }
}