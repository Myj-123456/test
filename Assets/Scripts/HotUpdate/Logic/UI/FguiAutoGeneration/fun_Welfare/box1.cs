/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Welfare
{
    public partial class box1 : GComponent
    {
        public Controller status;
        public Controller type;
        public GImage n10;
        public GImage n13;
        public GLoader pic;
        public GLoader pic1;
        public GTextField numLab;
        public GTextField day_num;
        public GImage n11;
        public GImage n15;
        public GGraph rect;
        public const string URL = "ui://awswhm01g0s01c";

        public static box1 CreateInstance()
        {
            return (box1)UIPackage.CreateObject("fun_Welfare", "box1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            type = GetControllerAt(1);
            n10 = (GImage)GetChildAt(0);
            n13 = (GImage)GetChildAt(1);
            pic = (GLoader)GetChildAt(2);
            pic1 = (GLoader)GetChildAt(3);
            numLab = (GTextField)GetChildAt(4);
            day_num = (GTextField)GetChildAt(5);
            n11 = (GImage)GetChildAt(6);
            n15 = (GImage)GetChildAt(7);
            rect = (GGraph)GetChildAt(8);
        }
    }
}