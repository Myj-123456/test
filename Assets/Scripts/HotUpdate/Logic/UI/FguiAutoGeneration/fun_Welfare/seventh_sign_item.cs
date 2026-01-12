/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Welfare
{
    public partial class seventh_sign_item : GButton
    {
        public Controller button;
        public Controller status;
        public Controller type;
        public GGraph rect;
        public GImage n6;
        public GTextField dayLab;
        public GImage n7;
        public GImage n8;
        public GImage n3;
        public GImage n10;
        public GGroup n11;
        public GImage n13;
        public GLoader pic;
        public GTextField dayLab1;
        public GLoader3D spine;
        public GImage n17;
        public GTextField nameLab;
        public GImage n25;
        public GImage n20;
        public GGroup n21;
        public const string URL = "ui://awswhm01s7sl1yjp849";

        public static seventh_sign_item CreateInstance()
        {
            return (seventh_sign_item)UIPackage.CreateObject("fun_Welfare", "seventh_sign_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            status = GetControllerAt(1);
            type = GetControllerAt(2);
            rect = (GGraph)GetChildAt(0);
            n6 = (GImage)GetChildAt(1);
            dayLab = (GTextField)GetChildAt(2);
            n7 = (GImage)GetChildAt(3);
            n8 = (GImage)GetChildAt(4);
            n3 = (GImage)GetChildAt(5);
            n10 = (GImage)GetChildAt(6);
            n11 = (GGroup)GetChildAt(7);
            n13 = (GImage)GetChildAt(8);
            pic = (GLoader)GetChildAt(9);
            dayLab1 = (GTextField)GetChildAt(10);
            spine = (GLoader3D)GetChildAt(11);
            n17 = (GImage)GetChildAt(12);
            nameLab = (GTextField)GetChildAt(13);
            n25 = (GImage)GetChildAt(14);
            n20 = (GImage)GetChildAt(15);
            n21 = (GGroup)GetChildAt(16);
        }
    }
}