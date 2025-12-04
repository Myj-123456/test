/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Pet
{
    public partial class tabBtn1 : GButton
    {
        public Controller button;
        public Controller type;
        public GImage n15;
        public GImage n16;
        public GImage n19;
        public GImage n20;
        public GGroup n23;
        public GImage n21;
        public GImage n22;
        public GGroup n24;
        public GImage n25;
        public GImage n26;
        public GGroup n27;
        public GImage red_point;
        public const string URL = "ui://o7kmyysdx92m1yjp7xs";

        public static tabBtn1 CreateInstance()
        {
            return (tabBtn1)UIPackage.CreateObject("fun_Pet", "tabBtn1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            type = GetControllerAt(1);
            n15 = (GImage)GetChildAt(0);
            n16 = (GImage)GetChildAt(1);
            n19 = (GImage)GetChildAt(2);
            n20 = (GImage)GetChildAt(3);
            n23 = (GGroup)GetChildAt(4);
            n21 = (GImage)GetChildAt(5);
            n22 = (GImage)GetChildAt(6);
            n24 = (GGroup)GetChildAt(7);
            n25 = (GImage)GetChildAt(8);
            n26 = (GImage)GetChildAt(9);
            n27 = (GGroup)GetChildAt(10);
            red_point = (GImage)GetChildAt(11);
        }
    }
}