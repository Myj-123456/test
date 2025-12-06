/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_PopTips
{
    public partial class video_doublr_view : GComponent
    {
        public Controller status;
        public Controller type;
        public GLoader bg;
        public GImage n2;
        public GImage n3;
        public GTextField titleLab;
        public GImage n5;
        public GImage n6;
        public GImage n7;
        public GImage n8;
        public GImage n9;
        public GTextField lab1;
        public GTextField lab2;
        public GTextField lab3;
        public GTextField lab4;
        public GImage n14;
        public GImage n15;
        public GButton close_btn;
        public GButton seach_btn;
        public GTextField timeLab;
        public GButton video_btn;
        public GButton buy_btn1;
        public GButton buy_btn;
        public GImage n18;
        public GTextField dis_lab;
        public GGroup n20;
        public GTextField test_lab;
        public GTextField timeLab1;
        public GGroup grp;
        public GGroup n35;
        public const string URL = "ui://vhcdvi5tkelj1yjp84p";

        public static video_doublr_view CreateInstance()
        {
            return (video_doublr_view)UIPackage.CreateObject("fun_PopTips", "video_doublr_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            type = GetControllerAt(1);
            bg = (GLoader)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            n3 = (GImage)GetChildAt(2);
            titleLab = (GTextField)GetChildAt(3);
            n5 = (GImage)GetChildAt(4);
            n6 = (GImage)GetChildAt(5);
            n7 = (GImage)GetChildAt(6);
            n8 = (GImage)GetChildAt(7);
            n9 = (GImage)GetChildAt(8);
            lab1 = (GTextField)GetChildAt(9);
            lab2 = (GTextField)GetChildAt(10);
            lab3 = (GTextField)GetChildAt(11);
            lab4 = (GTextField)GetChildAt(12);
            n14 = (GImage)GetChildAt(13);
            n15 = (GImage)GetChildAt(14);
            close_btn = (GButton)GetChildAt(15);
            seach_btn = (GButton)GetChildAt(16);
            timeLab = (GTextField)GetChildAt(17);
            video_btn = (GButton)GetChildAt(18);
            buy_btn1 = (GButton)GetChildAt(19);
            buy_btn = (GButton)GetChildAt(20);
            n18 = (GImage)GetChildAt(21);
            dis_lab = (GTextField)GetChildAt(22);
            n20 = (GGroup)GetChildAt(23);
            test_lab = (GTextField)GetChildAt(24);
            timeLab1 = (GTextField)GetChildAt(25);
            grp = (GGroup)GetChildAt(26);
            n35 = (GGroup)GetChildAt(27);
        }
    }
}