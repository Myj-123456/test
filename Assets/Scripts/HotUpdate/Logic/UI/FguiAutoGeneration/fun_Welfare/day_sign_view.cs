/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Welfare
{
    public partial class day_sign_view : GComponent
    {
        public GLoader bg;
        public close_btn close_btn;
        public GImage n20;
        public GImage n3;
        public GImage n11;
        public GImage n12;
        public GImage n17;
        public GImage n18;
        public GTextField sign_num;
        public GTextField timeLab;
        public pro pro;
        public GImage n6;
        public GButton sign_btn;
        public GButton cost_btn;
        public GButton getted;
        public GList list;
        public const string URL = "ui://awswhm01g0s03";

        public static day_sign_view CreateInstance()
        {
            return (day_sign_view)UIPackage.CreateObject("fun_Welfare", "day_sign_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            close_btn = (close_btn)GetChildAt(1);
            n20 = (GImage)GetChildAt(2);
            n3 = (GImage)GetChildAt(3);
            n11 = (GImage)GetChildAt(4);
            n12 = (GImage)GetChildAt(5);
            n17 = (GImage)GetChildAt(6);
            n18 = (GImage)GetChildAt(7);
            sign_num = (GTextField)GetChildAt(8);
            timeLab = (GTextField)GetChildAt(9);
            pro = (pro)GetChildAt(10);
            n6 = (GImage)GetChildAt(11);
            sign_btn = (GButton)GetChildAt(12);
            cost_btn = (GButton)GetChildAt(13);
            getted = (GButton)GetChildAt(14);
            list = (GList)GetChildAt(15);
        }
    }
}