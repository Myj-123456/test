/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Welfare
{
    public partial class page_btn : GButton
    {
        public Controller button;
        public Controller status;
        public GImage n1;
        public GImage n4;
        public GImage n15;
        public GImage n16;
        public GImage n17;
        public GImage n14;
        public GTextField titleLab;
        public const string URL = "ui://awswhm01g0s01ayr82q";

        public static page_btn CreateInstance()
        {
            return (page_btn)UIPackage.CreateObject("fun_Welfare", "page_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            status = GetControllerAt(1);
            n1 = (GImage)GetChildAt(0);
            n4 = (GImage)GetChildAt(1);
            n15 = (GImage)GetChildAt(2);
            n16 = (GImage)GetChildAt(3);
            n17 = (GImage)GetChildAt(4);
            n14 = (GImage)GetChildAt(5);
            titleLab = (GTextField)GetChildAt(6);
        }
    }
}