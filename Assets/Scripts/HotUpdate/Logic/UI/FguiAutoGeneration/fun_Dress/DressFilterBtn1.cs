/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Dress
{
    public partial class DressFilterBtn1 : GButton
    {
        public Controller button;
        public Controller type;
        public GImage n96;
        public GImage n95;
        public GImage n98;
        public GImage n99;
        public GImage n101;
        public GImage n103;
        public GImage n105;
        public GImage n107;
        public GImage n109;
        public GImage n111;
        public GGroup n113;
        public GImage n97;
        public GImage n100;
        public GImage n102;
        public GImage n104;
        public GImage n106;
        public GImage n108;
        public GImage n110;
        public GImage n112;
        public GGroup n114;
        public GTextField titleLab;
        public const string URL = "ui://argzn455kkb11yjp84k";

        public static DressFilterBtn1 CreateInstance()
        {
            return (DressFilterBtn1)UIPackage.CreateObject("fun_Dress", "DressFilterBtn1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            type = GetControllerAt(1);
            n96 = (GImage)GetChildAt(0);
            n95 = (GImage)GetChildAt(1);
            n98 = (GImage)GetChildAt(2);
            n99 = (GImage)GetChildAt(3);
            n101 = (GImage)GetChildAt(4);
            n103 = (GImage)GetChildAt(5);
            n105 = (GImage)GetChildAt(6);
            n107 = (GImage)GetChildAt(7);
            n109 = (GImage)GetChildAt(8);
            n111 = (GImage)GetChildAt(9);
            n113 = (GGroup)GetChildAt(10);
            n97 = (GImage)GetChildAt(11);
            n100 = (GImage)GetChildAt(12);
            n102 = (GImage)GetChildAt(13);
            n104 = (GImage)GetChildAt(14);
            n106 = (GImage)GetChildAt(15);
            n108 = (GImage)GetChildAt(16);
            n110 = (GImage)GetChildAt(17);
            n112 = (GImage)GetChildAt(18);
            n114 = (GGroup)GetChildAt(19);
            titleLab = (GTextField)GetChildAt(20);
        }
    }
}