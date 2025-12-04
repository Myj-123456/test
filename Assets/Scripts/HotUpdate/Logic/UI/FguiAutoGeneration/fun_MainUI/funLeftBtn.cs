/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MainUI
{
    public partial class funLeftBtn : GButton
    {
        public Controller type;
        public Controller status;
        public GGraph n113;
        public GImage n102;
        public GImage n104;
        public GImage n105;
        public GImage n106;
        public GImage n107;
        public GLoader draw_img;
        public GImage n110;
        public GImage n109;
        public GImage n111;
        public GImage n112;
        public GImage red_point;
        public GTextField timeLab;
        public const string URL = "ui://fa0hi8ybfm3f32";

        public static funLeftBtn CreateInstance()
        {
            return (funLeftBtn)UIPackage.CreateObject("fun_MainUI", "funLeftBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            status = GetControllerAt(1);
            n113 = (GGraph)GetChildAt(0);
            n102 = (GImage)GetChildAt(1);
            n104 = (GImage)GetChildAt(2);
            n105 = (GImage)GetChildAt(3);
            n106 = (GImage)GetChildAt(4);
            n107 = (GImage)GetChildAt(5);
            draw_img = (GLoader)GetChildAt(6);
            n110 = (GImage)GetChildAt(7);
            n109 = (GImage)GetChildAt(8);
            n111 = (GImage)GetChildAt(9);
            n112 = (GImage)GetChildAt(10);
            red_point = (GImage)GetChildAt(11);
            timeLab = (GTextField)GetChildAt(12);
        }
    }
}