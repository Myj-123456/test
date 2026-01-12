/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class page_btn4 : GButton
    {
        public Controller button;
        public Controller ctrl;
        public GImage n21;
        public GImage n22;
        public GTextField titleLab;
        public GImage red_point;
        public GImage n23;
        public const string URL = "ui://w3ox9ylto52y1yjp88x";

        public static page_btn4 CreateInstance()
        {
            return (page_btn4)UIPackage.CreateObject("fun_Recharge", "page_btn4");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            ctrl = GetControllerAt(1);
            n21 = (GImage)GetChildAt(0);
            n22 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
            red_point = (GImage)GetChildAt(3);
            n23 = (GImage)GetChildAt(4);
        }
    }
}