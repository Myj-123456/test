/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Welfare
{
    public partial class sign_item1 : GComponent
    {
        public Controller type;
        public Controller status;
        public GImage n0;
        public GImage n1;
        public GImage n5;
        public GLoader pic;
        public GTextField day_num;
        public GTextField numLab;
        public GImage n7;
        public GImage n6;
        public const string URL = "ui://awswhm01g0s0x";

        public static sign_item1 CreateInstance()
        {
            return (sign_item1)UIPackage.CreateObject("fun_Welfare", "sign_item1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            status = GetControllerAt(1);
            n0 = (GImage)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
            n5 = (GImage)GetChildAt(2);
            pic = (GLoader)GetChildAt(3);
            day_num = (GTextField)GetChildAt(4);
            numLab = (GTextField)GetChildAt(5);
            n7 = (GImage)GetChildAt(6);
            n6 = (GImage)GetChildAt(7);
        }
    }
}