/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Florist
{
    public partial class florisr_info_view : GComponent
    {
        public Controller tab;
        public GLoader bg;
        public florist_book_item floristInfo;
        public GButton left_btn;
        public GButton right_btn;
        public GGroup n67;
        public GList house_list;
        public GImage n58;
        public GImage n59;
        public GImage n60;
        public GTextField houseLab;
        public GGroup n63;
        public GImage n1;
        public GTextField titleLab;
        public GButton help_btn;
        public GGroup n65;
        public GImage n3;
        public GImage n8;
        public pageBtn1 info_btn;
        public pageBtn1 house_btn;
        public GButton close_btn;
        public GGroup n66;
        public GImage n46;
        public GImage n47;
        public GImage n48;
        public GTextField suitLab;
        public GList florist_list;
        public GGroup n69;
        public GImage n50;
        public GImage n51;
        public GImage n52;
        public GTextField addLab;
        public GList nature_list;
        public GGroup n71;
        public const string URL = "ui://nj16dzxym3ghb";

        public static florisr_info_view CreateInstance()
        {
            return (florisr_info_view)UIPackage.CreateObject("fun_Florist", "florisr_info_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tab = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            floristInfo = (florist_book_item)GetChildAt(1);
            left_btn = (GButton)GetChildAt(2);
            right_btn = (GButton)GetChildAt(3);
            n67 = (GGroup)GetChildAt(4);
            house_list = (GList)GetChildAt(5);
            n58 = (GImage)GetChildAt(6);
            n59 = (GImage)GetChildAt(7);
            n60 = (GImage)GetChildAt(8);
            houseLab = (GTextField)GetChildAt(9);
            n63 = (GGroup)GetChildAt(10);
            n1 = (GImage)GetChildAt(11);
            titleLab = (GTextField)GetChildAt(12);
            help_btn = (GButton)GetChildAt(13);
            n65 = (GGroup)GetChildAt(14);
            n3 = (GImage)GetChildAt(15);
            n8 = (GImage)GetChildAt(16);
            info_btn = (pageBtn1)GetChildAt(17);
            house_btn = (pageBtn1)GetChildAt(18);
            close_btn = (GButton)GetChildAt(19);
            n66 = (GGroup)GetChildAt(20);
            n46 = (GImage)GetChildAt(21);
            n47 = (GImage)GetChildAt(22);
            n48 = (GImage)GetChildAt(23);
            suitLab = (GTextField)GetChildAt(24);
            florist_list = (GList)GetChildAt(25);
            n69 = (GGroup)GetChildAt(26);
            n50 = (GImage)GetChildAt(27);
            n51 = (GImage)GetChildAt(28);
            n52 = (GImage)GetChildAt(29);
            addLab = (GTextField)GetChildAt(30);
            nature_list = (GList)GetChildAt(31);
            n71 = (GGroup)GetChildAt(32);
        }
    }
}