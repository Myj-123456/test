/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Welfare
{
    public partial class turntable_view : GComponent
    {
        public Controller textColorctrl;
        public Controller status;
        public GLoader bg;
        public GImage n15;
        public GImage n14;
        public GImage n13;
        public turntable_com com;
        public GTextField numLab;
        public GTextField numLab2;
        public GImage n8;
        public GButton get_btn;
        public skip_btn skip_btn;
        public share_btn share_btn;
        public GImage n10;
        public GTextField time_text;
        public GTextField n12;
        public GGroup n17;
        public GGroup n4;
        public const string URL = "ui://awswhm01v01m1yjp845";

        public static turntable_view CreateInstance()
        {
            return (turntable_view)UIPackage.CreateObject("fun_Welfare", "turntable_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            textColorctrl = GetControllerAt(0);
            status = GetControllerAt(1);
            bg = (GLoader)GetChildAt(0);
            n15 = (GImage)GetChildAt(1);
            n14 = (GImage)GetChildAt(2);
            n13 = (GImage)GetChildAt(3);
            com = (turntable_com)GetChildAt(4);
            numLab = (GTextField)GetChildAt(5);
            numLab2 = (GTextField)GetChildAt(6);
            n8 = (GImage)GetChildAt(7);
            get_btn = (GButton)GetChildAt(8);
            skip_btn = (skip_btn)GetChildAt(9);
            share_btn = (share_btn)GetChildAt(10);
            n10 = (GImage)GetChildAt(11);
            time_text = (GTextField)GetChildAt(12);
            n12 = (GTextField)GetChildAt(13);
            n17 = (GGroup)GetChildAt(14);
            n4 = (GGroup)GetChildAt(15);
        }
    }
}