/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_PopTips
{
    public partial class add_tips_item : GComponent
    {
        public Controller type;
        public Controller half;
        public Controller show_time;
        public GImage n0;
        public GTextField titleLab;
        public GImage n4;
        public GImage n9;
        public GImage n6;
        public GImage n7;
        public GImage n8;
        public GImage n13;
        public GImage n14;
        public GGroup n15;
        public GImage n16;
        public GImage n18;
        public GImage n17;
        public GGroup n19;
        public GTextField tip_lab;
        public GTextField timeLab;
        public GButton seach_btn;
        public video_btn video_btn;
        public price_btn buy_btn;
        public GImage n23;
        public GTextField dis_lab;
        public GGroup n25;
        public GTextField test_lab;
        public GTextField timeLab1;
        public GGroup grp;
        public GTextField video_lab;
        public GTextField limit_lab;
        public GGroup n40;
        public GButton vip_btn;
        public GTextField vip_lab;
        public GGroup n41;
        public const string URL = "ui://vhcdvi5tu25nj";

        public static add_tips_item CreateInstance()
        {
            return (add_tips_item)UIPackage.CreateObject("fun_PopTips", "add_tips_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            half = GetControllerAt(1);
            show_time = GetControllerAt(2);
            n0 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
            n4 = (GImage)GetChildAt(2);
            n9 = (GImage)GetChildAt(3);
            n6 = (GImage)GetChildAt(4);
            n7 = (GImage)GetChildAt(5);
            n8 = (GImage)GetChildAt(6);
            n13 = (GImage)GetChildAt(7);
            n14 = (GImage)GetChildAt(8);
            n15 = (GGroup)GetChildAt(9);
            n16 = (GImage)GetChildAt(10);
            n18 = (GImage)GetChildAt(11);
            n17 = (GImage)GetChildAt(12);
            n19 = (GGroup)GetChildAt(13);
            tip_lab = (GTextField)GetChildAt(14);
            timeLab = (GTextField)GetChildAt(15);
            seach_btn = (GButton)GetChildAt(16);
            video_btn = (video_btn)GetChildAt(17);
            buy_btn = (price_btn)GetChildAt(18);
            n23 = (GImage)GetChildAt(19);
            dis_lab = (GTextField)GetChildAt(20);
            n25 = (GGroup)GetChildAt(21);
            test_lab = (GTextField)GetChildAt(22);
            timeLab1 = (GTextField)GetChildAt(23);
            grp = (GGroup)GetChildAt(24);
            video_lab = (GTextField)GetChildAt(25);
            limit_lab = (GTextField)GetChildAt(26);
            n40 = (GGroup)GetChildAt(27);
            vip_btn = (GButton)GetChildAt(28);
            vip_lab = (GTextField)GetChildAt(29);
            n41 = (GGroup)GetChildAt(30);
        }
    }
}