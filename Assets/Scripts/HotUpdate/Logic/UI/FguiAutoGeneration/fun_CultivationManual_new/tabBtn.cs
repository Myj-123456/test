/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class tabBtn : GButton
    {
        public Controller button;
        public Controller type;
        public GImage n6;
        public GImage n8;
        public GImage n9;
        public GImage n17;
        public GImage n19;
        public GGroup n20;
        public GImage n12;
        public GImage n11;
        public GImage n16;
        public GImage n18;
        public GGroup n21;
        public const string URL = "ui://ekoic0wriust1yjp7sq";

        public static tabBtn CreateInstance()
        {
            return (tabBtn)UIPackage.CreateObject("fun_CultivationManual_new", "tabBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            type = GetControllerAt(1);
            n6 = (GImage)GetChildAt(0);
            n8 = (GImage)GetChildAt(1);
            n9 = (GImage)GetChildAt(2);
            n17 = (GImage)GetChildAt(3);
            n19 = (GImage)GetChildAt(4);
            n20 = (GGroup)GetChildAt(5);
            n12 = (GImage)GetChildAt(6);
            n11 = (GImage)GetChildAt(7);
            n16 = (GImage)GetChildAt(8);
            n18 = (GImage)GetChildAt(9);
            n21 = (GGroup)GetChildAt(10);
        }
    }
}