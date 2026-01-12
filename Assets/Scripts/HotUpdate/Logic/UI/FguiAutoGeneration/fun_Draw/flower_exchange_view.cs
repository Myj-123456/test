/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Draw
{
    public partial class flower_exchange_view : GComponent
    {
        public GLoader bg1;
        public GImage n2;
        public GLoader img;
        public GLoader bg2;
        public GLoader rare_bg;
        public GLoader rare;
        public GTextField rare_name;
        public GImage n8;
        public GLoader pic;
        public GTextField numLab;
        public GGroup n11;
        public GImage n3;
        public GLoader pic2;
        public GTextField numLab2;
        public GGroup n7;
        public GList list;
        public GImage n17;
        public GTextField titleLab;
        public GButton help_btn;
        public GGroup n20;
        public GImage n21;
        public GButton backBtn;
        public const string URL = "ui://97nah3khj68svl";

        public static flower_exchange_view CreateInstance()
        {
            return (flower_exchange_view)UIPackage.CreateObject("fun_Draw", "flower_exchange_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg1 = (GLoader)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            img = (GLoader)GetChildAt(2);
            bg2 = (GLoader)GetChildAt(3);
            rare_bg = (GLoader)GetChildAt(4);
            rare = (GLoader)GetChildAt(5);
            rare_name = (GTextField)GetChildAt(6);
            n8 = (GImage)GetChildAt(7);
            pic = (GLoader)GetChildAt(8);
            numLab = (GTextField)GetChildAt(9);
            n11 = (GGroup)GetChildAt(10);
            n3 = (GImage)GetChildAt(11);
            pic2 = (GLoader)GetChildAt(12);
            numLab2 = (GTextField)GetChildAt(13);
            n7 = (GGroup)GetChildAt(14);
            list = (GList)GetChildAt(15);
            n17 = (GImage)GetChildAt(16);
            titleLab = (GTextField)GetChildAt(17);
            help_btn = (GButton)GetChildAt(18);
            n20 = (GGroup)GetChildAt(19);
            n21 = (GImage)GetChildAt(20);
            backBtn = (GButton)GetChildAt(21);
        }
    }
}