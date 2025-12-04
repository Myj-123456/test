/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Customer
{
    public partial class like_level_view : GComponent
    {
        public Controller max;
        public GImage n3;
        public GLoader bg;
        public GImage n4;
        public GButton close_btn;
        public GImage n5;
        public pro curPro;
        public GTextField curProLab;
        public GTextField curAddLab;
        public GRichTextField curAdd;
        public GGroup n15;
        public GImage n6;
        public pro nextPro;
        public GTextField nextProLab;
        public GTextField nextAddLab;
        public GRichTextField nextAdd;
        public GGroup n16;
        public const string URL = "ui://pcr735xhcs1mw";

        public static like_level_view CreateInstance()
        {
            return (like_level_view)UIPackage.CreateObject("fun_Customer", "like_level_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            max = GetControllerAt(0);
            n3 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n4 = (GImage)GetChildAt(2);
            close_btn = (GButton)GetChildAt(3);
            n5 = (GImage)GetChildAt(4);
            curPro = (pro)GetChildAt(5);
            curProLab = (GTextField)GetChildAt(6);
            curAddLab = (GTextField)GetChildAt(7);
            curAdd = (GRichTextField)GetChildAt(8);
            n15 = (GGroup)GetChildAt(9);
            n6 = (GImage)GetChildAt(10);
            nextPro = (pro)GetChildAt(11);
            nextProLab = (GTextField)GetChildAt(12);
            nextAddLab = (GTextField)GetChildAt(13);
            nextAdd = (GRichTextField)GetChildAt(14);
            n16 = (GGroup)GetChildAt(15);
        }
    }
}