/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Tour_Land
{
    public partial class style_info_view : GComponent
    {
        public GLoader bg;
        public GImage n2;
        public GButton close_btn;
        public GImage n24;
        public GImage n4;
        public GImage n5;
        public GImage n6;
        public GImage n7;
        public GImage n12;
        public GImage n13;
        public GImage n14;
        public GImage n15;
        public GImage n8;
        public GImage n9;
        public GImage n10;
        public GImage n11;
        public GTextField pareLab1;
        public GTextField effectLab1;
        public GTextField pareLab2;
        public GTextField effectLab2;
        public GTextField pareLab3;
        public GTextField effectLab3;
        public GTextField pareLab4;
        public GTextField effectLab4;
        public const string URL = "ui://oo5kr0yox92m2r";

        public static style_info_view CreateInstance()
        {
            return (style_info_view)UIPackage.CreateObject("fun_Tour_Land", "style_info_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            close_btn = (GButton)GetChildAt(2);
            n24 = (GImage)GetChildAt(3);
            n4 = (GImage)GetChildAt(4);
            n5 = (GImage)GetChildAt(5);
            n6 = (GImage)GetChildAt(6);
            n7 = (GImage)GetChildAt(7);
            n12 = (GImage)GetChildAt(8);
            n13 = (GImage)GetChildAt(9);
            n14 = (GImage)GetChildAt(10);
            n15 = (GImage)GetChildAt(11);
            n8 = (GImage)GetChildAt(12);
            n9 = (GImage)GetChildAt(13);
            n10 = (GImage)GetChildAt(14);
            n11 = (GImage)GetChildAt(15);
            pareLab1 = (GTextField)GetChildAt(16);
            effectLab1 = (GTextField)GetChildAt(17);
            pareLab2 = (GTextField)GetChildAt(18);
            effectLab2 = (GTextField)GetChildAt(19);
            pareLab3 = (GTextField)GetChildAt(20);
            effectLab3 = (GTextField)GetChildAt(21);
            pareLab4 = (GTextField)GetChildAt(22);
            effectLab4 = (GTextField)GetChildAt(23);
        }
    }
}