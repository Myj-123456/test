/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_VipShop
{
    public partial class page_btn : GButton
    {
        public Controller button;
        public Controller type;
        public GImage n0;
        public GImage n1;
        public GImage n2;
        public GImage n3;
        public GImage n4;
        public GTextField titleLab;
        public const string URL = "ui://wm7arakyvedm1ayr7sa";

        public static page_btn CreateInstance()
        {
            return (page_btn)UIPackage.CreateObject("fun_VipShop", "page_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            type = GetControllerAt(1);
            n0 = (GImage)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
            n2 = (GImage)GetChildAt(2);
            n3 = (GImage)GetChildAt(3);
            n4 = (GImage)GetChildAt(4);
            titleLab = (GTextField)GetChildAt(5);
        }
    }
}