/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Welfare
{
    public partial class sign_view : GComponent
    {
        public GLoader bg;
        public GImage n23;
        public GImage n19;
        public GImage n21;
        public GImage n22;
        public GImage n20;
        public GImage n17;
        public GImage n18;
        public GGroup n24;
        public GImage n3;
        public GImage n4;
        public GTextField day_num;
        public pro pro;
        public GGroup n11;
        public GTextField timeLab;
        public GButton sign_btn;
        public GButton getted;
        public GButton cost_btn;
        public GGroup n12;
        public GList list;
        public const string URL = "ui://awswhm01g0s0v";

        public static sign_view CreateInstance()
        {
            return (sign_view)UIPackage.CreateObject("fun_Welfare", "sign_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            n23 = (GImage)GetChildAt(1);
            n19 = (GImage)GetChildAt(2);
            n21 = (GImage)GetChildAt(3);
            n22 = (GImage)GetChildAt(4);
            n20 = (GImage)GetChildAt(5);
            n17 = (GImage)GetChildAt(6);
            n18 = (GImage)GetChildAt(7);
            n24 = (GGroup)GetChildAt(8);
            n3 = (GImage)GetChildAt(9);
            n4 = (GImage)GetChildAt(10);
            day_num = (GTextField)GetChildAt(11);
            pro = (pro)GetChildAt(12);
            n11 = (GGroup)GetChildAt(13);
            timeLab = (GTextField)GetChildAt(14);
            sign_btn = (GButton)GetChildAt(15);
            getted = (GButton)GetChildAt(16);
            cost_btn = (GButton)GetChildAt(17);
            n12 = (GGroup)GetChildAt(18);
            list = (GList)GetChildAt(19);
        }
    }
}