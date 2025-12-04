/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Welfare
{
    public partial class day_btn : GButton
    {
        public Controller button;
        public Controller type;
        public Controller unlock;
        public GImage n1;
        public GImage n2;
        public GImage n3;
        public GImage n4;
        public GImage n5;
        public GImage n6;
        public GImage n7;
        public GImage n8;
        public GImage n9;
        public GImage n10;
        public const string URL = "ui://awswhm01g0s01f";

        public static day_btn CreateInstance()
        {
            return (day_btn)UIPackage.CreateObject("fun_Welfare", "day_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            type = GetControllerAt(1);
            unlock = GetControllerAt(2);
            n1 = (GImage)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            n3 = (GImage)GetChildAt(2);
            n4 = (GImage)GetChildAt(3);
            n5 = (GImage)GetChildAt(4);
            n6 = (GImage)GetChildAt(5);
            n7 = (GImage)GetChildAt(6);
            n8 = (GImage)GetChildAt(7);
            n9 = (GImage)GetChildAt(8);
            n10 = (GImage)GetChildAt(9);
        }
    }
}