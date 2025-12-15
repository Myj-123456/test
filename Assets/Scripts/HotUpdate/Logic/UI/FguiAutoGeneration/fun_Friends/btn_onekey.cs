/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class btn_onekey : GButton
    {
        public Controller button;
        public GImage n3;
        public GImage n4;
        public GTextField n5;
        public GTextField n6;
        public const string URL = "ui://fteyf9nzcl9t1yjp7uo";

        public static btn_onekey CreateInstance()
        {
            return (btn_onekey)UIPackage.CreateObject("fun_Friends", "btn_onekey");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n3 = (GImage)GetChildAt(0);
            n4 = (GImage)GetChildAt(1);
            n5 = (GTextField)GetChildAt(2);
            n6 = (GTextField)GetChildAt(3);
        }
    }
}