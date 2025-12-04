/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Welfare
{
    public partial class box : GButton
    {
        public Controller status;
        public GImage n1;
        public GImage n2;
        public GImage n3;
        public GImage n6;
        public GImage n7;
        public GLoader pic;
        public GTextField numLab;
        public GTextField day_num;
        public const string URL = "ui://awswhm01g0s0b";

        public static box CreateInstance()
        {
            return (box)UIPackage.CreateObject("fun_Welfare", "box");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            n3 = (GImage)GetChildAt(2);
            n6 = (GImage)GetChildAt(3);
            n7 = (GImage)GetChildAt(4);
            pic = (GLoader)GetChildAt(5);
            numLab = (GTextField)GetChildAt(6);
            day_num = (GTextField)GetChildAt(7);
        }
    }
}